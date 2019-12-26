using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IMPSOR
{



    [Table("respuestasPozos")]
    public class RespuestasPozo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Idpozo { get; set; }
        public int idPregunta { get; set; }
        public int metodo { get; set; }
        public string Respuesta { get; set; }


    }
}