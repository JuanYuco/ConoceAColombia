using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConoceAColombia.mvc.Controllers
{
    public class IncidenciaController : Controller
    {
        // GET: Incidencia
        public ActionResult Index()
        {
            BL.clsIncidencia incidencias = new BL.clsIncidencia();
            List<Models.Incidencia> lista_incidencias = incidencias.getIncidencia();

            BL.clsEstadoIncidencia estado_incidencias = new BL.clsEstadoIncidencia();
            List<Models.EstadoIncidencia> lista_estado_incidencia = estado_incidencias.getEstadoIncidencia();

            BL.clsTipoIncidencia tipo_incidencias = new BL.clsTipoIncidencia();
            List<Models.TipoIncidencia> lista_tipo_incidencia = tipo_incidencias.GetTipoIncidencia();

            var IndexLoad = new Models.Incidencia.IndexLoad
            {
                Incidencias = lista_incidencias,
                EstadoIncidencias = lista_estado_incidencia,
                TipoIncidencias = lista_tipo_incidencia
            };

            return View(IndexLoad);
        }

        //POST Incidencia/Create
        [HttpPost]
        public ActionResult Create(Models.Incidencia incidencia)
        {
            try
            {
                BL.clsIncidencia incidencias = new BL.clsIncidencia();
                incidencias.CreateIncidencia(incidencia);

                var json = Json(new
                {
                    Mensaje = "Se realizo proceso con exito"
                });
                json.MaxJsonLength = 500000000;

                return json;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}