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
    public class tipoProvedorsController : Controller
    {
        private TiendaEntities db = new TiendaEntities();

        // GET: tipoProvedors
        public ActionResult Index()
        {
            var tipoProvedor = db.tipoProvedor.Include(t => t.provedor);
            return View(tipoProvedor.ToList());
        }

        // GET: tipoProvedors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipoProvedor tipoProvedor = db.tipoProvedor.Find(id);
            if (tipoProvedor == null)
            {
                return HttpNotFound();
            }
            return View(tipoProvedor);
        }

        // GET: tipoProvedors/Create
        public ActionResult Create()
        {
            ViewBag.idprovedor = new SelectList(db.provedor, "idprovedor", "nombre");
            return View();
        }

        // POST: tipoProvedors/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idtipoProvedor,tipo,estatus,ididusuarioCrea,idusuarioModifica,idprovedor")] tipoProvedor tipoProvedor)
        {
            if (ModelState.IsValid)
            {
                db.tipoProvedor.Add(tipoProvedor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idprovedor = new SelectList(db.provedor, "idprovedor", "nombre", tipoProvedor.idprovedor);
            return View(tipoProvedor);
        }

        // GET: tipoProvedors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipoProvedor tipoProvedor = db.tipoProvedor.Find(id);
            if (tipoProvedor == null)
            {
                return HttpNotFound();
            }
            ViewBag.idprovedor = new SelectList(db.provedor, "idprovedor", "nombre", tipoProvedor.idprovedor);
            return View(tipoProvedor);
        }

        // POST: tipoProvedors/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idtipoProvedor,tipo,estatus,ididusuarioCrea,idusuarioModifica,idprovedor")] tipoProvedor tipoProvedor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoProvedor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idprovedor = new SelectList(db.provedor, "idprovedor", "nombre", tipoProvedor.idprovedor);
            return View(tipoProvedor);
        }

        // GET: tipoProvedors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipoProvedor tipoProvedor = db.tipoProvedor.Find(id);
            if (tipoProvedor == null)
            {
                return HttpNotFound();
            }
            return View(tipoProvedor);
        }

        // POST: tipoProvedors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tipoProvedor tipoProvedor = db.tipoProvedor.Find(id);
            db.tipoProvedor.Remove(tipoProvedor);
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
