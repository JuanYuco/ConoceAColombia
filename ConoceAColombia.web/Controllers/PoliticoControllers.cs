using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConoceAColombia.web.Controllers
{
    public class PoliticoControllers
    {
        public List<logica.Models.clsPolitico> getPolitico()
        {
            try
            {
                logica.BL.clsPolitico obclsPolitico = new logica.BL.clsPolitico();
                return obclsPolitico.getPolitico();
            }
            catch (Exception ew)
            {
                throw ew;
            }

        }


        public String insertarPolitico(logica.Models.clsPolitico obclsPoliticoModels)
        {
            try
            {
                logica.BL.clsPolitico obclsPolitico = new logica.BL.clsPolitico();
                return obclsPolitico.InsertPolitico(obclsPoliticoModels);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public String updatePolitico(logica.Models.clsPolitico obclsPoliticoModels)
        {
            try
            {
                logica.BL.clsPolitico obclsPolitico = new logica.BL.clsPolitico();
                return obclsPolitico.updatePolitico(obclsPoliticoModels);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public String deletePolitico(logica.Models.clsPolitico obclsPoliticoModels)
        {
            try
            {
                logica.BL.clsPolitico obclsPolitico = new logica.BL.clsPolitico();
                return obclsPolitico.deletePoliticio(obclsPoliticoModels);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<logica.Models.clsTipoPolitico> getTipoPolitico()
        {
            try
            {
                logica.BL.clsPolitico obclsPolitico = new logica.BL.clsPolitico();
                return obclsPolitico.getTipoPolitico();
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
                logica.BL.clsPolitico obclsPolitico = new logica.BL.clsPolitico();
                return obclsPolitico.getDepartamentos();
            }
            catch (Exception ew)
            {
                throw ew;
            }

        }
    }
}