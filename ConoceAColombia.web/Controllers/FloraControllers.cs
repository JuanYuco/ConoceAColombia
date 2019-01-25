using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace ConoceAColombia.web.Controllers
{
    public class FloraControllers
    {
        public List<logica.Models.clsFlora> getFloraWsController()
        {
            try
            {
                wsFlora.wsFlora obwsFlora = new wsFlora.wsFlora();

                string json = obwsFlora.getFlora();
                List<logica.Models.clsFlora> ltsclsFlora =
                    JsonConvert.DeserializeObject<List<logica.Models.clsFlora>>(json);

                return ltsclsFlora;
            }catch(Exception ew)
            {
                throw ew;
            }
     
        }


        public List<logica.Models.clsFlora> getFlora()
        {
            try
            {
                logica.BL.clsFlora obclsFlora = new logica.BL.clsFlora();
                return obclsFlora.getFlora();
            }catch(Exception ew)
            {
                throw ew;
            }
        }


        public string insertFlora(logica.Models.clsFlora obclsFloraModels)
        {
            try
            {
                logica.BL.clsFlora obclsFlora = new logica.BL.clsFlora();
                return obclsFlora.insertFlora(obclsFloraModels);
            }catch(Exception ew)
            {
                throw ew;
            }
        }

        public string updateFlora(logica.Models.clsFlora obclsFloraModels)
        {
            try
            {
                logica.BL.clsFlora obclsFlora = new logica.BL.clsFlora();
                return obclsFlora.updateFlora(obclsFloraModels);
            }catch(Exception ew)
            {
                throw ew;
            }
        }


        public string deleteFlora(logica.Models.clsFlora obclsFloraModels)
        {
            try
            {
                logica.BL.clsFlora obclsFlora = new logica.BL.clsFlora();
                return obclsFlora.deleteFlora(obclsFloraModels);
            }catch(Exception ew)
            {
                throw ew;
            }
        }


        public List<logica.Models.clsTipoFlora> getTipoFlora()
        {
            try
            {
                logica.BL.clsFlora obclsFlora = new logica.BL.clsFlora();
                return obclsFlora.getTipoFlora();
            }catch(Exception ew)
            {
                throw ew;
            }
        } 

    }
}