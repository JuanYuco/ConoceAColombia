using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConoceAColombia.mvc.Models
{
    public class Incidencia
    {
        public int Id { get; set; }
        public long Identificacion { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public EstadoIncidencia estadoIncidencia { get; set; }
        public TipoIncidencia TipoIncidencia { get; set; }

    }
}