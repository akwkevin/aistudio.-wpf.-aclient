using System.Collections;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace AIStudio.Core
{
    public class CustomeSelectionValues
    {
        public static IList GetSelectedValues(DependencyObject obj) 
        { 
            return (IList)obj.GetValue(SelectedValuesProperty);
        }

        public static void SetSelectedValues(DependencyObject obj, IList value) 
        { 
            obj.SetValue(SelectedValuesProperty, value);
        }

        //Using a DependencyProperty as the backing store for SelectedItems.  This enables animation, styling, binding, etc...     
        public static readonly DependencyProperty SelectedValuesProperty = DependencyProperty.RegisterAttached("SelectedValues", typeof(IList), typeof(CustomeSelectionValues), new PropertyMetadata(null,OnSelectedValuesChanged));
        static public void OnSelectedValuesChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is ListBox)
            {
                var listBox = d as ListBox;
                if ((listBox != null) && (listBox.SelectionMode == SelectionMode.Multiple))
                {
                    if (!listBox.IsLoaded)
                    {
                        SetSelectedValues(listBox, e.NewValue as IList);
                        listBox.Loaded += ListBox_Loaded;
                    }
                    else
                    {
                        if (e.OldValue != null) { listBox.SelectionChanged -= OnlistBoxSelectionChanged; }
                        IList collection = e.NewValue as IList;
                        listBox.SelectedItems.Clear();
                        if (collection != null)
                        {
                            foreach (var item in collection)
                            {
                                var model = listBox.Items.OfType<object>().FirstOrDefault(p => p.GetPropertyValue(listBox.SelectedValuePath).ToString() == item.ToString());
                                listBox.SelectedItems.Add(model);
                            }
                            listBox.SelectionChanged += OnlistBoxSelectionChanged;
                        }
                    }
                }
            }
            else if (d is MultiSelector)
            {
                var listBox = d as MultiSelector;
                if (listBox != null)
                {
                    if (!listBox.IsLoaded)
                    {
                        SetSelectedValues(listBox, e.NewValue as IList);
                        listBox.Loaded += ListBox_Loaded;
                    }
                    else
                    {
                        if (e.OldValue != null) { listBox.SelectionChanged -= OnlistBoxSelectionChanged; }
                        IList collection = e.NewValue as IList;
                        listBox.SelectedItems.Clear();

                        if (collection != null)
                        {
                            foreach (var item in collection)
                            {
                                var model = listBox.Items.OfType<object>().FirstOrDefault(p => Equals(p.GetPropertyValue(listBox.SelectedValuePath), item));
                                listBox.SelectedItems.Add(model);
                            }
                            listBox.SelectionChanged += OnlistBoxSelectionChanged;
                        }
                    }
                }
            }
        }


        private static void ListBox_Loaded(object sender, RoutedEventArgs e)
        {
            if (sender is ListBox)
            {
                var listBox = sender as ListBox;
                listBox.Loaded -= ListBox_Loaded;
                IList collection = GetSelectedValues(sender as DependencyObject);
                listBox.SelectedItems.Clear();
                if (collection != null)
                {
                    foreach (var item in collection)
                    {
                        var model = listBox.Items.OfType<object>().FirstOrDefault(p => Equals(p.GetPropertyValue(listBox.SelectedValuePath), item));
                        listBox.SelectedItems.Add(model);
                    }
                    listBox.SelectionChanged += OnlistBoxSelectionChanged;
                }
            }
            else if(sender is MultiSelector)
            {
                var listBox = sender as MultiSelector;
                listBox.Loaded -= ListBox_Loaded;
                IList collection = GetSelectedValues(sender as DependencyObject);
                listBox.SelectedItems.Clear();
                if (collection != null)
                {
                    foreach (var item in collection)
                    {
                        var model = listBox.Items.OfType<object>().FirstOrDefault(p => Equals(p.GetPropertyValue(listBox.SelectedValuePath), item));
                        listBox.SelectedItems.Add(model);
                    }
                    listBox.SelectionChanged += OnlistBoxSelectionChanged;
                }
            }
        }

        static void OnlistBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            IList dataSource = GetSelectedValues(sender as DependencyObject);            //添加用户选中的当前项.      
            var listBox = sender as Selector;

            foreach (var item in e.AddedItems)
            { 
                dataSource.Add(item.GetPropertyValue(listBox.SelectedValuePath) as string); 
            }
            //删除用户取消选中的当前项            
            foreach (var item in e.RemovedItems)
            { 
                dataSource.Remove(item.GetPropertyValue(listBox.SelectedValuePath) as string); 
            }
        }

    }
}
