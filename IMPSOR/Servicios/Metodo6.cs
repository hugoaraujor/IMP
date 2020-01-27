using IMPSOR.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMPSOR.Servicios
{
    public class Metodo6 : IMethods
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
                          join g in db.dat_sor_pozo on d.id_pozo equals g.id_pozo
                          select new GraphData2View() { pname = d.pozo, x = Convert.ToInt32(d.x_sup), y = Convert.ToInt32(d.y_sup), z = Convert.ToInt32(d.profIni), color = Services.getGraphDotColor(Math.Round(Convert.ToDecimal(g.Sor * d.Confiabilidad6), 2)), percentage = Math.Round(Convert.ToDouble(g.Sor * d.Confiabilidad6), 2) * 100 };
            return records;
        }

        public decimal getSor(int idPozo)
        {
            decimal sor = 0;
            var result = (from g in db.dat_sor_pozo where g.id_pozo == idPozo select new { g.Sor }).FirstOrDefault();
            if (result != null)
               sor = Convert.ToDecimal(result);
            return sor;
        }
    }
}