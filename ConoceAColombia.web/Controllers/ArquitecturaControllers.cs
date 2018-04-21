using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace ConoceAColombia.web.Controllers
{
    public class ArquitecturaControllers
    {
        public DataSet getConsultarArquitecturaController()
        {
            try
            {
                logica.BL.clsArquitectura obclsArquitectura = new logica.BL.clsArquitectura();
                return obclsArquitectura.getConsultarArquitectura();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public String setAdministarArquitecturaController(logica.Models.clsArquitectura obclsArquitecturaModels, int inOpcion)
        {
            try
            {
                logica.BL.clsArquitectura obclsArquitectura = new logica.BL.clsArquitectura();
                return obclsArquitectura.setAdministrarArquitectura(obclsArquitecturaModels, inOpcion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}