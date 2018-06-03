using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace ConoceAColombia.web.Views.MapaMusica
{
    public partial class MapaMusica : System.Web.UI.Page
    {
        void getMusica()
        {
            try
            {
                Controllers.MusicaControllers obCiudadesMusicaControllers = new Controllers.MusicaControllers();
                DataSet dsConsulta = obCiudadesMusicaControllers.getConsultarMusicaController();
                if (dsConsulta.Tables[0].Rows.Count > 0)
                {
                    rpMusica.DataSource = dsConsulta;
                }
                else
                {
                    rpMusica.DataSource = null;
                }
                rpMusica.DataBind();
            }
            catch (Exception ex) { ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('ERROR!', '" + ex.Message + "!', 'error')</Script>"); }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getMusica();
            }
        }
    }
}