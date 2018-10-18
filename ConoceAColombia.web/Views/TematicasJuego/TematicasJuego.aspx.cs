using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConoceAColombia.web.Views.TematicasJuego
{
    public partial class TematicasJuego : System.Web.UI.Page
    {
        void getTematicasJuego()
        {
            try
            {
                Controllers.TematicasControllers obTematicasControllers = new Controllers.TematicasControllers();
                gvwDatos.DataSource = obTematicasControllers.getTematicasJuego();
                gvwDatos.DataBind();
            }
            catch (Exception ex) { ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('ERROR!', '" + ex.Message + "!', 'error')</Script>"); }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getTematicasJuego();
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

                logica.Models.clsTematicasJuego clsTematicasJuego = new logica.Models.clsTematicasJuego
                {
                    lgCodigo = Convert.ToInt64(txtCodigo.Text),
                    stDescripcion = txtDescripcion.Text

                };

                Controllers.TematicasControllers obTematicasControllers = new Controllers.TematicasControllers();
                if (String.IsNullOrEmpty(lblOpcion.Text)) lblOpcion.Text = "1";

                if (lblOpcion.Text.Equals("1"))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('Mensaje!,'" + obTematicasControllers.insertarTematicasJuego(clsTematicasJuego) + "!','success')</Script>");
                    lblOpcion.Text = txtCodigo.Text = txtDescripcion.Text = String.Empty;
                    getTematicasJuego();
                }
                else if (lblOpcion.Text.Equals("2"))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('Mensaje!,'" + obTematicasControllers.updateTematicasJuego(clsTematicasJuego) + "!','success')</Script>");
                    lblOpcion.Text = txtCodigo.Text = txtDescripcion.Text = String.Empty;
                    getTematicasJuego();
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
                    logica.Models.clsTematicasJuego obclsTematicasJuego = new logica.Models.clsTematicasJuego
                    {
                        lgCodigo = Convert.ToInt32(((Label)gvwDatos.Rows[inIndice].FindControl("lblCodigo")).Text),
                        stDescripcion = String.Empty



                    };

                    Controllers.TematicasControllers obTematicasControllers = new Controllers.TematicasControllers();

                    ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('MENSAJE!', '" + obTematicasControllers.deleteTematicasJuego(obclsTematicasJuego) + "!','Success')</Script>");

                    lblOpcion.Text = txtCodigo.Text = txtDescripcion.Text = String.Empty;
                    getTematicasJuego();

                }

            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('ERROR!', '" + ex.Message + "!', 'ERROR')</Script>");
            }
        }
    }
}