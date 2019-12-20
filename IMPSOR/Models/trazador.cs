using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IMPSOR.Models
{
    [Table("trazadores")]
    public class trazador
    {
        public int Id { get; set; }

        public int PozoId { get; set; }

        public string cve_modelo { get; set; }

        public string parametros { get; set; }

        public string resultados { get; set; }

        public double? sor { get; set; }

    }
}