using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System.Windows.Input;
using System.Windows.Media;

namespace Dataforge.PrismAvalonExtensions.ViewModels
{
    public abstract class NavigationDockWindowViewModel : DockWindowViewModel, INavigationAware
    {  
        public virtual void OnNavigatedTo(NavigationContext navigationContext)
        {
          
        }

        public virtual bool IsNavigationTarget(NavigationContext navigationContext)
        {          
            if (TabItemNumber < MaxTabItemNumber)
            {
                TabItemNumber++;
                return false;
            }
            else
            {             
                return true;
            }      
        }

        public virtual void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }
    }
}
