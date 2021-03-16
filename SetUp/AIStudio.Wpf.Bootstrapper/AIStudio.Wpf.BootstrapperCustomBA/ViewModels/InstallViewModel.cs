using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Windows;
using System.Windows.Input;
using Microsoft.Tools.WindowsInstallerXml.Bootstrapper;

namespace CustomBA.ViewModels
{
    public class InstallViewModel : PropertyNotifyBase
    {
        public enum InstallState
        {
            Initializing,
            Present,
            NotPresent,
            Applying,
            Cancelled,
            Applied,
            Failed,
        }

        public enum UpdateState
        {
            Unknown,
            Initializing,
            Checking,
            Current,
            Available,
            Failed,
        }

        /// <summary>
        /// 记录状态
        /// </summary>
        private InstallState state;
        public UpdateState updatestate;

        /// <summary>
        /// 需要显示在WPFWindow
        /// </summary>
        private string message;
        private BootstrapperApplicationModel model;
        private string _packageId = string.Empty;
        private bool canceled;
        private Dictionary<string, int> executingPackageOrderIndex;
        private string username;
        private int progress;
        private int cacheProgress;
        private int executeProgress;
        private Version _version = new Version("2.0.0.0");
        private int progressPhases=1;
        private bool isUnstalling=false;
        #region Command
        /// <summary>
        /// 执行安装命令
        /// </summary>
        public ICommand InstallCommand { get; private set; }
        public ICommand UninstallCommand { get; private set; }
        public ICommand CancelCommand { get; private set; }
        public ICommand LaunchNewsCommand { get; private set; }
        private ICommand repairCommand;

        public ICommand RepairCommand
        {
            get
            {
                return this.repairCommand ?? (this.repairCommand = new RelayCommand(param =>
                    model.PlanAction(LaunchAction.Repair) 
                 , param => State == InstallState.Present));
            }
        }

        #endregion 

        #region 属性
        public string Message
        {
            get
            {
                return message;
            }
            set
            {
                if (message != value)
                {
                    message = value;
                    OnPropertyChanged("Message");
                }
            }
        }

        public InstallState State
        {
            get
            {
                return state;
            }
            set
            {
                if (state != value)
                {
                    state = value;
                    Message = "Status: " + state;
                    OnPropertyChanged("State");
                    OnPropertyChanged("CompleteEnabled");
                    OnPropertyChanged("ExitEnabled");
                    OnPropertyChanged("CancelEnabled");
                    OnPropertyChanged("InstallEnabled");
                    OnPropertyChanged("ProgressEnabled");
                    OnPropertyChanged("UninstallEnabled");
                }
            }
        }

        public string PackageId
        {
            get { return _packageId; }
            set
            {
                if (_packageId != value)
                {
                    _packageId = "packid:" + value;
                    OnPropertyChanged("PackageId");
                }
            }
        }
        public bool Canceled
        {
            get
            {
                return this.canceled;
            }

            set
            {
                if (this.canceled != value)
                {
                    this.canceled = value;
                    OnPropertyChanged("Canceled");
                }
            }
        }
        public Version Version
        {
            get
            {
                return _version;
            }
        }

        public string Username
        {
            get
            {
                return this.username;
            }
            set
            {
                this.username = value;
                this.model.SetBurnVariable("Username", this.username);
            }
        }

     

        public int Progress
        {
            get
            {
                if (isUnstalling)
                {
                    return progress*2;
                }
                return this.progress;
            }
            set
            {
                this.progress = value;
                OnPropertyChanged("Progress");
                OnPropertyChanged("Persent");
            }
        }

        private string _info;

        public string Info
        {
            get
            {
                if(string.IsNullOrEmpty(_info))
                _info= InstallEnabled ? "安装中..." : "进行中...";
                return _info;
            }
            set
            {
                _info = value;
                OnPropertyChanged("Info");
            }
        }

        public string Persent
        {
            get { return Progress + "%"; }
        }

        public bool InstallEnabled
        {
            get { return State == InstallState.NotPresent; }
        }

