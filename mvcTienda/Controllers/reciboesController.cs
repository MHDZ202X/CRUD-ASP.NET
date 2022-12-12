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
    public class reciboesController : Controller
    {
        private TiendaEntities db = new TiendaEntities();

        // GET: reciboes
        public ActionResult Index()
        {
            return View(db.recibo.ToList());
        }

        // GET: reciboes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            recibo recibo = db.recibo.Find(id);
            if (recibo == null)
            {
                return HttpNotFound();
            }
            return View(recibo);
        }

        // GET: reciboes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: reciboes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idrecibo,codigo,fecha,estatus,idusuarioCrea,idusuarioModifica")] recibo recibo)
        {
            if (ModelState.IsValid)
            {
                db.recibo.Add(recibo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(recibo);
        }

        // GET: reciboes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            recibo recibo = db.recibo.Find(id);
            if (recibo == null)
            {
                return HttpNotFound();
            }
            return View(recibo);
        }

        // POST: reciboes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idrecibo,codigo,fecha,estatus,idusuarioCrea,idusuarioModifica")] recibo recibo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recibo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(recibo);
        }

        // GET: reciboes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            recibo recibo = db.recibo.Find(id);
            if (recibo == null)
            {
                return HttpNotFound();
            }
            return View(recibo);
        }

        // POST: reciboes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            recibo recibo = db.recibo.Find(id);
            db.recibo.Remove(recibo);
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
