
using IMPSOR.Servicios;
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



            var detalles = db.GetPozos(idcampo, idyacimiento).Where(w => w.sormean1 != null);
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
                    var newrecord = new ResultadoCuestionario();
                    var update=action.Update;
                    if (reg == null)
                    {
                        update = action.Add;
                        newrecord.IdPozo = p.id_pozo;
                        var en = result;
                        if (metodo == 1)
                        {
                            newrecord.curvas = curvastr;

                        }
                        updateRecord(metodo, newrecord, update);
                        reg = db.ResultadoCuestionarios.Where(w => w.IdPozo == p.id_pozo).FirstOrDefault();

                    }
                    else
                    {
                        newrecord = db.ResultadoCuestionarios.Find(reg.IdRC);
                        var dn = result;
                        if (metodo == 1)
                        {
                            newrecord.curvas = curvastr;
                        }
                        updateRecord(metodo, newrecord,update);
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

            decimal sor=MethodProvider.Get(metodo.Value).getSor(newrecord.IdPozo);
            newrecord.GetType().GetProperty("sor" + (metodo).ToString()).SetValue(newrecord,sor);
     
            if (actionUpd == action.Add)
            {
                newrecord.included = true;
                db.ResultadoCuestionarios.Add(newrecord);
            }
            if (actionUpd == action.Update)
            {
                db.ResultadoCuestionarios.Attach(newrecord);
                db.Entry(newrecord).State = System.Data.Entity.EntityState.Modified;
            }

            db.SaveChanges();

        }
        
        private string addlog(string enunciate, bool v)
        {
            return "{'enunciado':'" + enunciate + "','resp':'" + v.ToString() + "'},";
        }

   
    }
}