using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IMPSOR
{
    public class cat_campo
    {
        [Key]
        public int id_campo { get; set; }

        public int id_activo { get; set; }

        public string campo { get; set; }

        public DateTime fecha_creacion { get; set; }

        public DateTime fecha_actualizacion { get; set; }

        public int id_vigencia { get; set; }

    }
}