using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace IMPSOR.Controllers
{
    
    public class HomeController : Controller
    
    {
        public DataContext db = new DataContext();
        public ActionResult Index()
        {
            
        
            return View();
        }

        [HttpGet]
        public ActionResult Configurar(int i=0)
        {
            var datamodel = db.Configuraciones.FirstOrDefault();
            if (datamodel == null)
                datamodel = new Configuracion();
            return View(datamodel);
        }
        [HttpPost]
        public ActionResult Configurar([Bind(Include = "Id,Metodo1,Metodo2,Metodo3,Metodo4,Metodo5,Metodo6,enfoqueId,Aplicacion,Herramienta,Operacion")] Configuracion datamodel)
        {

            var sumapartes = Convert.ToDecimal(datamodel.Aplicacion) + Convert.ToDecimal(datamodel.Herramienta) + Convert.ToDecimal(datamodel.Operacion);



            if ((!ModelState.IsValid) || sumapartes < 0 || sumapartes != 100)
            {


                ModelState.AddModelError("Aplicacion", "La suma de los porcentajes de Aplicacion, herramienta y Operación debe ser 100");
                return View();
            }
            else
            {
                if (datamodel.Id == 0)
                {
                    db.Configuraciones.Add(datamodel);
                    db.SaveChanges();

                }
            }
            

            if (datamodel.Id == 0 || datamodel.Metodo1 != null && datamodel.Metodo1 != 0)
            {
                IMPSOR.Services.GrabarConfiguracion(datamodel);
            }
           
            ViewBag.Message = "Your contact page.";
            return View(datamodel);
        }
       
    }
}