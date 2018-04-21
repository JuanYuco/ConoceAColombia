using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConoceAColombia.logica.Models
{
    public class clsArquitectura
    {
        public long lgCodigo { get; set; }
        public  clsDepartamentos clsDepartamentos { get; set; }
        public String stNombre { get; set; }
        public String stCiudad { get; set; }
        public String stLatitud { get; set; }
        public String stLongitud { get; set; }
        public clsTipodeArquitectura clsTipodeArquitectura { get; set; }
    }
}
