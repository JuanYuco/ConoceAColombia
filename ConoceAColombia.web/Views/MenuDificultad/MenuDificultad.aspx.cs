using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConoceAColombia.web.Views.MenuDificultad
{
    public partial class MenuDificultad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                if (Session["Tematica"] != null)
                {
                    lblTematica.Text = Session["Tematica"].ToString();
                }
                else
                {
                    Response.Redirect("../MenuJuego/MenuJuego.aspx");
                }
            }
        }

        protected void btnDificultadFacil_Click(object sender, EventArgs e)
        {
            Session["Dificultad"] = "Fácil";

        }

        protected void btnDificultadMedio_Click(object sender, EventArgs e)
        {
            Session["Dificultad"] = "Medio";
        }

        protected void btnDificultadDificil_Click(object sender, EventArgs e)
        {
            Session["Dificultad"] = "Difícil";
        }
    }
}