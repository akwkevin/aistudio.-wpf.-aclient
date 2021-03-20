using AIStudio.Core;
using AIStudio.Core.Validation;
using AIStudio.Wpf.Business;
using AIStudio.Wpf.LocalConfiguration;
using AIStudio.Wpf.Service.IAppClient;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Input;

namespace AIStudio.Wpf.Client.ViewModels
{
    public partial class LoginWindowViewModel : BindableBase
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

        private string _serverIP;
        public string ServerIP
        {
            get { return _serverIP; }
            set
            {
                SetProperty(ref _serverIP, value);
            }
        }

        private string _userName;
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
                return this._loginCommand ?? (this._loginCommand = new DelegateCommand<Window>(para => this.Login(para)));
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

        private async void Login(Window window)
        {
            if (Loginning) return;

            try
            {
                if (window != null)
                {
                    _window = window;
                }
                Loginning = true;
                if (!string.IsNullOrEmpty(Error))
                {
                    LoginError = Error;
                    return;
                }

                if (LoginStatus == "Input")
                {
                    if (!string.IsNullOrEmpty(LocalSetting.VerifyMode))
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
                    var token = await _dataProvider.GetToken(ServerIP, UserName, MD5Password, 1, TimeSpan.FromSeconds(8));
                    if (!token.IsOK)
                    {
                        throw new Exception(token.ErrorMessage);
                    }
                    else
                    {
                        success = true;
                    }
                }

                if (success)
                {
                    if (IsRmembered)
                    {
                        _localConfig.AddLoginInfo(new LoginInfo() { UserName = UserName, Password = MD5Password, });
                    }
                    _operator.UserName = UserName;
                    //登陆操作成功后，发送消息                   
                    LocalSetting.SetAppSetting("ServerIP", ServerIP);

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
            if ((bool)result == true)
            {
                Login(null);
            }
        }
    }

    public partial class LoginWindowViewModel : IDataErrorInfo
    {
        class LoginWindowViewModelMetadata
        {
            [StringNullValidation(ErrorMessage = "用户名不能为空")]
            public string UserName { get; set; }
            [StringNullValidation(ErrorMessage = "密码不能为空")]
            public string Password { get; set; }
        }

        public string Error
        {
            get
            {
                string error = null;
                PropertyInfo[] propertys = this.GetType().GetProperties();
                foreach (PropertyInfo pinfo in propertys)
                {
                    //循环遍历属性
                    if (pinfo.CanRead && pinfo.CanWrite)
                    {
                        error = this.ValidateProperty<LoginWindowViewModelMetadata>(pinfo.Name);
                        if (error != null && error.Length > 0)
                        {
                            break;
                        }
                    }
                }
                return error;
            }
        }

        public string this[string columnName]
        {
            get
            {
                return this.ValidateProperty<LoginWindowViewModelMetadata>(columnName);
            }
        }
    }
}
