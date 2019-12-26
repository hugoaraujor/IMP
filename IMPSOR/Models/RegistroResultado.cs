using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IMPSOR
{
    [Table("RegistroResultado")]
    public class RegistroResultado
    {
        public int Id { get; set; }

        public int? PozoId { get; set; }

        public double RHOf { get; set; }

        public double zgas { get; set; }

        public double ish_const { get; set; }

        public double? ish_base { get; set; }

        public double? mPorDen { get; set; }

        public double? RHO_ma { get; set; }

        public double? RHO_prom { get; set; }

        public double? GR_min { get; set; }

        public double? GR_max { get; set; }

        public double? lineal_m { get; set; }

        public double? lineal_b { get; set; }

        public double? lineal_x0 { get; set; }

        public double? metodo1_m { get; set; }

        public double? metodo1_b { get; set; }

        public double? metodo1_x0 { get; set; }

        public double? metodo2_m { get; set; }

        public double? metodo2_b { get; set; }

        public double? metodo2_x0 { get; set; }

        public double? metodo3_m { get; set; }

        public double? metodo3_b { get; set; }

        public double? metodo3_x0 { get; set; }

        public double? metodo4_m { get; set; }

        public double? metodo4_b { get; set; }

        public double? metodo4_x0 { get; set; }

        public double? picket1_m { get; set; }

        public double? picket1_Rmf { get; set; }

        public double? picket2_m { get; set; }

        public double? picket2_Rmf { get; set; }

        public double? picket3_m { get; set; }

        public double? picket3_Rmf { get; set; }

        public double? picket4_m { get; set; }

        public double? picket4_Rmf { get; set; }

        public int? id_gr { get; set; }

        public int? id_msfl { get; set; }

        public int? id_nphi { get; set; }

        public int? id_rhob { get; set; }

        public int? id_ish { get; set; }

        public int? id_vsh { get; set; }

        public int? id_PHIe { get; set; }

        public int? id_porDen { get; set; }

        public int? id_pickett1 { get; set; }

        public int? id_pickett2 { get; set; }

        public int? id_pickett3 { get; set; }

        public int? id_pickett4 { get; set; }

        public double? sormean1 { get; set; }

        public double? sormean2 { get; set; }

        public double? sormean3 { get; set; }

        public double? sormean4 { get; set; }

        public double? profIni { get; set; }

        public double? profFin { get; set; }

    }
}