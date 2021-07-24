using AIStudio.Core;
using AIStudio.Core.Models;
using Prism.Commands;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Util.Controls;

namespace AIStudio.Wpf.LayoutPage.ViewModels
{
    class UserConsoleEditViewModel : Prism.Mvvm.BindableBase
    {
        public UserConsoleEditViewModel(IEnumerable<AMenuItem> menuItems, string identifier, BaseDialog baseDialog)
        {
            Identifier = identifier;
            MenuItems = new ObservableCollection<AMenuItem>(menuItems);
            _baseDialog = baseDialog;
        }

        private ObservableCollection<AMenuItem> _menuItems;
        public ObservableCollection<AMenuItem> MenuItems
        {
            get { return _menuItems; }
            set
            {
                SetProperty(ref _menuItems, value);
            }
        }

        public AMenuItem SelectedMenuItem { get; private set; }

        protected string Identifier { get; set; } = LocalSetting.RootWindow;
        private BaseDialog _baseDialog;

        private ICommand _doubleClickAddDataCommand;
        public ICommand DoubleClickAddDataCommand
        {
            get
            {
                return this._doubleClickAddDataCommand ?? (this._doubleClickAddDataCommand = new DelegateCommand<object>(para => this.DoubleClickAddData(para)));
            }
        }     

        private void DoubleClickAddData(object para)
        {
            AMenuItem aMenuItem = para as AMenuItem;
            if (aMenuItem != null && aMenuItem.Type == 1)
            {
                //_baseDialog
                SelectedMenuItem = aMenuItem;
                _baseDialog.OKSource.Cancel();
            }
        }
       

    }
}
