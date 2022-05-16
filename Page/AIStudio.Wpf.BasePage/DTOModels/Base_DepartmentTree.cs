using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using AIStudio.Wpf.Controls;

namespace AIStudio.Wpf.BasePage.DTOModels
{
    public class Base_DepartmentTree : BaseTreeItemViewModel, INotifyPropertyChanged
    {
        public string Id { get; set; }

        public string Text { get; set; }
        public object children { get; set; }

        private ObservableCollection<Base_DepartmentTree> _children;
        public new ObservableCollection<Base_DepartmentTree> Children
        {
            get
            {
                return _children;
            }
            set
            {
                _children = value;
                ClearChild();
                AddChildRange(_children ?? new ObservableCollection<Base_DepartmentTree>());
            }
        }
    }
}
