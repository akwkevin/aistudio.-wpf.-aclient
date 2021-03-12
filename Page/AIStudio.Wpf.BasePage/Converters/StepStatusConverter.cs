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
using Util.Controls.Data;

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
                        return StepStatus.Complete;
                    case 1:
                    case 7:
                    case 10:
                    case 99:
                        return StepStatus.UnderWay;
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                    case 8:
                        return StepStatus.Error;
                    default: 
                        return StepStatus.Waiting;
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
