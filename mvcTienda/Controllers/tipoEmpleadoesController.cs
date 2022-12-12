using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using mvcTienda;

namespace mvcTienda.Controllers
{
    public class tipoEmpleadoesController : Controller
    {
        private TiendaEntities db = new TiendaEntities();

        // GET: tipoEmpleadoes
        public ActionResult Index()
        {
            return View(db.tipoEmpleado.ToList());
        }

        // GET: tipoEmpleadoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipoEmpleado tipoEmpleado = db.tipoEmpleado.Find(id);
            if (tipoEmpleado == null)
            {
                return HttpNotFound();
            }
            return View(tipoEmpleado);
        }

        // GET: tipoEmpleadoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tipoEmpleadoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idtipoEmpleado,tipo,estatus,idusuarioCrea,idusuarioModifica")] tipoEmpleado tipoEmpleado)
        {
            if (ModelState.IsValid)
            {
                db.tipoEmpleado.Add(tipoEmpleado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoEmpleado);
        }

        // GET: tipoEmpleadoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipoEmpleado tipoEmpleado = db.tipoEmpleado.Find(id);
            if (tipoEmpleado == null)
            {
                return HttpNotFound();
            }
            return View(tipoEmpleado);
        }

        // POST: tipoEmpleadoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idtipoEmpleado,tipo,estatus,idusuarioCrea,idusuarioModifica")] tipoEmpleado tipoEmpleado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoEmpleado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoEmpleado);
        }

        // GET: tipoEmpleadoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipoEmpleado tipoEmpleado = db.tipoEmpleado.Find(id);
            if (tipoEmpleado == null)
            {
                return HttpNotFound();
            }
            return View(tipoEmpleado);
        }

        // POST: tipoEmpleadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tipoEmpleado tipoEmpleado = db.tipoEmpleado.Find(id);
            db.tipoEmpleado.Remove(tipoEmpleado);
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
