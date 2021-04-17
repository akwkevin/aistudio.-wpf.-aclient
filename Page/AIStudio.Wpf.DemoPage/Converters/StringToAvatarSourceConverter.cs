using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media.Imaging;

namespace AIStudio.Wpf.DemoPage.Converters
{
    public class StringToAvatarSourceConverter :  IValueConverter
    {
        #region Converter

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string path = value as string;
            if (string.IsNullOrEmpty(path))
            {
                path = "pack://application:,,,/AIStudio.Wpf.DemoPage;component/Resources/Img/Avatar/avatar1.png";
            }
            if (!UrlDiscern(path))
            {
                if (!path.StartsWith("pack://application:,,,"))
                {
                    path = "pack://application:,,,/AIStudio.Wpf.DemoPage;component/Resources/Img/Avatar/" + path;
                }
            }
          
            return new BitmapImage(new Uri(path, UriKind.Absolute));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
        #endregion

        public bool UrlDiscern(string path)
        {
            if (Regex.IsMatch(path, @"(http|ftp|https)://"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
