using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace ConoceAColombia.web.Views.Arquitectura_Admin
{
    public partial class Arquitectura_Admin : System.Web.UI.Page
    {
        void getArquitectura()
        {
            try
            {
                Controllers.ArquitecturaControllers obArquitecturaControllers = new Controllers.ArquitecturaControllers();
                DataSet dsConsulta = obArquitecturaControllers.getConsultarArquitecturaController();
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
                getArquitectura();
                logica.BL.clsArquitectura clsArquitectura = new logica.BL.clsArquitectura();
                DataSet dsConsulta = clsArquitectura.getDepartamentoDatos(-1);
                DataSet dsConsultaDos = clsArquitectura.getArquitecturaTipoDatos(-1);

                clsArquitectura.CargarControl(ref ddlDepartamento, dsConsulta, "depaCodigo", "depaNombre", "-1", "<<Todos>>");
                clsArquitectura.CargarControl(ref ddlTipoArquitectura, dsConsultaDos, "tiarCodigo", "tiarDescripcion", "-1", "<<Todos>>");
            }

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                String stMensaje = String.Empty;
                if (String.IsNullOrEmpty(txtCodigo.Text)) stMensaje += "Ingrese Codigo, ";
                if (String.IsNullOrEmpty(txtNombre.Text)) stMensaje += "Ingrese Nombre, ";
                if (String.IsNullOrEmpty(txtCiudad.Text)) stMensaje += "Ingrese Ciudad, ";
                if (String.IsNullOrEmpty(txtLatitud.Text)) stMensaje += "Ingrese Latitud, ";
                if (String.IsNullOrEmpty(txtLongitud.Text)) stMensaje += "Ingrese Longitud, ";

                if (!String.IsNullOrEmpty(stMensaje)) throw new Exception(stMensaje.TrimEnd(','));

                logica.Models.clsArquitectura clsArquitectura = new logica.Models.clsArquitectura
                {
                    lgCodigo = Convert.ToInt64(txtCodigo.Text),
                    clsDepartamentos = new logica.Models.clsDepartamentos { inCodigo = Convert.ToInt64(ddlDepartamento.SelectedValue) },
                    stNombre = txtNombre.Text,
                    stCiudad = txtCiudad.Text,
                    stLatitud = txtLatitud.Text,
                    stLongitud = txtLongitud.Text,
                    clsTipodeArquitectura = new logica.Models.clsTipodeArquitectura { lgCodigo = Convert.ToInt64(ddlTipoArquitectura.SelectedValue)}
                };

                Controllers.ArquitecturaControllers obArquitecturaControllers = new Controllers.ArquitecturaControllers();
                if (String.IsNullOrEmpty(lblOpcion.Text)) lblOpcion.Text = "1";

                ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('Mensaje!,'" + obArquitecturaControllers.setAdministarArquitecturaController(clsArquitectura, Convert.ToInt32(lblOpcion.Text)) + "')</Script>");
                lblOpcion.Text = txtCodigo.Text = txtNombre.Text = txtCiudad.Text = txtLatitud.Text = txtLongitud.Text = String.Empty;
                getArquitectura();
            }
            catch (Exception ex) { ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> Swal('" + ex.Message + "')</Script>"); }

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            lblOpcion.Text = txtCodigo.Text = txtNombre.Text = txtCiudad.Text = txtLatitud.Text = txtLongitud.Text = String.Empty;
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
                    txtNombre.Text = String.IsNullOrEmpty(gvwDatos.Rows[inIndice].Cells[2].Text) ? String.Empty : gvwDatos.Rows[inIndice].Cells[2].Text;
                    txtCiudad.Text = String.IsNullOrEmpty(gvwDatos.Rows[inIndice].Cells[3].Text) ? String.Empty : gvwDatos.Rows[inIndice].Cells[3].Text;
                    txtLatitud.Text = String.IsNullOrEmpty(gvwDatos.Rows[inIndice].Cells[4].Text) ? String.Empty : gvwDatos.Rows[inIndice].Cells[4].Text;
                    txtLongitud.Text = String.IsNullOrEmpty(gvwDatos.Rows[inIndice].Cells[5].Text) ? String.Empty : gvwDatos.Rows[inIndice].Cells[5].Text;



                }
                else if (e.CommandName.Equals("Eliminar"))
                {
                    lblOpcion.Text = "3";
                    logica.Models.clsArquitectura obclsArquitectura = new logica.Models.clsArquitectura
                    {
                        lgCodigo = Convert.ToInt32(((Label)gvwDatos.Rows[inIndice].FindControl("lblCodigo")).Text),
                        clsDepartamentos = new logica.Models.clsDepartamentos { inCodigo = 0 },
                        stNombre = String.Empty,
                        stCiudad = String.Empty,
                        stLatitud = String.Empty,
                        stLongitud = String.Empty,
                        clsTipodeArquitectura = new logica.Models.clsTipodeArquitectura { lgCodigo=0}
                        

                    };

                    Controllers.ArquitecturaControllers obArquitecturaControllers = new Controllers.ArquitecturaControllers();

                    ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('MENSAJE!', '" + obArquitecturaControllers.setAdministarArquitecturaController(obclsArquitectura, Convert.ToInt32(lblOpcion.Text)) + "!', 'success')</Script>");

                    lblOpcion.Text = txtCodigo.Text = txtNombre.Text = txtCiudad.Text = txtLatitud.Text = txtLongitud.Text = String.Empty;
                    getArquitectura();

                }

            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('ERROR!', '" + ex.Message + "!', 'ERROR')</Script>");
            }

        }
    }
}