using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMPSOR.Models
{
    public class dat_sor_pozo
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int id_dat_sor_pozo { get; set; }

        public int id_region { get; set; }

        public int id_activo { get; set; }

        public int id_campo { get; set; }

        public int id_yacimiento { get; set; }

        public int id_pozo { get; set; }

        public string region { get; set; }

        public string activo { get; set; }

        public string campo { get; set; }

        public string yacimiento { get; set; }

        public string pozo { get; set; }

        public string Coord_X { get; set; }

        public string Coord_Y { get; set; }

        public decimal? presion_sat_campo { get; set; }

        public decimal? fact_vol_agua { get; set; }

        public decimal? viscosidad_agua { get; set; }

        public decimal? swi_campo { get; set; }

        public decimal? Vol_original_Campo { get; set; }

        public decimal? Sor { get; set; }

        public string Intervalo_1 { get; set; }

        public decimal? swi_1 { get; set; }

        public int? id_ResultadosCurvas { get; set; }

        public string tipo_curva_coef { get; set; }

        public string tipo_tendencia { get; set; }

        public string metodo { get; set; }

        public int? grado { get; set; }

        public decimal? a0 { get; set; }

        public decimal? a1 { get; set; }

        public decimal? a2 { get; set; }

        public decimal? a3 { get; set; }

        public decimal? a4 { get; set; }

        public decimal? a5 { get; set; }

        public decimal? a6 { get; set; }

        public decimal? Vol_aceite_bls { get; set; }

        public decimal? Vol_gas_mmpc { get; set; }

        public decimal? Vol_agua_bls { get; set; }

        public DateTime? fecha_min { get; set; }

        public DateTime? fecha_max { get; set; }

        public DateTime? fecha_creacion { get; set; }

    }
}