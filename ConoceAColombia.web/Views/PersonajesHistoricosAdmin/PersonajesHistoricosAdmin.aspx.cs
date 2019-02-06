using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

namespace ConoceAColombia.web.Views.PersonajesHistoricosAdmin
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        void getPersonajesHistoricos()
        {
            try
            {
                Controllers.PersonajesHistoricosControllers obPersonajesHistoricosControllers = new Controllers.PersonajesHistoricosControllers();
                DataSet dsConsulta = obPersonajesHistoricosControllers.getConsultarPersonajesHistoricosController();
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

                getPersonajesHistoricos();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                String stMensaje = String.Empty;
                if (String.IsNullOrEmpty(txtCodigo.Text)) stMensaje += "Ingrese Codigo, ";
                if (String.IsNullOrEmpty(txtNombre.Text)) stMensaje += "Ingrese Nombre, ";
                if (String.IsNullOrEmpty(txtNacimiento.Text)) stMensaje += "Ingrese Fecha de Nacimiento, ";
                if (String.IsNullOrEmpty(txtDescripcion.Text)) stMensaje += "Ingrese Descripcion, ";
                if (String.IsNullOrEmpty(txtCiudad.Text)) stMensaje += "Ingrese Ciudad, ";
                if (fuImagen.HasFile == false) stMensaje += "Agrega una imagen, ";
                if (String.IsNullOrEmpty(txtLatitud.Text)) stMensaje += "Ingrese Latitud, ";
                if (String.IsNullOrEmpty(txtLongitud.Text)) stMensaje += "Ingrese Longitud, ";

                if (!String.IsNullOrEmpty(stMensaje)) throw new Exception(stMensaje.TrimEnd(','));


                if (!Path.GetExtension(fuImagen.FileName).Equals(".jpg"))
                    throw new Exception("Solo se admiten formatos .JPG");

                String stRuta = Server.MapPath(@"~\tmp\") + fuImagen.FileName;
                fuImagen.PostedFile.SaveAs(stRuta);
                String stRutaDestino = Server.MapPath(@"~\Images\PersonajesHistoricos\") + txtCodigo.Text + "PersonajesHistoricos" + Path.GetExtension(fuImagen.FileName);
                if (File.Exists(stRutaDestino))
                {
                    File.SetAttributes(stRutaDestino, FileAttributes.Normal);
                    File.Delete(stRutaDestino);
                }

                File.Copy(stRuta, stRutaDestino);
                File.SetAttributes(stRuta, FileAttributes.Normal);
                File.Delete(stRuta);

                logica.Models.clsPersonajesHistoricos clsPersonajesHistoricos = new logica.Models.clsPersonajesHistoricos
                {
                    lgCodigo = Convert.ToInt64(txtCodigo.Text),
                    stDescripcion = txtDescripcion.Text,
                    stFechaNacimiento = txtNacimiento.Text,
                    stNombre = txtNombre.Text,
                    stCiudad = txtCiudad.Text,
                    stLatitud = txtLatitud.Text,
                    stLongitud = txtLongitud.Text,
                    stImagen = stRutaDestino
                };

                Controllers.PersonajesHistoricosControllers obPersonajesHistoricosControllers = new Controllers.PersonajesHistoricosControllers();
                if (String.IsNullOrEmpty(lblOpcion.Text)) lblOpcion.Text = "1";

                ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('Mensaje!,'" + obPersonajesHistoricosControllers.setAdministarPersonajesHistoricosController(clsPersonajesHistoricos, Convert.ToInt32(lblOpcion.Text)) + "')</Script>");
                lblOpcion.Text = txtCodigo.Text= txtNacimiento.Text= txtDescripcion.Text = txtNombre.Text = txtCiudad.Text = txtLatitud.Text = txtLongitud.Text = String.Empty;
                getPersonajesHistoricos();
            }
            catch (Exception ex) { ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> Swal('" + ex.Message + "')</Script>"); }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            lblOpcion.Text = txtCodigo.Text = txtNacimiento.Text = txtDescripcion.Text = txtNombre.Text = txtCiudad.Text = txtLatitud.Text = txtLongitud.Text = String.Empty;
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
                    txtNacimiento.Text = String.IsNullOrEmpty(gvwDatos.Rows[inIndice].Cells[3].Text) ? String.Empty : gvwDatos.Rows[inIndice].Cells[3].Text;
                    txtCiudad.Text = String.IsNullOrEmpty(gvwDatos.Rows[inIndice].Cells[4].Text) ? String.Empty : gvwDatos.Rows[inIndice].Cells[4].Text;
                    txtDescripcion.Text = String.IsNullOrEmpty(gvwDatos.Rows[inIndice].Cells[5].Text) ? String.Empty : gvwDatos.Rows[inIndice].Cells[5].Text;
                    txtLatitud.Text = String.IsNullOrEmpty(gvwDatos.Rows[inIndice].Cells[6].Text) ? String.Empty : gvwDatos.Rows[inIndice].Cells[6].Text;
                    txtLongitud.Text = String.IsNullOrEmpty(gvwDatos.Rows[inIndice].Cells[7].Text) ? String.Empty : gvwDatos.Rows[inIndice].Cells[7].Text;



                }
                else if (e.CommandName.Equals("Eliminar"))
                {
                    lblOpcion.Text = "3";
                    logica.Models.clsPersonajesHistoricos obclsPersonajesHistoricos = new logica.Models.clsPersonajesHistoricos
                    {
                        lgCodigo = Convert.ToInt32(((Label)gvwDatos.Rows[inIndice].FindControl("lblCodigo")).Text),
                        stNombre = String.Empty,
                        stFechaNacimiento = String.Empty,
                        stDescripcion=String.Empty,
                        stCiudad = String.Empty,
                        stLatitud = String.Empty,
                        stLongitud = String.Empty,
                        stImagen = String.Empty
                    };

                    Controllers.PersonajesHistoricosControllers obPersonajesHistoricosControllers = new Controllers.PersonajesHistoricosControllers();

                    ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('MENSAJE!', '" + obPersonajesHistoricosControllers.setAdministarPersonajesHistoricosController(obclsPersonajesHistoricos, Convert.ToInt32(lblOpcion.Text)) + "!', 'success')</Script>");

                    lblOpcion.Text = txtCodigo.Text = txtNacimiento.Text = txtDescripcion.Text = txtNombre.Text = txtCiudad.Text = txtLatitud.Text = txtLongitud.Text = String.Empty;
                    getPersonajesHistoricos();

                }

            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('ERROR!', '" + ex.Message + "!', 'ERROR')</Script>");
            }
        }
    }
}