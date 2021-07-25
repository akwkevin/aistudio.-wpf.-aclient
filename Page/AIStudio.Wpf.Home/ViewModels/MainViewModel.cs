using AIStudio.Core;
using AIStudio.Core.Models;
using AIStudio.Wpf.BasePage.DTOModels;
using AIStudio.Wpf.BasePage.Events;
using AIStudio.Wpf.Business;
using AIStudio.Wpf.Entity.DTOModels;
using AIStudio.Wpf.Home.Models;
using AIStudio.Wpf.Home.Views;
using AutoMapper;
using Dataforge.PrismAvalonExtensions.Events;
using Prism.Commands;
using Prism.Events;
using Prism.Ioc;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using Util.Controls;

namespace AIStudio.Wpf.Home.ViewModels
{
    class MainViewModel : Prism.Mvvm.BindableBase, INavigationAware
    {
        protected IContainerExtension _container { get; }
        public IRegionManager _regionManager { get; set; }//这个很重要，与View进行绑定，不然RequestNavigate不好使
        protected IEventAggregator _aggregator { get; }
        protected IOperator _operator { get; }
        protected IDataProvider _dataProvider { get; }
        protected IWSocketClient _wSocketClient { get; }
        protected IMapper _mapper { get; }

        public NoticeIconViewModel NoticeIconViewModel { get; set; }

        public MainViewModel(IContainerExtension container, IRegionManager regionManager, IEventAggregator aggregator, IOperator ioperator, IDataProvider dataProvider, IWSocketClient wSocketClient, IMapper mapper)
        {
            _container = container;
            _regionManager = regionManager;
            _aggregator = aggregator;
            _operator = ioperator;
            _dataProvider = dataProvider;
            _wSocketClient = wSocketClient;
            _mapper = mapper;

            LocalSetting.SettingChanged += SettingChanged;

            _aggregator.GetEvent<KeyExcuteEvent>().Subscribe(KeyExcuteEventReceived, (ev) => { return ev.Item1 == Identifier; });
            _aggregator.GetEvent<SelectedDocumentEvent>().Subscribe(SelectedDocumentEventReceived);
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            var identifier = navigationContext.Parameters["Identifier"] as string;
            if (!string.IsNullOrEmpty(identifier))
            {
                Identifier = identifier;
            }
            InitData();
            RegionName = AIStudio.Core.RegionName.TabContentRegion + "_" + Identifier;
            NoticeIconViewModel = new NoticeIconViewModel(this, Identifier);
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }

        public void OpenHomePage()
        {
            OpenPage("框架介绍");
        }

        private void OpenUserConsole()
        {
            OpenPage("我的控制台");
        }

        private void OpenPage(string title)
        {
            var item = SearchMenus.FirstOrDefault(p => p.Label == title);
            if (item != null)
            {
                NavigationParameters paras = new NavigationParameters();
                paras.Add("Title", item.Label);
                paras.Add("Identifier", Identifier);

                Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Loaded, (Action)delegate
                {
                    _regionManager.RequestNavigate(RegionName, item.WpfCode, NavigationComplete, paras);
                });
            }
        }

        public void OpenFullScreenWindow()
        {
            if (LocalSetting.ScreenMode == "Full")
            {
                var mainwindow = Application.Current.MainWindow;
                mainwindow.WindowState = WindowState.Maximized;
                mainwindow.Topmost = true;
                var localscreen = System.Windows.Forms.Screen.FromRectangle(new System.Drawing.Rectangle((int)mainwindow.Left, (int)mainwindow.Top, (int)mainwindow.Width, (int)mainwindow.Height));

                foreach (var screen in System.Windows.Forms.Screen.AllScreens)
                {
                    if (screen.DeviceName != localscreen?.DeviceName)
                    {
                        var otherwindow = new OtherMainWindow();
                        otherwindow.Show();
                        otherwindow.Top = screen.WorkingArea.Top;
                        otherwindow.Left = screen.WorkingArea.Left;
                        otherwindow.Height = screen.WorkingArea.Height;
                        otherwindow.Width = screen.WorkingArea.Width;
                        otherwindow.Topmost = true;
                        otherwindow.WindowState = WindowState.Maximized;
                        _regionManager.RegisterViewWithRegion(otherwindow.RegionName, typeof(MainView));
                    }
                }
            }

        }

        private void KeyExcuteEventReceived(Tuple<string, string> key)
        {
            KeyExcute(key.Item2);
        }

