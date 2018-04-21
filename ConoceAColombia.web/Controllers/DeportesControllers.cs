using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace ConoceAColombia.web.Controllers
{
    public class DeportesControllers
    {
        public DataSet getConsultarDeportesController()
        {
            try
            {
                logica.BL.clsDeportes obclsDeportes = new logica.BL.clsDeportes();
                return obclsDeportes.getConsultarDeportes();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public String setAdmintrarDeportesController(logica.Models.clsDeportes obclsDeportesModels, int inOpcion)
        {
            try
            {
                logica.BL.clsDeportes obclsDeportes = new logica.BL.clsDeportes();
                return obclsDeportes.setAdministrarDeportes(obclsDeportesModels, inOpcion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}