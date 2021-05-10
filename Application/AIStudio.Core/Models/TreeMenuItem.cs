using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace AIStudio.Core.Models
{
    /// <summary>
    /// The HamburgerTreeMenuItem provides an abstract implementation for HamburgerMenu entries.
    /// </summary> 
    public class TreeMenuItem : INotifyPropertyChanged
    {
        private string glyph;
        public string Glyph
        {
            get { return glyph; }
            set
            {
                if (value == glyph) return;
                glyph = value;
                OnPropertyChanged("Glyph");
            }
        }

        private string label;
        [Browsable(true)]
        public string Label
        {
            get { return label; }
            set
            {
                if (value == label) return;
                label = value;
                OnPropertyChanged("Label");
            }
        }


        private Type targetPageType;

        public Type TargetPageType
        {
            get { return targetPageType; }
            set
            {
                if (value == targetPageType) return;
                targetPageType = value;
                OnPropertyChanged("TargetPageType");
            }
        }

        private object tag;

        public object Tag
        {
            get { return tag; }
            set
            {
                if (value == tag) return;
                tag = value;
                OnPropertyChanged("Tag");
            }
        }

        private ICommand command;
        public ICommand Command
        {
            get { return command; }
            set
            {
                if (value == command) return;
                command = value;
                OnPropertyChanged("Command");
            }
        }

        private ObservableCollection<TreeMenuItem> children = new ObservableCollection<TreeMenuItem>();

        public ObservableCollection<TreeMenuItem> Children
        {
            get { return children; }
            set
            {
                if (value == children) return;
                children = value;
                OnPropertyChanged("Children");
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
