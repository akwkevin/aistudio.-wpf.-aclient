using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace AIStudio.Core.Converters
{
    public class InvertBoolConverter : MarkupExtension, IValueConverter
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
            return !(bool)value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !(bool)value;
        }
    }
}
