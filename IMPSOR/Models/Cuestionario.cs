using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IMPSOR.Models
{
    public class Cuestionario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCase { get; set; }
        public string Cuestionario_name { get; set; }
        public int Metodo { get; set; }

    }
}