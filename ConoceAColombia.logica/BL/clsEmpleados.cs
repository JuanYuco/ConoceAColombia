using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConoceAColombia.logica.BL
{
    public class clsEmpleados
    {
        public class clsModelEmpleado
        {
            public int inCodigos { set; get; }
            public string stNombres { get; set; }
            public string stApellidos { get; set; }
        }
        List<clsModelEmpleado> lstclsModelsEmpleado = new List<clsModelEmpleado>();
        public clsEmpleados()
        {
            
            clsModelEmpleado clsModelEmpleado1 = new clsModelEmpleado
            {
                inCodigos = 1,
                stApellidos = "Perez",
                stNombres = "Juan"
            };

            clsModelEmpleado clsModelEmpleado2 = new clsModelEmpleado()
            {
                inCodigos = 2,
                stNombres= "Andres",
                stApellidos="Dias"
            };

            lstclsModelsEmpleado.Add(clsModelEmpleado1);
            lstclsModelsEmpleado.Add(clsModelEmpleado2);
            
        }


        public List<clsModelEmpleado> getEmpleado(string stNombreCompleto)
        {
            return (from q in lstclsModelsEmpleado
                    where (q.stNombres + " " + q.stApellidos).Contains(stNombreCompleto)
                    select q).ToList();
        }
    }
}
