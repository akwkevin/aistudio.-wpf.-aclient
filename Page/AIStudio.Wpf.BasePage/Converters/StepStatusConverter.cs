using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace AIStudio.Wpf.BasePage.Converters
{
    public class StepStatusConverter : MarkupExtension, IValueConverter
    {
        #region Converter

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int)
            {
                switch((int)value)
                {
                    case 100:
                        return "Complete";
                    case 1:
                    case 7:
                    case 10:
                    case 99:
                        return "UnderWay";
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                    case 8:
                        return "Error";
                    default:
                        return "Waiting";
                }
            }
            return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
        #endregion

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}
