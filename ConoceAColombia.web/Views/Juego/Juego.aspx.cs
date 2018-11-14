using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConoceAColombia.web.Views.Juego
{
    public partial class Juego : System.Web.UI.Page
    {



        public static List<int> lstCodigos = new List<int>();
        public void getPregunta()
        {
            Random rnd = new Random();
            int numero = rnd.Next(1, 4);
            Controllers.JuegoControllers obJuegoControllers = new Controllers.JuegoControllers();
            logica.Models.clsPreguntasJuego clsPreguntasJuego = obJuegoControllers.getPregunta(obJuegoControllers.getPreguntas(),lstCodigos);
            if (clsPreguntasJuego.stPregunta.Equals("Ya se acabaron las preguntas"))
            {
                lblPuntaje.Text = (Convert.ToInt32(lblPuntaje.Text) + 1).ToString();
                Session["Puntaje"] = lblPuntaje.Text;
                lblPuntaje.Text = "0";
                lstCodigos.Clear();
                Response.Redirect("../Puntajes/Puntajes.aspx");
            }
            else
            {
                lblPregunta.Text = clsPreguntasJuego.stPregunta;
                lstCodigos.Add((int)clsPreguntasJuego.lgCodigo);
                clsPreguntasJuego.stSalio = "Salio";
                lblRespuestaCorrecta.Text = clsPreguntasJuego.stRespuestaCorrecta;

                if (clsPreguntasJuego.obclsTipoJuego.stDescripcion.Equals("Preguntas y Respuestas"))
                {
                    string[] preguntasmalas = { clsPreguntasJuego.stRespuestaIncorrectaUno,
                clsPreguntasJuego.stRespuestaIncorrectaDos,
                clsPreguntasJuego.stRespuestaIncorrectaTres,
                clsPreguntasJuego.stRespuestaIncorrectaCuatro,
                clsPreguntasJuego.stRespuestaIncorrectaCinco};
                    int valor = 1;

                    while (valor == 1)
                    {
                        if (numero == 1)
                        {
                            btnRespuestaUno.Text = clsPreguntasJuego.stRespuestaCorrecta;
                            valor = 0;
                        }
                        else if (numero == 2)
                        {
                            btnRespuestaDos.Text = clsPreguntasJuego.stRespuestaCorrecta;
                            valor = 0;
                        }
                        else if (numero == 3)
                        {
                            btnRespuestaTres.Text = clsPreguntasJuego.stRespuestaCorrecta;
                            valor = 0;
                        }
                        else if (numero == 4)
                        {
                            btnRespuestaCuatro.Text = clsPreguntasJuego.stRespuestaCorrecta;
                            valor = 0;
                        }

                    }
                    int valor2 = 1;
                    while (valor2 == 1)
                    {
                        int seleccion = rnd.Next(0, 4);
                        if (btnRespuestaUno.Text.Equals("") && btnRespuestaDos.Text != preguntasmalas[seleccion]
                            && btnRespuestaTres.Text != preguntasmalas[seleccion] && btnRespuestaCuatro.Text != preguntasmalas[seleccion])
                        {
                            btnRespuestaUno.Text = preguntasmalas[seleccion];
                        }

                        else if (btnRespuestaDos.Text.Equals("") && btnRespuestaUno.Text != preguntasmalas[seleccion]
                            && btnRespuestaTres.Text != preguntasmalas[seleccion] && btnRespuestaCuatro.Text != preguntasmalas[seleccion])
                        {
                            btnRespuestaDos.Text = preguntasmalas[seleccion];
                        }

                        else if (btnRespuestaTres.Text.Equals("") && btnRespuestaDos.Text != preguntasmalas[seleccion]
                            && btnRespuestaUno.Text != preguntasmalas[seleccion] && btnRespuestaCuatro.Text != preguntasmalas[seleccion])
                        {
                            btnRespuestaTres.Text = preguntasmalas[seleccion];
                        }

                        else if (btnRespuestaCuatro.Text.Equals("") && btnRespuestaDos.Text != preguntasmalas[seleccion]
                            && btnRespuestaTres.Text != preguntasmalas[seleccion] && btnRespuestaUno.Text != preguntasmalas[seleccion])
                        {
                            btnRespuestaCuatro.Text = preguntasmalas[seleccion];
                        }

                        if (!btnRespuestaUno.Text.Equals("") && !btnRespuestaDos.Text.Equals("") && !btnRespuestaTres.Text.Equals("") && !btnRespuestaCuatro.Text.Equals(""))
                        {
                            valor2 = 0;
                        }
                    }
                }

            }



        }


        public void getTime()
        {
            Session["Timer"] = DateTime.Now.AddSeconds(1000000).ToString();
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getPregunta();
                getTime();
            }

        }

        protected void btnRespuestaUno_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnRespuestaUno.Text.Equals(lblRespuestaCorrecta.Text))
                {
                    btnRespuestaUno.Text = "";
                    btnRespuestaDos.Text = "";
                    btnRespuestaTres.Text = "";
                    btnRespuestaCuatro.Text = "";
                    getPregunta();
                    ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('Perfecto!', '" + "La respuesta es Correcta" + "!', 'success')</Script>");
                    lblPuntaje.Text = (Convert.ToInt32(lblPuntaje.Text) + 1).ToString();
                    getTime();
                    

                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('Que mal!', '" + "La respuesta es Incorrecta, tu puntaje final es " + lblPuntaje.Text + "!', 'error')</Script>");
                    Session["Puntaje"] = lblPuntaje.Text;
                    lblPuntaje.Text = "0";
                    lstCodigos.Clear();
                    Response.Redirect("../Puntajes/Puntajes.aspx");
                }
            }
            catch (Exception ew)
            {
                throw ew;
            }
        }

        protected void btnRespuestaDos_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnRespuestaDos.Text.Equals(lblRespuestaCorrecta.Text))
                {
                    btnRespuestaUno.Text = "";
                    btnRespuestaDos.Text = "";
                    btnRespuestaTres.Text = "";
                    btnRespuestaCuatro.Text = "";
                    getPregunta();
                    ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('Perfecto!', '" + "La respuesta es Correcta" + "!', 'success')</Script>");
                    lblPuntaje.Text = (Convert.ToInt32(lblPuntaje.Text) + 1).ToString();
                    getTime();

                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('Que mal!', '" + "La respuesta es Incorrecta, tu puntaje final es " + lblPuntaje.Text + "!', 'error')</Script>");
                    Session["Puntaje"] = lblPuntaje.Text;
                    lblPuntaje.Text = "0";
                    lstCodigos.Clear();
                    Response.Redirect("../Puntajes/Puntajes.aspx");
                }
            }
            catch (Exception ew)
            {
                throw ew;
            }
        }

        protected void btnRespuestaTres_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnRespuestaTres.Text.Equals(lblRespuestaCorrecta.Text))
                {
                    btnRespuestaUno.Text = "";
                    btnRespuestaDos.Text = "";
                    btnRespuestaTres.Text = "";
                    btnRespuestaCuatro.Text = "";
                    getPregunta();
                    ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('Perfecto!', '" + "La respuesta es Correcta" + "!', 'success')</Script>");
                    lblPuntaje.Text = (Convert.ToInt32(lblPuntaje.Text) + 1).ToString();
                    getTime();
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('Que mal!', '" + "La respuesta es Incorrecta, tu puntaje final es " + lblPuntaje.Text + "!', 'error')</Script>");
                    Session["Puntaje"] = lblPuntaje.Text;
                    lblPuntaje.Text = "0";
                    lstCodigos.Clear();
                    Response.Redirect("../Puntajes/Puntajes.aspx");

                }
            }
            catch (Exception ew)
            {
                throw ew;
            }
        }

        protected void btnRespuestaCuatro_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnRespuestaCuatro.Text.Equals(lblRespuestaCorrecta.Text))
                {
                    btnRespuestaUno.Text = "";
                    btnRespuestaDos.Text = "";
                    btnRespuestaTres.Text = "";
                    btnRespuestaCuatro.Text = "";
                    getPregunta();
                    ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('Perfecto!', '" + "La respuesta es Correcta" + "!', 'success')</Script>");
                    lblPuntaje.Text = (Convert.ToInt32(lblPuntaje.Text) + 1).ToString();
                    getTime();

                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('Que mal!', '" + "La respuesta es Incorrecta, tu puntaje final es " + lblPuntaje.Text + "!', 'error')</Script>");
                    Session["Puntaje"] = lblPuntaje.Text;
                    lblPuntaje.Text = "0";
                    lstCodigos.Clear();
                    Response.Redirect("../Puntajes/Puntajes.aspx");
                }
            }
            catch (Exception ew)
            {
                throw ew;
            }
        }


        protected void tmTiempo_Tick(object sender, EventArgs e)
        {
            if (DateTime.Compare(DateTime.Now, DateTime.Parse(Session["Timer"].ToString())) < 0)
            {
                ltMsg.Text = "Tiempo " + (((Int32)DateTime.Parse(Session["Timer"].ToString()).Subtract(DateTime.Now).TotalSeconds) % 60).ToString();
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('Que mal!', '" + "El tiempo ah terminado, tu puntaje final es " + lblPuntaje.Text + "!', 'error')</Script>");
                Session["Puntaje"] = lblPuntaje.Text;
                lblPuntaje.Text = "0";
                Response.Redirect("../Puntajes/Puntajes.aspx");
            }
        }




    }
}