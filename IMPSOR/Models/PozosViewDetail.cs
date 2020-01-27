using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IMPSOR
{
    public class PozosViewDetail
    {
        public bool selected { get; set; }
        public string region { get; set; }
        public string activo { get; set; }
        public int id_campo { get; set; }
        public string campo { get; set; }
        public int id_yacimiento { get; set; }
        public string yacimiento { get; set; }
        public string tipo_yacimiento { get; set; }
        public string pozo { get; set; }
        public string estado { get; set; }
        public int id_pozo { get; set; }
        public string estatus { get; set; }
        // [DisplayFormat(DataFormatString = "{0:0.####}")]
        //public decimal? sormean1 { get; set; }
        public string curvas { get; set; }
        public decimal Confiabilidad { get; set; }
        public decimal Confiabilidad1 { get; set; }
        public decimal Confiabilidad2 { get; set; }
        public decimal Confiabilidad3 { get; set; }
        public decimal Confiabilidad4{ get; set; }
        public decimal Confiabilidad5 { get; set; }
        public decimal Confiabilidad6 { get; set; }
                //[DisplayFormat(DataFormatString = "{0:#,##0.0000#}", ConvertEmptyStringToNull = true, NullDisplayText = " ", ApplyFormatInEditMode = true)]
        public decimal? sor { get; set; }
        public double? sormean1 { get; set; }
        [DisplayFormat(DataFormatString = "{0:#,##0.0000#}", ConvertEmptyStringToNull = true, NullDisplayText = " ", ApplyFormatInEditMode = true)]
        public double? sormean2 { get; set; }
        [DisplayFormat(DataFormatString = "{0:#,##0.0000#}", ConvertEmptyStringToNull = true, NullDisplayText = " ", ApplyFormatInEditMode = true)]
        public double? sormean3 { get; set; }
        [DisplayFormat(DataFormatString = "{0:#,##0.0000#}", ConvertEmptyStringToNull = true, NullDisplayText = " ", ApplyFormatInEditMode = true)]
        public double? sormean4 { get; set; }
        [DisplayFormat(DataFormatString = "{0:#,##0.0000#}", ConvertEmptyStringToNull = true, NullDisplayText = " ", ApplyFormatInEditMode = true)]
        public double? metodo1_m { get; set; }
        [DisplayFormat(DataFormatString = "{0:#,##0.0000#}", ConvertEmptyStringToNull = true, NullDisplayText = " ", ApplyFormatInEditMode = true)]
        public double? metodo2_m { get; set; }
        [DisplayFormat(DataFormatString = "{0:#,##0.0000#}", ConvertEmptyStringToNull = true, NullDisplayText = " ", ApplyFormatInEditMode = true)]
        public double? metodo3_m { get; set; }
        [DisplayFormat(DataFormatString = "{0:#,##0.0000#}", ConvertEmptyStringToNull = true, NullDisplayText = " ", ApplyFormatInEditMode = true)]
        public double? metodo4_m { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0.0000#}", ConvertEmptyStringToNull = true, NullDisplayText = " ", ApplyFormatInEditMode = true)]
        public double? picket1_m { get; set; }
        [DisplayFormat(DataFormatString = "{0:#,##0.0000#}", ConvertEmptyStringToNull = true, NullDisplayText = " ", ApplyFormatInEditMode = true)]
        public double? picket1_Rmf { get; set; }
        [DisplayFormat(DataFormatString = "{0:#,##0.0000#}", ConvertEmptyStringToNull = true, NullDisplayText = " ", ApplyFormatInEditMode = true)]
        public double? picket2_m { get; set; }
        [DisplayFormat(DataFormatString = "{0:#,##0.0000#}", ConvertEmptyStringToNull = true, NullDisplayText = " ", ApplyFormatInEditMode = true)]
        public double? picket2_Rmf { get; set; }
        [DisplayFormat(DataFormatString = "{0:#,##0.0000#}", ConvertEmptyStringToNull = true, NullDisplayText = " ", ApplyFormatInEditMode = true)]
        public double? picket3_m { get; set; }
        [DisplayFormat(DataFormatString = "{0:#,##0.0000#}", ConvertEmptyStringToNull = true, NullDisplayText = " ", ApplyFormatInEditMode = true)]
        public double? picket3_Rmf { get; set; }
        [DisplayFormat(DataFormatString = "{0:#,##0.0000#}", ConvertEmptyStringToNull = true, NullDisplayText = " ", ApplyFormatInEditMode = true)]
        public double? picket4_m { get; set; }
        [DisplayFormat(DataFormatString = "{0:#,##0.0000#}", ConvertEmptyStringToNull = true, NullDisplayText = " ", ApplyFormatInEditMode = true)]
        public double? picket4_Rmf { get; set; }
        [DisplayFormat(DataFormatString = "{0:#,##0.0000#}", ConvertEmptyStringToNull = true, NullDisplayText = " ", ApplyFormatInEditMode = true)]
        public decimal? sor1 { get; set; }
        [DisplayFormat(DataFormatString = "{0:#,##0.0000#}", ConvertEmptyStringToNull = true, NullDisplayText = " ", ApplyFormatInEditMode = true)]
        public decimal? sor2 { get; set; }
        [DisplayFormat(DataFormatString = "{0:#,##0.0000#}", ConvertEmptyStringToNull = true, NullDisplayText = " ", ApplyFormatInEditMode = true)]
        public decimal? sor3 { get; set; }
        [DisplayFormat(DataFormatString = "{0:#,##0.0000#}", ConvertEmptyStringToNull = true, NullDisplayText = " ", ApplyFormatInEditMode = true)]
        public decimal? sor4 { get; set; }
        [DisplayFormat(DataFormatString = "{0:#,##0.0000#}", ConvertEmptyStringToNull = true, NullDisplayText = " ", ApplyFormatInEditMode = true)]
        public decimal? sor5 { get; set; }
        [DisplayFormat(DataFormatString = "{0:#,##0.0000#}", ConvertEmptyStringToNull = true, NullDisplayText = " ", ApplyFormatInEditMode = true)]
        public decimal? sor6 { get; set; }

        public string RespuestasCuestionario1 { get; set; }
        public string RespuestasCuestionario2 { get; set; }
        public string RespuestasCuestionario3 { get; set; }
        public string RespuestasCuestionario4 { get; set; }
        public string RespuestasCuestionario5 { get; set; }
        public string RespuestasCuestionario6 { get; set; }
        public string x_sup { get; set; }
        public string y_sup { get; set; }
        public double? profIni { get; set; }
        public decimal? numsor { get; set; }
    }
}