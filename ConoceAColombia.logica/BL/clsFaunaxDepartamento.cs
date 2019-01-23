using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace ConoceAColombia.logica.BL
{
    public class clsFaunaxDepartamento
    {

        public List<Models.clsFaunaxDepartamento> getFaunaxDepartamento()
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obDatos = new Entidades.bdConoceAColombiaEntities())
                {
                    List<Models.clsFaunaxDepartamento> lstclsFaunaxDepartamento = (from q in obDatos.tbFaunaxDepartamento
                                                         join tbFa in obDatos.tbFauna on q.fxdFauna equals tbFa.faunCodigo
                                                         join tbDe in obDatos.tbDepartamento on q.fxdDepartamento equals tbDe.depaCodigo
                                                         select new Models.clsFaunaxDepartamento
                                                         {
                                                             lgCodigo = q.fxdCodigo,
                                                             stLatitud = q.fxdLatitud,
                                                             stLongitud = q.fxdLongitud,
                                                             obclsFauna = new Models.clsFauna
                                                             {
                                                                 lgCodigo = q.fxdFauna,
                                                                 stNombre = tbFa.faunNombre
                                                             },
                                                             obclsDepartamentos = new Models.clsDepartamentos
                                                             {
                                                                 inCodigo = q.fxdDepartamento,
                                                                 stNombre = tbDe.depaNombre
                                                             }
                                                            
                                                         }).ToList();
                    return lstclsFaunaxDepartamento;

                }
            }
            catch (Exception ew)
            {
                throw ew;
            }
        }


        public string InsertFaunaxDepartamento(Models.clsFaunaxDepartamento obclsFaunaxDepartamento)
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obDatos = new Entidades.bdConoceAColombiaEntities())
                {
                    obDatos.tbFaunaxDepartamento.Add(new Entidades.tbFaunaxDepartamento
                    {
                        fxdCodigo = obclsFaunaxDepartamento.lgCodigo,
                        fxdLatitud = obclsFaunaxDepartamento.stLatitud,
                        fxdLongitud = obclsFaunaxDepartamento.stLongitud,
                        fxdFauna = obclsFaunaxDepartamento.obclsFauna.lgCodigo,
                        fxdDepartamento = obclsFaunaxDepartamento.obclsDepartamentos.inCodigo
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



        public string updateFaunaxDepartamento(Models.clsFaunaxDepartamento ob)
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obbdConoceAColombiaEntities =
                    new Entidades.bdConoceAColombiaEntities())
                {
                    Entidades.tbFaunaxDepartamento obtbFaunaxDepartamento = (from q in obbdConoceAColombiaEntities.tbFaunaxDepartamento
                                                   where q.fxdCodigo == ob.lgCodigo
                                                   select q).FirstOrDefault();
                    
                    obtbFaunaxDepartamento.fxdLatitud = ob.stLatitud;
                    obtbFaunaxDepartamento.fxdLongitud = ob.stLongitud;
                    obtbFaunaxDepartamento.fxdFauna = ob.obclsFauna.lgCodigo;
                    obtbFaunaxDepartamento.fxdDepartamento = ob.obclsDepartamentos.inCodigo;
                    obbdConoceAColombiaEntities.SaveChanges();

                    return "Se realizo proceso con exito";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public string deleteFaunaxDepartamento(Models.clsFaunaxDepartamento ob)
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obbdConoceAColombiaEntities =
                    new Entidades.bdConoceAColombiaEntities())
                {
                    Entidades.tbFaunaxDepartamento obtbFaunaxDepartamento = (from q in obbdConoceAColombiaEntities.tbFaunaxDepartamento
                                                   where q.fxdCodigo == ob.lgCodigo
                                                   select q).FirstOrDefault();
                    obbdConoceAColombiaEntities.tbFaunaxDepartamento.Remove(obtbFaunaxDepartamento);
                    obbdConoceAColombiaEntities.SaveChanges();

                    return "Se realizo proceso con exito";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<Models.clsFauna> getFauna()
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obDatos = new Entidades.bdConoceAColombiaEntities())
                {
                    List<Models.clsFauna> lstclsFauna = (from q in obDatos.tbFauna
                                                         join tbTF in obDatos.tbTipoFauna on q.faunTipo equals tbTF.tifaCodigo
                                                         select new Models.clsFauna
                                                         {
                                                             lgCodigo = q.faunCodigo,
                                                             stNombre = q.faunNombre,
                                                             stDescripcion = q.faunDescripcion,
                                                             obclsTipoFauna = new Models.clsTipoFauna
                                                             {
                                                                 lgCodigo = q.faunTipo,
                                                                 stDescripcion = tbTF.tifaDescripcion
                                                             }
                                                         }).ToList();
                    return lstclsFauna;

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
            catch(Exception ew)
            {
                throw ew;
            }
        }


        public void CargarControlFauna(ref DropDownList ddlControl, List<Models.clsFauna> dsConsulta, String stValor, String stTexto, String stValorEmcabezado, String stTextoEmcabezado)
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





        public List<Models.clsFaunaxDepartamento> getTodoFauna()
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obDatos = new Entidades.bdConoceAColombiaEntities())
                {
                    List<Models.clsFaunaxDepartamento> lstclsTodoFauna = (from q in obDatos.tbFaunaxDepartamento
                                                                                   join tbFa in obDatos.tbFauna on q.fxdFauna equals tbFa.faunCodigo
                                                                                   join tbDe in obDatos.tbDepartamento on q.fxdDepartamento equals tbDe.depaCodigo
                                                                                   join tbTF in obDatos.tbTipoFauna on tbFa.faunTipo equals tbTF.tifaCodigo
                                                                                   select new Models.clsFaunaxDepartamento
                                                                                   {
                                                                                       lgCodigo = q.fxdCodigo,
                                                                                       
                                                                                       stLatitud = q.fxdLatitud,
                                                                                       stLongitud = q.fxdLongitud,
                                                                                       obclsFauna = new Models.clsFauna
                                                                                       {
                                                                                           lgCodigo = q.fxdFauna,
                                                                                           stNombre = tbFa.faunNombre,
                                                                                           obclsTipoFauna = new Models.clsTipoFauna
                                                                                           {
                                                                                               lgCodigo = tbFa.faunTipo,
                                                                                               stDescripcion = tbTF.tifaDescripcion
                                                                                           }
                                                                                           
                                                                                       },
                                                                                       obclsDepartamentos = new Models.clsDepartamentos
                                                                                       {
                                                                                           inCodigo = q.fxdDepartamento,
                                                                                           stNombre = tbDe.depaNombre
                                                                                       }

                                                                                   }).ToList();
                    return lstclsTodoFauna;

                }
            }
            catch (Exception ew)
            {
                throw ew;
            }
        }


    }
}
