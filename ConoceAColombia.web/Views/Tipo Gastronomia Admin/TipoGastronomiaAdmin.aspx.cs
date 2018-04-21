using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace ConoceAColombia.web.Views.Tipo_Gastronomia_Admin
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        void getTipodeGastronomia()
        {
            try
            {
                Controllers.TipodeGastronomiaControllers tipodeGastronomiaControllers = new Controllers.TipodeGastronomiaControllers();
                DataSet dsConsulta = tipodeGastronomiaControllers.getConsultarTipodeGastronomiaController();
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
                getTipodeGastronomia();
            }

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                String stMensaje = String.Empty;
                if (String.IsNullOrEmpty(txtCodigo.Text)) stMensaje += "Ingrese Codigo, ";
                if (String.IsNullOrEmpty(txtDescripcion.Text)) stMensaje += "Ingrese Descripcion";

                if (!String.IsNullOrEmpty(stMensaje)) throw new Exception(stMensaje.TrimEnd(','));

                logica.Models.clsTipodeGastronomia clsTipodeGastronomia = new logica.Models.clsTipodeGastronomia
                {
                    lgCodigo = Convert.ToInt64(txtCodigo.Text),
                    stDescripcion = txtDescripcion.Text,


                };
                
                Controllers.TipodeGastronomiaControllers obtipodeGastronomiaControllers = new Controllers.TipodeGastronomiaControllers();
                 if (String.IsNullOrEmpty(lblOpcion.Text)) lblOpcion.Text = "1";

                ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> alert('Mensaje!,'" + obtipodeGastronomiaControllers.setAdministrarTipodeGastronomiaController(clsTipodeGastronomia, Convert.ToInt32(lblOpcion.Text)) + "')</Script>");
                lblOpcion.Text = txtCodigo.Text = txtDescripcion.Text = String.Empty;
                getTipodeGastronomia();
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
                    txtDescripcion.Text = String.IsNullOrEmpty(gvwDatos.Rows[inIndice].Cells[1].Text) ? String.Empty : gvwDatos.Rows[inIndice].Cells[1].Text;



                }
                else if (e.CommandName.Equals("Eliminar"))
                {
                    lblOpcion.Text = "3";
                    logica.Models.clsTipodeGastronomia obclsTipodeGastronomia = new logica.Models.clsTipodeGastronomia
                    {
                        lgCodigo = Convert.ToInt32(((Label)gvwDatos.Rows[inIndice].FindControl("lblCodigo")).Text),
                        stDescripcion = String.Empty,

                    };

                    Controllers.TipodeGastronomiaControllers obTipodeGastronomiaControllers = new Controllers.TipodeGastronomiaControllers();

                    ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('MENSAJE!', '" + obTipodeGastronomiaControllers.setAdministrarTipodeGastronomiaController(obclsTipodeGastronomia, Convert.ToInt32(lblOpcion.Text)) + "!', 'success')</Script>");

                    lblOpcion.Text = txtCodigo.Text = txtDescripcion.Text = String.Empty;
                    getTipodeGastronomia();

                }

            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('ERROR!', '" + ex.Message + "!', 'ERROR')</Script>");
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            lblOpcion.Text = txtCodigo.Text = txtDescripcion.Text = String.Empty;
        }
    }
}