using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IMPSOR
{
    [Table("cat_yacimiento")]
    public class cat_yacimiento
    {
        [Key]
        public int id_yacimiento { get; set; }

        public int id_campo { get; set; }

        public string yacimiento { get; set; }

        public int id_tipo_yacimiento { get; set; }

        public DateTime fecha_creacion { get; set; }

        public DateTime fecha_actualizacion { get; set; }

        public int id_vigencia { get; set; }



    }
}