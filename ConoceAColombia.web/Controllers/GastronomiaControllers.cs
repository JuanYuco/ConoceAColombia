using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


namespace ConoceAColombia.web.Controllers
{
    public class GastronomiaControllers
    {
        public DataSet getConsultarGastronomiaController()
        {
            try
            {
                logica.BL.clsGastronomia obclsGastronomia = new logica.BL.clsGastronomia();
                return obclsGastronomia.getConsultarGastronomia();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public String setAdministrarGastronomiaController(logica.Models.clsGastronomia obclsGastronomiaModels, int inOpcion)
        {
            try
            {
                logica.BL.clsGastronomia obclsGastronomia = new logica.BL.clsGastronomia();
                return obclsGastronomia.setAdministrarGastronomia(obclsGastronomiaModels, inOpcion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}