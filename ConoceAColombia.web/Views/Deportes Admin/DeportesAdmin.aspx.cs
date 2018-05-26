using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace ConoceAColombia.web.Views.Deportes_Admin
{
    public partial class DeportesAdmin : System.Web.UI.Page
    
    {

        void getDeportes()
        {
            try
            {
                Controllers.DeportesControllers obDeportesControllers = new Controllers.DeportesControllers();
                gvwDatos.DataSource = obDeportesControllers.getDeportesControllers();
                gvwDatos.DataBind();
            }
            catch (Exception ex) { ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('ERROR!', '" + ex.Message + "!', 'error')</Script>"); }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getDeportes();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                String stMensaje = String.Empty;
                if (String.IsNullOrEmpty(txtCodigo.Text)) stMensaje += "Ingrese Codigo, ";
                if (String.IsNullOrEmpty(txtNombre.Text)) stMensaje += "Ingrese Nombre, ";
                if (!String.IsNullOrEmpty(stMensaje)) throw new Exception(stMensaje.TrimEnd(','));

                logica.Models.clsDeportes clsDeportes = new logica.Models.clsDeportes
                {
                    lgCodigo = Convert.ToInt64(txtCodigo.Text),
                    stNombre = txtNombre.Text
                    
                };

                Controllers.DeportesControllers obDeportesControllers = new Controllers.DeportesControllers();
                if (String.IsNullOrEmpty(lblOpcion.Text)) lblOpcion.Text = "1";

                if (lblOpcion.Text.Equals("1"))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('Mensaje!,'" + obDeportesControllers.insertarDeportes(clsDeportes) + "!','success')</Script>");
                    lblOpcion.Text = txtCodigo.Text = txtNombre.Text = String.Empty;
                    getDeportes();
                }
                else if (lblOpcion.Text.Equals("2"))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('Mensaje!,'" + obDeportesControllers.updateDeportes(clsDeportes) + "!','success')</Script>");
                    lblOpcion.Text = txtCodigo.Text = txtNombre.Text = String.Empty;
                    getDeportes();
                }

                
            }
            catch (Exception ex) { ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> Swal('MENSAJE!', '" + ex.Message + "!','success')</Script>"); }

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            lblOpcion.Text = txtCodigo.Text = txtNombre.Text = String.Empty;
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
                   



                }
                else if (e.CommandName.Equals("Eliminar"))
                {
                    logica.Models.clsDeportes obclsDeportes = new logica.Models.clsDeportes
                    {
                        lgCodigo = Convert.ToInt32(((Label)gvwDatos.Rows[inIndice].FindControl("lblCodigo")).Text),
                        stNombre = String.Empty
                        


                    };

                    Controllers.DeportesControllers obDeportesControllers = new Controllers.DeportesControllers();

                    ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('MENSAJE!', '" + obDeportesControllers.deleteDeportes(obclsDeportes) + "!','Success')</Script>");

                    lblOpcion.Text = txtCodigo.Text = txtNombre.Text  = String.Empty;
                    getDeportes();

                }

            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('ERROR!', '" + ex.Message + "!', 'ERROR')</Script>");
            }
        }
    }
}