using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace ConoceAColombia.logica.BL
{
    public class clsDeportista
    {
        public List<Models.clsDeportista> getDeportista()
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obDatos = new Entidades.bdConoceAColombiaEntities())
                {
                    List<Models.clsDeportista> lstclsDeportista = (from q in obDatos.tbDeportista
                                                         join tbTd in obDatos.tbTipoDeportista on q.depoTipo equals tbTd.tideCodigo
                                                         join tbDe in obDatos.tbDepartamento on q.depoDepartamento equals tbDe.depaCodigo
                                                         select new Models.clsDeportista
                                                         {
                                                             lgCodigo = q.depoCodigo,
                                                             stNombre = q.depoNombre,
                                                             stDescripcion = q.depoDescripcion,
                                                             stFechaNacimiento = q.depoFechaNacimiento.ToString(),
                                                             stCiudad = q.depoCiudad,
                                                             stLatitud = q.depoLatitud,
                                                             stLongitud = q.depoLongitud,
                                                             obclsTipoDeportista = new Models.clsTipoDeportista
                                                             {
                                                                 lgCodigo = q.depoTipo,
                                                                 stDescripcion = tbTd.tideDescripcion
                                                             },
                                                             obclsDepartamentos = new Models.clsDepartamentos
                                                             {
                                                                 inCodigo = q.depoDepartamento,
                                                                 stNombre = tbDe.depaNombre
                                                             }
                                                             
                                                             
                                                         }).ToList();
                    return lstclsDeportista;

                }
            }
            catch (Exception ew)
            {
                throw ew;
            }
        }

        public string InsertDeportista(Models.clsDeportista obclsDeportista)
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obDatos = new Entidades.bdConoceAColombiaEntities())
                {
                    obDatos.tbDeportista.Add(new Entidades.tbDeportista
                    {
                        depoCodigo = obclsDeportista.lgCodigo,
                        depoNombre = obclsDeportista.stNombre,
                        depoDescripcion = obclsDeportista.stDescripcion,
                        depoFechaNacimiento =Convert.ToDateTime(obclsDeportista.stFechaNacimiento),
                        depoCiudad = obclsDeportista.stCiudad,
                        depoLatitud = obclsDeportista.stLatitud,
                        depoLongitud = obclsDeportista.stLongitud,
                        depoDepartamento = obclsDeportista.obclsDepartamentos.inCodigo,
                        depoTipo = obclsDeportista.obclsTipoDeportista.lgCodigo
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


        public string updateDeportista(Models.clsDeportista ob)
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obbdConoceAColombiaEntities =
                    new Entidades.bdConoceAColombiaEntities())
                {
                    Entidades.tbDeportista obtbDeportista = (from q in obbdConoceAColombiaEntities.tbDeportista
                                                   where q.depoCodigo == ob.lgCodigo
                                                   select q).FirstOrDefault();
                    obtbDeportista.depoNombre = ob.stNombre;
                    obtbDeportista.depoDescripcion = ob.stDescripcion;
                    obtbDeportista.depoFechaNacimiento = Convert.ToDateTime(ob.stFechaNacimiento);
                    obtbDeportista.depoCiudad = ob.stCiudad;
                    obtbDeportista.depoLatitud = ob.stLatitud;
                    obtbDeportista.depoLongitud = ob.stLongitud;
                    obtbDeportista.depoDepartamento = ob.obclsDepartamentos.inCodigo;
                    obtbDeportista.depoTipo = ob.obclsTipoDeportista.lgCodigo;
                    obbdConoceAColombiaEntities.SaveChanges();

                    return "Se realizo proceso con exito";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public string deleteDeportista(Models.clsDeportista ob)
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obbdConoceAColombiaEntities =
                    new Entidades.bdConoceAColombiaEntities())
                {
                    Entidades.tbDeportista obtbDeportista = (from q in obbdConoceAColombiaEntities.tbDeportista
                                                   where q.depoCodigo == ob.lgCodigo
                                                   select q).FirstOrDefault();
                    obbdConoceAColombiaEntities.tbDeportista.Remove(obtbDeportista);
                    obbdConoceAColombiaEntities.SaveChanges();

                    return "Se realizo proceso con exito";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Models.clsTipoDeportista> getTipoDeportista()
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obDatos = new Entidades.bdConoceAColombiaEntities())
                {
                    List<Models.clsTipoDeportista> lstclsTipoDeportista = (from q in obDatos.tbTipoDeportista
                                                                 select new Models.clsTipoDeportista
                                                                 {
                                                                     lgCodigo = q.tideCodigo,
                                                                     stDescripcion = q.tideDescripcion
                                                                 }).ToList();
                    return lstclsTipoDeportista;

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


        public void CargarControlTipoDeportista(ref DropDownList ddlControl, List<Models.clsTipoDeportista> dsConsulta, String stValor, String stTexto, String stValorEmcabezado, String stTextoEmcabezado)
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
