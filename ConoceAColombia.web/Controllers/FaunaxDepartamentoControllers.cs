using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConoceAColombia.web.Controllers
{
    public class FaunaxDepartamentoControllers
    {
        public List<logica.Models.clsFaunaxDepartamento> getFaunaxDepartamento()
        {
            try
            {
                logica.BL.clsFaunaxDepartamento obclsFaunaxDepartamento = new logica.BL.clsFaunaxDepartamento();
                return obclsFaunaxDepartamento.getFaunaxDepartamento();
            }
            catch (Exception ew)
            {
                throw ew;
            }

        }


        public String insertarFaunaxDepartamento(logica.Models.clsFaunaxDepartamento obclsFaunaxDepartamentoModels)
        {
            try
            {
                logica.BL.clsFaunaxDepartamento obclsFaunaxDepartamento = new logica.BL.clsFaunaxDepartamento();
                return obclsFaunaxDepartamento.InsertFaunaxDepartamento(obclsFaunaxDepartamentoModels);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public String updateFaunaxDepartamento(logica.Models.clsFaunaxDepartamento obclsFaunaxDepartamentoModels)
        {
            try
            {
                logica.BL.clsFaunaxDepartamento obclsFaunaxDepartamento = new logica.BL.clsFaunaxDepartamento();
                return obclsFaunaxDepartamento.updateFaunaxDepartamento(obclsFaunaxDepartamentoModels);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public String deleteFaunaxDepartamento(logica.Models.clsFaunaxDepartamento obclsFaunaxDepartamentoModels)
        {
            try
            {
                logica.BL.clsFaunaxDepartamento obclsFaunaxDepartamento = new logica.BL.clsFaunaxDepartamento();
                return obclsFaunaxDepartamento.deleteFaunaxDepartamento(obclsFaunaxDepartamentoModels);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<logica.Models.clsFauna> getFauna()
        {
            try
            {
                logica.BL.clsFaunaxDepartamento obclsFaunaxDepartamento = new logica.BL.clsFaunaxDepartamento();
                return obclsFaunaxDepartamento.getFauna();
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
                logica.BL.clsFaunaxDepartamento obclsFaunaxDepartamento = new logica.BL.clsFaunaxDepartamento();
                return obclsFaunaxDepartamento.getDepartamentos();
            }
            catch (Exception ew)
            {
                throw ew;
            }
        }
    }
}