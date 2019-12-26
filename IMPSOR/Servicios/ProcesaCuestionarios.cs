
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace IMPSOR
{
    public class ServicioCuestionario
    {
        private RegistroResultado result1 = null;
        private dat_NucleosPozo resultm2 = null;
        private trazador resultm3 = null;
        DataContext db = new DataContext();
  
        private string strprc = "";
        public  string ProcesaCuestionarios(int? idcampo, int? idyacimiento, int? metodo = null)
        {
            decimal GlobalporcMetodo = GetPercentMetodoPreevaluated(metodo);
            decimal GlobalporcHerramientas = GetPercentMetodoPreevaluated("Herramienta");
            decimal GlobalporcAplicacion = GetPercentMetodoPreevaluated("Aplicacion");
            decimal GlobalporcOperacion = GetPercentMetodoPreevaluated("Operacion");
            decimal totalPorcPreguntas = getTotalesporcenTest(metodo, null);
            decimal totalPorcHerramientas = getTotalesporcenTest(metodo, Ambito.Herramienta);
            decimal totalPorcAplicacion = getTotalesporcenTest(metodo, Ambito.Aplicacion);
            decimal totalPorcOperacion = getTotalesporcenTest(metodo, Ambito.Operacion);



            var detalles = db.GetPozos(idcampo, idyacimiento).Where(w => w.sor1 != null);
            var idpozo = 0;
            if (detalles.Count() > 0)
            {
                foreach (PozosViewDetail p in detalles)
                {
                    decimal totalamb0 = 0;
                    decimal totalamb1 = 0;
                    decimal totalamb2 = 0;
                    var reg = db.ResultadoCuestionarios.Where(w => w.IdPozo == p.id_pozo).FirstOrDefault();
                    string curvastr = db.GetCurvasStr(p.id_pozo);
                    idpozo = p.id_pozo;
                    object result = null;

                    if (reg == null)
                    {
                        var newrecord = new ResultadoCuestionario();
                        newrecord.IdPozo = p.id_pozo;

                        var en = result;
                        if (metodo == 1)
                        {
                            newrecord.curvas = curvastr;

                        }
                        AddNewRecord(metodo, newrecord, action.Add);
                        reg = db.ResultadoCuestionarios.Where(w => w.IdPozo == p.id_pozo).FirstOrDefault();

                    }
                    else
                    {
                        var newrecord = db.ResultadoCuestionarios.Find(reg.IdRC);
                        var dn = result;

                        if (metodo == 1)
                        {
                            newrecord.curvas = curvastr;
                        }
                        updateRecord(metodo, newrecord, action.Update);

                    }




                    //Cuestionario
                    var cuestionarios = db.Cuestionarios.Where(w => w.Metodo == metodo).ToList();
                    var compare = new Comparaciones.Solve();
                    var nresd = compare.Evaluate("1!0");
                    decimal n = 100;
                    strprc = "";
                    foreach (Cuestionario c in cuestionarios)
                    {

                        var preguntas = db.Preguntas.Where(w => w.IdCase == c.IdCase).ToList();

                        foreach (Pregunta pregunta in preguntas)
                        {
                            bool valuebool = false;
                            var expr = pregunta.Condicioneval + pregunta.operador + pregunta.valor;
                            Type type = typeof(Funciones);
                            object[] parametersArray = new object[] { idpozo };
                            pregunta.Condicioneval = pregunta.Condicioneval;
                            if (pregunta.Condicioneval != null)
                            {
                                MethodInfo method = type.GetMethod(pregunta.Condicioneval.Replace("#", "Nro").Trim());

                                if (method != null)
                                {
                                    object result2 = new object();
                                    result = null;
                                    var outresult = InvocaMetodo(method, parametersArray);
                                    pregunta.ExpressionSi = compare.Evaluate(pregunta.ExpressionSi.Replace("{#}", outresult.ToString()));
                                    expr = expr.Replace(pregunta.Condicioneval, outresult);
                                    expr = expr.Replace("True", "-1");
                                    expr = expr.Replace("true", "-1");
                                    expr = expr.Replace("False", "0");
                                    expr = expr.Replace("false", "0");
                                    var xx = compare.Evaluate(expr);
                                    if (xx == "-1")
                                    {
                                        n = n * Convert.ToDecimal(pregunta.ExpressionSi);

                                        valuebool = true;

                                    }


                                    strprc += addlog(pregunta.Enunciate, valuebool);


                                    Console.WriteLine(result2);
                                }
                                else if (pregunta.Condicioneval.IndexOf("{?}") > -1)
                                {
                                    var resp = GetAnswer(p.id_pozo, pregunta.IdQuestion);
                                    expr = expr.Replace("{?}", resp);
                                    expr = expr.Replace("Si", "1");
                                    expr = expr.Replace("No", "0");
                                    var eval = compare.Evaluate(expr);
                                    if (eval != "0")
                                    {

                                        var valoracion = Convert.ToDecimal(compare.Evaluate(pregunta.ExpressionSi));

                                        n = n * valoracion;
                                        if (pregunta.ambito == Ambito.Herramienta)
                                            totalamb0 = totalamb0 + (valoracion);

                                        if (pregunta.ambito == Ambito.Operacion)
                                            totalamb1 = totalamb1 + (valoracion);

                                        if (pregunta.ambito == Ambito.Aplicacion)
                                            totalamb2 = totalamb2 + (valoracion);

                                        valuebool = true;
                                    }
                                    if (resp == "Si")
                                        valuebool = true;
                                    else
                                        valuebool = false;
                                    strprc += addlog(pregunta.Enunciate, valuebool);

                                }

                            }

                        }

                    }

                    var totAplicacion = ((totalamb2 * 100 / totalPorcAplicacion) * GlobalporcAplicacion / 100);
                    var totherramienta = ((totalamb0 * 100 / totalPorcHerramientas) * GlobalporcHerramientas / 100);
                    var totOperacion = ((totalamb1 * 100 / totalPorcOperacion) * GlobalporcOperacion / 100);
                    var confiabilidad = Math.Round(((totAplicacion + totherramienta + totOperacion) * GlobalporcMetodo) / 100, 2);


                    var newrecord1 = db.ResultadoCuestionarios.Find(reg.IdRC);
                    newrecord1.GetType().GetProperty("Confiabilidad" + metodo.ToString()).SetValue(newrecord1, confiabilidad);
                    newrecord1.GetType().GetProperty("RespuestasCuestionario" + metodo.ToString()).SetValue(newrecord1, "[" + strprc + "]");
                    var respstr = newrecord1.GetType().GetProperty("RespuestasCuestionario" + metodo.ToString()).GetValue(newrecord1).ToString();

                    newrecord1.GetType().GetProperty("RespuestasCuestionario" + metodo.ToString()).SetValue(newrecord1, respstr.ToString().Replace("'", "\""));
                    newrecord1.GetType().GetProperty("RespuestasCuestionario" + metodo.ToString()).SetValue(newrecord1, respstr.ToString().Replace("},]", "}]"));
                    db.ResultadoCuestionarios.Attach(newrecord1);
                    db.Entry(newrecord1).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                }

            }
            return strprc;
        }
        //Obtiene el porcentaje de la preevalucion del metodo
        private decimal GetPercentMetodoPreevaluated(int? metodo)
        {
            var regConf = db.Configuraciones.FirstOrDefault();
            decimal valor = (decimal)regConf.GetType().GetProperty("Metodo" + metodo.ToString()).GetValue(regConf);
            return valor;
        }
        //Obtiene el porcentaje de la preevalucion del metodo
        private decimal GetPercentMetodoPreevaluated(string categoria)
        {
            var regConf = db.Configuraciones.FirstOrDefault();
            decimal valor = (decimal)regConf.GetType().GetProperty(categoria).GetValue(regConf);
            return valor;
        }
        //Obtiene el porcentaje de cada categoria segun el metodo
        private decimal getTotalesporcenTest(int? metodo, Ambito? pcat)
        {
            decimal ret = 0;
            var preguntas = db.Preguntas.Where(w => w.Metodo == metodo);
            if (pcat != null)
                foreach (Pregunta p in preguntas.Where(w => w.ambito == pcat))
                {
                    var Strtodec = Convert.ToDecimal(p.ExpressionSi);
                    ret = ret + Strtodec;
                }
            else
                foreach (Pregunta p in preguntas)
                {
                    var Strtodec = Convert.ToDecimal(p.ExpressionSi);
                    ret = ret + Strtodec;
                }
            if (ret == 0)
                ret = 1;


            return ret;

        }

        private string GetAnswer(int id_pozo, int idQuestion)
        {
            var retstr = "";
            var ret = db.respuestasPozos.Where(w => w.idPregunta == idQuestion && w.Idpozo == id_pozo).SingleOrDefault();

            if (ret != null)
                retstr = ret.Respuesta;
            return retstr;
        }

        private string InvocaMetodo(MethodInfo method, object[] parametersArray)
        {

            Type type = typeof(Funciones);
            object classInstance = Activator.CreateInstance(type, null);
            object result2 = null;
            var m = method.GetType();

            if (method.ReturnType.Name == "Boolean")
            {
                result2 = (bool)method.Invoke(classInstance, parametersArray);
            }
            if (method.ReturnType.Name == "Int32")
            {
                result2 = (Int32)method.Invoke(classInstance, parametersArray);
            }
            if (method.ReturnType.Name == "String")
            {
                result2 = (String)method.Invoke(classInstance, parametersArray);
            }
            return result2.ToString();
        }
        private void updateRecord(int? metodo, ResultadoCuestionario newrecord, action actionUpd)
        {

            switch (metodo)
            {
                case 1:
                    result1 = db.GetResults().ToList().Where(w => w.PozoId == newrecord.IdPozo).FirstOrDefault();

                    var sorresultindex = SeleccionarSorReg(ref result1);
                    var SorVar = "sor" + metodo.ToString();
                    var sorseleccionada = newrecord.GetType().GetProperty(SorVar);
                    if (result1 != null)
                        newrecord.sor1 = Convert.ToDecimal(result1.GetType().GetProperty("sormean" + (sorresultindex + 1).ToString()).GetValue(result1));
                    else
                        newrecord.sor1 = 0;

                    newrecord.included = true;
                    db.ResultadoCuestionarios.Attach(newrecord);
                    break;
                case 2:
                    resultm2 = (from a in db.dat_NucleosPozos where a.id_pozo == newrecord.IdPozo select a).SingleOrDefault();
                    newrecord.sor2 = 0;
                    newrecord.included = true;

                    if (resultm2 != null)
                        newrecord.sor2 = Convert.ToDecimal(resultm2.So);

                    break;
                case 3:
                    resultm3 = (from a in db.trazadores where a.PozoId == newrecord.IdPozo select a).FirstOrDefault();
                    newrecord.sor3 = 0;
                    newrecord.included = true;

                    if (resultm3 != null)
                        newrecord.sor3 = Convert.ToDecimal(resultm3.sor);

                    break;

            }
            if (actionUpd == action.Update)
            {
                db.ResultadoCuestionarios.Attach(newrecord);
                db.Entry(newrecord).State = System.Data.Entity.EntityState.Modified;
            }

            db.SaveChanges();

        }
        private void AddNewRecord(int? metodo, ResultadoCuestionario newrecord, action actionUpd)
        {

            switch (metodo)
            {
                case 1:
                    result1 = db.GetResults().ToList().Where(w => w.PozoId == newrecord.IdPozo).FirstOrDefault();
                    var sorresultindex = SeleccionarSorReg(ref result1);
                    var SorVar = "sor" + metodo.ToString();
                    var sorseleccionada = newrecord.GetType().GetProperty(SorVar);
                    if (result1 != null)
                        newrecord.sor1 = Convert.ToDecimal(result1.GetType().GetProperty("sormean" + (sorresultindex + 1).ToString()).GetValue(result1));
                    else
                        newrecord.sor1 = 0;
                    db.ResultadoCuestionarios.Add(newrecord);
                    db.SaveChanges();
                    break;
                case 2:
                    resultm2 = (from a in db.dat_NucleosPozos where a.id_pozo == newrecord.IdPozo select a).SingleOrDefault();
                    newrecord.sor2 = Convert.ToDecimal(resultm2.So);
                    break;
                case 3:
                    resultm3 = (from a in db.trazadores where a.PozoId == newrecord.IdPozo select a).FirstOrDefault();
                    newrecord.sor3 = 0;
                    newrecord.included = true;
                    if (resultm3 != null)
                        newrecord.sor3 = Convert.ToDecimal(resultm3.sor);

                    break;
            }
            if (actionUpd == action.Add)
            {
                newrecord.included = true;
                db.ResultadoCuestionarios.Add(newrecord);
            }


            db.SaveChanges();

        }
        private string addlog(string enunciate, bool v)
        {
            return "{'enunciado':'" + enunciate + "','resp':'" + v.ToString() + "'},";
        }

        public int SeleccionarSorReg(ref RegistroResultado registro)
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