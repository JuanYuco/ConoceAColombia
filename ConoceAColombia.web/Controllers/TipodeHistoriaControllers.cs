using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace ConoceAColombia.web.Controllers
{
    public class TipodeHistoriaControllers
    {
        public DataSet getConsultarTipodeHistoriaController()
        {
            try
            {
                logica.BL.clsTipodeHistoria obclsTipodeHistoria = new logica.BL.clsTipodeHistoria();
                return obclsTipodeHistoria.getConsultarTipodeHistoria();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public String setAdministrarTipodeHistoriaController(logica.Models.clsTipoHistoria obclsTipoHistoriaModels, int inOpcion)
        {
            try
            {
                logica.BL.clsTipodeHistoria obclsTiposdeHistoria = new logica.BL.clsTipodeHistoria();
                return obclsTiposdeHistoria.setAdministrarTipodeHistoria(obclsTipoHistoriaModels, inOpcion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}