using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace ConoceAColombia.logica.BL
{
    public class clsPolitico
    {
        public List<Models.clsPolitico> getPolitico()
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obDatos = new Entidades.bdConoceAColombiaEntities())
                {
                    List<Models.clsPolitico> lstclsPolitico = (from q in obDatos.tbPolitico
                                                                   join tbTp in obDatos.tbTipoPolitico on q.poliTipo equals tbTp.tipoCodigo
                                                                   join tbDe in obDatos.tbDepartamento on q.poliDepartamento equals tbDe.depaCodigo
                                                                   select new Models.clsPolitico
                                                                   {
                                                                       lgCodigo = q.poliCodigo,
                                                                       stNombre = q.poliNombre,
                                                                       stDescripcion = q.poliDescripcion,
                                                                       stFechaNacimiento = q.poliFechaNacimiento.ToString(),
                                                                       stCiudad = q.poliCiudad,
                                                                       stLatitud = q.poliLatitud,
                                                                       stLongitud = q.poliLongitud,
                                                                       stImagen = q.poliImagen,
                                                                       obclsTipoPolitico = new Models.clsTipoPolitico
                                                                       {
                                                                           lgCodigo = q.poliTipo,
                                                                           stDescripcion = tbTp.tipoDescripcion
                                                                       },
                                                                       obclsDepartamentos = new Models.clsDepartamentos
                                                                       {
                                                                           inCodigo = q.poliDepartamento,
                                                                           stNombre = tbDe.depaNombre
                                                                       }
                                                                   }).ToList();
                    return lstclsPolitico;

                }
            }
            catch (Exception ew)
            {
                throw ew;
            }
        }

        public string InsertPolitico(Models.clsPolitico obclsPolitico)
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obDatos = new Entidades.bdConoceAColombiaEntities())
                {
                    obDatos.tbPolitico.Add(new Entidades.tbPolitico
                    {
                        poliCodigo = obclsPolitico.lgCodigo,
                        poliNombre = obclsPolitico.stNombre,
                        poliDescripcion = obclsPolitico.stDescripcion,
                        poliFechaNacimiento = Convert.ToDateTime(obclsPolitico.stFechaNacimiento),
                        poliCiudad = obclsPolitico.stCiudad,
                        poliLatitud = obclsPolitico.stLatitud,
                        poliLongitud = obclsPolitico.stLongitud,
                        poliDepartamento = obclsPolitico.obclsDepartamentos.inCodigo,
                        poliTipo = obclsPolitico.obclsTipoPolitico.lgCodigo,
                        poliImagen = obclsPolitico.stImagen
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


        public string updatePolitico(Models.clsPolitico ob)
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obbdConoceAColombiaEntities =
                    new Entidades.bdConoceAColombiaEntities())
                {
                    Entidades.tbPolitico obtbPolitico = (from q in obbdConoceAColombiaEntities.tbPolitico
                                                             where q.poliCodigo == ob.lgCodigo
                                                             select q).FirstOrDefault();
                    obtbPolitico.poliNombre = ob.stNombre;
                    obtbPolitico.poliDescripcion = ob.stDescripcion;
                    obtbPolitico.poliFechaNacimiento = Convert.ToDateTime(ob.stFechaNacimiento);
                    obtbPolitico.poliCiudad = ob.stCiudad;
                    obtbPolitico.poliLatitud = ob.stLatitud;
                    obtbPolitico.poliLongitud = ob.stLongitud;
                    obtbPolitico.poliDepartamento = ob.obclsDepartamentos.inCodigo;
                    obtbPolitico.poliTipo = ob.obclsTipoPolitico.lgCodigo;
                    obtbPolitico.poliImagen = ob.stImagen;
                    obbdConoceAColombiaEntities.SaveChanges();

                    return "Se realizo proceso con exito";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public string deletePoliticio(Models.clsPolitico ob)
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obbdConoceAColombiaEntities =
                    new Entidades.bdConoceAColombiaEntities())
                {
                    Entidades.tbPolitico obtbPolitico = (from q in obbdConoceAColombiaEntities.tbPolitico
                                                             where q.poliCodigo == ob.lgCodigo
                                                             select q).FirstOrDefault();
                    obbdConoceAColombiaEntities.tbPolitico.Remove(obtbPolitico);
                    obbdConoceAColombiaEntities.SaveChanges();

                    return "Se realizo proceso con exito";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Models.clsTipoPolitico> getTipoPolitico()
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obDatos = new Entidades.bdConoceAColombiaEntities())
                {
                    List<Models.clsTipoPolitico> lstclsTipoPolitico = (from q in obDatos.tbTipoPolitico
                                                                           select new Models.clsTipoPolitico
                                                                           {
                                                                               lgCodigo = q.tipoCodigo,
                                                                               stDescripcion = q.tipoDescripcion
                                                                           }).ToList();
                    return lstclsTipoPolitico;

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


        public void CargarControlTipoPolitico(ref DropDownList ddlControl, List<Models.clsTipoPolitico> dsConsulta, String stValor, String stTexto, String stValorEmcabezado, String stTextoEmcabezado)
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
