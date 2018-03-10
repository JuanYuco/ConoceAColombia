using System;
using System.Collections.Generic;
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
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('ERROR!', '" + ex.Message + "!', 'error')</Script>");
            }

        }
    }
}