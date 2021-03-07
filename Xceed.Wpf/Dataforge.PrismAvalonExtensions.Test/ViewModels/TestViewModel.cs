using Dataforge.PrismAvalonExtensions.ViewModels;
using Prism.Regions;

namespace Dataforge.PrismAvalonExtensions.Test.ViewModels
{
    public class TestViewModel : NavigationDockWindowViewModel
    {
        private int _pageViews;
        public int PageViews
        {
            get { return _pageViews; }
            set { SetProperty(ref _pageViews, value); }
        }

        public TestViewModel()
        {
            Title = "Test";
            MaxTabItemNumber = 3;
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            base.OnNavigatedTo(navigationContext);
            PageViews++;
        }
    }
}
