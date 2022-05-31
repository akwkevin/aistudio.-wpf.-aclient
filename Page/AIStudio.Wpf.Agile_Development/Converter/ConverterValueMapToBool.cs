using System;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace AIStudio.Wpf.Agile_Development.Converter
{
    public class ConverterValueMapToBool : MarkupExtension, IValueConverter
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return new ConverterValueMapToBool
            {
                FromType = this.FromType ?? typeof(char),
                TargetType = this.TargetType ?? typeof(bool),
                Parameter = this.Parameter
            };
        }

        public object Parameter
        {
            get;
            set;
        }
        public Type TargetType
        {
            get;
            set;
        }
        public Type FromType
        {
            get;
            set;
        }
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null || parameter == null)
                return false;

            if (object.Equals(value, parameter))
                return true;

            return string.Equals(value.ToString(), parameter.ToString());
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var result = DependencyProperty.UnsetValue;
            if (value == null) return result;
            if (value is bool)
            {
                if ((bool)value)
                    result = parameter;
                else
                    result = this.Parameter;
                if (result == null || string.IsNullOrWhiteSpace(result.ToString()))
                    return DependencyProperty.UnsetValue;
                //处理枚举类型
                if (targetType.IsEnum)
                    result = Enum.Parse(targetType, result as string);
                else if (targetType.IsValueType)
                {
                    if (targetType == typeof(Int32))
                        result = System.Convert.ToInt32(result);
                    else if (targetType == typeof(Int16))
                        result = System.Convert.ToInt16(result);
                    else if (targetType == typeof(char))
                        result = result.ToString().First();
                }
            }
            return result;
        }

        #endregion
    }
}
