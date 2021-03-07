using System;
using System.Linq;
using System.Windows;
using System.Windows.Media.Imaging;
using Util.Controls;

namespace AIStudio.Wpf.BasePage.Controls
{
    public class ChatBubble : SelectableItem
    {
        public ChatBubble()
        {
            //读取资源字典文件
            ResourceDictionary rd = new ResourceDictionary();
            rd.Source = new Uri("/AIStudio.Wpf.BasePage;component/Controls/ChatBubble.xaml", UriKind.Relative);
            if (!this.Resources.MergedDictionaries.Any(p => p.Source == rd.Source))
            {
                this.Resources.MergedDictionaries.Add(rd);
            }
            //获取样式
            this.Style = this.FindResource("ChatBubbleBaseStyle") as Style;
        }

        public static readonly DependencyProperty RoleProperty = DependencyProperty.Register(
            "Role", typeof(string), typeof(ChatBubble), new PropertyMetadata(default(string)));

        public string Role
        {
            get => (string)GetValue(RoleProperty);
            set => SetValue(RoleProperty, value);
        }

        public static readonly DependencyProperty TypeProperty = DependencyProperty.Register(
            "Type", typeof(int), typeof(ChatBubble), new PropertyMetadata(1));

        public int Type
        {
            get => (int)GetValue(TypeProperty);
            set => SetValue(TypeProperty, value);
        }

        public static readonly DependencyProperty AvatarProperty = DependencyProperty.Register(
           "Avatar", typeof(BitmapImage), typeof(ChatBubble), new PropertyMetadata(null));

        public BitmapImage Avatar
        {
            get => (BitmapImage)GetValue(AvatarProperty);
            set => SetValue(AvatarProperty, value);
        }

        public static readonly DependencyProperty IsReadProperty = DependencyProperty.Register(
            "IsRead", typeof(bool), typeof(ChatBubble), new PropertyMetadata(false));

        public bool IsRead
        {
            get => (bool)GetValue(IsReadProperty);
            set => SetValue(IsReadProperty, value);
        }

        public static readonly DependencyProperty ShowTimeProperty = DependencyProperty.Register(
          "ShowTime", typeof(bool), typeof(ChatBubble), new PropertyMetadata(true));

        public bool ShowTime
        {
            get => (bool)GetValue(ShowTimeProperty);
            set => SetValue(ShowTimeProperty, value);
        }

        public static readonly DependencyProperty CreateTimeProperty = DependencyProperty.Register(
         "CreateTime", typeof(DateTime), typeof(ChatBubble), new PropertyMetadata(DateTime.Now));

        public DateTime CreateTime
        {
            get => (DateTime)GetValue(CreateTimeProperty);
            set => SetValue(CreateTimeProperty, value);
        }

        public static void SetMaxWidth(DependencyObject element, double value)
            => element.SetValue(MaxWidthProperty, value);

        public static double GetMaxWidth(DependencyObject element)
            => (double)element.GetValue(MaxWidthProperty);

        public Action<object> ReadAction { get; set; }

        protected override void OnSelected(RoutedEventArgs e)
        {
            base.OnSelected(e);

            IsRead = true;
            ReadAction?.Invoke(Content);
        }
    }
}
