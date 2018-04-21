using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConoceAColombia.logica.Models
{
    public class clsUsuarios
    {
        public int inCodigo { get; set; }
        public String stNombre { get; set; }
        public String stApellido { get; set;}
        public String stCorreo { get; set; }
        public String stPassword { get; set; }
        public int  inPuntuacionMaxima { get; set; }
        public int inTipo { get; set; }
        public string stUsuaImagen { get; set; }
    }
}
