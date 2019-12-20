using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMPSOR
{
    public static class Extensions
    {
            public static decimal ToDecimal(this string str)
            {
             
                if (string.IsNullOrEmpty(str))
                    return 0;

                decimal d;

      
                if (!decimal.TryParse(str, out d))
                    return 0;

                return d;
        
            }
    }
}