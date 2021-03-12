//	--------------------------------------------------------------------
//		Obtained from: WPFSmartLibrary
//		For more information see : http://wpfsmartlibrary.codeplex.com/
//		(by DotNetMastermind)
//	--------------------------------------------------------------------

using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace AIStudio.Core.Converters
{
    /// <summary>
    ///     Converts a String into a Visibility enumeration (and back)
    ///     The FalseEquivalent can be declared with the "FalseEquivalent" property
    /// </summary>
    [ValueConversion(typeof (string), typeof (Visibility))]
    [MarkupExtensionReturnType(typeof (StringToVisibilityConverter))]
    public class StringToVisibilityConverter : MarkupExtension, IValueConverter
    {


        #region MarkupExtension "overrides"

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }

        #endregion

        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && targetType == typeof (Visibility))
            {
                if (parameter != null)
                {
                    var paras = parameter.ToString().Split('^');
                    foreach (var para in paras)
                    {
                        if (value.ToString() == para)
                        {
                            return Visibility.Visible;
                        }
                    }
                    return Visibility.Collapsed;
                }
                return string.IsNullOrEmpty((string)value) ? Visibility.Collapsed : Visibility.Visible;
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}