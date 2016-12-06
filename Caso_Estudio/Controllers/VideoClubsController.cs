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
    public class VideoClubsController : Controller
    {
        private VideoClubContext db = new VideoClubContext();

        // GET: VideoClubs
        public ActionResult Index()
        {
            return View(db.VideoClubs.ToList());
        }

        // GET: VideoClubs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoClub videoClub = db.VideoClubs.Find(id);
            if (videoClub == null)
            {
                return HttpNotFound();
            }
            return View(videoClub);
        }

        // GET: VideoClubs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VideoClubs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VideoClubID,Name,City,Address,Zip")] VideoClub videoClub)
        {
            if (ModelState.IsValid)
            {
                db.VideoClubs.Add(videoClub);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(videoClub);
        }

        // GET: VideoClubs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoClub videoClub = db.VideoClubs.Find(id);
            if (videoClub == null)
            {
                return HttpNotFound();
            }
            return View(videoClub);
        }

        // POST: VideoClubs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VideoClubID,Name,City,Address,Zip")] VideoClub videoClub)
        {
            if (ModelState.IsValid)
            {
                db.Entry(videoClub).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(videoClub);
        }

        // GET: VideoClubs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoClub videoClub = db.VideoClubs.Find(id);
            if (videoClub == null)
            {
                return HttpNotFound();
            }
            return View(videoClub);
        }

        // POST: VideoClubs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VideoClub videoClub = db.VideoClubs.Find(id);
            db.VideoClubs.Remove(videoClub);
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
