using Microsoft.Xaml.Behaviors;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;

namespace AIStudio.Core
{
    public class SelectAllBahavior : Behavior<DataGrid>
    {
        private const string ISCHECKED = "IsChecked";

        //使用默认样式
        //private const string CHECKBOXSTYLE = "CheckBox_Style";

        private CheckBox _allcheck = new CheckBox();

        public bool InitialState
        {
            get { return (bool)GetValue(InitialStateProperty); }
            set { SetValue(InitialStateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for InitialState.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty InitialStateProperty =
            DependencyProperty.Register("InitialState", typeof(bool), typeof(SelectAllBahavior), new PropertyMetadata(false));

        protected override void OnAttached()
        {
            base.OnAttached();

            AssociatedObject.PreviewKeyDown += AssociatedObjectKeyDown;
            AssociatedObject.Focusable = true;

            DataGridTemplateColumn column = new DataGridTemplateColumn();
            DataTemplate cellTemplate = new DataTemplate();
            FrameworkElementFactory cellBox = new FrameworkElementFactory(typeof(CheckBox));
            //使用默认样式
            //cellBox.SetValue(CheckBox.StyleProperty, AssociatedObject.FindResource(CHECKBOXSTYLE) as Style);
            //先去掉快捷键处理
            //cellBox.SetValue(FrameworkElement.ToolTipProperty, "F3全选、F4全清,Shift+F4反选");
            cellBox.SetBinding(ToggleButton.IsCheckedProperty, new Binding(ISCHECKED) { Mode = BindingMode.TwoWay });
            cellBox.SetValue(ToggleButton.MarginProperty, new Thickness(16, 0, 2, 0));
                //cellBox.SetValue(ToggleButton.MarginProperty, new )
            cellBox.AddHandler(ToggleButton.CheckedEvent, new RoutedEventHandler(ItemChecked));
            cellBox.AddHandler(ToggleButton.UncheckedEvent, new RoutedEventHandler(ItemUnchecked));
            cellTemplate.VisualTree = cellBox;
            column.CellTemplate = cellTemplate;

            //_allcheck.Style = AssociatedObject.FindResource(CHECKBOXSTYLE) as Style;
            _allcheck.Margin = new Thickness(8, 0, 2, 0);
            _allcheck.IsChecked = InitialState;
            _allcheck.Checked += HeaderChecked;
            _allcheck.Unchecked += HeaderUnchecked;
            _allcheck.Indeterminate += HeaderIndeterminate;
            column.Header = _allcheck;
            AssociatedObject.Columns.Insert(0, column);
        }

        private bool CheckAllMode = false;
        private bool CheckSingleMode = false;

        private void ItemChecked(object sender, RoutedEventArgs e)
        {
            var item = (sender as CheckBox).DataContext;
            if (item.GetType().GetProperty("IsChecked") != null)
            {
                item.GetType().GetProperty("IsChecked").SetValue(item, true);
            }
            
            if (CheckAllMode) return;
            CheckSingleMode = true;
            int selected = SelectedCount();
            int total = TotalCount();
            if (selected == total)
            {
                _allcheck.IsThreeState = false;
                _allcheck.IsChecked = true;
            }
            else
            {
                _allcheck.IsChecked = null;
            }
            CheckSingleMode = false;
        }

        private void ItemUnchecked(object sender, RoutedEventArgs e)
        {
            var item = (sender as CheckBox).DataContext;
            if (item.GetType().GetProperty("IsChecked") != null)
            {
                item.GetType().GetProperty("IsChecked").SetValue(item, false);
            }

            if (CheckAllMode) return;
            CheckSingleMode = true;
            int selected = SelectedCount();
            int total = TotalCount();
            if (selected == 0)
            {
                _allcheck.IsThreeState = false;
                _allcheck.IsChecked = false;
            }
            else
            {
                _allcheck.IsChecked = null;
            }
            CheckSingleMode = false;
        }

        private void AssociatedObjectKeyDown(object sender, KeyEventArgs e)
        {
            //先去掉快捷键处理
            //switch (e.Key)
            //{
            //    case Key.F3:
            //        _allcheck.IsChecked = true;
            //        break;
            //    case Key.F4:
            //        if (e.KeyboardDevice.Modifiers.HasFlag(ModifierKeys.Shift))
            //        {
            //            foreach (var item in AssociatedObject.ItemsSource)
            //            {                           
            //                if (item.GetType().GetProperty("IsChecked") != null)
            //                {
            //                    var value = (bool)item.GetType().GetProperty("IsChecked").GetValue(item);
            //                    item.GetType().GetProperty("IsChecked").SetValue(item, !value);
            //                }
            //            }
            //        }
            //        else
            //        {
            //            _allcheck.IsChecked = false;
            //        }
            //        break;
            //    default:
            //        break;
            //}
        }

        private void HeaderIndeterminate(object sender, RoutedEventArgs e)
        {

        }

        private void HeaderChecked(object sender, RoutedEventArgs e)
        {
            if (CheckSingleMode) return;
            CheckAllMode = true;
            _allcheck.IsThreeState = false;
            foreach (var item in AssociatedObject.ItemsSource)
            {
                if (item.GetType().GetProperty("IsChecked") != null)
                {
                    item.GetType().GetProperty("IsChecked").SetValue(item, true);
                }
            }
            CheckAllMode = false;
        }

        private void HeaderUnchecked(object sender, RoutedEventArgs e)
        {
            if (CheckSingleMode) return;
            CheckAllMode = true;
            _allcheck.IsThreeState = false;
            foreach (var item in AssociatedObject.ItemsSource)
            {
                if (item.GetType().GetProperty("IsChecked") != null)
                {
                    item.GetType().GetProperty("IsChecked").SetValue(item, false);
                }
            }
            CheckAllMode = false;
        }

        private int SelectedCount()
        {
            int count = 0;
            foreach (var item in AssociatedObject.ItemsSource)
            {
                if (item.GetType().GetProperty("IsChecked") != null)
                {
                    var value = (bool)item.GetType().GetProperty("IsChecked").GetValue(item);
                    if (value)
                    {
                        count++;
                    }
                }              
            }
            return count;
        }

        private int TotalCount()
        {
            int count = 0;
            foreach (var item in AssociatedObject.ItemsSource)
            {
                count++;
            }
            return count;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.Columns.RemoveAt(0);
            AssociatedObject.KeyDown -= AssociatedObjectKeyDown;
        }
    }
}
