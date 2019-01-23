using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConoceAColombia.web.Controllers
{
    public class TipoPoliticoControllers
    {
        public List<logica.Models.clsTipoPolitico> getTipoPolitico()
        {
            try
            {
                logica.BL.clsTipoPolitico obclsTipoPolitico = new logica.BL.clsTipoPolitico();
                return obclsTipoPolitico.getTipoPolitico();
            }
            catch (Exception ew)
            {
                throw ew;
            }

        }


        public String insertarTipoPolitico(logica.Models.clsTipoPolitico obclTipoPoliticoModels)
        {
            try
            {
                logica.BL.clsTipoPolitico obclsTipoPolitico = new logica.BL.clsTipoPolitico();
                return obclsTipoPolitico.InsertTipoPolitico(obclTipoPoliticoModels);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public String updateTipoPolitico(logica.Models.clsTipoPolitico obclsTipoPoliticoModels)
        {
            try
            {
                logica.BL.clsTipoPolitico obclsTipoPolitico = new logica.BL.clsTipoPolitico();
                return obclsTipoPolitico.updateTipoPolitico(obclsTipoPoliticoModels);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public String deleteTipoPolitico(logica.Models.clsTipoPolitico obclsTipoPoliticoModels)
        {
            try
            {
                logica.BL.clsTipoPolitico obclsTipoPolitico = new logica.BL.clsTipoPolitico();
                return obclsTipoPolitico.deleteTipoPolitico(obclsTipoPoliticoModels);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}