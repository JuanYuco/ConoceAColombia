using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;


namespace ConoceAColombia.web.Controllers
{
    public class DepartamentosControllers
    {
        public DataSet getConsultarPosiblesClientesController()
        {
            try
            {
                logica.BL.clsDepartamentos obclsDepartamentos = new logica.BL.clsDepartamentos();
                return obclsDepartamentos.getConsultarDepartamentos();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public String setAdmintrarDepartamentosController(logica.Models.clsDepartamentos obclsDepartamentosModels, int inOpcion)
        {
            try
            {
                logica.BL.clsDepartamentos obclsDepartamentos = new logica.BL.clsDepartamentos();
                return obclsDepartamentos.setAdministrarDepartamentos(obclsDepartamentosModels, inOpcion);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

    }
}