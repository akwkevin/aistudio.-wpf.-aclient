using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Reflection;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace AIStudio.Core.Converters
{
    /// <summary>
    /// 用于Enum值的显示，如果Enum附加了DisplayAttribute，取其Name属性值进行显示
    /// </summary>
    public class EnumDisplayConverter : MarkupExtension, IValueConverter
    {
        #region IValueConverter 成员

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return DependencyProperty.UnsetValue;
            Type enumType = value.GetType();

            if (enumType.IsEnum && Enum.IsDefined(enumType, value))
            {
                Enum enumObj = value as Enum;
                FieldInfo fieldInfo = enumType.GetField(enumObj.ToString());
                object[] arr = fieldInfo.GetCustomAttributes(typeof(DisplayAttribute), true);
                if (arr.Length == 0)
                {
                    return value.ToString();
                }
                else
                {
                    DisplayAttribute disp = arr[0] as DisplayAttribute;
                    return disp.Name;
                }
            }
            else
            {
                return DependencyProperty.UnsetValue;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string valueStr = value as string;
            if (!string.IsNullOrEmpty(valueStr) && targetType.IsEnum)
            {
                FieldInfo[] fis = targetType.GetFields();

                foreach (FieldInfo fi in fis)
                {
                    DisplayAttribute[] attributes =
                      (DisplayAttribute[])fi.GetCustomAttributes(
                      typeof(DisplayAttribute), false);
                    if (attributes.Length > 0)
                    {
                        if (attributes[0].Name == valueStr)
                        {
                            return fi.GetValue(fi.Name);
                        }
                    }
                    if (fi.Name == valueStr)
                    {
                        return fi.GetValue(fi.Name);
                    }
                }
                return DependencyProperty.UnsetValue;
            }
            else
                return DependencyProperty.UnsetValue;
        }

        #endregion


        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return new EnumDisplayConverter();
        }
    }
}
