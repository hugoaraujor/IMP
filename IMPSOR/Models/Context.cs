using IMPSOR.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace IMPSOR
{
    public partial class DataContext : DbContext
    {

        public DataContext() : base("Default")
        {
        }
        public virtual DbSet<rel_campo_yacimiento_pozo> rel_campo_yacimiento_pozo { get; set; }
        public virtual DbSet<cat_yacimiento> cat_yacimiento { get; set; }
        public virtual DbSet<Pozo> cat_pozo { get; set; }
        public  DbSet<Pozo_Seleccion> Pozo_Seleccion { get; set; }
        public DbSet<Pregunta> Preguntas { get; set; }
        public DbSet<Cuestionario> Cuestionarios { get; set; }
        public DbSet<Funcion> Funciones { get; set; }
        public virtual DbSet<cat_campo> cat_campo { get; set; }
        public  DbSet<cat_pozos_coord> cat_pozos_coords { get; set; }
        public virtual DbSet<RegistroResultado> RegistroResultado { get; set; }
        public virtual DbSet<Configuracion> Configuraciones { get; set; }
        public  DbSet<ResultadoCuestionario> ResultadoCuestionarios{ get; set; }
        public virtual DbSet<RegistroInfo> RegistroInfo { get; set; }
        public virtual DbSet<registroDatos> RegistroDatos { get; set; }
        public virtual DbSet<trazador> trazadores { get; set; }
        public virtual DbSet<dat_NucleosPozo> dat_NucleosPozos { get; set; }
        public DbSet<RespuestasPozo> respuestasPozos { get; set; }
      
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<DataContext>(null);

            

            modelBuilder.Entity<ResultadoCuestionario>().Property(x => x.Confiabilidad).HasPrecision(7, 3);
        }
        public virtual List<PozosViewDetail> GetPozos(int? camposel, int? yac_id)
        {
            var db = this;
            var idParam = new SqlParameter
            {
                ParameterName = "campoid",
                Value = camposel
            };
            var yac = new SqlParameter
            {
                ParameterName = "yacimiento",
                Value = yac_id
            };
            List<PozosViewDetail> resp = new List<PozosViewDetail>();
            //try
            //{
            resp = db.Database.SqlQuery<PozosViewDetail>("SP_Q_Campo_Yacimiento_Pozo @campoid,@yacimiento ", @idParam, @yac).ToList<PozosViewDetail>();
            // }
            // catch
            // {
            // }
            return resp;
        }
        public virtual List<PozosViewDetail> GetPozosprocesados(int? camposel, int? yac_id)
        {
            var db = this;
            var idParam = new SqlParameter
            {
                ParameterName = "campoid",
                Value = camposel
            };
            var yac = new SqlParameter
            {
                ParameterName = "yacimiento",
                Value = yac_id
            };
            return db.Database.SqlQuery<PozosViewDetail>("SP_Q_Campo_Yacimiento_Pozos_procesados @campoid,@yacimiento ", @idParam, @yac).ToList();
        }
        public string GetCurvasStr(int? pozoid)
        {
            var db = this;
            var idParam = new SqlParameter
            {
                ParameterName = "Pozo",
                Value = pozoid
            };
            var tempdb = new DataContext();
            var sresp = (string)tempdb.Database.SqlQuery<string>("SP_ProveeCurvas @Pozo", @idParam).ToList().FirstOrDefault();
            tempdb.Dispose();
            return sresp+"";
        }
        public virtual DbRawSqlQuery<RegistroResultado> GetResults(int? pozoid=null)
        {
            var db = this;
            //var idParam = new SqlParameter
            //{
            //    ParameterName = "Pozo",
            //    Value = pozoid
            //};
           //var resp= db.Database.SqlQuery<RegistroResultado>("[dbo].[SP_GetResultsporPozo]  @Pozo", @idParam);

            var resp = db.Database.SqlQuery<RegistroResultado>("[dbo].[SP_GetResultsporPozo]" );
            return resp;
        }
        //SP_Q_Campo_Yacimiento_Coordenadas
            public virtual DbRawSqlQuery<GraphData2View> GetResultsGraphData(int? camposel, int? yac_id,int? sor)
        {
            var db = this;
            
            var idParam = new SqlParameter
            {
                ParameterName = "campoid",
                Value = camposel
            };
            var yac = new SqlParameter
            {
                ParameterName = "yacid",
                Value = yac_id
            };
            var sors = new SqlParameter
            {
                ParameterName = "selsor",
                Value = sor
            };
            var resp =db.Database.SqlQuery<GraphData2View>("SP_Q_Campo_Yacimiento_Coordenadas @campoid,@yacid,@selsor ", @idParam, @yac,@sors);
            return resp;
        }
    }
}