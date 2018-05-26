using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace ConoceAColombia.logica.BL
{
    public class clsEquipo
    {
        ISessionFactory session = null;

        public clsEquipo()
        {
            clsConexion obclsConexion = new clsConexion();
            session = obclsConexion.getConexionn();
        }

        public string addEquipo(Models.clsEquipo obclsEquipo)
        {
            try
            {
                using (var conn = session.OpenSession())
                {
                    using (var transaction = conn.BeginTransaction())
                    {
                        conn.SaveOrUpdate(obclsEquipo);
                        transaction.Commit();
                        return "Se realizo con exito";
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string deleteEquipo(Models.clsEquipo obclsEquipo)
        {
            try
            {
                using (var conn = session.OpenSession())
                {
                    using (var transaction = conn.BeginTransaction())
                    {
                        conn.Delete(obclsEquipo);
                        transaction.Commit();
                        return "Se realizo con exito";
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Models.clsEquipo> getEquipo()
        {
            try
            {
                using (var conn = session.OpenSession())
                {
                    return (from q in conn.Query<Models.clsEquipo>()
                            join tbD in conn.Query<Models.clsDeportes>() on q.obclsDeportes.stNombre equals tbD.stNombre
                            join tbDp in conn.Query<Models.clsDepartamentos>() on q.obclsDepartamentos.stNombre equals tbDp.stNombre
                            select new Models.clsEquipo
                            {
                                lgCodigo = q.lgCodigo,
                                stNombre = q.stNombre,
                                stDescripcion = q.stDescripcion,
                                stPresidente = q.stPresidente,
                                stFundacion = q.stFundacion,
                                stCiudad = q.stCiudad,
                                stLatitud = q.stLatitud,
                                stLongitud =q.stLongitud,
                                obclsDeportes = new Models.clsDeportes
                                {
                                    lgCodigo= tbD.lgCodigo,
                                    stNombre = q.obclsDeportes.stNombre
                                },
                                obclsDepartamentos = new Models.clsDepartamentos
                                {
                                    inCodigo  = tbDp.inCodigo,
                                    stNombre = q.obclsDepartamentos.stNombre
                                }
                                
                                
                            }).ToList();
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public List<Models.clsDeportes> getDeportes()
        {
            try
            {
                using (var conn = session.OpenSession())
                {
                    return (from q in conn.Query<Models.clsDeportes>()
                            select new Models.clsDeportes
                            {
                                lgCodigo = q.lgCodigo,
                                stNombre = q.stNombre
                            }).ToList();
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
                using (var conn = session.OpenSession())
                {
                    return (from q in conn.Query<Models.clsDepartamentos>()
                            select new Models.clsDepartamentos
                            {
                                inCodigo = q.inCodigo,
                                stNombre = q.stNombre,
                                stCapital = q.stCapital,
                                stDemografia = q.stDemografia,
                                stFundacion = q.stFundacion,
                                stGentilicio = q.stGentilicio,
                                stGobernador = q.stGobernador,
                                stLatitud = q.stLatitud,
                                stLongitud = q.stLongitud,
                                stMunicipios = q.stMunicipios,
                                stPoblacion = q.stPoblacion,
                                stSuperficie = q.stSuperficie
                            }).ToList();
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }













        public void CargarControlDepartamentos(ref DropDownList ddlControl, List<Models.clsDepartamentos> consulta, String stValor, String stTexto, String stValorEmcabezado, String stTextoEmcabezado)
        {
            try
            {
                ddlControl.DataSource = consulta;
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

        public void CargarControlDeportes(ref DropDownList ddlControl, List<Models.clsDeportes> consulta, String stValor, String stTexto, String stValorEmcabezado, String stTextoEmcabezado)
        {
            try
            {
                ddlControl.DataSource = consulta;
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
