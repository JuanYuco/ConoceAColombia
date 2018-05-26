using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace ConoceAColombia.web.Views.MapaPersonajesPublicos
{
    public partial class MapaPersonajesPublicos : System.Web.UI.Page
    {
        void getArtistas()
        {
            try
            {
                Controllers.ArtistasControllers obCiudadesArtistasControllers = new Controllers.ArtistasControllers();
                DataSet dsConsulta = obCiudadesArtistasControllers.getConsultarArtistasController();
                if (dsConsulta.Tables[0].Rows.Count > 0)
                {
                    rpPersonajesPublicos.DataSource = dsConsulta;
                }
                else
                {
                    rpPersonajesPublicos.DataSource = null;
                }
                rpPersonajesPublicos.DataBind();
            }
            catch (Exception ex) { ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('ERROR!', '" + ex.Message + "!', 'error')</Script>"); }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getArtistas();
            }
        }
    }
}