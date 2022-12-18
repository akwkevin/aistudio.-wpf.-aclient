using System.Collections.ObjectModel;
using System.ComponentModel;
using AIStudio.Core.Models;
using AIStudio.Wpf.Controls;

namespace AIStudio.Wpf.BasePage.DTOModels
{
    public class Base_DictionaryTree : BaseTreeItemViewModel, INotifyPropertyChanged, IIsChecked
    {
        public string Id { get; set; }

        public string ParentId { get; set; }

        public int Type { get; set; }

        public int Sort { get; set; }

        public string TypeText { get; set; }

        public string Text { get; set; }
        public string Value { get; set; }
        public string Code { get; set; }
        public Core.ControlType ControlType { get; set; }
        public string Remark { get; set; }

        public object children { get; set; }

        private ObservableCollection<Base_DictionaryTree> _children;
        public new ObservableCollection<Base_DictionaryTree> Children
        {
            get
            {
                return _children;
            }
            set
            {
                _children = value;
                ClearChild();
                AddChildRange(_children ?? new ObservableCollection<Base_DictionaryTree>());
            }
        }

        public string Error { get; set; }
    }
}
