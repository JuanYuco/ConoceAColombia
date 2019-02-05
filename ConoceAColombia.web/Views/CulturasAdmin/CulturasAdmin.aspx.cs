using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConoceAColombia.web.Views.CulturasAdmin
{
    public partial class CulturasAdmin : System.Web.UI.Page
    {
        void getCulturas()
        {
            try
            {
                Controllers.CulturasControllers obCulturasControllers = new Controllers.CulturasControllers();
                gvwDatos.DataSource = obCulturasControllers.getCulturas();
                gvwDatos.DataBind();
            }
            catch (Exception ex) { ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('ERROR!', '" + ex.Message + "!', 'error')</Script>"); }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getCulturas();
                logica.BL.clsCulturas obclsCulturas = new logica.BL.clsCulturas();
                Controllers.CulturasControllers obCulturasControllers = new Controllers.CulturasControllers();
                List<logica.Models.clsDepartamentos> consultaDepartamentos = obCulturasControllers.getDepartamentos();
                List<logica.Models.clsTipoCulturas> consultaTipoCulturas = obCulturasControllers.getTipoCulturas();
                obclsCulturas.CargarControlDepartamento(ref ddlDepartamento, consultaDepartamentos, "inCodigo", "stNombre", "-1", "<<Todos>>");
                obclsCulturas.CargarControlTipoCulturas(ref ddlTipoCulturas, consultaTipoCulturas, "lgCodigo", "stDescripcion", "-1", "<<Todos>>");
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
                if (String.IsNullOrEmpty(txtFechaInicio.Text)) stMensaje += "Ingrese la fecha de inicio, ";
                if (String.IsNullOrEmpty(txtFechaFin.Text)) stMensaje += "Ingrese fecha del final, ";
                if (fuImagen.HasFile == false) stMensaje += "Agrega una imagen, ";
                if (String.IsNullOrEmpty(txtLatitud.Text)) stMensaje += "Ingrese Latitud, ";
                if (String.IsNullOrEmpty(txtLongitud.Text)) stMensaje += "Ingrese Longitud, ";
                if (!String.IsNullOrEmpty(stMensaje)) throw new Exception(stMensaje.TrimEnd(','));


                if (!Path.GetExtension(fuImagen.FileName).Equals(".jpg"))
                    throw new Exception("Solo se admiten formatos .JPG");

                String stRuta = Server.MapPath(@"~\tmp\") + fuImagen.FileName;
                fuImagen.PostedFile.SaveAs(stRuta);
                String stRutaDestino = Server.MapPath(@"~\Images\Culturas\") + txtCodigo.Text + "Culturas" + Path.GetExtension(fuImagen.FileName);
                if (File.Exists(stRutaDestino))
                {
                    File.SetAttributes(stRutaDestino, FileAttributes.Normal);
                    File.Delete(stRutaDestino);
                }

                File.Copy(stRuta, stRutaDestino);
                File.SetAttributes(stRuta, FileAttributes.Normal);
                File.Delete(stRuta);

                logica.Models.clsCulturas clsCulturas = new logica.Models.clsCulturas
                {
                    lgCodigo = Convert.ToInt64(txtCodigo.Text),
                    stNombre = txtNombre.Text,
                    stFechaInicio = txtFechaInicio.Text,
                    stFechaFin = txtFechaFin.Text,
                    stDescripcion = txtDescripcion.Text,
                    stImagen = stRutaDestino,
                    stLatitud = txtLatitud.Text,
                    stLongitud = txtLongitud.Text,
                    obclsDepartamentos = new logica.Models.clsDepartamentos
                    {
                        inCodigo = Convert.ToInt64(ddlDepartamento.SelectedValue)
                    },
                    obclsTipoCulturas = new logica.Models.clsTipoCulturas
                    {
                        lgCodigo = Convert.ToInt64(ddlTipoCulturas.SelectedValue)
                    }

                };

                Controllers.CulturasControllers obCulturasControllers = new Controllers.CulturasControllers();
                if (String.IsNullOrEmpty(lblOpcion.Text)) lblOpcion.Text = "1";

                if (lblOpcion.Text.Equals("1"))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('Mensaje!,'" + obCulturasControllers.addCulturas(clsCulturas) + "!','success')</Script>");
                    lblOpcion.Text = txtCodigo.Text = txtDescripcion.Text =  txtFechaInicio.Text =txtFechaFin.Text =txtNombre.Text = txtLatitud.Text = txtLongitud.Text=  String.Empty;
                    getCulturas();
                }
                else if (lblOpcion.Text.Equals("2"))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('Mensaje!,'" + obCulturasControllers.updateCulturas(clsCulturas) + "!','success')</Script>");
                    lblOpcion.Text = txtCodigo.Text = txtDescripcion.Text = txtFechaInicio.Text = txtFechaFin.Text = txtNombre.Text = txtLatitud.Text = txtLongitud.Text = String.Empty;
                    getCulturas();
                }


            }
            catch (Exception ex) { ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> Swal('MENSAJE!', '" + ex.Message + "!','success')</Script>"); }

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            lblOpcion.Text = txtCodigo.Text = txtDescripcion.Text = txtFechaInicio.Text = txtFechaFin.Text = txtNombre.Text = txtLatitud.Text = txtLongitud.Text = String.Empty;
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
                    txtFechaInicio.Text = String.IsNullOrEmpty(gvwDatos.Rows[inIndice].Cells[3].Text) ? String.Empty : gvwDatos.Rows[inIndice].Cells[3].Text;
                    txtFechaFin.Text = String.IsNullOrEmpty(gvwDatos.Rows[inIndice].Cells[4].Text) ? String.Empty : gvwDatos.Rows[inIndice].Cells[4].Text;
                    txtLatitud.Text = String.IsNullOrEmpty(gvwDatos.Rows[inIndice].Cells[5].Text) ? String.Empty : gvwDatos.Rows[inIndice].Cells[5].Text;
                    txtLongitud.Text = String.IsNullOrEmpty(gvwDatos.Rows[inIndice].Cells[6].Text) ? String.Empty : gvwDatos.Rows[inIndice].Cells[6].Text;

                }
                else if (e.CommandName.Equals("Eliminar"))
                {
                    logica.Models.clsCulturas obclsCulturas = new logica.Models.clsCulturas
                    {
                        lgCodigo = Convert.ToInt32(((Label)gvwDatos.Rows[inIndice].FindControl("lblCodigo")).Text),
                        stNombre = String.Empty,
                        stDescripcion = String.Empty,
                        stLatitud = String.Empty,
                        stLongitud = String.Empty,
                        stFechaFin = String.Empty,
                        stFechaInicio = String.Empty,
                        stImagen = String.Empty
                    };

                    Controllers.CulturasControllers obCulturasControllers = new Controllers.CulturasControllers();

                    ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('MENSAJE!', '" + obCulturasControllers.deleteCulturas(obclsCulturas) + "!','Success')</Script>");

                    lblOpcion.Text = txtCodigo.Text = txtDescripcion.Text = txtFechaInicio.Text = txtFechaFin.Text = txtNombre.Text = txtLatitud.Text = txtLongitud.Text = String.Empty;
                    getCulturas();

                }

            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('ERROR!', '" + ex.Message + "!', 'ERROR')</Script>");
            }
        }
    }
}