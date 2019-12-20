using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IMPSOR
{
    [Table("cat_pozos_coords")]
    public class cat_pozos_coord
    {
        [Key]
        public decimal x { get; set; }

        public decimal y { get; set; }

        public int IdPozo { get; set; }
    }
}