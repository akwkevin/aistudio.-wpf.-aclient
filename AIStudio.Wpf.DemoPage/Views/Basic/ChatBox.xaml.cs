using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Util.Controls.Tools;
using Util.Controls.Data;
using System.Media;
using Util.Controls;
using System.Diagnostics;
using System.IO;
using Microsoft.Win32;
using System.Windows.Media.Imaging;

namespace AIStudio.Wpf.DemoPage.Views
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

            ChatInfos = new ObservableCollection<ChatInfoModel>();
            ListBoxChat.ItemContainerGenerator.ItemsChanged += ItemContainerGenerator_ItemsChanged;
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
          "ChatInfos", typeof(ObservableCollection<ChatInfoModel>), typeof(ChatBox), new PropertyMetadata(null));

        public ObservableCollection<ChatInfoModel> ChatInfos
        {
            get { return (ObservableCollection<ChatInfoModel>)this.GetValue(ChatInfosProperty); }
            set { this.SetValue(ChatInfosProperty, value); }
        }

        public RelayCommand<KeyEventArgs> SendStringCmd => new Lazy<RelayCommand<KeyEventArgs>>(() =>
           new RelayCommand<KeyEventArgs>(SendString)).Value;

        private void SendString(KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (string.IsNullOrEmpty(ChatString)) return;
                var info = new ChatInfoModel
                {
                    Message = ChatString,
                    SenderId = _id,
                    Type = (int)ChatMessageType.String,
                    Role = "Sender",
                    Avatar = "pack://application:,,,/AIStudio.Wpf.DemoPage;component/Resources/Img/Avatar/avatar1.png",
                };
                //ChatInfos.Add(info);
                RaiseChatSendChanged(info);
                ChatString = string.Empty;
            }
        }

        public RelayCommand<RoutedEventArgs> ReadMessageCmd => new Lazy<RelayCommand<RoutedEventArgs>>(() =>
           new RelayCommand<RoutedEventArgs>(ReadMessage)).Value;

        private void ReadMessage(RoutedEventArgs e)
        {
            if (e.OriginalSource is FrameworkElement element && element.Tag is ChatInfoModel info)
            {
                if (info.Type == (int)ChatMessageType.Image)
                {
                    new Util.Controls.Windows.ImageBrowser(new Uri(info.Enclosure.ToString()))
                    {
                        Owner = WindowHelper.GetActiveWindow()
                    }.Show();
                }
                else if (info.Type == (int)ChatMessageType.Phonetics)
                {
                    var player = new SoundPlayer(info.Enclosure.ToString());
                    player.PlaySync();
                }
            }
        }

        public RelayCommand StartRecordCmd => new Lazy<RelayCommand>(() =>
          new RelayCommand(StartRecord)).Value;

        private void StartRecord()
        {
            Win32Helper.MciSendString("set wave bitpersample 8", "", 0, 0);
            Win32Helper.MciSendString("set wave samplespersec 20000", "", 0, 0);
            Win32Helper.MciSendString("set wave channels 2", "", 0, 0);
            Win32Helper.MciSendString("set wave format tag pcm", "", 0, 0);
            Win32Helper.MciSendString("open new type WAVEAudio alias movie", "", 0, 0);
            Win32Helper.MciSendString("record movie", "", 0, 0);

            _stopwatch.Reset();
            _stopwatch.Start();
        }

        public RelayCommand StopRecordCmd => new Lazy<RelayCommand>(() =>
            new RelayCommand(StopRecord)).Value;

        private void StopRecord()
        {
            if (!Directory.Exists(AudioCachePath))
            {
                try
                {
                    Directory.CreateDirectory(AudioCachePath);
                }
                catch (Exception e)
                {
                    Growl.Error(e.Message);
                    return;
                }
            }

            var cachePath = $"{AudioCachePath}\\{Guid.NewGuid().ToString()}";
            var cachePathWithQuotes = $"\"{cachePath}\"";
            Win32Helper.MciSendString("stop movie", "", 0, 0);
            Win32Helper.MciSendString($"save movie {cachePathWithQuotes}", "", 0, 0);
            Win32Helper.MciSendString("close movie", "", 0, 0);

            _stopwatch.Stop();

            var info = new ChatInfoModel
            {
                Message = $"{_stopwatch.Elapsed.Seconds.ToString()} {"Second"}",
                SenderId = _id,
                Type = (int)ChatMessageType.Phonetics,
                Role = "Sender",
                Enclosure = cachePath,
                Avatar = "pack://application:,,,/AIStudio.Wpf.DemoPage;component/Resources/Img/Avatar/avatar1.png",
            };
            //ChatInfos.Add(info);
            RaiseChatSendChanged(info);
        }

        public RelayCommand OpenImageCmd => new Lazy<RelayCommand>(() =>
            new RelayCommand(OpenImage)).Value;

        private void OpenImage()
        {
            var dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == true)
            {
                var fileName = dialog.FileName;
                if (File.Exists(fileName))
                {
                    var info = new ChatInfoModel
                    {
                        Message = BitmapFrame.Create(new Uri(fileName)),
                        SenderId = _id,
                        Type = (int)ChatMessageType.Image,
                        Role = "Sender",
                        Enclosure = fileName,
                        Avatar = "pack://application:,,,/AIStudio.Wpf.DemoPage;component/Resources/Img/Avatar/avatar1.png",
                    };
                    //ChatInfos.Add(info);
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
        void RaiseChatSendChanged(ChatInfoModel content)
        {
            var arg = new ChatSendEventArgs(content, ChatSendChangedEvent);
            RaiseEvent(arg);
        }
        #endregion
    }

    public struct ChatInfoModel
    {
        public object Message { get; set; }

        public string SenderId { get; set; }

        public string Role { get; set; }

        public int Type { get; set; }

        public object Enclosure { get; set; }

        public string Avatar { get; set; }
    }

    public class ChatSendEventArgs : RoutedEventArgs
    {
        public ChatSendEventArgs(ChatInfoModel content, RoutedEvent routedEvent) : base(routedEvent)
        {
            Content = content;
        }

        public ChatInfoModel Content { get; set; }
    }

    public delegate void ChatSendEventHandler(object sender, ChatSendEventArgs e);
}
