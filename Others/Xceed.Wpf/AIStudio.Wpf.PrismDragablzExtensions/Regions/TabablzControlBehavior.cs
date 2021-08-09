using Dragablz;
using Prism.Regions;
using Prism.Regions.Behaviors;
using System;
using System.Collections.Specialized;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace AIStudio.Wpf.PrismDragablzExtensions.Regions
{
    class TabablzControlBehavior : RegionBehavior, IHostAwareRegionBehavior
    {
        public static readonly string BehaviorKey = "TabablzControlBehavior";

        public TabablzControlBehavior()
        {
        }

        #region TabablzControl TabablzControl
        TabablzControl _tabablzControl;
        TabablzControl TabablzControl
        {
            get { return _tabablzControl; }
            set { _tabablzControl = value; }
        }
        #endregion

        #region DependencyObject HostControl
        public DependencyObject HostControl
        {
            get { return TabablzControl; }

            set { TabablzControl = value as TabablzControl; }
        }
        #endregion

        #region TabablzControlRegion TabablzControlRegion
        TabablzControlRegion TabablzControlRegion
        {
            get { return (TabablzControlRegion)Region; }
        }
        #endregion

        #region void OnAttach()
        protected override void OnAttach()
        {
            TabablzControl.SelectionChanged += TabControl_SelectionChanged;
            TabablzControl.ClosingItemCallback = ClosingItemCallback;

            Region.ActiveViews.CollectionChanged += ActiveViews_CollectionChanged;
            Region.Views.CollectionChanged += Views_CollectionChanged;
        }
        #endregion

        #region void ActiveViews_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        void ActiveViews_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    var proxy = TabablzControlRegion.GetTabablzProxy(e.NewItems[0]);
                    TabablzControl.SelectedItem = proxy;
                    TabablzControl.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                    break;
            }
        }
        #endregion

        #region void TabControl_SelectionChanged
        private void TabControl_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (TabablzControl != sender) return;

            if (e.AddedItems.Count > 0)
            {
                var item = e.AddedItems[0] as TabablzProxy;
                if (item != null)
                {
                    var regionItem = item.View;

                    foreach (var active in Region.ActiveViews.Where(it => it != regionItem))
                    {
                        if (Region.Views.Contains(active))
                            this.Region.Deactivate(active);
                    }

                    if (this.Region.Views.Contains(regionItem) && !Region.ActiveViews.Contains(regionItem))
                    {
                        this.Region.Activate(regionItem);
                    }
                }
            }
        }

        private void ClosingItemCallback(ItemActionCallbackArgs<TabablzControl> args)
        {
            // remove from region
            this.Region.Remove(((TabablzProxy)args.DragablzItem.DataContext).View);
        }
        #endregion

        #region void Views_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)

        void Views_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    int startIndex = e.NewStartingIndex;
                    foreach (object newItem in e.NewItems)
                    {
                        TabablzProxy proxy = TabablzControlRegion.GetTabablzProxy(newItem);
                        if (proxy == null) //如果没有，则新建一个
                        {
                            proxy = new TabablzProxy(newItem as FrameworkElement);
                            TabablzControlRegion.AddTabablzProxy(newItem, proxy);
                        }

                        this.TabablzControl.Items.Add(proxy);
                    }
                    break;

                case NotifyCollectionChangedAction.Remove:
                    foreach (var oldItem in e.OldItems)
                    {
                        TabablzProxy proxy = TabablzControlRegion.GetTabablzProxy(oldItem);
                        if (proxy != null) 
                        {                            
                            TabablzControl.Items.Remove(proxy);
                            TabablzControlRegion.RemoveTabablzProxy(oldItem);
                        }
                    }
                    break;
            }
        }

        #endregion

    }
}