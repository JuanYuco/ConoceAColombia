using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace ConoceAColombia.web.Controllers
{
    public class PersoanesxHistoriaControllers
    {
        public DataSet getConsultarPersonajesxHistoriaController()
        {
            try
            {
                logica.BL.clsPersonajesxHistoria obclsPersonajexHistoria = new logica.BL.clsPersonajesxHistoria();
                return obclsPersonajexHistoria.getConsultarPersoanjesxHistoria();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public String setAdministarPersonajexHistoriaController(logica.Models.clsPersonajesxHistoria obclsPersonajexHistoriaModels, int inOpcion)
        {
            try
            {
                logica.BL.clsPersonajesxHistoria obclsPersonajesxHistoria = new logica.BL.clsPersonajesxHistoria();
                return obclsPersonajesxHistoria.setAdministrarPersonajexHistoria(obclsPersonajexHistoriaModels, inOpcion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}