using AIStudio.Core;
using AIStudio.Wpf.AgileDevelopment.Attributes;
using AIStudio.Wpf.AgileDevelopment.ItemSources;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Reflection;
using System.Windows;


namespace AIStudio.Wpf.AgileDevelopment.Commons
{
    public abstract class BaseControlItem : BindableBase
    {
        public int DisplayIndex
        {
            get; set;
        }

        public object Header
        {
            get; set;
        }

        public string PropertyName
        {
            get; set;
        }

        private object _value;
        public object Value
        {
            get
            {
                return _value;
            }
            set
            {
                SetProperty(ref _value, value);
            }
        }

        private Visibility _visibility;
        public Visibility Visibility
        {
            get
            {
                return _visibility;
            }
            set
            {
                SetProperty(ref _visibility, value);
            }
        }

        public ControlType ControlType
        {
            get; set;
        }

        public object ItemSource
        {
            get; set;
        }

        public bool IsRequired
        {
            get; set;
        }

        public string StringFormat
        {
            get; set;
        }

        public bool IsReadOnly
        {
            get; set;
        }

        public static bool GetControlItem(PropertyInfo property, BaseControlItem baseControlItem)
        {
            string itemSource = property.Name;
            var attribute = ColumnHeaderAttribute.GetPropertyAttribute(property);
            if (attribute != null)
            {
                if (attribute.Ignore)
                {
                    return false;
                }

                baseControlItem.Header = attribute.DisplayName ?? property.Name;
                baseControlItem.ControlType = attribute.ControlType;
                baseControlItem.IsRequired = attribute.IsRequired;
                baseControlItem.StringFormat = attribute.StringFormat;
                baseControlItem.DisplayIndex = attribute.DisplayIndex;

                if (!string.IsNullOrEmpty(attribute.ItemSource))
                {
                    itemSource = attribute.ItemSource;
                }
            }
            else if (ItemSourceDictionary.Dictionarys.ContainsKey(property.Name))
            {
                var dic = ItemSourceDictionary.Dictionarys[property.Name];
                baseControlItem.Header = dic.Text;
                baseControlItem.ControlType = dic.ControlType;
                baseControlItem.DisplayIndex = int.MaxValue;

                if (!string.IsNullOrEmpty(dic.Code))
                {
                    itemSource = dic.Code;
                }
            }
            else
            {
                baseControlItem.Header = property.Name;
                baseControlItem.DisplayIndex = int.MaxValue;
            }

            if (ItemSourceDictionary.Items.ContainsKey(itemSource))
            {
                //树形控件使用树形数据集
                if (baseControlItem.ControlType == ControlType.TreeSelect)
                {
                    baseControlItem.ItemSource = ItemSourceDictionary.Items[$"Tree{itemSource}"];
                }
                else
                {
                    baseControlItem.ItemSource = ItemSourceDictionary.Items[itemSource];
                }
            }

            if (property.PropertyType == typeof(int) || property.PropertyType == typeof(int?))
            {
                if (string.IsNullOrEmpty(baseControlItem.StringFormat))
                {
                    baseControlItem.StringFormat = "n0";
                }
                if (baseControlItem.ControlType == ControlType.None)
                {
                    baseControlItem.ControlType = ControlType.IntegerUpDown;
                }
            }
            else if (property.PropertyType == typeof(long) || property.PropertyType == typeof(long?))
            {
                if (string.IsNullOrEmpty(baseControlItem.StringFormat))
                {
                    baseControlItem.StringFormat = "n0";
                }
                if (baseControlItem.ControlType == ControlType.None)
                {
                    baseControlItem.ControlType = ControlType.LongUpDown;
                }
            }
            else if (property.PropertyType == typeof(double) || property.PropertyType == typeof(double?))
            {
                if (string.IsNullOrEmpty(baseControlItem.StringFormat))
                {
                    baseControlItem.StringFormat = "f3";
                }
                if (baseControlItem.ControlType == ControlType.None)
                {
                    baseControlItem.ControlType = ControlType.DoubleUpDown;
                }
            }
            else if (property.PropertyType == typeof(decimal) || property.PropertyType == typeof(decimal?))
            {
                if (string.IsNullOrEmpty(baseControlItem.StringFormat))
                {
                    baseControlItem.StringFormat = "f3";
                }
                if (baseControlItem.ControlType == ControlType.None)
                {
                    baseControlItem.ControlType = ControlType.DecimalUpDown;
                }
            }
            else if (property.PropertyType == typeof(DateTime) || property.PropertyType == typeof(DateTime?))
            {
                if (string.IsNullOrEmpty(baseControlItem.StringFormat))
                {
                    baseControlItem.StringFormat = "yyyy-MM-dd HH:mm:ss";
                }
                if (baseControlItem.ControlType == ControlType.None)
                {
                    baseControlItem.ControlType = ControlType.DateTimeUpDown;
                }
            }
            else
            {
                if (baseControlItem.ControlType == ControlType.None)
                {
                    baseControlItem.ControlType = ControlType.TextBox;
                }
            }

            baseControlItem.PropertyName = property.Name;

            return true;
        }

        public static void ObjectToList<T>(object value, IEnumerable<T> items) where T : BaseControlItem
        {
            foreach (var item in items)
            {
                if (string.IsNullOrEmpty(item.PropertyName))
                    continue;

                if (value == null)
                {
                    item.Value = null;
                    continue;
                }

                if (value is ExpandoObject keyValuePairs)
                {
                    var dictionary = (IDictionary<string, object>)keyValuePairs;
                    item.Value = dictionary[item.PropertyName];
                }
                else
                {
                    var property = value.GetType().GetProperty(item.PropertyName);
                    if (property.CanRead)
                    {
                        item.Value = property.GetValue(value);
                    }
                }
            }
        }

        public static void ListToObject<T>(object value, IEnumerable<T> items) where T : BaseControlItem
        {
            foreach (var item in items)
            {
                if (string.IsNullOrEmpty(item.PropertyName))
                    continue;

                try
                {
                    if (value.GetType().GetProperty(item.PropertyName).CanWrite)
                    {
                        var propertyInfo = value.GetType().GetProperty(item.PropertyName);
                        propertyInfo.SetValue(value, item.Value);
                    }
                }
                catch { }
            }
        }

        public static Dictionary<string, object> ListToDictionary<T>(IEnumerable<T> items) where T : BaseControlItem
        {
            Dictionary<string, object> keyValue = new Dictionary<string, object>();
            foreach (var item in items)
            {
                if (string.IsNullOrEmpty(item.PropertyName))
                    continue;
                if (item.Value == null || item.Value.ToString() == string.Empty)
                    continue;

                keyValue.Add(item.PropertyName, item.Value);
            }

            return keyValue;
        }

        public static object GetDefaultValue(Type type)
        {
            return type.IsValueType ? Activator.CreateInstance(type) : null;
        }
    }
}
