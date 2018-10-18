using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConoceAColombia.web.Controllers
{
    public class TematicasControllers
    {
        public List<logica.Models.clsTematicasJuego> getTematicasJuego()
        {
            try
            {
                logica.BL.clsTematicasJuego obclsTemamticasJuego = new logica.BL.clsTematicasJuego();
                return obclsTemamticasJuego.getTematica();
            }
            catch (Exception ew)
            {
                throw ew;
            }

        }


        public String insertarTematicasJuego(logica.Models.clsTematicasJuego obclTematciasJuegoModels)
        {
            try
            {
                logica.BL.clsTematicasJuego obclsTematicasJuego = new logica.BL.clsTematicasJuego();
                return obclsTematicasJuego.addTematicas(obclTematciasJuegoModels);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public String updateTematicasJuego(logica.Models.clsTematicasJuego obclsTematicasJuegoModels)
        {
            try
            {
                logica.BL.clsTematicasJuego obclsTematicasJuego = new logica.BL.clsTematicasJuego();
                return obclsTematicasJuego.updateTematica(obclsTematicasJuegoModels);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public String deleteTematicasJuego(logica.Models.clsTematicasJuego obclsTematicasJuegoModels)
        {
            try
            {
                logica.BL.clsTematicasJuego obclsTematicasJuego = new logica.BL.clsTematicasJuego();
                return obclsTematicasJuego.deleteTematica(obclsTematicasJuegoModels);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}