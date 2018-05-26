using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConoceAColombia.logica.Models
{
    public class clsHistoria
    {
        public long lgCodigo { get; set; }
        public string stNombre { get; set; }
        public string stDescripcion { get; set; }
        public clsTipoHistoria obclsTipoHisotoria { get; set; }
        public string stFechaInicio { get; set; }
        public string stFechaFin { get; set; }
        public clsDepartamentos obclsDepartamentos { get; set; }
        public string stLatitud { get; set; }
        public string stLongitud { get; set; }

    }
}
