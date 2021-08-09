using AIStudio.Wpf.PrismDragablzExtensions;
using Prism.Events;
using Prism.Ioc;
using Prism.Regions;
using System.Collections.Generic;

namespace AIStudio.Wpf.PrismDragablzExtensions.Regions
{
    public class TabablzControlRegion : Region
    {
        public TabablzControlRegion()
        {

        }

        IEventAggregator _eventAggregator = null;
        public IEventAggregator EventAggregator
        {
            get
            {
                if (_eventAggregator == null) _eventAggregator = ContainerLocator.Current.Resolve<IEventAggregator>();
                return _eventAggregator;
            }
        }

        public override IRegionManager Add(object view, string viewName, bool createRegionManagerScope)
        {
            TabablzProxy md = view as TabablzProxy;
            IRegionManager rm = null;      
            rm = base.Add(view, viewName, createRegionManagerScope);
            
            return rm;
        }

        Dictionary<object, TabablzProxy> _tabablzProxyDictionary = new Dictionary<object, TabablzProxy>();
        Dictionary<object, TabablzProxy> TabablzProxyDictionary
        {
            get { return _tabablzProxyDictionary; }
        }

        public TabablzProxy GetTabablzProxy(object view)
        {
            if (!TabablzProxyDictionary.ContainsKey(view)) return null;
            return TabablzProxyDictionary[view];
        }

        public void AddTabablzProxy(object view, TabablzProxy proxy)
        {
            TabablzProxyDictionary.Add(view, proxy);
        }

        public void RemoveTabablzProxy(object view)
        {
            TabablzProxyDictionary.Remove(view);
        }
    }
}
