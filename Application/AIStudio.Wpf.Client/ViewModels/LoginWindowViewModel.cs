using AIStudio.Core;
using AIStudio.Core.Models;
using AIStudio.LocalConfiguration;
using AIStudio.Wpf.Business;
using Prism.Commands;
using Prism.Events;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using AIStudio.Wpf.Controls;
using Accelerider.Extensions.Mvvm;
using AIStudio.Wpf.Client.Views;

namespace AIStudio.Wpf.Client.ViewModels
{
    public partial class LoginWindowViewModel : DataErrorInfoBindableBase, IViewLoadedAndUnloadedAware<LoginWindow>
    {
        private ObservableCollection<LoginInfo> _loginInfo;
        public ObservableCollection<LoginInfo> LoginInfo
        {
            get { return _loginInfo; }
            set
            {
                SetProperty(ref _loginInfo, value);
            }
        }

        private string _version;
        public string Version
        {
            get { return _version; }
            set
            {
                SetProperty(ref _version, value);
            }
        }

        public bool ApiMode { get { return (!string.IsNullOrEmpty(ServerIP) && ServerIP != LocalSetting.Standalone); } }

        private string _serverIP;
        public string ServerIP
        {
            get { return _serverIP; }
            set
            {
                SetProperty(ref _serverIP, value);
            }
        }

        private ObservableCollection<string> _servers;
        public ObservableCollection<string> Servers
        {
            get { return _servers; }
            set
            {
                SetProperty(ref _servers, value);
            }
        }

        private string _userName;
        [Required(ErrorMessage = "用户名不能为空")]
        public string UserName
        {
            get { return _userName; }
            set
            {
                if (SetProperty(ref _userName, value))
                {
                    AutoPassword();
                }
            }
        }

        private string _password;
        [Required(ErrorMessage = "密码不能为空")]
        public string Password
        {
            get { return _password; }
            set
            {
                if (SetProperty(ref _password, value))
                {
                    MD5Password = null;
                }
            }
        }

        public string MD5Password { get; set; }

        private bool _isRmembered = true;
        public bool IsRmembered
        {
            get { return _isRmembered; }
            set
            {
                SetProperty(ref _isRmembered, value);
            }
        }

        private string _loginError;
        public string LoginError
        {
            get { return _loginError; }
            set
            {
                SetProperty(ref _loginError, value);
            }
        }

        private string _loginStatus = "Input";
        public string LoginStatus
        {
            get { return _loginStatus; }
            set
            {
                SetProperty(ref _loginStatus, value);
            }
        }

        private ICommand _loginCommand;
        public ICommand LoginCommand
        {
            get
            {
                return this._loginCommand ?? (this._loginCommand = new DelegateCommand(() => this.Login()));
            }
        }

        private ICommand _resultChangedComamnd;
        public ICommand ResultChangedComamnd
        {
            get
            {
                return this._resultChangedComamnd ?? (this._resultChangedComamnd = new DelegateCommand<object>(obj => this.ResultChanged(obj)));
            }
        }


        IEventAggregator _aggregator { get; }
        IOperator _operator { get; }
        IDataProvider _dataProvider { get; }
        IUserConfig _localConfig { get; }


        public LoginWindowViewModel(IEventAggregator aggregator, IOperator ioperator, IDataProvider dataProvider, IUserConfig localConfig)
        {
            _aggregator = aggregator;
            _operator = ioperator;
            _dataProvider = dataProvider;

            _localConfig = localConfig;

            LoginInfo = _localConfig.LoginInfo;
            ServerIP = LocalSetting.ServerIP;
            Servers = new ObservableCollection<string>(LocalSetting.Servers.Split(";", StringSplitOptions.RemoveEmptyEntries));
            Version = LocalSetting.Version;

            var info = LoginInfo.FirstOrDefault();
            if (info != null)
            {
                _userName = info.UserName;
                RaisePropertyChanged("UserName");
                _password = info.Password;
                RaisePropertyChanged("Password");
                MD5Password = info.Password;
            }

        }

        private void AutoPassword()
        {
            var info = LoginInfo.FirstOrDefault(p => p.UserName == UserName);
            if (info != null)
            {
                Password = info.Password;
                MD5Password = info.Password;
            }
            else
            {
                Password = null;
            }
        }

        private bool Loginning = false;
        private Window _window;

        private async void Login()
        {
            if (Loginning) return;

            try
            {
                Loginning = true;
                if (!string.IsNullOrEmpty(Error))
                {
                    LoginError = Error;
                    return;
                }

                if (LoginStatus == "Input")
                {
                    if (LocalSetting.ApiMode != ApiMode)
                    {
                        LocalSetting.SetAppSetting("ServerIP", ServerIP);

                        if (Controls.MessageBox.Show("服务器模式在[前后端分离方式]与[客户端独立模式]发生了切换,需要重启生效,立即重启？") == MessageBoxResult.OK)
                        {
                            Process p = new Process();
                            p.StartInfo.FileName = System.AppDomain.CurrentDomain.BaseDirectory + "AIStudio.Wpf.Client.exe";
                            p.StartInfo.UseShellExecute = false;
                            p.Start();
                            
                            _window.Close();
                        }
                        return;
                    }

                    if (!string.IsNullOrEmpty(LocalSetting.VerifyMode))//如果开启了日志验证
                    {
                        LoginStatus = LocalSetting.VerifyMode;
                        return;
                    }
                }
                LoginStatus = "Input";

                bool success = false;
                if (string.IsNullOrEmpty(MD5Password))
                {
                    MD5Password = Password.ToMD5String();
                }
                if (UserName == "LocalUser" && MD5Password == "LocalUser".ToMD5String())
                {
                    success = true;
                }
                else
                {
                    var token = await _dataProvider.GetToken(ServerIP, UserName, MD5Password, 1, TimeSpan.FromSeconds(60));
                    if (!token.Success)
                    {
                        throw new Exception(token.Msg);
                    }
                    else
                    {
                        success = true;
                    }
                    LocalSetting.TokenJson = _dataProvider.GetHeader().ToJson();
                }

                if (success)
                {
                    if (IsRmembered)
                    {
                        _localConfig.AddLoginInfo(new LoginInfo() { UserName = UserName, Password = MD5Password, });
                    }
                    _operator.UserName = UserName;

                    LocalSetting.SetAppSetting("ServerIP", ServerIP);           

                    if (!Servers.Contains(ServerIP))
                    {
                        Servers.Add(ServerIP);
                        LocalSetting.SetAppSetting("Servers", string.Join(";", Servers));//把新服务器保存起来
                    }

                    _window.DialogResult = success;
                    _window.Close();
                }
            }
            catch (Exception ex)
            {
                LoginError = ex.Message;
            }
            finally
            {
                Loginning = false;
            }
        }

        private void ResultChanged(object result)
        {
            if ((bool)result == true)//验证成功
            {
                Login();
            }
        }

        public void OnLoaded(LoginWindow view)
        {
            _window = view;
        }

        public void OnUnloaded(LoginWindow view)
        {
            
        }
    }


}
