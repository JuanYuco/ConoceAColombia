using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConoceAColombia.web.Views.FloraAdmin
{
    public partial class FloraAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getFlora();
                logica.BL.clsFlora obclsFlora = new logica.BL.clsFlora();
                Controllers.FloraControllers obFloraControllers = new Controllers.FloraControllers();
                List<logica.Models.clsTipoFlora> consultaTipoFlora = obFloraControllers.getTipoFlora();
                obclsFlora.CargarControlTipoFlora(ref ddlTipoFlora, consultaTipoFlora, "lgCodigo", "stDescripcion", "-1", "<<Todos>>");
            }

        }
        public void getFlora()
        {
            try
            {
                Controllers.FloraControllers obFloraControllers = new Controllers.FloraControllers();
                List<logica.Models.clsFlora> ltsclsFlora = obFloraControllers.getFlora();

                if (ltsclsFlora.Count > 0) gvwDatos.DataSource = ltsclsFlora;
                else gvwDatos.DataSource = null;

                gvwDatos.DataBind();
            }catch(Exception ew)
            {
                throw ew;
            }
        }

        

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                String stMensaje = String.Empty;
                if (String.IsNullOrEmpty(txtCodigo.Text)) stMensaje += "Ingrese Codigo, ";
                if (String.IsNullOrEmpty(txtNomCientifico.Text)) stMensaje += "Ingrese Nombre Cientifico, ";
                if (String.IsNullOrEmpty(txtNomComun.Text)) stMensaje += "Ingrese Nombre, ";
                if (String.IsNullOrEmpty(txtPeridoFloracion.Text)) stMensaje += "Ingrese Perido de Floración, ";
                if (String.IsNullOrEmpty(txtAbundancia.Text)) stMensaje += "Ingrese abundancia, ";
                if (String.IsNullOrEmpty(txtDescripcion.Text)) stMensaje += "Ingrese Descripción, ";
                if (!String.IsNullOrEmpty(stMensaje)) throw new Exception(stMensaje.TrimEnd(','));

                logica.Models.clsFlora clsFlora = new logica.Models.clsFlora
                {
                    lgCodigo = Convert.ToInt64(txtCodigo.Text),
                    stNombreCientifico = txtNomCientifico.Text,
                    stNombre = txtNomComun.Text,
                    stDescripcion = txtDescripcion.Text,
                    stPeriodoFloracion = txtPeridoFloracion.Text,
                    stAbundancia = txtAbundancia.Text,
                    obclsTipoFlora = new logica.Models.clsTipoFlora
                    {
                        lgCodigo = Convert.ToInt64(ddlTipoFlora.SelectedValue)
                    }

                };

                Controllers.FloraControllers obFloraControllers = new Controllers.FloraControllers();
                if (String.IsNullOrEmpty(lblOpcion.Text)) lblOpcion.Text = "1";

                if (lblOpcion.Text.Equals("1"))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('Mensaje!,'" + obFloraControllers.insertFlora(clsFlora) + "!','success')</Script>");
                    lblOpcion.Text = txtCodigo.Text = txtDescripcion.Text = txtNomCientifico.Text = txtNomComun.Text = txtPeridoFloracion.Text
                         = txtAbundancia.Text =  String.Empty;
                    getFlora();
                }
                else if (lblOpcion.Text.Equals("2"))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('Mensaje!,'" + obFloraControllers.updateFlora(clsFlora) + "!','success')</Script>");
                    lblOpcion.Text = txtCodigo.Text = txtDescripcion.Text = txtNomCientifico.Text = txtNomComun.Text = txtPeridoFloracion.Text
                         = txtAbundancia.Text =  String.Empty;
                    getFlora();
                }


            }
            catch (Exception ex) { ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> Swal('MENSAJE!', '" + ex.Message + "!','success')</Script>"); }

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            lblOpcion.Text = txtCodigo.Text = txtDescripcion.Text = txtNomCientifico.Text = txtNomComun.Text = txtPeridoFloracion.Text
                         = txtAbundancia.Text =  String.Empty;
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
                    txtNomCientifico.Text = String.IsNullOrEmpty(gvwDatos.Rows[inIndice].Cells[1].Text) ? String.Empty : gvwDatos.Rows[inIndice].Cells[1].Text;
                    txtNomComun.Text = String.IsNullOrEmpty(gvwDatos.Rows[inIndice].Cells[2].Text) ? String.Empty : gvwDatos.Rows[inIndice].Cells[2].Text;
                    txtDescripcion.Text = String.IsNullOrEmpty(gvwDatos.Rows[inIndice].Cells[3].Text) ? String.Empty : gvwDatos.Rows[inIndice].Cells[3].Text;
                    txtAbundancia.Text = String.IsNullOrEmpty(gvwDatos.Rows[inIndice].Cells[4].Text) ? String.Empty : gvwDatos.Rows[inIndice].Cells[4].Text;
                    txtPeridoFloracion.Text = String.IsNullOrEmpty(gvwDatos.Rows[inIndice].Cells[5].Text) ? String.Empty : gvwDatos.Rows[inIndice].Cells[5].Text;
                    
                }
                else if (e.CommandName.Equals("Eliminar"))
                {
                    logica.Models.clsFlora obclsFlora = new logica.Models.clsFlora
                    {
                        lgCodigo = Convert.ToInt64(((Label)gvwDatos.Rows[inIndice].FindControl("lblCodigo")).Text),
                        stNombreCientifico = String.Empty,
                        stNombre = String.Empty,
                        stAbundancia = String.Empty,
                        stPeriodoFloracion = String.Empty,
                        stDescripcion = String.Empty,
                        obclsTipoFlora = new logica.Models.clsTipoFlora
                        {
                            lgCodigo = 0
                        }



                    };

                    Controllers.FloraControllers obFloraControllers = new Controllers.FloraControllers();

                    ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('MENSAJE!', '" + obFloraControllers.deleteFlora(obclsFlora) + "!','Success')</Script>");

                    lblOpcion.Text = txtCodigo.Text = txtDescripcion.Text = txtNomCientifico.Text = txtNomComun.Text = txtPeridoFloracion.Text
                         = txtAbundancia.Text =  String.Empty;
                    getFlora();

                }

            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('ERROR!', '" + ex.Message + "!', 'ERROR')</Script>");
            }
        }
    }
}