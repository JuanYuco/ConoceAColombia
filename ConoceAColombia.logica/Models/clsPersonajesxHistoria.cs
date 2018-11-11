using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConoceAColombia.logica.Models
{
    public class clsPersonajesxHistoria
    {
        public long lgCodigo { get; set; }
        public clsPersonajesHistoricos obclsPersonajesHistoricos { get; set; }
        public clsHistoria obclsHistoria { get; set; }
    }
}
