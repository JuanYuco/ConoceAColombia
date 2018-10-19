using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConoceAColombia.web.Views.TipoJuego
{
    public partial class TipoJuego : System.Web.UI.Page
    {
        void getTipoJuego()
        {
            try
            {
                Controllers.TipoJuegoControllers obTipoJuegoControllers = new Controllers.TipoJuegoControllers();
                gvwDatos.DataSource = obTipoJuegoControllers.getTipoJuego();
                gvwDatos.DataBind();
            }
            catch (Exception ex) { ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('ERROR!', '" + ex.Message + "!', 'error')</Script>"); }

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getTipoJuego();
            }

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                String stMensaje = String.Empty;
                if (String.IsNullOrEmpty(txtCodigo.Text)) stMensaje += "Ingrese Codigo, ";
                if (String.IsNullOrEmpty(txtDescripcion.Text)) stMensaje += "Ingrese Descripción, ";
                if (!String.IsNullOrEmpty(stMensaje)) throw new Exception(stMensaje.TrimEnd(','));

                logica.Models.clsTipoJuego clsTipoJuego = new logica.Models.clsTipoJuego
                {
                    lgCodigo = Convert.ToInt64(txtCodigo.Text),
                    stDescripcion = txtDescripcion.Text

                };

                Controllers.TipoJuegoControllers obTipoJuegoControllers = new Controllers.TipoJuegoControllers();
                if (String.IsNullOrEmpty(lblOpcion.Text)) lblOpcion.Text = "1";

                if (lblOpcion.Text.Equals("1"))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('Mensaje!,'" + obTipoJuegoControllers.insertarTipoJuego(clsTipoJuego) + "!','success')</Script>");
                    lblOpcion.Text = txtCodigo.Text = txtDescripcion.Text = String.Empty;
                    getTipoJuego();
                }
                else if (lblOpcion.Text.Equals("2"))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('Mensaje!,'" + obTipoJuegoControllers.updateTipoJuego(clsTipoJuego) + "!','success')</Script>");
                    lblOpcion.Text = txtCodigo.Text = txtDescripcion.Text = String.Empty;
                    getTipoJuego();
                }


            }
            catch (Exception ex) { ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> Swal('MENSAJE!', '" + ex.Message + "!','success')</Script>"); }

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            lblOpcion.Text = txtCodigo.Text = txtDescripcion.Text = String.Empty;
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
                    txtDescripcion.Text = String.IsNullOrEmpty(gvwDatos.Rows[inIndice].Cells[1].Text) ? String.Empty : gvwDatos.Rows[inIndice].Cells[1].Text;




                }
                else if (e.CommandName.Equals("Eliminar"))
                {
                    logica.Models.clsTipoJuego obclsTipoJuego = new logica.Models.clsTipoJuego
                    {
                        lgCodigo = Convert.ToInt32(((Label)gvwDatos.Rows[inIndice].FindControl("lblCodigo")).Text),
                        stDescripcion = String.Empty



                    };

                    Controllers.TipoJuegoControllers obTipoJuegoControllers = new Controllers.TipoJuegoControllers();

                    ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('MENSAJE!', '" + obTipoJuegoControllers.deleteTipoJuego(obclsTipoJuego) + "!','Success')</Script>");

                    lblOpcion.Text = txtCodigo.Text = txtDescripcion.Text = String.Empty;
                    getTipoJuego();

                }

            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('ERROR!', '" + ex.Message + "!', 'ERROR')</Script>");
            }
        }
    }
}