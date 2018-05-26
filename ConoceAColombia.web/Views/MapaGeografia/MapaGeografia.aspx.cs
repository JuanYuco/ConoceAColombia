using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace ConoceAColombia.web.Views.MapaEsteSi
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        void getCiudadesPrincipales()
        {
            try
            {
                Controllers.CiudadesPrincipalesControllers obCiudadesPrincipalesController = new Controllers.CiudadesPrincipalesControllers();
                DataSet dsConsulta = obCiudadesPrincipalesController.getConsultarCiudadesPrincipalesController();
                if (dsConsulta.Tables[0].Rows.Count > 0)
                {
                    rpCiudadesPricipales.DataSource = dsConsulta;
                }
                else
                {
                    rpCiudadesPricipales.DataSource = null;
                }
                rpCiudadesPricipales.DataBind();
            }
            catch (Exception ex) { ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('ERROR!', '" + ex.Message + "!', 'error')</Script>"); }

        }
        void getDepartamentos()
        {
            try
            {
                Controllers.DepartamentosControllers obdepartamentosControllers = new Controllers.DepartamentosControllers();
                DataSet dsConsulta = obdepartamentosControllers.getConsultarPosiblesClientesController();
                if (dsConsulta.Tables[0].Rows.Count > 0)
                {
                    rpDepartamentos.DataSource = dsConsulta;
                }
                else
                {
                    rpDepartamentos.DataSource = null;
                }
                rpDepartamentos.DataBind();
            }
            catch (Exception ex) { ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('ERROR!', '" + ex.Message + "!', 'error')</Script>"); }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getDepartamentos();
                getCiudadesPrincipales();
            }
        }
    }
}