using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConoceAColombia.web.Controllers
{
    public class FloraxDepartamentoControllers
    {
        public List<logica.Models.clsFloraxDepartamento> getFloraxDepartamento()
        {
            try
            {
                logica.BL.clsFloraxDepartamento obclsFloraxDepartamento = new logica.BL.clsFloraxDepartamento();
                return obclsFloraxDepartamento.getFloraxDepartamento();
            }
            catch (Exception ew)
            {
                throw ew;
            }

        }


        public String insertarFloraxDepartamento(logica.Models.clsFloraxDepartamento obclsFloraxDepartamentoModels)
        {
            try
            {
                logica.BL.clsFloraxDepartamento obclsFloraxDepartamento = new logica.BL.clsFloraxDepartamento();
                return obclsFloraxDepartamento.InsertFloraxDepartamento(obclsFloraxDepartamentoModels);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public String updateFloraxDepartamento(logica.Models.clsFloraxDepartamento obclsFloraxDepartamentoModels)
        {
            try
            {
                logica.BL.clsFloraxDepartamento obclsFloraxDepartamento = new logica.BL.clsFloraxDepartamento();
                return obclsFloraxDepartamento.updateFloraxDepartamento(obclsFloraxDepartamentoModels);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public String deleteFloraxDepartamento(logica.Models.clsFloraxDepartamento obclsFloraxDepartamentoModels)
        {
            try
            {
                logica.BL.clsFloraxDepartamento obclsFloraxDepartamento = new logica.BL.clsFloraxDepartamento();
                return obclsFloraxDepartamento.deleteFloraxDepartamento(obclsFloraxDepartamentoModels);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<logica.Models.clsFlora> getFlora()
        {
            try
            {
                logica.BL.clsFloraxDepartamento obclsFloraxDepartamento = new logica.BL.clsFloraxDepartamento();
                return obclsFloraxDepartamento.getFlora();
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
                logica.BL.clsFloraxDepartamento obclsFloraxDepartamento = new logica.BL.clsFloraxDepartamento();
                return obclsFloraxDepartamento.getDepartamentos();
            }
            catch (Exception ew)
            {
                throw ew;
            }
        }
    }
}