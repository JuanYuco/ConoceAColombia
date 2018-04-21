using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace ConoceAColombia.web.Controllers
{
    public class CiudadesPrincipalesControllers
    {
        

        public DataSet getConsultarCiudadesPrincipalesController()
        {
            try
            {
                logica.BL.clsCiudadesPrincipales obclsCiudadesPrincipales= new logica.BL.clsCiudadesPrincipales();
                return obclsCiudadesPrincipales.getConsultarCiudadesPrincipales();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public String setAdministarCiudadesPrincipalesController(logica.Models.clsCiudadesPrincipales obclsCiudadesPrincipalesModels, int inOpcion)
        {
            try
            {
                logica.BL.clsCiudadesPrincipales obclsCiudadesPrincipales = new logica.BL.clsCiudadesPrincipales();
                return obclsCiudadesPrincipales.setAdministrarCiudaesPrincipales(obclsCiudadesPrincipalesModels, inOpcion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}