using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConoceAColombia.logica.Models
{
    public class clsPreguntasJuego
    {
        public long lgCodigo { get; set; }
        public string stPregunta { get; set; }
        public string stRespuestaCorrecta { get; set; }
        public string stRespuestaIncorrectaUno { get; set; }
        public string stRespuestaIncorrectaDos { get; set; }
        public string stRespuestaIncorrectaTres { get; set; }
        public string stRespuestaIncorrectaCuatro { get; set; }
        public string stRespuestaIncorrectaCinco { get; set; }
        public clsTematicasJuego obclsTematicasJuego { get; set; }
        public clsTipoJuego obclsTipoJuego { get; set; }
        public clsDicultadJuego obclsDicultadJuego { get; set; }


    }
}
