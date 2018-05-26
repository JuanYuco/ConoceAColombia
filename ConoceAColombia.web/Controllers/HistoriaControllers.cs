using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace ConoceAColombia.web.Controllers
{
    public class HistoriaControllers
    {
        public DataSet getConsultarHistoriaController()
        {
            try
            {
                logica.BL.clsHistoria obclsHistoria = new logica.BL.clsHistoria();
                return obclsHistoria.getConsultarHistoria();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public String setAdministarHistoriaController(logica.Models.clsHistoria obclsHistoriaModels, int inOpcion)
        {
            try
            {
                logica.BL.clsHistoria obclsHistoria = new logica.BL.clsHistoria();
                return obclsHistoria.setAdministrarHistoria(obclsHistoriaModels, inOpcion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}