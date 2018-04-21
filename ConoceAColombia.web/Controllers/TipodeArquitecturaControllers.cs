using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace ConoceAColombia.web.Controllers
{
    public class TipodeArquitecturaControllers
    {
        public DataSet getConsultarTiposdeArquitecturaController()
        {
            try
            {
                logica.BL.clsTipodeArquitectura obclsTiposdeArquitectura = new logica.BL.clsTipodeArquitectura();
                return obclsTiposdeArquitectura.getConsultarTiposdeArquitectura();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public String setAdmintrarTiposdeArquitecturaController(logica.Models.clsTipodeArquitectura obclsTiposdeArquitecturaModels, int inOpcion)
        {
            try
            {
                logica.BL.clsTipodeArquitectura obclsTiposdeArquitectura = new logica.BL.clsTipodeArquitectura();
                return obclsTiposdeArquitectura.setAdministrarTiposdeArquitectura(obclsTiposdeArquitecturaModels, inOpcion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}