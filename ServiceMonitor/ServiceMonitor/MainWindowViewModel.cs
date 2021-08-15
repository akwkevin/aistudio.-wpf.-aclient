using AIStudio.Wpf.Business;
using AIStudio.Wpf.Entity.DTOModels;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace ServiceMonitor
{
    class MainWindowViewModel : BindableBase
    {
        private string _databaseType = "Sqlite";
        public string DatabaseType
        {
            get { return _databaseType; }
            set
            {
                SetProperty(ref _databaseType, value);
            }
        }

        private int _port = 5000;
        public int Port
        {
            get { return _port; }
            set
            {
                SetProperty(ref _port, value);
            }
        }

        private bool _createNoWindow = false;
        public bool CreateNoWindow
        {
            get { return _createNoWindow; }
            set
            {
                SetProperty(ref _createNoWindow, value);
            }
        }

        private ObservableCollection<D_OnlineUserDTO> _userDatas;
        public ObservableCollection<D_OnlineUserDTO> UserDatas
        {
            get { return _userDatas; }
            set
            {
                if (_userDatas != value)
                {
                    _userDatas = value;
                    RaisePropertyChanged("UserDatas");
                }
            }
        }

        protected ListCollectionView _view;

        private ICommand _startCommand;
        public ICommand StartCommand
        {
            get
            {
                return this._startCommand ?? (this._startCommand = new DelegateCommand(() => this.Start()));
            }
        }

        private ICommand _stopCommand;
        public ICommand StopCommand
        {
            get
            {
                return this._stopCommand ?? (this._stopCommand = new DelegateCommand(() => this.Stop()));
            }
        }

        private ICommand _refreshCommand;
        public ICommand RefreshCommand
        {
            get
            {
                return this._refreshCommand ?? (this._refreshCommand = new DelegateCommand(() => this.Refresh()));
            }
        }

        private ICommand _swaggerCommand;
        public ICommand SwaggerCommand
        {
            get
            {
                return this._swaggerCommand ?? (this._swaggerCommand = new DelegateCommand(() => this.Swagger()));
            }
        }

        IDataProvider _dataProvider;
        public MainWindowViewModel()
        {
            _dataProvider = new ApiDataProvider();
        }
        private void Start()
        {
            if (CmdHelper.GetPidByPort(Port).Count > 0)
            {
                MessageBox.Show("服务已经启动或者端口号被占用！！！");
                return;
            }


            System.IO.File.Copy($"{DatabaseType.ToLower()}//appsettings.json", "server//appsettings.json", true);      

            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";             //设定需要执行的命令 
            p.StartInfo.UseShellExecute = false;          //不使用系统外壳程序启动  
            p.StartInfo.RedirectStandardInput = true;     //重定向输入（一定是true） 
            p.StartInfo.RedirectStandardOutput = false;    //重定向输出  
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = CreateNoWindow;            //不创建窗口 

            p.Start();

            p.StandardInput.WriteLine("cd server");
            p.StandardInput.WriteLine($"dotnet Coldairarrow.Api.dll --urls http://*:{Port}");
        }

        private void Stop()
        {
            List<int> list_pid = CmdHelper.GetPidByPort(Port);
            if (list_pid.Count == 0)
            {
                MessageBox.Show("没有要停止的服务！！！");
                return;
            }
            List<string> list_process = CmdHelper.GetProcessNameByPid(list_pid);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("占用" + Port + "端口的进程有:");
            foreach (var item in list_process)
            {
                sb.Append(item + "\r\n");
            }
            sb.AppendLine("是否要结束这些进程？");

            if (MessageBox.Show(sb.ToString(), "系统提示", MessageBoxButton.YesNo) == MessageBoxResult.No)
                return;
            CmdHelper.PidKill(list_pid);
            MessageBox.Show("操作完成");
        }

        private async void Refresh()
        {

            await _dataProvider.GetToken("http://localhost:5000", "Admin", "Admin", 1, TimeSpan.FromSeconds(60));

            var result = await _dataProvider.GetData<List<D_OnlineUserDTO>>($"/D_Manage/D_UserMessage/GetUserList");
            if (!result.Success)
            {
                throw new Exception(result.Msg);
            }
            else
            {
                UserDatas = new ObservableCollection<D_OnlineUserDTO>(result.Data);
               
                _view = (ListCollectionView)CollectionViewSource.GetDefaultView(UserDatas);
                _view.Filter = Filter;
            }
        }

        private bool Filter(object obj)
        {
            D_OnlineUserDTO s = obj as D_OnlineUserDTO;
            if (s == null) return false;

            if (s.Online)
            {
                return true;
            }

            return false;
          
        }

        private void Swagger()
        {
            System.Diagnostics.Process.Start("explorer.exe", $"http://localhost:{Port}/swagger/index.html");
        }
    }
}
