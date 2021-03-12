using Dataforge.PrismAvalonExtensions.ViewModels;
using Prism.Regions;

namespace Dataforge.PrismAvalonExtensions.Test.ViewModels
{
    public class Test2ViewModel : NavigationDockWindowViewModel
    {

        private int _pageViews;
        public int PageViews
        {
            get { return _pageViews; }
            set { SetProperty(ref _pageViews, value); }
        }
        IRegionManager _regionManager;

        public Test2ViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            Title = "Test2";
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            base.OnNavigatedTo(navigationContext);
            PageViews++;
        }


    }
}
