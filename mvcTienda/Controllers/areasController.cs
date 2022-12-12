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
    public class areasController : Controller
    {
        private TiendaEntities db = new TiendaEntities();

        // GET: areas
        public ActionResult Index()
        {
            var area = db.area.Include(a => a.tienda);
            return View(area.ToList());
        }

        // GET: areas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            area area = db.area.Find(id);
            if (area == null)
            {
                return HttpNotFound();
            }
            return View(area);
        }

        // GET: areas/Create
        public ActionResult Create()
        {
            ViewBag.idtienda = new SelectList(db.tienda, "idtienda", "nombre");
            return View();
        }

        // POST: areas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idarea,nombre,estatus,idusuarioCrea,idusuarioModifica,idtienda")] area area)
        {
            if (ModelState.IsValid)
            {
                db.area.Add(area);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idtienda = new SelectList(db.tienda, "idtienda", "nombre", area.idtienda);
            return View(area);
        }

        // GET: areas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            area area = db.area.Find(id);
            if (area == null)
            {
                return HttpNotFound();
            }
            ViewBag.idtienda = new SelectList(db.tienda, "idtienda", "nombre", area.idtienda);
            return View(area);
        }

        // POST: areas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idarea,nombre,estatus,idusuarioCrea,idusuarioModifica,idtienda")] area area)
        {
            if (ModelState.IsValid)
            {
                db.Entry(area).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idtienda = new SelectList(db.tienda, "idtienda", "nombre", area.idtienda);
            return View(area);
        }

        // GET: areas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            area area = db.area.Find(id);
            if (area == null)
            {
                return HttpNotFound();
            }
            return View(area);
        }

        // POST: areas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            area area = db.area.Find(id);
            db.area.Remove(area);
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
