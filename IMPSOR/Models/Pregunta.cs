using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IMPSOR.Models
{
    public class Pregunta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdQuestion { get; set; }
        public int IdCase { get; set; }
        public int idPregunta { get; set; }

        public string Enunciate { get; set; }
        public string Condicioneval { get; set; }
        public string operador { get; set; }
        public string valor { get; set; }

        public string ExpressionSi { get; set; }
        public string conector { get; set; }
        public int Metodo { get; set; }
        public Ambito ambito { get; set; }
    }

}