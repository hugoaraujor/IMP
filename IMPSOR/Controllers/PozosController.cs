using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using IMPSOR;
using IMPSOR.Models;
using PagedList;
namespace IMPSOR.Controllers
{
    public class PozosController : Controller
    {
        
        private DataContext db = new DataContext();
        private Funciones funciones = new Funciones();
        private IEnumerable<Pregunta> Preguntas = new DataContext().Preguntas.AsEnumerable();
        private JavaScriptSerializer jss = new JavaScriptSerializer();
        private ServicioCuestionario ServCuestionario=new ServicioCuestionario();
        public ActionResult Metodos(int metodo = 0)
        {
            ViewBag.Message = "Seleccione el Método.";
            ViewBag.Title = "Sistema Experto";
            if (metodo == 1)
                return RedirectToAction("Index", new { metodo = metodo });

            return View(db.Cuestionarios.ToList());
        }

        public ActionResult Index([Bind(Include = "yacimiento,campo, yacimientos,campos,procesados,metodo")] PozosView datamodel, int page = 0, int checkpozoid = 0, int metodo1 = 0, int? flow = 0,int metodoindex=0)
        {

            int pageindex = page;
            var pagesize = 11;

            if (flow == 5)
                return RedirectToAction("IndexAll", "Pozos", datamodel);

         
            var campos_Qry = db.cat_campo.ToList().OrderBy(o => o.campo);
            datamodel.campos = new SelectList(campos_Qry, "id_campo", "campo", campos_Qry.FirstOrDefault());

            if (datamodel.campo == 0)
                datamodel.campo = campos_Qry.FirstOrDefault().id_campo;

            if (datamodel.yacimiento == 0)
                datamodel.yacimiento = db.cat_yacimiento.Where(y => y.id_campo == datamodel.campo).FirstOrDefault().id_yacimiento;

            var yacimientos_Qry = db.cat_yacimiento.ToList().OrderBy(o => o.yacimiento).Where(w => w.id_campo == datamodel.campo);
            datamodel.yacimientos = new SelectList(yacimientos_Qry, "id_yacimiento", "yacimiento");

            var detalles = new List<PozosViewDetail>();

            try
            {
                detalles = db.GetPozos(datamodel.campo, datamodel.yacimiento);
                foreach (PozosViewDetail pozo in detalles)
                {
                    detalles.Find(f=>f.id_pozo==pozo.id_pozo).estatus=db.respuestasPozos.Where(w=>w.Idpozo==pozo.id_pozo&&w.metodo==datamodel.metodo).Any().ToString();
                    
                }

            }
            catch { }

            if (datamodel.procesados)
            {
                try
                {
                    detalles = detalles.Where(w => w.estado == "Procesado").ToList();
                }
                catch { }
            }
   
            if (pageindex == 0) pageindex = 1;

            if ((datamodel.yacimiento != (int?)Session["yacimiento"]) || (datamodel.procesados != (bool?)Session["procesado"]))
                pageindex = 1;

            datamodel.Detalle = detalles.ToPagedList(pageindex, pagesize);
            datamodel.Preguntas = Preguntas.Where(w => w.Metodo == datamodel.metodo).ToList();
           ServCuestionario.ProcesaCuestionarios(datamodel.campo, datamodel.yacimiento, datamodel.metodo);
            Session["yacimiento"] = datamodel.yacimiento;
            Session["procesado"] = datamodel.procesados;
            ViewBag.Title = "Sistema Experto";
            ViewBag.SubTitle = Services.GetMethodName(datamodel.metodo);
            TempData["dataModel"] = datamodel;
            ViewBag.page = page;
            return View(datamodel);
        }


