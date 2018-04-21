using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConoceAColombia.web.Controllers
{
    public class CrearCuentaControllers
    {
        public String setCrearCuentaControllers(logica.Models.clsUsuarios obclsUsuarioModels, int inOpcion)
        {
            try
            {
                logica.BL.clsUsuarios clsUsuarios = new logica.BL.clsUsuarios();
                return clsUsuarios.setCrearCuenta(obclsUsuarioModels, inOpcion);
            }catch(Exception ew)
            {
                throw ew;
            }

        }
    }
}