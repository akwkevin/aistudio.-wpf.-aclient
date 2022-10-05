using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace AIStudio.Core
{
    public static class DataGridHelper
    {
        public static readonly DependencyProperty IsCheckAllProperty = DependencyProperty.RegisterAttached(
           "IsCheckAll", typeof(bool), typeof(DataGridHelper), new FrameworkPropertyMetadata(default(bool), OnIsCheckAllPropertyChangedCallback));

        public static void SetIsCheckAll(DependencyObject element, bool value)
        {
            element.SetValue(IsCheckAllProperty, value);
        }

        public static bool GetIsCheckAll(DependencyObject element)
        {
            return (bool)element.GetValue(IsCheckAllProperty);
        }

        public static readonly DependencyProperty DataGridHostProperty = DependencyProperty.RegisterAttached(
         "DataGridHost", typeof(DataGrid), typeof(DataGridHelper));

        public static void SetDataGridHost(DependencyObject element, DataGrid value)
        {
            element.SetValue(DataGridHostProperty, value);
        }

        public static DataGrid GetDataGridHost(DependencyObject element)
        {
            return (DataGrid)element.GetValue(DataGridHostProperty);
        }

        private static void OnIsCheckAllPropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            var checkbox = dependencyObject as CheckBox;
            if (checkbox != null)
            {
                var datagrid = dependencyObject.TryFindParent<DataGrid>();
                if (datagrid != null)
                {
                    SetDataGridHost(checkbox, datagrid);
                    checkbox.Checked += Checkbox_Checked;
                    checkbox.Unchecked += Checkbox_Checked;
                }
            }
        }

        private static void Checkbox_Checked(object sender, RoutedEventArgs e)
        {
            var checkbox = sender as CheckBox;
            if (checkbox == null || !checkbox.IsChecked.HasValue)
                return;

            var datagrid = GetDataGridHost(checkbox);
            if (datagrid != null)
            {
                foreach (var item in datagrid.Items)
                {
                    if (item.GetType().GetProperty("IsChecked") != null)
                    {
                        item.GetType().GetProperty("IsChecked").SetValue(item, checkbox.IsChecked);
                    }
                }
            }
        }

    }
}
