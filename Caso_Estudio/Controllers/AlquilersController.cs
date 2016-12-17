using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Caso_Estudio.DAL;
using Caso_Estudio.Models;

namespace Caso_Estudio.Controllers
{
    public class AlquilersController : Controller
    {
        private VideoClubContext db = new VideoClubContext();

        // GET: Alquilers
        public ActionResult Index()
        {
            return View(db.Alquileres.ToList());
        }

        // GET: Alquilers/Alquiler
        public ActionResult Alquiler(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alquiler alquiler = db.Alquileres.Find(id);
            if (alquiler == null)
            {
                return HttpNotFound();
            }
            return View(alquiler);
        }

        // GET: Alquilers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alquiler alquiler = db.Alquileres.Find(id);
            if (alquiler == null)
            {
                return HttpNotFound();
            }
            return View(alquiler);
        }

        // GET: Alquilers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Alquilers/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AlquilerID,PickUpate,DateOfReturn,Cost")] Alquiler alquiler)
        {
            if (ModelState.IsValid)
            {
                db.Alquileres.Add(alquiler);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(alquiler);
        }

        // GET: Alquilers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alquiler alquiler = db.Alquileres.Find(id);
            if (alquiler == null)
            {
                return HttpNotFound();
            }
            return View(alquiler);
        }

        // POST: Alquilers/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AlquilerID,PickUpate,DateOfReturn,Cost")] Alquiler alquiler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(alquiler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(alquiler);
        }

        // GET: Alquilers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alquiler alquiler = db.Alquileres.Find(id);
            if (alquiler == null)
            {
                return HttpNotFound();
            }
            return View(alquiler);
        }

        // POST: Alquilers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Alquiler alquiler = db.Alquileres.Find(id);
            db.Alquileres.Remove(alquiler);
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
