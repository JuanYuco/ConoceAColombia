using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace ConoceAColombia.web.Controllers
{
    public class PersonajesHistoricosControllers
    {
        public DataSet getConsultarPersonajesHistoricosController()
        {
            try
            {
                logica.BL.clsPersonajesHistoricos obclsPersonajesHistoricos = new logica.BL.clsPersonajesHistoricos();
                return obclsPersonajesHistoricos.getConsultarPersonajesHistoricos();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public String setAdministarPersonajesHistoricosController(logica.Models.clsPersonajesHistoricos obclsPersonajesHistoricosModels, int inOpcion)
        {
            try
            {
                logica.BL.clsPersonajesHistoricos obclsPersonajesHistoricos = new logica.BL.clsPersonajesHistoricos();
                return obclsPersonajesHistoricos.setAdministrarPersonajesHistoricos(obclsPersonajesHistoricosModels, inOpcion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}