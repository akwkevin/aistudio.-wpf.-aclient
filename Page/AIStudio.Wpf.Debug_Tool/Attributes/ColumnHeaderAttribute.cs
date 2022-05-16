using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Data;
using AIStudio.Wpf.Debug_Tool.Commons;

namespace AIStudio.Wpf.Debug_Tool.Attributes
{
    public class ColumnHeaderAttribute : DisplayNameAttribute
    {
        public ColumnHeaderAttribute()
        {

        }

        public ColumnHeaderAttribute(string displayName) : base(displayName) { }


        public Visibility Visibility
        {
            get; set;
        } = Visibility.Visible;

        public int DisplayIndex
        {
            get; set;
        } = int.MaxValue;

        public string StringFormat
        {
            get; set;
        }

        public bool Ignore
        {
            get; set;
        }

        public Type Converter
        {
            get; set;
        }

        public object ConverterParameter
        {
            get; set;
        }

        public string ForegroundExpression
        {
            get; set;
        }

        public string BackgroundExpression
        {
            get; set;
        }

        public bool IsPin
        {
            get; set;
        }

        public bool IsRequired
        {
            get; set;
        }

        public bool IsReadOnly
        {
            get; set;
        }

        public ControlType ControlType
        {
            get; set;
        } = ControlType.TextBox;

        public HorizontalAlignment HorizontalAlignment
        {
            get; set;
        }

        public string SortMemberPath
        {
            get; set;
        }

        public bool CanUserSort
        {
            get; set;
        } = true;

        public static DataGridColumnCustom GetDataGridColumnCustom(PropertyInfo property)
        {
            DataGridColumnCustom dataGridColumnCustom = new DataGridColumnCustom();
            dataGridColumnCustom.Binding = property.Name;

            var attribute = ColumnHeaderAttribute.GetPropertyAttribute(property);
            if (attribute != null)
            {
                if (attribute.Ignore)
                {
                    return null;
                }

                dataGridColumnCustom.Header = attribute.DisplayName ?? property.Name;
                dataGridColumnCustom.StringFormat = attribute.StringFormat;
                dataGridColumnCustom.Visibility = attribute.Visibility;
                if (attribute.Converter != null)
                {
                    dataGridColumnCustom.Converter = attribute.Converter.FullName;
                    dataGridColumnCustom.ConverterParameter = attribute.ConverterParameter;
                }
                dataGridColumnCustom.ForegroundExpression = attribute.ForegroundExpression;
                dataGridColumnCustom.BackgroundExpression = attribute.BackgroundExpression;
                dataGridColumnCustom.HorizontalAlignment = attribute.HorizontalAlignment;
                dataGridColumnCustom.DisplayIndex = attribute.DisplayIndex;
                dataGridColumnCustom.SortMemberPath = attribute.SortMemberPath ?? property.Name;
                dataGridColumnCustom.CanUserSort = attribute.CanUserSort;
            }
            else
            {
                dataGridColumnCustom.Header = property.Name;
                dataGridColumnCustom.DisplayIndex = int.MaxValue;
                dataGridColumnCustom.SortMemberPath = property.Name;
                dataGridColumnCustom.CanUserSort = true;
            }

            if (property.PropertyType == typeof(int) || property.PropertyType == typeof(long))
            {
                if (string.IsNullOrEmpty(dataGridColumnCustom.StringFormat))
                {
                    dataGridColumnCustom.StringFormat = "n0";
                }
            }
            else if (property.PropertyType == typeof(double) || property.PropertyType == typeof(decimal))
            {
                if (string.IsNullOrEmpty(dataGridColumnCustom.StringFormat))
                {
                    dataGridColumnCustom.StringFormat = "f3";
                }
            }
            else if (property.PropertyType == typeof(DateTime))
            {
                if (string.IsNullOrEmpty(dataGridColumnCustom.StringFormat))
                {
                    dataGridColumnCustom.StringFormat = "yyyy-MM-dd HH:mm:ss";
                }
            }

            return dataGridColumnCustom;
        }

        public static ColumnHeaderAttribute GetPropertyAttribute(object descriptor)
        {
            PropertyDescriptor pd = descriptor as PropertyDescriptor;
            if (pd != null)
            {
                ColumnHeaderAttribute attr = pd.Attributes[typeof(ColumnHeaderAttribute)] as ColumnHeaderAttribute;
                if ((attr != null) && (attr != ColumnHeaderAttribute.Default))
                {
                    return attr;
                }
            }
            else
            {
                PropertyInfo pi = descriptor as PropertyInfo;
                if (pi != null)
                {
                    Object[] attrs = pi.GetCustomAttributes(typeof(ColumnHeaderAttribute), true);
                    foreach (var att in attrs)
                    {
                        ColumnHeaderAttribute attribute = att as ColumnHeaderAttribute;
                        if ((attribute != null) && (attribute != ColumnHeaderAttribute.Default))
                        {
                            return attribute;
                        }
                    }
                }
            }
            return null;
        }
    }
}
