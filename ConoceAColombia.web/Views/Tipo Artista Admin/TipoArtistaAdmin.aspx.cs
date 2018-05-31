using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


namespace ConoceAColombia.web.Views.Genero_Admin
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        void getTipodeArtista()
        {
            try
            {
                Controllers.TipodeArtistaControllers tipodeArtistaControllers = new Controllers.TipodeArtistaControllers();
                DataSet dsConsulta = tipodeArtistaControllers.getConsultarTipodeArtistaController();
                if (dsConsulta.Tables[0].Rows.Count > 0)
                {
                    gvwDatos.DataSource = dsConsulta;
                }
                else
                {
                    gvwDatos.DataSource = null;
                }
                gvwDatos.DataBind();
            }
            catch (Exception ex) { ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('ERROR!', '" + ex.Message + "!', 'error')</Script>"); }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string stLogin = string.Empty;
                string stPassword = string.Empty;
                if (Request.QueryString["stLogin"] != null && Request.QueryString["stPassword"] != null)
                    stLogin = Request.QueryString["stLogin"].ToString();


                if (Session["SessionEmailAdministrador"] != null)
                    stLogin = Session["SessionEmailAdministrador"].ToString();
                else
                    Response.Redirect("../LoginAdministrador/LoginAdministrador.aspx");
                getTipodeArtista();
            }

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                String stMensaje = String.Empty;
                if (String.IsNullOrEmpty(txtCodigo.Text)) stMensaje += "Ingrese Codigo, ";
                if (String.IsNullOrEmpty(txtGenero.Text)) stMensaje += "Ingrese Genero ";

                if (!String.IsNullOrEmpty(stMensaje)) throw new Exception(stMensaje.TrimEnd(','));

                logica.Models.clsTipodeArtista clsTipodeArtista = new logica.Models.clsTipodeArtista
                {
                    lgCodigo = Convert.ToInt64(txtCodigo.Text),
                    stGenero = txtGenero.Text,


                };
                
                Controllers.TipodeArtistaControllers obtipodeArtistaControllers = new Controllers.TipodeArtistaControllers();
                if (String.IsNullOrEmpty(lblOpcion.Text)) lblOpcion.Text = "1";

                ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> alert('Mensaje!,'" + obtipodeArtistaControllers.setAdmintrarTipodeArtistaController(clsTipodeArtista, Convert.ToInt32(lblOpcion.Text)) + "')</Script>");
                lblOpcion.Text = txtCodigo.Text = txtGenero.Text = String.Empty;
                getTipodeArtista();
            }
            catch (Exception ex) { ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> alert('" + ex.Message + "')</Script>"); }
        }

        protected void gvwDatos_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            try
            {
                int inIndice = Convert.ToInt16(e.CommandArgument);
                if (e.CommandName.Equals("Editar"))
                {
                    lblOpcion.Text = "2";
                    txtCodigo.Text = ((Label)gvwDatos.Rows[inIndice].FindControl("lblCodigo")).Text;
                    txtGenero.Text = String.IsNullOrEmpty(gvwDatos.Rows[inIndice].Cells[1].Text) ? String.Empty : gvwDatos.Rows[inIndice].Cells[1].Text;



                }
                else if (e.CommandName.Equals("Eliminar"))
                {
                    lblOpcion.Text = "3";
                    logica.Models.clsTipodeArtista obclsTipodeArtista = new logica.Models.clsTipodeArtista
                    {
                        lgCodigo = Convert.ToInt32(((Label)gvwDatos.Rows[inIndice].FindControl("lblCodigo")).Text),
                        stGenero = String.Empty,

                    };

                    Controllers.TipodeArtistaControllers obTipodeArtistaControllers = new Controllers.TipodeArtistaControllers();

                    ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('MENSAJE!', '" + obTipodeArtistaControllers.setAdmintrarTipodeArtistaController(obclsTipodeArtista, Convert.ToInt32(lblOpcion.Text)) + "!', 'success')</Script>");

                    lblOpcion.Text = txtCodigo.Text = txtGenero.Text = String.Empty;
                    getTipodeArtista();

                }

            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('ERROR!', '" + ex.Message + "!', 'ERROR')</Script>");
            }
        }



        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            lblOpcion.Text = txtCodigo.Text = txtGenero.Text = String.Empty;
        }
    }
}