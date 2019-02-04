using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConoceAColombia.web.Controllers
{
    public class TipoLugaresControllers
    {
        public List<logica.Models.clsTipoLugares> getTipoLugares()
        {
            try
            {
                logica.BL.clsTipoLugares obclsTipoLugares = new logica.BL.clsTipoLugares();
                return obclsTipoLugares.getTipoLugares();
            }
            catch (Exception ew)
            {
                throw ew;
            }

        }


        public String insertarTipoLugares(logica.Models.clsTipoLugares obclsTipoLugaresModels)
        {
            try
            {
                logica.BL.clsTipoLugares obclsTipoLugares = new logica.BL.clsTipoLugares();
                return obclsTipoLugares.InsertTipoLugares(obclsTipoLugaresModels);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public String updateTipoLugares(logica.Models.clsTipoLugares obclsTipoLugaresModels)
        {
            try
            {
                logica.BL.clsTipoLugares obclsTipoLugares = new logica.BL.clsTipoLugares();
                return obclsTipoLugares.updateTipoLugares(obclsTipoLugaresModels);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public String deleteTipoLugares(logica.Models.clsTipoLugares obclsTipoLugaresModels)
        {
            try
            {
                logica.BL.clsTipoLugares obclsTipoLugares = new logica.BL.clsTipoLugares();
                return obclsTipoLugares.deleteTipoLugares(obclsTipoLugaresModels);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}