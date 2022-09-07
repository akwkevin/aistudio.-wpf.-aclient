using AIStudio.Core;
using AIStudio.Core.Models;
using AIStudio.Wpf.BasePage.ViewModels;
using AIStudio.Wpf.BasePage.Views;
using AIStudio.Wpf.Business;
using AIStudio.Wpf.LayoutPage.Models;
using AIStudio.Wpf.LayoutPage.Views;
using AIStudio.LocalConfiguration;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using AIStudio.Wpf.Controls;
using Util.Panels;
using Util.Panels.Controls;
using Prism.Events;
using AIStudio.Wpf.BasePage.Events;
using AIStudio.Wpf.PrismAvalonExtensions.ViewModels;

namespace AIStudio.Wpf.LayoutPage.ViewModels
{
    class UserConsoleViewModel : BasePageViewModel
    {   
        private IUserConfig _userConfig { get; }
        private IOperator _operator { get; }
        private IEventAggregator _aggregator { get; }

        public UserConsoleViewModel(IUserConfig userConfig, IOperator __operator, IEventAggregator aggregator)
        {
            _userConfig = userConfig;
            _operator = __operator;
            _aggregator = aggregator;

            UserConsoleData = new UserConsoleData();
            PanelTypes = new List<PanelType>()
            {
                Util.Panels.PanelType.TilePanel,
                Util.Panels.PanelType.MaximizedTilePanel
            };

            MenuItems = _operator.MenuItems;
            SearchMenus = _operator.SearchMenus;
        }

        public override async void OnNavigatedTo(NavigationContext navigationContext)
        {
            base.OnNavigatedTo(navigationContext);

            try
            {
                ShowWait();
                await System.Threading.Tasks.Task.Delay(500);//偷下懒，延迟等待界面Loaded，再初始化布局
                UserConsoleData = _userConfig.ReadConfig<UserConsoleData>(this, Identifier);
                foreach (var item in UserConsoleData.Data)
                {
                    var control = InitControl(item.Type);
                    item.Content = control;
                }
            }
            finally
            {
                HideWait();
            }
        }

        private ObservableCollection<AMenuItem> SearchMenus { get; set; }

        private ObservableCollection<AMenuItem> _menuItems;
        public ObservableCollection<AMenuItem> MenuItems
        {
            get { return _menuItems; }
            set
            {
                SetProperty(ref _menuItems, value);
            }
        }

        public List<PanelType> PanelTypes { get; set; }

        private UserConsoleData _userConsoleData;
        public UserConsoleData UserConsoleData
        {
            get { return _userConsoleData; }
            set
            {
                SetProperty(ref _userConsoleData, value);
            }
        }

        private ICommand _editCommand;
        public ICommand EditCommand
        {
            get
            {
                return this._editCommand ?? (this._editCommand = new DelegateCommand(() => this.Edit()));
            }
        }

        private ICommand _saveCommand;
        public ICommand SaveCommand
        {
            get
            {
                return this._saveCommand ?? (this._saveCommand = new DelegateCommand(() => this.Save()));
            }
        }

        private ICommand _openCommand;
        public ICommand OpenCommand
        {
            get
            {
                return this._openCommand ?? (this._openCommand = new DelegateCommand<UserItemData>(para => this.OpenInMain(para)));
            }
        }

        private ICommand _rectangleGridCommand;
        public ICommand RectangleGridCommand
        {
            get
            {
                return this._rectangleGridCommand ?? (this._rectangleGridCommand = new DelegateCommand<RoutedPropertyChangedEventArgs<RectangleGridEventArgs>>(obj => this.RectangleGrid(obj)));
            }
        }

        private void RectangleGrid(RoutedPropertyChangedEventArgs<RectangleGridEventArgs> obj)
        {
            UserConsoleData.RowNum = obj.NewValue.Row;
            UserConsoleData.ColumnNum = obj.NewValue.Column;
        }

        private async void Edit()
        {
            var dialog = new UserConsoleEditView();
            var viewmodel = new UserConsoleEditViewModel(MenuItems, Identifier, dialog);
            dialog.DataContext = viewmodel;
            var res = (BaseDialogResult)await WindowBase.ShowDialogAsync2(dialog, Identifier);
            if (res == BaseDialogResult.OK)
            {
                var control = InitControl(viewmodel.SelectedMenuItem.WpfCode);
                if (control != null)
                {
                    UserConsoleData.Data.Add(new UserItemData() { Title = viewmodel.SelectedMenuItem.Label, Content = control, CanClose = true, Type = viewmodel.SelectedMenuItem.WpfCode });
                }
            }
        }

        private void OpenInMain(UserItemData para)
        {
            _aggregator.GetEvent<MenuExcuteEvent>().Publish(new Tuple<string, string>(Identifier, para.Type));
        }

        private Control InitControl(string fullname)
        {
            if (!SearchMenus.Any(p => p.WpfCode == fullname))
            {
                PromptUserControl txt = new PromptUserControl("您没有该菜单的权限");
                return txt;
            }

            var assemblies = System.AppDomain.CurrentDomain.GetAssemblies().Where(p => p.FullName.StartsWith("AIStudio.Wpf")).ToList();

            foreach (var assembly in assemblies)
            {
                Type type = assembly.GetType(fullname);
                if (type != null)
                {
                    var control = Activator.CreateInstance(type) as UserControl;
                    ViewModelLocator.SetAutoWireViewModel(control, true);


                    if (control.DataContext is NavigationDockWindowViewModel)
                    {
                        NavigationContext context = new NavigationContext(null, null);
                        context.Parameters.Add("Identifier", Identifier);
                        (control.DataContext as NavigationDockWindowViewModel).OnNavigatedTo(context);
                    }


                    return control;
                }
            }

            return new PromptUserControl("该菜单没有实现");
        }

        private void Save()
        {
            _userConfig.WriteConfig(this, UserConsoleData, Identifier);
        }
    }


}
