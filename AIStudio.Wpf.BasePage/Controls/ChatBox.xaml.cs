using AIStudio.Wpf.Business.DTOModels;
using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Util.Controls;
using Util.Controls.Data;
using Util.Controls.Tools;

namespace AIStudio.Wpf.BasePage.Controls
{
    /// <summary>
    /// ChatBox.xaml 的交互逻辑
    /// </summary>
    public partial class ChatBox : UserControl
    {
        private static readonly string AudioCachePath = $"{AppDomain.CurrentDomain.BaseDirectory}Cache";

        private readonly string _id = Guid.NewGuid().ToString();

        private readonly Stopwatch _stopwatch = new Lazy<Stopwatch>(() => new Stopwatch()).Value;

        public ChatBox()
        {
            InitializeComponent();

            ChatInfos = new ObservableCollection<D_UserMessageDTO>();
            ListBoxChat.ItemContainerGenerator.ItemsChanged += ItemContainerGenerator_ItemsChanged;

            ToolConfigs = new ObservableCollection<ToolConfig>();
            ToolConfigs.Add(new ToolConfig() { Icon = "emjio", Title = "表情" });
            ToolConfigs.Add(new ToolConfig() { Icon = "picture", Title = "图片" });
            ToolConfigs.Add(new ToolConfig() { Icon = "video-camera", Title = "视频" });
            ToolConfigs.Add(new ToolConfig() { Icon = "audio", Title = "音频" });
            ToolConfigs.Add(new ToolConfig() { Icon = "file", Title = "文件" });

            EmjioItems = new ObservableCollection<EmjioItem>();
            foreach(var dataIndex in EmojiDataFactory.DataIndex.Value)
            {
                EmjioItems.Add(new EmjioItem() { Emjio = dataIndex.Key, Uri = "pack://application:,,,/Util.Controls;component" + dataIndex.Value });
            }
        }

        private System.Windows.Controls.ScrollViewer _scrollViewer;

        private void ItemContainerGenerator_ItemsChanged(object sender, System.Windows.Controls.Primitives.ItemsChangedEventArgs e)
        {
            if (_scrollViewer == null)
            {
                _scrollViewer = VisualHelper.GetChild<System.Windows.Controls.ScrollViewer>(ListBoxChat);
            }

            _scrollViewer?.ScrollToBottom();
        }

        public static readonly DependencyProperty ChatStringProperty = DependencyProperty.Register(
           "ChatString", typeof(string), typeof(ChatBox), new PropertyMetadata(default(string)));

        public string ChatString
        {
            get { return (string)this.GetValue(ChatStringProperty); }
            set { this.SetValue(ChatStringProperty, value); }
        }

        public static readonly DependencyProperty ChatInfosProperty = DependencyProperty.Register(
          "ChatInfos", typeof(ObservableCollection<D_UserMessageDTO>), typeof(ChatBox), new PropertyMetadata(null));

        public ObservableCollection<D_UserMessageDTO> ChatInfos
        {
            get { return (ObservableCollection<D_UserMessageDTO>)this.GetValue(ChatInfosProperty); }
            set { this.SetValue(ChatInfosProperty, value); }
        }

        public static readonly DependencyProperty IsHistoryProperty = DependencyProperty.Register(
          "IsHistory", typeof(bool), typeof(ChatBox), new PropertyMetadata(default(bool), IsHistoryChangedCallback));

        public bool IsHistory
        {
            get { return (bool)this.GetValue(IsHistoryProperty); }
            set { this.SetValue(IsHistoryProperty, value); }
        }

        private static void IsHistoryChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            var chatBox = (ChatBox)dependencyObject;
            if (chatBox != null && chatBox.IsHistory)
            {
                chatBox.RaiseChatSendChanged(chatBox.StartValue, chatBox.EndValue);
            }
        }

        public static readonly DependencyProperty SelectModeProperty = DependencyProperty.Register(
          "SelectMode", typeof(int), typeof(ChatBox), new PropertyMetadata(1, SelectModeChangedCallback));

        public int SelectMode
        {
            get { return (int)this.GetValue(SelectModeProperty); }
            set { this.SetValue(SelectModeProperty, value); }
        }

