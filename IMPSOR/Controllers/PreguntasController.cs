

using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;


namespace IMPSOR.Controllers
{
    public class PreguntasController : Controller
    {
        private DataContext db = new DataContext();

        public ActionResult Index(int? id)
        {
            if (id == null || id == 0)
                return RedirectToAction("Index", "Cuestionarios");
            
            var cuestionario = db.Cuestionarios.Where(m => m.Metodo == id);
            ViewBag.titulo = cuestionario.SingleOrDefault().Cuestionario_name;
            ViewBag.cuestionario = cuestionario.SingleOrDefault() ;

            return View(db.Preguntas.Where(w=>w.IdCase==cuestionario.FirstOrDefault().IdCase).ToList());
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pregunta pregunta = db.Preguntas.Find(id);
            if (pregunta == null)
            {
                return HttpNotFound();
            }
            return View(pregunta);
        }
        public ActionResult Create(int? id)
        {
            if (id == null || id == 0)
                return RedirectToAction("Index", "Cuestionarios");
            var funciones = new Funciones();
            List<Funcion> listafunciones = funciones.Get(id);
            listafunciones.Add(new Funcion() { Idfuncion = 0, Func = "{?}", Metodo = id.Value });
            
            var listaoperadores= funciones.GetOperatorsList();
            ViewBag.operadores = listaoperadores;
            ViewBag.cuestionario = db.Cuestionarios.Find(id);
            ViewBag.funciones = listafunciones;
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdQuestion,IdCase,idPregunta,Enunciate,Condicioneval,operador,valor,ExpressionSi,conector,Metodo")] Pregunta pregunta)
        {
            if (ModelState.IsValid)
            {
                pregunta.idPregunta = db.Preguntas.Where(w => w.IdCase == pregunta.IdCase).Count()+1;
                db.Preguntas.Add(pregunta);
                db.SaveChanges();
                return RedirectToAction("Index",new { id = pregunta.Metodo });
            }
            ViewBag.cuestionario = db.Cuestionarios.Find(pregunta.IdCase);
            return View(pregunta);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return RedirectToAction("Index", "Cuestionarios");
            var func = new Funciones();
            
            ViewBag.operadores = func.GetOperatorsList();
            Pregunta pregunta = db.Preguntas.Find(id);
            ViewBag.cuestionario = db.Cuestionarios.Find(pregunta.IdCase);
            var funciones = new Funciones();
            List<Funcion> listafunciones = funciones.Get(id);
            listafunciones.Add(new Funcion() { Idfuncion = 0, Func = "{?}", Metodo = id.Value });
            ViewBag.funciones = listafunciones;
            if (pregunta == null)
            {
                return HttpNotFound();
            }
            return View(pregunta);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdQuestion,IdCase,idPregunta,Enunciate,Condicioneval,operador,valor,ExpressionSi,conector,Metodo")] Pregunta pregunta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pregunta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { id = pregunta.Metodo });
                //return RedirectToAction("Seleccion","Cuestionarios", new { id = pregunta.IdCase });
            }
            return View(pregunta);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pregunta pregunta = db.Preguntas.Find(id);

            if (pregunta == null)
            {
                return HttpNotFound();
            }
            return View(pregunta);
        }

        // POST: Preguntas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pregunta pregunta = db.Preguntas.Find(id);
            db.Preguntas.Remove(pregunta);
            db.SaveChanges();
            return RedirectToAction("Index",new { id = pregunta.Metodo});
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
