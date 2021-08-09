using AIStudio.Wpf.PrismDragablzExtensions.Helpers;
using System.ComponentModel;

namespace AIStudio.Wpf.PrismDragablzExtensions
{
    public class TabablzProxy
    {
        public INotifyPropertyChanged DataContext { get; set; }
        public object View { get; set; }

        public TabablzProxy(object view)
        {
            View = view;
            DataContext = RegionUtility.GetInterfaceFromView<INotifyPropertyChanged>(view);
        }
    }
}
