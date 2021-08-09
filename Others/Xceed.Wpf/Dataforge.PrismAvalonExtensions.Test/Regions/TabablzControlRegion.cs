using Dataforge.PrismAvalonExtensions.Events;
using Prism.Events;
using Prism.Ioc;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using Xceed.Wpf.AvalonDock.Layout;

namespace Dataforge.PrismAvalonExtensions.Test.Regions
{
    public class TabablzControlRegion : Region
    {
        public TabablzControlRegion()
        {
            this.NavigationService.Navigating += NavigationService_Navigating;
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
            if (md != null)
            {
                TabablzProxyDictionary.Add(md.Content, md);
                rm = base.Add(md.Content, viewName, createRegionManagerScope);
                TabablzProxyDictionary.Remove(md.Content);
            }
            else
            {               
                rm = base.Add(view, viewName, createRegionManagerScope);
            }
            return rm;
        }

        private void NavigationService_Navigating(object sender, RegionNavigationEventArgs e)
        {
            if (e.NavigationContext.Parameters.ContainsKey("Title"))
            {
                var view = this.Views.FirstOrDefault(x => x.GetType().Name == e.Uri.ToString() || x.GetType().FullName == e.Uri.ToString()) as FrameworkElement;
                if (view != null)
                {
                    var propertyInfo = view.DataContext.GetType().GetProperty("Title");
                    if (propertyInfo != null)
                    {
                        propertyInfo.SetValue(view.DataContext, e.NavigationContext.Parameters["Title"]);
                    }
                    IsSelected(e.NavigationContext.Parameters["Title"] as string);
                }
            }
        }

        Collection<object> _busyRemoving = new Collection<object>();
        public override void Remove(object view)
        {
            if (_busyRemoving.Contains(view)) return;
            try
            {
                _busyRemoving.Add(view);
                base.Remove(view);
            }
            finally
            {
                _busyRemoving.Remove(view);
            }
        }

        Dictionary<object, TabablzProxy> _dockStrategyDictionary = new Dictionary<object, TabablzProxy>();
        Dictionary<object, TabablzProxy> TabablzProxyDictionary
        {
            get { return _dockStrategyDictionary; }
        }

        public TabablzProxy GetTabablzProxy(object view)
        {
            if (!TabablzProxyDictionary.ContainsKey(view)) return null;
            return TabablzProxyDictionary[view];
        }

        public void IsSelected(string title)
        {
            _eventAggregator.GetEvent<SelectedDocumentEvent>().Publish(title);
        }
    }
}
