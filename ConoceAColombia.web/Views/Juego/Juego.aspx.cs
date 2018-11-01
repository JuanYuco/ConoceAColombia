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
        public void getPregunta()
        {
            Random rnd = new Random();
            int numero = rnd.Next(1, 4);
            Controllers.JuegoControllers obJuegoControllers = new Controllers.JuegoControllers();
            logica.Models.clsPreguntasJuego clsPreguntasJuego = obJuegoControllers.getPregunta(obJuegoControllers.getPreguntas());
            lblPregunta.Text = clsPreguntasJuego.stPregunta;
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


            else if (clsPreguntasJuego.obclsTipoJuego.stDescripcion.Equals("Anagrama"))
            {

                divRespuestas.Visible = false;
                string[] letras = clsPreguntasJuego.stRespuestaCorrecta.Split(' ');
                int valor3 = 1;

                while (valor3 == 1)
                {

                    Button botones = new Button();
                    int contador = 0;
                    int numeroDos = rnd.Next(0, letras.Length);
                    if (!letras[numeroDos].Equals(""))
                    {
                        botones.ID = numeroDos.ToString();
                        botones.Text = letras[numeroDos];
                        botones.CssClass = "btn btn-primary";
                        botones.Click += new EventHandler(Botones_Click);
                        
                        divLetras.Controls.Add(botones);

                        letras[numeroDos] = "";
                    }
                    for (int i = 0; i < letras.Length; i++)
                    {
                        if (letras[i].Equals(""))
                        {
                            contador = contador + 1;
                        }
                    }
                    if (contador == letras.Length)
                    {
                        valor3 = 0;
                    }

                }

            }


        }

        private void Botones_Click(object sender, EventArgs e)
        {
           
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getPregunta();
            }

        }


    }
}