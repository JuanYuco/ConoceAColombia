using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConoceAColombia.web.Controllers
{
    public class TipoFloraControllers
    {
        public List<logica.Models.clsTipoFlora> getTipoFlora()
        {
            try
            {
                logica.BL.clsTipoFlora obclsTipoFlora = new logica.BL.clsTipoFlora();
                return obclsTipoFlora.getTipoFlora();
            }
            catch (Exception ew)
            {
                throw ew;
            }

        }


        public String insertarTipoFlora(logica.Models.clsTipoFlora obclTipoFloraModels)
        {
            try
            {
                logica.BL.clsTipoFlora obclsTipoFlora = new logica.BL.clsTipoFlora();
                return obclsTipoFlora.InsertTipoFlora(obclTipoFloraModels);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public String updateTipoFlora(logica.Models.clsTipoFlora obclsTipoFloraModels)
        {
            try
            {
                logica.BL.clsTipoFlora obclsTipoFlora = new logica.BL.clsTipoFlora();
                return obclsTipoFlora.updateTipoFlora(obclsTipoFloraModels);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public String deleteTipoFlora(logica.Models.clsTipoFlora obclsTipoFloraModels)
        {
            try
            {
                logica.BL.clsTipoFlora obclsTipoFlora = new logica.BL.clsTipoFlora();
                return obclsTipoFlora.deleteTipoFlora(obclsTipoFloraModels);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}