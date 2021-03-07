using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace AIStudio.Core.Converters
{
    [ValueConversion(typeof(bool), typeof(Visibility))]
    public class ConverterBoolToOppositeVisibility : MarkupExtension, IValueConverter
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return new ConverterBoolToOppositeVisibility { FromType = this.FromType ?? typeof(bool), TargetType = this.TargetType ?? typeof(Visibility), Parameter = this.Parameter };
        }

        public object Parameter { get; set; }
        public Type TargetType { get; set; }
        public Type FromType { get; set; }

        #region IValueConverter 成员

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //默认返回结果是隐藏
            Visibility result = Visibility.Visible;



            if (value is bool)
            {
                //true = Collapsed
                if ((bool)value)
                {
                    result = Visibility.Collapsed;
                    //如果指定参数parameter，则默认返回Collapsed
                    if (parameter != null && parameter is string && parameter as string == "Hidden")
                        result = Visibility.Hidden;
                }


                //false = default
                else if (!(bool)value)
                    return result;
            }

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is Visibility)
            {
                if ((Visibility)value == Visibility.Hidden || (Visibility)value == Visibility.Collapsed)
                    return true;
                else
                    return false;
            }

            return false;
        }

        #endregion
    }
}
