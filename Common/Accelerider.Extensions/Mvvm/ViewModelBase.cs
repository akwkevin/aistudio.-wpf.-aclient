using System;
using System.Windows.Threading;
using Prism.Events;
using Prism.Mvvm;

namespace Accelerider.Extensions.Mvvm
{
    public abstract class ViewModelBase : BindableBase
    { 
        protected ViewModelBase()
        {
           
        }

        public Dispatcher Dispatcher { get; set; }

        // ReSharper disable once InconsistentNaming
        protected virtual void InvokeOnUIThread(Action action) => Dispatcher.Invoke(action);
    }
}
