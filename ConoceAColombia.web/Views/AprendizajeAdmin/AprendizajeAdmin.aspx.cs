using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConoceAColombia.web.Views
{
    public partial class AprendizajeAdmin : System.Web.UI.Page
    {

        void getAprendizaje()
        {
            try
            {
                Controllers.AprendizajeControllers obAprendizajeControllers = new Controllers.AprendizajeControllers();
                gvwDatos.DataSource = obAprendizajeControllers.getAprendizaje();
                gvwDatos.DataBind();
            }
            catch (Exception ex) { ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('ERROR!', '" + ex.Message + "!', 'error')</Script>"); }

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getAprendizaje();
                logica.BL.clsAprendizaje obclsAprendizaje = new logica.BL.clsAprendizaje();
                Controllers.AprendizajeControllers obAprendizajeControllers = new Controllers.AprendizajeControllers();
                List<logica.Models.clsTipoAprendizaje> consultaTipoAprendizaje = obAprendizajeControllers.getTipoAprendizaje();
                List<logica.Models.clsDepartamentos> consultaDepartamentos = obAprendizajeControllers.getDepartamentos();
                obclsAprendizaje.CargarControlTipoAprendizaje(ref ddlTipoAprendizaje, consultaTipoAprendizaje, "lgCodigo", "stDescripcion", "-1", "<<Todos>>");
                obclsAprendizaje.CargarControlDepartamento(ref ddlDepartamento, consultaDepartamentos, "inCodigo", "stNombre", "-1", "<<Todos>>");
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
                if (fuImagen.HasFile == false) stMensaje += "Agrega una imagen, ";
                if (String.IsNullOrEmpty(txtCiudad.Text)) stMensaje += "Ingrese Ciudad, ";
                if (String.IsNullOrEmpty(txtLatitud.Text)) stMensaje += "Ingrese Latitud, ";
                if (String.IsNullOrEmpty(txtLongitud.Text)) stMensaje += "Ingrese Longitud, ";

                if (!String.IsNullOrEmpty(stMensaje)) throw new Exception(stMensaje.TrimEnd(','));

                if (!Path.GetExtension(fuImagen.FileName).Equals(".jpg"))
                    throw new Exception("Solo se admiten formatos .JPG");

                String stRuta = Server.MapPath(@"~\tmp\") + fuImagen.FileName;
                fuImagen.PostedFile.SaveAs(stRuta);
                String stRutaDestino = Server.MapPath(@"~\Images\Aprendizaje\") + txtCodigo.Text + "Aprendizaje" + Path.GetExtension(fuImagen.FileName);
                if (File.Exists(stRutaDestino))
                {
                    File.SetAttributes(stRutaDestino, FileAttributes.Normal);
                    File.Delete(stRutaDestino);
                }

                File.Copy(stRuta, stRutaDestino);
                File.SetAttributes(stRuta, FileAttributes.Normal);
                File.Delete(stRuta);

                logica.Models.clsAprendizaje clsAprendizaje = new logica.Models.clsAprendizaje
                {
                    lgCodigo = Convert.ToInt64(txtCodigo.Text),
                    stNombre = txtNombre.Text,
                    stDescripcion = txtDescripcion.Text,
                    stFechaNacimiento = txtFechaNacimiento.Text,
                    stCiudad = txtCiudad.Text,
                    stImagen = stRutaDestino,
                    stLatitud = txtLatitud.Text,
                    stLongitud = txtLongitud.Text,
                    obclsDepartamentos = new logica.Models.clsDepartamentos
                    {
                        inCodigo = Convert.ToInt64(ddlDepartamento.SelectedValue)
                    },
                    obclsTipoAprendizaje = new logica.Models.clsTipoAprendizaje
                    {
                        lgCodigo = Convert.ToInt64(ddlTipoAprendizaje.SelectedIndex)
                    }


                };

                Controllers.AprendizajeControllers obAprendizajeControllers = new Controllers.AprendizajeControllers();
                if (String.IsNullOrEmpty(lblOpcion.Text)) lblOpcion.Text = "1";

                if (lblOpcion.Text.Equals("1"))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('Mensaje!,'" + obAprendizajeControllers.insertarAprendizaje(clsAprendizaje) + "!','success')</Script>");
                    lblOpcion.Text = txtCodigo.Text = txtNombre.Text = txtDescripcion.Text = txtFechaNacimiento.Text = txtCiudad.Text = txtLatitud.Text = txtLongitud.Text = String.Empty;
                    getAprendizaje();
                }
                else if (lblOpcion.Text.Equals("2"))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('Mensaje!,'" + obAprendizajeControllers.updateAprendizaje(clsAprendizaje) + "!','success')</Script>");
                    lblOpcion.Text = txtCodigo.Text = txtNombre.Text = txtDescripcion.Text = txtFechaNacimiento.Text = txtCiudad.Text = txtLatitud.Text = txtLongitud.Text = String.Empty;
                    getAprendizaje();
                }


            }
            catch (Exception ex) { ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> Swal('MENSAJE!', '" + ex.Message + "!','success')</Script>"); }
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
                    logica.Models.clsAprendizaje obclsAprendizaje = new logica.Models.clsAprendizaje
                    {
                        lgCodigo = Convert.ToInt32(((Label)gvwDatos.Rows[inIndice].FindControl("lblCodigo")).Text),
                        obclsDepartamentos = new logica.Models.clsDepartamentos { inCodigo = 0 },
                        stNombre = String.Empty,
                        stDescripcion = String.Empty,
                        stFechaNacimiento = String.Empty,
                        stCiudad = String.Empty,
                        stImagen = String.Empty,
                        stLatitud = String.Empty,
                        stLongitud = String.Empty,
                        obclsTipoAprendizaje = new logica.Models.clsTipoAprendizaje { lgCodigo = 0 }



                    };

                    Controllers.AprendizajeControllers obAprendizajeControllers = new Controllers.AprendizajeControllers();

                    ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('MENSAJE!', '" + obAprendizajeControllers.deleteAprendizaje(obclsAprendizaje) + "!','Success')</Script>");

                    lblOpcion.Text = txtCodigo.Text = txtNombre.Text = txtDescripcion.Text = txtFechaNacimiento.Text = txtCiudad.Text = txtLatitud.Text = txtLongitud.Text = String.Empty;
                    getAprendizaje();

                }

            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('ERROR!', '" + ex.Message + "!', 'ERROR')</Script>");
            }
        }
    }
}