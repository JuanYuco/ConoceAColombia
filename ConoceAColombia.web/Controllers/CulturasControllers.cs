using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConoceAColombia.web.Controllers
{
    public class CulturasControllers
    {
        public string addCulturas(logica.Models.clsCulturas obclsCulturasModels)
        {
            try{
                logica.BL.clsCulturas obclsCulturas = new logica.BL.clsCulturas();
                return obclsCulturas.addCulturas(obclsCulturasModels);
            }catch(Exception ew)
            {
                throw ew;
            }
        }


        public string updateCulturas(logica.Models.clsCulturas obclsCulturasModels)
        {
            try
            {
                logica.BL.clsCulturas obclsCulturas = new logica.BL.clsCulturas();
                return obclsCulturas.updateCulturas(obclsCulturasModels);
            }catch(Exception ew)
            {
                throw ew;
            }
        }


        public string deleteCulturas(logica.Models.clsCulturas obclsCulturasModels)
        {
            try
            {
                logica.BL.clsCulturas obclsCulturas = new logica.BL.clsCulturas();
                return obclsCulturas.deleteCulturas(obclsCulturasModels);
            }catch(Exception ew)
            {
                throw ew;
            }
        }

        public List<logica.Models.clsCulturas> getCulturas()
        {
            try
            {
                logica.BL.clsCulturas obclsCulturas = new logica.BL.clsCulturas();
                return obclsCulturas.getCulturas();
            }
            catch(Exception ew)
            {
                throw ew;
            }
        }

        public List<logica.Models.clsDepartamentos> getDepartamentos()
        {
            try
            {
                logica.BL.clsCulturas obclsCulturas = new logica.BL.clsCulturas();
                return obclsCulturas.getDepartamentos();
            }catch(Exception ew)
            {
                throw ew;
            }
        }


        public List<logica.Models.clsTipoCulturas> getTipoCulturas()
        {
            try
            {
                logica.BL.clsCulturas obclsCulturas = new logica.BL.clsCulturas();
                return obclsCulturas.getTipoCulturas();
            }
            catch (Exception ew)
            {
                throw ew;
            }
        }

    }
}