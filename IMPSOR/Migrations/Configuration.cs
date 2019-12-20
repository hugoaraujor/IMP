namespace IMPSOR.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<IMPSOR.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(IMPSOR.DataContext context)
        {
           
             //  context.cat_pozos_coords.AddOrUpdate(
             //        new cat_pozos_coord { IdPozo = 65933,x= 484880.18M, y= 1967071.99M },
             //        new cat_pozos_coord { IdPozo = 65934, x = 495080.91M, y = 1998060.21M },
             //        new cat_pozos_coord { IdPozo = 120835, x = 475080.91M, y = 1898060.21M },
             //        new cat_pozos_coord { IdPozo = 101040, x = 475089.91M, y = 2600000.50M },
             //        new cat_pozos_coord { IdPozo = 101983, x = 425389.91M, y = 2200000.50M },
             //        new cat_pozos_coord { IdPozo = 112867, x = 405389.91M, y = 1100000.50M },
             //        new cat_pozos_coord { IdPozo = 101988, x = 355389.91M, y = 2000000.50M },
             //        new cat_pozos_coord { IdPozo = 103224, x = 495089.91M, y = 1000000.50M },
             //        new cat_pozos_coord { IdPozo = 113737, x = 505389.91M, y = 2000000.50M },
             //        new cat_pozos_coord { IdPozo = 104306, x = 435389.91M, y = 1900000.50M },
             //        new cat_pozos_coord { IdPozo = 105101, x = 422222.91M, y = 1700000.50M },
             //        new cat_pozos_coord { IdPozo = 128020, x = 3822221.91M, y = 1600000.50M },
             //        new cat_pozos_coord { IdPozo = 105101, x = 4322222.91M, y = 2000000.50M }
                     
             // );
             //context.Cuestionarios.AddOrUpdate(
             //   new Cuestionario { IdCase=1, Cuestionario_name="Registros Geofísicos",Metodo=1 },
             //   new Cuestionario { IdCase = 1, Cuestionario_name = "Registros Geofísicos", Metodo = 1 },
             //   new Cuestionario { IdCase = 1, Cuestionario_name = "Nucleos", Metodo = 2 },
             //   new Cuestionario { IdCase = 1, Cuestionario_name = "Trazadores", Metodo = 3 },
             //   new Cuestionario { IdCase = 1, Cuestionario_name = "PVP", Metodo = 4 },
             //   new Cuestionario { IdCase = 1, Cuestionario_name = "Balance de Materias", Metodo = 5 },
             //   new Cuestionario { IdCase = 1, Cuestionario_name = "Registros de Producción", Metodo = 6 }
             //   );


        }
    }
}
