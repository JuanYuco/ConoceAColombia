using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace ConoceAColombia.web.Views.Gastronomia_Admin
{
    public partial class GastronomiaAdmin : System.Web.UI.Page
    {
        void getGastronomia()
        {
            try
            {
                Controllers.GastronomiaControllers obGastronomiaControllers = new Controllers.GastronomiaControllers();
                DataSet dsConsulta = obGastronomiaControllers.getConsultarGastronomiaController();
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

                logica.BL.clsGastronomia clsGastronomia = new logica.BL.clsGastronomia();
                DataSet dsConsulta = clsGastronomia.getDepartamentoDatos(-1);
                DataSet dsConsultaDos = clsGastronomia.getGastronomiaTipoDatos(-1);

                clsGastronomia.CargarControl(ref ddlDepartamentos, dsConsulta, "depaCodigo", "depaNombre", "-1", "<<Todos>>");
                clsGastronomia.CargarControl(ref ddlTipoGastronomia, dsConsultaDos, "tigaCodigo", "tigaDescripcion", "-1", "<<Todos>>");
                getGastronomia();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                String stMensaje = String.Empty;
                if (String.IsNullOrEmpty(txtCodigo.Text)) stMensaje += "Ingrese Codigo, ";
                if (String.IsNullOrEmpty(txtNombre.Text)) stMensaje += "Ingrese Nombre, ";
                if (String.IsNullOrEmpty(txtDescripcion.Text)) stMensaje += "Ingrese Descripcion, ";
                if (String.IsNullOrEmpty(txtCiudad.Text)) stMensaje += "Ingrese Ciudad, ";
                if (String.IsNullOrEmpty(txtLatitud.Text)) stMensaje += "Ingrese Latitud, ";
                if (String.IsNullOrEmpty(txtLongitud.Text)) stMensaje += "Ingrese Longitud, ";

                if (!String.IsNullOrEmpty(stMensaje)) throw new Exception(stMensaje.TrimEnd(','));

                logica.Models.clsGastronomia clsGastronomia = new logica.Models.clsGastronomia
                {
                    lgCodigo = Convert.ToInt64(txtCodigo.Text),
                    stNombre = txtNombre.Text,
                    stDescripcion = txtDescripcion.Text,
                    stCiudad = txtCiudad.Text,
                    stLatitud = txtLatitud.Text,
                    stLongitud = txtLongitud.Text,
                    clsDepartamentos = new logica.Models.clsDepartamentos { inCodigo = Convert.ToInt64(ddlDepartamentos.SelectedValue) },
                    clsTipodeGastronomia = new logica.Models.clsTipodeGastronomia { lgCodigo = Convert.ToInt64(ddlTipoGastronomia.SelectedValue) }
                };

                Controllers.GastronomiaControllers obGastronomiaControllers = new Controllers.GastronomiaControllers();
                if (String.IsNullOrEmpty(lblOpcion.Text)) lblOpcion.Text = "1";

                ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('Mensaje!,'" + obGastronomiaControllers.setAdministrarGastronomiaController(clsGastronomia, Convert.ToInt32(lblOpcion.Text)) + "')</Script>");
                lblOpcion.Text = txtCodigo.Text = txtNombre.Text =txtDescripcion.Text= txtCiudad.Text = txtLatitud.Text = txtLongitud.Text = String.Empty;
                getGastronomia();
            }
            catch (Exception ex) { ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> Swal('" + ex.Message + "')</Script>"); }

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {

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
                    txtCiudad.Text = String.IsNullOrEmpty(gvwDatos.Rows[inIndice].Cells[3].Text) ? String.Empty : gvwDatos.Rows[inIndice].Cells[3].Text;
                    txtLatitud.Text = String.IsNullOrEmpty(gvwDatos.Rows[inIndice].Cells[4].Text) ? String.Empty : gvwDatos.Rows[inIndice].Cells[4].Text;
                    txtLongitud.Text = String.IsNullOrEmpty(gvwDatos.Rows[inIndice].Cells[5].Text) ? String.Empty : gvwDatos.Rows[inIndice].Cells[5].Text;



                }
                else if (e.CommandName.Equals("Eliminar"))
                {
                    lblOpcion.Text = "3";
                    logica.Models.clsGastronomia obclsGastronomia = new logica.Models.clsGastronomia
                    {
                        lgCodigo = Convert.ToInt32(((Label)gvwDatos.Rows[inIndice].FindControl("lblCodigo")).Text),
                        clsDepartamentos = new logica.Models.clsDepartamentos { inCodigo = 0 },
                        stNombre = String.Empty,
                        stCiudad = String.Empty,
                        stLatitud = String.Empty,
                        stLongitud = String.Empty,
                        stDescripcion = String.Empty,
                        clsTipodeGastronomia = new logica.Models.clsTipodeGastronomia { lgCodigo = 0 }


                    };

                    Controllers.GastronomiaControllers obGastronomiaControllers = new Controllers.GastronomiaControllers();

                    ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('MENSAJE!', '" + obGastronomiaControllers.setAdministrarGastronomiaController(obclsGastronomia, Convert.ToInt32(lblOpcion.Text)) + "!', 'success')</Script>");

                    lblOpcion.Text = txtCodigo.Text = txtNombre.Text = txtCiudad.Text = txtLatitud.Text = txtLongitud.Text = String.Empty;
                    getGastronomia();

                }

            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('ERROR!', '" + ex.Message + "!', 'ERROR')</Script>");
            }

        }
    }
}