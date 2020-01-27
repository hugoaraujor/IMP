using IMPSOR.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMPSOR.Servicios
{
    public static class MethodProvider
    {

        public static IMethods Get(int IndexMethod)
        {
            IMethods _methodprovider = null;
            switch (IndexMethod)
            {
                case 1:
                    _methodprovider = new Metodo1();
                    break;
                case 2:
                    _methodprovider = new Metodo2();
                    break;
                case 3:
                    _methodprovider = new Metodo3();
                    break;
                case 4:
                    _methodprovider = new Metodo4();
                    break;
                case 5:
                    _methodprovider = new Metodo5();
                    break;
                case 6:
                    _methodprovider = new Metodo6();
                    break;
            }

            return _methodprovider;
        }


    }
}