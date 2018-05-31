using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;

namespace ConoceAColombia.web.Views.Departamentos_Admin
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        void getDepartamentos()
        {
            try
            {
                Controllers.DepartamentosControllers obdepartamentosControllers = new Controllers.DepartamentosControllers();
                DataSet dsConsulta = obdepartamentosControllers.getConsultarPosiblesClientesController();
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
                getDepartamentos();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                String stMensaje = String.Empty;
                if (String.IsNullOrEmpty(txtCodigo.Text)) stMensaje += "Ingrese Codigo, ";
                if (String.IsNullOrEmpty(txtNombre.Text)) stMensaje += "Ingrese Nombre, ";
                if (String.IsNullOrEmpty(txtCapital.Text)) stMensaje += "Ingrese Capital, ";
                if (String.IsNullOrEmpty(txtGobernador.Text)) stMensaje += "Ingrese Gobernador, ";
                if (String.IsNullOrEmpty(txtMunicipios.Text)) stMensaje += "Ingrese Municipios, ";
                if (String.IsNullOrEmpty(txtFundacion.Text)) stMensaje += "Ingrese Fundacion, ";
                if (String.IsNullOrEmpty(txtGentilicio.Text)) stMensaje += "Ingrese Gentilicio, ";
                if (String.IsNullOrEmpty(txtPoblacion.Text)) stMensaje += "Ingrese Poblacion, ";
                if (String.IsNullOrEmpty(txtSuperficie.Text)) stMensaje += "Ingrese Superficie, ";
                if (String.IsNullOrEmpty(txtDemografia.Text)) stMensaje += "Ingrese Demografia, ";
                if (String.IsNullOrEmpty(txtLatitud.Text)) stMensaje += "Ingrese Latitud, ";
                if (String.IsNullOrEmpty(txtLongitud.Text)) stMensaje += "Ingrese Longitud, ";
                if (!String.IsNullOrEmpty(stMensaje)) throw new Exception(stMensaje.TrimEnd(','));

                logica.Models.clsDepartamentos obclsDepartamentos = new logica.Models.clsDepartamentos
                {
                    inCodigo = Convert.ToInt64(txtCodigo.Text),
                    stNombre = txtNombre.Text,
                    stCapital = txtCapital.Text,
                    stGobernador = txtGobernador.Text,
                    stMunicipios = txtMunicipios.Text,
                    stFundacion = txtFundacion.Text,
                    stGentilicio = txtGentilicio.Text,
                    stPoblacion = txtPoblacion.Text,
                    stSuperficie = txtSuperficie.Text,
                    stDemografia = txtDemografia.Text,
                    stLatitud = txtLatitud.Text,
                    stLongitud = txtLongitud.Text,
                    
            };
                
                Controllers.DepartamentosControllers obdepartamentosControllers = new Controllers.DepartamentosControllers();
                if (String.IsNullOrEmpty(lblOpcion.Text)) lblOpcion.Text = "1";

                ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> alert('Mensaje!,'"+ obdepartamentosControllers.setAdmintrarDepartamentosController(obclsDepartamentos,Convert.ToInt32(lblOpcion.Text))+ "')</Script>");
                lblOpcion.Text = txtCodigo.Text = txtNombre.Text = txtGobernador.Text = txtCapital.Text = txtMunicipios.Text = txtFundacion.Text = txtGentilicio.Text = txtPoblacion.Text = txtSuperficie.Text = txtLatitud.Text = txtDemografia.Text = txtLongitud.Text = String.Empty;
                getDepartamentos();
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
                    txtNombre.Text = String.IsNullOrEmpty(gvwDatos.Rows[inIndice].Cells[1].Text) ? String.Empty: gvwDatos.Rows[inIndice].Cells[1].Text;
                    txtCapital.Text = String.IsNullOrEmpty(gvwDatos.Rows[inIndice].Cells[2].Text) ? String.Empty : gvwDatos.Rows[inIndice].Cells[2].Text;
                    txtGobernador.Text = String.IsNullOrEmpty(gvwDatos.Rows[inIndice].Cells[3].Text) ? String.Empty : gvwDatos.Rows[inIndice].Cells[3].Text;
                    txtMunicipios.Text = String.IsNullOrEmpty(gvwDatos.Rows[inIndice].Cells[4].Text) ? String.Empty : gvwDatos.Rows[inIndice].Cells[4].Text;
                    txtFundacion.Text = String.IsNullOrEmpty(gvwDatos.Rows[inIndice].Cells[5].Text) ? String.Empty : gvwDatos.Rows[inIndice].Cells[5].Text;
                    txtGentilicio.Text = String.IsNullOrEmpty(gvwDatos.Rows[inIndice].Cells[6].Text) ? String.Empty : gvwDatos.Rows[inIndice].Cells[6].Text;
                    txtPoblacion.Text = String.IsNullOrEmpty(gvwDatos.Rows[inIndice].Cells[7].Text) ? String.Empty : gvwDatos.Rows[inIndice].Cells[7].Text;
                    txtSuperficie.Text = String.IsNullOrEmpty(gvwDatos.Rows[inIndice].Cells[8].Text) ? String.Empty : gvwDatos.Rows[inIndice].Cells[8].Text;
                    txtDemografia.Text = String.IsNullOrEmpty(gvwDatos.Rows[inIndice].Cells[9].Text) ? String.Empty : gvwDatos.Rows[inIndice].Cells[9].Text;
                    txtLatitud.Text = String.IsNullOrEmpty(gvwDatos.Rows[inIndice].Cells[10].Text) ? String.Empty : gvwDatos.Rows[inIndice].Cells[10].Text;
                    txtLongitud.Text = String.IsNullOrEmpty(gvwDatos.Rows[inIndice].Cells[11].Text) ? String.Empty : gvwDatos.Rows[inIndice].Cells[11].Text;
                    
                   
                }
                else if (e.CommandName.Equals("Eliminar"))
                {
                    lblOpcion.Text = "3";
                    logica.Models.clsDepartamentos obclsDepartamentos = new logica.Models.clsDepartamentos
                    {
                        inCodigo = Convert.ToInt32(((Label)gvwDatos.Rows[inIndice].FindControl("lblCodigo")).Text),
                        stNombre = String.Empty,
                        stCapital = String.Empty,
                        stGobernador = String.Empty,
                        stMunicipios = String.Empty,
                        stFundacion = String.Empty,
                        stGentilicio = String.Empty,
                        stPoblacion = String.Empty,
                        stSuperficie = String.Empty,
                        stDemografia = String.Empty,
                        stLatitud = String.Empty,
                        stLongitud = String.Empty,
                    };

                    Controllers.DepartamentosControllers obdepartamentosControllers = new Controllers.DepartamentosControllers();
                    
                    ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('MENSAJE!', '" + obdepartamentosControllers.setAdmintrarDepartamentosController(obclsDepartamentos, Convert.ToInt32(lblOpcion.Text)) + "!', 'success')</Script>");

                    lblOpcion.Text = txtCodigo.Text= txtNombre.Text= txtGobernador.Text = txtCapital.Text= txtMunicipios.Text= txtFundacion.Text= txtGentilicio.Text= txtPoblacion.Text= txtSuperficie.Text=txtLatitud.Text=txtDemografia.Text=txtLongitud.Text= String.Empty;
                    getDepartamentos();

                }

            }catch(Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('ERROR!', '" + ex.Message + "!', 'ERROR')</Script>");
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            lblOpcion.Text = txtCodigo.Text = txtNombre.Text = txtGobernador.Text = txtCapital.Text = txtMunicipios.Text = txtFundacion.Text = txtGentilicio.Text = txtPoblacion.Text = txtSuperficie.Text = txtLatitud.Text = txtDemografia.Text = txtLongitud.Text = String.Empty;
        }
    }
}