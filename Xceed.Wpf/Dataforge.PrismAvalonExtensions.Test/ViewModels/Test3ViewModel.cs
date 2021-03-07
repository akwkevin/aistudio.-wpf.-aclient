using Dataforge.PrismAvalonExtensions;
using Dataforge.PrismAvalonExtensions.ViewModels;
using Prism.Regions;

namespace Dataforge.PrismAvalonExtensions.Test.ViewModels
{
    public class Test3ViewModel : NavigationDockWindowViewModel
    {
        private int _pageViews;
        public int PageViews
        {
            get { return _pageViews; }
            set { SetProperty(ref _pageViews, value); }
        }

        public Test3ViewModel()
        {
            Title = "Test3";
            CanClose = false;
            DockStrategy = new SideDockStrategy(DockSide.Left);
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            base.OnNavigatedTo(navigationContext);
            PageViews++;
        }

        public DockStrategy DockStrategy { get; set; }
    }
}
