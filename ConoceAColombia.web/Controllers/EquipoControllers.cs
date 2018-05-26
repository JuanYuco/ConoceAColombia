using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConoceAColombia.web.Controllers
{
    public class EquipoControllers
    {
        public List<logica.Models.clsEquipo> getEquipo()
        {
            try
            {
                logica.BL.clsEquipo obclsEquipo = new logica.BL.clsEquipo();
                return obclsEquipo.getEquipo();

            }
            catch(Exception ew)
            {
                throw ew;
            }
        }

        public string addEquipo(logica.Models.clsEquipo obclsEquipoModels)
        {
            try
            {
                logica.BL.clsEquipo obclsEquipo = new logica.BL.clsEquipo();
                return obclsEquipo.addEquipo(obclsEquipoModels);
            }catch(Exception ew)
            {
                throw ew;
            }
        }

        public string deleteEquipo(logica.Models.clsEquipo obclsEquipoModels)
        {
            try
            {
                logica.BL.clsEquipo obclsEquipo = new logica.BL.clsEquipo();
                return obclsEquipo.deleteEquipo(obclsEquipoModels);

            }catch(Exception ew)
            {
                throw ew;
            }
        }
    }
}