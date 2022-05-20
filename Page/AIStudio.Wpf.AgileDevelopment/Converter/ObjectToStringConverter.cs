using AIStudio.Core;
using AIStudio.Wpf.AgileDevelopment.ItemSources;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace AIStudio.Wpf.AgileDevelopment.Converter
{
    public class ObjectToStringConverter : IValueConverter
    { 
        public object Convert(object value, Type typeTarget, object param, System.Globalization.CultureInfo culture)
        {
            ObservableCollection<ISelectOption> itemSource = null;
            if (param != null && ItemSourceDictionary.Items.ContainsKey(param?.ToString()))
            {
                itemSource = ItemSourceDictionary.Items[param?.ToString()];
            }

            if (value is IEnumerable<object> list)
            {
                if (itemSource != null)
                {
                    List<string> displays = new List<string>();
                    foreach (var item in list)
                    {
                        displays.Add(itemSource.FirstOrDefault(p => item?.ToString() == p.Value)?.Text);
                    }
                    return string.Join(",", displays.Select(p => p?.ToString()));
                }
                return string.Join(",", list.Select(p => p?.ToString()));
            }
            else
            {
                if (param?.ToString() == "Department")
                {

                }
                if (itemSource != null)
                {
                    return itemSource.FirstOrDefault(p => value?.ToString() == p.Value)?.Text;
                }
            }

            return value?.ToString();
        }
        public object ConvertBack(object value, Type typeTarget, object param, System.Globalization.CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}
