using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IMPSOR
{
    [Table("rel_campo_yacimiento_pozo")]
    public class rel_campo_yacimiento_pozo
    {
        [Key]
        public int id_rel_campo_yacimiento_pozo { get; set; }

        public int id_yacimiento { get; set; }

        public int id_pozo { get; set; }

        public DateTime fecha_creacion { get; set; }

        public DateTime fecha_actualizacion { get; set; }

        public int id_vigencia { get; set; }

    }
}