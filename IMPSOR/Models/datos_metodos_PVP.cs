using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IMPSOR.Models
{
    public class dat_Datos_metodo_PVP
    {   [Key]
        public int id_dat_Datos_metodo_PVP { get; set; }
        public int? id_rel_campo_yac_pozo { get; set; }

        public int? id_campo { get; set; }

        public int? id_yacimiento { get; set; }

        public int? id_pozo { get; set; }

        public string metodo { get; set; }

        public int? Numero { get; set; }

        public string Pozo { get; set; }

        public DateTime? fecha { get; set; }

        public string intervalo { get; set; }

        public string prueba { get; set; }

        public decimal? espesor { get; set; }

        public decimal? pws { get; set; }

        public decimal? ko { get; set; }

        public decimal? kw { get; set; }

        public decimal? bo { get; set; }

        public decimal? mo { get; set; }

        public decimal? mw { get; set; }

        public decimal? bw { get; set; }

        public decimal? qo { get; set; }

        public decimal? qw { get; set; }

        public decimal? tp { get; set; }

        public DateTime fecha_creacion { get; set; }

    }
    public class dat_Datos_metodo_PVP_Resultado
    { [Key]
        public int id_dat_Datos_metodo_PVP_resultado { get; set; }
        public int? id_dat_Datos_metodo_PVP { get; set; }
        public string pozo { get; set; }
        public string metodo { get; set; }
        public string tipo_prueba { get; set; }
        public int? id_dat_Nucleos_Curva { get; set; }
        public string pozo_ecuacion { get; set; }
        public string muestra { get; set; }
        public string descripcion_muestra { get; set; }
        public string metodo_tendencia { get; set; }
        public string tipo_tendencia { get; set; }
        public string tipo_curva_coef { get; set; }
        public int? grado { get; set; }
        public decimal? a0 { get; set; }
        public decimal? a1 { get; set; }
        public decimal? a2 { get; set; }
        public decimal? a3 { get; set; }
        public decimal? a4 { get; set; }
        public decimal? a5 { get; set; }
        public decimal? a6 { get; set; }
        public decimal? porosidad { get; set; }
        public decimal? sor { get; set; }
        public decimal? swi { get; set; }
        public decimal? so { get; set; }
        public decimal? Ac_movil { get; set; }
        public decimal? sw { get; set; }

    }

}