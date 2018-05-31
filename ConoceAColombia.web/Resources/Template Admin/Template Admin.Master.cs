using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConoceAColombia.web.Resources.Template_Admin
{
    public partial class Template_Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string[] stEmail = null;
                if (Session["SessionEmailAdministrador"] != null)
                {
                    stEmail = Session["SessionEmailAdministrador"].ToString().Split('@');
                    lblUsuario.Text = stEmail[0];
                }
            }
        }

        protected void lbSalir_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("../../Views/LoginAdministrador/loginAdministrador.aspx");
        }
    }
}