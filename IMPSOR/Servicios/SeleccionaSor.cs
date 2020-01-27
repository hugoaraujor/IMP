using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMPSOR.Servicios
{
    public static class SeleccionaSor
    {
        public static int Get(ref RegistroResultado registro)
        {
            decimal promedio = 0;
            int finalindex = 1;
            if (registro != null)
            {
                promedio = Convert.ToDecimal((registro.sormean1 == null ? 0 : registro.sormean1 + registro.sormean2 == null ? 0 : registro.sormean2 + (registro.sormean3 == null ? 0 : registro.sormean3) + (registro.sormean4 == null ? 0 : registro.sormean4) / 4));
                //calculo min diferencia con el promedio
                List<decimal> diferencias = new List<decimal>();
                if (registro.sormean1 == null)
                    registro.sormean1 = 0;

                if (registro.sormean2 == null)
                    registro.sormean2 = 0;

                if (registro.sormean3 == null)
                    registro.sormean3 = 0;

                if (registro.sormean4 == null)
                    registro.sormean4 = 0;

                diferencias.Add(Math.Abs(promedio - Convert.ToDecimal(registro.sormean1.Value)));
                diferencias.Add(Math.Abs(promedio - Convert.ToDecimal(registro.sormean2.Value)));
                diferencias.Add(Math.Abs(promedio - Convert.ToDecimal(registro.sormean3.Value)));
                diferencias.Add(Math.Abs(promedio - Convert.ToDecimal(registro.sormean4.Value)));
                decimal minvalue = diferencias.Min();

                decimal result = diferencias.Min<decimal>();
                finalindex = diferencias.IndexOf(result);

            }



            return finalindex;
        }
    }
}