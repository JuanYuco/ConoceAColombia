using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConoceAColombia.logica.Models
{
    public class clsMusica
    {
        public long lgCodigo { get; set; }
        public string stNombre { get; set; }
        public string stDescripcion { get; set; }
        public string stImagen { get; set; }
        public String stLatitud { get; set; }
        public String stLongitud { get; set; }
        public clsDepartamentos clsDepartamentos { get; set; }
    }
}
