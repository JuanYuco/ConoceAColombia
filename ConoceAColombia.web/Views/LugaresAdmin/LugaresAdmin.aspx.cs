using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace ConoceAColombia.web.Views.LugaresAdmin
{
    public partial class LugaresAdmin : System.Web.UI.Page
    {
        void getLugares()
        {
            try
            {
                Controllers.LugaresControllers obLugaresControllers = new Controllers.LugaresControllers();
                gvwDatos.DataSource = obLugaresControllers.getLugares();
                gvwDatos.DataBind();
            }
            catch (Exception ex) { ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('ERROR!', '" + ex.Message + "!', 'error')</Script>"); }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getLugares();
                logica.BL.clsLugares obclsLugares = new logica.BL.clsLugares();
                Controllers.LugaresControllers obLugaresControllers = new Controllers.LugaresControllers();
                List<logica.Models.clsDepartamentos> consultaDepartamentos = obLugaresControllers.getDepartamentos();
                List<logica.Models.clsTipoLugares> consultaTipoLugares = obLugaresControllers.getTipoLugares();
                obclsLugares.CargarControlDepartamento(ref ddlDepartamento, consultaDepartamentos, "inCodigo", "stNombre", "-1", "<<Todos>>");
                obclsLugares.CargarControlTipoLugares(ref ddlTipoLugares, consultaTipoLugares, "lgCodigo", "stDescripcion", "-1", "<<Todos>>");
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
                if (String.IsNullOrEmpty(txtCiudad.Text)) stMensaje += "Ingrese la Ciudad, ";
                if (String.IsNullOrEmpty(txtFundacion.Text)) stMensaje += "Ingrese fundación, ";
                if (String.IsNullOrEmpty(txtDireccion.Text)) stMensaje += "Ingrese Dirección, ";
                if (fuImagen.HasFile == false) stMensaje += "Agrega una imagen, ";
                if (String.IsNullOrEmpty(txtLatitud.Text)) stMensaje += "Ingrese Latitud, ";
                if (String.IsNullOrEmpty(txtLongitud.Text)) stMensaje += "Ingrese Longitud, ";
                if (!String.IsNullOrEmpty(stMensaje)) throw new Exception(stMensaje.TrimEnd(','));


                if (!Path.GetExtension(fuImagen.FileName).Equals(".jpg"))
                    throw new Exception("Solo se admiten formatos .JPG");

                String stRuta = Server.MapPath(@"~\tmp\") + fuImagen.FileName;
                fuImagen.PostedFile.SaveAs(stRuta);
                String stRutaDestino = Server.MapPath(@"~\Images\Lugares\") + txtCodigo.Text + "Lugares" + Path.GetExtension(fuImagen.FileName);
                if (File.Exists(stRutaDestino))
                {
                    File.SetAttributes(stRutaDestino, FileAttributes.Normal);
                    File.Delete(stRutaDestino);
                }

                File.Copy(stRuta, stRutaDestino);
                File.SetAttributes(stRuta, FileAttributes.Normal);
                File.Delete(stRuta);

                logica.Models.clsLugares clsLugares = new logica.Models.clsLugares
                {
                    lgCodigo = Convert.ToInt64(txtCodigo.Text),
                    stNombre = txtNombre.Text,
                    stDescripcion = txtDescripcion.Text,
                    stCiudad = txtCiudad.Text,
                    stFundacion = txtFundacion.Text,
                    stDireccion = txtDireccion.Text,
                    stImagen = stRutaDestino,
                    stLatitud = txtLatitud.Text,
                    stLongitud = txtLongitud.Text,
                    obclsDepartamento = new logica.Models.clsDepartamentos
                    {
                        inCodigo = Convert.ToInt64(ddlDepartamento.SelectedValue)
                    },
                    obclsTipoLugar = new logica.Models.clsTipoLugares
                    {
                        lgCodigo = Convert.ToInt64(ddlTipoLugares.SelectedValue)
                    }

                };

                Controllers.LugaresControllers obLugaresControllers = new Controllers.LugaresControllers();
                if (String.IsNullOrEmpty(lblOpcion.Text)) lblOpcion.Text = "1";

                if (lblOpcion.Text.Equals("1"))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('Mensaje!,'" + obLugaresControllers.insertLugares(clsLugares) + "!','success')</Script>");
                    lblOpcion.Text = txtCodigo.Text = txtDescripcion.Text = txtCiudad.Text = txtFundacion.Text = txtDireccion.Text =txtNombre.Text = txtLatitud.Text = txtLongitud.Text = String.Empty;
                    getLugares();
                }
                else if (lblOpcion.Text.Equals("2"))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('Mensaje!,'" + obLugaresControllers.updateLugares(clsLugares) + "!','success')</Script>");
                    lblOpcion.Text = txtCodigo.Text = txtDescripcion.Text = txtCiudad.Text = txtFundacion.Text = txtDireccion.Text = txtNombre.Text = txtLatitud.Text = txtLongitud.Text = String.Empty;
                    getLugares();
                }


            }
            catch (Exception ex) { ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> Swal('MENSAJE!', '" + ex.Message + "!','success')</Script>"); }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            lblOpcion.Text = txtCodigo.Text = txtDescripcion.Text = txtCiudad.Text = txtFundacion.Text = txtDireccion.Text = txtNombre.Text = txtLatitud.Text = txtLongitud.Text = String.Empty;
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
                    txtFundacion.Text = String.IsNullOrEmpty(gvwDatos.Rows[inIndice].Cells[4].Text) ? String.Empty : gvwDatos.Rows[inIndice].Cells[4].Text;
                    txtDireccion.Text = String.IsNullOrEmpty(gvwDatos.Rows[inIndice].Cells[5].Text) ? String.Empty : gvwDatos.Rows[inIndice].Cells[5].Text;
                    txtLatitud.Text = String.IsNullOrEmpty(gvwDatos.Rows[inIndice].Cells[6].Text) ? String.Empty : gvwDatos.Rows[inIndice].Cells[6].Text;
                    txtLongitud.Text = String.IsNullOrEmpty(gvwDatos.Rows[inIndice].Cells[7].Text) ? String.Empty : gvwDatos.Rows[inIndice].Cells[7].Text;

                }
                else if (e.CommandName.Equals("Eliminar"))
                {
                    logica.Models.clsLugares obclsLugares = new logica.Models.clsLugares
                    {
                        lgCodigo = Convert.ToInt32(((Label)gvwDatos.Rows[inIndice].FindControl("lblCodigo")).Text),
                        stNombre = String.Empty,
                        stDescripcion = String.Empty,
                        stLatitud = String.Empty,
                        stLongitud = String.Empty,
                        stCiudad = String.Empty,
                        stFundacion = String.Empty,
                        stDireccion = String.Empty,
                        stImagen = String.Empty
                    
                    };

                    Controllers.LugaresControllers obLugaresControllers = new Controllers.LugaresControllers();

                    ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('MENSAJE!', '" + obLugaresControllers.deleteLugares(obclsLugares) + "!','Success')</Script>");

                    lblOpcion.Text = txtCodigo.Text = txtDescripcion.Text = txtCiudad.Text = txtFundacion.Text = txtDireccion.Text = txtNombre.Text = txtLatitud.Text = txtLongitud.Text = String.Empty;
                    getLugares();

                }

            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('ERROR!', '" + ex.Message + "!', 'ERROR')</Script>");
            }
        }
    }
}