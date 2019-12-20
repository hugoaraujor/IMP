using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IMPSOR.Models
{

    [Table("Pozo_Seleccion")]
    public class Pozo_Seleccion
    {
        [Key]
        public int IdPozo { get; set; }
        public bool Seleccionado { get; set; }
    }

}