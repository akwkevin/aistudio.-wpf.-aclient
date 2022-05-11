using System;
using System.Windows.Threading;
using Prism.Events;
using Prism.Mvvm;
using Unity;

namespace Accelerider.Extensions.Mvvm
{
    public abstract class ViewModelBase : BindableBase
    {
       

        protected ViewModelBase(IUnityContainer container)
        {
            Container = container;
            EventAggregator = container.Resolve<IEventAggregator>();
        }

        public Dispatcher Dispatcher { get; set; }

        protected IUnityContainer Container { get; }

        protected IEventAggregator EventAggregator { get; }

        // ReSharper disable once InconsistentNaming
        protected virtual void InvokeOnUIThread(Action action) => Dispatcher.Invoke(action);
    }
}
