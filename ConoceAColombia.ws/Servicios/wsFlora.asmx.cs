using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Newtonsoft.Json;

namespace ConoceAColombia.ws.Servicios
{
    /// <summary>
    /// Descripción breve de wsFlora
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class wsFlora : System.Web.Services.WebService
    {

        [WebMethod]
        public string getFlora()
        {
            logica.BL.clsFlora obclsFlora = new logica.BL.clsFlora();
            return JsonConvert.SerializeObject(obclsFlora.getFlora());
        }
        [WebMethod]
        public void InsertFlora(string stclsFlora)
        {
            logica.BL.clsFlora obclsFlora = new logica.BL.clsFlora();
            logica.Models.clsFlora obclsFloraModel = JsonConvert.DeserializeObject<logica.Models.clsFlora>(stclsFlora);
            obclsFlora.InsertFlora(obclsFloraModel);
        }
    }
}
