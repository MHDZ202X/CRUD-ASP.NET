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
    public class sucursalsController : Controller
    {
        private TiendaEntities db = new TiendaEntities();

        // GET: sucursals
        public ActionResult Index()
        {
            var sucursal = db.sucursal.Include(s => s.tienda);
            return View(sucursal.ToList());
        }

        // GET: sucursals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sucursal sucursal = db.sucursal.Find(id);
            if (sucursal == null)
            {
                return HttpNotFound();
            }
            return View(sucursal);
        }

        // GET: sucursals/Create
        public ActionResult Create()
        {
            ViewBag.idtienda = new SelectList(db.tienda, "idtienda", "nombre");
            return View();
        }

        // POST: sucursals/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idsucursal,nombre,direccion,estatus,idusuarioCrea,idusuarioModifica,idtienda")] sucursal sucursal)
        {
            if (ModelState.IsValid)
            {
                db.sucursal.Add(sucursal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idtienda = new SelectList(db.tienda, "idtienda", "nombre", sucursal.idtienda);
            return View(sucursal);
        }

        // GET: sucursals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sucursal sucursal = db.sucursal.Find(id);
            if (sucursal == null)
            {
                return HttpNotFound();
            }
            ViewBag.idtienda = new SelectList(db.tienda, "idtienda", "nombre", sucursal.idtienda);
            return View(sucursal);
        }

        // POST: sucursals/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idsucursal,nombre,direccion,estatus,idusuarioCrea,idusuarioModifica,idtienda")] sucursal sucursal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sucursal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idtienda = new SelectList(db.tienda, "idtienda", "nombre", sucursal.idtienda);
            return View(sucursal);
        }

        // GET: sucursals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sucursal sucursal = db.sucursal.Find(id);
            if (sucursal == null)
            {
                return HttpNotFound();
            }
            return View(sucursal);
        }

        // POST: sucursals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            sucursal sucursal = db.sucursal.Find(id);
            db.sucursal.Remove(sucursal);
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
