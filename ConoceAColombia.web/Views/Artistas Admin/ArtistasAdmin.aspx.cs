﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

namespace ConoceAColombia.web.Views.Artistas_Admin
{
    public partial class ArtistasAdmin : System.Web.UI.Page
    {
        void getArtistas()
        {
            try
            {
                Controllers.ArtistasControllers obCiudadesArtistasControllers = new Controllers.ArtistasControllers();
                DataSet dsConsulta = obCiudadesArtistasControllers.getConsultarArtistasController();
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


                logica.BL.clsArtistas clsArtistas = new logica.BL.clsArtistas();
                DataSet dsConsulta = clsArtistas.getDepartamentoDatos(-1);
                DataSet dsConsultaDos = clsArtistas.getArtistaTipoDatos(-1);

                clsArtistas.CargarControl(ref ddlDepartamento, dsConsulta, "depaCodigo", "depaNombre", "-1", "<<Todos>>");
                clsArtistas.CargarControl(ref ddlTipoArtista, dsConsultaDos, "tiatCodigo", "tiatGenero", "-1", "<<Todos>>");
                getArtistas();
            }


        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                String stMensaje = String.Empty;
                if (String.IsNullOrEmpty(txtCodigo.Text)) stMensaje += "Ingrese Codigo, ";
                if (String.IsNullOrEmpty(txtNombre.Text)) stMensaje += "Ingrese Nombre, ";
                if (String.IsNullOrEmpty(txtDescripcion.Text)) stMensaje += "Ingrese Descripción, ";
                if (String.IsNullOrEmpty(txtFechaNacimiento.Text)) stMensaje += "Ingrese Fecha de Nacimiento, ";
                if (String.IsNullOrEmpty(txtCiudad.Text)) stMensaje += "Ingrese Ciudad, ";
                if (fuImagen.HasFile == false) stMensaje += "Agrega una imagen, ";
                if (String.IsNullOrEmpty(txtLatitud.Text)) stMensaje += "Ingrese Latitud, ";
                if (String.IsNullOrEmpty(txtLongitud.Text)) stMensaje += "Ingrese Longitud, ";

                if (!String.IsNullOrEmpty(stMensaje)) throw new Exception(stMensaje.TrimEnd(','));

                if (!Path.GetExtension(fuImagen.FileName).Equals(".jpg"))
                    throw new Exception("Solo se admiten formatos .JPG");

                String stRuta = Server.MapPath(@"~\tmp\") + fuImagen.FileName;
                fuImagen.PostedFile.SaveAs(stRuta);
                String stRutaDestino = Server.MapPath(@"~\Images\Artistas\") + txtCodigo.Text + "Artistas" + Path.GetExtension(fuImagen.FileName);
                if (File.Exists(stRutaDestino))
                {
                    File.SetAttributes(stRutaDestino, FileAttributes.Normal);
                    File.Delete(stRutaDestino);
                }

                File.Copy(stRuta, stRutaDestino);
                File.SetAttributes(stRuta, FileAttributes.Normal);
                File.Delete(stRuta);

                logica.Models.clsArtistas clsArtistas = new logica.Models.clsArtistas
                {
                    lgCodigo = Convert.ToInt64(txtCodigo.Text),
                    clsDepartamentos = new logica.Models.clsDepartamentos { inCodigo = Convert.ToInt64(ddlDepartamento.SelectedValue) },
                    stNombre = txtNombre.Text,
                    stDescripcion = txtDescripcion.Text,
                    stFechaNacimiento = txtFechaNacimiento.Text,
                    stCiudad = txtCiudad.Text,
                    stLatitud = txtLatitud.Text,
                    stLongitud = txtLongitud.Text,
                    stImagen = stRutaDestino,
                    clsTipodeArtista = new logica.Models.clsTipodeArtista { lgCodigo = Convert.ToInt64(ddlTipoArtista.SelectedValue)}
                };

                Controllers.ArtistasControllers obArtistasControllers = new Controllers.ArtistasControllers();
                if (String.IsNullOrEmpty(lblOpcion.Text)) lblOpcion.Text = "1";

                ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('Mensaje!,'" + obArtistasControllers.setAdministarArtistasController(clsArtistas, Convert.ToInt32(lblOpcion.Text)) + "')</Script>");
                lblOpcion.Text = txtCodigo.Text = txtNombre.Text = txtDescripcion.Text = txtFechaNacimiento.Text= txtCiudad.Text = txtLatitud.Text = txtLongitud.Text = String.Empty;
                getArtistas();
            }
            catch (Exception ex) { ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> Swal('" + ex.Message + "')</Script>"); }

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            lblOpcion.Text = txtCodigo.Text = txtNombre.Text = txtDescripcion.Text = txtFechaNacimiento.Text = txtCiudad.Text = txtLatitud.Text = txtLongitud.Text = String.Empty;
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
                    txtFechaNacimiento.Text = String.IsNullOrEmpty(gvwDatos.Rows[inIndice].Cells[3].Text) ? String.Empty : gvwDatos.Rows[inIndice].Cells[3].Text;
                    txtCiudad.Text = String.IsNullOrEmpty(gvwDatos.Rows[inIndice].Cells[5].Text) ? String.Empty : gvwDatos.Rows[inIndice].Cells[5].Text;
                    txtLatitud.Text = String.IsNullOrEmpty(gvwDatos.Rows[inIndice].Cells[6].Text) ? String.Empty : gvwDatos.Rows[inIndice].Cells[6].Text;
                    txtLongitud.Text = String.IsNullOrEmpty(gvwDatos.Rows[inIndice].Cells[7].Text) ? String.Empty : gvwDatos.Rows[inIndice].Cells[7].Text;



                }
                else if (e.CommandName.Equals("Eliminar"))
                {
                    lblOpcion.Text = "3";
                    logica.Models.clsArtistas obclsArtistas = new logica.Models.clsArtistas
                    {
                        lgCodigo = Convert.ToInt32(((Label)gvwDatos.Rows[inIndice].FindControl("lblCodigo")).Text),
                        clsDepartamentos = new logica.Models.clsDepartamentos { inCodigo = 0 },
                        stNombre = String.Empty,
                        stDescripcion = String.Empty,
                        stFechaNacimiento = String.Empty,
                        stCiudad = String.Empty,
                        stLatitud = String.Empty,
                        stLongitud = String.Empty,
                        stImagen = String.Empty,
                        clsTipodeArtista = new logica.Models.clsTipodeArtista { lgCodigo = 0 }
                        

                    };

                    Controllers.ArtistasControllers obArtistasControllers = new Controllers.ArtistasControllers();

                    ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('MENSAJE!', '" + obArtistasControllers.setAdministarArtistasController(obclsArtistas, Convert.ToInt32(lblOpcion.Text)) + "!', 'success')</Script>");

                    lblOpcion.Text = txtCodigo.Text = txtNombre.Text = txtDescripcion.Text = txtFechaNacimiento.Text = txtCiudad.Text = txtLatitud.Text = txtLongitud.Text = String.Empty;
                    getArtistas();

                }

            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('ERROR!', '" + ex.Message + "!', 'ERROR')</Script>");
            }
        }
    }
}