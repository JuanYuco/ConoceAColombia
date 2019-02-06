using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace ConoceAColombia.logica.BL
{
    public class clsFauna
    {
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
                                                                     stImagen = q.faunImagen,
                                                                     obclsTipoFauna = new Models.clsTipoFauna
                                                                     {
                                                                        lgCodigo =  q.faunTipo,
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

        public string InsertFauna(Models.clsFauna obclsFauna)
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obDatos = new Entidades.bdConoceAColombiaEntities())
                {
                    obDatos.tbFauna.Add(new Entidades.tbFauna
                    {
                        faunCodigo = obclsFauna.lgCodigo,
                        faunNombre = obclsFauna.stNombre,
                        faunDescripcion = obclsFauna.stDescripcion,
                        faunTipo = obclsFauna.obclsTipoFauna.lgCodigo,
                        faunImagen = obclsFauna.stImagen
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


        public string updateFauna(Models.clsFauna ob)
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obbdConoceAColombiaEntities =
                    new Entidades.bdConoceAColombiaEntities())
                {
                    Entidades.tbFauna obtbFauna = (from q in obbdConoceAColombiaEntities.tbFauna
                                                           where q.faunCodigo == ob.lgCodigo
                                                           select q).FirstOrDefault();
                    obtbFauna.faunNombre = ob.stNombre;
                    obtbFauna.faunDescripcion = ob.stDescripcion;
                    obtbFauna.faunImagen = ob.stImagen;
                    obtbFauna.faunTipo = ob.obclsTipoFauna.lgCodigo;
                    obbdConoceAColombiaEntities.SaveChanges();

                    return "Se realizo proceso con exito";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public string deleteFauna(Models.clsFauna ob)
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obbdConoceAColombiaEntities =
                    new Entidades.bdConoceAColombiaEntities())
                {
                    Entidades.tbFauna obtbFauna = (from q in obbdConoceAColombiaEntities.tbFauna
                                                           where q.faunCodigo == ob.lgCodigo
                                                           select q).FirstOrDefault();
                    obbdConoceAColombiaEntities.tbFauna.Remove(obtbFauna);
                    obbdConoceAColombiaEntities.SaveChanges();

                    return "Se realizo proceso con exito";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Models.clsTipoFauna> getTipoFauna()
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obDatos = new Entidades.bdConoceAColombiaEntities())
                {
                    List<Models.clsTipoFauna> lstclsTipoFauna = (from q in obDatos.tbTipoFauna
                                                                 select new Models.clsTipoFauna
                                                                 {
                                                                     lgCodigo = q.tifaCodigo,
                                                                     stDescripcion = q.tifaDescripcion
                                                                 }).ToList();
                    return lstclsTipoFauna;

                }
            }
            catch (Exception ew)
            {
                throw ew;
            }
        }


        public void CargarControlTipoFauna(ref DropDownList ddlControl, List<Models.clsTipoFauna> dsConsulta, String stValor, String stTexto, String stValorEmcabezado, String stTextoEmcabezado)
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
