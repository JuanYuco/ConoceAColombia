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
    }
}