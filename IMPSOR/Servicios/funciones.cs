using IMPSOR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web;

namespace IMPSOR
{
   
    public class Funciones
    {

        DataContext db = new DataContext();
        List<string> operators = new List<string>();
        public Funciones()
        {
            operators.Add(">");
            operators.Add("<");
            operators.Add(">=");
            operators.Add("<=");
            operators.Add("!");
            operators.Add("=");
            operators.Add("&");
            operators.Add("|");
        }
        public List<Funcion> Get(int? idmetodo)
        {
            return db.Funciones.Where(w => w.Metodo == idmetodo).ToList();
        }
        public List<string> GetOperatorsList()
        {
            return operators;
        }
        public bool UsaCurvasOriginales(int idpozo)
        {
            var curvastr = db.GetCurvasStr(idpozo);
            var n = 0;
            if (curvastr.IndexOf("GR,") > -1) n++;
            if (curvastr.IndexOf("MSFL") > -1) n++;
            if (curvastr.IndexOf("NPHI") > -1) n++;
            if (curvastr.IndexOf("RHOB") > -1) n++;
            var resp = false;
            if (n == 4)
                resp = true;
            return resp;

        }
        public bool UsaCurva(string curva, int idpozo)
        {
            var curvastr = db.GetCurvasStr(idpozo);
            var n = 0;
            var resp = false;
            if (curvastr.IndexOf(curva) > -1)
                resp = true;
            return resp;
        }
        public int NroCurvasEstimadas(int idpozo)
        {
            var curvastr = db.GetCurvasStr(idpozo);
            curvastr = curvastr.Replace("_e_s", "9");
            var n = 0;
            int count = Regex.Matches(curvastr, "_e,").Count;
            return count;
        }
        public int NroCurvasSuavizadas(int idpozo)
        {
            var curvastr = db.GetCurvasStr(idpozo);
            int count = curvastr.Split('s').Length - 1;
            return count;
        }
        public int NroCurvasEstimadasySuavizadas(int idpozo)
        {
            var curvastr = db.GetCurvasStr(idpozo);
            int count = Regex.Matches(curvastr, "_e_s").Count;

            return count;
        }
        public int NroCurvasNoOriginales(int idpozo)
        {
            var curvastr = db.GetCurvasStr(idpozo);
            return (4 - NroCurvasOriginales(idpozo));
        }
        public int NroCurvasOriginales(int idpozo)
        {
            var curvastr = db.GetCurvasStr(idpozo);
            var n = 0;
            if (curvastr.IndexOf("GR") > -1) n++;
            if (curvastr.IndexOf("MSFL") > -1) n++;
            if (curvastr.IndexOf("NPHI") > -1) n++;
            if (curvastr.IndexOf("RHOB") > -1) n++;
            return (n);
        }

      
     
    
        public int SeleccionarSorNucleos(ref RegistroResultado registro)
        {
            return 0;
        }
        public void ProcesaEntry(int id, ref double valor)
        {
            var condicion = db.Preguntas.Where(w => w.IdQuestion == id);
            
        }

        public bool UsaRHOBporGR(int idpozo)
        {
            var curvastr = db.GetCurvasStr(idpozo);
             var resp=false;
            if ((curvastr.IndexOf("RHOB,")>=0))
                resp = true; 
            return (resp);
        }
        public bool UsaGRporRHOB(int idpozo)
        {
            var curvastr = db.GetCurvasStr(idpozo);
            var resp = false;
            if (curvastr.IndexOf("GR") >=(curvastr.Length-2))
                resp = true; 
            return (resp);
        }
        public bool UsaRT(int idpozo)
        {
            var curvastr = db.GetCurvasStr(idpozo);
            var resp = false;
            if (curvastr.IndexOf("RT") > -1)
                resp = true;
            return (resp);
        }
        public bool UsaGR(int idpozo)
        {
            var curvastr = db.GetCurvasStr(idpozo);
            var resp = false;
            if (curvastr.IndexOf("GR")> -1)
                resp = true;
            return (resp);
        }
        public bool Somera(int idpozo)
        {
            var curvastr = db.GetCurvasStr(idpozo);
            var resp = false;
            
            if (curvastr.IndexOf("LLS") > -1 || curvastr.IndexOf("AT20") > -1 || curvastr.IndexOf("AT30") > -1 || curvastr.IndexOf("ILM") > -1 || curvastr.IndexOf("RT") > -1)
                return (resp);
            return resp;
        }
        public bool Profunda(int idpozo)
        {
            var curvastr = db.GetCurvasStr(idpozo);
            var resp = false;
            if (curvastr.IndexOf("LLD") >= (curvastr.Length - 2) )
                resp = true;
            if (curvastr.IndexOf("ILD")>-1|| curvastr.IndexOf("AT60") > -1||curvastr.IndexOf("AT90") > -1)
                resp = true;

            return (resp);
        }
      
    }
}