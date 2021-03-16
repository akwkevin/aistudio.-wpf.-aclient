using AIStudio.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media.Imaging;

namespace AIStudio.Wpf.BasePage.Converters
{
    public class CountTo99PlusConverter : MarkupExtension, IValueConverter
    {
        #region Converter

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int)
            {
                if ((int)value > 99)
                {
                    return "99+";
                }
                else if ((int)value == 0)
                {
                    return null;
                }
            }
            return value;
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
