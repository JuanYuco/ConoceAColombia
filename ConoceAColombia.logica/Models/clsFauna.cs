using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConoceAColombia.logica.Models
{
    public class clsFauna
    {
        public long lgCodigo { get; set; }
        public string stNombre { get; set; }
        public string stDescripcion { get; set; }
        public clsTipoFauna obclsTipoFauna { get; set; }
    }
}
