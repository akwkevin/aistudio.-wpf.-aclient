using AIStudio.Core;
using AIStudio.Core.Models;
using AIStudio.Wpf.BasePage.ViewModels;
using AIStudio.Wpf.BasePage.Views;
using AIStudio.Wpf.Business;
using AIStudio.Wpf.LayoutPage.Models;
using AIStudio.Wpf.LayoutPage.Views;
using AIStudio.LocalConfiguration;
using Dataforge.PrismAvalonExtensions.ViewModels;
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

namespace AIStudio.Wpf.LayoutPage.ViewModels
{
    class _3DShowcaseViewModel : BasePageViewModel
    {
        private IUserConfig _userConfig { get; }
        private IOperator _operator { get; }

        public _3DShowcaseViewModel(IUserConfig userConfig, IOperator __operator)
        {
            _userConfig = userConfig;
            _operator = __operator;

            User3DData = new User3DData();

            MenuItems = _operator.MenuItems;
            SearchMenus = _operator.SearchMenus;
        }


        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            base.OnNavigatedTo(navigationContext);

            try
            {
                ShowWait();
                User3DData = _userConfig.ReadConfig<User3DData>(this, Identifier);
                for (int i = 0; i < User3DData.Data.Count; i++)
                {
                    var item = User3DData.Data[i];
                    Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        if (item.Content == null)
                        {
                            item.Content = InitControl(item.WpfCode);
                        }
                    }));
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

        private User3DData _user3DData;
        public User3DData User3DData
        {
            get { return _user3DData; }
            set
            {
                SetProperty(ref _user3DData, value);
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

        //private ICommand _openCommand;
        //public ICommand OpenCommand
        //{
        //    get
        //    {
        //        return this._openCommand ?? (this._openCommand = new DelegateCommand<object>(para => this.Open(para)));
        //    }
        //}

        //private ICommand _closeCommand;
        //public ICommand CloseCommand
        //{
        //    get
        //    {
        //        return this._closeCommand ?? (this._closeCommand = new DelegateCommand(() => this.Close()));
        //    }
        //}      

        private async void Edit()
        {
            var dialog = new _3DShowcaseEditView();
            var viewmodel = new _3DShowcaseEditViewModel(MenuItems, User3DData.Data, Identifier);
            dialog.DataContext = viewmodel;

            var res = (BaseDialogResult)await WindowBase.ShowDialogAsync(dialog, Identifier);
            if (res == BaseDialogResult.OK)
            {
                List<_3DItemData> list = new List<_3DItemData>();
                for (int i = 0; i < viewmodel._3DItems.Count; i++)
                {
                    var item = viewmodel._3DItems[i];
                    Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        if (item.Content == null)
                        {
                            item.Content = InitControl(item.WpfCode);
                        }
                    }));
                    list.Add(item);
                }

                User3DData.Data = new ObservableCollection<_3DItemData>(list);
            }
        }

        public Control InitControl(string fullname)
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
            _userConfig.WriteConfig(this, User3DData, Identifier);
        }

        //如果想弹窗实现。
        //AIStudio.Wpf.Controls.PopupWindow window;
        //private void Open(object para)
        //{
        //    if (window != null)
        //    {
        //        return;
        //    }
        //    WallControl.ItemclickEventArg arg = para as WallControl.ItemclickEventArg;
        //    if (arg != null && arg.Data is _3DItemData item)
        //    {
        //        var control = InitControl(item.WpfCode);
        //        control.Width = 500;
        //        control.Height = 300;
        //        window = new AIStudio.Wpf.Controls.PopupWindow
        //        {
        //            Owner = WindowBase.GetWindowBase(Identifier),
        //            PopupElement = control,
        //            WindowStartupLocation = WindowStartupLocation.CenterOwner,
        //            AllowsTransparency = true,
        //            WindowStyle = WindowStyle.None,
        //            Title = item.Label,
        //            PopupAnimation = AIStudio.Wpf.Controls.CustomizePopupAnimation.Rotate
        //        };
        //        window.Show();
        //    }
        //}

        //private void Close()
        //{
        //    if (window != null)
        //    {
        //        window.Close();
        //        window = null;
        //    }
        //}

    }


}