        public bool UninstallEnabled
        {
            get
            {
                return State == InstallState.Present;
               // return UninstallCommand.CanExecute(this);
            }
        }

        public bool CancelEnabled
        {
            get { return  State == InstallState.Applying; }
        }

        public bool ExitEnabled
        {
            get { return this.State != InstallState.Applying; }
        }

        public bool ProgressEnabled
        {
            get { return this.State == InstallState.Applying; }
        }

        /// <summary>
        /// 是否同意协议 控制按钮使能
        /// </summary>
        public bool IsAgree
        {
            get { return _isAgree; }
            set
            {
                _isAgree = value;
                OnPropertyChanged("IsAgree");
            }
        }

        /// <summary>
        /// 先不管
        /// </summary>
        public bool IsUpToDate
        {
            get { return true; }
        }
        public bool RepairEnabled
        {
            get { return this.RepairCommand.CanExecute(this); }
        }

        public bool CompleteEnabled
        {
            get { return State == InstallState.Applied; }
        }

        public int  Phases
        {
            get


            {
                return progressPhases;
            }
        }

        private string _installText = "Uninstall";
        public string InstallText
        {
            get
            {
                return _installText;
            }
            set
            {
                _installText = value;
                OnPropertyChanged("InstallText");
            }
        }

        public string RepairText
        {
            get { return _repairText; }
            set
            {
                _repairText = value;
                OnPropertyChanged("RepairText");
            }
        }

        private bool _lableback=true;
        private string _repairText = "Repair";
        private string _installFollder = "";
        private string _spaceInfo = "所需空间200M 可用空间30G";
        private bool _isAgree=true;

        public bool LabelBack
        {
            get
            {
                return _lableback;
            }
            set
            {
                _lableback = value;
                OnPropertyChanged("LabelBack");
            }
        }


        public string InstallFollder
        {
            get
            {
                if (string.IsNullOrEmpty(_installFollder))
                {
                    _installFollder = IniFolder();
                }
                return _installFollder;
            }
            set
            {
                if (_installFollder != value && ValidDir(value))
                {
                    _installFollder = value;
                    OnPropertyChanged("InstallFollder");
                    model.SetTargetFolderPath(value);
                }
            }
        }

        /// <summary>
        /// 显示安装空间信息
        /// </summary>
        public string SpaceInfo
        {
            get { return _spaceInfo; }
            set
            {
                if (_spaceInfo != value)
                {
                    _spaceInfo = value;
                    OnPropertyChanged("SpaceInfo");
                }
            }
        }
        #endregion 

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_model"></param>
        public InstallViewModel(BootstrapperApplicationModel _model)
        {
            model = _model;
            executingPackageOrderIndex = new Dictionary<string, int>();
            State = InstallState.Initializing;
            //处理由bootstrapper触发的事件
            WireUpEventHandlers();
            //初始化命令 第一个参数是命令要触发的方法，第二个匿名函数是命令执行的条件
            InstallCommand = new RelayCommand(param => model.PlanAction(LaunchAction.Install), param => State == InstallState.NotPresent);

            UninstallCommand = new RelayCommand(param =>
            {
                model.PlanAction(LaunchAction.Uninstall);
                isUnstalling = true;
            }, param => State == InstallState.Present);

            CancelCommand = new RelayCommand(param =>
            {
                model.LogMessage("Cancelling...");
                if (State == InstallState.Applying)
                {
                    State = InstallState.Cancelled;
                }
                else
                {
                    CustomBootstrapperApplication.Dispatcher.InvokeShutdown();
                }
            }, param => State != InstallState.Cancelled);


            model.BootstrapperApplication.CacheAcquireProgress += CacheAcquireProgress;
            model.BootstrapperApplication.ExecuteProgress += ApplyExecuteProgress;
            model.BootstrapperApplication.ExecuteMsiMessage += ExecuteMsiMessage;
            model.BootstrapperApplication.PlanBegin += PlanBegin;
            model.BootstrapperApplication.PlanPackageComplete += PlanPackageComplete;
            model.BootstrapperApplication.Progress += ApplyProgress;
            model.BootstrapperApplication.CacheComplete += CacheComplete;

            iniSpaecInfo();
        }

