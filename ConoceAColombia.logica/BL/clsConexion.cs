using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Configuration;


namespace ConoceAColombia.logica.BL
{
    public class clsConexion
    {
        /// <summary>
        /// Obtiene Conexion  a base de datos
        /// </summary>
        /// <returns>Cadena de conexion</returns>
        public String getConexion()
        {
            return ConfigurationManager.ConnectionStrings["CAC"].ToString();

        }
    }
}