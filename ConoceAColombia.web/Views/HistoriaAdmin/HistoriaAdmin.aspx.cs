using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace ConoceAColombia.web.Views.HistoriaAdmin
{
    public partial class HistoriaAdmin : System.Web.UI.Page
    {

        void getHistoria()
        {
            try
            {
                Controllers.HistoriaControllers obHistoriaControllers = new Controllers.HistoriaControllers();
                DataSet dsConsulta = obHistoriaControllers.getConsultarHistoriaController();
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

                getHistoria();
                logica.BL.clsHistoria clsHistoria = new logica.BL.clsHistoria();
                DataSet dsConsulta = clsHistoria.getDepartamentoDatos(-1);
                DataSet dsConsultaDos = clsHistoria.getHistoriaTipoDatos(-1);

                clsHistoria.CargarControl(ref dllDepartamento, dsConsulta, "depaCodigo", "depaNombre", "-1", "<<Todos>>");
                clsHistoria.CargarControl(ref ddlTipoHistoria, dsConsultaDos, "pehiCodigo", "pehiDescripcion", "-1", "<<Todos>>");
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                String stMensaje = String.Empty;
                if (String.IsNullOrEmpty(txtCodigo.Text)) stMensaje += "Ingrese Codigo, ";
                if (String.IsNullOrEmpty(txtNombre.Text)) stMensaje += "Ingrese Nombre, ";
                if (String.IsNullOrEmpty(txtDescripción.Text)) stMensaje += "Ingrese Decripcion, ";
                if (String.IsNullOrEmpty(txtFechaInicio.Text)) stMensaje += "Ingrese Fecha Inicio, ";
                if (String.IsNullOrEmpty(txtFechaFin.Text)) stMensaje += "Ingrese Fecha Fin, ";
                if (String.IsNullOrEmpty(txtLatitud.Text)) stMensaje += "Ingrese Latitud, ";
                if (String.IsNullOrEmpty(txtLongitud.Text)) stMensaje += "Ingrese Longitud, ";

                if (!String.IsNullOrEmpty(stMensaje)) throw new Exception(stMensaje.TrimEnd(','));

                logica.Models.clsHistoria clsHistoria = new logica.Models.clsHistoria
                {
                    lgCodigo = Convert.ToInt64(txtCodigo.Text),
                    stNombre = txtNombre.Text,
                    stDescripcion = txtDescripción.Text,
                    obclsTipoHisotoria = new logica.Models.clsTipoHistoria { lgCodigo = Convert.ToInt64(ddlTipoHistoria.SelectedValue) },
                    stFechaInicio = txtFechaInicio.Text,
                    stFechaFin = txtFechaFin.Text,
                    obclsDepartamentos = new logica.Models.clsDepartamentos { inCodigo = Convert.ToInt64(dllDepartamento.SelectedValue) },
                    stLatitud = txtLatitud.Text,
                    stLongitud = txtLongitud.Text,
                    
                };

                Controllers.HistoriaControllers obHistoriaControllers = new Controllers.HistoriaControllers();
                if (String.IsNullOrEmpty(lblOpcion.Text)) lblOpcion.Text = "1";

                ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('Mensaje!,'" + obHistoriaControllers.setAdministarHistoriaController(clsHistoria, Convert.ToInt32(lblOpcion.Text)) + "')</Script>");
                lblOpcion.Text = txtCodigo.Text = txtNombre.Text = txtDescripción.Text=txtFechaInicio.Text=txtFechaFin.Text = txtLatitud.Text = txtLongitud.Text = String.Empty;
                getHistoria();
            }
            catch (Exception ex) { ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> Swal('" + ex.Message + "')</Script>"); }

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            lblOpcion.Text = txtCodigo.Text = txtNombre.Text = txtDescripción.Text = txtFechaInicio.Text = txtFechaFin.Text = txtLatitud.Text = txtLongitud.Text = String.Empty;
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
                    txtDescripción.Text = String.IsNullOrEmpty(gvwDatos.Rows[inIndice].Cells[2].Text) ? String.Empty : gvwDatos.Rows[inIndice].Cells[2].Text;
                    txtFechaInicio.Text = String.IsNullOrEmpty(gvwDatos.Rows[inIndice].Cells[4].Text) ? String.Empty : gvwDatos.Rows[inIndice].Cells[4].Text;
                    txtFechaFin.Text = String.IsNullOrEmpty(gvwDatos.Rows[inIndice].Cells[5].Text) ? String.Empty : gvwDatos.Rows[inIndice].Cells[5].Text;
                    txtLatitud.Text = String.IsNullOrEmpty(gvwDatos.Rows[inIndice].Cells[6].Text) ? String.Empty : gvwDatos.Rows[inIndice].Cells[6].Text;
                    txtLongitud.Text = String.IsNullOrEmpty(gvwDatos.Rows[inIndice].Cells[7].Text) ? String.Empty : gvwDatos.Rows[inIndice].Cells[7].Text;



                }
                else if (e.CommandName.Equals("Eliminar"))
                {
                    lblOpcion.Text = "3";
                    logica.Models.clsHistoria obclsHistoria = new logica.Models.clsHistoria
                    {
                        lgCodigo = Convert.ToInt32(((Label)gvwDatos.Rows[inIndice].FindControl("lblCodigo")).Text),
                        stNombre = String.Empty,
                        stDescripcion = String.Empty,
                        obclsTipoHisotoria = new logica.Models.clsTipoHistoria { lgCodigo = 0 },
                        stFechaInicio = String.Empty,
                        stFechaFin = String.Empty,
                        obclsDepartamentos = new logica.Models.clsDepartamentos { inCodigo = 0 },
                        stLatitud = String.Empty,
                        stLongitud = String.Empty
                    };

                    Controllers.HistoriaControllers obHistoriaControllers = new Controllers.HistoriaControllers();

                    ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('MENSAJE!', '" + obHistoriaControllers.setAdministarHistoriaController(obclsHistoria, Convert.ToInt32(lblOpcion.Text)) + "!', 'success')</Script>");

                    lblOpcion.Text = txtCodigo.Text = txtNombre.Text = txtDescripción.Text = txtFechaInicio.Text = txtFechaFin.Text = txtLatitud.Text = txtLongitud.Text = String.Empty;
                    getHistoria();

                }

            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('ERROR!', '" + ex.Message + "!', 'ERROR')</Script>");
            }
        }
    }
}