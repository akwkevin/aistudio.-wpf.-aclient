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
    public class FilterDateConverter : MarkupExtension, IValueConverter
    {
        #region Converter

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime)
            {
                var dt = (DateTime)value;
                if (dt.Date == DateTime.Today)
                {
                    return dt.ToString("HH:mm:ss");
                }
                else
                {
                    return dt.ToString("yyyy-MM-dd");
                }
            }
            else
            {
                return "";
            }          
           
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
