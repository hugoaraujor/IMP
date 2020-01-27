using IMPSOR.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMPSOR.Servicios
{
    public class Metodo4 : IMethods
    {
        private static DataContext db = new DataContext();
        public List<PozosViewDetail> detalles(int? campo, int? yacimiento)
        {
            return db.GetPozos(campo, yacimiento).Where(w => w.estado == "Procesado").ToList();
        }

        public IEnumerable<GraphData2View> getDetails(int? campo, int? yacimiento, int? idPozo = 0)
        {
            var detalles = this.detalles(campo, yacimiento);
            var records = from d in detalles
                          join g in db.dat_Datos_metodo_PVP on d.id_pozo equals g.id_pozo
                          join f in db.dat_Datos_metodo_PVP_Resultado on g.id_dat_Datos_metodo_PVP equals f.id_dat_Datos_metodo_PVP
                          orderby d.id_campo
                          select new GraphData2View() { pname = d.pozo, x = Convert.ToInt32(d.x_sup), y = Convert.ToInt32(d.y_sup), z = Convert.ToInt32(d.profIni), color = Services.getGraphDotColor(Math.Round(Convert.ToDecimal(f.sor * d.Confiabilidad4), 2)), percentage = Math.Round(Convert.ToDouble(f.sor * d.Confiabilidad4), 2) * 100 };
            return records;
        }

        public decimal getSor(int idPozo)
        {
            decimal sor = 0;
            var result = (from d in db.dat_Datos_metodo_PVP
                            join f in db.dat_Datos_metodo_PVP_Resultado on d.id_dat_Datos_metodo_PVP equals f.id_dat_Datos_metodo_PVP
                            where d.id_pozo == idPozo
                            select new { f.sor }).FirstOrDefault();
            
            if (result!= null)
               sor = Convert.ToDecimal(result.sor);
            return sor;
        }
    }
}