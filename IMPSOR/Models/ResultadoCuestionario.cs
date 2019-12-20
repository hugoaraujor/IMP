using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IMPSOR
{

    [Table("ResultadoCuestionarios")]
    public class ResultadoCuestionario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdRC { get; set; }
        public bool included { get; set; }
        public int IdPozo { get; set; }
        public decimal? sor { get; set; }
        [DisplayFormat(DataFormatString = "{0:#,##0.00000#}", ConvertEmptyStringToNull = true, NullDisplayText = " ", ApplyFormatInEditMode = true)]
        public decimal? sor1 { get; set; }
        [DisplayFormat(DataFormatString = "{0:#,##0.00000#}", ConvertEmptyStringToNull = true, NullDisplayText = " ", ApplyFormatInEditMode = true)]
        public decimal? sor2 { get; set; }
        [DisplayFormat(DataFormatString = "{0:#,##0.00000#}", ConvertEmptyStringToNull = true, NullDisplayText = " ", ApplyFormatInEditMode = true)]
        public decimal? sor3 { get; set; }
        [DisplayFormat(DataFormatString = "{0:#,##0.00000#}", ConvertEmptyStringToNull = true, NullDisplayText = " ", ApplyFormatInEditMode = true)]
        public decimal? sor4 { get; set; }
        [DisplayFormat(DataFormatString = "{0:#,##0.00000#}", ConvertEmptyStringToNull = true, NullDisplayText = " ", ApplyFormatInEditMode = true)]
        public decimal? sor5 { get; set; }
        [DisplayFormat(DataFormatString = "{0:#,##0.00000#}", ConvertEmptyStringToNull = true, NullDisplayText = " ", ApplyFormatInEditMode = true)]
        public decimal? sor6 { get; set; }
        public string curvas { get; set; }
        public decimal Confiabilidad { get; set; }
        public decimal Confiabilidad1 { get; set; }
        public decimal Confiabilidad2 { get; set; }
        public decimal Confiabilidad3 { get; set; }
        public decimal Confiabilidad4 { get; set; }
        public decimal Confiabilidad5 { get; set; }
        public decimal Confiabilidad6 { get; set; }

        public string RespuestasCuestionario1 { get; set; }
        public string RespuestasCuestionario2 { get; set; }
        public string RespuestasCuestionario3 { get; set; }
        public string RespuestasCuestionario4 { get; set; }
        public string RespuestasCuestionario5 { get; set; }
        public string RespuestasCuestionario6 { get; set; }
    }
}