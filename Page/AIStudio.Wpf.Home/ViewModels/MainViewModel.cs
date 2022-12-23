using Accelerider.Extensions.Mvvm;
using AIStudio.Core;
using AIStudio.Core.Models;
using AIStudio.Wpf.BasePage.DTOModels;
using AIStudio.Wpf.BasePage.Events;
using AIStudio.Wpf.BasePage.Models;
using AIStudio.Wpf.Business;
using AIStudio.Wpf.Controls;
using AIStudio.Wpf.Entity.DTOModels;
using AIStudio.Wpf.Home.Models;
using AIStudio.Wpf.Home.Views;
using AutoMapper;
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
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace AIStudio.Wpf.Home.ViewModels
{
    public class MainViewModel : Prism.Mvvm.BindableBase, INavigationAware, IViewLoadedAndUnloadedAwareAsync
    {
        protected IContainerExtension _container { get; }
        public IRegionManager _regionManager { get; set; }//这个很重要，与View进行绑定，不然RequestNavigate不好使
        protected IEventAggregator _aggregator { get; }
        protected IOperator _operator { get; }
        protected IDataProvider _dataProvider { get; }
        protected IMapper _mapper { get; }
        protected IUserData _userData { get; }

        protected WindowBase _window { get; set; }

        public NoticeIconViewModel NoticeIconViewModel { get; set; }

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

        private ObservableCollection<AMenuItem> _optionItems = new ObservableCollection<AMenuItem>();
        public ObservableCollection<AMenuItem> OptionItems
        {
            get { return _optionItems; }
            set
            {
                SetProperty(ref _optionItems, value);
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

        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                SetProperty(ref _title, value);
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

        //写个注释，Identifier这个是为多屏做的，用于识别不同的窗体
        private string _identifier = LocalSetting.RootWindow;
        public string Identifier
        {
            get { return _identifier; }
            set
            {
                SetProperty(ref _identifier, value);
            }
        }

        private ICommand _menuExcuteCommand;
        public ICommand MenuExcuteCommand
        {
            get
            {
                return this._menuExcuteCommand ?? (this._menuExcuteCommand = new DelegateCommand<AMenuItem>(para => this.SelectedMenuItemChanged(para)));
            }
        }

        private ICommand _keyExcuteCommand;
        public ICommand KeyExcuteCommand
        {
            get
            {
                return this._keyExcuteCommand ?? (this._keyExcuteCommand = new DelegateCommand<string>(para => this.KeyExcute(para)));
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

        public MainViewModel(IContainerExtension container, IRegionManager regionManager, IEventAggregator aggregator, IOperator ioperator, IDataProvider dataProvider, IMapper mapper, IUserData userData)
        {
            _container = container;
            _regionManager = regionManager;
            _aggregator = aggregator;
            _operator = ioperator;
            _dataProvider = dataProvider;
            _mapper = mapper;
            _userData = userData;

            LocalSetting.SettingChanged += SettingChanged;

            _aggregator.GetEvent<MenuExcuteEvent>().Subscribe(MenuExcuteEventReceived, (ev) => { return ev.Item1 == Identifier; });
        }

        public async Task OnLoaded(object sender, RoutedEventArgs e)
        {
            if (_window == null)
            {
                await InitData();
                InitOption();

                _window = WindowBase.GetWindowBase(Identifier);
            }

            _window.PreviewKeyDown -= View_PreviewKeyDown;
            _window.PreviewKeyDown += View_PreviewKeyDown;

            IsMain = Identifier == LocalSetting.RootWindow;
            if (!string.IsNullOrEmpty(Title))
            {
                OpenPage(Title);
            }
            else
            {
                OpenHomePage();
            }

            if (IsMain)
            {
                OpenFullScreenWindow();
            }
        }

        public Task OnUnloaded(object sender, RoutedEventArgs e)
        {
            if (_window != null)
            {
                _window.PreviewKeyDown -= View_PreviewKeyDown;
            }
            return Task.CompletedTask;
        }

        private void View_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            KeyExcute(e.KeyboardDevice.Modifiers == ModifierKeys.None ? e.Key.ToString() : e.KeyboardDevice.Modifiers.ToString() + "+" + e.Key.ToString());
        }

        public virtual void OnNavigatedTo(NavigationContext navigationContext)
        {
            var identifier = navigationContext.Parameters["Identifier"] as string;
            if (!string.IsNullOrEmpty(identifier))
            {
                Identifier = identifier;
            }

            SetRegionName();
            NoticeIconViewModel = new NoticeIconViewModel(Identifier);

            Title = navigationContext.Parameters["Title"] as string;
        }

        protected virtual void SetRegionName()
        {
            RegionName = AIStudio.Core.RegionName.TabContentRegion + "_" + Identifier;
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
                paras.Add("Glyph", item.Icon);
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


        public async virtual Task InitData()
        {
            using (var waitfor = WaitFor.GetWaitFor(this.GetHashCode(), Identifier, "正在获取用户信息", WaitingStyle.Progress))
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

                #region 菜单
                MenuItems = new ObservableCollection<AMenuItem>();
                if (_operator.UserName != "LocalUser")
                {
                    try
                    {
                        var userinfo = await _dataProvider.GetData<Base_UserDTO>("/Base_Manage/Home/GetOperatorInfo");
                        if (!userinfo.Success)
                        {
                            throw new System.Exception(userinfo.Msg);
                        }

                        _operator.Property = userinfo.Data;
                        _operator.Avatar = userinfo.Data.Avatar;

                        waitfor.SetText("正在获取菜单信息");
                        var menuinfo = await _dataProvider.GetData<List<Base_ActionTree>>("/Base_Manage/Home/GetOperatorMenuList");
                        if (!menuinfo.Success)
                        {
                            throw new System.Exception(menuinfo.Msg);
                        }
                        BuildMenu(menuinfo.Data);

                        RefreshUserData();
                    }
                    catch (Exception ex)
                    {
                        Controls.MessageBox.Error(ex.Message);
                    }
                }

#if DEBUG
                AMenuItem code = new AMenuItem() { Icon = "code", Label = "开发", Code = "Demo", Type = 0 };
                MenuItems.Add(code);

                if (_operator.UserName != "LocalUser")
                {
                    code.AddChildren(new AMenuItem() { Label = "数据库连接", Code = "/Base_Manage/Base_DbLinkView/", Type = 1, Command = MenuExcuteCommand });
                    code.AddChildren(new AMenuItem() { Label = "代码生成", Code = "/Base_Manage/BuildCodeView/", Type = 1, Command = MenuExcuteCommand });
                    code.AddChildren(new AMenuItem() { Label = "Swagger", Code = "/Base_Manage/SwaggerView/", Type = 1, Command = MenuExcuteCommand });
                    code.AddChildren(new AMenuItem() { Label = "文件上传", Code = "/Base_Manage/UploadView/", Type = 1, Command = MenuExcuteCommand });
                    code.AddChildren(new AMenuItem() { Label = "表单Form", Code = "/Agile_Development/FormView/", Type = 1, Command = MenuExcuteCommand });
                    code.AddChildren(new AMenuItem() { Label = "表单-代码生成", Code = "/Agile_Development/FormCodeView/", Type = 1, Command = MenuExcuteCommand });
                    code.AddChildren(new AMenuItem() { Label = "crud-用户管理", Code = "/Agile_Development/Base_UserQueryView/", Type = 1, Command = MenuExcuteCommand });
                }
#endif
                var tool = new AMenuItem() { Icon = "tool", Label = "工具", Code = "Tool", Type = 0, Command = MenuExcuteCommand };
                var setting = new AMenuItem() { Icon = "setting", Label = "系统设置", Code = "Setting", Type = 1, Command = MenuExcuteCommand };
                var newWindow = new AMenuItem() { Icon = "windows", Label = (string)Application.Current.Resources["新增窗口"], Code = "NewWindow", Type = 1, Command = MenuExcuteCommand };
                var screenshot = new AMenuItem() { Icon = "screenshot", Label = (string)Application.Current.Resources["截屏"], Code = "Screenshot", Type = 1, Command = MenuExcuteCommand };

                tool.AddChildren(setting);
                tool.AddChildren(newWindow);
                tool.AddChildren(screenshot);
                MenuItems.Add(tool);

                var winStatus = new AMenuItem() { Icon = "windows", Label = (string)Application.Current.Resources["窗口"], Code = "WinStatus", Type = 0, Command = MenuExcuteCommand };
                var showTitleBar = new AMenuItem() { Label = (string)Application.Current.Resources["标题显示"], Code = "ShowTitleBar", Type = 1, IsChecked = WindowBase.GetWindowStatus("ShowTitleBar", Identifier), Command = MenuExcuteCommand };
                var showInTaskbar = new AMenuItem() { Label = (string)Application.Current.Resources["任务栏显示"], Code = "ShowInTaskbar", Type = 1, IsChecked = WindowBase.GetWindowStatus("ShowInTaskbar", Identifier), Command = MenuExcuteCommand };
                var topmost = new AMenuItem() { Label = (string)Application.Current.Resources["总在最前"], Code = "Topmost", Type = 1, IsChecked = WindowBase.GetWindowStatus("Topmost", Identifier), Command = MenuExcuteCommand };
                var toggleFullScreen = new AMenuItem() { Label = (string)Application.Current.Resources["最大化全屏"], Code = "ToggleFullScreen", Type = 1, IsChecked = WindowBase.GetWindowStatus("ToggleFullScreen", Identifier), Command = MenuExcuteCommand };
                var notifyIcon = new AMenuItem() { Label = (string)Application.Current.Resources["托盘显示"], Code = "ShowNotifyIcon", Type = 1, Command = MenuExcuteCommand };

                winStatus.AddChildren(showTitleBar);
                winStatus.AddChildren(showInTaskbar);
                winStatus.AddChildren(topmost);
                winStatus.AddChildren(toggleFullScreen);
                winStatus.AddChildren(notifyIcon);

                MenuItems.Add(winStatus);
                SearchMenus = new ObservableCollection<AMenuItem>(AddTotalMenu(MenuItems));

                _operator.MenuTrees = MenuItems;
                _operator.Menus = SearchMenus;
                _operator.Permissions = _operator.Menus.Where(p => p.PermissionValues != null).SelectMany(p => p.PermissionValues).ToList();
                #endregion
            }
        }

        private async void RefreshUserData()
        {
            using (var waitfor = WaitFor.GetWaitFor(this.GetHashCode(), Identifier, "正在刷新内存", WaitingStyle.Progress))
            {
                try
                {
                    await _userData.Init();
                }
                catch (Exception ex)
                {
                    Controls.MessageBox.Error(ex.Message);
                }
            }
        }

        public void InitOption()
        {
            OptionItems = new ObservableCollection<AMenuItem>();
            AMenuItem code = new AMenuItem() { Icon = "menu", Label = "设置", Code = "Option", Type = 0 };
            OptionItems.Add(code);

            code.AddChildren(new AMenuItem() { Icon = "profile", Label = "本地日志", Code = "Logs" });
            code.AddChildren(new AMenuItem() { Icon = "bug", Label = "问题反馈", Code = "FeetBack" });
            code.AddChildren(new AMenuItem() { Icon = "mail", Label = "技术支持", Code = "Support" });
            code.AddChildren(new AMenuItem() { Icon = "coffee", Label = "帮助", Code = "Helper" });
            code.AddChildren(new AMenuItem() { Icon = "star", Label = "关于", Code = "About" });
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
                AMenuItem aMenuItem = new AMenuItem() { Icon = node.Icon, Label = node.Text, Code = node.Url, Value = node.ValueInfo, Type = node.Type, ParentId = node.ParentId, Id = node.Id, NeedAction = node.NeedAction, PermissionValues = node.PermissionValues };
                if (aMenuItem.Type == 1)
                {
                    aMenuItem.Command = MenuExcuteCommand;
                }
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
                    AMenuItem aMenuItem = new AMenuItem() { Icon = node.Icon, Label = node.Text, Code = node.Url, Value = node.ValueInfo, Type = node.Type, ParentId = node.ParentId, Id = node.Id, NeedAction = node.NeedAction, PermissionValues = node.PermissionValues };
                    if (aMenuItem.Type == 1)
                    {
                        aMenuItem.Command = MenuExcuteCommand;
                    }
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

        private void SettingChanged(string key)
        {
            Type type = WindowSetting.GetType();//获得类型  
            if (WindowSetting.ContainsProperty(key))
            {
                var data = typeof(LocalSetting).GetProperty(key)?.GetValue(typeof(LocalSetting));
                type.GetProperty(key).SetValue(WindowSetting, data);
            }
        }

        SystemSetView flyout;
        private void Flyout_ClosingFinished(object sender, RoutedEventArgs e)
        {
            flyout = null;
        }

        public virtual void KeyExcute(string key)
        {
            switch (key)
            {
                //F10怎么是home
                case "System":
                    {
                        ComeCapture.MainWindow window = new ComeCapture.MainWindow();
                        //直接显示截图
                        //window.Closed += (sender, args) =>
                        //{
                        //    var image = Clipboard.GetImage();
                        //    AIStudio.Wpf.Controls.ImageBrowser imageBrowser = new AIStudio.Wpf.Controls.ImageBrowser(image);
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
                case "Escape":
                    {
                        var win = WindowBase.GetWindowBase(Identifier);
                        if (win != null)
                        {
                            if (win.IsOverlayVisible())
                            {
                                win.CloseDialog();
                            }
                            else
                            {
                                win.Close();
                            }
                        }
                        break;
                    }
                case "Control+Q":
                    {
                        IsFocusSearchText = false;
                        IsFocusSearchText = true;
                        break;
                    }
                #region 自定义Key
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
                case "Screenshot":
                    {
                        KeyExcute("System");
                        break;
                    }
                case "NewWindow":
                    {
                        var otherwindow = new OtherMainWindow();
                        otherwindow.Show();
                        //_regionManager.RegisterViewWithRegion(otherwindow.RegionName, typeof(MainView));

                        NavigationParameters paras = new NavigationParameters();
                        paras.Add("Identifier", otherwindow.Identifier);
                        _regionManager.RequestNavigate(otherwindow.RegionName, "MainView", paras);
                        break;
                    }
                case "FullScreen":
                case "EscapeFullScreen":
                    {
                        var window = WindowBase.GetWindowBase(Identifier);
                        string mainContentRegion;
                        if (Identifier == LocalSetting.RootWindow)
                        {
                            mainContentRegion = AIStudio.Core.RegionName.MainContentRegion;
                        }
                        else
                        {
                            mainContentRegion = window.GetPropertyValue(nameof(RegionName))?.ToString();
                        }

                        NavigationParameters paras = new NavigationParameters();
                        paras.Add("Identifier", Identifier);
                        paras.Add("Title", Title);

                        _regionManager.RequestNavigate(mainContentRegion, key == "FullScreen" ? "FullScreenView" : "MainView", paras);

                        if (key == "FullScreen")
                        {
                            WindowBase.SetWindowStatus("ShowTitleBar", Identifier, false);
                            WindowBase.SetWindowStatus("ToggleFullScreen", Identifier, true);
                        }
                        else
                        {
                            WindowBase.SetWindowStatus("ShowTitleBar", Identifier, true);
                            WindowBase.SetWindowStatus("ToggleFullScreen", Identifier, false);
                        }
                        break;
                    }
                case "Refresh":
                    {
                        RefreshUserData();
                        break;
                    }
                    #endregion
            }
        }

        private void MenuExcuteEventReceived(Tuple<string, string> tuple)
        {
            SelectedMenuItem = SearchMenus.FirstOrDefault(p => p.WpfCode == tuple.Item2);
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
                    Controls.MessageBox.Warning("您没有该菜单的权限", windowIdentifier: Identifier);
                    return;
                }
            }

            if (string.IsNullOrEmpty(item.Label))//有的界面程序内部用Code传过来的。
            {
                item.Label = SearchMenus.FirstOrDefault(p => p.Code == item.Code)?.Label;
            }

            if (parentcode == "WinStatus")
            {
                if (item.Code == "ShowNotifyIcon")
                {
                    WindowBase.SetWindowStatus(item.Code, Identifier);
                }
                else
                {
                    item.IsChecked = WindowBase.SetWindowStatus(item.Code, Identifier);
                }
                return;
            }
            else if (parentcode == "Tool" || parentcode == "Option")
            {
                KeyExcute(item.Code);
                return;
            }

            if (item.Type == 1)
            {
                NavigationParameters paras = new NavigationParameters();
                paras.Add("Title", item.Label);
                paras.Add("Glyph", item.Icon);
                paras.Add("Identifier", Identifier);
                paras.Add("Value", item.Value);
                _regionManager.RequestNavigate(RegionName, item.WpfCode, NavigationComplete, paras);
            }
        }

        private void NavigationComplete(NavigationResult result)
        {
            if (result.Result == false)
            {
                WindowBase.ShowMessageQueue($"{result.Context.Uri.ToString()}打开失败", Identifier);
            }
            else
            {
                Title = result.Context.Parameters["Title"] as string;
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

            var res = (DialogResult)await WindowBase.ShowChildWindowAsync(dialog, "编辑表单", Identifier);
            if (res == DialogResult.OK)
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
