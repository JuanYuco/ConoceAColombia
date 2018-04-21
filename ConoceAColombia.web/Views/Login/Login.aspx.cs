using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.WebRequestMethods;


namespace ConoceAColombia.web.Views.Login
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["Email"] != null)
                    txtEmail.Text = Request.Cookies["Email"].Value.ToString();
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                String stMensaje = String.Empty;
                if (String.IsNullOrEmpty(txtEmail.Text)) stMensaje += "Ingrese Email, ";
                if (String.IsNullOrEmpty(txtPassword.Text)) stMensaje += "Ingrese Contraseña, ";
                if (!String.IsNullOrEmpty(stMensaje)) throw new Exception(stMensaje.TrimEnd(','));
                //Defino Objeto con prioridades
                logica.Models.clsUsuarios obclsUsuarios = new logica.Models.clsUsuarios
                {
                    stCorreo = txtEmail.Text,
                    stPassword = txtPassword.Text

                };
                //Instancio Controlador
                Controllers.LoginControllers obLogingController = new Controllers.LoginControllers();
                bool blBandera = obLogingController.getValidarUsuarioController(obclsUsuarios);

                if (blBandera)
                {
                    if (chkRecordar.Checked)
                    {
                        HttpCookie cookieEmail = new HttpCookie("Email", txtEmail.Text);
                        cookieEmail.Expires = DateTime.Now.AddDays(2);
                        Response.Cookies.Add(cookieEmail);

                    }
                    else
                    {
                        HttpCookie cookieEmail = new HttpCookie("Email", txtEmail.Text);
                        cookieEmail.Expires = DateTime.Now.AddDays(-1);
                        Response.Cookies.Add(cookieEmail);

                    }

                    ViewState["viewLogin"] = txtEmail.Text;
                    ViewState["ViewPassword"] = txtPassword.Text;

                    Session["SessionEmail"] = txtEmail.Text;
                    Session["sesionPassword"] = txtPassword.Text;

                    Response.Redirect("../Index/Index.aspx");
                    

                    //Session.RemoveAll(); Remover todas
                    //Session.Remove("sesionLogin"); Nombre Variable a remover
                }
                else
                    throw new Exception("Usuario o password incorrectos");

            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('ERROR!', '" + ex.Message + "!', 'error')</Script>");
            }

        }


    }
}
