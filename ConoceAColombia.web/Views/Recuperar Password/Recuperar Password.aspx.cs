using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;

namespace ConoceAColombia.web.Views.Recuperar_Password
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRecuperar_Click(object sender, EventArgs e)
        {
            try
            {
                String stMensaje = String.Empty;
                if (String.IsNullOrEmpty(txtIngresarEmail.Text)) stMensaje = "Ingrese el Email";
                if (!String.IsNullOrEmpty(stMensaje)) throw new Exception(stMensaje);

                Controllers.RecuperarPasswordControllers obRecuperarPasswordControllers = new Controllers.RecuperarPasswordControllers();
                logica.Models.clsUsuarios obclsUsuarios = new logica.Models.clsUsuarios
                {
                    stCorreo = txtIngresarEmail.Text

                };

                DataSet dsConsulta = obRecuperarPasswordControllers.getConsultarPasswordController(obclsUsuarios);

                if (dsConsulta.Tables[0].Rows.Count > 0)
                {

                    string[] stLogin = dsConsulta.Tables[0].Rows[0]["usuaCorreo"].ToString().Split('@');
                    string stCuerpoHTML = "<!DOCTYPE html>";
                    stCuerpoHTML += "<html lang='es'>";
                    stCuerpoHTML += "<head>";
                    stCuerpoHTML += "<meta charset='utf - 8'>";
                    stCuerpoHTML += "<title>Recuperacion de correo</title>";
                    stCuerpoHTML += "</head>";
                    stCuerpoHTML += "<body style='background - color: black '>";
                    stCuerpoHTML += "<table style='max - width: 600px; padding: 10px; margin: 0 auto; border - collapse: collapse; '>	";
                    stCuerpoHTML += "<tr>";
                    stCuerpoHTML += "<td style='padding: 0'>";
                    stCuerpoHTML += "<img style='padding: 0; display: block' src='cid:Fondo' width='100%' height='10%'>";
                    stCuerpoHTML += "</td>";
                    stCuerpoHTML += "</tr>";
                    stCuerpoHTML += "<tr>";
                    stCuerpoHTML += "<td style='background - color: #ecf0f1'>";
                    stCuerpoHTML += "<div style='color: #34495e; margin: 4% 10% 2%; text-align: justify;font-family: sans-serif'>";
                    stCuerpoHTML += "<h2 style='color: #e67e22; margin: 0 0 7px'>Hola " + stLogin[0] + "</h2>";
                    stCuerpoHTML += "<p style='margin: 2px; font - size: 15px'>";
                    stCuerpoHTML += "Hemos recibido una solicitud para restablecer el password de su cuenta asociada con ";
                    stCuerpoHTML += "esta dirección de correo electrónico. Si no ha realizado esta solicitud, puede ignorar este ";
                    stCuerpoHTML += "correo electrónico y le garantizamos que su cuenta es completamente segura.";
                    stCuerpoHTML += "<br/>";
                    stCuerpoHTML += "<br/>";
                    stCuerpoHTML += "Su password es: " + dsConsulta.Tables[0].Rows[0]["usuaPassword"].ToString();
                    stCuerpoHTML += "</p>";
                    stCuerpoHTML += "<p style='color: #b3b3b3; font-size: 12px; text-align: center;margin: 30px 0 0'>Copyright © Conoce a:Colombia 2018</p>";
                    stCuerpoHTML += "</div>";
                    stCuerpoHTML += "</td>";
                    stCuerpoHTML += "</tr>";
                    stCuerpoHTML += "</table>";
                    stCuerpoHTML += "</body>";
                    stCuerpoHTML += "</html>";
                    logica.Models.clsCorreo obclsCorreo = new logica.Models.clsCorreo()
                    {
                        stServidor = ConfigurationManager.AppSettings["stServidor"].ToString(),
                        stUsuario = ConfigurationManager.AppSettings["stUsuario"].ToString(),
                        stPassword = ConfigurationManager.AppSettings["stPassword"].ToString(),
                        stPuerto = ConfigurationManager.AppSettings["stPuerto"].ToString(),
                        blAutenticacion = true,
                        blConexionSegura = true,
                        inPrioridad = 0,
                        inTipo = 1,
                        stAsunto = "Recuperacion de Password",
                        stFrom = ConfigurationManager.AppSettings["stUsuario"].ToString(),
                        stTo = txtIngresarEmail.Text,
                        stImage = Server.MapPath("~")+ @"\Resources\Images\hqdefault.jpg",
                        stIdImage = "Fondo",
                        stMensaje = stCuerpoHTML


                    };

                    obRecuperarPasswordControllers.setEmailController(obclsCorreo);
                    ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('Mensaje!', 'Se realizo proceso con exito!', 'success')</Script>");


                }
                else
                {
                    throw new Exception("No se encotro información asociada con esa dirección de correo");

                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('ERROR!', '" + ex.Message + "!', 'error')</Script>");
            }
        }

        protected void btnRecuperar_Click1(object sender, EventArgs e)
        {

        }
    }
}