using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConoceAColombia.web.Views.Puntajes
{
    public partial class Puntajes : System.Web.UI.Page
    {
        public void getPuntajes()
        {
            Controllers.PuntajePorPersonasControllers puntajePorPersonasControllers = new Controllers.PuntajePorPersonasControllers();
            List<logica.Models.clsPuntajePorPersona> lstPuntajeporPersona = puntajePorPersonasControllers.getPuntajePorPersona();
            gvwDatos.DataSource = lstPuntajeporPersona;
            gvwDatos.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Tematica"] == null || Session["Dificultad"] == null || Session["Puntaje"] == null)
                {
                    Response.Redirect("../MenuJuego/MenuJuego.aspx");
                }
            }
            
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {

            Response.Redirect("../MenuJuego/MenuJuego.aspx");

        }

        protected void gvwDatos_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Controllers.PuntajePorPersonasControllers obPuntajesPorPersonasControllers = new Controllers.PuntajePorPersonasControllers();
                logica.Models.clsPuntajePorPersona obPuntajePorPersonaModels = new logica.Models.clsPuntajePorPersona
                {
                    stNombreCompleto = txtNombre.Text,
                    inPuntaje = Convert.ToInt32(Session["Puntaje"].ToString()),
                    stTipoJuego = Session["Tematica"].ToString(),
                    stDificultad = Session["Dificultad"].ToString()
                };

                obPuntajesPorPersonasControllers.addPuntajePorPersona(obPuntajePorPersonaModels);
                divLlenar.Visible = false;
                getPuntajes();
                divPuntajes.Visible = true; 
            }
            catch (Exception ew)
            {
                throw ew;
            }
        }
    }
}