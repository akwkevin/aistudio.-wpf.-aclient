using AIStudio.Core;
using AIStudio.Wpf.Controls.Bindings;
using AIStudio.Wpf.Debug_Tool.Attributes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.Reflection;
using System.Windows;

namespace AIStudio.Wpf.Debug_Tool.Commons
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

        public ObservableCollection<SelectOption> ItemSource
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

        public static bool GetControlItem(PropertyInfo property, BaseControlItem queryConditionItem)
        {
            var attribute = ColumnHeaderAttribute.GetPropertyAttribute(property);
            if (attribute != null)
            {
                if (attribute.Ignore)
                {
                    return false;
                }

                queryConditionItem.Header = attribute.DisplayName ?? property.Name;
                queryConditionItem.ControlType = attribute.ControlType;
                queryConditionItem.IsRequired = attribute.IsRequired;
                queryConditionItem.StringFormat = attribute.StringFormat;
                queryConditionItem.DisplayIndex = attribute.DisplayIndex;
            }
            else
            {
                queryConditionItem.Header = property.Name;
                queryConditionItem.ControlType = ControlType.TextBox;
                queryConditionItem.DisplayIndex = int.MaxValue;
            }

            if (property.PropertyType == typeof(int))
            {
                if (string.IsNullOrEmpty(queryConditionItem.StringFormat))
                {
                    queryConditionItem.StringFormat = "n0";
                }
                queryConditionItem.ControlType = ControlType.IntegerUpDown;
            }
            else if (property.PropertyType == typeof(long))
            {
                if (string.IsNullOrEmpty(queryConditionItem.StringFormat))
                {
                    queryConditionItem.StringFormat = "n0";
                }
                queryConditionItem.ControlType = ControlType.LongUpDown;
            }
            else if (property.PropertyType == typeof(double))
            {
                if (string.IsNullOrEmpty(queryConditionItem.StringFormat))
                {
                    queryConditionItem.StringFormat = "f3";
                }
                queryConditionItem.ControlType = ControlType.DoubleUpDown;
            }
            else if (property.PropertyType == typeof(decimal))
            {
                if (string.IsNullOrEmpty(queryConditionItem.StringFormat))
                {
                    queryConditionItem.StringFormat = "f3";
                }
                queryConditionItem.ControlType = ControlType.DecimalUpDown;
            }
            else if (property.PropertyType == typeof(DateTime))
            {
                if (string.IsNullOrEmpty(queryConditionItem.StringFormat))
                {
                    queryConditionItem.StringFormat = "yyyy-MM-dd HH:mm:ss";
                }
                queryConditionItem.ControlType = ControlType.DateTimeUpDown;
            }

            queryConditionItem.PropertyName = property.Name;

            return true;
        }

        public static void ObjectToList<T>(object value, IEnumerable<T> items) where T : BaseControlItem
        {
            foreach (var item in items)
            {
                if (string.IsNullOrEmpty(item.PropertyName))
                    continue;

                if (value is ExpandoObject keyValuePairs)
                {
                    var dictionary = (IDictionary<string, object>)keyValuePairs;
                    item.Value = dictionary[item.PropertyName];
                }
                else
                {
                    if (value.GetType().GetProperty(item.PropertyName).CanRead)
                    {
                        item.Value = value.GetType().GetProperty(item.PropertyName).GetValue(value);
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
