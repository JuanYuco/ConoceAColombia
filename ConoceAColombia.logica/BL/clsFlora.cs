using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace ConoceAColombia.logica.BL
{
    public class clsFlora
    {
        public List<Models.clsFlora>getFlora()
        {
            try
            {
                using(Entidades.bdConoceAColombiaEntities obDatos = new Entidades.bdConoceAColombiaEntities())
                {
                    List<Models.clsFlora> lstclFlora = (from q in obDatos.tbFlora
                                                        join tbDep in obDatos.tbDepartamento on q.depaCodigo equals tbDep.depaCodigo
                                                        select new Models.clsFlora
                                                        {
                                                            lgCodigo = q.florCodigo,
                                                            stNombre = q.florNomComun,
                                                            stNombreCientifico = q.florNomCientifico,
                                                            stAbundancia = q.florAbundancia,
                                                            stDescripcion = q.florDescripcion,
                                                            stPeriodoFloracion = q.florPeriodoFloracion,
                                                            stLatitud = q.florLatitud,
                                                            stLongitud = q.florLongitud,
                                                            obclsDepartamentos = new Models.clsDepartamentos
                                                            {
                                                                inCodigo = q.depaCodigo,
                                                                stNombre = tbDep.depaNombre
                                                                
                                                            }
                                                        }).ToList();
                    return lstclFlora;
                                                        
                }
            }catch(Exception ew)
            {
                throw ew;
            }
        }




        public void InsertFlora(Models.clsFlora obclsFlora)
        {
            try
            {
                using(Entidades.bdConoceAColombiaEntities obDatos = new Entidades.bdConoceAColombiaEntities())
                {
                    obDatos.tbFlora.Add(new Entidades.tbFlora
                    {
                        florCodigo = obclsFlora.lgCodigo,
                        florNomComun = obclsFlora.stNombre,
                        florNomCientifico = obclsFlora.stNombreCientifico,
                        florDescripcion = obclsFlora.stDescripcion,
                        florAbundancia = obclsFlora.stAbundancia,
                        florPeriodoFloracion = obclsFlora.stPeriodoFloracion,
                        florLatitud = obclsFlora.stLatitud,
                        florLongitud = obclsFlora.stLongitud,
                        depaCodigo = obclsFlora.obclsDepartamentos.inCodigo
                    });
                    obDatos.SaveChanges();
                }
            }catch(Exception ew)
            {
                throw ew;
            }
        }


        public List<Models.clsFlora> getFloraNuevo(string stNombreCompleto)
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obDatos = new Entidades.bdConoceAColombiaEntities())
                {
                    List<Models.clsFlora> lstclFlora = (from q in obDatos.tbFlora
                                                        where (q.florNomComun + " " + q.florNomCientifico).ToLower().Contains(stNombreCompleto.ToLower())
                                                        select new Models.clsFlora
                                                        {
                                                            lgCodigo = q.florCodigo,
                                                            stNombre = q.florNomComun,
                                                            stNombreCientifico = q.florNomCientifico
                                                        } ).ToList();
                    return lstclFlora;

                }
            }
            catch (Exception ew)
            {
                throw ew;
            }
        }


        public string addFlora(Models.clsFlora obclsFlora)
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obDatos = new Entidades.bdConoceAColombiaEntities())
                {
                    obDatos.tbFlora.Add(new Entidades.tbFlora
                    {
                        florCodigo = obclsFlora.lgCodigo,
                        florNomComun = obclsFlora.stNombre,
                        florNomCientifico = obclsFlora.stNombreCientifico,
                        florDescripcion = obclsFlora.stDescripcion,
                        florAbundancia = obclsFlora.stAbundancia,
                        florPeriodoFloracion = obclsFlora.stPeriodoFloracion,
                        florLatitud = obclsFlora.stLatitud,
                        florLongitud = obclsFlora.stLongitud,
                        depaCodigo = obclsFlora.obclsDepartamentos.inCodigo
                    });
                    obDatos.SaveChanges();
                    return "Se realizo con exito";
                }
            }
            catch (Exception ew)
            {
                throw ew;
            }
        }


        public string updateFlora(Models.clsFlora ob)
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obbdConoceAColombiaEntities =
                    new Entidades.bdConoceAColombiaEntities())
                {
                    Entidades.tbFlora obtbFlora = (from q in obbdConoceAColombiaEntities.tbFlora
                                                   where q.florCodigo == ob.lgCodigo
                                                   select q).FirstOrDefault();
                    obtbFlora.florNomCientifico = ob.stNombreCientifico;
                    obtbFlora.florNomComun = ob.stNombre;
                    obtbFlora.florDescripcion = ob.stDescripcion;
                    obtbFlora.florAbundancia = ob.stAbundancia;
                    obtbFlora.florPeriodoFloracion = ob.stPeriodoFloracion;
                    obtbFlora.florLatitud = ob.stLatitud;
                    obtbFlora.florLongitud = ob.stLongitud;
                    obtbFlora.depaCodigo = ob.obclsDepartamentos.inCodigo;
                    obbdConoceAColombiaEntities.SaveChanges();

                    return "Se realizo proceso con exito";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string deleteFlora(Models.clsFlora ob)
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obbdConoceAColombiaEntities =
                    new Entidades.bdConoceAColombiaEntities())
                {
                    Entidades.tbFlora obtbFlora = (from q in obbdConoceAColombiaEntities.tbFlora
                                                   where q.florCodigo == ob.lgCodigo
                                                   select q).FirstOrDefault();
                    obbdConoceAColombiaEntities.tbFlora.Remove(obtbFlora);
                    obbdConoceAColombiaEntities.SaveChanges();

                    return "Se realizo proceso con exito";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public List<Models.clsDepartamentos> getDepartamentos()
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obDatos = new Entidades.bdConoceAColombiaEntities())
                {
                    List<Models.clsDepartamentos> lstclsDepartamentos = (from q in obDatos.tbDepartamento
                                                                         select new Models.clsDepartamentos
                                                                         {
                                                                             inCodigo = q.depaCodigo,
                                                                             stNombre = q.depaNombre
                                                                         }).ToList();
                    return lstclsDepartamentos;
                }

            }
            catch (Exception ew)
            {
                throw ew;
            }
        }


        public void CargarControlDepartamento(ref DropDownList ddlControl, List<Models.clsDepartamentos> dsConsulta, String stValor, String stTexto, String stValorEmcabezado, String stTextoEmcabezado)
        {
            try
            {
                ddlControl.DataSource = dsConsulta;
                ddlControl.DataTextField = stTexto;
                ddlControl.DataValueField = stValor;
                ddlControl.DataBind();

                ddlControl.Items.Insert(0, new ListItem(stTextoEmcabezado, stValorEmcabezado));

            }
            catch (Exception ew)
            {
                throw ew;
            }
        }
    }
}
