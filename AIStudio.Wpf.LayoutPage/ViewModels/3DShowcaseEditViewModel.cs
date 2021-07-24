using AIStudio.Core;
using AIStudio.Core.Models;
using AIStudio.Wpf.BasePage.Models;
using AutoMapper;
using Prism.Commands;
using Prism.Ioc;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Util.Controls;

namespace AIStudio.Wpf.LayoutPage.ViewModels
{
    class _3DShowcaseEditViewModel : Prism.Mvvm.BindableBase
    {
        private static IMapper _mapper { get => ContainerLocator.Current.Resolve<IMapper>(); }
        public _3DShowcaseEditViewModel(IEnumerable<AMenuItem> menuItems, IEnumerable<_3DItemData> aToolItems, string identifier)
        {
            Identifier = identifier;
            MenuItems = new ObservableCollection<AMenuItem>(menuItems);
            _3DItems = new ObservableCollection<_3DItemData>(aToolItems);
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

        private ObservableCollection<_3DItemData> _3dItems;
        public ObservableCollection<_3DItemData> _3DItems
        {
            get { return _3dItems; }
            set
            {
                SetProperty(ref _3dItems, value);
            }
        }

        protected string Identifier { get; set; } = LocalSetting.RootWindow;

        private ICommand _doubleClickAddDataCommand;
        public ICommand DoubleClickAddDataCommand
        {
            get
            {
                return this._doubleClickAddDataCommand ?? (this._doubleClickAddDataCommand = new DelegateCommand<object>(para => this.DoubleClickAddData(para)));
            }
        }

        private ICommand _deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                return this._deleteCommand ?? (this._deleteCommand = new DelegateCommand<object>(para => this.Delete(para)));
            }
        }

        private void DoubleClickAddData(object para)
        {
            AMenuItem aMenuItem = para as AMenuItem;
            if (aMenuItem != null && aMenuItem.Type == 1)
            {
                if (_3DItems.Any(p => p.Code == aMenuItem.Code))
                {
                    WindowBase.ShowMessageQueue($"不能重复添加菜单-{aMenuItem.Label}", Identifier);
                }
                else
                {
                    var item = _mapper.Map<_3DItemData>(aMenuItem);
                    _3DItems.Add(item);
                }
            }
        }

        private void Delete(object para)
        {
            _3DItemData aToolItem = para as _3DItemData;
            if (aToolItem != null)
            {
                _3DItems.Remove(aToolItem);
            }
        }

    }
}
