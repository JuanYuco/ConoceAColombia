using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace ConoceAColombia.logica.BL
{
    public class clsPreguntasJuego
    {
        public string addPreguntasJuego(Models.clsPreguntasJuego ob)
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obbdConoceAColombiaEntities =
                    new Entidades.bdConoceAColombiaEntities())
                {
                    Entidades.tbPreguntasJuego obtbPreguntasJuego = new Entidades.tbPreguntasJuego
                    {
                        prjuCodigo = ob.lgCodigo,
                        prjuPregunta = ob.stPregunta,
                        prjuRespuestaCorrecta = ob.stRespuestaCorrecta,
                        prjuRespuestaIncorrectaUno = ob.stRespuestaIncorrectaUno,
                        prjuRespuestaIncorrectaDos = ob.stRespuestaIncorrectaDos,
                        prjuRespuestaIncorrectaTres = ob.stRespuestaIncorrectaTres,
                        prjuRespuestaIncorrectaCuatro = ob.stRespuestaIncorrectaCuatro,
                        prjuRespuestaIncorrectaCinco = ob.stRespuestaIncorrectaCinco,
                        prjuTematica = ob.obclsTematicasJuego.lgCodigo,
                        prjuTipoJuego = ob.obclsTipoJuego.lgCodigo,
                        prjuDificultad = ob.obclsDicultadJuego.lgCodigo
                    };
                    obbdConoceAColombiaEntities.tbPreguntasJuego.Add(obtbPreguntasJuego);
                    obbdConoceAColombiaEntities.SaveChanges();

                    return "Se realizo proceso con exito";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public string updatePreguntasJuego(Models.clsPreguntasJuego ob)
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obbdConoceAColombiaEntities =
                    new Entidades.bdConoceAColombiaEntities())
                {
                    Entidades.tbPreguntasJuego obtbPreguntasJuego = (from q in obbdConoceAColombiaEntities.tbPreguntasJuego
                                                         where q.prjuCodigo == ob.lgCodigo
                                                         select q).FirstOrDefault();
                    obtbPreguntasJuego.prjuPregunta = ob.stPregunta;
                    obtbPreguntasJuego.prjuRespuestaCorrecta = ob.stRespuestaCorrecta;
                    obtbPreguntasJuego.prjuRespuestaIncorrectaUno = ob.stRespuestaIncorrectaUno;
                    obtbPreguntasJuego.prjuRespuestaIncorrectaDos = ob.stRespuestaIncorrectaDos;
                    obtbPreguntasJuego.prjuRespuestaIncorrectaTres = ob.stRespuestaIncorrectaTres;
                    obtbPreguntasJuego.prjuRespuestaIncorrectaCuatro = ob.stRespuestaIncorrectaCuatro;
                    obtbPreguntasJuego.prjuRespuestaIncorrectaCinco = ob.stRespuestaIncorrectaCinco;
                    obtbPreguntasJuego.prjuTematica = ob.obclsTematicasJuego.lgCodigo;
                    obtbPreguntasJuego.prjuTipoJuego = ob.obclsTipoJuego.lgCodigo;
                    obtbPreguntasJuego.prjuDificultad = ob.obclsDicultadJuego.lgCodigo;

                    obbdConoceAColombiaEntities.SaveChanges();

                    return "Se realizo proceso con exito";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public string deletePreguntasJuego(Models.clsPreguntasJuego ob)
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obbdConoceAColombiaEntities =
                    new Entidades.bdConoceAColombiaEntities())
                {
                    Entidades.tbPreguntasJuego obtbPreguntasJuego = (from q in obbdConoceAColombiaEntities.tbPreguntasJuego
                                                         where q.prjuCodigo == ob.lgCodigo
                                                         select q).FirstOrDefault();
                    obbdConoceAColombiaEntities.tbPreguntasJuego.Remove(obtbPreguntasJuego);
                    obbdConoceAColombiaEntities.SaveChanges();

                    return "Se realizo proceso con exito";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Models.clsPreguntasJuego> getPreguntasJuego()
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obbdConoceAColombiaEntities =
                    new Entidades.bdConoceAColombiaEntities())
                {
                    List<Models.clsPreguntasJuego> lstclsPreguntasJuego
                        = (from q in obbdConoceAColombiaEntities.tbPreguntasJuego
                           join tbTem in obbdConoceAColombiaEntities.tbTematicaJuego on q.prjuTematica equals tbTem.tejuCodigo
                           join tbTip in obbdConoceAColombiaEntities.tbTipoJuego on q.prjuTipoJuego equals tbTip.tijuCodigo
                           join tbDif in obbdConoceAColombiaEntities.tbDificultadJuego on q.prjuDificultad equals tbDif.dijuCodigo
                           select new Models.clsPreguntasJuego
                           {
                               lgCodigo = q.prjuCodigo,
                               stPregunta = q.prjuPregunta,
                               stRespuestaCorrecta = q.prjuRespuestaCorrecta,
                               stRespuestaIncorrectaUno = q.prjuRespuestaIncorrectaUno,
                               stRespuestaIncorrectaDos = q.prjuRespuestaIncorrectaDos,
                               stRespuestaIncorrectaTres = q.prjuRespuestaIncorrectaTres,
                               stRespuestaIncorrectaCuatro = q.prjuRespuestaIncorrectaCuatro,
                               stRespuestaIncorrectaCinco = q.prjuRespuestaIncorrectaCinco,
                               obclsTematicasJuego = new Models.clsTematicasJuego
                               {
                                   lgCodigo = q.prjuTematica,
                                   stDescripcion = tbTem.tejuDescripcion
                               },
                               obclsTipoJuego = new Models.clsTipoJuego
                               {
                                   lgCodigo = q.prjuTipoJuego,
                                   stDescripcion = tbTip.tijuDescripcion
                               },
                               obclsDicultadJuego = new Models.clsDicultadJuego
                               {
                                   lgCodigo = q.prjuDificultad,
                                   stDescripcion = tbDif.dijuDescripcion
                               }
                              
                           }).ToList();

                    return lstclsPreguntasJuego;
                }

            }
            catch (Exception ex) { throw ex; }
        }


        public List<Models.clsTematicasJuego> getTematica()
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obbdConoceAColombiaEntities =
                    new Entidades.bdConoceAColombiaEntities())
                {
                    List<Models.clsTematicasJuego> lstclsTematicaJuego
                        = (from q in obbdConoceAColombiaEntities.tbTematicaJuego
                           select new Models.clsTematicasJuego
                           {
                               lgCodigo = q.tejuCodigo,
                               stDescripcion = q.tejuDescripcion
                           }).ToList();

                    return lstclsTematicaJuego;
                }

            }
            catch (Exception ex) { throw ex; }
        }

        public void CargarControlTematicasJuego(ref DropDownList ddlControl, List<Models.clsTematicasJuego> dsConsulta, String stValor, String stTexto, String stValorEmcabezado, String stTextoEmcabezado)
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



        public List<Models.clsTipoJuego> getTipoJuego()
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obbdConoceAColombiaEntities =
                    new Entidades.bdConoceAColombiaEntities())
                {
                    List<Models.clsTipoJuego> lstclsTipoJuego
                        = (from q in obbdConoceAColombiaEntities.tbTipoJuego
                           select new Models.clsTipoJuego
                           {
                               lgCodigo = q.tijuCodigo,
                               stDescripcion = q.tijuDescripcion
                           }).ToList();

                    return lstclsTipoJuego;
                }

            }
            catch (Exception ex) { throw ex; }
        }



        public void CargarControlTipoJuego(ref DropDownList ddlControl, List<Models.clsTipoJuego> dsConsulta, String stValor, String stTexto, String stValorEmcabezado, String stTextoEmcabezado)
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


        public List<Models.clsDicultadJuego> getDificultadJuego()
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obbdConoceAColombiaEntities =
                    new Entidades.bdConoceAColombiaEntities())
                {
                    List<Models.clsDicultadJuego> lstclsDificultadJuego
                        = (from q in obbdConoceAColombiaEntities.tbDificultadJuego
                           select new Models.clsDicultadJuego
                           {
                               lgCodigo = q.dijuCodigo,
                               stDescripcion = q.dijuDescripcion
                           }).ToList();

                    return lstclsDificultadJuego;
                }

            }
            catch (Exception ex) { throw ex; }
        }

        public void CargarControlDificultad(ref DropDownList ddlControl, List<Models.clsDicultadJuego> dsConsulta, String stValor, String stTexto, String stValorEmcabezado, String stTextoEmcabezado)
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