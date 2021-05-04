using AIStudio.Core;
using AIStudio.Wpf.BasePage.Models;
using AIStudio.Wpf.Home.Views;
using AIStudio.Wpf.LocalConfiguration;
using Dataforge.PrismAvalonExtensions.ViewModels;
using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Util.Controls;
using Util.Panels;
using Util.Panels.Controls;
using Newtonsoft.Json;

namespace AIStudio.Wpf.Home.ViewModels
{
    class UserConsoleViewModel : NavigationDockWindowViewModel
    {   
        private IUserConfig _userConfig { get; }

        public UserConsoleViewModel(IUserConfig userConfig)
        {
            _userConfig = userConfig;
            UserConsoleData = new UserConsoleData();
            PanelTypes = new List<PanelType>()
            {
                Util.Panels.PanelType.TilePanel,
                Util.Panels.PanelType.MaximizedTile
            };          
        }

        public override async void OnNavigatedTo(NavigationContext navigationContext)
        {
            base.OnNavigatedTo(navigationContext);

            var identifier = navigationContext.Parameters["Identifier"] as string;
            if (!string.IsNullOrEmpty(identifier))
            {
                Identifier = identifier;
            }

            MenuItems = navigationContext.Parameters["MenuItems"] as ObservableCollection<AMenuItem>;
            SearchMenus = navigationContext.Parameters["SearchMenus"] as ObservableCollection<AMenuItem>;

            await System.Threading.Tasks.Task.Delay(1000);
            UserConsoleData = _userConfig.ReadConfig<UserConsoleData>(this);
            
            foreach (var item in UserConsoleData.Data)
            {
                var control = InitControl(item.Type);
                item.Content = control;
            }
        }

        protected string Identifier { get; set; } = LocalSetting.RootWindow;
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
            var res = (BaseDialogResult)await WindowBase.ShowDialogAsync(dialog, Identifier);
            if (res == BaseDialogResult.OK)
            {
                var control = InitControl(viewmodel.SelectedMenuItem.WpfCode);
                if (control != null)
                {
                    UserConsoleData.Data.Add(new UserItemData() { Title = viewmodel.SelectedMenuItem.Label, Content = control, CanClose = true, Type = viewmodel.SelectedMenuItem.WpfCode });
                }
            }
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

            return null;
        }

        private void Save()
        {
            _userConfig.WriteConfig(this, UserConsoleData);
        }
    }

    public class UserItemData : MDIItemData
    {
        [JsonIgnore]
        public Control Content { get; set; }
        public string Type { get; set; }//序列化后重构控件使用
    }

    public class UserConsoleData : BindableBase
    {
        private PanelType _panelType = PanelType.TilePanel;
        public PanelType PanelType
        {
            get { return _panelType; }
            set
            {
                SetProperty(ref _panelType, value);
            }
        }

        private int _columnNum = 2;
        public int ColumnNum
        {
            get { return _columnNum; }
            set
            {
                SetProperty(ref _columnNum, value);
            }
        }

        private int rowNum = 2;
        public int RowNum
        {
            get { return rowNum; }
            set
            {
                SetProperty(ref rowNum, value);
            }
        }

        private ObservableCollection<UserItemData> _data = new ObservableCollection<UserItemData>();
        public ObservableCollection<UserItemData> Data
        {
            get { return _data; }
            set
            {
                SetProperty(ref _data, value);
            }
        }

 
    }
}
