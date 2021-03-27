using AIStudio.Core;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using SuperSocket.ClientEngine;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using WebSocket4Net;

namespace AIStudio.Wpf.Business
{
    public class WSocketClient : BindableBase, IWSocketClient
    {
        private ILogger _logger { get => ContainerLocator.Current.Resolve<ILogger>(); }

        #region 向外传递数据事件
        public event Action<WSMessageType, string> MessageReceived;
        #endregion

        WebSocket4Net.WebSocket _webSocket;
        /// <summary>
        /// 检查重连线程
        /// </summary>
        Thread _thread;
        bool _isRunning = true;
        /// <summary>
        /// WebSocket连接地址
        /// </summary>
        public string ServerPath { get; set; }

        public WSocketClient(string serverip, string url)
        {
            Init(serverip, url);
        }

        public WSocketClient()
        {

        }

        private void Init(string serverip, string url)
        {
            ServerIP = serverip;
            ServerPath = url;
            if (_webSocket != null)
            {
                Dispose();
            }
            this._webSocket = new WebSocket4Net.WebSocket(url);
            this._webSocket.Opened -= WebSocket_Opened;
            this._webSocket.Opened += WebSocket_Opened;
            this._webSocket.Error -= WebSocket_Error;
            this._webSocket.Error += WebSocket_Error;
            this._webSocket.Closed -= WebSocket_Closed;
            this._webSocket.Closed += WebSocket_Closed;
            this._webSocket.MessageReceived -= WebSocket_MessageReceived;
            this._webSocket.MessageReceived += WebSocket_MessageReceived;
            IsInit = true;


        }

        public void InitAndStart(string serverip, string url)
        {
            Init(serverip, url);
            Start();
        }

        #region "web socket "
        /// <summary>
        /// 连接方法
        /// <returns></returns>
        public bool Start()
        {
            bool result = true;
            try
            {
                this._webSocket.Open();

                this._isRunning = true;
                this._thread = new Thread(new ThreadStart(CheckConnection));
                this._thread.Start();
            }
            catch (Exception ex)
            {
                _logger.Error(LogType.WebSocket, ex.ToString());
                result = false;
            }
            return result;
        }
        /// <summary>
        /// 消息收到事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void WebSocket_MessageReceived(object sender, MessageReceivedEventArgs e)
        {
            //_logger.Info(LogType.WebSocket, " Received:" + e.Message);

            var result = JsonConvert.DeserializeObject<MessageResult>(e.Message);
            if (result.MessageType == WSMessageType.PingType)
            {
                try
                {
                    DelayMS = (int)(DateTime.Now - DateTime.ParseExact(result.Data.ToString(), "yyyy-MM-dd HH:mm:ss.fff", System.Globalization.CultureInfo.CurrentCulture)).TotalMilliseconds;
                }
                catch { DelayMS = null; }
                return;
            }


            MessageReceived?.Invoke(result.MessageType, (result.Data??"").ToString());
        }
        /// <summary>
        /// Socket关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void WebSocket_Closed(object sender, EventArgs e)
        {
            _logger.Info(LogType.WebSocket, "websocket_Closed");
        }
        /// <summary>
        /// Socket报错事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void WebSocket_Error(object sender, ErrorEventArgs e)
        {
            _logger.Info(LogType.WebSocket, "websocket_Error:" + e.Exception.ToString());
        }
        /// <summary>
        /// Socket打开事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void WebSocket_Opened(object sender, EventArgs e)
        {
            _logger.Info(LogType.WebSocket, " websocket_Opened");
        }
        /// <summary>
        /// 检查重连线程
        /// </summary>
        private void CheckConnection()
        {
            do
            {
                try
                {
                    IsConnected = true;
                    if (this._webSocket.State != WebSocket4Net.WebSocketState.Open && this._webSocket.State != WebSocket4Net.WebSocketState.Connecting)
                    {
                        _logger.Info(LogType.WebSocket, " Reconnect websocket WebSocketState:" + this._webSocket.State);
                        this._webSocket.Close();
                        this._webSocket.Open();
                        Console.WriteLine("正在重连");

                        IsConnected = false;
                        DelayMS = null;
                    }
                    else if (PingIntervalMS > 0)
                    {
                        MessageResult send = new MessageResult();
                        send.MessageType = WSMessageType.PingType;
                        send.Data = DateTime.Now;                        
                        SendMessage(send.ToStandardTimeFormatJson());
                    }                    
                }
                catch (Exception ex)
                {
                    _logger.Error(LogType.WebSocket, ex.ToString());
                }
                int sleepms = (IsConnected && PingIntervalMS > 0) ? PingIntervalMS : 5000;
                bool isStopPingFlag = PingIntervalMS > 0 ? false : true;
                while (sleepms > 0)
                {
                    sleepms = sleepms - 1000;
                    if (sleepms > 0)
                        System.Threading.Thread.Sleep(1000);
                    else
                        System.Threading.Thread.Sleep(sleepms + 1000);
                    if (isStopPingFlag && PingIntervalMS > 0)
                        break;
                }
            } while (this._isRunning);
        }
        #endregion

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="Message"></param>
        public void SendMessage(string Message)
        {
            Task.Factory.StartNew(() =>
            {
                if (_webSocket != null && _webSocket.State == WebSocket4Net.WebSocketState.Open)
                {
                    this._webSocket.Send(Message);
                }
            });
        }

