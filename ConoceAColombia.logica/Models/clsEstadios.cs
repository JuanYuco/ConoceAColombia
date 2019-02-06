using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConoceAColombia.logica.Models
{
    public class clsEstadios
    {
        public long lgCodigo { get; set; }
        public string stNombre { get; set; }
        public string stDescripcion { get; set; }
        public string  stFundacion { get; set; }
        public string stCapacidad { get; set; }
        public string stCiudad { get; set; }
        public string stImagen { get; set; }
        public string stLatitud { get; set; }
        public string stLongitud { get; set; }
        public clsDepartamentos obclsDepartamento { get; set; }
        public clsDeportes obclsDeporte { get; set; }
    }
}
