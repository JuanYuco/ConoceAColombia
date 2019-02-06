using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConoceAColombia.web.Views.EquipoAdmin
{
    public partial class EquipoAdmin : System.Web.UI.Page
    {
        public void getEquipo()
        {
            Controllers.EquipoControllers obEquipoControllers = new Controllers.EquipoControllers();
            gvwDatos.DataSource = obEquipoControllers.getEquipo();
            gvwDatos.DataBind();
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

                logica.BL.clsEquipo clsEquipo = new logica.BL.clsEquipo();
                List<logica.Models.clsDeportes> listDeportes = clsEquipo.getDeportes();
                List<logica.Models.clsDepartamentos> listDepartamentos = clsEquipo.getDepartamentos();
                clsEquipo.CargarControlDeportes(ref ddlDeportes, listDeportes, "lgCodigo", "stNombre", "-1", "<<Todos>>");
                clsEquipo.CargarControlDepartamentos(ref ddlDepartamento, listDepartamentos, "inCodigo", "stNombre", "-1", "<<Todos>>");
                getEquipo();
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
                if (String.IsNullOrEmpty(txtPresidente.Text)) stMensaje += "Ingrese Presidente, ";
                if (String.IsNullOrEmpty(txtFundación.Text)) stMensaje += "Ingrese Fundacion, ";
                if (String.IsNullOrEmpty(txtCiudad.Text)) stMensaje += "Ingrese Ciudad, ";
                if (fuImagen.HasFile == false) stMensaje += "Agrega una imagen, ";
                if (String.IsNullOrEmpty(txtLatitud.Text)) stMensaje += "Ingrese Latitud, ";
                if (String.IsNullOrEmpty(txtLongitud.Text)) stMensaje += "Ingrese Longitud, ";

                if (!String.IsNullOrEmpty(stMensaje)) throw new Exception(stMensaje.TrimEnd(','));

                if (!Path.GetExtension(fuImagen.FileName).Equals(".jpg"))
                    throw new Exception("Solo se admiten formatos .JPG");

                String stRuta = Server.MapPath(@"~\tmp\") + fuImagen.FileName;
                fuImagen.PostedFile.SaveAs(stRuta);
                String stRutaDestino = Server.MapPath(@"~\Images\Equipos\") + txtCodigo.Text + "Equipos" + Path.GetExtension(fuImagen.FileName);
                if (File.Exists(stRutaDestino))
                {
                    File.SetAttributes(stRutaDestino, FileAttributes.Normal);
                    File.Delete(stRutaDestino);
                }

                File.Copy(stRuta, stRutaDestino);
                File.SetAttributes(stRuta, FileAttributes.Normal);
                File.Delete(stRuta);

                logica.Models.clsEquipo clsEquipo = new logica.Models.clsEquipo
                {
                    lgCodigo = Convert.ToInt64(txtCodigo.Text),
                    obclsDepartamentos = new logica.Models.clsDepartamentos { inCodigo = Convert.ToInt64(ddlDepartamento.SelectedValue) },
                    stNombre = txtNombre.Text,
                    stCiudad = txtCiudad.Text,
                    stLatitud = txtLatitud.Text,
                    stLongitud = txtLongitud.Text,
                    stDescripcion = txtDescripcion.Text,
                    stFundacion = txtFundación.Text,
                    stPresidente = txtPresidente.Text,
                    stImagen = stRutaDestino,
                    obclsDeportes = new logica.Models.clsDeportes { lgCodigo = Convert.ToInt64(ddlDeportes.SelectedValue) }
                };

                Controllers.EquipoControllers obEquipoControllers = new Controllers.EquipoControllers();
                

                ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('Mensaje!,'" + obEquipoControllers.addEquipo(clsEquipo) + "')</Script>");
                lblOpcion.Text = txtCodigo.Text = txtNombre.Text=txtDescripcion.Text=txtFundación.Text=txtPresidente.Text = txtCiudad.Text = txtLatitud.Text = txtLongitud.Text = String.Empty;
                getEquipo();
            }
            catch (Exception ex) { ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> Swal('" + ex.Message + "')</Script>"); }

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            lblOpcion.Text = txtCodigo.Text = txtNombre.Text = txtDescripcion.Text = txtFundación.Text = txtPresidente.Text = txtCiudad.Text = txtLatitud.Text = txtLongitud.Text = String.Empty;
        }

        protected void gvwDatos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int inIndice = Convert.ToInt16(e.CommandArgument);
                if (e.CommandName.Equals("Editar"))
                {
                    txtCodigo.Text = ((Label)gvwDatos.Rows[inIndice].FindControl("lblCodigo")).Text;
                    txtNombre.Text = String.IsNullOrEmpty(gvwDatos.Rows[inIndice].Cells[1].Text) ? String.Empty : gvwDatos.Rows[inIndice].Cells[1].Text;
                    txtDescripcion.Text = String.IsNullOrEmpty(gvwDatos.Rows[inIndice].Cells[2].Text) ? String.Empty : gvwDatos.Rows[inIndice].Cells[2].Text;
                    txtPresidente.Text = String.IsNullOrEmpty(gvwDatos.Rows[inIndice].Cells[3].Text) ? String.Empty : gvwDatos.Rows[inIndice].Cells[3].Text;
                    txtFundación.Text = String.IsNullOrEmpty(gvwDatos.Rows[inIndice].Cells[4].Text) ? String.Empty : gvwDatos.Rows[inIndice].Cells[4].Text;
                    txtCiudad.Text = String.IsNullOrEmpty(gvwDatos.Rows[inIndice].Cells[5].Text) ? String.Empty : gvwDatos.Rows[inIndice].Cells[5].Text;
                    txtLatitud.Text = String.IsNullOrEmpty(gvwDatos.Rows[inIndice].Cells[6].Text) ? String.Empty : gvwDatos.Rows[inIndice].Cells[6].Text;
                    txtLongitud.Text = String.IsNullOrEmpty(gvwDatos.Rows[inIndice].Cells[7].Text) ? String.Empty : gvwDatos.Rows[inIndice].Cells[7].Text;



                }
                else if (e.CommandName.Equals("Eliminar"))
                {
                    lblOpcion.Text = "3";
                    logica.Models.clsEquipo obclsEquipo = new logica.Models.clsEquipo
                    {
                        lgCodigo = Convert.ToInt32(((Label)gvwDatos.Rows[inIndice].FindControl("lblCodigo")).Text),
                        obclsDepartamentos = new logica.Models.clsDepartamentos { inCodigo = 0 },
                        stNombre = String.Empty,
                        stCiudad = String.Empty,
                        stLatitud = String.Empty,
                        stLongitud = String.Empty,
                        stDescripcion = String.Empty,
                        stFundacion = String.Empty,
                        stPresidente = String.Empty,
                        stImagen = String.Empty,
                        obclsDeportes = new logica.Models.clsDeportes { lgCodigo = 0 }


                    };

                    Controllers.EquipoControllers obEquipoControllers = new Controllers.EquipoControllers();

                    ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('MENSAJE!', '" + obEquipoControllers.deleteEquipo(obclsEquipo) + "!', 'success')</Script>");

                    lblOpcion.Text = txtCodigo.Text = txtNombre.Text = txtDescripcion.Text = txtFundación.Text = txtPresidente.Text = txtCiudad.Text = txtLatitud.Text = txtLongitud.Text = String.Empty;
                    getEquipo();

                }

            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('ERROR!', '" + ex.Message + "!', 'ERROR')</Script>");
            }

        }
    }
}