using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConoceAColombia.web.Controllers
{
    public class JuegoControllers
    {
        public List<logica.Models.clsPreguntasJuego> getPreguntas()
        {
            try
            {
                logica.BL.clsPreguntasJuego obclsPreguntasJuego = new logica.BL.clsPreguntasJuego();
                List<logica.Models.clsPreguntasJuego> lstPreguntas = obclsPreguntasJuego.getPreguntasJuego();
                return lstPreguntas;
            }
            catch (Exception ew)
            {
                throw ew;
            }
        }


        public List<logica.Models.clsPreguntasJuego> getPreguntas(string tematica, string dificultad)
        {
            try
            {
                logica.BL.clsPreguntasJuego obclsPreguntasJuego = new logica.BL.clsPreguntasJuego();
                return obclsPreguntasJuego.getPreguntasJuego(tematica, dificultad);
            }
            catch (Exception ew)
            {
                throw ew;
            }
        }


        public logica.Models.clsPreguntasJuego getPregunta(List<logica.Models.clsPreguntasJuego> lstPreguntasJuego)
        {
            try
            {
                logica.BL.clsPreguntasJuego obclsPreguntasJuego = new logica.BL.clsPreguntasJuego();
                logica.Models.clsPreguntasJuego obPregunta = obclsPreguntasJuego.getPreguntaRamdon(lstPreguntasJuego);
                return obPregunta;
            }
            catch (Exception ew)
            {
                throw ew;
            }
        }


        public void updateEstadoPregunta(logica.Models.clsPreguntasJuego obclsPreguntasJuegoModels)
        {
            logica.BL.clsPreguntasJuego obclsPreguntasJuego = new logica.BL.clsPreguntasJuego();
            obclsPreguntasJuego.updateEstadoPregunta(obclsPreguntasJuegoModels);
        }
    }
}