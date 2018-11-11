using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace ConoceAColombia.web.Controllers
{
    public class FloraControllers
    {
        public List<logica.Models.clsFlora> getFloraController()
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


        public string addFlora(logica.Models.clsFlora obclsFloraModels)
        {
            try
            {
                logica.BL.clsFlora obclsFlora = new logica.BL.clsFlora();
                return obclsFlora.addFlora(obclsFloraModels);
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


        public List<logica.Models.clsDepartamentos> getDepartamentos()
        {
            try
            {
                logica.BL.clsFlora obclsFlora = new logica.BL.clsFlora();
                return obclsFlora.getDepartamentos();
            }catch(Exception ew)
            {
                throw ew;
            }
        } 

    }
}