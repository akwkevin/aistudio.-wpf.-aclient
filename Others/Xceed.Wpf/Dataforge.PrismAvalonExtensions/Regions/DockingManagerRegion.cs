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

namespace Dataforge.PrismAvalonExtensions.Regions
{
    public class DockingManagerRegion : Region
    {
        public DockingManagerRegion()
        {
            EventAggregator.GetEvent<CloseAllDocumentsEvent>().Subscribe(OnCloseAllDocuments);
            this.NavigationService.Navigating += NavigationService_Navigating;
        }

        private void OnCloseAllDocuments(CloseAllDocumentsEventArgs args)
        {
            Queue<object> queue = new Queue<object>(Documents.Keys);
            while (queue.Count > 0)
            {
                object view = queue.Dequeue();
                Documents[view].Close();
                if (this.Views.Contains(view))
                {
                    args.Cancel = true;
                    break;
                }
            }
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
            DockingMetadata md = view as DockingMetadata;
            IRegionManager rm = null;
            if (md != null)
            {
                DockingMetadataDictionary.Add(md.View, md);
                rm = base.Add(md.View, viewName, createRegionManagerScope);
                DockingMetadataDictionary.Remove(md.View);
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

        Dictionary<object, DockingMetadata> _dockStrategyDictionary = new Dictionary<object, DockingMetadata>();
        Dictionary<object, DockingMetadata> DockingMetadataDictionary
        {
            get { return _dockStrategyDictionary; }
        }

        public DockingMetadata GetDockingMetadata(object view)
        {
            if (!DockingMetadataDictionary.ContainsKey(view)) return null;
            return DockingMetadataDictionary[view];
        }

        Dictionary<object, LayoutDocument> _documents;
        Dictionary<object, LayoutDocument> Documents
        {
            get
            {
                if (_documents == null) _documents = new Dictionary<object, LayoutDocument>();
                return _documents;
            }
        }

        public void RegisterCloseAction(object view, LayoutDocument document)
        {
            Documents.Add(view, document);
        }

        public void RemoveCloseAction(object view)
        {
            Documents.Remove(view);
            if (view is IDisposable disposable)
            {
                disposable.Dispose();
            }

            if (view is FrameworkElement element)
            {
                if (element.DataContext is IDisposable disposableDataContext)
                {
                    disposableDataContext.Dispose();
                }
            }

            if (Documents.Count == 0)
            {
                _eventAggregator.GetEvent<SelectedDocumentEvent>().Publish(null);
            }
        }

        public void IsSelected(string title)
        {
            _eventAggregator.GetEvent<SelectedDocumentEvent>().Publish(title);
        }
    }
}
