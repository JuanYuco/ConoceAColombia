using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConoceAColombia.web.Views.PreguntasJuego
{
    public partial class PreguntasJuego : System.Web.UI.Page
    {
        void getPreguntasJuego()
        {
            try
            {
                Controllers.PreguntasJuegoControllers obPreguntasJuegoControllers = new Controllers.PreguntasJuegoControllers();
                gvwDatos.DataSource = obPreguntasJuegoControllers.getPreguntasJuego();
                gvwDatos.DataBind();
            }
            catch (Exception ex) { ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('ERROR!', '" + ex.Message + "!', 'error')</Script>"); }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getPreguntasJuego();
                logica.BL.clsPreguntasJuego obclsPreguntasJuego = new logica.BL.clsPreguntasJuego();
                Controllers.PreguntasJuegoControllers obPreguntasJuegoControllers = new Controllers.PreguntasJuegoControllers();
                List<logica.Models.clsTematicasJuego> consultaTematicas = obPreguntasJuegoControllers.getTematicasJuego();
                List<logica.Models.clsTipoJuego> consultaTipoJuego = obPreguntasJuegoControllers.getTipoJuego();
                List<logica.Models.clsDicultadJuego> consultaDificultadJuego = obPreguntasJuegoControllers.getDificultadJuego();
                obclsPreguntasJuego.CargarControlTematicasJuego(ref ddlTematicasJuego, consultaTematicas, "lgCodigo", "stDescripcion", "-1", "<<Todos>>");
                obclsPreguntasJuego.CargarControlTipoJuego(ref ddlTipoJuego, consultaTipoJuego, "lgCodigo", "stDescripcion", "-1", "<<Todos>>");
                obclsPreguntasJuego.CargarControlDificultad(ref ddlDicultadJuego, consultaDificultadJuego, "lgCodigo", "stDescripcion", "-1", "<<Todos>>");
            }

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                String stMensaje = String.Empty;
                if (String.IsNullOrEmpty(txtCodigo.Text)) stMensaje += "Ingrese Codigo, ";
                if (String.IsNullOrEmpty(txtPregunta.Text)) stMensaje += "Ingrese Pregunta, ";
                if (String.IsNullOrEmpty(txtRespuestaCorrecta.Text)) stMensaje += "Ingrese Respuesta Correcta, ";
                if (String.IsNullOrEmpty(txtRespuestaIncorrectaUno.Text)) stMensaje += "Ingrese Respuesta incorrecta Uno, ";
                if (String.IsNullOrEmpty(txtRespuestaIncorrectaDos.Text)) stMensaje += "Ingrese Respuesta Incorrecta Dos, ";
                if (String.IsNullOrEmpty(txtRespuestaIncorrectaTres.Text)) stMensaje += "Ingrese Respuesta Incorrecta Tres, ";
                if (String.IsNullOrEmpty(txtRespuestaIncorrectaCuatro.Text)) stMensaje += "Ingrese Respuesta Incorrecta Cuatro, ";
                if (String.IsNullOrEmpty(txtRespuestaIncorrectaCinco.Text)) stMensaje += "Ingrese Respuesta Incorrecta Cinco, ";
                if (!String.IsNullOrEmpty(stMensaje)) throw new Exception(stMensaje.TrimEnd(','));

                logica.Models.clsPreguntasJuego clsPreguntasJuego = new logica.Models.clsPreguntasJuego
                {
                    lgCodigo = Convert.ToInt64(txtCodigo.Text),
                    stPregunta = txtPregunta.Text,
                    stRespuestaCorrecta = txtRespuestaCorrecta.Text,
                    stRespuestaIncorrectaUno = txtRespuestaIncorrectaUno.Text,
                    stRespuestaIncorrectaDos = txtRespuestaIncorrectaDos.Text,
                    stRespuestaIncorrectaTres = txtRespuestaIncorrectaTres.Text,
                    stRespuestaIncorrectaCuatro = txtRespuestaIncorrectaCuatro.Text,
                    stRespuestaIncorrectaCinco = txtRespuestaIncorrectaCinco.Text,
                    obclsTematicasJuego = new logica.Models.clsTematicasJuego {lgCodigo =  Convert.ToInt64(ddlTematicasJuego.SelectedValue) },
                    obclsTipoJuego = new logica.Models.clsTipoJuego { lgCodigo = Convert.ToInt64(ddlTipoJuego.SelectedValue)},
                    obclsDicultadJuego = new logica.Models.clsDicultadJuego { lgCodigo = Convert.ToInt64(ddlDicultadJuego.SelectedValue)}

                };

                Controllers.PreguntasJuegoControllers obPreguntasJuegoControllers = new Controllers.PreguntasJuegoControllers();
                if (String.IsNullOrEmpty(lblOpcion.Text)) lblOpcion.Text = "1";

                if (lblOpcion.Text.Equals("1"))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('Mensaje!,'" + obPreguntasJuegoControllers.insertarPreguntasJuego(clsPreguntasJuego) + "!','success')</Script>");
                    lblOpcion.Text = txtCodigo.Text = txtPregunta.Text = txtRespuestaCorrecta.Text = txtRespuestaIncorrectaUno.Text = txtRespuestaIncorrectaDos.Text = txtRespuestaIncorrectaTres.Text = txtRespuestaIncorrectaCuatro.Text = txtRespuestaIncorrectaCinco.Text = String.Empty ;
                    getPreguntasJuego();
                }
                else if (lblOpcion.Text.Equals("2"))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('Mensaje!,'" + obPreguntasJuegoControllers.updatePreguntasJuego(clsPreguntasJuego) + "!','success')</Script>");
                    lblOpcion.Text = txtCodigo.Text = txtPregunta.Text = txtRespuestaCorrecta.Text = txtRespuestaIncorrectaUno.Text = txtRespuestaIncorrectaDos.Text = txtRespuestaIncorrectaTres.Text = txtRespuestaIncorrectaCuatro.Text = txtRespuestaIncorrectaCinco.Text = String.Empty;
                    getPreguntasJuego();
                }


            }
            catch (Exception ex) { ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> Swal('MENSAJE!', '" + ex.Message + "!','success')</Script>"); }

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            lblOpcion.Text = txtCodigo.Text = txtPregunta.Text = txtRespuestaCorrecta.Text = txtRespuestaIncorrectaUno.Text = txtRespuestaIncorrectaDos.Text = txtRespuestaIncorrectaTres.Text = txtRespuestaIncorrectaCuatro.Text = txtRespuestaIncorrectaCinco.Text = String.Empty;
        }

        protected void gvwDatos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int inIndice = Convert.ToInt16(e.CommandArgument);
                if (e.CommandName.Equals("Editar"))
                {
                    lblOpcion.Text = "2";
                    txtCodigo.Text = ((Label)gvwDatos.Rows[inIndice].FindControl("lblCodigo")).Text;
                    txtPregunta.Text = String.IsNullOrEmpty(gvwDatos.Rows[inIndice].Cells[1].Text) ? String.Empty : gvwDatos.Rows[inIndice].Cells[1].Text;
                    txtRespuestaCorrecta.Text = String.IsNullOrEmpty(gvwDatos.Rows[inIndice].Cells[2].Text) ? String.Empty : gvwDatos.Rows[inIndice].Cells[2].Text;
                    txtRespuestaIncorrectaUno.Text = String.IsNullOrEmpty(gvwDatos.Rows[inIndice].Cells[3].Text) ? String.Empty : gvwDatos.Rows[inIndice].Cells[3].Text;
                    txtRespuestaIncorrectaDos.Text = String.IsNullOrEmpty(gvwDatos.Rows[inIndice].Cells[4].Text) ? String.Empty : gvwDatos.Rows[inIndice].Cells[4].Text;
                    txtRespuestaIncorrectaTres.Text = String.IsNullOrEmpty(gvwDatos.Rows[inIndice].Cells[5].Text) ? String.Empty : gvwDatos.Rows[inIndice].Cells[5].Text;
                    txtRespuestaIncorrectaCuatro.Text = String.IsNullOrEmpty(gvwDatos.Rows[inIndice].Cells[6].Text) ? String.Empty : gvwDatos.Rows[inIndice].Cells[6].Text;
                    txtRespuestaIncorrectaCinco.Text = String.IsNullOrEmpty(gvwDatos.Rows[inIndice].Cells[7].Text) ? String.Empty : gvwDatos.Rows[inIndice].Cells[7].Text;
                }
                else if (e.CommandName.Equals("Eliminar"))
                {
                    logica.Models.clsPreguntasJuego obclsPreguntasJuego = new logica.Models.clsPreguntasJuego
                    {
                        lgCodigo = Convert.ToInt32(((Label)gvwDatos.Rows[inIndice].FindControl("lblCodigo")).Text),
                        stPregunta = String.Empty,
                        stRespuestaCorrecta = String.Empty,
                        stRespuestaIncorrectaUno = String.Empty,
                        stRespuestaIncorrectaDos = String.Empty,
                        stRespuestaIncorrectaTres = String.Empty,
                        stRespuestaIncorrectaCuatro = String.Empty,
                        stRespuestaIncorrectaCinco = String.Empty,
                        obclsTematicasJuego = new logica.Models.clsTematicasJuego { lgCodigo = 0},
                        obclsTipoJuego = new logica.Models.clsTipoJuego { lgCodigo = 0},
                        obclsDicultadJuego = new logica.Models.clsDicultadJuego { lgCodigo = 0}

                    };

                    Controllers.PreguntasJuegoControllers obPreguntasJuegoControllers = new Controllers.PreguntasJuegoControllers();

                    ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('MENSAJE!', '" + obPreguntasJuegoControllers.deletePreguntasJuego(obclsPreguntasJuego) + "!','Success')</Script>");

                    lblOpcion.Text = txtCodigo.Text = txtPregunta.Text = txtRespuestaCorrecta.Text = txtRespuestaIncorrectaUno.Text = txtRespuestaIncorrectaDos.Text = txtRespuestaIncorrectaTres.Text = txtRespuestaIncorrectaCuatro.Text = txtRespuestaIncorrectaCinco.Text = String.Empty;
                    getPreguntasJuego();

                }

            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('ERROR!', '" + ex.Message + "!', 'ERROR')</Script>");
            }
        }
    }
}