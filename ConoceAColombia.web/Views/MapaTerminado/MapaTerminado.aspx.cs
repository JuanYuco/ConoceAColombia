using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace ConoceAColombia.web.Views.MapaTerminado
{
    public partial class MapaTerminado : System.Web.UI.Page
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
        public void getEquipo()
        {
            Controllers.EquipoControllers obEquipoControllers = new Controllers.EquipoControllers();
            rpDeportes.DataSource = obEquipoControllers.getEquipo();
            rpDeportes.DataBind();
        }

        void getEstructurasDeportivas()
        {
            Controllers.ArquitecturaControllers obArquitecturaControllers = new Controllers.ArquitecturaControllers();
            DataSet dsConsulta = obArquitecturaControllers.getConsultarEstructurasDeportivas();
            if(dsConsulta.Tables[0].Rows.Count > 0)
            {
                rpEstructurasDeportivas.DataSource = dsConsulta;
            }
            else
            {
                rpEstructurasDeportivas.DataSource = null;
            }
            rpEstructurasDeportivas.DataBind();
        }


        void getHistoria()
        {
            try
            {
                Controllers.HistoriaControllers obHistoriaControllers = new Controllers.HistoriaControllers();
                DataSet dsConsulta = obHistoriaControllers.getConsultarHistoriaController();
                if (dsConsulta.Tables[0].Rows.Count > 0)
                {
                    rpHistoria.DataSource = dsConsulta;
                }
                else
                {
                    rpHistoria.DataSource = null;
                }
                rpHistoria.DataBind();
            }
            catch (Exception ex) { ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('ERROR!', '" + ex.Message + "!', 'error')</Script>"); }
        }

        void getPersonajesHistoricos()
        {
            try
            {
                Controllers.PersonajesHistoricosControllers obPersonajesHistoricosControllers = new Controllers.PersonajesHistoricosControllers();
                DataSet dsConsulta = obPersonajesHistoricosControllers.getConsultarPersonajesHistoricosController();
                if (dsConsulta.Tables[0].Rows.Count > 0)
                {
                    rpPersonajesHistoricos.DataSource = dsConsulta;
                }
                else
                {
                    rpPersonajesHistoricos.DataSource = null;
                }
                rpPersonajesHistoricos.DataBind();
            }
            catch (Exception ex) { ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('ERROR!', '" + ex.Message + "!', 'error')</Script>"); }
        }

        void getArquitectura()
        {
            try
            {
                Controllers.ArquitecturaControllers obArquitecturaControllers = new Controllers.ArquitecturaControllers();
                DataSet dsConsulta = obArquitecturaControllers.getConsultarArquitecturaController();
                if (dsConsulta.Tables[0].Rows.Count > 0)
                {
                    rpArquitectura.DataSource = dsConsulta;
                }
                else
                {
                    rpArquitectura.DataSource = null;
                }
                rpArquitectura.DataBind();
            }
            catch (Exception ex) { ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('ERROR!', '" + ex.Message + "!', 'error')</Script>"); }

        }

        void getFlora()
        {
            try
            {
                Controllers.FloraControllers obFloraControllers = new Controllers.FloraControllers();
                rpFlora.DataSource = obFloraControllers.getFlora();
                rpFlora.DataBind();
            }
            catch (Exception ew)
            {
                throw ew;
            }
        }

        void getFauna()
        {
            try
            {
                Controllers.FaunaxDepartamentoControllers obFaunaxDepartamentoControllers = new Controllers.FaunaxDepartamentoControllers();
                rpFauna.DataSource = obFaunaxDepartamentoControllers.getTodoFauna();
                rpFauna.DataBind();
            }catch(Exception ew)
            {
                throw ew;
            }
        }


        void getCulturas()
        {
            try
            {
                Controllers.CulturasControllers obCulturasControllers = new Controllers.CulturasControllers();
                rpCulturas.DataSource = obCulturasControllers.getCulturas();
                rpCulturas.DataBind();
            }catch(Exception ew)
            {
                throw ew;
            }
        }



        




        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string[] stEmail = null;
                if (Session["SessionEmail"] != null)
                {
                    stEmail = Session["SessionEmail"].ToString().Split('@');
                    lblUsuario.Text = stEmail[0];
                }
                string stLogin = string.Empty;
                string stPassword = string.Empty;
                if (Request.QueryString["stLogin"] != null && Request.QueryString["stPassword"] != null)
                    stLogin = Request.QueryString["stLogin"].ToString();



                if (Session["SessionEmail"] != null)
                    stLogin = Session["SessionEmail"].ToString();
                else
                    Response.Redirect("../Login/Login.aspx");
            }

        }

      

        protected void lbSalir_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("../../Views/Login/login.aspx");
        }

        protected void linkGeografia_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(GetType(),"Borrar Marcadores", "deleteMarkers()", true);
            getDepartamentos();
            getCiudadesPrincipales();
            rpGastronomia.DataSource = null;
            rpGastronomia.DataBind();
            rpMusica.DataSource = null;
            rpMusica.DataBind();
            rpPersonajesPublicos.DataSource = null;
            rpPersonajesPublicos.DataBind();
            rpDeportes.DataSource = null;
            rpDeportes.DataBind();
            rpEstructurasDeportivas.DataSource = null;
            rpEstructurasDeportivas.DataBind();
            rpHistoria.DataSource = null;
            rpHistoria.DataBind();
            rpPersonajesHistoricos.DataSource = null;
            rpPersonajesHistoricos.DataBind();
            rpArquitectura.DataSource = null;
            rpArquitectura.DataBind();
            rpFlora.DataSource = null;
            rpFlora.DataBind();
            rpFauna.DataSource = null;
            rpFauna.DataBind();
            rpCulturas.DataSource = null;
            rpCulturas.DataBind();
        }

        protected void LinkPersonajesPublicos_Click(object sender, EventArgs e)
        {
            getArtistas();
            rpGastronomia.DataSource = null;
            rpGastronomia.DataBind();
            rpMusica.DataSource = null;
            rpMusica.DataBind();
            rpDepartamentos.DataSource = null;
            rpDepartamentos.DataBind();
            rpCiudadesPricipales.DataSource = null;
            rpCiudadesPricipales.DataBind();
            rpDeportes.DataSource = null;
            rpDeportes.DataBind();
            rpEstructurasDeportivas.DataSource = null;
            rpEstructurasDeportivas.DataBind();
            rpHistoria.DataSource = null;
            rpHistoria.DataBind();
            rpPersonajesHistoricos.DataSource = null;
            rpPersonajesHistoricos.DataBind();
            rpArquitectura.DataSource = null;
            rpArquitectura.DataBind();
            rpFlora.DataSource = null;
            rpFlora.DataBind();
            rpFauna.DataSource = null;
            rpFauna.DataBind();
            rpCulturas.DataSource = null;
            rpCulturas.DataBind();
        }

        protected void LinkArte_Click(object sender, EventArgs e)
        {
            getArquitectura();
            rpGastronomia.DataSource = null;
            rpGastronomia.DataBind();
            rpMusica.DataSource = null;
            rpMusica.DataBind();
            rpDepartamentos.DataSource = null;
            rpDepartamentos.DataBind();
            rpCiudadesPricipales.DataSource = null;
            rpCiudadesPricipales.DataBind();
            rpDeportes.DataSource = null;
            rpDeportes.DataBind();
            rpEstructurasDeportivas.DataSource = null;
            rpEstructurasDeportivas.DataBind();
            rpHistoria.DataSource = null;
            rpHistoria.DataBind();
            rpPersonajesHistoricos.DataSource = null;
            rpPersonajesHistoricos.DataBind();
            rpFlora.DataSource = null;
            rpFlora.DataBind();
            rpFauna.DataSource = null;
            rpFauna.DataBind();
            rpCulturas.DataSource = null;
            rpCulturas.DataBind();

        }

        protected void LinkGastronomia_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(GetType(), "Borrar Marcadores", "deleteMarkers()", true);
            getGastronomia();
            rpDepartamentos.DataSource = null;
            rpDepartamentos.DataBind();
            rpCiudadesPricipales.DataSource = null;
            rpCiudadesPricipales.DataBind();
            rpMusica.DataSource = null;
            rpMusica.DataBind();
            rpPersonajesPublicos.DataSource = null;
            rpPersonajesPublicos.DataBind();
            rpDeportes.DataSource = null;
            rpDeportes.DataBind();
            rpEstructurasDeportivas.DataSource = null;
            rpEstructurasDeportivas.DataBind();
            rpHistoria.DataSource = null;
            rpHistoria.DataBind();
            rpPersonajesHistoricos.DataSource = null;
            rpPersonajesHistoricos.DataBind();
            rpArquitectura.DataSource = null;
            rpArquitectura.DataBind();
            rpFlora.DataSource = null;
            rpFlora.DataBind();
            rpFauna.DataSource = null;
            rpFauna.DataBind();
            rpCulturas.DataSource = null;
            rpCulturas.DataBind();
        }

        protected void LinkMusica_Click(object sender, EventArgs e)
        {
            getMusica();
            rpDepartamentos.DataSource = null;
            rpDepartamentos.DataBind();
            rpCiudadesPricipales.DataSource = null;
            rpCiudadesPricipales.DataBind();
            rpGastronomia.DataSource = null;
            rpGastronomia.DataBind();
            rpPersonajesPublicos.DataSource = null;
            rpPersonajesPublicos.DataBind();
            rpDeportes.DataSource = null;
            rpDeportes.DataBind();
            rpEstructurasDeportivas.DataSource = null;
            rpEstructurasDeportivas.DataBind();
            rpHistoria.DataSource = null;
            rpHistoria.DataBind();
            rpPersonajesHistoricos.DataSource = null;
            rpPersonajesHistoricos.DataBind();
            rpArquitectura.DataSource = null;
            rpArquitectura.DataBind();
            rpFlora.DataSource = null;
            rpFlora.DataBind();
            rpFauna.DataSource = null;
            rpFauna.DataBind();
            rpCulturas.DataSource = null;
            rpCulturas.DataBind();
        }

        protected void LinkDeportes_Click(object sender, EventArgs e)
        {
            getEquipo();
            getEstructurasDeportivas();
            rpDepartamentos.DataSource = null;
            rpDepartamentos.DataBind();
            rpCiudadesPricipales.DataSource = null;
            rpCiudadesPricipales.DataBind();
            rpGastronomia.DataSource = null;
            rpGastronomia.DataBind();
            rpPersonajesPublicos.DataSource = null;
            rpPersonajesPublicos.DataBind();
            rpMusica.DataSource = null;
            rpMusica.DataBind();
            rpHistoria.DataSource = null;
            rpHistoria.DataBind();
            rpPersonajesHistoricos.DataSource = null;
            rpPersonajesHistoricos.DataBind();
            rpArquitectura.DataSource = null;
            rpArquitectura.DataBind();
            rpFlora.DataSource = null;
            rpFlora.DataBind();
            rpFauna.DataSource = null;
            rpFauna.DataBind();
            rpCulturas.DataSource = null;
            rpCulturas.DataBind();
        }

        protected void LinkHistoria_Click(object sender, EventArgs e)
        {
            getHistoria();
            getPersonajesHistoricos();
            rpDepartamentos.DataSource = null;
            rpDepartamentos.DataBind();
            rpCiudadesPricipales.DataSource = null;
            rpCiudadesPricipales.DataBind();
            rpGastronomia.DataSource = null;
            rpGastronomia.DataBind();
            rpPersonajesPublicos.DataSource = null;
            rpPersonajesPublicos.DataBind();
            rpMusica.DataSource = null;
            rpMusica.DataBind();
            rpDeportes.DataSource = null;
            rpDeportes.DataBind();
            rpEstructurasDeportivas.DataSource = null;
            rpEstructurasDeportivas.DataBind();
            rpArquitectura.DataSource = null;
            rpArquitectura.DataBind();
            rpFlora.DataSource = null;
            rpFlora.DataBind();
            rpFauna.DataSource = null;
            rpFauna.DataBind();
            rpCulturas.DataSource = null;
            rpCulturas.DataBind();

        }

        protected void LinkFlora_Click(object sender, EventArgs e)
        {
            getFlora();
            rpDepartamentos.DataSource = null;
            rpDepartamentos.DataBind();
            rpCiudadesPricipales.DataSource = null;
            rpCiudadesPricipales.DataBind();
            rpGastronomia.DataSource = null;
            rpGastronomia.DataBind();
            rpPersonajesPublicos.DataSource = null;
            rpPersonajesPublicos.DataBind();
            rpMusica.DataSource = null;
            rpMusica.DataBind();
            rpDeportes.DataSource = null;
            rpDeportes.DataBind();
            rpEstructurasDeportivas.DataSource = null;
            rpEstructurasDeportivas.DataBind();
            rpArquitectura.DataSource = null;
            rpArquitectura.DataBind();
            rpHistoria.DataSource = null;
            rpHistoria.DataBind();
            rpPersonajesHistoricos.DataSource = null;
            rpPersonajesHistoricos.DataBind();
            rpFauna.DataSource = null;
            rpFauna.DataBind();
            rpCulturas.DataSource = null;
            rpCulturas.DataBind();

        }

        protected void LinkFauna_Click(object sender, EventArgs e)
        {
            getFauna();
            rpDepartamentos.DataSource = null;
            rpDepartamentos.DataBind();
            rpCiudadesPricipales.DataSource = null;
            rpCiudadesPricipales.DataBind();
            rpGastronomia.DataSource = null;
            rpGastronomia.DataBind();
            rpPersonajesPublicos.DataSource = null;
            rpPersonajesPublicos.DataBind();
            rpMusica.DataSource = null;
            rpMusica.DataBind();
            rpDeportes.DataSource = null;
            rpDeportes.DataBind();
            rpEstructurasDeportivas.DataSource = null;
            rpEstructurasDeportivas.DataBind();
            rpArquitectura.DataSource = null;
            rpArquitectura.DataBind();
            rpHistoria.DataSource = null;
            rpHistoria.DataBind();
            rpPersonajesHistoricos.DataSource = null;
            rpPersonajesHistoricos.DataBind();
            rpFlora.DataSource = null;
            rpFlora.DataBind();
            rpCulturas.DataSource = null;
            rpCulturas.DataBind();
        }

        protected void linkCulturas_Click(object sender, EventArgs e)
        {
            getCulturas();
            rpDepartamentos.DataSource = null;
            rpDepartamentos.DataBind();
            rpCiudadesPricipales.DataSource = null;
            rpCiudadesPricipales.DataBind();
            rpGastronomia.DataSource = null;
            rpGastronomia.DataBind();
            rpPersonajesPublicos.DataSource = null;
            rpPersonajesPublicos.DataBind();
            rpMusica.DataSource = null;
            rpMusica.DataBind();
            rpDeportes.DataSource = null;
            rpDeportes.DataBind();
            rpEstructurasDeportivas.DataSource = null;
            rpEstructurasDeportivas.DataBind();
            rpArquitectura.DataSource = null;
            rpArquitectura.DataBind();
            rpHistoria.DataSource = null;
            rpHistoria.DataBind();
            rpPersonajesHistoricos.DataSource = null;
            rpPersonajesHistoricos.DataBind();
            rpFauna.DataSource = null;
            rpFauna.DataBind();
            rpFlora.DataSource = null;
            rpFlora.DataBind();
        }
    }
}