using IMPSOR.Interfaces;
using IMPSOR.Servicios;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
namespace IMPSOR
{
    public static  class Services
    {
        public static DataContext db = new DataContext();
        private static string[] ColorGradients = new string[] { "#ff0000", "#ff6a00", "#ffd800", "#4cff00", "#00ffff", "#4800ff", "#b200ff" };
        public static IMethods _currentmethod;

        public  static void Set(IMethods method)
        {
            
            _currentmethod = method;
            

        }
        public static string GetMethodName(int metodo)
        {
            Services.Set(MethodProvider.Get(metodo));
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
        public static IEnumerable<GraphData2View> Getgraphdata(int? campo, int? yacimiento, int metodo)
        {
           
            IEnumerable<GraphData2View> records = new List<GraphData2View>();
            if (metodo !=0)
            {
                try
                 {
                    records = _currentmethod.getDetails(campo, yacimiento);
                }
                 catch { }
            }
            return records;

        }
        public static List<GraphData2View> Getgraphdata2(int? campo, int? yacimiento, int? Sor, int metodo = 1)
        {
            
            (db as IObjectContextAdapter).ObjectContext.CommandTimeout = 1000;
            var detalles = db.GetResultsGraphData(campo, yacimiento).ToList();
            return detalles;

        }

        public static string getGraphDotColor(decimal? valor)
        {
           if (valor <= 0)
             valor = 0.01M;
           string retorno = "";
            int percent = 0;
            try
            {
                percent = Convert.ToInt16(Math.Floor((valor.Value)) * 6) / 100;
            }
            catch
            { 
            
            }
           retorno = (ColorGradients[6 - (percent)]);
           return retorno;
        }
       

    } 
}
