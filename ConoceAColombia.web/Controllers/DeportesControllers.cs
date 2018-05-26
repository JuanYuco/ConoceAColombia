using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConoceAColombia.web.Controllers
{
    public class DeportesControllers
    {
        public List<logica.Models.clsDeportes> getDeportesControllers()
        {
            try
            {
                logica.BL.clsDeportes obclsDeportes = new logica.BL.clsDeportes();
                return obclsDeportes.getDeportes();
            }
            catch (Exception ew)
            {
                throw ew;
            }
            
        }


        public String insertarDeportes(logica.Models.clsDeportes obclsDeportesModels)
        {
            try 
            {
                logica.BL.clsDeportes obclsDeportes = new logica.BL.clsDeportes();
                return obclsDeportes.addDeportes(obclsDeportesModels);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public String updateDeportes(logica.Models.clsDeportes obclsDeportesModels)
        {
            try
            {
                logica.BL.clsDeportes obclsDeportes = new logica.BL.clsDeportes();
                return obclsDeportes.updateDeportes(obclsDeportesModels);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public String deleteDeportes(logica.Models.clsDeportes obclsDeportesModels)
        {
            try
            {
                logica.BL.clsDeportes obclsDeportes = new logica.BL.clsDeportes();
                return obclsDeportes.deleteDeportes(obclsDeportesModels);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
