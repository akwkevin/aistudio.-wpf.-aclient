using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AIStudio.Core
{
    /// <summary>
    /// 拓展方法静态类
    /// </summary>
    public static partial class Extention
    {
        public static T ToEnum<T>(this string str)
        {
            return (T)Enum.Parse(typeof(T), str);
        }

        public static string GetDescription(this Enum value)
        {
            if (value == null) return "";
            System.Reflection.FieldInfo fieldInfo = value.GetType().GetField(value.ToString());
            object[] attribArray = fieldInfo.GetCustomAttributes(false);
            if (attribArray.Length == 0)
                return value.ToString();
            else
                return (attribArray[0] as DescriptionAttribute).Description;
        }


    }
}
