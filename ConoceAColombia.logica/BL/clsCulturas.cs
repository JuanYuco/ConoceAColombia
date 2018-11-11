using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace ConoceAColombia.logica.BL
{
    public class clsCulturas
    {
        public string addCulturas(Models.clsCulturas ob)
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obbdConoceAColombiaEntities =
                    new Entidades.bdConoceAColombiaEntities())
                {
                    Entidades.tbCulturas obtbCulturas = new Entidades.tbCulturas
                    {
                        cultCodigo = ob.lgCodigo,
                        cultNombre = ob.stNombre,
                        cultDescripcion = ob.stDescripcion,
                        cultLatitud = ob.stLongitud,
                        cultLongitud = ob.stLongitud,
                        cultDepartamento = ob.obclsDepartamentos.inCodigo
                    };
                    obbdConoceAColombiaEntities.tbCulturas.Add(obtbCulturas);
                    obbdConoceAColombiaEntities.SaveChanges();

                    return "Se realizo proceso con exito";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public string updateCulturas(Models.clsCulturas ob)
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obbdConoceAColombiaEntities =
                    new Entidades.bdConoceAColombiaEntities())
                {
                    Entidades.tbCulturas obtbCultura = (from q in obbdConoceAColombiaEntities.tbCulturas
                                                                   where q.cultCodigo == ob.lgCodigo
                                                                   select q).FirstOrDefault();
                    obtbCultura.cultNombre = ob.stNombre;
                    obtbCultura.cultDescripcion = ob.stDescripcion;
                    obtbCultura.cultLatitud = ob.stLatitud;
                    obtbCultura.cultLongitud = ob.stLongitud;
                    obtbCultura.cultDepartamento = ob.obclsDepartamentos.inCodigo;
                    obbdConoceAColombiaEntities.SaveChanges();

                    return "Se realizo proceso con exito";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public string deleteCulturas(Models.clsCulturas ob)
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obbdConoceAColombiaEntities =
                    new Entidades.bdConoceAColombiaEntities())
                {
                    Entidades.tbCulturas obtbCulturas = (from q in obbdConoceAColombiaEntities.tbCulturas
                                                                   where q.cultCodigo == ob.lgCodigo
                                                                   select q).FirstOrDefault();
                    obbdConoceAColombiaEntities.tbCulturas.Remove(obtbCulturas);
                    obbdConoceAColombiaEntities.SaveChanges();

                    return "Se realizo proceso con exito";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Models.clsCulturas> getCulturas()
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obbdConoceAColombiaEntities =
                    new Entidades.bdConoceAColombiaEntities())
                {
                    List<Models.clsCulturas> lstclsCulturas
                        = (from q in obbdConoceAColombiaEntities.tbCulturas
                           join tbDp in obbdConoceAColombiaEntities.tbDepartamento on q.cultDepartamento equals tbDp.depaCodigo
                           select new Models.clsCulturas
                           {
                               lgCodigo = q.cultCodigo,
                               stNombre = q.cultNombre,
                               stDescripcion = q.cultDescripcion,
                               stLatitud = q.cultLatitud,
                               stLongitud = q.cultLongitud,
                               obclsDepartamentos = new Models.clsDepartamentos
                               {
                                   inCodigo = q.cultDepartamento,
                                   stNombre = tbDp.depaNombre
                               }
                           }).ToList();

                    return lstclsCulturas;
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