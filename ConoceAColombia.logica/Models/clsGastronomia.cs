using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConoceAColombia.logica.Models
{
    public class clsGastronomia
    {
        public long lgCodigo { get; set; }
        public String stNombre { get; set; }
        public String stDescripcion { get; set; }
        public String stCiudad { get; set; }
        public String stImagen { get; set; }
        public String stLatitud { get; set; }
        public String stLongitud { get; set; }
        public clsDepartamentos clsDepartamentos { get; set; }
        public clsTipodeGastronomia clsTipodeGastronomia { get; set; }
    }
}
