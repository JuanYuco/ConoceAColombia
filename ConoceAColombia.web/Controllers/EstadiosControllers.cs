using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConoceAColombia.web.Controllers
{
    public class EstadiosControllers
    {
        public string insertEstadios(logica.Models.clsEstadios obclsEstadiosModels)
        {
            try
            {
                logica.BL.clsEstadios obclsEstadios = new logica.BL.clsEstadios();
                return obclsEstadios.insertEstadios(obclsEstadiosModels);
            }
            catch (Exception ew)
            {
                throw ew;
            }
        }


        public string updateEstadios(logica.Models.clsEstadios obclsEstadiosModels)
        {
            try
            {
                logica.BL.clsEstadios obclsEstadios = new logica.BL.clsEstadios();
                return obclsEstadios.updateEstadios(obclsEstadiosModels);
            }
            catch (Exception ew)
            {
                throw ew;
            }
        }


        public string deleteEstadios(logica.Models.clsEstadios obclsEstadiosModels)
        {
            try
            {
                logica.BL.clsEstadios obclsEstadios = new logica.BL.clsEstadios();
                return obclsEstadios.deleteEstadios(obclsEstadiosModels);
            }
            catch (Exception ew)
            {
                throw ew;
            }
        }

        public List<logica.Models.clsEstadios> getEstadios()
        {
            try
            {
                logica.BL.clsEstadios obclsEstadios = new logica.BL.clsEstadios();
                return obclsEstadios.getEstadios();
            }
            catch (Exception ew)
            {
                throw ew;
            }
        }

        public List<logica.Models.clsDepartamentos> getDepartamentos()
        {
            try
            {
                logica.BL.clsEstadios obclsEstadios = new logica.BL.clsEstadios();
                return obclsEstadios.getDepartamentos();
            }
            catch (Exception ew)
            {
                throw ew;
            }
        }


        public List<logica.Models.clsDeportes> getDeportes()
        {
            try
            {
                logica.BL.clsEstadios obclsEstadios = new logica.BL.clsEstadios();
                return obclsEstadios.getDeportes();
            }
            catch (Exception ew)
            {
                throw ew;
            }
        }
    }
}