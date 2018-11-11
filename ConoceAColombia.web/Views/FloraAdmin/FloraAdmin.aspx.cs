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
                List<logica.Models.clsDepartamentos> consultaDepartamentos = obFloraControllers.getDepartamentos();
                obclsFlora.CargarControlDepartamento(ref ddlDepartamento, consultaDepartamentos, "inCodigo", "stNombre", "-1", "<<Todos>>");
            }

        }
        public void getFlora()
        {
            try
            {
                Controllers.FloraControllers obFloraControllers = new Controllers.FloraControllers();
                List<logica.Models.clsFlora> ltsclsFlora = obFloraControllers.getFloraController();

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
                if (String.IsNullOrEmpty(txtLatitud.Text)) stMensaje += "Ingrese Latitud, ";
                if (String.IsNullOrEmpty(txtLongitud.Text)) stMensaje += "Ingrese Codigo, ";
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
                    stLatitud = txtLatitud.Text,
                    stLongitud = txtLongitud.Text,
                    obclsDepartamentos = new logica.Models.clsDepartamentos
                    {
                        inCodigo = Convert.ToInt64(ddlDepartamento.SelectedValue)
                    }

                };

                Controllers.FloraControllers obFloraControllers = new Controllers.FloraControllers();
                if (String.IsNullOrEmpty(lblOpcion.Text)) lblOpcion.Text = "1";

                if (lblOpcion.Text.Equals("1"))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('Mensaje!,'" + obFloraControllers.addFlora(clsFlora) + "!','success')</Script>");
                    lblOpcion.Text = txtCodigo.Text = txtDescripcion.Text = txtNomCientifico.Text = txtNomComun.Text = txtPeridoFloracion.Text
                         = txtAbundancia.Text = txtLatitud.Text= txtLongitud.Text =  String.Empty;
                    getFlora();
                }
                else if (lblOpcion.Text.Equals("2"))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('Mensaje!,'" + obFloraControllers.updateFlora(clsFlora) + "!','success')</Script>");
                    lblOpcion.Text = txtCodigo.Text = txtDescripcion.Text = txtNomCientifico.Text = txtNomComun.Text = txtPeridoFloracion.Text
                         = txtAbundancia.Text = txtLatitud.Text = txtLongitud.Text = String.Empty;
                    getFlora();
                }


            }
            catch (Exception ex) { ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> Swal('MENSAJE!', '" + ex.Message + "!','success')</Script>"); }

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            lblOpcion.Text = txtCodigo.Text = txtDescripcion.Text = txtNomCientifico.Text = txtNomComun.Text = txtPeridoFloracion.Text
                         = txtAbundancia.Text = txtLatitud.Text = txtLongitud.Text = String.Empty;
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
                    txtLatitud.Text = String.IsNullOrEmpty(gvwDatos.Rows[inIndice].Cells[6].Text) ? String.Empty : gvwDatos.Rows[inIndice].Cells[6].Text;
                    txtLongitud.Text = String.IsNullOrEmpty(gvwDatos.Rows[inIndice].Cells[7].Text) ? String.Empty : gvwDatos.Rows[inIndice].Cells[7].Text;
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
                        stLatitud = String.Empty,
                        stLongitud = String.Empty,
                        stDescripcion = String.Empty,
                        obclsDepartamentos = new logica.Models.clsDepartamentos
                        {
                            inCodigo = 0
                        }



                    };

                    Controllers.FloraControllers obFloraControllers = new Controllers.FloraControllers();

                    ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('MENSAJE!', '" + obFloraControllers.deleteFlora(obclsFlora) + "!','Success')</Script>");

                    lblOpcion.Text = txtCodigo.Text = txtDescripcion.Text = txtNomCientifico.Text = txtNomComun.Text = txtPeridoFloracion.Text
                         = txtAbundancia.Text = txtLatitud.Text = txtLongitud.Text = String.Empty;
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