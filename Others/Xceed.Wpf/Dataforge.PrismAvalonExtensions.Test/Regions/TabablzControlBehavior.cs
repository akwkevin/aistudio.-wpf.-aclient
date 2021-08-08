using Dragablz;
using Prism.Regions;
using Prism.Regions.Behaviors;
using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using Xceed.Wpf.AvalonDock;
using Xceed.Wpf.AvalonDock.Layout;

namespace Dataforge.PrismAvalonExtensions.Test.Regions
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
                    if (TabablzControl.SelectedItem != null && TabablzControl.SelectedItem != e.NewItems[0] && Region.ActiveViews.Contains(TabablzControl.SelectedItem))
                    {
                        this.Region.Deactivate(TabablzControl.SelectedItem);
                    }

                    TabablzControl.SelectedItem = e.NewItems[0];
                    break;

                case NotifyCollectionChangedAction.Remove:
                    if (e.OldItems.Contains(TabablzControl.SelectedItem))
                    {
                        TabablzControl.SelectedItem = null;
                    }
                    break;
            }
        }



        #endregion

        #region 

        private void TabControl_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (TabablzControl != sender) return;

            if (e.AddedItems.Count > 0)
            {
                var item = e.AddedItems[0] as TabablzProxy;
                if (item != null)
                {
                    var regionItem = item.Content;

                    if (this.Region.Views.Contains(regionItem))
                    {
                        this.Region.Activate(regionItem);
                    }
                }
            }
        }

        private void ClosingItemCallback(ItemActionCallbackArgs<TabablzControl> args)
        {
            // remove from region
            this.Region.Remove(((TabablzProxy)args.DragablzItem.DataContext).Content);
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
                        TabablzProxy md = TabablzControlRegion.GetTabablzProxy(newItem);
                        //if (md == null) continue;
                        if (md == null) //如果没有，则新建一个
                        {
                            md = new TabablzProxy(newItem as FrameworkElement);
                        }

                        this.TabablzControl.Items.Add(md);
                    }
                    break;

                case NotifyCollectionChangedAction.Remove:
                    foreach (var oldItem in e.OldItems)
                    {
                        TabablzProxy md = TabablzControlRegion.GetTabablzProxy(oldItem);
                        if (md != null) 
                        {
                            TabablzControl.Items.Remove(md);
                            this.TabablzControlRegion.Remove(oldItem);
                        }
                    }
                    break;
            }
        }

        #endregion

    }
}