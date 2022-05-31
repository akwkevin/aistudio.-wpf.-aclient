using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Reflection;
using System.Text;

namespace AIStudio.Wpf.Agile_Development.Extensions
{
    public static class PropertyInfoExtensions
    {
        public static PropertyInfo[] GetPropertyInfos(Type type)
        {
            return type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
        }

        public static IDictionary<string, object> ModelToDic(this object o)
        {
            IDictionary<string, object> map = new Dictionary<string, object>();

            Type t = o.GetType();

            PropertyInfo[] pi = GetPropertyInfos(t);

            foreach (PropertyInfo p in pi)
            {
                MethodInfo mi = p.GetGetMethod();

                if (mi != null && mi.IsPublic)
                {
                    map.Add(p.Name, p.GetValue(o, null));
                }
            }

            return map;
        }

        public static ExpandoObject DicToExpandoObject(this IDictionary<string, object> map)
        {
            ExpandoObject expando = new ExpandoObject();
            var dictionary = (IDictionary<string, object>)expando;

            foreach (var keyvalue in map)
            {
                dictionary.Add(keyvalue.Key, keyvalue.Value);
            }

            return expando;
        }


        /// <summary>
        /// 实体属性反射
        /// </summary>
        /// <typeparam name="S">赋值对象</typeparam>
        /// <typeparam name="T">被赋值对象</typeparam>
        /// <param name="s"></param>
        /// <param name="t"></param>
        public static void CopyTo<S, T>(this S s, T t)
        {
            PropertyInfo[] pps = GetPropertyInfos(s.GetType());
            Type target = t.GetType();

            foreach (var pp in pps)
            {
                PropertyInfo targetPP = target.GetProperty(pp.Name);
                object value = pp.GetValue(s, null);

                if (targetPP != null && value != null)
                {
                    targetPP.SetValue(t, value, null);
                }
            }
        }

        public static void CopyTo<T>(this Dictionary<string, object> s, T t)
        {
            PropertyInfo[] pps = GetPropertyInfos(t.GetType());

            foreach (var pp in pps)
            {
                if (s.ContainsKey(pp.Name))
                {
                    object value = s[pp.Name];
                    if (value != null)
                    {
                        if (pp.PropertyType == typeof(int))
                        {
                            pp.SetValue(t, Convert.ToInt32(value), null);
                        }
                        else
                        {
                            pp.SetValue(t, value, null);
                        }
                    }
                }
            }
        }

        public static Type GetAssemblyType(this string typeName)
        {
            Type type = null;
            Assembly[] assemblyArray = AppDomain.CurrentDomain.GetAssemblies();
            int assemblyArrayLength = assemblyArray.Length;
            for (int i = 0; i < assemblyArrayLength; ++i)
            {
                type = assemblyArray[i].GetType(typeName);
                if (type != null)
                {
                    return type;
                }
            }

            for (int i = 0; (i < assemblyArrayLength); ++i)
            {
                Type[] typeArray = assemblyArray[i].GetTypes();
                int typeArrayLength = typeArray.Length;
                for (int j = 0; j < typeArrayLength; ++j)
                {
                    if (typeArray[j].Name.Equals(typeName))
                    {
                        return typeArray[j];
                    }
                }
            }
            return type;

        }
    }
}