using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

namespace AIStudio.Core
{
    public class HyperlinkHelper
    {
        public static readonly DependencyProperty IsCheckAllProperty = DependencyProperty.RegisterAttached(
           "ViewInBrower", typeof(bool), typeof(HyperlinkHelper), new FrameworkPropertyMetadata(default(bool), OnViewInBrowerPropertyChangedCallback));

        public static void SetViewInBrower(DependencyObject element, bool value)
        {
            element.SetValue(IsCheckAllProperty, value);
        }

        public static bool GetViewInBrower(DependencyObject element)
        {
            return (bool)element.GetValue(IsCheckAllProperty);
        }

        private static void OnViewInBrowerPropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            var checkbox = dependencyObject as Hyperlink;
            if (checkbox != null)
            {
                checkbox.Click -= Checkbox_Click;
                if ((bool)dependencyPropertyChangedEventArgs.NewValue)
                {                   
                    checkbox.Click += Checkbox_Click;
                }
            }
        }

        private static void Checkbox_Click(object sender, RoutedEventArgs e)
        {
            Hyperlink link = sender as Hyperlink;
            // 激活的是当前默认的浏览器
            System.Diagnostics.Process.Start("explorer.exe", link.NavigateUri.AbsoluteUri);
        }
    }
}
