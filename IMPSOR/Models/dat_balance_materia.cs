using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IMPSOR.Models
{
    public class dat_balanace_Materia
    {   
        public  int id_balance { get; }
        public int id_Campo { get; set; }

        public int id_Yacimiento { get; set; }

        public decimal? profundidad { get; set; }

        public decimal? Espesor_medio { get; set; }

        public decimal? N { get; set; }

        public decimal? G { get; set; }

        public decimal? NBoi { get; set; }

        public decimal? DDI { get; set; }

        public decimal? SDI { get; set; }

        public decimal? WDI { get; set; }

        public decimal? EDI { get; set; }

        public decimal? SumaDI { get; set; }

        public decimal? FroAct { get; set; }

        public decimal? FrgAct { get; set; }

        public decimal? ROA { get; set; }

        public decimal? ROGN { get; set; }

        public decimal? RRA { get; set; }

        public decimal? RRGN { get; set; }

        public decimal? We { get; set; }

        public decimal? Wact { get; set; }

        public decimal? Sor { get; set; }

        public decimal? conv_Np { get; set; }

        public decimal? conv_Boi { get; set; }

        public decimal? conv_Bo { get; set; }

        public decimal? conv_Rsi { get; set; }

        public decimal? conv_Rs { get; set; }

        public decimal? conv_Bgi { get; set; }

        public decimal? conv_Bg { get; set; }

        public decimal? conv_We { get; set; }

        public decimal? conv_Bw { get; set; }

        public decimal? conv_Wp { get; set; }

        public decimal? conv_m { get; set; }

        public decimal? conv_Cw { get; set; }

        public decimal? conv_Sw { get; set; }

        public decimal? conv_Cf { get; set; }

        public decimal? conv_Pi { get; set; }

        public decimal? conv_Pb { get; set; }

        public decimal? conv_Pact { get; set; }

        public decimal? conv_Fro { get; set; }

        public decimal? conv_Frg { get; set; }

        public decimal? conv_Gp { get; set; }

        public decimal? conv_Bob { get; set; }

        public decimal? conv_Npb { get; set; }

        public string conv_unidad_Np { get; set; }

        public string conv_unidad_Boi { get; set; }

        public string conv_unidad_Bo { get; set; }

        public string conv_unidad_Rsi { get; set; }

        public string conv_unidad_Rs { get; set; }

        public string conv_unidad_Bgi { get; set; }

        public string conv_unidad_Bg { get; set; }

        public string conv_unidad_We { get; set; }

        public string conv_unidad_Bw { get; set; }

        public string conv_unidad_Wp { get; set; }

        public string conv_unidad_m { get; set; }

        public string conv_unidad_Cw { get; set; }

        public string conv_unidad_Sw { get; set; }

        public string conv_unidad_Cf { get; set; }

        public string conv_unidad_Pi { get; set; }

        public string conv_unidad_Pb { get; set; }

        public string conv_unidad_Pact { get; set; }

        public string conv_unidad_Fro { get; set; }

        public string conv_unidad_Frg { get; set; }

        public string conv_unidad_Gp { get; set; }
        public string conv_unidad_Bob { get; set; }
        public string conv_unidad_Npb { get; set; }
        [Key]
        public DateTime? fecha_creacion { get; set; }

    }
}