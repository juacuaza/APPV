using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Caso_Estudio.DAL;
using Caso_Estudio.Models;
using System.Collections.Generic;
using System;

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


        // GET: Socios/Login
        public ActionResult Login()
        {
            return View();
        }

        //POST: Socios/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Socio model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // No cuenta los errores de inicio de sesión para el bloqueo de la cuenta
            // Para permitir que los errores de contraseña desencadenen el bloqueo de la cuenta, cambie a shouldLockout: true
            var result = PasswordSign(model.Name, model.Password);
            switch (result)
            {
                case "success":
                    return RedirectToLocal(returnUrl);
                case "fail":
                default:
                    ModelState.AddModelError("", "Intento de inicio de sesión no válido.");
                    return View(model);
            }
        }

        //Comprueba si el socio esta en la ddbb
        private string PasswordSign(string name, string password)
        {
            Socio socio = null;
            string login = "fail";

            socio = db.Socios.Where(s => (s.Name.Equals(name) && s.Password.Equals(password))).FirstOrDefault();

            if (socio != null)
                login = "success";

            return login;
        }

        //Devuelve la pagina que se le pasa como string
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: Socios/Create
        public ActionResult Create()
        {
            ViewBag.name = new SelectList(db.VideoClubs.Select(s => s.Name).ToList());
            return View();
        }

        // POST: Socios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SocioID,Name,Password,Age,VideoClub")] Socio socio)
        {
            try
            {
                List<VideoClub> listaVC = new List<VideoClub>();
                VideoClub vc = null;
                foreach (VideoClub vd in db.VideoClubs)
                {
                    listaVC.Add(vd);
                }

                if (listaVC != null)
                {
                    string[] strCadena = Request.Form["name"].Split(',');
                    var strnombre = strCadena[1];
                    vc = listaVC.Where(s => s.Name.Equals(strnombre)).FirstOrDefault();
                }

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
