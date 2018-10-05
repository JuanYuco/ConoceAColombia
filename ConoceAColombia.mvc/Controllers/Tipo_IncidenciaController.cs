using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ConoceAColombia.mvc.DAL;

namespace ConoceAColombia.mvc.Controllers
{
    public class Tipo_IncidenciaController : Controller
    {
        private bdConoceAColombiaEntities db = new bdConoceAColombiaEntities();

        // GET: Tipo_Incidencia
        public ActionResult Index()
        {
            return View(db.Tipo_Incidencia.ToList());
        }

        // GET: Tipo_Incidencia/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_Incidencia tipo_Incidencia = db.Tipo_Incidencia.Find(id);
            if (tipo_Incidencia == null)
            {
                return HttpNotFound();
            }
            return View(tipo_Incidencia);
        }

        // GET: Tipo_Incidencia/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tipo_Incidencia/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,descripcion")] Tipo_Incidencia tipo_Incidencia)
        {
            if (ModelState.IsValid)
            {
                db.Tipo_Incidencia.Add(tipo_Incidencia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipo_Incidencia);
        }

        // GET: Tipo_Incidencia/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_Incidencia tipo_Incidencia = db.Tipo_Incidencia.Find(id);
            if (tipo_Incidencia == null)
            {
                return HttpNotFound();
            }
            return View(tipo_Incidencia);
        }

        // POST: Tipo_Incidencia/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,descripcion")] Tipo_Incidencia tipo_Incidencia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipo_Incidencia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipo_Incidencia);
        }

        // GET: Tipo_Incidencia/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_Incidencia tipo_Incidencia = db.Tipo_Incidencia.Find(id);
            if (tipo_Incidencia == null)
            {
                return HttpNotFound();
            }
            return View(tipo_Incidencia);
        }

        // POST: Tipo_Incidencia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tipo_Incidencia tipo_Incidencia = db.Tipo_Incidencia.Find(id);
            db.Tipo_Incidencia.Remove(tipo_Incidencia);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
