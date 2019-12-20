using IMPSOR.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
namespace IMPSOR
{
    public class Services
    {
        public static DataContext db = new DataContext();
        private static string[] ColorGradients = new string[] { "#ff0000", "#ff6a00", "#ffd800", "#4cff00", "#00ffff", "#4800ff", "#b200ff" };
        public static string GetMethodName(int metodo)
        {
            return db.Cuestionarios.Where(m => m.Metodo == metodo).SingleOrDefault().Cuestionario_name;
        }
       
            public static void GrabarConfiguracion(Configuracion datamodel)
        {
            var data = db.Configuraciones.Where(w => w.Id == datamodel.Id).FirstOrDefault();
            data.enfoqueId = datamodel.enfoqueId;
            data.Metodo1 = datamodel.Metodo1;
            data.Metodo2 = datamodel.Metodo2;
            data.Metodo3 = datamodel.Metodo3;
            data.Metodo4 = datamodel.Metodo4;
            data.Metodo5 = datamodel.Metodo5;
            data.Metodo6 = datamodel.Metodo6;
            data.Herramienta = datamodel.Herramienta;
            data.Aplicacion = datamodel.Aplicacion;
            data.Operacion = datamodel.Operacion;
            db.Configuraciones.Attach(data);
            db.Entry(data).State = EntityState.Modified;
            db.SaveChanges();
       }
        public static IEnumerable<GraphData2View> Getgraphdata(int? campo,int? yacimiento,int metodo)
        {
                var detalles = db.GetPozos(campo, yacimiento).Where(w => w.estado == "Procesado").ToList();
                IEnumerable<GraphData2View> records = new List<GraphData2View>();
            if (metodo != 0)
            {
                try
                {
                    records = from d in detalles
                              join b in db.cat_pozos_coords on d.id_pozo equals b.IdPozo
                              join c in db.RegistroResultado on b.IdPozo equals c.PozoId
                              join e in db.ResultadoCuestionarios on d.id_pozo equals e.IdPozo
                              join h in db.rel_campo_yacimiento_pozo on d.id_pozo equals h.id_pozo
                              join i in db.cat_yacimiento on h.id_yacimiento equals i.id_yacimiento
                              where i.id_yacimiento == yacimiento && i.id_campo == campo
                              select new GraphData2View() { x = b.x, y = Convert.ToInt32(b.y), z = Convert.ToInt32(c.profIni), color = getGraphDotColor(Math.Round(Convert.ToDecimal(e.GetType().GetProperty("sor" + metodo.ToString()).GetValue(e).ToString()), 2) ), pname = d.pozo, percentage = Math.Round(Convert.ToDouble(e.GetType().GetProperty("sor" + metodo.ToString()).GetValue(e)), 2) * 100 };

                }
                catch { }
            }
            return records;
          
        }
        public static List<GraphData2View> Getgraphdata2(int? campo, int? yacimiento,int? Sor, int metodo=1)
        { 
            (db as IObjectContextAdapter).ObjectContext.CommandTimeout = 1000;
            var detalles = db.GetResultsGraphData(campo, yacimiento, Sor).ToList();
            return detalles;
          
        }
        
        public static  string getGraphDotColor(decimal? valor)
        {
            if (valor <= 0)
                valor = 0.01M;
            string retorno = "";
            int percent = Convert.ToInt16(Math.Floor(((valor.Value*100)*6)/100));
            retorno = (ColorGradients[6 - (percent)]);
            return retorno;
        }
        
    }
}