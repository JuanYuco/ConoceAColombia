using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConoceAColombia.web.Controllers
{
    public class TipoDeportistaControllers
    {
        public List<logica.Models.clsTipoDeportista> getTipoDeportista()
        {
            try
            {
                logica.BL.clsTipoDeportista obclsTipoDeportista = new logica.BL.clsTipoDeportista();
                return obclsTipoDeportista.getTipoDeportista();
            }
            catch (Exception ew)
            {
                throw ew;
            }

        }


        public String insertarTipoDeportista(logica.Models.clsTipoDeportista obclTipoDeportistaModels)
        {
            try
            {
                logica.BL.clsTipoDeportista obclsTipoDeportista = new logica.BL.clsTipoDeportista();
                return obclsTipoDeportista.InsertTipoDeportista(obclTipoDeportistaModels);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public String updateTipoDeportista(logica.Models.clsTipoDeportista obclsTipoDeportistaModels)
        {
            try
            {
                logica.BL.clsTipoDeportista obclsTipoDeportista = new logica.BL.clsTipoDeportista();
                return obclsTipoDeportista.updateTipoDeportista(obclsTipoDeportistaModels);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public String deleteTipoDeportista(logica.Models.clsTipoDeportista obclsTipoDeportistaModels)
        {
            try
            {
                logica.BL.clsTipoDeportista obclsTipoDeportista = new logica.BL.clsTipoDeportista();
                return obclsTipoDeportista.deleteTipoDeportista(obclsTipoDeportistaModels);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}