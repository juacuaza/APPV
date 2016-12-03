using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Caso_Estudio.Models;

namespace Caso_Estudio.Controllers
{
    public class CadenasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Cadenas
        public ActionResult Index()
        {
            return View(db.Cadenas.ToList());
        }

        // GET: Cadenas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cadena cadena = db.Cadenas.Find(id);
            if (cadena == null)
            {
                return HttpNotFound();
            }
            return View(cadena);
        }

        // GET: Cadenas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cadenas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CadenaID,Name,City,Address,Zip")] Cadena cadena)
        {
            if (ModelState.IsValid)
            {
                db.Cadenas.Add(cadena);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cadena);
        }

        // GET: Cadenas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cadena cadena = db.Cadenas.Find(id);
            if (cadena == null)
            {
                return HttpNotFound();
            }
            return View(cadena);
        }

        // POST: Cadenas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CadenaID,Name,City,Address,Zip")] Cadena cadena)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cadena).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cadena);
        }

        // GET: Cadenas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cadena cadena = db.Cadenas.Find(id);
            if (cadena == null)
            {
                return HttpNotFound();
            }
            return View(cadena);
        }

        // POST: Cadenas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cadena cadena = db.Cadenas.Find(id);
            db.Cadenas.Remove(cadena);
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
