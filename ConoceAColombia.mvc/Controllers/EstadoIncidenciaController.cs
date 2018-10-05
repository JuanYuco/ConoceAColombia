using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConoceAColombia.mvc.Controllers
{
    public class EstadoIncidenciaController : Controller
    {
        // GET: EstadoIncidencia
        public ActionResult Index()
        {
            BL.clsEstadoIncidencia obclsEstadoIncidencia = new BL.clsEstadoIncidencia();

            return View(obclsEstadoIncidencia.getEstadoIncidencia());
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(Models.EstadoIncidencia estado_indicencia)
        {
            if (ModelState.IsValid)
            {
                BL.clsEstadoIncidencia obclsEstadoIncidencia = new BL.clsEstadoIncidencia();
                obclsEstadoIncidencia.createEstadoIncidencia(estado_indicencia);
                return RedirectToAction("Index");
            }

            return View(estado_indicencia);
        }


        public ActionResult Edit(int id)
        {
            BL.clsEstadoIncidencia obclsEstadoIncidencia = new BL.clsEstadoIncidencia();
            Models.EstadoIncidencia estado_incidencia = obclsEstadoIncidencia.getEstadoIncidencia(new Models.EstadoIncidencia { inId = id }).FirstOrDefault();
            return View(estado_incidencia);
        }



        [HttpPost]
        public ActionResult Edit(Models.EstadoIncidencia estado_indicencia)
        {
            if (ModelState.IsValid)
            {
                BL.clsEstadoIncidencia obclsEstadoIncidencia = new BL.clsEstadoIncidencia();
                obclsEstadoIncidencia.updateEstadoIncidencia(estado_indicencia);
                return RedirectToAction("Index");
            }
            return View(estado_indicencia);
        }


        public ActionResult Delete(int id)
        {
            BL.clsEstadoIncidencia obclsEstadoIncidencia = new BL.clsEstadoIncidencia();
            Models.EstadoIncidencia estado_incidencia = obclsEstadoIncidencia.getEstadoIncidencia(new Models.EstadoIncidencia { inId = id }).FirstOrDefault();
            if (estado_incidencia == null)
                return HttpNotFound();
            return View(estado_incidencia);
        }


        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(Models.EstadoIncidencia estado_incidencia)
        {
            BL.clsEstadoIncidencia obclsEstadoIncidencia = new BL.clsEstadoIncidencia();
            obclsEstadoIncidencia.deleteEstadoIncidencia(estado_incidencia);
            return RedirectToAction("Index");
        }


        public ActionResult Details(int id)
        {
            BL.clsEstadoIncidencia obclsEstadoIncidencia = new BL.clsEstadoIncidencia();
            Models.EstadoIncidencia estado_incidencia = obclsEstadoIncidencia.getEstadoIncidencia(new Models.EstadoIncidencia { inId = id }).FirstOrDefault();
            if (estado_incidencia == null)
                return HttpNotFound();
            return View(estado_incidencia);
        }

    }
}