        /// <summary>
        /// 事件订阅
        /// </summary>
        private void WireUpEventHandlers()
        {
            model.BootstrapperApplication.DetectPackageComplete += DetectPackageComplete;

            model.BootstrapperApplication.PlanComplete += PlanComplete;

            model.BootstrapperApplication.ApplyComplete += ApplyComplete;

            model.BootstrapperApplication.ApplyBegin += ApplyBegin;

            model.BootstrapperApplication.ExecutePackageBegin += ExecutePackageBegin;

            model.BootstrapperApplication.ExecutePackageComplete += ExecutePackageComplete;

        }

        private void iniSpaecInfo()
        {
            //找到系统盘
            //计算空间
            SpaceInfo = GetSpace(GetSystemFolder());
        }

        private string GetSpace(string pan)
        {
            realSpaec = 0;
            System.IO.DriveInfo drive = new System.IO.DriveInfo(pan);
            long freeSpace = drive.AvailableFreeSpace;//取得c盘的可用空间大小
            realSpaec = freeSpace/1024/1024/1024;
            return string.Format("所需空间{0}M，{1}盘可用空间{2}G", 400, pan, realSpaec);
        }

        private long realSpaec;

        private string IniFolder()
        {
            var path = GetSystemFolder();
            var is64 = Environment.Is64BitOperatingSystem; 
            path += is64 ? @"\Program Files (x86)" : @"\Program Files";

            path += @"\"+SoftName;

            return path;
        }

        private string GetSystemFolder()
        {
            return System.Environment.SystemDirectory.Substring(0, 2);
        }
        #endregion

