using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConoceAColombia.logica.Models
{
    public class clsFlora
    {
        public long lgCodigo { get; set; }
        public string stNombreCientifico { get; set; }
        public string stNombre { get; set; }
        public string stDescripcion { get; set; }
        public string stAbundancia  { get; set; }
        public string stPeriodoFloracion { get; set; }
        public string stLatitud { get; set; }
        public string stLongitud { get; set; }
        public clsDepartamentos obclsDepartamentos { get; set; }

    }
}
