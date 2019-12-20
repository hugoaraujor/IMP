using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IMPSOR { 
  
        [Table("Configuraciones")]
        public class Configuracion
        {
            [Key]
            public int Id { get; set; }
            public enfoque enfoqueId { get; set; }
        [Required]
        [Range(typeof(decimal), "0", "100")]
        [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Porcentaje Metodo 1 Invalido solo valores de (0-100) con punto(.) decimal")]
        
        public decimal? Metodo1 { get; set; }
        [Required]
        [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Porcentaje Metodo 2  Invalido solo valores de (0-100) con punto(.) decimal")]
        [Range(typeof(decimal), "0", "100")]
        public decimal? Metodo2 { get; set; }
        [Required]
        [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Porcentaje Metodo 3 Invalido solo valores de (0-100) con punto(.) decimal")]
        [Range(typeof(decimal), "0", "100")]
        public decimal? Metodo3 { get; set; }

        [Required]
        [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Porcentaje Metodo 4  Invalido solo valores de (0-100) con punto(.) decimal")]
        [Range(typeof(decimal), "0", "100")]
        public decimal? Metodo4 { get; set; }
        [Required]
        [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Porcentaje Metodo 5  Invalido solo valores de (0-100) con punto(.) decimal")]
        [Range(typeof(decimal), "0", "100")]
        public decimal? Metodo5 { get; set; }
        [Required]
        [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Porcentaje Metodo 6  Invalido solo valores de (0-100) con punto(.) decimal")]
        [Range(typeof(decimal), "0", "100")]
        public decimal? Metodo6 { get; set; }
        [Required]
        [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Porcentaje Herramienta  Invalido solo valores de (0-100) con punto(.) decimal")]
        [Range(typeof(decimal), "0", "100")]
        public decimal? Herramienta { get; set; }
        [Required]
        [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Porcentaje Operación solo valores de (0-100) con punto(.) decimal")]
        [Range(typeof(decimal), "0", "100")]
        public decimal? Operacion { get; set; }
        [Required]
        [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Porcentaje Aplicación solo valores de (0-100) con punto(.) decimal")]
        [Range(typeof(decimal), "0", "100")]
        public decimal? Aplicacion{ get; set; }
        [Timestamp]
         public byte[] Updated { get; set; }


        
    }

    


    public enum enfoque
        {
            Optimista = 0,
            Pesimista = 1

        }
    }
