using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConoceAColombia.web.Views.EstadiosAdmin
{
    public partial class EstadiosAdmin : System.Web.UI.Page
    {
        void getEstadios()
        {
            try
            {
                Controllers.EstadiosControllers obEstadiosControllers = new Controllers.EstadiosControllers();
                gvwDatos.DataSource = obEstadiosControllers.getEstadios();
                gvwDatos.DataBind();
            }
            catch (Exception ex) { ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('ERROR!', '" + ex.Message + "!', 'error')</Script>"); }

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getEstadios();
                logica.BL.clsEstadios obclsEstadios = new logica.BL.clsEstadios();
                Controllers.EstadiosControllers obEstadiosControllers = new Controllers.EstadiosControllers();
                List<logica.Models.clsDepartamentos> consultaDepartamentos = obEstadiosControllers.getDepartamentos();
                List<logica.Models.clsDeportes> consultaDeportes = obEstadiosControllers.getDeportes();
                obclsEstadios.CargarControlDepartamento(ref ddlDepartamento, consultaDepartamentos, "inCodigo", "stNombre", "-1", "<<Todos>>");
                obclsEstadios.CargarControlDeportes(ref ddlDeportes, consultaDeportes, "lgCodigo", "stNombre", "-1", "<<Todos>>");
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
                if (String.IsNullOrEmpty(txtFundacion.Text)) stMensaje += "Ingrese Fundación, ";
                if (String.IsNullOrEmpty(txtCapacidad.Text)) stMensaje += "Ingrese Capacidad, ";
                if (String.IsNullOrEmpty(txtCiudad.Text)) stMensaje += "Ingrese Ciudad, ";
                if (fuImagen.HasFile == false) stMensaje += "Agrega una imagen, ";
                if (String.IsNullOrEmpty(txtLatitud.Text)) stMensaje += "Ingrese Latitud, ";
                if (String.IsNullOrEmpty(txtLongitud.Text)) stMensaje += "Ingrese Longitud, ";
                if (!String.IsNullOrEmpty(stMensaje)) throw new Exception(stMensaje.TrimEnd(','));


                if (!Path.GetExtension(fuImagen.FileName).Equals(".jpg"))
                    throw new Exception("Solo se admiten formatos .JPG");

                String stRuta = Server.MapPath(@"~\tmp\") + fuImagen.FileName;
                fuImagen.PostedFile.SaveAs(stRuta);
                String stRutaDestino = Server.MapPath(@"~\Images\Estadios\") + txtCodigo.Text + "Estadios" + Path.GetExtension(fuImagen.FileName);
                if (File.Exists(stRutaDestino))
                {
                    File.SetAttributes(stRutaDestino, FileAttributes.Normal);
                    File.Delete(stRutaDestino);
                }

                File.Copy(stRuta, stRutaDestino);
                File.SetAttributes(stRuta, FileAttributes.Normal);
                File.Delete(stRuta);


                logica.Models.clsEstadios clsEstadios = new logica.Models.clsEstadios
                {
                    lgCodigo = Convert.ToInt64(txtCodigo.Text),
                    stNombre = txtNombre.Text,
                    stDescripcion = txtDescripcion.Text,
                    stFundacion = txtFundacion.Text,
                    stCapacidad = txtCapacidad.Text,
                    stCiudad = txtCiudad.Text,
                    stLatitud = txtLatitud.Text,
                    stLongitud = txtLongitud.Text,
                    stImagen = stRutaDestino,
                    obclsDepartamento = new logica.Models.clsDepartamentos
                    {
                        inCodigo = Convert.ToInt64(ddlDepartamento.SelectedValue)
                    },
                    obclsDeporte = new logica.Models.clsDeportes
                    {
                        lgCodigo = Convert.ToInt64(ddlDeportes.SelectedValue)
                    }

                };

                Controllers.EstadiosControllers obEstadiosControllers = new Controllers.EstadiosControllers();
                if (String.IsNullOrEmpty(lblOpcion.Text)) lblOpcion.Text = "1";

                if (lblOpcion.Text.Equals("1"))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('Mensaje!,'" + obEstadiosControllers.insertEstadios(clsEstadios) + "!','success')</Script>");
                    lblOpcion.Text = txtCodigo.Text = txtDescripcion.Text = txtFundacion.Text = txtCapacidad.Text = txtCiudad.Text = txtNombre.Text = txtLatitud.Text = txtLongitud.Text = String.Empty;
                    getEstadios();
                }
                else if (lblOpcion.Text.Equals("2"))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('Mensaje!,'" + obEstadiosControllers.updateEstadios(clsEstadios) + "!','success')</Script>");
                    lblOpcion.Text = txtCodigo.Text = txtDescripcion.Text = txtFundacion.Text = txtCapacidad.Text = txtCiudad.Text = txtNombre.Text = txtLatitud.Text = txtLongitud.Text = String.Empty;
                    getEstadios();
                }


            }
            catch (Exception ex) { ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> Swal('MENSAJE!', '" + ex.Message + "!','success')</Script>"); }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            lblOpcion.Text = txtCodigo.Text = txtDescripcion.Text = txtFundacion.Text = txtCapacidad.Text = txtCiudad.Text = txtNombre.Text = txtLatitud.Text = txtLongitud.Text = String.Empty;
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
                    txtFundacion.Text = String.IsNullOrEmpty(gvwDatos.Rows[inIndice].Cells[3].Text) ? String.Empty : gvwDatos.Rows[inIndice].Cells[3].Text;
                    txtCapacidad.Text = String.IsNullOrEmpty(gvwDatos.Rows[inIndice].Cells[4].Text) ? String.Empty : gvwDatos.Rows[inIndice].Cells[4].Text;
                    txtCiudad.Text = String.IsNullOrEmpty(gvwDatos.Rows[inIndice].Cells[5].Text) ? String.Empty : gvwDatos.Rows[inIndice].Cells[5].Text;
                    txtLatitud.Text = String.IsNullOrEmpty(gvwDatos.Rows[inIndice].Cells[6].Text) ? String.Empty : gvwDatos.Rows[inIndice].Cells[6].Text;
                    txtLongitud.Text = String.IsNullOrEmpty(gvwDatos.Rows[inIndice].Cells[7].Text) ? String.Empty : gvwDatos.Rows[inIndice].Cells[7].Text;

                }
                else if (e.CommandName.Equals("Eliminar"))
                {
                    logica.Models.clsEstadios obclsEstadios = new logica.Models.clsEstadios
                    {
                        lgCodigo = Convert.ToInt32(((Label)gvwDatos.Rows[inIndice].FindControl("lblCodigo")).Text),
                        stNombre = String.Empty,
                        stDescripcion = String.Empty,
                        stLatitud = String.Empty,
                        stLongitud = String.Empty,
                        stFundacion = String.Empty,
                        stCapacidad = String.Empty,
                        stCiudad = String.Empty,
                        stImagen = String.Empty
                    };

                    Controllers.EstadiosControllers obEstadiosControllers = new Controllers.EstadiosControllers();

                    ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('MENSAJE!', '" + obEstadiosControllers.deleteEstadios(obclsEstadios) + "!','Success')</Script>");

                    lblOpcion.Text = txtCodigo.Text = txtDescripcion.Text = txtFundacion.Text = txtCapacidad.Text = txtCiudad.Text = txtNombre.Text = txtLatitud.Text = txtLongitud.Text = String.Empty;
                    getEstadios();

                }

            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('ERROR!', '" + ex.Message + "!', 'ERROR')</Script>");
            }
        }
    }
}