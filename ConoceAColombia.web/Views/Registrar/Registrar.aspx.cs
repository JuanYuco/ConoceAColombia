using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConoceAColombia.web.Views.Registrar
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           


        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                String stMensaje = String.Empty;
                if (String.IsNullOrEmpty(txtNombre.Text)) stMensaje += "Ingrese el Nombre,";
                if (String.IsNullOrEmpty(txtLastName.Text)) stMensaje += " Ingrese el apellido,";
                if (String.IsNullOrEmpty(txtEmail.Text)) stMensaje += " Ingrese Email,";
                if (String.IsNullOrEmpty(txtPassword.Text)) stMensaje += " Ingrese La Contraseña,";
                if (String.IsNullOrEmpty(txtConfirmPassword.Text)) stMensaje += " Ingrese la confirmacion de la contraseña,";
                if (txtPassword.Text != txtConfirmPassword.Text) stMensaje += "Las Contraseñas son diferentes,";
                if (!String.IsNullOrEmpty(stMensaje)) throw new Exception(stMensaje.TrimEnd(','));


                Controllers.CrearCuentaControllers obCrearCuentaControllers = new Controllers.CrearCuentaControllers();
                if (fuImagen.HasFile)
                {
                    if (!Path.GetExtension(fuImagen.FileName).Equals(".jpg"))
                        throw new Exception("Solo se admiten formatos .JPG");

                    String stRuta = Server.MapPath(@"~\tmp\")+fuImagen.FileName;
                    fuImagen.PostedFile.SaveAs(stRuta);
                    String stRutaDestino = Server.MapPath(@"~\Images\") + txtEmail.Text + Path.GetExtension(fuImagen.FileName);
                    if (File.Exists(stRutaDestino))
                    {
                        File.SetAttributes(stRutaDestino, FileAttributes.Normal);
                        File.Delete(stRutaDestino);
                    }

                    File.Copy(stRuta, stRutaDestino);
                    File.SetAttributes(stRuta, FileAttributes.Normal);
                    File.Delete(stRuta);

                    logica.Models.clsUsuarios obclsUsuarios = new logica.Models.clsUsuarios
                    {
                        stNombre = txtNombre.Text,
                        stApellido = txtLastName.Text,
                        stCorreo = txtEmail.Text,
                        stPassword = txtPassword.Text,
                        stUsuaImagen = stRutaDestino
                    };
                    ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "<script> swal('Mensaje!', '" + obCrearCuentaControllers.setCrearCuentaControllers(obclsUsuarios, 1) + "!', 'success') </script>");
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('ERROR!', '" + ex.Message + "!', 'error')</Script>");
            }

        }
    }
}