        public ActionResult IndexAll([Bind(Include = "yacimiento,campo, yacimientos,campos,procesados,metodo")] PozosView datamodel, int page = 0, int checkpozoid = 0, int metodo = 0, int? flow = 0)
        {

            int pageindex = page;
            var pagesize = 12;

            if (flow == 5)
            {
                if (datamodel.metodo == 1)
                    return RedirectToAction("SorGraph2", "Pozos", datamodel); 
                else
                   return RedirectToAction("SorGraph", "Pozos", datamodel);
            }
         
            datamodel.procesados = true;
            var campos_Qry = db.cat_campo.ToList().OrderBy(o => o.campo);
            datamodel.campos = new SelectList(campos_Qry, "id_campo", "campo", datamodel.campo);
            if (datamodel.campo == 0)
                datamodel.campo = campos_Qry.FirstOrDefault().id_campo;
            if (datamodel.yacimiento == 0)
                datamodel.yacimiento = db.cat_yacimiento.Where(y => y.id_campo == datamodel.campo).FirstOrDefault().id_yacimiento;

            var yacimientos_Qry = db.cat_yacimiento.Where(w => w.id_campo == datamodel.campo).ToList().OrderBy(o => o.yacimiento);
            if (yacimientos_Qry.Where(y => y.id_yacimiento == datamodel.yacimiento).Count() == 0)
                datamodel.yacimiento = yacimientos_Qry.FirstOrDefault().id_yacimiento;
            datamodel.yacimientos = new SelectList(yacimientos_Qry, "id_yacimiento", "yacimiento", datamodel.yacimiento);
            var detalles = new List<PozosViewDetail>();
            detalles=GetDetalles(datamodel.campo, datamodel.yacimiento, datamodel.procesados).ToList();
            if (pageindex == 0) pageindex = 1;
            if ((datamodel.yacimiento != (int?)Session["yacimiento"]) || (datamodel.procesados != (bool?)Session["procesado"]))
                pageindex = 1;
            datamodel.Preguntas = Preguntas.Where(w => w.Metodo == metodo).ToList();
            datamodel.Detalle = detalles.ToPagedList(pageindex, pagesize);
            ViewBag.SubTitle = "Inferencia del Método";
            return View(datamodel);
        }
        public ActionResult Comparativa([Bind(Include = "yacimiento,campo, yacimientos,campos,procesados,metodo")] PozosView datamodel, int page = 0, int checkpozoid = 0, int metodo = 0, int? flow = 0)
        {

            int pageindex = page;
            var pagesize = 12;
            if (flow == 5)
                return RedirectToAction("SorGraph", "Pozos", datamodel);
            datamodel.procesados = true;
            var campos_Qry = db.cat_campo.ToList().OrderBy(o => o.campo);
            datamodel.campos = new SelectList(campos_Qry, "id_campo", "campo", datamodel.campo);
            if (datamodel.campo == 0)
                datamodel.campo = campos_Qry.FirstOrDefault().id_campo;
            if (datamodel.yacimiento == 0)
                datamodel.yacimiento = db.cat_yacimiento.Where(y => y.id_campo == datamodel.campo).FirstOrDefault().id_yacimiento;

            var yacimientos_Qry = db.cat_yacimiento.Where(w => w.id_campo == datamodel.campo).ToList().OrderBy(o => o.yacimiento);
            if (yacimientos_Qry.Where(y => y.id_yacimiento == datamodel.yacimiento).Count() == 0)
                datamodel.yacimiento = yacimientos_Qry.FirstOrDefault().id_yacimiento;
            datamodel.yacimientos = new SelectList(yacimientos_Qry, "id_yacimiento", "yacimiento", datamodel.yacimiento);
            var detalles = new List<PozosViewDetail>();
            detalles = GetDetalles(datamodel.campo, datamodel.yacimiento, datamodel.procesados).ToList();
            if (pageindex == 0) pageindex = 1;
            if ((datamodel.yacimiento != (int?)Session["yacimiento"]) || (datamodel.procesados != (bool?)Session["procesado"]))
                pageindex = 1;
            datamodel.Preguntas = Preguntas.Where(w => w.Metodo == metodo).ToList();
            datamodel.Detalle = detalles.ToPagedList(pageindex, pagesize);
             ViewBag.SubTitle = "Inferencia del Método";
            return View(datamodel);
        }
        private IEnumerable<PozosViewDetail> GetDetalles(int? campo, int? yacimiento, Boolean procesados)
        {
            var detalles = db.GetPozos(campo, yacimiento);
            if (procesados && detalles != null)
            {
                detalles = detalles.Where(w => w.estado == "Procesado" || w.RespuestasCuestionario2!=null).ToList();
                
              }
            return detalles;
        }

        public ActionResult SorGraph2(GraphJson cadena, int metodo,int? campo, int? yacimiento)
        {
            if (campo == null)
                return RedirectToAction("Index", "Home");
  
            
            var coordsource = Services.Getgraphdata2(campo, yacimiento, metodo).ToList().OrderBy(o=>o.pname);
            foreach (GraphData2View g in coordsource)
            {
                g.color = Services.getGraphDotColor(Convert.ToDecimal(g.percentage));
                g.percentage = Math.Round(((g.percentage==null?0: g.percentage) * 100).Value,2);
            }

            //Si se aumenta la carga de datos superior a 1000 no despliega
            var coordsource2 = coordsource.Take(1000);
            
            jss.MaxJsonLength = Int32.MaxValue;
            cadena.Jsoncadena = jss.Serialize(coordsource2);
            cadena.Titulo = db.cat_campo.Where(w => w.id_campo == campo).FirstOrDefault().campo;
            cadena.Subtitulo = db.cat_yacimiento.Where(w => w.id_yacimiento == yacimiento).FirstOrDefault().yacimiento;
            return View(cadena);
        }
        public ActionResult SorGraph(GraphJson cadena, int metodo, int? campo, int? yacimiento)
        {
            if (campo == null)
                return RedirectToAction("Index", "Home");

            var coordsource = Services.Getgraphdata(campo, yacimiento, metodo);
            var coordsource2 = coordsource;
          
            cadena.Jsoncadena = jss.Serialize(coordsource); 
            cadena.Titulo = db.cat_campo.Where(w => w.id_campo == campo).FirstOrDefault().campo;
            cadena.Subtitulo = db.cat_yacimiento.Where(w => w.id_yacimiento == yacimiento).FirstOrDefault().yacimiento;
            return View(cadena);
        }
        public ActionResult Details()
        {
            return Details();
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
