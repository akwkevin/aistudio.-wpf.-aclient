using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace AIStudio.Core.Converters
{
    public class ConverterValueSetToOppositeVisibility : MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null || parameter == null)
                return DependencyProperty.UnsetValue;

            IEnumerable<string> checkList = parameter.ToString().Split('^');

            bool equal = checkList.Contains(value.ToString());

            if (equal)
                return Visibility.Collapsed;
            else
                return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return new ConverterValueSetToOppositeVisibility
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
    }
}
