using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConoceAColombia.web.Controllers
{
    public class PreguntasJuegoControllers
    {
        public List<logica.Models.clsPreguntasJuego> getPreguntasJuego()
        {
            try
            {
                logica.BL.clsPreguntasJuego obclsPreguntasJuego = new logica.BL.clsPreguntasJuego();
                return obclsPreguntasJuego.getPreguntasJuego();
            }
            catch (Exception ew)
            {
                throw ew;
            }

        }


       


        public String insertarPreguntasJuego(logica.Models.clsPreguntasJuego obclPreguntasJuegoModels)
        {
            try
            {
                logica.BL.clsPreguntasJuego obclsPreguntasJuego = new logica.BL.clsPreguntasJuego();
                return obclsPreguntasJuego.addPreguntasJuego(obclPreguntasJuegoModels);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public String updatePreguntasJuego(logica.Models.clsPreguntasJuego obclsPreguntasJuegoModels)
        {
            try
            {
                logica.BL.clsPreguntasJuego obclsPreguntasJuego = new logica.BL.clsPreguntasJuego();
                return obclsPreguntasJuego.updatePreguntasJuego(obclsPreguntasJuegoModels);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public String deletePreguntasJuego(logica.Models.clsPreguntasJuego obclsPreguntasJuegoModels)
        {
            try
            {
                logica.BL.clsPreguntasJuego obclsPreguntasJuego = new logica.BL.clsPreguntasJuego();
                return obclsPreguntasJuego.deletePreguntasJuego(obclsPreguntasJuegoModels);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<logica.Models.clsTematicasJuego> getTematicasJuego()
        {
            try
            {
                logica.BL.clsPreguntasJuego obclsPreguntasJuego = new logica.BL.clsPreguntasJuego();
                return obclsPreguntasJuego.getTematica();
            }
            catch (Exception ew)
            {
                throw ew;
            }
        }

        public List<logica.Models.clsTipoJuego> getTipoJuego()
        {
            try
            {
                logica.BL.clsPreguntasJuego obclsPreguntasJuego = new logica.BL.clsPreguntasJuego();
                return obclsPreguntasJuego.getTipoJuego();
            }
            catch (Exception ew)
            {
                throw ew;
            }

        }

        public List<logica.Models.clsDicultadJuego> getDificultadJuego()
        {
            try
            {
                logica.BL.clsPreguntasJuego obclsPreguntasJuego = new logica.BL.clsPreguntasJuego();
                return obclsPreguntasJuego.getDificultadJuego();
            }
            catch (Exception ew)
            {
                throw ew;
            }

        }

    }
}