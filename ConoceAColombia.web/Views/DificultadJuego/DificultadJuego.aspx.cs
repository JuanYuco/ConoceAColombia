using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConoceAColombia.web.Views.DificultadJuego
{
    public partial class DificultadJuego : System.Web.UI.Page
    {
        void getDificultadJuego()
        {
            try
            {
                Controllers.DificultadJuegoControllers obTipoJuegoControllers = new Controllers.DificultadJuegoControllers();
                gvwDatos.DataSource = obTipoJuegoControllers.getDificultadJuego();
                gvwDatos.DataBind();
            }
            catch (Exception ex) { ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('ERROR!', '" + ex.Message + "!', 'error')</Script>"); }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getDificultadJuego();
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

                logica.Models.clsDicultadJuego clsDificultadJuego = new logica.Models.clsDicultadJuego
                {
                    lgCodigo = Convert.ToInt64(txtCodigo.Text),
                    stDescripcion = txtDescripcion.Text

                };

                Controllers.DificultadJuegoControllers obDificultadJuegoControllers = new Controllers.DificultadJuegoControllers();
                if (String.IsNullOrEmpty(lblOpcion.Text)) lblOpcion.Text = "1";

                if (lblOpcion.Text.Equals("1"))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('Mensaje!,'" + obDificultadJuegoControllers.insertarDificultadJuego(clsDificultadJuego) + "!','success')</Script>");
                    lblOpcion.Text = txtCodigo.Text = txtDescripcion.Text = String.Empty;
                    getDificultadJuego();
                }
                else if (lblOpcion.Text.Equals("2"))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('Mensaje!,'" + obDificultadJuegoControllers.updateDificultadJuego(clsDificultadJuego) + "!','success')</Script>");
                    lblOpcion.Text = txtCodigo.Text = txtDescripcion.Text = String.Empty;
                    getDificultadJuego();
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
                    logica.Models.clsDicultadJuego obclsDificultadJuego = new logica.Models.clsDicultadJuego
                    {
                        lgCodigo = Convert.ToInt32(((Label)gvwDatos.Rows[inIndice].FindControl("lblCodigo")).Text),
                        stDescripcion = String.Empty



                    };

                    Controllers.DificultadJuegoControllers obDificultadJuegoControllers = new Controllers.DificultadJuegoControllers();

                    ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('MENSAJE!', '" + obDificultadJuegoControllers.deleteDificultadJuego(obclsDificultadJuego) + "!','Success')</Script>");

                    lblOpcion.Text = txtCodigo.Text = txtDescripcion.Text = String.Empty;
                    getDificultadJuego();

                }

            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('ERROR!', '" + ex.Message + "!', 'ERROR')</Script>");
            }
        }
    }
}