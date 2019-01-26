using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConoceAColombia.web.Controllers
{
    public class TipoCulturasControllers
    {
        public List<logica.Models.clsTipoCulturas> getTipoCulturas()
        {
            try
            {
                logica.BL.clsTipoCulturas obclsTipoCulturas = new logica.BL.clsTipoCulturas();
                return obclsTipoCulturas.getTipoCulturas();
            }
            catch (Exception ew)
            {
                throw ew;
            }

        }


        public String insertarTipoCulturas(logica.Models.clsTipoCulturas obclTipoCulturasModels)
        {
            try
            {
                logica.BL.clsTipoCulturas obclsTipoCulturas = new logica.BL.clsTipoCulturas();
                return obclsTipoCulturas.InsertTipoCulturas(obclTipoCulturasModels);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public String updateTipoCulturas(logica.Models.clsTipoCulturas obclsTipoCulturasModels)
        {
            try
            {
                logica.BL.clsTipoCulturas obclsTipoCulturas = new logica.BL.clsTipoCulturas();
                return obclsTipoCulturas.updateTipoCulturas(obclsTipoCulturasModels);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public String deleteTipoCulturas(logica.Models.clsTipoCulturas obclsTipoCulturasModels)
        {
            try
            {
                logica.BL.clsTipoCulturas obclsTipoCulturas = new logica.BL.clsTipoCulturas();
                return obclsTipoCulturas.deleteTipoCulturas(obclsTipoCulturasModels);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}