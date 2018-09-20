using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace ConoceAColombia.web.Services
{
    /// <summary>
    /// Descripción breve de wsConsulta
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class wsConsulta : System.Web.Services.WebService
    {

        [WebMethod]
        public List<string> getEmpleadosWS(string prefixText, int count)
        {
            logica.BL.clsEmpleados obclsEmpleados =
                new logica.BL.clsEmpleados();

            List<logica.BL.clsEmpleados.clsModelEmpleado> lstclsModelEmpleado =
                obclsEmpleados.getEmpleado(prefixText);

            List<string> lstEmpleados = new List<string>();
            foreach (var elem in lstclsModelEmpleado)
                lstEmpleados.Add(elem.inCodigos + " - " + elem.stNombres + " " + elem.stApellidos);

            return lstEmpleados;
        }


        [WebMethod]
        public List<string> getFloraWS(string prefixText, int count)
        {
            logica.BL.clsFlora obclsFlora =
                new logica.BL.clsFlora();

            List<logica.Models.clsFlora> lstclsModelFlora =
                obclsFlora.getFloraNuevo(prefixText);

            List<string> lstFlora = new List<string>();
            foreach (var elem in lstclsModelFlora)
                lstFlora.Add(elem.lgCodigo + " - " + elem.stNombre + " " + elem.stNombreCientifico);

            return lstFlora;
        }
    }
}
