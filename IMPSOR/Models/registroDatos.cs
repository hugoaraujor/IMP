using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMPSOR.Models
{

    public class registroDatos
    {
        public int Id { get; set; }

        public int RegistroInfoId { get; set; }

        public double Profundidad { get; set; }

        public double? Valor { get; set; }

    }
}