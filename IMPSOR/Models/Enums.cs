using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMPSOR.Models
{
    public enum action
    {
        Add,
        Update
    }

    public enum MeasureTypes
    {
        Puntual = 1,
        Vector = 2
    }


    public enum fType
    {
        Entero = 1,
        Doble = 2,
        Logical = 3
    }

    public enum Ambito
    {
        Herramienta = 0,
        Operacion = 1,
        Aplicacion = 2
    }

}