using System.Collections.Generic;
using System.Linq;
using Prism.Commands;
using Prism.Regions;

namespace AIStudio.Wpf.PrismAvalonExtensions.ViewModels
{
    public abstract class NavigationDockWindowViewModel : DockWindowViewModel, INavigationAware
    {

        public NavigationDockWindowViewModel() : base()
        {
            CloseCommand = new DelegateCommand<object>(OnExecuteCloseCommand);
        }

        private void OnExecuteCloseCommand(object tabItem)
        {
            _regionManager.Regions[_regionName].Remove(tabItem);
            this.Dispose();
        }

        public DelegateCommand<object> CloseCommand
        {
            get;
        }


        #region MaxTabItemNumber
        public int MaxTabItemNumber { get; set; } = 1;

        private string _key;
        private string _regionName;
        private IRegionManager _regionManager;

        private static Dictionary<string, List<object>> _navigationInfo = new Dictionary<string, List<object>>();
        #endregion
        public virtual void OnNavigatedTo(NavigationContext navigationContext)
        {
            var key = navigationContext.NavigationService.Region.Name + "_" + navigationContext.NavigationService.Journal.CurrentEntry.Uri.ToString();
            if (!_navigationInfo.ContainsKey(key))
            {
                _navigationInfo[key] = new List<object>() { };
            }

            var list = _navigationInfo[key];
            if (list.Count < MaxTabItemNumber)
            {
                if (!list.Contains(this))
                {
                    _navigationInfo[key].Add(this);
                }
            }

            _key = key;
            _regionName = navigationContext.NavigationService.Region.Name;
            _regionManager = navigationContext.NavigationService.Region.RegionManager;
        }

        public virtual bool IsNavigationTarget(NavigationContext navigationContext)
        {
            var key = navigationContext.NavigationService.Region.Name + "_" + navigationContext.NavigationService.Journal.CurrentEntry.Uri.ToString();
            var list = _navigationInfo[key];
            if (list.Count < MaxTabItemNumber)
            {
                return false;
            }
            else
            {
                if (this == _navigationInfo[key].FirstOrDefault())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public virtual void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }

        public override void Dispose()
        {
            _navigationInfo[_key].Remove(this);
            base.Dispose();
        }
    }
}
