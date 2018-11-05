using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConoceAColombia.web.Views.MenuJuego
{
    public partial class MenuJuego : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnJuegoRandom_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnJuegoGeografia_Click(object sender, EventArgs e)
        {
            Session["Tematica"] = "Geografía";
            Response.Redirect("../MenuDificultad/MenuDificultad.aspx");
        }

        protected void btnJuegoGastronomia_Click(object sender, EventArgs e)
        {
            Session["Tematica"] = "Gastronomía";
            Response.Redirect("../MenuDificultad/MenuDificultad.aspx");
        }

        protected void btnHistoria_Click(object sender, EventArgs e)
        {
            Session["Tematica"] = "Historía";
            Response.Redirect("../MenuDificultad/MenuDificultad.aspx");
        }

        protected void btnDeportes_Click(object sender, EventArgs e)
        {
            Session["Tematica"] = "Deportes";
            Response.Redirect("../MenuDificultad/MenuDificultad.aspx");
        }

        protected void btnFlora_Click(object sender, EventArgs e)
        {
            Session["Tematica"] = "Flora";
            Response.Redirect("../MenuDificultad/MenuDificultad.aspx");
        }

        protected void btnFauna_Click(object sender, EventArgs e)
        {
            Session["Tematica"] = "Fauna";
            Response.Redirect("../MenuDificultad/MenuDificultad.aspx");
        }

        protected void btnMusica_Click(object sender, EventArgs e)
        {
            Session["Tematica"] = "Música";
            Response.Redirect("../MenuDificultad/MenuDificultad.aspx");
        }
    }
}