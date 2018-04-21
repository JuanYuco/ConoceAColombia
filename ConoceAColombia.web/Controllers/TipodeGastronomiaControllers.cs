using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace ConoceAColombia.web.Controllers
{
    public class TipodeGastronomiaControllers
    {
        public DataSet getConsultarTipodeGastronomiaController()
        {
            try
            {
                logica.BL.clsTipodeGastronomia obclsTipodeGastronomia = new logica.BL.clsTipodeGastronomia();
                return obclsTipodeGastronomia.getConsultarTipodeGastronomia();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public String setAdministrarTipodeGastronomiaController(logica.Models.clsTipodeGastronomia obclsTipodeGastronomiaModels, int inOpcion)
        {
            try
            {
                logica.BL.clsTipodeGastronomia obclsTiposdeGastronomia = new logica.BL.clsTipodeGastronomia();
                return obclsTiposdeGastronomia.setAdministrarTipodeGastronomia(obclsTipodeGastronomiaModels, inOpcion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}