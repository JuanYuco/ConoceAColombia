using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConoceAColombia.web.Controllers
{
    public class DeportistaControllers
    {
        public List<logica.Models.clsDeportista> getDeportista()
        {
            try
            {
                logica.BL.clsDeportista obclsDeportista = new logica.BL.clsDeportista();
                return obclsDeportista.getDeportista();
            }
            catch (Exception ew)
            {
                throw ew;
            }

        }


        public String insertarDeportista(logica.Models.clsDeportista obclsDeportistaModels)
        {
            try
            {
                logica.BL.clsDeportista obclsDeportista = new logica.BL.clsDeportista();
                return obclsDeportista.InsertDeportista(obclsDeportistaModels);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public String updateDeportista(logica.Models.clsDeportista obclsDeportistaModels)
        {
            try
            {
                logica.BL.clsDeportista obclsDeportista = new logica.BL.clsDeportista();
                return obclsDeportista.updateDeportista(obclsDeportistaModels);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public String deleteDeportista(logica.Models.clsDeportista obclsDeportistaModels)
        {
            try
            {
                logica.BL.clsDeportista obclsDeportista = new logica.BL.clsDeportista();
                return obclsDeportista.deleteDeportista(obclsDeportistaModels);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<logica.Models.clsTipoDeportista> getTipoDeportista()
        {
            try
            {
                logica.BL.clsTipoDeportista obclsTipoDeportista = new logica.BL.clsTipoDeportista();
                return obclsTipoDeportista.getTipoDeportista();
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
                logica.BL.clsDeportista obclsDeportista = new logica.BL.clsDeportista();
                return obclsDeportista.getDepartamentos();
            }
            catch (Exception ew)
            {
                throw ew;
            }

        }

    }
}