        private static void SelectModeChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            var chatBox = (ChatBox)dependencyObject;
            if (chatBox != null)
            {
                chatBox.SelectModeChangedCallback(e.OldValue, e.NewValue);
            }
        }

        private void SelectModeChangedCallback(object oldvalue, object newvalue)
        {
            switch(newvalue)
            {
                case 1: StartValue = DateTime.Today; EndValue = DateTime.Now; break;
                case 2: StartValue = DateTime.Now.AddDays(-7); EndValue = DateTime.Now; break;
                case 3: StartValue = DateTime.Now.AddDays(-30); EndValue = DateTime.Now; break;
                case 4: StartValue = DateTime.Now.AddDays(-90); EndValue = DateTime.Now; break;
            }
        }

        public static readonly DependencyProperty StartValueProperty = DependencyProperty.Register(
         "StartValue", typeof(DateTime), typeof(ChatBox), new PropertyMetadata(DateTime.Today));

        public DateTime StartValue
        {
            get { return (DateTime)this.GetValue(StartValueProperty); }
            set { this.SetValue(StartValueProperty, value); }
        }

        public static readonly DependencyProperty EndValueProperty = DependencyProperty.Register(
         "EndValue", typeof(DateTime), typeof(ChatBox), new PropertyMetadata(DateTime.Now));

        public DateTime EndValue
        {
            get { return (DateTime)this.GetValue(EndValueProperty); }
            set { this.SetValue(EndValueProperty, value); }
        }

        public RelayCommand<KeyEventArgs> SendStringCmd => new Lazy<RelayCommand<KeyEventArgs>>(() =>
           new RelayCommand<KeyEventArgs>(SendString)).Value;

        private void SendString(KeyEventArgs e)
        {
            if (e == null || (e.Key == Key.Enter  && e.KeyboardDevice.Modifiers == ModifierKeys.None))
            {
                if (string.IsNullOrEmpty(ChatString.Trim())) return;
                var info = new D_UserMessageDTO
                {
                    Text = ChatString.Trim(),
                    Type = (int)ChatMessageType.String,
                };

                RaiseChatSendChanged(info);
                ChatString = string.Empty;
            }
        }

        public RelayCommand<KeyEventArgs> HistorySearchCmd => new Lazy<RelayCommand<KeyEventArgs>>(() =>
          new RelayCommand<KeyEventArgs>(HistorySearch)).Value;

        private void HistorySearch(KeyEventArgs e)
        {
            RaiseChatSendChanged(StartValue, EndValue);         
        }

        public RelayCommand<RoutedEventArgs> ReadMessageCmd => new Lazy<RelayCommand<RoutedEventArgs>>(() =>
           new RelayCommand<RoutedEventArgs>(ReadMessage)).Value;

        private void ReadMessage(RoutedEventArgs e)
        {
            if (e.OriginalSource is FrameworkElement element && element.Tag is D_UserMessageDTO info)
            {
                if (info.Type == (int)ChatMessageType.Image)
                {
                    new Util.Controls.Windows.ImageBrowser(new Uri(info.Text))
                    {
                        Owner = WindowHelper.GetActiveWindow()
                    }.Show();
                }
                else if (info.Type == (int)ChatMessageType.Audio)
                {
                    MediaElementPlayerWindow.Show(info.Text);
                }
                else if (info.Type == (int)ChatMessageType.Video)
                {
                    MediaElementPlayerWindow.Show(info.Text, ShowMode.PathVideoMode);
                }
            }
        }

        public RelayCommand<string> ToolBarCmd => new Lazy<RelayCommand<string>>(() =>
            new RelayCommand<string>(ToolBar)).Value;

        private void ToolBar(string para)
        {
            var dialog = new OpenFileDialog();
            int type = (int)ChatMessageType.Image;
            if (para == "picture")
            {
                dialog.Filter = "图片|*.jpg;*.png;*.gif;*.jpeg;*.bmp";
                type = (int)ChatMessageType.Image;
            }
            else if (para == "video-camera")
            {
                dialog.Filter = "视频|*.mpg;*.mpeg;*.avi;*.rm;*.rmvb;*.mov;*.wmv;*.asf;*.dat";
                type = (int)ChatMessageType.Video;
            }
            else if (para == "audio")//MP3;AAC;WAV;WMA;CDA;FLAC;M4A;MID;MKA;MP2;MPA;MPC;APE;OFR;OGG;RA;WV;TTA;AC3;DTS 
            {
                dialog.Filter = "音频|*.mp3;*.aac;*.wav;*.wma";
                type = (int)ChatMessageType.Audio;
            }
            else if (para == "file")
            {
                type = (int)ChatMessageType.Upload;
            }
            else if (para == "history")
            {
                IsHistory = !IsHistory;
                return;
            }
            if (dialog.ShowDialog() == true)
            {
                var fileName = dialog.FileName;
                if (File.Exists(fileName))
                {
                    var info = new D_UserMessageDTO
                    {
                        Text = fileName,
                        Type = type,                      
                    };
                    RaiseChatSendChanged(info);
                }
            }
        }

        #region Routed Event
        public static readonly RoutedEvent ChatSendChangedEvent = EventManager.RegisterRoutedEvent("ChatSendChanged", RoutingStrategy.Bubble, typeof(ChatSendEventHandler), typeof(ChatBox));
        public event ChatSendEventHandler ChatSendChanged
        {
            add { AddHandler(ChatSendChangedEvent, value); }
            remove { RemoveHandler(ChatSendChangedEvent, value); }
        }
        void RaiseChatSendChanged(D_UserMessageDTO content)
        {
            var arg = new ChatSendEventArgs(content, ChatSendChangedEvent);
            RaiseEvent(arg);
        }

        public static readonly RoutedEvent HistorySearchChangedEvent = EventManager.RegisterRoutedEvent("HistorySearchChanged", RoutingStrategy.Bubble, typeof(HistorySearchEventHandler), typeof(ChatBox));
        public event HistorySearchEventHandler HistorySearchChanged
        {
            add { AddHandler(HistorySearchChangedEvent, value); }
            remove { RemoveHandler(HistorySearchChangedEvent, value); }
        }
        void RaiseChatSendChanged(DateTime startTime, DateTime endTime)
        {
            var arg = new HistorySearchEventArgs(startTime, endTime, HistorySearchChangedEvent);
            RaiseEvent(arg);
        }
        #endregion

        public static readonly DependencyProperty ToolConfigsProperty = DependencyProperty.Register(
         "ToolConfigs", typeof(ObservableCollection<ToolConfig>), typeof(ChatBox), new PropertyMetadata(null));

        public ObservableCollection<ToolConfig> ToolConfigs
        {
            get { return (ObservableCollection<ToolConfig>)this.GetValue(ToolConfigsProperty); }
            set { this.SetValue(ToolConfigsProperty, value); }
        }

        public static readonly DependencyProperty EmjioItemsProperty = DependencyProperty.Register(
       "EmjioItems", typeof(ObservableCollection<EmjioItem>), typeof(ChatBox), new PropertyMetadata(null));

        public ObservableCollection<EmjioItem> EmjioItems
        {
            get { return (ObservableCollection<EmjioItem>)this.GetValue(EmjioItemsProperty); }
            set { this.SetValue(EmjioItemsProperty, value); }
        }

        public RelayCommand<string> EmjioSendCmd => new Lazy<RelayCommand<string>>(() =>
         new RelayCommand<string>(EmjioSend)).Value;

        private void EmjioSend(string emjio)
        {
            ChatString += emjio;
            IsOpenEmjio = false;
        }

        /// <summary>
        /// Gets or sets is open.
        /// </summary>
        public bool IsOpenEmjio
        {
            get { return (bool)GetValue(IsOpenEmjioProperty); }
            set { SetValue(IsOpenEmjioProperty, value); }
        }

        public static readonly DependencyProperty IsOpenEmjioProperty =
            DependencyProperty.Register("IsOpenEmjio", typeof(bool), typeof(ChatBox));
    }



    public class ChatSendEventArgs : RoutedEventArgs
    {
        public ChatSendEventArgs(D_UserMessageDTO content, RoutedEvent routedEvent) : base(routedEvent)
        {
            Content = content;
        }

        public D_UserMessageDTO Content { get; set; }
    }

    public delegate void ChatSendEventHandler(object sender, ChatSendEventArgs e);

    public class HistorySearchEventArgs : RoutedEventArgs
    {
        public HistorySearchEventArgs(DateTime startTime, DateTime endTime, RoutedEvent routedEvent) : base(routedEvent)
        {
            StartTime = startTime;
            EndTime = endTime;
        }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
    public delegate void HistorySearchEventHandler(object sender, HistorySearchEventArgs e);

    public struct ToolConfig
    {
        public string Icon { get; set; }
        public string Title { get; set; }
    }

    public struct EmjioItem
    {
        public string Emjio { get; set; }
        public string Uri { get; set; }
    }
}
