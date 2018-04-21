using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;


namespace ConoceAColombia.web.Controllers
{
    public class RecuperarPasswordControllers
    {
        public DataSet getConsultarPasswordController(logica.Models.clsUsuarios obclsUsuarios)
        {
            try
            {
                logica.BL.clsRecuperarPassword obclsRecuperarPassword = new logica.BL.clsRecuperarPassword();
                return obclsRecuperarPassword.getConsultarPassword(obclsUsuarios);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void setEmailController(logica.Models.clsCorreo obclsCorreo)
        {
            try
            {
                logica.BL.clsGeneral obclsGeneral = new logica.BL.clsGeneral();
                obclsGeneral.setEmail(obclsCorreo);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}