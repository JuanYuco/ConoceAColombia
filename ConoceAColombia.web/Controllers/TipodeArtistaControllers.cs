using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace ConoceAColombia.web.Controllers
{
    public class TipodeArtistaControllers
    {
        public DataSet getConsultarTipodeArtistaController()
        {
            try
            {
                logica.BL.clsTipodeArtista obclsTipodeArtista = new logica.BL.clsTipodeArtista();
                return obclsTipodeArtista.getConsultarTiposdeArtista();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public String setAdmintrarTipodeArtistaController(logica.Models.clsTipodeArtista obclsTipodeArtistaModels, int inOpcion)
        {
            try
            {
                logica.BL.clsTipodeArtista obclsTipodeArtista = new logica.BL.clsTipodeArtista();
                return obclsTipodeArtista.setAdministrarTiposdeArtista(obclsTipodeArtistaModels, inOpcion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}