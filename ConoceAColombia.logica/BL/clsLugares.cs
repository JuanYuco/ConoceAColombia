using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace ConoceAColombia.logica.BL
{
    public class clsLugares
    {
        public string insertLugares(Models.clsLugares ob)
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obbdConoceAColombiaEntities =
                    new Entidades.bdConoceAColombiaEntities())
                {
                    Entidades.tbLugares obtbLugares = new Entidades.tbLugares
                    {
                        lugaCodigo = ob.lgCodigo,
                        lugaNombre = ob.stNombre,
                        lugaDescripcion = ob.stDescripcion,
                        lugaCiudad = ob.stCiudad,
                        lugaFundacion = ob.stFundacion,
                        lugaDireccion = ob.stDireccion,
                        lugaImagen = ob.stImagen,
                        lugaLatitud = ob.stLatitud,
                        lugaLongitud = ob.stLongitud,
                        lugaDepartamento = ob.obclsDepartamento.inCodigo,
                        lugaTipo = ob.obclsTipoLugar.lgCodigo
                    };
                    obbdConoceAColombiaEntities.tbLugares.Add(obtbLugares);
                    obbdConoceAColombiaEntities.SaveChanges();

                    return "Se realizo proceso con exito";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public string updateLugares(Models.clsLugares ob)
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obbdConoceAColombiaEntities =
                    new Entidades.bdConoceAColombiaEntities())
                {
                    Entidades.tbLugares obtbLugares = (from q in obbdConoceAColombiaEntities.tbLugares
                                                        where q.lugaCodigo == ob.lgCodigo
                                                        select q).FirstOrDefault();
                    obtbLugares.lugaNombre = ob.stNombre;
                    obtbLugares.lugaDescripcion = ob.stDescripcion;
                    obtbLugares.lugaCiudad = ob.stCiudad;
                    obtbLugares.lugaDireccion = ob.stDireccion;
                    obtbLugares.lugaFundacion = ob.stFundacion;
                    obtbLugares.lugaImagen = ob.stImagen;
                    obtbLugares.lugaLatitud = ob.stLatitud;
                    obtbLugares.lugaLongitud = ob.stLongitud;
                    obtbLugares.lugaDepartamento = ob.obclsDepartamento.inCodigo;
                    obtbLugares.lugaTipo = ob.obclsTipoLugar.lgCodigo;
                    obbdConoceAColombiaEntities.SaveChanges();

                    return "Se realizo proceso con exito";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public string deleteLugares(Models.clsLugares ob)
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obbdConoceAColombiaEntities =
                    new Entidades.bdConoceAColombiaEntities())
                {
                    Entidades.tbLugares obtbLugares = (from q in obbdConoceAColombiaEntities.tbLugares
                                                         where q.lugaCodigo == ob.lgCodigo
                                                         select q).FirstOrDefault();
                    obbdConoceAColombiaEntities.tbLugares.Remove(obtbLugares);
                    obbdConoceAColombiaEntities.SaveChanges();

                    return "Se realizo proceso con exito";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Models.clsLugares> getLugares()
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obbdConoceAColombiaEntities =
                    new Entidades.bdConoceAColombiaEntities())
                {
                    List<Models.clsLugares> lstclsLugares
                        = (from q in obbdConoceAColombiaEntities.tbLugares
                           join tbTl in obbdConoceAColombiaEntities.tbTipoLugares on q.lugaTipo equals tbTl.tiluCodigo
                           join tbDp in obbdConoceAColombiaEntities.tbDepartamento on q.lugaDepartamento equals tbDp.depaCodigo
                           select new Models.clsLugares
                           {
                               lgCodigo = q.lugaCodigo,
                               stNombre = q.lugaNombre,
                               stDescripcion = q.lugaDescripcion,
                               stCiudad = q.lugaCiudad,
                               stFundacion = q.lugaFundacion,
                               stDireccion = q.lugaDireccion,
                               stImagen = q.lugaImagen,
                               stLatitud = q.lugaLatitud,
                               stLongitud = q.lugaLongitud,
                               obclsTipoLugar = new Models.clsTipoLugares
                               {
                                   lgCodigo = q.lugaTipo,
                                   stDescripcion = tbTl.tiluDescripcion
                               },
                               obclsDepartamento = new Models.clsDepartamentos
                               {
                                   inCodigo = q.lugaDepartamento,
                                   stNombre = tbDp.depaNombre
                               }
                           }).ToList();

                    return lstclsLugares;
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


        public List<Models.clsTipoLugares> getTipoLugares()
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obDatos = new Entidades.bdConoceAColombiaEntities())
                {
                    List<Models.clsTipoLugares> lstclsTipoLugares = (from q in obDatos.tbTipoLugares
                                                                       select new Models.clsTipoLugares
                                                                       {
                                                                           lgCodigo = q.tiluCodigo,
                                                                           stDescripcion = q.tiluDescripcion
                                                                       }).ToList();
                    return lstclsTipoLugares;
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


        public void CargarControlTipoLugares(ref DropDownList ddlControl, List<Models.clsTipoLugares> dsConsulta, String stValor, String stTexto, String stValorEmcabezado, String stTextoEmcabezado)
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
