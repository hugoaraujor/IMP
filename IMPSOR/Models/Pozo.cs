using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IMPSOR
{
    [Table("cat_pozo")]
    public class Pozo
    {
        [Key]
        public int id_pozo { get; set; }

        public string pozo { get; set; }

        public string estatus_pozo { get; set; }

        public int id_tipo_pozo { get; set; }

        public DateTime fecha_creacion { get; set; }

        public DateTime fecha_actualizacion { get; set; }

        public int id_vigencia { get; set; }

    }
}