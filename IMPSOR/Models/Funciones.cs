using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IMPSOR
{
    [Table("Funciones")]
    public class Funcion
    {
        [Key]
        public int Idfuncion { get; set; }
        public string Func { get; set; }
        public int Metodo { get; set; }
    }
}