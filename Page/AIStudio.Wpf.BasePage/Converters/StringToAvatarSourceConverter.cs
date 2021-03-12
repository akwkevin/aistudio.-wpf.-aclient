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
    public class StringToAvatarSourceConverter : MarkupExtension, IValueConverter
    {
        #region Converter

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string path = value as string;
            if (string.IsNullOrEmpty(path))
            {
                path = "pack://application:,,,/AIStudio.Resource;component/Images/Luffy.jpg";
            }
            if (!ImageHelper.UrlDiscern(path))
            {
                if (!path.StartsWith("pack://application:,,,"))
                {
                    path = "pack://application:,,,/AIStudio.Resource;component" + path;
                }
            }
          
            return new BitmapImage(new Uri(path, UriKind.Absolute));
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