        public async void InitData()
        {
            #region 工具栏
            var section = LocalSetting.GetSection("usersetting") as UserSettingSection;
            if (section?.WindowItems[Identifier] != null)
            {
                ToolItems = new ObservableCollection<AToolItem>(section.WindowItems[Identifier].ToolItems.ChangeType<List<AToolItem>>());
            }
            #endregion

            #region 窗体布局
            Type type = WindowSetting.GetType();//获得类型  
            foreach (PropertyInfo sp in type.GetProperties())//获得类型的属性字段  
            {
                var key = sp.Name;

                var data = typeof(LocalSetting).GetProperty(key)?.GetValue(typeof(LocalSetting));
                sp.SetValue(WindowSetting, data);
            }
            #endregion


            Operator = _operator as Operator;
            WSocketClient = _wSocketClient as WSocketClient;

            #region 菜单
            if (_operator.UserName != "LocalUser")
            {
                try
                {
                    var control = WindowBase.ShowWaiting(WaitingType.Progress, Identifier);
                    control.WaitInfo = "正在获取用户信息";
                    var userinfo = await _dataProvider.GetData<UserInfoPermissions>("/Base_Manage/Home/GetOperatorInfo");
                    if (!userinfo.IsOK)
                    {
                        throw new System.Exception(userinfo.ErrorMessage);
                    }

                    _operator.Property = userinfo.ResponseItem.UserInfo;
                    _operator.Permissions = userinfo.ResponseItem.Permissions;
                    _operator.Avatar = userinfo.ResponseItem.UserInfo.Avatar;

                    control.WaitInfo = "正在获取菜单信息";
                    var menuinfo = await _dataProvider.GetData<List<Base_ActionTree>>("/Base_Manage/Home/GetOperatorMenuList");
                    if (!menuinfo.IsOK)
                    {
                        throw new System.Exception(menuinfo.ErrorMessage);
                    }
                    BuildMenu(menuinfo.ResponseItem);

                    if (LocalSetting.ApiMode)
                    {
                        //连接socket
                        _wSocketClient.InitAndStart(LocalSetting.ServerIP, $"{LocalSetting.ServerIP.Replace("http", "ws")}/ws?userName={_operator.Property.UserName}&userId={_operator.Property.Id}");
                        _wSocketClient.MessageReceived -= _wSocketClient_MessageReceived;
                        _wSocketClient.MessageReceived += _wSocketClient_MessageReceived;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    WindowBase.HideWaiting(Identifier);
                }
            }

#if DEBUG
            AMenuItem code = new AMenuItem() { Glyph = "code", Label = "开发", Code = "Demo", Type = 0 };
            MenuItems.Add(code);

            AMenuItem subcode = null;
            if (_operator.UserName != "LocalUser")
            {
                code.AddChildren(new AMenuItem() { Label = "数据库连接", Code = "/Base_Manage/Base_DbLinkView/", Type = 1 });
                code.AddChildren(new AMenuItem() { Label = "代码生成", Code = "/Base_Manage/BuildCodeView/", Type = 1 });
                code.AddChildren(new AMenuItem() { Label = "Swagger", Code = "/Base_Manage/SwaggerView/", Type = 1 });
                code.AddChildren(new AMenuItem() { Label = "文件上传", Code = "/Base_Manage/UploadView/", Type = 1 });
            }
#endif
            var tool = new AMenuItem() { Glyph = "tool", Label = "工具", Code = "Tool", Type = 0 };
            var screenshot = new AMenuItem() { Label = (string)Application.Current.Resources["截屏"], Code = "Screenshot", Type = 1 };
            var newWindow = new AMenuItem() { Label = (string)Application.Current.Resources["新增窗口"], Code = "NewWindow", Type = 1 };

            tool.AddChildren(newWindow);
            tool.AddChildren(screenshot);
            MenuItems.Add(tool);

            var winStatus = new AMenuItem() { Glyph = "windows", Label = (string)Application.Current.Resources["窗口"], Code = "WinStatus", Type = 0 };
            var showTitleBar = new AMenuItem() { Label = (string)Application.Current.Resources["标题显示"], Code = "ShowTitleBar", Type = 1, IsChecked = WindowBase.GetWindowStatus("ShowTitleBar", Identifier) };
            var showInTaskbar = new AMenuItem() { Label = (string)Application.Current.Resources["任务栏显示"], Code = "ShowInTaskbar", Type = 1, IsChecked = WindowBase.GetWindowStatus("ShowInTaskbar", Identifier) };
            var topmost = new AMenuItem() { Label = (string)Application.Current.Resources["总在最前"], Code = "Topmost", Type = 1, IsChecked = WindowBase.GetWindowStatus("Topmost", Identifier) };
            var toggleFullScreen = new AMenuItem() { Label = (string)Application.Current.Resources["最大化全屏"], Code = "ToggleFullScreen", Type = 1, IsChecked = WindowBase.GetWindowStatus("ToggleFullScreen", Identifier) };
            var notifyIcon = new AMenuItem() { Label = (string)Application.Current.Resources["托盘显示"], Code = "ShowNotifyIcon", Type = 1 };

            winStatus.AddChildren(showTitleBar);
            winStatus.AddChildren(showInTaskbar);
            winStatus.AddChildren(topmost);
            winStatus.AddChildren(toggleFullScreen);
            winStatus.AddChildren(notifyIcon);

            MenuItems.Add(winStatus);
            SearchMenus = new ObservableCollection<AMenuItem>(AddTotalMenu(MenuItems));

            _operator.MenuItems = MenuItems;
            _operator.SearchMenus = SearchMenus;
            #endregion

            IsMain = Identifier == LocalSetting.RootWindow;
            if (IsMain)
            {
                OpenHomePage();
                OpenFullScreenWindow();
            }
        }

        private void _wSocketClient_MessageReceived(WSMessageType type, string message)
        {
            if (type == WSMessageType.PushType)
            {

            }
        }

        private void BuildMenu(List<Base_ActionTree> base_Actions)
        {
            var nodes = base_Actions.Where(p => string.IsNullOrEmpty(p.ParentId));
            foreach (var node in nodes)
            {
                AMenuItem aMenuItem = new AMenuItem() { Glyph = node.Icon, Label = node.Text, Code = node.Url, Type = node.Type, ParentId = node.ParentId, Id = node.Id };
                MenuItems.Add(aMenuItem);
                SubBuildMenu(aMenuItem, node, aMenuItem.Id);
            }
        }

        private void SubBuildMenu(AMenuItem menuItem, Base_ActionTree parent, string parentid)
        {
            if (parent.Children != null)
            {
                foreach (var node in parent.Children)
                {
                    AMenuItem aMenuItem = new AMenuItem() { Glyph = node.Icon, Label = node.Text, Code = node.Url, Type = node.Type, ParentId = node.ParentId, Id = node.Id };
                    menuItem.AddChildren(aMenuItem);
                    SubBuildMenu(aMenuItem, node, aMenuItem.Id);
                }
            }
        }

        private List<AMenuItem> AddTotalMenu(IEnumerable<AMenuItem> items)
        {
            List<AMenuItem> list = new List<AMenuItem>();
            foreach (var item in items)
            {
                if (item.Type == 1)
                {
                    list.Add(item);
                }
                if (item.Children != null)
                {
                    list.AddRange(AddTotalMenu(item.Children.OfType<AMenuItem>()));
                }
            }
            return list;
        }

        #region 属性与方法
        private bool _isMain;
        public bool IsMain
        {
            get { return _isMain; }
            set
            {
                SetProperty(ref _isMain, value);
            }
        }


        private WindowSetting _windowSetting = new WindowSetting();
        public WindowSetting WindowSetting
        {
            get { return _windowSetting; }
            set
            {
                SetProperty(ref _windowSetting, value);
            }
        }


        private Operator __operator;
        public Operator Operator
        {
            get { return __operator; }
            set
            {
                SetProperty(ref __operator, value);
            }
        }

        private WSocketClient __wSocketClient;
        public WSocketClient WSocketClient
        {
            get { return __wSocketClient; }
            set
            {
                SetProperty(ref __wSocketClient, value);
            }
        }

        private string _searchText;
        public string SearchText
        {
            get { return _searchText; }
            set
            {
                SetProperty(ref _searchText, value);
            }
        }

        private bool _isFocusSearchText;
        public bool IsFocusSearchText
        {
            get { return _isFocusSearchText; }
            set
            {
                SetProperty(ref _isFocusSearchText, value);
            }
        }


        private ObservableCollection<AMenuItem> _searchMenus = new ObservableCollection<AMenuItem>();
        public ObservableCollection<AMenuItem> SearchMenus
        {
            get { return _searchMenus; }
            set
            {
                SetProperty(ref _searchMenus, value);
            }
        }


        private ObservableCollection<AMenuItem> _menuItems = new ObservableCollection<AMenuItem>();
        public ObservableCollection<AMenuItem> MenuItems
        {
            get { return _menuItems; }
            set
            {
                SetProperty(ref _menuItems, value);
            }
        }

        private AMenuItem _selectedMenuItem;
        public AMenuItem SelectedMenuItem
        {
            get { return _selectedMenuItem; }
            set
            {
                SetProperty(ref _selectedMenuItem, value);
                SelectedMenuItemChanged(value);
            }
        }

        private ObservableCollection<AToolItem> _toolItems = new ObservableCollection<AToolItem>();
        public ObservableCollection<AToolItem> ToolItems
        {
            get { return _toolItems; }
            set
            {
                SetProperty(ref _toolItems, value);
            }
        }

        private string _regionName;
        public string RegionName
        {
            get { return _regionName; }
            set
            {
                SetProperty(ref _regionName, value);
            }
        }

        private string _pageTitle = LocalSetting.Title;
        public string PageTitle
        {
            get { return _pageTitle; }
            set
            {
                SetProperty(ref _pageTitle, value);
            }
        }

        private string _noticeText = "欢迎来到AIStudio...";
        public string NoticeText
        {
            get { return _noticeText; }
            set
            {
                SetProperty(ref _noticeText, value);
            }
        }


        private string _identifier = LocalSetting.RootWindow;
        public string Identifier
        {
            get { return _identifier; }
            set
            {
                SetProperty(ref _identifier, value);
            }
        }

        private ICommand _systemManageCommand;
        public ICommand SystemManageCommand
        {
            get
            {
                return this._systemManageCommand ?? (this._systemManageCommand = new DelegateCommand<string>(para => this.SystemManage(para)));
            }
        }

        private ICommand _userDropCommand;
        public ICommand UserDropCommand
        {
            get
            {
                return this._userDropCommand ?? (this._userDropCommand = new DelegateCommand<string>(para => this.UserDrop(para)));
            }
        }

        private ICommand _searchCommand;
        public ICommand SearchCommand
        {
            get
            {
                return this._searchCommand ?? (this._searchCommand = new DelegateCommand<AMenuItem>(para => this.Search(para)));
            }
        }


        private ICommand _toolBarConfigCommand;
        public ICommand ToolBarConfigCommand
        {
            get
            {
                return this._toolBarConfigCommand ?? (this._toolBarConfigCommand = new DelegateCommand(() => this.ToolBarConfig()));
            }
        }

        private ICommand _openUserConsoleCommand;
        public ICommand OpenUserConsoleCommand
        {
            get
            {
                return this._openUserConsoleCommand ?? (this._openUserConsoleCommand = new DelegateCommand(() => this.OpenUserConsole()));
            }
        }
        #endregion

        private void SettingChanged(string key)
        {
            Type type = WindowSetting.GetType();//获得类型  
            if (WindowSetting.ContainsProperty(key))
            {
                var data = typeof(LocalSetting).GetProperty(key)?.GetValue(typeof(LocalSetting));
                type.GetProperty(key).SetValue(WindowSetting, data);
            }
        }
        private void SystemManage(string para)
        {
            switch (para)
            {
                case "Setting":
                    {
                        if (flyout == null)
                        {
                            flyout = new SystemSetView();
                            flyout.ClosingFinished += Flyout_ClosingFinished;
                            // when the flyout is closed, remove it from the hosting FlyoutsControl
                            WindowBase.ShowFlyout(flyout, Identifier);
                        }
                        break;
                    }
                case "Logs":
                    {
                        string dir = System.AppDomain.CurrentDomain.BaseDirectory + "Logs";
                        System.Diagnostics.Process.Start("explorer.exe", Path.GetFullPath(dir));
                        break;
                    }
            }
        }

        SystemSetView flyout;
        private void Flyout_ClosingFinished(object sender, RoutedEventArgs e)
        {
            flyout = null;
        }

        private void UserDrop(string para)
        {
            switch (para)
            {
                case "Logout":
                    {
                        var win = WindowBase.GetWindowBase(Identifier);
                        if (win != null)
                        {
                            win.Close();
                        }
                        break;
                    }
            }
        }

        private void KeyExcute(string key)
        {
            switch (key)
            {
                case "F10":
                    {
                        ComeCapture.MainWindow window = new ComeCapture.MainWindow();
                        //直接显示截图
                        //window.Closed += (sender, args) =>
                        //{
                        //    var image = Clipboard.GetImage();
                        //    Util.Controls.Windows.ImageBrowser imageBrowser = new Util.Controls.Windows.ImageBrowser(image);
                        //    imageBrowser.Show();
                        //};
                        window.Show();
                        break;
                    }
                case "F11":
                    {
                        WindowBase.SetWindowStatus("ToggleFullScreen", Identifier);
                        break;
                    }
                case "Esc":
                    {
                        UserDrop("Logout");
                        break;
                    }
                case "Ctrl+Q":
                    {
                        IsFocusSearchText = false;
                        IsFocusSearchText = true;
                        break;
                    }
            }
        }

        void SelectedMenuItemChanged(AMenuItem item)
        {
            if (item == null || string.IsNullOrEmpty(item.Code))
            {
                return;
            }

            string parentcode = string.Empty;
            if (item.Parent != null)
            {
                parentcode = item.Parent.Code;
            }
            else if (item is AToolItem)
            {
                parentcode = (item as AToolItem).ParentCode;
                if (!SearchMenus.Any(p => p.Code == item.Code))
                {
                    MessageBoxHelper.ShowHit("您没有该菜单的权限", Identifier);
                    return;
                }
            }

            if (string.IsNullOrEmpty(item.Label))//有的界面程序内部用Code传过来的。
            {
                item.Label = SearchMenus.FirstOrDefault(p => p.Code == item.Code)?.Label;
            }

            if (parentcode == "WinStatus")
            {
                item.IsChecked = WindowBase.SetWindowStatus(item.Code, Identifier);
                return;
            }
            else if (parentcode == "Tool")
            {
                if (item.Code == "Screenshot")
                {
                    KeyExcute("F10");
                }
                else if (item.Code == "NewWindow")
                {
                    var otherwindow = new OtherMainWindow();
                    otherwindow.Show();
                    //_regionManager.RegisterViewWithRegion(otherwindow.RegionName, typeof(MainView));

                    NavigationParameters paras = new NavigationParameters();
                    paras.Add("Identifier", otherwindow.Identifier);
                    _regionManager.RequestNavigate(otherwindow.RegionName, "MainView", paras);
                }
                return;
            }

            if (item.Type == 1)
            {
                NavigationParameters paras = new NavigationParameters();
                paras.Add("Title", item.Label);
                paras.Add("Identifier", Identifier);
                _regionManager.RequestNavigate(RegionName, item.WpfCode, NavigationComplete, paras);
            }
        }

        private void NavigationComplete(NavigationResult result)
        {
            if (result.Result == false)
            {
                WindowBase.ShowMessageQueue($"{result.Context.Uri.ToString()}打开失败", Identifier);
            }
        }

        private void SelectedDocumentEventReceived(string title)
        {
            if (string.IsNullOrEmpty(title))
            {
                PageTitle = LocalSetting.Title;
            }
            else
            {
                PageTitle = title + " - " + LocalSetting.Title;
            }
        }

        private void Search(AMenuItem item)
        {
            if (item == null)
            {
                item = SearchMenus.FirstOrDefault();
            }
            SelectedMenuItemChanged(item);
            SearchText = null;
        }


        private async void ToolBarConfig()
        {
            var dialog = new ToolBarSetView();
            var viewmodel = new ToolBarSetViewModel(MenuItems, _mapper.Map<List<AToolItem>>(ToolItems), Identifier);
            dialog.DataContext = viewmodel;

            var res = (BaseDialogResult)await WindowBase.ShowDialogAsync(dialog, Identifier);
            if (res == BaseDialogResult.OK)
            {
                var config = LocalSetting.GetWriteSection("usersetting", new UserSettingSection());
                var section = config.Sections["usersetting"] as UserSettingSection;

                ToolItemCollection toolItems = new ToolItemCollection();
                toolItems.AddRange(viewmodel.ToolItems.ChangeType<List<ToolItemElement>>());
                if (section.WindowItems[Identifier] == null)
                {
                    section.WindowItems.Add(new WindowItemElement() { Name = Identifier });
                }
                section.WindowItems[Identifier].ToolItems = toolItems;

                LocalSetting.SaveSection(config);

                ToolItems = viewmodel.ToolItems;

            }
        }



    }
}
