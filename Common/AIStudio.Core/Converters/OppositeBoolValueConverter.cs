using System;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace AIStudio.Core.Converters
{
    /// <summary>
    /// 取反操作，即返回 !value
    /// 同时支持Visibility和Boolean类型
    /// </summary>
    [ValueConversion(typeof(bool), typeof(bool))]
    public class OppositeBoolValueConverter : MarkupExtension, IValueConverter
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return new OppositeBoolValueConverter { FromType = this.FromType ?? typeof(bool), TargetType = this.TargetType ?? typeof(bool), Parameter = this.Parameter };
        }

        public object Parameter { get; set; }
        public Type TargetType { get; set; }
        public Type FromType { get; set; }

        #region IValueConverter 成员

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                throw new NullReferenceException();
            if (targetType == typeof(Visibility) && value.GetType() == typeof(Visibility))
            {
                return (Visibility)value == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
            }
            else if (value is bool)
            {
                return !(bool)value;
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (targetType == typeof(bool) && value.GetType() == typeof(bool))
            {
                return !(bool)value;
            }

            return null;
        }

        #endregion
    }
}
