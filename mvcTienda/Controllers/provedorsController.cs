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
    public class provedorsController : Controller
    {
        private TiendaEntities db = new TiendaEntities();

        // GET: provedors
        public ActionResult Index()
        {
            return View(db.provedor.ToList());
        }

        // GET: provedors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            provedor provedor = db.provedor.Find(id);
            if (provedor == null)
            {
                return HttpNotFound();
            }
            return View(provedor);
        }

        // GET: provedors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: provedors/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idprovedor,nombre,estatus,idusuarioCrea,idusuarioModifica")] provedor provedor)
        {
            if (ModelState.IsValid)
            {
                db.provedor.Add(provedor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(provedor);
        }

        // GET: provedors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            provedor provedor = db.provedor.Find(id);
            if (provedor == null)
            {
                return HttpNotFound();
            }
            return View(provedor);
        }

        // POST: provedors/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idprovedor,nombre,estatus,idusuarioCrea,idusuarioModifica")] provedor provedor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(provedor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(provedor);
        }

        // GET: provedors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            provedor provedor = db.provedor.Find(id);
            if (provedor == null)
            {
                return HttpNotFound();
            }
            return View(provedor);
        }

        // POST: provedors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            provedor provedor = db.provedor.Find(id);
            db.provedor.Remove(provedor);
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
