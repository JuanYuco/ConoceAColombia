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
                                                        join tbTF in obDatos.tbTipoFlora on q.florTipo equals tbTF.tiflCodigo
                                                        select new Models.clsFlora
                                                        {
                                                            lgCodigo = q.florCodigo,
                                                            stNombre = q.florNomComun,
                                                            stNombreCientifico = q.florNomCientifico,
                                                            stAbundancia = q.florAbundancia,
                                                            stDescripcion = q.florDescripcion,
                                                            stPeriodoFloracion = q.florPeriodoFloracion,
                                                            obclsTipoFlora = new Models.clsTipoFlora
                                                            {
                                                                lgCodigo = q.florTipo,
                                                                stDescripcion = tbTF.tiflDescripcion
                                                            }

                                                        }).ToList();
                    return lstclFlora;
                                                        
                }
            }catch(Exception ew)
            {
                throw ew;
            }
        }




        public string insertFlora(Models.clsFlora obclsFlora)
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
                        florTipo = obclsFlora.obclsTipoFlora.lgCodigo
                    });
                    obDatos.SaveChanges();
                    return "Se realizo con exito";
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
                    obtbFlora.florTipo = ob.obclsTipoFlora.lgCodigo;
                    
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



        public List<Models.clsTipoFlora> getTipoFlora()
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obDatos = new Entidades.bdConoceAColombiaEntities())
                {
                    List<Models.clsTipoFlora> lstclsTipoFlora = (from q in obDatos.tbTipoFlora
                                                                         select new Models.clsTipoFlora
                                                                         {
                                                                             lgCodigo = q.tiflCodigo,
                                                                             stDescripcion = q.tiflDescripcion
                                                                         }).ToList();
                    return lstclsTipoFlora;
                }

            }
            catch (Exception ew)
            {
                throw ew;
            }
        }


        public void CargarControlTipoFlora(ref DropDownList ddlControl, List<Models.clsTipoFlora> dsConsulta, String stValor, String stTexto, String stValorEmcabezado, String stTextoEmcabezado)
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
