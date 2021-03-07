using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Util.Controls;

namespace AIStudio.Wpf.BasePage.DTOModels
{
    public class OA_DefTypeTree : BaseTreeItemViewModel, INotifyPropertyChanged
    {
        public OA_DefTypeTree()
        {
            IsExpanded = false;
        }
        public string RealId { get; set; }
        public string Type { get; set; }
        public string Unit { get; set; }
        public object children { get; set; }

        private ObservableCollection<OA_DefTypeTree> _children;
        public new ObservableCollection<OA_DefTypeTree> Children
        {
            get
            {
                return _children;
            }
            set
            {
                _children = value;
                ClearChild();
                AddChildRange(_children ?? new ObservableCollection<OA_DefTypeTree>());
            }
        }
    }
}
