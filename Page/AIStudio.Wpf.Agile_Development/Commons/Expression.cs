using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Reflection;

namespace AIStudio.Wpf.Agile_Development.Commons
{
    /// <summary>
    /// 处理表达试运算---动态生成数学表达式并计算其值
    /// 表达式使用 C# 语法，可带一个的自变量(x)。
    /// 表达式的自变量和值均为(double)类型。
    /// </summary>
    /// <example>
    /// <code>
    /// Expression expression = new Expression("Math.Sin(x)"); 
    /// Console.WriteLine(expression.Compute(Math.PI / 2)); 
    /// expression = new Expression("double u = Math.PI - x;" + 
    /// "double pi2 = Math.PI * Math.PI;" + 
    /// "return 3 * x * x + Math.Log(u * u) / pi2 / pi2 + 1;"); 
    /// Console.WriteLine(expression.Compute(0)); 
    /// 
    /// Expression expression = new Expression("return 10*(5+5)/10;");
    /// Response.Write(expression.Compute(0));
    /// Response.End();
    public class Expression
    {
        object instance;
        MethodInfo method;
        /// <summary>
        /// 表达试运算
        /// </summary>
        /// <param name="expression">表达试</param>
        public Expression(string expression)
        {
            if (expression.IndexOf("return") < 0) expression = "return " + expression + ";";
            string className = "Expression";
            string methodName = "Compute";
            CompilerParameters p = new CompilerParameters();
            p.GenerateInMemory = true;
            CompilerResults cr = new CSharpCodeProvider().CompileAssemblyFromSource(p, string.
              Format("using System;sealed class {0}{{public double {1}(double x){{{2}}}}}",
              className, methodName, expression));
            if (cr.Errors.Count > 0)
            {
                string msg = "Expression(\"" + expression + "\"): \n";
                foreach (CompilerError err in cr.Errors) msg += err.ToString() + "\n";
                throw new Exception(msg);
            }
            instance = cr.CompiledAssembly.CreateInstance(className);
            method = instance.GetType().GetMethod(methodName);
        }
        /// <summary>
        /// 处理数据
        /// </summary>
        /// <param name="x"></param>
        /// <returns>返回计算值</returns>
        public double Compute(double x)
        {
            return (double)method.Invoke(instance, new object[] { x });
        }
    }
}
