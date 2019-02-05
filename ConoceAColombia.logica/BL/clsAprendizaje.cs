using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace ConoceAColombia.logica.BL
{
    public class clsAprendizaje
    {
        public List<Models.clsAprendizaje> getAprendizaje()
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obDatos = new Entidades.bdConoceAColombiaEntities())
                {
                    List<Models.clsAprendizaje> lstclsAprendizaje = (from q in obDatos.tbPersonajeAprendizaje
                                                                   join tbTa in obDatos.tbTipoPersonajeAprendizaje on q.apreTipo equals tbTa.tiapCodigo
                                                                   join tbDe in obDatos.tbDepartamento on q.apreDepartamento equals tbDe.depaCodigo
                                                                   select new Models.clsAprendizaje
                                                                   {
                                                                       lgCodigo = q.apreCodigo,
                                                                       stNombre = q.apreNombre,
                                                                       stDescripcion = q.apreDescripcion,
                                                                       stFechaNacimiento = q.apreFechaNacimiento.ToString(),
                                                                       stCiudad = q.apreCiudad,
                                                                       stImagen = q.apreImagen,
                                                                       stLatitud = q.apreLatitud,
                                                                       stLongitud = q.apreLongitud,
                                                                       obclsTipoAprendizaje = new Models.clsTipoAprendizaje
                                                                       {
                                                                           lgCodigo = q.apreTipo,
                                                                           stDescripcion = tbTa.tiapDescripcion
                                                                       },
                                                                       obclsDepartamentos = new Models.clsDepartamentos
                                                                       {
                                                                           inCodigo = q.apreDepartamento,
                                                                           stNombre = tbDe.depaNombre
                                                                       }


                                                                   }).ToList();
                    return lstclsAprendizaje;

                }
            }
            catch (Exception ew)
            {
                throw ew;
            }
        }

        public string InsertAprendizaje(Models.clsAprendizaje obclsAprendizaje)
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obDatos = new Entidades.bdConoceAColombiaEntities())
                {
                    obDatos.tbPersonajeAprendizaje.Add(new Entidades.tbPersonajeAprendizaje
                    {
                        apreCodigo = obclsAprendizaje.lgCodigo,
                        apreNombre = obclsAprendizaje.stNombre,
                        apreDescripcion = obclsAprendizaje.stDescripcion,
                        apreFechaNacimiento = Convert.ToDateTime(obclsAprendizaje.stFechaNacimiento),
                        apreCiudad = obclsAprendizaje.stCiudad,
                        apreImagen = obclsAprendizaje.stImagen,
                        apreLatitud = obclsAprendizaje.stLatitud,
                        apreLongitud = obclsAprendizaje.stLongitud,
                        apreDepartamento = obclsAprendizaje.obclsDepartamentos.inCodigo,
                        apreTipo = obclsAprendizaje.obclsTipoAprendizaje.lgCodigo
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


        public string updateAprendizaje(Models.clsAprendizaje ob)
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obbdConoceAColombiaEntities =
                    new Entidades.bdConoceAColombiaEntities())
                {
                    Entidades.tbPersonajeAprendizaje obtbAprendizaje = (from q in obbdConoceAColombiaEntities.tbPersonajeAprendizaje
                                                             where q.apreCodigo == ob.lgCodigo
                                                             select q).FirstOrDefault();
                    obtbAprendizaje.apreNombre = ob.stNombre;
                    obtbAprendizaje.apreDescripcion = ob.stDescripcion;
                    obtbAprendizaje.apreFechaNacimiento = Convert.ToDateTime(ob.stFechaNacimiento);
                    obtbAprendizaje.apreCiudad = ob.stCiudad;
                    obtbAprendizaje.apreImagen = ob.stImagen;
                    obtbAprendizaje.apreLatitud = ob.stLatitud;
                    obtbAprendizaje.apreLongitud = ob.stLongitud;
                    obtbAprendizaje.apreDepartamento = ob.obclsDepartamentos.inCodigo;
                    obtbAprendizaje.apreTipo = ob.obclsTipoAprendizaje.lgCodigo;
                    obbdConoceAColombiaEntities.SaveChanges();

                    return "Se realizo proceso con exito";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public string deleteAprendizaje(Models.clsAprendizaje ob)
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obbdConoceAColombiaEntities =
                    new Entidades.bdConoceAColombiaEntities())
                {
                    Entidades.tbPersonajeAprendizaje obtbAprendizaje = (from q in obbdConoceAColombiaEntities.tbPersonajeAprendizaje
                                                             where q.apreCodigo == ob.lgCodigo
                                                             select q).FirstOrDefault();
                    obbdConoceAColombiaEntities.tbPersonajeAprendizaje.Remove(obtbAprendizaje);
                    obbdConoceAColombiaEntities.SaveChanges();

                    return "Se realizo proceso con exito";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Models.clsTipoAprendizaje> getTipoAprendizaje()
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obDatos = new Entidades.bdConoceAColombiaEntities())
                {
                    List<Models.clsTipoAprendizaje> lstclsTipoAprendizaje = (from q in obDatos.tbTipoPersonajeAprendizaje
                                                                           select new Models.clsTipoAprendizaje
                                                                           {
                                                                               lgCodigo = q.tiapCodigo,
                                                                               stDescripcion = q.tiapDescripcion
                                                                           }).ToList();
                    return lstclsTipoAprendizaje;

                }
            }
            catch (Exception ew)
            {
                throw ew;
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


        public void CargarControlTipoAprendizaje(ref DropDownList ddlControl, List<Models.clsTipoAprendizaje> dsConsulta, String stValor, String stTexto, String stValorEmcabezado, String stTextoEmcabezado)
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
