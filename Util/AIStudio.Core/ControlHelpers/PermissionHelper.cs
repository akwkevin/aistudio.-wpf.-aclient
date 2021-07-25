using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace AIStudio.Wpf.Business.Permission
{
    public class PermissionHelper
    {
        public static readonly DependencyProperty HasPermProperty = DependencyProperty.RegisterAttached(
          "HasPerm", typeof(string), typeof(PermissionHelper), new PropertyMetadata(default(string), OnHasPermPropertyChangedCallback));

        public static void SetIsCheckAll(DependencyObject element, string value)
        {
            element.SetValue(HasPermProperty, value);
        }

        public static string GetIsCheckAll(DependencyObject element)
        {
            return (string)element.GetValue(HasPermProperty);
        }

        private static void OnHasPermPropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            FrameworkElement element = dependencyObject as FrameworkElement;
            if (element != null)
            {

            }
          
        }
    }
}
