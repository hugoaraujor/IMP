using IMPSOR.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMPSOR.Servicios
{

    public class Metodo3 : IMethods
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
                          join F in db.trazadores on d.id_pozo equals F.PozoId
                          join h in db.rel_campo_yacimiento_pozo on d.id_pozo equals h.id_pozo
                          join i in db.cat_yacimiento on h.id_yacimiento equals i.id_yacimiento
                          where i.id_yacimiento == yacimiento && i.id_campo == campo
                          select new GraphData2View() { x = Convert.ToInt32(d.x_sup), y = Convert.ToInt32(d.y_sup), z = Convert.ToInt32(d.profIni), color = Services.getGraphDotColor(Math.Round(Convert.ToDecimal(F.sor) * d.Confiabilidad3, 2)), pname = d.pozo, percentage = Math.Round(Convert.ToDouble(F.sor * Convert.ToDouble(d.Confiabilidad3)) * 100, 2) };
            return records;
        }

        public decimal getSor(int idPozo)
        {
            decimal sor = 0;
            var result = (from a in db.trazadores where a.PozoId == idPozo select a).FirstOrDefault();
            if (result != null)
                sor=Convert.ToDecimal(result.sor);
            return sor;

        }
    }
}