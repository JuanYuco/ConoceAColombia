using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace ConoceAColombia.logica.BL
{
    public class clsFloraxDepartamento
    {
        public List<Models.clsFloraxDepartamento> getFloraxDepartamento()
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obDatos = new Entidades.bdConoceAColombiaEntities())
                {
                    List<Models.clsFloraxDepartamento> lstclsFloraxDepartamento = (from q in obDatos.tbFloraxDepartamento
                                                                                   join tbFl in obDatos.tbFlora on q.foxdFlora equals tbFl.florCodigo
                                                                                   join tbDe in obDatos.tbDepartamento on q.foxdDepartamento equals tbDe.depaCodigo
                                                                                   select new Models.clsFloraxDepartamento
                                                                                   {
                                                                                       lgCodigo = q.foxdCodigo,
                                                                                       stLatitud = q.foxdLatitud,
                                                                                       stLongitud = q.foxdLongitud,
                                                                                       obclsFlora = new Models.clsFlora
                                                                                       {
                                                                                           lgCodigo = q.foxdFlora,
                                                                                           stNombre = tbFl.florNomComun
                                                                                       },
                                                                                       obclsDepartamentos = new Models.clsDepartamentos
                                                                                       {
                                                                                           inCodigo = q.foxdDepartamento,
                                                                                           stNombre = tbDe.depaNombre
                                                                                       }

                                                                                   }).ToList();
                    return lstclsFloraxDepartamento;

                }
            }
            catch (Exception ew)
            {
                throw ew;
            }
        }


        public string InsertFloraxDepartamento(Models.clsFloraxDepartamento obclsFloraxDepartamento)
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obDatos = new Entidades.bdConoceAColombiaEntities())
                {
                    obDatos.tbFloraxDepartamento.Add(new Entidades.tbFloraxDepartamento
                    {
                        foxdCodigo = obclsFloraxDepartamento.lgCodigo,
                        foxdLatitud = obclsFloraxDepartamento.stLatitud,
                        foxdLongitud = obclsFloraxDepartamento.stLongitud,
                        foxdFlora = obclsFloraxDepartamento.obclsFlora.lgCodigo,
                        foxdDepartamento = obclsFloraxDepartamento.obclsDepartamentos.inCodigo
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



        public string updateFloraxDepartamento(Models.clsFloraxDepartamento ob)
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obbdConoceAColombiaEntities =
                    new Entidades.bdConoceAColombiaEntities())
                {
                    Entidades.tbFloraxDepartamento obtbFloraxDepartamento = (from q in obbdConoceAColombiaEntities.tbFloraxDepartamento
                                                                             where q.foxdCodigo == ob.lgCodigo
                                                                             select q).FirstOrDefault();

                    obtbFloraxDepartamento.foxdLatitud = ob.stLatitud;
                    obtbFloraxDepartamento.foxdLongitud = ob.stLongitud;
                    obtbFloraxDepartamento.foxdFlora = ob.obclsFlora.lgCodigo;
                    obtbFloraxDepartamento.foxdDepartamento = ob.obclsDepartamentos.inCodigo;
                    obbdConoceAColombiaEntities.SaveChanges();

                    return "Se realizo proceso con exito";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public string deleteFloraxDepartamento(Models.clsFloraxDepartamento ob)
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obbdConoceAColombiaEntities =
                    new Entidades.bdConoceAColombiaEntities())
                {
                    Entidades.tbFloraxDepartamento obtbFloraxDepartamento = (from q in obbdConoceAColombiaEntities.tbFloraxDepartamento
                                                                             where q.foxdCodigo == ob.lgCodigo
                                                                             select q).FirstOrDefault();
                    obbdConoceAColombiaEntities.tbFloraxDepartamento.Remove(obtbFloraxDepartamento);
                    obbdConoceAColombiaEntities.SaveChanges();

                    return "Se realizo proceso con exito";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<Models.clsFlora> getFlora()
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obDatos = new Entidades.bdConoceAColombiaEntities())
                {
                    List<Models.clsFlora> lstclsFlora = (from q in obDatos.tbFlora
                                                         join tbTF in obDatos.tbTipoFlora on q.florTipo equals tbTF.tiflCodigo
                                                         select new Models.clsFlora
                                                         {
                                                             lgCodigo = q.florCodigo,
                                                             stNombre = q.florNomComun,
                                                             stDescripcion = q.florDescripcion,
                                                             obclsTipoFlora = new Models.clsTipoFlora
                                                             {
                                                                 lgCodigo = q.florTipo,
                                                                 stDescripcion = tbTF.tiflDescripcion
                                                             }
                                                         }).ToList();
                    return lstclsFlora;

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


        public void CargarControlFlora(ref DropDownList ddlControl, List<Models.clsFlora> dsConsulta, String stValor, String stTexto, String stValorEmcabezado, String stTextoEmcabezado)
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
