using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConoceAColombia.logica.Models
{
    public class clsDepartamentos
    {
        public virtual long inCodigo { get; set; }
        public virtual String stNombre { get; set; }
        public virtual String stCapital { get; set; }
        public virtual String stGobernador { get; set; }
        public virtual String stMunicipios { get; set; }
        public virtual String stFundacion { get; set; }
        public virtual String stGentilicio { get; set; }
        public virtual String stPoblacion { get; set; }
        public virtual String stLatitud { get; set; }
        public virtual String stDemografia { get; set; }
        public virtual String stLongitud { get; set; }
        public virtual String stSuperficie { get; set; }
    }
}
