using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace AIStudio.Core.Converters
{
    //选中项索引转换成可见项
    public class IntVisibilityConverter : MarkupExtension, IValueConverter
    {
        /// <summary>
        /// Returns the value for the target property of this markup extension.
        /// </summary>
        /// <param name="serviceProvider">Object that can provide services for the markup extension.</param>
        /// <returns>Reference to the instance of this Int32IndexToNumberConverter.</returns>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {            
           
            if (value is int && parameter is string) //与参数相同则显示
            {
                if (parameter.ToString().Contains("^"))
                {
                    var paras = parameter.ToString().Split('^');                    
                    foreach(var para in paras)
                    {
                        if (value.ToString() == para)
                        {
                            return Visibility.Visible;
                        }
                    }
                    return Visibility.Collapsed;
                }
                else
                {
                    if (value.ToString() == (string)parameter)
                    {
                        return Visibility.Visible;
                    }
                }
            }
            else if (value is int) //无参数，则大于0显示
            {
                if ((int)value > 0)
                {
                    return Visibility.Visible;
                }
            }
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
