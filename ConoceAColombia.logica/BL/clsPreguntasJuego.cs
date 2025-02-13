﻿using System;
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
                               stSalio = q.prjuSalio,
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





        public Models.clsPreguntasJuego getPreguntaRamdon(List<Models.clsPreguntasJuego> lstPreguntasJuego, List<int>Codigos)
        {
            try
            {

                Models.clsPreguntasJuego obPregunta = new Models.clsPreguntasJuego();
                Random rnd = new Random();
                
                int Contador = 0;
                int valor = 0;
                int valor2 = 0;
                if (lstPreguntasJuego.Count == Codigos.Count)
                {
                    obPregunta = new Models.clsPreguntasJuego
                    {
                        lgCodigo = 1000,
                        stPregunta = "Ya se acabaron las preguntas"

                    };
                }
                else
                {
                    while (valor2 == 0)
                    {
                        int numero = rnd.Next(1, lstPreguntasJuego.Count + 1);
                        Contador = 0; 
                        foreach (Models.clsPreguntasJuego preguntas in lstPreguntasJuego)
                        {
                            valor = 0;
                            Contador++;

                            if (Codigos != null)
                            {
                                foreach (int Codigo in Codigos)
                                {
                                    if (Contador == Codigo)
                                    {
                                        valor = 1;
                                    }
                                }
                            }


                            if (Contador == numero && valor == 0)
                            {
                                obPregunta = new Models.clsPreguntasJuego
                                {
                                    lgCodigo = preguntas.lgCodigo,
                                    stPregunta = preguntas.stPregunta,
                                    stRespuestaCorrecta = preguntas.stRespuestaCorrecta,
                                    stRespuestaIncorrectaUno = preguntas.stRespuestaIncorrectaUno,
                                    stRespuestaIncorrectaDos = preguntas.stRespuestaIncorrectaDos,
                                    stRespuestaIncorrectaTres = preguntas.stRespuestaIncorrectaTres,
                                    stRespuestaIncorrectaCuatro = preguntas.stRespuestaIncorrectaCuatro,
                                    stRespuestaIncorrectaCinco = preguntas.stRespuestaIncorrectaCinco,
                                    obclsTematicasJuego = new Models.clsTematicasJuego
                                    {
                                        stDescripcion = preguntas.obclsTematicasJuego.stDescripcion
                                    },
                                    obclsTipoJuego = new Models.clsTipoJuego
                                    {
                                        stDescripcion = preguntas.obclsTipoJuego.stDescripcion
                                    },
                                    obclsDicultadJuego = new Models.clsDicultadJuego
                                    {
                                        stDescripcion = preguntas.obclsDicultadJuego.stDescripcion
                                    }
                                };

                            }


                        }

                        if (obPregunta.lgCodigo != 0)
                        {
                            valor2 = 1;
                        }
                    }
                }
                return obPregunta;
            }
            catch (Exception ew)
            {
                throw ew;
            }
        }



        public List<Models.clsPreguntasJuego> getPreguntasJuego(string tematica, string dificultad)
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
                           where tbTem.tejuDescripcion == tematica
                           where tbDif.dijuDescripcion == dificultad
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
                               stSalio = q.prjuSalio,
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


        public void updateEstadoPregunta(Models.clsPreguntasJuego ob)
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obbdConoceAColombiaEntities =
                    new Entidades.bdConoceAColombiaEntities())
                {
                    Entidades.tbPreguntasJuego obtbPreguntasJuego = (from q in obbdConoceAColombiaEntities.tbPreguntasJuego
                                                                     where q.prjuCodigo == ob.lgCodigo
                                                                     select q).FirstOrDefault();
                    obtbPreguntasJuego.prjuSalio = ob.stSalio;
                    obbdConoceAColombiaEntities.SaveChanges();


                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void updateVolverEstado()
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obbdConoceAColombiaEntities =
                    new Entidades.bdConoceAColombiaEntities())
                {
                    Entidades.tbPreguntasJuego obtbPreguntasJuego = (from q in obbdConoceAColombiaEntities.tbPreguntasJuego

                                                                     select q).FirstOrDefault();
                    obtbPreguntasJuego.prjuSalio = "no salio";
                    obbdConoceAColombiaEntities.SaveChanges();


                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }





    }
}