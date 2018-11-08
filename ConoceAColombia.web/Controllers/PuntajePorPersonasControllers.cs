using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConoceAColombia.web.Controllers
{
    public class PuntajePorPersonasControllers
    {
        public string addPuntajePorPersona(logica.Models.clsPuntajePorPersona clsPuntajePorPersonaModels)
        {
            try
            {
                logica.BL.clsPuntajePorPersona obclsPuntajePorPersona = new logica.BL.clsPuntajePorPersona();
                return obclsPuntajePorPersona.addPuntajePorPersona(clsPuntajePorPersonaModels);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }


        public List<logica.Models.clsPuntajePorPersona> getPuntajePorPersona()
        {
            try
            {
                logica.BL.clsPuntajePorPersona obclsPuntajePorPersona = new logica.BL.clsPuntajePorPersona();
                return obclsPuntajePorPersona.getPuntajePorPersona();
            }catch(Exception ex)
            {
                throw ex;
            }
        }
        

        
    }
}