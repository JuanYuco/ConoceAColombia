using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConoceAColombia.web.Controllers
{
    public class TipoJuegoControllers
    {
        public List<logica.Models.clsTipoJuego> getTipoJuego()
        {
            try
            {
                logica.BL.clsTipoJuego obclsTipoJuego = new logica.BL.clsTipoJuego();
                return obclsTipoJuego.getTipoJuego();
            }
            catch (Exception ew)
            {
                throw ew;
            }

        }


        public String insertarTipoJuego(logica.Models.clsTipoJuego obclTipoJuegoModels)
        {
            try
            {
                logica.BL.clsTipoJuego obclsTipoJuego = new logica.BL.clsTipoJuego();
                return obclsTipoJuego.addTipoJuego(obclTipoJuegoModels);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public String updateTipoJuego(logica.Models.clsTipoJuego obclsTipoJuegoModels)
        {
            try
            {
                logica.BL.clsTipoJuego obclsTipoJuego = new logica.BL.clsTipoJuego();
                return obclsTipoJuego.updateTipoJuego(obclsTipoJuegoModels);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public String deleteTipoJuego(logica.Models.clsTipoJuego obclsTipoJuegoModels)
        {
            try
            {
                logica.BL.clsTipoJuego obclsTipoJuego = new logica.BL.clsTipoJuego();
                return obclsTipoJuego.deleteTipoJuego(obclsTipoJuegoModels);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}