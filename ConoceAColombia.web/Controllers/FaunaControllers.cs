using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConoceAColombia.web.Controllers
{
    public class FaunaControllers
    {
        public List<logica.Models.clsFauna> getFauna()
        {
            try
            {
                logica.BL.clsFauna obclsFauna = new logica.BL.clsFauna();
                return obclsFauna.getFauna();
            }
            catch (Exception ew)
            {
                throw ew;
            }

        }


        public String insertarFauna(logica.Models.clsFauna obclsFaunaModels)
        {
            try
            {
                logica.BL.clsFauna obclsFauna = new logica.BL.clsFauna();
                return obclsFauna.InsertFauna(obclsFaunaModels);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public String updateFauna(logica.Models.clsFauna obclsFaunaModels)
        {
            try
            {
                logica.BL.clsFauna obclsFauna = new logica.BL.clsFauna();
                return obclsFauna.updateFauna(obclsFaunaModels);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public String deleteFauna(logica.Models.clsFauna obclsFaunaModels)
        {
            try
            {
                logica.BL.clsFauna obclsFauna = new logica.BL.clsFauna();
                return obclsFauna.deleteFauna(obclsFaunaModels);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

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
    }
}