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
    public class marketingsController : Controller
    {
        private TiendaEntities db = new TiendaEntities();

        // GET: marketings
        public ActionResult Index()
        {
            var marketing = db.marketing.Include(m => m.tienda);
            return View(marketing.ToList());
        }

        // GET: marketings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            marketing marketing = db.marketing.Find(id);
            if (marketing == null)
            {
                return HttpNotFound();
            }
            return View(marketing);
        }

        // GET: marketings/Create
        public ActionResult Create()
        {
            ViewBag.idtienda = new SelectList(db.tienda, "idtienda", "nombre");
            return View();
        }

        // POST: marketings/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idmarketing,codigo,tipo,idusuarioCrea,idusuarioModifica,idtienda")] marketing marketing)
        {
            if (ModelState.IsValid)
            {
                db.marketing.Add(marketing);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idtienda = new SelectList(db.tienda, "idtienda", "nombre", marketing.idtienda);
            return View(marketing);
        }

        // GET: marketings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            marketing marketing = db.marketing.Find(id);
            if (marketing == null)
            {
                return HttpNotFound();
            }
            ViewBag.idtienda = new SelectList(db.tienda, "idtienda", "nombre", marketing.idtienda);
            return View(marketing);
        }

        // POST: marketings/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idmarketing,codigo,tipo,idusuarioCrea,idusuarioModifica,idtienda")] marketing marketing)
        {
            if (ModelState.IsValid)
            {
                db.Entry(marketing).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idtienda = new SelectList(db.tienda, "idtienda", "nombre", marketing.idtienda);
            return View(marketing);
        }

        // GET: marketings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            marketing marketing = db.marketing.Find(id);
            if (marketing == null)
            {
                return HttpNotFound();
            }
            return View(marketing);
        }

        // POST: marketings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            marketing marketing = db.marketing.Find(id);
            db.marketing.Remove(marketing);
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
