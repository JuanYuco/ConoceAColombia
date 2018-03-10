using System;

namespace ConoceAColombia.web.Controllers
{
    public class LoginControllers
    {
        /// <summary>
        /// Validar Usuario
        /// </summary>
        /// <param name="obclsUsuarios">Objeto Usuario</param>
        /// <returns>Confirmacion</returns>
        public bool getValidarUsuarioController(logica.Models.clsUsuarios obclsUsuarios)
        {
            try
            {
                logica.BL.clsUsuarios obclsUsuario = new logica.BL.clsUsuarios();
                return obclsUsuario.getValidarUsuario(obclsUsuarios);


            }
            catch (Exception ew)
            {
                throw ew;
            }
        }
    }
}