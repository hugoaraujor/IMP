using IMPSOR.Models;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;


namespace IMPSOR.Controllers
{
    public class CuestionariosController : Controller
    {
        private DataContext db = new DataContext();

        public ActionResult Index(string Mensaje = "")
        {
            ViewBag.Mensaje = Mensaje;
            return View(db.Cuestionarios.ToList());
        }

        public ActionResult Seleccion(int metodo = 0)
        {
            ViewBag.Message = "Seleccione el Método.";
            ViewBag.Title = "Cuestionarios";

            return View("Metodos", db.Cuestionarios.ToList());
        }

        public ActionResult Details(int? id, string Mensaje = "")
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cuestionario cuestionario = db.Cuestionarios.Find(id);
            if (cuestionario == null)
            {
                return HttpNotFound();
            }
            return View(cuestionario);
        }
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCase,Cuestionario_name,Metodo")] Cuestionario cuestionario, string Mensaje = "")
        {

            if (ModelState.IsValid)
            {
                db.Cuestionarios.Add(cuestionario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cuestionario);
        }

        // GET: Cuestionarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cuestionario cuestionario = db.Cuestionarios.Find(id);
            if (cuestionario == null)
            {
                return HttpNotFound();
            }

            return View(cuestionario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCase,Cuestionario_name,Metodo")] Cuestionario cuestionario, string Mensaje = "")
        {
            if (ModelState.IsValid)
            {
                db.Entry(cuestionario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cuestionario);
        }

        [HttpGet]
        public ActionResult Delete(int? id, string Mensaje = "")
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cuestionario cuestionario = db.Cuestionarios.Find(id);
            var preguntas = db.Preguntas.Where(w => w.IdCase == id).Count();
            if (preguntas > 0)
            {
                return RedirectToAction("Index", "Cuestionarios", new { Mensaje = "No puede Borrar un cuestionario que no este vacío." });
            }

            if (cuestionario == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("Index", new { Mensaje = "" });
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, string Mensaje = "")
        {
            Cuestionario cuestionario = db.Cuestionarios.Find(id);
            db.Cuestionarios.Remove(cuestionario);
            db.SaveChanges();
            return RedirectToAction("Index", new { Mensaje = "" });
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
