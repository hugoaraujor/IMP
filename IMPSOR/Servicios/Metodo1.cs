using IMPSOR.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMPSOR.Servicios
{
    public class Metodo1 : IMethods
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
                          join c in db.RegistroResultado on d.id_pozo equals c.PozoId
                          join e in db.ResultadoCuestionarios on d.id_pozo equals e.IdPozo
                          join h in db.rel_campo_yacimiento_pozo on d.id_pozo equals h.id_pozo
                          join i in db.cat_yacimiento on h.id_yacimiento equals i.id_yacimiento
                          where i.id_yacimiento == yacimiento && i.id_campo == campo
                          select new GraphData2View() { x = Convert.ToInt32(c.x_sup), y = Convert.ToInt32(c.y_sup), z = Convert.ToInt32(c.profIni), color = Services.getGraphDotColor(Math.Round(Convert.ToDecimal(e.GetType().GetProperty("sor" + c.numsor.ToString()).GetValue(e).ToString()), 2)), pname = d.pozo, percentage = Math.Round(Convert.ToDouble(e.GetType().GetProperty("sor" + c.numsor.ToString()).GetValue(e)), 2) * 100 };
            return records;
        }

        public decimal getSor(int idPozo)
        {
            decimal sor = 0;
            var result = db.GetResults().ToList().Where(w => w.PozoId == idPozo).FirstOrDefault();
            var sorresultindex = SeleccionaSor.Get(ref result);
            if (result != null)
                sor = Convert.ToDecimal(result.GetType().GetProperty("sormean" + (sorresultindex + 1).ToString()).GetValue(result));
            return sor;
        }
    }
}