using Dataforge.PrismAvalonExtensions.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dataforge.PrismAvalonExtensions.Test.Regions
{
    public class TabablzProxy
    {
        public DockWindowViewModel CommonData { get; set; }
        public object Content { get; set; }

        public TabablzProxy(object view)
        {
            Content = view;
            CommonData = RegionUtility.GetInterfaceFromView<DockWindowViewModel>(view);
        }
    }
}
