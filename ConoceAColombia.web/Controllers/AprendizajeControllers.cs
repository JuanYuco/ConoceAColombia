using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConoceAColombia.web.Controllers
{
    public class AprendizajeControllers
    {
        public List<logica.Models.clsAprendizaje> getAprendizaje()
        {
            try
            {
                logica.BL.clsAprendizaje obclsAprendizaje = new logica.BL.clsAprendizaje();
                return obclsAprendizaje.getAprendizaje();
            }
            catch (Exception ew)
            {
                throw ew;
            }

        }


        public String insertarAprendizaje(logica.Models.clsAprendizaje obclsAprendizajeModels)
        {
            try
            {
                logica.BL.clsAprendizaje obclsAprendizaje = new logica.BL.clsAprendizaje();
                return obclsAprendizaje.InsertAprendizaje(obclsAprendizajeModels);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public String updateAprendizaje(logica.Models.clsAprendizaje obclsAprendizajeModels)
        {
            try
            {
                logica.BL.clsAprendizaje obclsAprendizaje = new logica.BL.clsAprendizaje();
                return obclsAprendizaje.updateAprendizaje(obclsAprendizajeModels);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public String deleteAprendizaje(logica.Models.clsAprendizaje obclsAprendizajeModels)
        {
            try
            {
                logica.BL.clsAprendizaje obclsAprendizaje = new logica.BL.clsAprendizaje();
                return obclsAprendizaje.deleteAprendizaje(obclsAprendizajeModels);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<logica.Models.clsTipoAprendizaje> getTipoAprendizaje()
        {
            try
            {
                logica.BL.clsAprendizaje obclsAprendizaje = new logica.BL.clsAprendizaje();
                return obclsAprendizaje.getTipoAprendizaje();
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
                logica.BL.clsAprendizaje obclsAprendizaje = new logica.BL.clsAprendizaje();
                return obclsAprendizaje.getDepartamentos();
            }
            catch (Exception ew)
            {
                throw ew;
            }

        }
    }
}