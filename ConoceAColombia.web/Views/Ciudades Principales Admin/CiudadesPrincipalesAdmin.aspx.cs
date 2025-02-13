﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

namespace ConoceAColombia.web.Views.Ciudades_Principales_Admin
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        void getCiudadesPrincipales()
        {
            try
            {
                Controllers.CiudadesPrincipalesControllers obCiudadesPrincipalesController = new Controllers.CiudadesPrincipalesControllers();
                DataSet dsConsulta = obCiudadesPrincipalesController.getConsultarCiudadesPrincipalesController();
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

                logica.BL.clsCiudadesPrincipales clsCiudadesPrincipales = new logica.BL.clsCiudadesPrincipales();
                DataSet dsConsulta = clsCiudadesPrincipales.getDepartamentoDatos(-1);

                clsCiudadesPrincipales.CargarControl(ref ddlDepartamento, dsConsulta, "depaCodigo", "depaNombre", "-1", "<<Todos>>");
                getCiudadesPrincipales();
            }

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                String stMensaje = String.Empty;
                if (String.IsNullOrEmpty(txtCodigo.Text)) stMensaje += "Ingrese Codigo, ";
                if (String.IsNullOrEmpty(txtNombre.Text)) stMensaje += "Ingrese Nombre, ";
                if (String.IsNullOrEmpty(txtReseña.Text)) stMensaje += "Ingrese Reseña, ";
                if (fuImagen.HasFile == false) stMensaje += "Agrega una imagen, ";
                if (String.IsNullOrEmpty(txtLatitud.Text)) stMensaje += "Ingrese Latitud, ";
                if (String.IsNullOrEmpty(txtLongitud.Text)) stMensaje += "Ingrese Longitud, ";

                if (!String.IsNullOrEmpty(stMensaje)) throw new Exception(stMensaje.TrimEnd(','));

                if (!Path.GetExtension(fuImagen.FileName).Equals(".jpg"))
                    throw new Exception("Solo se admiten formatos .JPG");

                String stRuta = Server.MapPath(@"~\tmp\") + fuImagen.FileName;
                fuImagen.PostedFile.SaveAs(stRuta);
                String stRutaDestino = Server.MapPath(@"~\Images\CiudadesPrincipales\") + txtCodigo.Text + "Ciudades" + Path.GetExtension(fuImagen.FileName);
                if (File.Exists(stRutaDestino))
                {
                    File.SetAttributes(stRutaDestino, FileAttributes.Normal);
                    File.Delete(stRutaDestino);
                }

                File.Copy(stRuta, stRutaDestino);
                File.SetAttributes(stRuta, FileAttributes.Normal);
                File.Delete(stRuta);

                logica.Models.clsCiudadesPrincipales clsCiudadesPrincipales = new logica.Models.clsCiudadesPrincipales
                {
                    lgCodigo = Convert.ToInt64(txtCodigo.Text),
                    stNombre = txtNombre.Text,
                    stReseña = txtReseña.Text,
                    stImagen = stRutaDestino,
                    stLatitud = txtLatitud.Text,
                    stLongitud= txtLongitud.Text,
                    clsDepartamentos = new logica.Models.clsDepartamentos {inCodigo=Convert.ToInt64(ddlDepartamento.SelectedValue)}
                };

                Controllers.CiudadesPrincipalesControllers obtipodeCiudadesPrincipalesControllers = new Controllers.CiudadesPrincipalesControllers();
                if (String.IsNullOrEmpty(lblOpcion.Text)) lblOpcion.Text = "1";

                ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('Mensaje!,'" + obtipodeCiudadesPrincipalesControllers.setAdministarCiudadesPrincipalesController(clsCiudadesPrincipales, Convert.ToInt32(lblOpcion.Text)) + "')</Script>");
                lblOpcion.Text = txtCodigo.Text = txtNombre.Text =  txtReseña.Text= txtLatitud.Text=txtLongitud.Text=String.Empty;
                getCiudadesPrincipales();
            }
            catch (Exception ex) { ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> Swal('" + ex.Message + "')</Script>"); }

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {

            lblOpcion.Text = txtCodigo.Text = txtNombre.Text = txtReseña.Text = txtLatitud.Text = txtLongitud.Text = String.Empty;
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
                    txtReseña.Text = String.IsNullOrEmpty(gvwDatos.Rows[inIndice].Cells[2].Text) ? String.Empty : gvwDatos.Rows[inIndice].Cells[2].Text;
                    txtLatitud.Text = String.IsNullOrEmpty(gvwDatos.Rows[inIndice].Cells[3].Text) ? String.Empty : gvwDatos.Rows[inIndice].Cells[3].Text;
                    txtLongitud.Text = String.IsNullOrEmpty(gvwDatos.Rows[inIndice].Cells[4].Text) ? String.Empty : gvwDatos.Rows[inIndice].Cells[4].Text;
                    


                }
                else if (e.CommandName.Equals("Eliminar"))
                {
                    lblOpcion.Text = "3";
                    logica.Models.clsCiudadesPrincipales obclsCiudadesPrincipales = new logica.Models.clsCiudadesPrincipales
                    {
                        lgCodigo = Convert.ToInt32(((Label)gvwDatos.Rows[inIndice].FindControl("lblCodigo")).Text),
                        stNombre = String.Empty,
                        stReseña = String.Empty,
                        stLatitud = String.Empty,
                        stLongitud = String.Empty,
                        stImagen = String.Empty,
                        clsDepartamentos = new logica.Models.clsDepartamentos { inCodigo = 0}
                        
                    };

                    Controllers.CiudadesPrincipalesControllers obCiudadesPrincipalesControllers = new Controllers.CiudadesPrincipalesControllers();

                    ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('MENSAJE!', '" + obCiudadesPrincipalesControllers.setAdministarCiudadesPrincipalesController(obclsCiudadesPrincipales, Convert.ToInt32(lblOpcion.Text)) + "!', 'success')</Script>");

                    lblOpcion.Text = txtCodigo.Text = txtNombre.Text = txtReseña.Text = txtLatitud.Text = txtLongitud.Text= String.Empty;
                    getCiudadesPrincipales();

                }

            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('ERROR!', '" + ex.Message + "!', 'ERROR')</Script>");
            }

        }
    }
}