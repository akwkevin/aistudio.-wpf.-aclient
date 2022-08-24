using AIStudio.Wpf.Business;
using Prism.Ioc;
using System.Windows;
using AIStudio.Wpf.Controls;
using AIStudio.Wpf.Controls.Helper;
using System.Linq;

namespace AIStudio.Wpf.BasePage.Permission
{
    public class PermissionHelper
    {
        public static readonly DependencyProperty HasPermProperty = DependencyProperty.RegisterAttached(
          "HasPerm", typeof(string), typeof(PermissionHelper), new PropertyMetadata(default(string), OnHasPermPropertyChangedCallback));

        public static void SetHasPerm(DependencyObject element, string value)
        {
            element.SetValue(HasPermProperty, value);
        }

        public static string GetHasPerm(DependencyObject element)
        {
            return (string)element.GetValue(HasPermProperty);
        }
      

        private static void OnHasPermPropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            if (DesignerHelper.IsInDesignMode) return;
            string str = dependencyPropertyChangedEventArgs.NewValue as string;
            if (dependencyObject is FrameworkElement element)
            {
                var _operator = ContainerLocator.Current.Resolve<IOperator>(); 
                if (_operator != null)
                {
                    var menu = _operator.SearchMenus.FirstOrDefault(p => p.WpfName != null && str.StartsWith(p.WpfName));
                    if (menu != null && menu.NeedAction == false)
                    {
                        element.Visibility = Visibility.Visible;
                    }
                    else if (_operator.Permissions == null || !_operator.Permissions.Contains(str))
                    {
                        element.Visibility = Visibility.Collapsed;
                    }
                }
                else
                {
                    element.Visibility = Visibility.Collapsed;
                }
            }      
            else if (dependencyObject is Microsoft.Xaml.Behaviors.TriggerAction trigger)
            {
                var _operator = ContainerLocator.Current.Resolve<IOperator>();
                if (_operator != null)
                {
                    var menu = _operator.SearchMenus.FirstOrDefault(p => p.WpfName != null && str.StartsWith(p.WpfName));
                    if (menu != null && menu.NeedAction == false)
                    {
                        trigger.IsEnabled = true;
                    }
                    else if (_operator.Permissions == null || !_operator.Permissions.Contains(str))
                    {
                        trigger.IsEnabled = false;
                    }
                }
                else
                {
                    trigger.IsEnabled = false;
                }
            }
        }

        public static readonly DependencyProperty IsCreatorProperty = DependencyProperty.RegisterAttached(
          "IsCreator", typeof(string), typeof(PermissionHelper), new PropertyMetadata(default(string), OnIsCreatorChangedCallback));

        public static void SetIsCreator(DependencyObject element, string value)
        {
            element.SetValue(HasPermProperty, value);
        }

        public static string GetIsCreator(DependencyObject element)
        {
            return (string)element.GetValue(HasPermProperty);
        }

        private static void OnIsCreatorChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            if (DesignerHelper.IsInDesignMode) return;
            FrameworkElement element = dependencyObject as FrameworkElement;
            string str = dependencyPropertyChangedEventArgs.NewValue as string;
            if (element != null)
            {
                var _operator = ContainerLocator.Current.Resolve<IOperator>();
                if (_operator == null || _operator.Property == null || string.IsNullOrEmpty(str) || !str.Contains(_operator.Property.Id))
                {
                    element.Visibility = Visibility.Collapsed;
                }
            }
        }
    }
}