        public void Dispose()
        {
            this._isRunning = false;
            try
            {
                if (_thread != null)
                {
                    _thread.Abort();
                }
            }
            catch
            {

            }

            if (this._webSocket != null)
            {
                this._webSocket.Close();
                this._webSocket.Dispose();
                this._webSocket = null;
            }
        }

        private bool _isinit;
        public bool IsInit
        {
            get { return _isinit; }
            set
            {
                SetProperty(ref _isinit, value);
            }
        }

        private bool _isConnected = true;
        public bool IsConnected
        {
            get { return _isConnected; }
            set
            {
                SetProperty(ref _isConnected, value);
            }
        }

        private bool _isPing = true;
        public bool IsPing
        {
            get { return _isPing; }
            set
            {
                SetProperty(ref _isPing, value);
            }
        }

        private string _serverIP;
        public string ServerIP
        {
            get { return _serverIP; }
            set
            {
                SetProperty(ref _serverIP, value);
            }
        }

        private int? _delayMS;
        public int? DelayMS
        {
            get
            {
                if (PingIntervalMS < 0)
                    return null;
                else
                    return _delayMS;
            }
            set
            {
                if (SetProperty(ref _delayMS, value))
                {
                    SetAlarmGrade(value);
                }
            }
        }

        private void SetAlarmGrade(int? value)
        {
            if (value.HasValue)
            {
                if (value < 0)
                {
                    AlarmGrade = AlarmGrade.Danger;
                }
                else if (value < 100)
                {
                    AlarmGrade = AlarmGrade.Success;
                }
                else if (value < 1000)
                {
                    AlarmGrade = AlarmGrade.Warning;
                }
                else
                {
                    AlarmGrade = AlarmGrade.Danger;
                }
            }
            else
            {
                AlarmGrade = AlarmGrade.Success;
            }
        }

        private AlarmGrade _alarmGrade = AlarmGrade.Success;
        public AlarmGrade AlarmGrade
        {
            get { return _alarmGrade; }
            set
            {
                SetProperty(ref _alarmGrade, value);
            }
        }

        private int _pingIntervalMS = 1000;
        public int PingIntervalMS
        {
            get { return _pingIntervalMS; }
            set
            {
                SetProperty(ref _pingIntervalMS, value);
            }
        }

        private ICommand _startPingCommand;
        public ICommand StartPingCommand
        {
            get
            {
                return this._startPingCommand ?? (this._startPingCommand = new DelegateCommand(() => this.StartPing()));
            }
        }

        private ICommand _stopPingCommand;
        public ICommand StopPingCommand
        {
            get
            {
                return this._stopPingCommand ?? (this._stopPingCommand = new DelegateCommand(() => this.StopPing()));
            }
        }

        private void StartPing()
        {
            PingIntervalMS = 1000;
            IsPing = true;
        }

        private void StopPing()
        {
            PingIntervalMS = -1;
            IsPing = false;
            RaisePropertyChanged("DelayMS");
        }
    }
}
