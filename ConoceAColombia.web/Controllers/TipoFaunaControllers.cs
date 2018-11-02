using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConoceAColombia.web.Controllers
{
    public class TipoFaunaControllers
    {
        public List<logica.Models.clsTipoFauna> getTipoFauna()
        {
            try
            {
                logica.BL.clsTipoFauna obclsTipoFauna = new logica.BL.clsTipoFauna();
                return obclsTipoFauna.getTipoFauna();
            }
            catch (Exception ew)
            {
                throw ew;
            }

        }


        public String insertarTipoFauna(logica.Models.clsTipoFauna obclTipoFaunaModels)
        {
            try
            {
                logica.BL.clsTipoFauna obclsTipoFauna = new logica.BL.clsTipoFauna();
                return obclsTipoFauna.InsertTipoFauna(obclTipoFaunaModels);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public String updateTipoFauna(logica.Models.clsTipoFauna obclsTipoFaunaModels)
        {
            try
            {
                logica.BL.clsTipoFauna obclsTipoFauna = new logica.BL.clsTipoFauna();
                return obclsTipoFauna.updateTipoFauna(obclsTipoFaunaModels);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public String deleteTipoJuego(logica.Models.clsTipoFauna obclsTipoFaunaModels)
        {
            try
            {
                logica.BL.clsTipoFauna obclsTipoFauna = new logica.BL.clsTipoFauna();
                return obclsTipoFauna.deleteTipoFauna(obclsTipoFaunaModels);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}