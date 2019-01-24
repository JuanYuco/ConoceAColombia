using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConoceAColombia.web.Controllers
{
    public class TipoAprendizajeControllers
    {
        public List<logica.Models.clsTipoAprendizaje> getTipoAprendizaje()
        {
            try
            {
                logica.BL.clsTipoAprendizaje obclsTipoAprendizaje = new logica.BL.clsTipoAprendizaje();
                return obclsTipoAprendizaje.getTipoAprendizaje();
            }
            catch (Exception ew)
            {
                throw ew;
            }

        }


        public String insertarTipoAprendizaje(logica.Models.clsTipoAprendizaje obclsTipoAprendizajeModels)
        {
            try
            {
                logica.BL.clsTipoAprendizaje obclsTipoAprendizaje = new logica.BL.clsTipoAprendizaje();
                return obclsTipoAprendizaje.InsertTipoAprendizaje(obclsTipoAprendizajeModels);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public String updateTipoAprendizaje(logica.Models.clsTipoAprendizaje obclsTipoAprendizajeModels)
        {
            try
            {
                logica.BL.clsTipoAprendizaje obclsTipoAprendizaje = new logica.BL.clsTipoAprendizaje();
                return obclsTipoAprendizaje.updateTipoAprendizaje(obclsTipoAprendizajeModels);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public String deleteTipoAprendizaje(logica.Models.clsTipoAprendizaje obclsTipoAprendizajeModels)
        {
            try
            {
                logica.BL.clsTipoAprendizaje obclsTipoAprendizaje = new logica.BL.clsTipoAprendizaje();
                return obclsTipoAprendizaje.deleteTipoAprendizaje(obclsTipoAprendizajeModels);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}