using org.mariuszgromada.math.mxparser;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Windows.Data;

namespace AIStudio.Wpf.AgileDevelopment.Converter
{
    public class ExpressionConverter : IValueConverter
    {
        public object Convert(object value, Type typeTarget, object param, System.Globalization.CultureInfo culture)
        {
            if (param is string str)
            {
                try
                {
                    var conditions = str.Split(new string[] { "——" }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var condition in conditions)
                    {
                        string[] datas = condition.Split(new string[] { "_" }, StringSplitOptions.RemoveEmptyEntries);
                        List<Argument> args = new List<Argument>();
                        if (value is ValueType)
                        {
                            Argument x = new Argument($"p0", value?.ToString());
                            args.Add(x);
                        }
                        else
                        {
                            var paras = datas[0].Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                            for (int i = 0; i < paras.Length; i++)
                            {
                                if (value is ExpandoObject keyValuePairs)
                                {
                                    var dictionary = (IDictionary<string, object>)keyValuePairs;
                                    Argument x = new Argument($"p{i}", dictionary[paras[i]].ToString());
                                    args.Add(x);
                                }
                                else
                                {
                                    Argument x = new Argument($"p{i}", value.GetType().GetProperty(paras[i]).GetValue(value).ToString());
                                    args.Add(x);
                                }
                            }
                        }
                        Expression e = new Expression(datas[1], args.ToArray());
                        var result = e.calculate();
                        if (result > 0)
                        {
                            return datas[2];
                        }
                    }
                }
                catch { }
            }
            return System.Windows.DependencyProperty.UnsetValue;
        }
        public object ConvertBack(object value, Type typeTarget, object param, System.Globalization.CultureInfo culture)
        {
            return "";
        }
    }
}
