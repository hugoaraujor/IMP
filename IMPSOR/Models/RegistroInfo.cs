using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IMPSOR
{
    [Table("RegistroInfo")]
    public class RegistroInfo
    {
        public int Id { get; set; }

        public string Alias { get; set; }

        public int PozoId { get; set; }

        public int? LASId { get; set; }

        public int MnemonicoId { get; set; }

        public int MetodoId { get; set; }

        public int? padreId { get; set; }

        public int? RegistroResultadoId { get; set; }

    }
}