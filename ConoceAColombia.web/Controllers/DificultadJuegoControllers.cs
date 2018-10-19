using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConoceAColombia.web.Controllers
{
    public class DificultadJuegoControllers
    {
        public List<logica.Models.clsDicultadJuego> getDificultadJuego()
        {
            try
            {
                logica.BL.clsDificultadJuego obclsDificultadJuego = new logica.BL.clsDificultadJuego();
                return obclsDificultadJuego.getDificultadJuego();
            }
            catch (Exception ew)
            {
                throw ew;
            }

        }


        public String insertarDificultadJuego(logica.Models.clsDicultadJuego obclDificultadJuegoModels)
        {
            try
            {
                logica.BL.clsDificultadJuego obclsDificultadJuego = new logica.BL.clsDificultadJuego();
                return obclsDificultadJuego.addDificultadJuego(obclDificultadJuegoModels);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public String updateDificultadJuego(logica.Models.clsDicultadJuego obclsDificultadJuegoModels)
        {
            try
            {
                logica.BL.clsDificultadJuego obclsDificultadJuego = new logica.BL.clsDificultadJuego();
                return obclsDificultadJuego.updateDificultadJuego(obclsDificultadJuegoModels);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public String deleteDificultadJuego(logica.Models.clsDicultadJuego obclsDificultadJuegoModels)
        {
            try
            {
                logica.BL.clsDificultadJuego obclsDificultadJuego = new logica.BL.clsDificultadJuego();
                return obclsDificultadJuego.deleteDificultadJuego(obclsDificultadJuegoModels);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}