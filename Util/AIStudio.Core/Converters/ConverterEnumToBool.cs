using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace AIStudio.Core.Converters
{
    /// <summary>
    /// 比较枚举类型的值,主要用于枚举值和RadioButton之间的转换。
    /// </summary>
    public class ConverterEnumToBool : MarkupExtension, IValueConverter
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return new ConverterEnumToBool { FromType = this.FromType ?? typeof(Enum), TargetType = this.TargetType ?? typeof(bool), Parameter = this.Parameter };
        }

        public object Parameter { get; set; }
        public Type TargetType { get; set; }
        public Type FromType { get; set; }

        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string ParameterString = parameter as string;
            if (ParameterString == null)
                return DependencyProperty.UnsetValue;

            if (Enum.IsDefined(value.GetType(), value) == false)
                return DependencyProperty.UnsetValue;

            object paramvalue = Enum.Parse(value.GetType(), ParameterString) ?? new object();

            return paramvalue.Equals(value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool isChecked = (bool)value;
            if (!isChecked)
            {
                //这里需要注意ConvertBack方法中判断value的值为false的时候，会直接返回null
                //这样写是为了RadioButton的状态变为未选中的时候，阻止数据传回Employee的实例。
                //如果不这样做，值更新会在两个RadioButton之间形成一个环路，导致RadioButton不能正常工作。
                return null;
            }

            string ParameterString = parameter as string;
            if (ParameterString == null)
                return DependencyProperty.UnsetValue;

            return Enum.Parse(targetType, ParameterString);
        }

        #endregion
    }
}
