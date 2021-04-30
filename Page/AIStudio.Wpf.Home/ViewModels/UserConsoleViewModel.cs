using AIStudio.Core;
using AIStudio.Wpf.BasePage.Models;
using AIStudio.Wpf.Home.Views;
using Dataforge.PrismAvalonExtensions.ViewModels;
using Prism.Commands;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Util.Controls;

namespace AIStudio.Wpf.Home.ViewModels
{
    class UserConsoleViewModel : NavigationDockWindowViewModel
    {     
        public IRegionManager _regionManager { get; set; }//这个很重要，与View进行绑定，不然RequestNavigate不好使     

        public UserConsoleViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            base.OnNavigatedTo(navigationContext);

            var identifier = navigationContext.Parameters["Identifier"] as string;
            if (!string.IsNullOrEmpty(identifier))
            {
                Identifier = identifier;
            }

            MenuItems = navigationContext.Parameters["MenuItems"] as ObservableCollection<AMenuItem>;
        }

        protected string Identifier { get; set; } = LocalSetting.RootWindow;

        private ObservableCollection<AMenuItem> _menuItems;
        public ObservableCollection<AMenuItem> MenuItems
        {
            get { return _menuItems; }
            set
            {
                SetProperty(ref _menuItems, value);
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

        private async void Edit()
        {
            var dialog = new UserConsoleEditView();
            var viewmodel = new UserConsoleEditViewModel(MenuItems, Identifier, dialog);
            dialog.DataContext = viewmodel;
            var res = (BaseDialogResult)await WindowBase.ShowDialogAsync(dialog, Identifier);
            if (res == BaseDialogResult.OK)
            {
                _regionManager.RequestNavigate("UserContentRegion", viewmodel.SelectedMenuItem.WpfCode);
            }
        }

    }
}
