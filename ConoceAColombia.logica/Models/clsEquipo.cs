using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConoceAColombia.logica.Models
{
    public class clsEquipo
    {
        public virtual long lgCodigo { get; set; }
        public virtual string  stNombre { get; set; }
        public virtual string stDescripcion { get; set; }
        public virtual string stPresidente { get; set; }
        public virtual string stFundacion { get; set; }
        public virtual string stCiudad { get; set; }
        public virtual string stLatitud { get; set; }
        public virtual string stLongitud { get; set; }
        public virtual clsDeportes obclsDeportes { get; set; }
        public virtual clsDepartamentos obclsDepartamentos { get; set; }
    }
}
