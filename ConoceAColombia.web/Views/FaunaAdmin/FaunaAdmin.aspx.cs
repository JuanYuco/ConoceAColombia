using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConoceAColombia.web.Views.FaunaAdmin
{
    public partial class FaunaAdmin : System.Web.UI.Page
    {
        void getFauna()
        {
            try
            {
                Controllers.FaunaControllers obFaunaControllers = new Controllers.FaunaControllers();
                gvwDatos.DataSource = obFaunaControllers.getFauna();
                gvwDatos.DataBind();
            }
            catch (Exception ex) { ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('ERROR!', '" + ex.Message + "!', 'error')</Script>"); }

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getFauna();
                logica.BL.clsFauna obclsFauna = new logica.BL.clsFauna();
                Controllers.FaunaControllers obFaunaControllers = new Controllers.FaunaControllers();
                List<logica.Models.clsTipoFauna> consultaTipoFauna = obFaunaControllers.getTipoFauna();
                obclsFauna.CargarControlTipoFauna(ref ddlTipoFauna, consultaTipoFauna, "lgCodigo", "stDescripcion", "-1", "<<Todos>>");
            }

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                String stMensaje = String.Empty;
                if (String.IsNullOrEmpty(txtCodigo.Text)) stMensaje += "Ingrese Codigo, ";
                if (String.IsNullOrEmpty(txtNombre.Text)) stMensaje += "Ingrese Nombre, ";
                if (String.IsNullOrEmpty(txtDescripcion.Text)) stMensaje += "Ingrese Descripción, ";
                if (!String.IsNullOrEmpty(stMensaje)) throw new Exception(stMensaje.TrimEnd(','));

                logica.Models.clsFauna clsFauna = new logica.Models.clsFauna
                {
                    lgCodigo = Convert.ToInt64(txtCodigo.Text),
                    stNombre = txtNombre.Text,
                    stDescripcion = txtDescripcion.Text,
                    obclsTipoFauna = new logica.Models.clsTipoFauna
                    {
                        lgCodigo = Convert.ToInt64(ddlTipoFauna.SelectedValue)
                    }

                };

                Controllers.FaunaControllers obFaunaControllers = new Controllers.FaunaControllers();
                if (String.IsNullOrEmpty(lblOpcion.Text)) lblOpcion.Text = "1";

                if (lblOpcion.Text.Equals("1"))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('Mensaje!,'" + obFaunaControllers.insertarFauna(clsFauna) + "!','success')</Script>");
                    lblOpcion.Text = txtCodigo.Text = txtDescripcion.Text = txtNombre.Text = String.Empty;
                    getFauna();
                }
                else if (lblOpcion.Text.Equals("2"))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('Mensaje!,'" + obFaunaControllers.updateFauna(clsFauna) + "!','success')</Script>");
                    lblOpcion.Text = txtCodigo.Text = txtDescripcion.Text = txtNombre.Text = String.Empty;
                    getFauna();
                }


            }
            catch (Exception ex) { ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> Swal('MENSAJE!', '" + ex.Message + "!','success')</Script>"); }

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            lblOpcion.Text = txtCodigo.Text = txtDescripcion.Text = txtNombre.Text = String.Empty;
        }

        protected void gvwDatos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int inIndice = Convert.ToInt16(e.CommandArgument);
                if (e.CommandName.Equals("Editar"))
                {
                    lblOpcion.Text = "2";
                    txtCodigo.Text = ((Label)gvwDatos.Rows[inIndice].FindControl("lblCodigo")).Text;
                    txtNombre.Text = String.IsNullOrEmpty(gvwDatos.Rows[inIndice].Cells[1].Text) ? String.Empty : gvwDatos.Rows[inIndice].Cells[1].Text;
                    txtDescripcion.Text = String.IsNullOrEmpty(gvwDatos.Rows[inIndice].Cells[2].Text) ? String.Empty : gvwDatos.Rows[inIndice].Cells[2].Text;
                }
                else if (e.CommandName.Equals("Eliminar"))
                {
                    logica.Models.clsFauna obclsFauna = new logica.Models.clsFauna
                    {
                        lgCodigo = Convert.ToInt32(((Label)gvwDatos.Rows[inIndice].FindControl("lblCodigo")).Text),
                        stNombre = String.Empty,
                        stDescripcion = String.Empty



                    };

                    Controllers.FaunaControllers obFaunaControllers = new Controllers.FaunaControllers();

                    ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('MENSAJE!', '" + obFaunaControllers.deleteFauna(obclsFauna) + "!','Success')</Script>");

                    lblOpcion.Text = txtCodigo.Text = txtDescripcion.Text = txtNombre.Text = String.Empty;
                    getFauna();

                }

            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('ERROR!', '" + ex.Message + "!', 'ERROR')</Script>");
            }
        }
    }
}