        #region 方法
        /// <summary>
        /// 修改路径，需要验证，并重新获取盘别的空间
        /// </summary>
        /// <param name="dir"></param>
        /// <returns></returns>
        private bool ValidDir(string dir)
        {
            if (string.IsNullOrEmpty(dir))
            {
                MessageBox.Show("请选择安装路径", "提示", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }

            if (dir.Contains(":"))
            {
                var pan = dir.Split(':')[0] + ":";
                SpaceInfo = GetSpace(pan);
                if (realSpaec < 1)
                {
                    MessageBox.Show("空间可能不够", "提示", MessageBoxButton.OK, MessageBoxImage.Information);
                    return false;
                }
                return true;
            }
            else
            {
                MessageBox.Show("请选择正确的安装路径", "提示", MessageBoxButton.OK, MessageBoxImage.Information);
            }


            return false;
        }


        private void CacheAcquireProgress(object sender, CacheAcquireProgressEventArgs e)
        {
            lock (this)
            {
                this.cacheProgress = e.OverallPercentage;
                this.Progress = (this.cacheProgress + this.executeProgress) / this.Phases;
                e.Result = Canceled ? Result.Cancel : Result.Ok;
            }
        }
        private void ApplyExecuteProgress(object sender, ExecuteProgressEventArgs e)
        {
            lock (this)
            {

                this.executeProgress = e.OverallPercentage;
                this.Progress = (this.cacheProgress + this.executeProgress) / 2; // always two phases if we hit execution.

                if (CustomBootstrapperApplication.Model.Command.Display == Display.Embedded)
                {
                    CustomBootstrapperApplication.Model.Engine.SendEmbeddedProgress(e.ProgressPercentage, this.Progress);
                }

                e.Result =  Canceled ? Result.Cancel : Result.Ok;
            }
        }

        /// <summary>
        /// 这个方法 会在Detect中被调用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DetectPackageComplete(object sender, DetectPackageCompleteEventArgs e)
        {
            PackageId = e.PackageId;
            //对应的是MsiPackage Id="DIAView"
            //MessageBox.Show(e.PackageId + e.State);
            if (e.PackageId.Equals(SoftName, StringComparison.Ordinal))
            {
                State = e.State == PackageState.Present ? InstallState.Present : InstallState.NotPresent;
                //State =  InstallState.NotPresent;
            }
        }


        private void PlanBegin(object sender, PlanBeginEventArgs e)
        {
            lock (this)
            {
                if (InstallEnabled)
                {
                    this.progressPhases = (LaunchAction.Layout == CustomBootstrapperApplication.Model.PlannedAction) ? 1 : 2;
                }
                else
                {
                    LabelBack = false;
                }
                InstallText = "";
                RepairText = "";
              //  OnPropertyChanged("Phases");
             //   OnPropertyChanged("InstallEnabled");
                this.executingPackageOrderIndex.Clear();
            }
        }
        private void PlanPackageComplete(object sender, PlanPackageCompleteEventArgs e)
        {
            if (ActionState.None != e.Execute)
            {
                lock (this)
                {
                    Debug.Assert(!this.executingPackageOrderIndex.ContainsKey(e.PackageId));
                    this.executingPackageOrderIndex.Add(e.PackageId, this.executingPackageOrderIndex.Count);
                }
            }
        }

        /// <summary>
        /// PlanAction 结束后会触发这个方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void PlanComplete(object sender, PlanCompleteEventArgs e)
        {
            if (State == InstallState.Cancelled)
            {
                CustomBootstrapperApplication.Dispatcher.InvokeShutdown();
                return;
            }
            State = InstallState.Applying;
            model.ApplyAction();
        }
        /// <summary>
        /// ApplyAction 开始 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ApplyBegin(object sender, ApplyBeginEventArgs e)
        {
            State = InstallState.Applying;
          //  OnPropertyChanged("ProgressEnabled");
          //  OnPropertyChanged("CancelEnabled");
        }
        /// <summary>
        /// 安装
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ExecutePackageBegin(object sender, ExecutePackageBeginEventArgs e)
        {
            if (State == InstallState.Cancelled)
            {
                e.Result = Result.Cancel;
            }
        }

        private void ExecuteMsiMessage(object sender, ExecuteMsiMessageEventArgs e)
        {
            lock (this)
            {
                if (e.MessageType == InstallMessage.ActionStart)
                {
                    this.Message = e.Message;
                }
                e.Result = Canceled ? Result.Cancel : Result.Ok;
            }
        }
        private void CacheComplete(object sender, CacheCompleteEventArgs e)
        {
            lock (this)
            {
                this.cacheProgress = 100;
                this.Progress = (this.cacheProgress + this.executeProgress) / this.progressPhases;
            }
        }
        /// <summary>
        /// 卸载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ExecutePackageComplete(object sender, ExecutePackageCompleteEventArgs e)
        {
            if (State == InstallState.Cancelled)
            {
                e.Result = Result.Cancel;
            }
          //  OnPropertyChanged("CompleteEnabled");
        }
        /// <summary>
        /// Apply结束
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ApplyComplete(object sender, ApplyCompleteEventArgs e)
        {
            model.FinalResult = e.Status;
            State = InstallState.Applied;
            isUnstalling = false;
         //   OnPropertyChanged("CompleteEnabled");
           // CustomBootstrapperApplication.Dispatcher.InvokeShutdown();
        }

        private void ApplyProgress(object sender, ProgressEventArgs e)
        {
            lock (this)
            {
                e.Result =  Canceled ? Result.Cancel : Result.Ok;
            }
        }
       
     
        #endregion


        #region Config

        public string SoftName { get { return InstallConfig.SoftName; } }
        public string WebSite { get { return InstallConfig.WebSite; } }
        public string IcoUrl { get { return InstallConfig.IcoUrl; } }
        public string SoftTitle { get { return InstallConfig.SoftTitle; } }
        public string InstallFinished { get { return InstallConfig.InstallFinished; } }
        public string WeiXin { get { return InstallConfig.WeiXin; } }
        public string BkUrl { get { return InstallConfig.BkUrl; } }
            

        #endregion


    }
}
