using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMPSOR
{
    public class dat_NucleosPozo
    {
        public int id_dat_NucleosPozo { get; set; }

        public int id_region { get; set; }

        public int id_activo { get; set; }

        public int id_campo { get; set; }

        public int id_yacimiento { get; set; }

        public int id_pozo { get; set; }

        public string archivo { get; set; }

        public int? Num_muestra { get; set; }

        public int? Num_nucleo { get; set; }

        public string X { get; set; }

        public string Y { get; set; }

        public decimal? Profundidad { get; set; }

        public int? id { get; set; }

        public string edad { get; set; }

        public decimal? Peso_de_la_Muestra_gr { get; set; }

        public decimal? Vol_Roca_cm3 { get; set; }

        public decimal? Vol_de_HG_Inyectado_cm3 { get; set; }

        public decimal? Vol_Agua_800_F_Cm3 { get; set; }

        public decimal? Vol_Agua_1200_F_Cm3 { get; set; }

        public decimal? Vol_Aceite_observado_cm3 { get; set; }

        public decimal? Vol_Aceite_corregido_cm3 { get; set; }

        public decimal? Densidad_de_la_Roca_gr_cm { get; set; }

        public decimal? Vol_total_Roca_cm3 { get; set; }

        public decimal? Vol_Gas_p { get; set; }

        public decimal? Vol_Aceite_p { get; set; }

        public decimal? Vol_Agua_p { get; set; }

        public decimal? Porosidad_p { get; set; }

        public decimal? saturación_de_Aceite_p { get; set; }

        public decimal? saturación_de_Agua_p { get; set; }

        public decimal? P { get; set; }

        public decimal? VTR { get; set; }

        public decimal? Vg { get; set; }

        public decimal? Vo { get; set; }

        public decimal? Vw { get; set; }

        public decimal? O { get; set; }

        public decimal? So { get; set; }

        public decimal? Sw { get; set; }

        public decimal? KoSwi { get; set; }

        public decimal? Sor { get; set; }

        public decimal? Swi { get; set; }

        public decimal? Krw { get; set; }

        public string usuario { get; set; }

        public DateTime fecha_creacion { get; set; }

        public DateTime fecha_actualizacion { get; set; }

        public int id_vigencia { get; set; }

    }

}