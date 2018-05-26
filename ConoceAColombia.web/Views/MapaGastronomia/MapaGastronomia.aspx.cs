using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace ConoceAColombia.web.Views.MapaGastronomia
{
    public partial class MapaGastronomia : System.Web.UI.Page
    {
        void getGastronomia()
        {
            try
            {
                Controllers.GastronomiaControllers obGastronomiaControllers = new Controllers.GastronomiaControllers();
                DataSet dsConsulta = obGastronomiaControllers.getConsultarGastronomiaController();
                if (dsConsulta.Tables[0].Rows.Count > 0)
                {
                    rpGastronomia.DataSource = dsConsulta;
                }
                else
                {
                    rpGastronomia.DataSource = null;
                }
                rpGastronomia.DataBind();
            }
            catch (Exception ex) { ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('ERROR!', '" + ex.Message + "!', 'error')</Script>"); }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getGastronomia();
            }
        }
    }
}