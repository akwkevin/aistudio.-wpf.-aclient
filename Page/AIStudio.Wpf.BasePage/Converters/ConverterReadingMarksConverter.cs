using AIStudio.Wpf.Business;
using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;
using Util.Controls;

namespace AIStudio.Wpf.BasePage.Converters
{
    [ValueConversion(typeof(bool), typeof(Visibility))]
    public class ConverterReadingMarksConverter : MarkupExtension, IValueConverter
    {
        #region IValueConverter 成员

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (DesignerHelper.IsInDesignMode) return DependencyProperty.UnsetValue;

            if (value == null)
                return DependencyProperty.UnsetValue;

            var _operator = ContainerLocator.Current.Resolve<IOperator>();
            if (_operator == null || _operator.Property == null)
            {
                return false;
            }

            IEnumerable<string> checkList = value.ToString().Split('^');

            bool equal = checkList.Contains(_operator.Property.Id.ToString());

            if (equal)
                return !IsOpposite;
            else
                return IsOpposite;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return new ConverterReadingMarksConverter
            {
                FromType = this.FromType ?? typeof(char),
                TargetType = this.TargetType ?? typeof(bool),
                Parameter = this.Parameter,
                IsOpposite = this.IsOpposite
            };
        }

        public bool IsOpposite 
        { 
            get;
            set;
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
