using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Caso_Estudio.DAL;
using Caso_Estudio.Models;
using System.Collections.Generic;

namespace Caso_Estudio.Controllers
{
    public class SociosController : Controller
    {        
        private VideoClubContext db = new VideoClubContext();


        // GET: Socios
        public ActionResult Index()
        {
            return View(db.Socios.ToList());
        }

        // GET: Socios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Socio socio = db.Socios.Find(id);
            if (socio == null)
            {
                return HttpNotFound();
            }
            return View(socio);
        }


        // GET: Socios/Registro
        public ActionResult Registro()
        {
            int i = 110;
            ViewBag.name = new SelectList(db.VideoClubs.Select(s => s.Name).ToList());
            return View();
        }

        // Post: Socios/Registro
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registro([Bind(Include = "SocioID,Name,Password,Age,VideoClub")] Socio socio)
        {
            try
            {
                List<VideoClub> listaVC = new List<VideoClub>();
                VideoClub vc = null;
                foreach(VideoClub vd in db.VideoClubs)
                {
                    listaVC.Add(vd);
                }

                if (listaVC != null)
                {
                    string[] strCadena = Request.Form["name"].Split(',');
                    var strnombre = strCadena[1];
                     vc = listaVC.Where(s => s.Name.Equals(strnombre)).FirstOrDefault();
                }


                //VideoClub vc = (from s in db.VideoClubs
                //               where s.Name.Equals(Request.Form["name"].LastOrDefault().ToString())
                //               select s).FirstOrDefault();

                //VideoClub vc = db.VideoClubs.Where(s => s.Name.Equals(Request.Form["VideoClub"].ToString())).FirstOrDefault();
                if (vc != null)
                    socio.VideoClub = vc;
            }
            catch { }

            if (ModelState.IsValid)
            {
                db.Socios.Add(socio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(socio);
        }




        // GET: Socios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Socios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SocioID,Name,Password,Age")] Socio socio)
        {
            if (ModelState.IsValid)
            {
                db.Socios.Add(socio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(socio);
        }

        // GET: Socios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Socio socio = db.Socios.Find(id);
            if (socio == null)
            {
                return HttpNotFound();
            }
            return View(socio);
        }

        // POST: Socios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SocioID,Name,Password,Age")] Socio socio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(socio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(socio);
        }

        // GET: Socios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Socio socio = db.Socios.Find(id);
            if (socio == null)
            {
                return HttpNotFound();
            }
            return View(socio);
        }

        // POST: Socios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Socio socio = db.Socios.Find(id);
            db.Socios.Remove(socio);
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
