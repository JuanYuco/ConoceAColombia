using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConoceAColombia.logica.Models
{
    public class clsCorreo
    {
        public string stServidor { get; set; }
        public string stUsuario { get; set; }
        public string stPassword { get; set; }
        public bool blConexionSegura  { get; set; }
        public bool blAutenticacion { get; set; }
        public string stFrom { get; set; }
        public string stTo { get; set; }
        public string stAsunto { get; set; }
        public string stMensaje { get; set; }
        public int inTipo { get; set; }
        public int inPrioridad { get; set; }
        public string stPuerto { get; set; }
        public string stImage { get; set; }
        public string stIdImage { get; set; }
    }
}
