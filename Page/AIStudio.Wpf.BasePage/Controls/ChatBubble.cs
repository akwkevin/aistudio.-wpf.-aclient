using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Util.Controls;

namespace AIStudio.Wpf.BasePage.Controls
{
    public class ChatBubble : Util.Controls.ChatBubble
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
    }
}
