using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace ConoceAColombia.web.Views.PersonajesxHistoriaAdmin
{
    public partial class PersonajexHistoriaAdmin : System.Web.UI.Page
    {
        void getPersonajesxHistoria()
        {
            try
            {
                Controllers.PersoanesxHistoriaControllers obPersonajexHistoriaControllers = new Controllers.PersoanesxHistoriaControllers();
                gvwDatos.DataSource = obPersonajexHistoriaControllers.getConsultarPersonajesxHistoriaController();
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

                getPersonajesxHistoria();
                logica.BL.clsPersonajesxHistoria clsPersonajexHistoria = new logica.BL.clsPersonajesxHistoria();
                DataSet dsConsulta = clsPersonajexHistoria.getPersonajesHistoricosDatos(-1);
                DataSet dsConsultaDos = clsPersonajexHistoria.getHistoriaDatos(-1);

                clsPersonajexHistoria.CargarControl(ref ddlPersonajeHistorico, dsConsulta, "pehiCodigo", "pehiNombre", "-1", "<<Todos>>");
                clsPersonajexHistoria.CargarControl(ref ddlHistoriaPersonaje, dsConsultaDos, "histCodigo", "histNombre", "-1", "<<Todos>>");
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                logica.Models.clsPersonajesxHistoria clsPersonajexHistoria = new logica.Models.clsPersonajesxHistoria
                {
                    obclsPersonajesHistoricos = new logica.Models.clsPersonajesHistoricos { lgCodigo = Convert.ToInt64(ddlPersonajeHistorico.SelectedValue) },
                    obclsHistoria = new logica.Models.clsHistoria { lgCodigo = Convert.ToInt64(ddlHistoriaPersonaje.SelectedValue) }
                };

                Controllers.PersoanesxHistoriaControllers obPersonajesxHistoriaControllers = new Controllers.PersoanesxHistoriaControllers();
                if (String.IsNullOrEmpty(lblOpcion.Text)) lblOpcion.Text = "1";

                ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('Mensaje!,'" + obPersonajesxHistoriaControllers.setAdministarPersonajexHistoriaController(clsPersonajexHistoria, Convert.ToInt32(lblOpcion.Text)) + "')</Script>");
                getPersonajesxHistoria();
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
                if (e.CommandName.Equals("Eliminar"))
                {
                    lblOpcion.Text = "3";
                    logica.Models.clsPersonajesxHistoria obclsPersonajesxHistoria = new logica.Models.clsPersonajesxHistoria
                    {

                        obclsPersonajesHistoricos = new logica.Models.clsPersonajesHistoricos { lgCodigo = Convert.ToInt64(((Label)gvwDatos.Rows[inIndice].FindControl("lblCodigo")).Text) },
                        obclsHistoria = new logica.Models.clsHistoria { lgCodigo = Convert.ToInt64(gvwDatos.Rows[inIndice].Cells[2].Text) }


                    };

                    Controllers.PersoanesxHistoriaControllers obPersonajesxHistoriaControllers = new Controllers.PersoanesxHistoriaControllers();

                    ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('MENSAJE!', '" + obPersonajesxHistoriaControllers.setAdministarPersonajexHistoriaController(obclsPersonajesxHistoria, Convert.ToInt32(lblOpcion.Text)) + "!', 'success')</Script>");


                    getPersonajesxHistoria();
                }
                }catch (Exception ew) { 
            
                throw ew;
            }




        }

    }
}
