using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConoceAColombia.web.Views.DeportistaAdmin
{
    public partial class DeportistaAdmin : System.Web.UI.Page
    {
        void getDeportista()
        {
            try
            {
                Controllers.DeportistaControllers obDeportistaControllers = new Controllers.DeportistaControllers();
                gvwDatos.DataSource = obDeportistaControllers.getDeportista();
                gvwDatos.DataBind();
            }
            catch (Exception ex) { ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('ERROR!', '" + ex.Message + "!', 'error')</Script>"); }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getDeportista();
                logica.BL.clsDeportista obclsDeportista = new logica.BL.clsDeportista();
                Controllers.DeportistaControllers obDeportistaControllers = new Controllers.DeportistaControllers();
                List<logica.Models.clsTipoDeportista> consultaTipoDeportista = obDeportistaControllers.getTipoDeportista();
                List<logica.Models.clsDepartamentos> consultaDepartamentos = obDeportistaControllers.getDepartamentos();
                obclsDeportista.CargarControlTipoDeportista(ref ddlTipoDeportista, consultaTipoDeportista, "lgCodigo", "stDescripcion", "-1", "<<Todos>>");
                obclsDeportista.CargarControlDepartamento(ref ddlDepartamento, consultaDepartamentos, "inCodigo", "stNombre", "-1", "<<Todos>>");
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
                String stRutaDestino = Server.MapPath(@"~\Images\Deportista\") + txtCodigo.Text + "Deportista" + Path.GetExtension(fuImagen.FileName);
                if (File.Exists(stRutaDestino))
                {
                    File.SetAttributes(stRutaDestino, FileAttributes.Normal);
                    File.Delete(stRutaDestino);
                }

                File.Copy(stRuta, stRutaDestino);
                File.SetAttributes(stRuta, FileAttributes.Normal);
                File.Delete(stRuta);

                logica.Models.clsDeportista clsDeportista = new logica.Models.clsDeportista
                {
                    lgCodigo = Convert.ToInt64(txtCodigo.Text),
                    stNombre = txtNombre.Text,
                    stDescripcion = txtDescripcion.Text,
                    stFechaNacimiento = txtFechaNacimiento.Text,
                    stCiudad = txtCiudad.Text,
                    stLatitud = txtLatitud.Text,
                    stLongitud = txtLongitud.Text,
                    obclsDepartamentos = new logica.Models.clsDepartamentos
                    {
                        inCodigo = Convert.ToInt64(ddlDepartamento.SelectedValue)
                    },
                    obclsTipoDeportista = new logica.Models.clsTipoDeportista
                    {
                        lgCodigo = Convert.ToInt64(ddlTipoDeportista.SelectedIndex)
                    },
                    stImagen = stRutaDestino
                    

                };

                Controllers.DeportistaControllers obDeportistaControllers = new Controllers.DeportistaControllers();
                if (String.IsNullOrEmpty(lblOpcion.Text)) lblOpcion.Text = "1";

                if (lblOpcion.Text.Equals("1"))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('Mensaje!,'" + obDeportistaControllers.insertarDeportista(clsDeportista) + "!','success')</Script>");
                    lblOpcion.Text = txtCodigo.Text = txtNombre.Text = txtDescripcion.Text = txtFechaNacimiento.Text = txtCiudad.Text = txtLatitud.Text = txtLongitud.Text = String.Empty;
                    getDeportista();
                }
                else if (lblOpcion.Text.Equals("2"))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('Mensaje!,'" + obDeportistaControllers.updateDeportista(clsDeportista) + "!','success')</Script>");
                    lblOpcion.Text = txtCodigo.Text = txtNombre.Text = txtDescripcion.Text = txtFechaNacimiento.Text = txtCiudad.Text = txtLatitud.Text = txtLongitud.Text = String.Empty;
                    getDeportista();
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
                    logica.Models.clsDeportista obclsDeportista = new logica.Models.clsDeportista
                    {
                        lgCodigo = Convert.ToInt32(((Label)gvwDatos.Rows[inIndice].FindControl("lblCodigo")).Text),
                        obclsDepartamentos = new logica.Models.clsDepartamentos { inCodigo = 0 },
                        stNombre = String.Empty,
                        stDescripcion = String.Empty,
                        stFechaNacimiento = String.Empty,
                        stCiudad = String.Empty,
                        stLatitud = String.Empty,
                        stLongitud = String.Empty,
                        obclsTipoDeportista = new logica.Models.clsTipoDeportista { lgCodigo = 0 },
                        stImagen = String.Empty



                    };

                    Controllers.DeportistaControllers obDeportistaControllers = new Controllers.DeportistaControllers();

                    ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('MENSAJE!', '" + obDeportistaControllers.deleteDeportista(obclsDeportista) + "!','Success')</Script>");

                    lblOpcion.Text = txtCodigo.Text = txtNombre.Text = txtDescripcion.Text = txtFechaNacimiento.Text = txtCiudad.Text = txtLatitud.Text = txtLongitud.Text = String.Empty;
                    getDeportista();

                }

            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('ERROR!', '" + ex.Message + "!', 'ERROR')</Script>");
            }
        }
    }
}