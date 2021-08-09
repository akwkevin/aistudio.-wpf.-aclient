using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DragablzPrism.Interfaces;
using Microsoft.Practices.Prism.Mvvm;

namespace DragablzPrism.ViewModels
{
    public class BaseViewModel : BindableBase, ICommonData
    {
        private string title;

        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged("Title");
            }
        }
    }
}
