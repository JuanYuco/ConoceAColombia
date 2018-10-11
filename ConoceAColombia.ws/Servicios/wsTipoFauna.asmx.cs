using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Newtonsoft.Json;

namespace ConoceAColombia.ws.Servicios
{
    /// <summary>
    /// Descripción breve de wsTipoFauna
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class wsTipoFauna : System.Web.Services.WebService
    {

        [WebMethod]
        public string getTipoFauna()
        {
            logica.BL.clsTipoFauna obclsTipoFauna = new logica.BL.clsTipoFauna();
            return JsonConvert.SerializeObject(obclsTipoFauna.getTipoFauna());
        }

        [WebMethod]
        public void InsertTipoFauna(string stclsTipoFauna)
        {
            logica.BL.clsTipoFauna obclsTipoFauna = new logica.BL.clsTipoFauna();
            logica.Models.clsTipoFauna obclsTipoFaunaModel = JsonConvert.DeserializeObject<logica.Models.clsTipoFauna>(stclsTipoFauna);
            obclsTipoFauna.InsertTipoFauna(obclsTipoFaunaModel);
        }

    }
}
