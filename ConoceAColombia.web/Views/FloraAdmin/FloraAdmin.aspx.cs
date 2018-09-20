using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConoceAColombia.web.Views.FloraAdmin
{
    public partial class FloraAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getFlora();
            }

        }
        public void getFlora()
        {
            try
            {
                Controllers.FloraControllers obFloraControllers = new Controllers.FloraControllers();
                List<logica.Models.clsFlora> ltsclsFlora = obFloraControllers.getFloraController();

                if (ltsclsFlora.Count > 0) gvwDatos.DataSource = ltsclsFlora;
                else gvwDatos.DataSource = null;

                gvwDatos.DataBind();
            }catch(Exception ew)
            {
                throw ew;
            }
        }

        protected void gvwDatos_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {

        }
    }
}