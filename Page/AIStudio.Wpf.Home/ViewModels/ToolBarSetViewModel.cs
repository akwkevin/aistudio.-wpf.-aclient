using AIStudio.Core;
using AIStudio.Core.Models;
using AutoMapper;
using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Svg2XamlTestExtension;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using AIStudio.Wpf.Controls;

namespace AIStudio.Wpf.Home.ViewModels
{
    class ToolBarSetViewModel : Prism.Mvvm.BindableBase
    {
        private static IMapper _mapper { get => ContainerLocator.Current.Resolve<IMapper>(); }
        public ToolBarSetViewModel(IEnumerable<AMenuItem> menuItems, IEnumerable<AToolItem> aToolItems, string identifier)
        {
            Identifier = identifier;
            MenuItems = new ObservableCollection<AMenuItem>(menuItems);
            ToolItems = new ObservableCollection<AToolItem>(aToolItems);
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

        private ObservableCollection<AToolItem> _toolItems;
        public ObservableCollection<AToolItem> ToolItems
        {
            get { return _toolItems; }
            set
            {
                SetProperty(ref _toolItems, value);
            }
        }

        protected string Identifier { get; set; } = LocalSetting.RootWindow;

        public List<string> Glyphs { get; set; } = PackSvg.DataIndex.Value.Keys.Where(p => p.Item1 == "outline").Select(p => p.Item2).ToList();

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
                if (ToolItems.Any(p => p.Code == aMenuItem.Code))
                {
                    WindowBase.ShowMessageQueue($"不能重复添加菜单-{aMenuItem.Label}", Identifier);
                }
                else
                {
                    ToolItems.Add(_mapper.Map<AToolItem>(aMenuItem));
                }
            }
        }

        private void Delete(object para)
        {
            AToolItem aToolItem = para as AToolItem;
            if (aToolItem != null)
            {
                ToolItems.Remove(aToolItem);
            }
        }

    }
}
