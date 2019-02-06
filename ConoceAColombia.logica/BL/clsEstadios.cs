using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace ConoceAColombia.logica.BL
{
    public class clsEstadios
    {
        public string insertEstadios(Models.clsEstadios ob)
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obbdConoceAColombiaEntities =
                    new Entidades.bdConoceAColombiaEntities())
                {
                    Entidades.tbEstadios obtbEstadios = new Entidades.tbEstadios
                    {
                        estaCodigo = ob.lgCodigo,
                        estaNombre = ob.stNombre,
                        estaDescripcion = ob.stDescripcion,
                        estaFundacion = ob.stFundacion,
                        estaCapacidad = ob.stCapacidad,
                        estaCiudad = ob.stCiudad,
                        estaLatitud = ob.stLatitud,
                        estaLongitud = ob.stLongitud,
                        estaDepartamento = ob.obclsDepartamento.inCodigo,
                        estaDeporte = ob.obclsDeporte.lgCodigo,
                        estaImagen = ob.stImagen
                    };
                    obbdConoceAColombiaEntities.tbEstadios.Add(obtbEstadios);
                    obbdConoceAColombiaEntities.SaveChanges();

                    return "Se realizo proceso con exito";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public string updateEstadios(Models.clsEstadios ob)
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obbdConoceAColombiaEntities =
                    new Entidades.bdConoceAColombiaEntities())
                {
                    Entidades.tbEstadios obtbEstadios = (from q in obbdConoceAColombiaEntities.tbEstadios
                                                        where q.estaCodigo == ob.lgCodigo
                                                        select q).FirstOrDefault();
                    obtbEstadios.estaNombre = ob.stNombre;
                    obtbEstadios.estaDescripcion = ob.stDescripcion;
                    obtbEstadios.estaFundacion = ob.stFundacion;
                    obtbEstadios.estaCapacidad = ob.stCapacidad;
                    obtbEstadios.estaCiudad = ob.stCiudad;
                    obtbEstadios.estaImagen = ob.stImagen;
                    obtbEstadios.estaLatitud = ob.stLatitud;
                    obtbEstadios.estaLongitud = ob.stLongitud;
                    obtbEstadios.estaDepartamento = ob.obclsDepartamento.inCodigo;
                    obtbEstadios.estaDeporte = ob.obclsDeporte.lgCodigo;
                    obbdConoceAColombiaEntities.SaveChanges();

                    return "Se realizo proceso con exito";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public string deleteEstadios(Models.clsEstadios ob)
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obbdConoceAColombiaEntities =
                    new Entidades.bdConoceAColombiaEntities())
                {
                    Entidades.tbEstadios obtbEstadios = (from q in obbdConoceAColombiaEntities.tbEstadios
                                                         where q.estaCodigo == ob.lgCodigo
                                                         select q).FirstOrDefault();
                    obbdConoceAColombiaEntities.tbEstadios.Remove(obtbEstadios);
                    obbdConoceAColombiaEntities.SaveChanges();

                    return "Se realizo proceso con exito";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Models.clsEstadios> getEstadios()
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obbdConoceAColombiaEntities =
                    new Entidades.bdConoceAColombiaEntities())
                {
                    List<Models.clsEstadios> lstclsEstadios
                        = (from q in obbdConoceAColombiaEntities.tbEstadios
                           join tbDe in obbdConoceAColombiaEntities.tbDeportes on q.estaDeporte equals tbDe.depoCodigo
                           join tbDp in obbdConoceAColombiaEntities.tbDepartamento on q.estaDepartamento equals tbDp.depaCodigo
                           select new Models.clsEstadios
                           {
                               lgCodigo = q.estaCodigo,
                               stNombre = q.estaNombre,
                               stDescripcion = q.estaDescripcion,
                               stFundacion = q.estaFundacion,
                               stCapacidad = q.estaCapacidad,
                               stCiudad = q.estaCiudad,
                               stImagen = q.estaImagen,
                               stLatitud = q.estaLatitud,
                               stLongitud = q.estaLongitud,
                               obclsDeporte = new Models.clsDeportes
                               {
                                   lgCodigo = q.estaDeporte,
                                   stNombre = tbDe.depoNombre
                               },
                               obclsDepartamento = new Models.clsDepartamentos
                               {
                                   inCodigo = q.estaDepartamento,
                                   stNombre = tbDp.depaNombre
                               }
                           }).ToList();

                    return lstclsEstadios;
                }

            }
            catch (Exception ex) { throw ex; }
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


        public List<Models.clsDeportes> getDeportes()
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obDatos = new Entidades.bdConoceAColombiaEntities())
                {
                    List<Models.clsDeportes> lstclsDeportes = (from q in obDatos.tbDeportes
                                                                       select new Models.clsDeportes
                                                                       {
                                                                           lgCodigo = q.depoCodigo,
                                                                           stNombre = q.depoNombre
                                                                       }).ToList();
                    return lstclsDeportes;
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


        public void CargarControlDeportes(ref DropDownList ddlControl, List<Models.clsDeportes> dsConsulta, String stValor, String stTexto, String stValorEmcabezado, String stTextoEmcabezado)
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
