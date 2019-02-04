using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConoceAColombia.web.Controllers
{
    public class LugaresControllers
    {

        public string insertLugares(logica.Models.clsLugares obclsLugaresModels)
        {
            try
            {
                logica.BL.clsLugares obclsLugares = new logica.BL.clsLugares();
                return obclsLugares.insertLugares(obclsLugaresModels);
            }
            catch (Exception ew)
            {
                throw ew;
            }
        }


        public string updateLugares(logica.Models.clsLugares obclsLugaresModels)
        {
            try
            {
                logica.BL.clsLugares obclsLugares = new logica.BL.clsLugares();
                return obclsLugares.updateLugares(obclsLugaresModels);
            }
            catch (Exception ew)
            {
                throw ew;
            }
        }


        public string deleteLugares(logica.Models.clsLugares obclsLugaresModels)
        {
            try
            {
                logica.BL.clsLugares obclsLugares = new logica.BL.clsLugares();
                return obclsLugares.deleteLugares(obclsLugaresModels);
            }
            catch (Exception ew)
            {
                throw ew;
            }
        }

        public List<logica.Models.clsLugares> getLugares()
        {
            try
            {
                logica.BL.clsLugares obclsLugares = new logica.BL.clsLugares();
                return obclsLugares.getLugares();
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
                logica.BL.clsLugares obclsLugares = new logica.BL.clsLugares();
                return obclsLugares.getDepartamentos();
            }
            catch (Exception ew)
            {
                throw ew;
            }
        }


        public List<logica.Models.clsTipoLugares> getTipoLugares()
        {
            try
            {
                logica.BL.clsLugares obclsLugares = new logica.BL.clsLugares();
                return obclsLugares.getTipoLugares();
            }
            catch (Exception ew)
            {
                throw ew;
            }
        }
    }
}