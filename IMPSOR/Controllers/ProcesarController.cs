using IMPSOR.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
namespace IMPSOR
{
    public class ProcesarController : Controller
    {
        DataContext db = new DataContext();
       
        public ActionResult Index(int? pozoid, string resp, string submitresp, string seleccion,int step = 0, int? metodo = 1, bool backw = false,int page=1)
        {
            if (submitresp == "Graba")
            {
                GrabarCuestionario(metodo.Value, pozoid, resp);
                return RedirectToAction("Index", "Pozos", new { @metodo = metodo ,@page=page});
            }
            if (submitresp == "Cancel")
            {            
                return RedirectToAction("Index", "Pozos", new { @metodo = metodo, @page = page });
            }
            ViewBag.metodo = db.Cuestionarios.Where(w => w.Metodo == metodo).SingleOrDefault().Cuestionario_name;
            ViewBag.pozo = db.cat_pozo.Where(w => w.id_pozo == pozoid).SingleOrDefault();
            ViewBag.page = page;
            
            if (seleccion!="" && seleccion!=null)
            submitresp = seleccion;

            if (backw)
            {
                ViewBag.step = step - 1;
                step = step - 2;
            }
            
            var cuentapreguntas = db.Preguntas.Where(w => w.Metodo == metodo && w.Condicioneval.IndexOf("{?}")>-1).Count();

            if (submitresp != null)
            {
                ViewBag.step = step + 1;
                step++;
          


            }
            var pregunta=getPregunta(metodo,step);
           if ( pregunta!=null)
           {     if (submitresp!=null)
                 resp = resp + (pregunta.IdQuestion.ToString("D2")+","+step.ToString("D2") + ","+submitresp)+";";
                 ViewBag.Title = pregunta.Enunciate;
           }
            ViewBag.resp = resp;
            ViewBag.percent = calculatePercent(step, cuentapreguntas);


            if (step < 0)
            {
                ViewBag.step = 0;
                step = 0;

            }

            return View();
        }

        private Pregunta getPregunta(int? metodo,int step)
        {
            return db.Preguntas.Where(w => w.Metodo == metodo && w.Condicioneval.IndexOf("{?}") > -1).OrderBy(o => o.IdQuestion).Skip(step).FirstOrDefault();
        }

        private void GrabarCuestionario(int metodo, int? pozoid, string resp)
        {
            string[] respuestas = new string[20];
            respuestas=resp.Split(';');
            foreach (string s in respuestas)
            {
                if (s != "")
                {
                    var columnas = s.Split(',');
                    var detalle = new RespuestasPozo() { Idpozo = pozoid.Value, idPregunta = Convert.ToInt16(columnas[0]), Respuesta = columnas[2], metodo = metodo };
                    var respuesta = db.respuestasPozos.Where(w => w.Idpozo == pozoid && w.idPregunta == detalle.idPregunta).FirstOrDefault();
                    if (respuesta == null)
                        db.respuestasPozos.Add(detalle);
                    else
                    {
                        respuesta.Respuesta = detalle.Respuesta;
                        db.respuestasPozos.Attach(respuesta);
                        db.Entry(respuesta).State = EntityState.Modified;
                    }
                    db.SaveChanges();
                }
            }
      
        }

        private int calculatePercent(int step,int totalsteps)
        {
            var percent = 0;
            try
            {
                percent = (step * 100) / totalsteps;
            }
            catch {}
            if (percent < 0)
                percent = 0;
            if (percent > 100)
                percent = 100;
            return Convert.ToInt16(percent);
        }


    
   
    }
}
