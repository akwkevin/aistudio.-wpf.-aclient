using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Accelerider.Extensions.Mvvm;
using Prism.Commands;
using Prism.Regions;

namespace AIStudio.Wpf.PrismAvalonExtensions.ViewModels
{
    public abstract class NavigationDockWindowViewModel : DockWindowViewModel, INavigationAware, IViewLoadedAndUnloadedAwareAsync
    {

        public NavigationDockWindowViewModel() : base()
        {
            CloseCommand = new DelegateCommand<object>(OnExecuteCloseCommand);
        }

        private void OnExecuteCloseCommand(object tabItem)
        {
            this.Dispose();
        }

        public DelegateCommand<object> CloseCommand
        {
            get;
        }


        #region MaxTabItemNumber
        public int MaxTabItemNumber { get; set; } = 1;

        private static Dictionary<string, List<object>> _navigationInfo = new Dictionary<string, List<object>>();
        #endregion
        public virtual void OnNavigatedTo(NavigationContext navigationContext)
        {

        }

        public virtual bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public virtual void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }

        public override void Dispose()
        {
            base.Dispose();
        }


        public virtual Task OnLoaded(object sender, RoutedEventArgs e)
        {
            return Task.CompletedTask;
        }

        public virtual Task OnUnloaded(object sender, RoutedEventArgs e)
        {
            return Task.CompletedTask;
        }
    }
}
