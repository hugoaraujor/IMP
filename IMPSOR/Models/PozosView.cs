using IMPSOR.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IMPSOR
{
    public class PozosView
    {
        public PozosView()
        {
            campo = 0;
            yacimiento = 0;

        }
        public int metodo { get; set; }
        public IEnumerable<Pregunta> Preguntas { get; set; }
        public PagedList.IPagedList<PozosViewDetail> Detalle { get; set; }
        public IEnumerable<SelectListItem> campos { get; set; }
        public IEnumerable<SelectListItem> yacimientos { get; set; }
        public int? campo { get; set; }
        public int? yacimiento { get; set; }
        [DisplayName("   Procesados")]
        public bool procesados { get; set; }

    }
}