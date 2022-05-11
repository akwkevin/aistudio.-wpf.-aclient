using ICSharpCode.AvalonEdit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AIStudio.Core.ControlHelpers
{
    public static class TextEditorHelper
    {
        public static readonly DependencyProperty AttachProperty =
            DependencyProperty.RegisterAttached("Attach", typeof(bool), typeof(TextEditorHelper), new PropertyMetadata(false, Attach));

        public static void SetAttach(DependencyObject dp, bool value)
        {
            dp.SetValue(AttachProperty, value);
        }
        public static bool GetAttach(DependencyObject dp)
        {
            return (bool)dp.GetValue(AttachProperty);
        }

        public static readonly DependencyProperty TextProperty =
          DependencyProperty.RegisterAttached("Text",
          typeof(string), typeof(TextEditorHelper),
          new FrameworkPropertyMetadata(string.Empty, OnTextPropertyChanged));

        public static string GetText(DependencyObject dp)
        {
            return (string)dp.GetValue(TextProperty);
        }
        public static void SetText(DependencyObject dp, string value)
        {
            dp.SetValue(TextProperty, value);
        }

        private static readonly DependencyProperty IsUpdatingProperty =
        DependencyProperty.RegisterAttached("IsUpdating", typeof(bool),
        typeof(TextEditorHelper));

        private static bool GetIsUpdating(DependencyObject dp)
        {
            return (bool)dp.GetValue(IsUpdatingProperty);
        }
        private static void SetIsUpdating(DependencyObject dp, bool value)
        {
            dp.SetValue(IsUpdatingProperty, value);
        }

        private static void Attach(DependencyObject sender,DependencyPropertyChangedEventArgs e)
        {
            TextEditor textEditor = sender as TextEditor;
            if (textEditor == null)
                return;
            if ((bool)e.OldValue)
            {
                textEditor.TextChanged -= TextChanged;
            }
            if ((bool)e.NewValue)
            {
                textEditor.TextChanged += TextChanged;
            }
        }

        private static void OnTextPropertyChanged(DependencyObject sender,
        DependencyPropertyChangedEventArgs e)
        {
            TextEditor textEditor = sender as TextEditor;
            textEditor.TextChanged -= TextChanged;
            if (!(bool)GetIsUpdating(textEditor))
            {
                textEditor.Text = (string)e.NewValue;
            }
            textEditor.TextChanged += TextChanged;
        }

        private static void TextChanged(object sender, EventArgs e)
        {
            TextEditor textEditor = sender as TextEditor;
            SetIsUpdating(textEditor, true);
            SetText(textEditor, textEditor.Text);
            SetIsUpdating(textEditor, false);
        }

    }
}
