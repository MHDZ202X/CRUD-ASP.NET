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
    public class tipoCuentasController : Controller
    {
        private TiendaEntities db = new TiendaEntities();

        // GET: tipoCuentas
        public ActionResult Index()
        {
            return View(db.tipoCuenta.ToList());
        }

        // GET: tipoCuentas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipoCuenta tipoCuenta = db.tipoCuenta.Find(id);
            if (tipoCuenta == null)
            {
                return HttpNotFound();
            }
            return View(tipoCuenta);
        }

        // GET: tipoCuentas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tipoCuentas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idtipoCuenta,tipo,estatus,ididusuarioCrea,idusuarioModifica")] tipoCuenta tipoCuenta)
        {
            if (ModelState.IsValid)
            {
                db.tipoCuenta.Add(tipoCuenta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoCuenta);
        }

        // GET: tipoCuentas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipoCuenta tipoCuenta = db.tipoCuenta.Find(id);
            if (tipoCuenta == null)
            {
                return HttpNotFound();
            }
            return View(tipoCuenta);
        }

        // POST: tipoCuentas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idtipoCuenta,tipo,estatus,ididusuarioCrea,idusuarioModifica")] tipoCuenta tipoCuenta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoCuenta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoCuenta);
        }

        // GET: tipoCuentas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipoCuenta tipoCuenta = db.tipoCuenta.Find(id);
            if (tipoCuenta == null)
            {
                return HttpNotFound();
            }
            return View(tipoCuenta);
        }

        // POST: tipoCuentas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tipoCuenta tipoCuenta = db.tipoCuenta.Find(id);
            db.tipoCuenta.Remove(tipoCuenta);
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
