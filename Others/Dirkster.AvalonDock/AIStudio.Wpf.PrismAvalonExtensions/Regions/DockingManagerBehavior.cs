using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using AvalonDock;
using AvalonDock.Layout;
using Prism.Regions;
using Prism.Regions.Behaviors;

namespace AIStudio.Wpf.PrismAvalonExtensions.Regions
{
    class DockingManagerBehavior : RegionBehavior, IHostAwareRegionBehavior
    {
        public static readonly string BehaviorKey = "DockingManagerBehavior";

        public DockingManagerBehavior()
        {
        }

        #region DockingManager DockingManager

        DockingManager _dockingManager;
        DockingManager DockingManager
        {
            get
            {
                return _dockingManager;
            }
            set
            {
                _dockingManager = value;
            }
        }

        #endregion

        #region DependencyObject HostControl

        public DependencyObject HostControl
        {
            get
            {
                return DockingManager;
            }

            set
            {
                DockingManager = value as DockingManager;
            }
        }

        #endregion

        #region DockingManagerRegion DockingManagerRegion

        DockingManagerRegion DockingManagerRegion
        {
            get
            {
                return (DockingManagerRegion)Region;
            }
        }

        #endregion



        #region void OnAttach()

        protected override void OnAttach()
        {
            if (DockingManager.DocumentsSource != null) throw new InvalidOperationException("DocumentsSource already set.");
            if (DockingManager.AnchorablesSource != null) throw new InvalidOperationException("AnchorablesSource already set.");

            DockingManager.ActiveContentChanged += ManagerActiveContentChanged;
            Region.ActiveViews.CollectionChanged += ActiveViews_CollectionChanged;
            Region.Views.CollectionChanged += Views_CollectionChanged;
        }

        #endregion

        #region void ActiveViews_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)

        bool _updatingActiveViewsInManagerActiveContentChanged;
        void ActiveViews_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            //if (this._updatingActiveViewsInManagerActiveContentChanged) return;

            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    if (DockingManager.ActiveContent != null && DockingManager.ActiveContent != e.NewItems[0] && Region.ActiveViews.Contains(DockingManager.ActiveContent))
                    {
                        this.Region.Deactivate(DockingManager.ActiveContent);
                    }

                    DockingManager.ActiveContent = e.NewItems[0];
                    break;

                case NotifyCollectionChangedAction.Remove:
                    if (e.OldItems.Contains(DockingManager.ActiveContent))
                    {
                        DockingManager.ActiveContent = null;
                    }
                    break;
            }
        }

        #endregion

        #region void ManagerActiveContentChanged(object sender, EventArgs e)

        void ManagerActiveContentChanged(object sender, EventArgs e)
        {
            if (DockingManager != sender) return;

            try
            {
                this._updatingActiveViewsInManagerActiveContentChanged = true;
                object activeContent = DockingManager.ActiveContent;

                foreach (var item in Region.ActiveViews.Where(it => it != activeContent))
                {
                    if (Region.Views.Contains(item))
                        this.Region.Deactivate(item);
                }

                if (this.Region.Views.Contains(activeContent) && !Region.ActiveViews.Contains(activeContent))
                {
                    this.Region.Activate(activeContent);
                }
            }
            finally
            {
                this._updatingActiveViewsInManagerActiveContentChanged = false;
            }
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
                        DockingMetadata md = DockingManagerRegion.GetDockingMetadata(newItem);
                        //if (md == null) continue;
                        if (md == null) //如果没有，则新建一个
                        {
                            md = new DockingMetadata(newItem as FrameworkElement, null);
                        }

                        try
                        {
                            md.TitleBinding = new Binding("Title") { Source = md.View.DataContext };
                        }
                        catch { }
                        if (md.DockStrategy is DocumentDockStrategy) DocumentDock(md);
                        if (md.DockStrategy is SideDockStrategy) SideDock(md);
                        if (md.DockStrategy is NestedDockStrategy) NestedDock(md);
                    }
                    break;

                case NotifyCollectionChangedAction.Remove:
                    if (_isHidingClosing) break;
                    foreach (var oldItem in e.OldItems)
                    {
                        LayoutAnchorable targetAncorable = DockingManager.Layout.Descendents().OfType<LayoutAnchorable>().FirstOrDefault(p => p.Content == oldItem);
                        if (targetAncorable != null)
                        {
                            targetAncorable.Hide();
                            continue;
                        }
                        LayoutDocument targetDocument = DockingManager.Layout.Descendents().OfType<LayoutDocument>().FirstOrDefault(p => p.Content == oldItem);
                        if (targetDocument != null) targetDocument.Close();

                        DockingManagerRegion.RemoveCloseAction(oldItem);
                    }
                    break;
            }
        }

        #endregion

        #region void HidingClosing(object sender, CancelEventArgs e)

        bool _isHidingClosing = false;
        void HidingClosing(object sender, CancelEventArgs e)
        {
            try
            {
                _isHidingClosing = true;
                LayoutAnchorable la = sender as LayoutAnchorable;
                if (la != null)
                {
                    DockingManagerRegion.Remove(la.Content);
                    return;
                }
                LayoutDocument d = sender as LayoutDocument;
                if (d != null) DockingManagerRegion.Remove(d.Content);
            }
            finally
            {
                _isHidingClosing = false;
            }
        }

        #endregion



        #region void DocumentDock(DockingMetadata dm)

        void DocumentDock(DockingMetadata dm)
        {
            DocumentDockStrategy dds = dm.DockStrategy as DocumentDockStrategy;
            LayoutDocumentPane documentPane = DockingManager.Layout.Descendents().OfType<LayoutDocumentPane>().First();
            LayoutDocument document = new LayoutDocument();

            if (dm.TitleBinding != null)
            {
                BindingOperations.SetBinding(document, LayoutDocument.TitleProperty, dm.TitleBinding);
            }
            else
            {
                document.Title = dm.Title;
            }
            document.Content = dm.View;
            documentPane.Children.Add(document);
            document.CanClose = dm.CanClose;
            document.CanFloat = dm.CanFloat;
            document.IconSource = dm.Icon;
            document.ContentId = dm.ContentId;
            document.Closing += (ss, e) => {
                IClosingValidator cv = dm.View.DataContext as IClosingValidator;
                if (cv != null && cv.IsDirty)
                {
                    if (Region.Views.Contains(dm.View)) Region.Activate(dm.View);
                    if (!cv.OnClosing()) e.Cancel = true;
                }
            };
            document.Closed += (s, ee) => {
                DockingManagerRegion.Remove(dm.View);
                DockingManagerRegion.RemoveCloseAction(dm.View);
            };
            document.IsSelectedChanged += (s, ee) => {
                if (document.IsSelected)
                {
                    DockingManagerRegion.IsSelected(document.Title);
                }
            };
            DockingManagerRegion.RegisterCloseAction(dm.View, document);

        }

        #endregion

        #region void SideDock(DockingMetadata dm)

        void SideDock(DockingMetadata dm)
        {
            SideDockStrategy sds = dm.DockStrategy as SideDockStrategy;
            LayoutAnchorablePane lap = new LayoutAnchorablePane();
            LayoutAnchorable la = new LayoutAnchorable();
            lap.Children.Add(la);
            if (dm.TitleBinding != null)
            {
                BindingOperations.SetBinding(la, LayoutDocument.TitleProperty, dm.TitleBinding);
            }
            else
            {
                la.Title = dm.Title;
            }
            la.Content = dm.View;
            la.IconSource = dm.Icon;
            la.CanHide = dm.CanClose;
            la.ContentId = dm.ContentId;
            la.Hiding += HidingClosing;

            switch (sds.Side)
            {
                case DockSide.Left:
                    #region DockSide.Left

                    lap.DockWidth = sds.Size;
                    la.AutoHideWidth = sds.Size.Value;

                    if (DockingManager.Layout.RootPanel.Orientation != System.Windows.Controls.Orientation.Horizontal &&
                        DockingManager.Layout.RootPanel.Children.Count == 1)
                        DockingManager.Layout.RootPanel.Orientation = System.Windows.Controls.Orientation.Horizontal;

                    if (DockingManager.Layout.RootPanel.Orientation == System.Windows.Controls.Orientation.Horizontal)
                    {
                        DockingManager.Layout.RootPanel.Children.Insert(0, lap);
                    }
                    else
                    {
                        var newOrientedPanel = new LayoutPanel()
                        {
                            Orientation = System.Windows.Controls.Orientation.Horizontal
                        };

                        newOrientedPanel.Children.Add(lap);
                        newOrientedPanel.Children.Add(DockingManager.Layout.RootPanel);

                        DockingManager.Layout.RootPanel = newOrientedPanel;
                    }
                    break;

                #endregion

                case DockSide.Right:
                    #region DockSide.Right

                    lap.DockWidth = sds.Size;
                    la.AutoHideWidth = sds.Size.Value;

                    if (DockingManager.Layout.RootPanel.Orientation != System.Windows.Controls.Orientation.Horizontal
                        && DockingManager.Layout.RootPanel.Children.Count == 1)
                        DockingManager.Layout.RootPanel.Orientation = System.Windows.Controls.Orientation.Horizontal;

                    if (DockingManager.Layout.RootPanel.Orientation == System.Windows.Controls.Orientation.Horizontal)
                    {
                        DockingManager.Layout.RootPanel.Children.Add(lap);
                    }
                    else
                    {
                        var newOrientedPanel = new LayoutPanel()
                        {
                            Orientation = System.Windows.Controls.Orientation.Horizontal
                        };

                        newOrientedPanel.Children.Add(DockingManager.Layout.RootPanel);
                        newOrientedPanel.Children.Add(lap);

                        DockingManager.Layout.RootPanel = newOrientedPanel;
                    }
                    break;

                #endregion

                case DockSide.Top:
                    #region DockSide.Top

                    lap.DockHeight = sds.Size;
                    la.AutoHideHeight = sds.Size.Value;

                    if (DockingManager.Layout.RootPanel.Orientation != System.Windows.Controls.Orientation.Vertical
                        && DockingManager.Layout.RootPanel.Children.Count == 1)
                        DockingManager.Layout.RootPanel.Orientation = System.Windows.Controls.Orientation.Vertical;

                    if (DockingManager.Layout.RootPanel.Orientation == System.Windows.Controls.Orientation.Vertical)
                    {
                        DockingManager.Layout.RootPanel.Children.Insert(0, lap);
                    }
                    else
                    {
                        var newOrientedPanel = new LayoutPanel()
                        {
                            Orientation = System.Windows.Controls.Orientation.Vertical
                        };

                        newOrientedPanel.Children.Add(lap);
                        newOrientedPanel.Children.Add(DockingManager.Layout.RootPanel);

                        DockingManager.Layout.RootPanel = newOrientedPanel;
                    }
                    break;

                #endregion

                case DockSide.Bottom:
                    #region DockSide.Bottom

                    lap.DockHeight = sds.Size;
                    la.AutoHideHeight = sds.Size.Value;

                    if (DockingManager.Layout.RootPanel.Orientation != System.Windows.Controls.Orientation.Vertical
                        && DockingManager.Layout.RootPanel.Children.Count == 1)
                        DockingManager.Layout.RootPanel.Orientation = System.Windows.Controls.Orientation.Vertical;

                    if (DockingManager.Layout.RootPanel.Orientation == System.Windows.Controls.Orientation.Vertical)
                    {
                        DockingManager.Layout.RootPanel.Children.Add(lap);
                    }
                    else
                    {
                        var newOrientedPanel = new LayoutPanel()
                        {
                            Orientation = System.Windows.Controls.Orientation.Vertical
                        };

                        newOrientedPanel.Children.Add(DockingManager.Layout.RootPanel);
                        newOrientedPanel.Children.Add(lap);

                        DockingManager.Layout.RootPanel = newOrientedPanel;
                    }
                    break;

                    #endregion
            }

            if (dm.AutoHide) la.ToggleAutoHide();
        }

        #endregion

        #region void NestedDock(DockingMetadata dm)

        void NestedDock(DockingMetadata dm)
        {
            NestedDockStrategy nds = dm.DockStrategy as NestedDockStrategy;
            ILayoutAnchorablePane targetModel = null;
            LayoutAnchorable targetAncorable = DockingManager.Layout.Descendents().OfType<LayoutAnchorable>().FirstOrDefault(p => p.Content == nds.TargetView);
            if (targetAncorable == null)
            {
                NestedDockOnDocument(dm);
                return;
            }
            else
            {
                if (targetAncorable.Parent is LayoutAnchorGroup)
                {
                    NestedDockOnAutoHidden(dm);
                    return;
                }

                targetModel = targetAncorable.Parent as ILayoutAnchorablePane;
            }
            if (targetModel == null) throw new InvalidOperationException("Could not process drop target.");

            LayoutAnchorablePane lap = new LayoutAnchorablePane();
            LayoutAnchorable anchorableActive = new LayoutAnchorable();
            lap.Children.Add(anchorableActive);
            anchorableActive.Content = dm.View;
            if (dm.TitleBinding != null)
            {
                BindingOperations.SetBinding(anchorableActive, LayoutDocument.TitleProperty, dm.TitleBinding);
            }
            else
            {
                anchorableActive.Title = dm.Title;
            }
            anchorableActive.CanHide = dm.CanClose;
            anchorableActive.IconSource = dm.Icon;
            anchorableActive.ContentId = dm.ContentId;
            anchorableActive.Hiding += HidingClosing;

            switch (nds.Position)
            {
                case NestedDockPosition.Bottom:
                    #region NestedDockType.Bottom
                    {
                        lap.DockHeight = nds.Size;
                        anchorableActive.AutoHideHeight = nds.Size.Value;

                        var parentModel = targetModel.Parent as ILayoutGroup;
                        var parentModelOrientable = targetModel.Parent as ILayoutOrientableGroup;
                        int insertToIndex = parentModel.IndexOfChild(targetModel);

                        if (parentModelOrientable.Orientation != System.Windows.Controls.Orientation.Vertical &&
                            parentModel.ChildrenCount == 1)
                            parentModelOrientable.Orientation = System.Windows.Controls.Orientation.Vertical;

                        if (parentModelOrientable.Orientation == System.Windows.Controls.Orientation.Vertical)
                        {
                            parentModel.InsertChildAt(insertToIndex + 1, lap);
                        }
                        else
                        {
                            var newOrientedPanel = new LayoutAnchorablePaneGroup()
                            {
                                Orientation = System.Windows.Controls.Orientation.Vertical,
                                DockWidth = GetWidth(targetModel),
                                DockHeight = GetHeight(targetModel),
                            };

                            parentModel.InsertChildAt(insertToIndex, newOrientedPanel);
                            newOrientedPanel.Children.Add(targetModel);
                            newOrientedPanel.Children.Add(lap);
                        }
                    }
                    break;

                #endregion

                case NestedDockPosition.Top:
                    #region NestedDockPosition.Top
                    {
                        lap.DockHeight = nds.Size;
                        anchorableActive.AutoHideHeight = nds.Size.Value;

                        var parentModel = targetModel.Parent as ILayoutGroup;
                        var parentModelOrientable = targetModel.Parent as ILayoutOrientableGroup;
                        int insertToIndex = parentModel.IndexOfChild(targetModel);

                        if (parentModelOrientable.Orientation != System.Windows.Controls.Orientation.Vertical &&
                            parentModel.ChildrenCount == 1)
                            parentModelOrientable.Orientation = System.Windows.Controls.Orientation.Vertical;

                        if (parentModelOrientable.Orientation == System.Windows.Controls.Orientation.Vertical)
                        {
                            parentModel.InsertChildAt(insertToIndex, lap);
                        }
                        else
                        {
                            var newOrientedPanel = new LayoutAnchorablePaneGroup()
                            {
                                Orientation = System.Windows.Controls.Orientation.Vertical,
                                DockWidth = GetWidth(targetModel),
                                DockHeight = GetHeight(targetModel),
                            };

                            parentModel.InsertChildAt(insertToIndex, newOrientedPanel);
                            newOrientedPanel.Children.Add(targetModel);
                            newOrientedPanel.Children.Insert(0, lap);

                        }
                    }
                    break;
                #endregion

                case NestedDockPosition.Left:
                    #region NestedDockPosition.Left
                    {
                        lap.DockWidth = nds.Size;
                        anchorableActive.AutoHideWidth = nds.Size.Value;

                        var parentModel = targetModel.Parent as ILayoutGroup;
                        var parentModelOrientable = targetModel.Parent as ILayoutOrientableGroup;
                        int insertToIndex = parentModel.IndexOfChild(targetModel);

                        if (parentModelOrientable.Orientation != System.Windows.Controls.Orientation.Horizontal &&
                            parentModel.ChildrenCount == 1)
                            parentModelOrientable.Orientation = System.Windows.Controls.Orientation.Horizontal;

                        if (parentModelOrientable.Orientation == System.Windows.Controls.Orientation.Horizontal)
                        {
                            parentModel.InsertChildAt(insertToIndex, lap);
                        }
                        else
                        {
                            var newOrientedPanel = new LayoutAnchorablePaneGroup()
                            {
                                Orientation = System.Windows.Controls.Orientation.Horizontal,
                                DockWidth = GetWidth(targetModel),
                                DockHeight = GetHeight(targetModel),
                            };

                            parentModel.InsertChildAt(insertToIndex, newOrientedPanel);
                            newOrientedPanel.Children.Add(targetModel);
                            newOrientedPanel.Children.Insert(0, lap);
                        }
                    }
                    break;
                #endregion

                case NestedDockPosition.Right:
                    #region DropTargetType.AnchorablePaneDockRight
                    {
                        lap.DockWidth = nds.Size;
                        anchorableActive.AutoHideWidth = nds.Size.Value;

                        var parentModel = targetModel.Parent as ILayoutGroup;
                        var parentModelOrientable = targetModel.Parent as ILayoutOrientableGroup;
                        int insertToIndex = parentModel.IndexOfChild(targetModel);

                        if (parentModelOrientable.Orientation != System.Windows.Controls.Orientation.Horizontal &&
                            parentModel.ChildrenCount == 1)
                            parentModelOrientable.Orientation = System.Windows.Controls.Orientation.Horizontal;

                        if (parentModelOrientable.Orientation == System.Windows.Controls.Orientation.Horizontal)
                        {
                            parentModel.InsertChildAt(insertToIndex + 1, lap);
                        }
                        else
                        {
                            var newOrientedPanel = new LayoutAnchorablePaneGroup()
                            {
                                Orientation = System.Windows.Controls.Orientation.Horizontal,
                                DockWidth = GetWidth(targetModel),
                                DockHeight = GetHeight(targetModel),
                            };

                            parentModel.InsertChildAt(insertToIndex, newOrientedPanel);
                            newOrientedPanel.Children.Add(targetModel);
                            newOrientedPanel.Children.Add(lap);
                        }
                    }
                    break;
                #endregion

                case NestedDockPosition.Inside:
                    #region NestedDockPosition.Inside
                    {
                        var paneModel = targetModel as LayoutAnchorablePane;
                        paneModel.Children.Add(anchorableActive);
                    }
                    break;
                    #endregion
            }

            anchorableActive.IsActive = true;
            if (dm.AutoHide) anchorableActive.ToggleAutoHide();
        }

        #region GetHeight(ILayoutAnchorablePane targetModel)

        GridLength GetHeight(ILayoutAnchorablePane targetModel)
        {
            LayoutAnchorablePane lap = targetModel as LayoutAnchorablePane;
            if (lap != null) return lap.DockHeight;

            LayoutAnchorablePaneGroup lapg = targetModel as LayoutAnchorablePaneGroup;
            if (lapg != null) return lapg.DockHeight;

            return new GridLength();
        }

        #endregion

        #region GetWidth(ILayoutAnchorablePane targetModel)

        GridLength GetWidth(ILayoutAnchorablePane targetModel)
        {
            LayoutAnchorablePane lap = targetModel as LayoutAnchorablePane;
            if (lap != null) return lap.DockWidth;

            LayoutAnchorablePaneGroup lapg = targetModel as LayoutAnchorablePaneGroup;
            if (lapg != null) return lapg.DockWidth;

            return new GridLength();
        }

        #endregion


        #region void NestedDockOnDocument(DockingMetadata dm)

        void NestedDockOnDocument(DockingMetadata dm)
        {
            NestedDockStrategy nds = dm.DockStrategy as NestedDockStrategy;
            ILayoutDocumentPane targetModel = null;
            LayoutDocumentPaneGroup parentGroup = null;
            LayoutPanel parentGroupPanel = null;

            LayoutDocument targetDocument = DockingManager.Layout.Descendents().OfType<LayoutDocument>().FirstOrDefault(p => p.Content == nds.TargetView);
            if (targetDocument != null) targetModel = targetDocument.Parent as ILayoutDocumentPane;
            else targetModel = DockingManager.Layout.Descendents().OfType<LayoutDocumentPaneGroup>().FirstOrDefault();
            if (targetModel == null) throw new InvalidOperationException("Could not locate a LayoutDocumentPaneGroup.");
            FindParentLayoutDocumentPane(targetModel, out parentGroup, out parentGroupPanel);

            LayoutAnchorablePane lap = new LayoutAnchorablePane();
            LayoutAnchorable anchorableActive = new LayoutAnchorable();
            lap.Children.Add(anchorableActive);
            anchorableActive.Content = dm.View;
            if (dm.TitleBinding != null)
            {
                BindingOperations.SetBinding(anchorableActive, LayoutDocument.TitleProperty, dm.TitleBinding);
            }
            else
            {
                anchorableActive.Title = dm.Title;
            }
            anchorableActive.CanHide = dm.CanClose;
            anchorableActive.IconSource = dm.Icon;
            anchorableActive.ContentId = dm.ContentId;
            anchorableActive.Hiding += HidingClosing;

            switch (nds.Position)
            {
                case NestedDockPosition.Bottom:
                    #region NestedDockType.Bottom
                    {
                        lap.DockHeight = nds.Size;
                        anchorableActive.AutoHideHeight = nds.Size.Value;

                        if (parentGroupPanel != null &&
                            parentGroupPanel.ChildrenCount == 1)
                            parentGroupPanel.Orientation = System.Windows.Controls.Orientation.Vertical;

                        if (parentGroupPanel != null &&
                            parentGroupPanel.Orientation == System.Windows.Controls.Orientation.Vertical)
                        {
                            parentGroupPanel.Children.Insert(
                                parentGroupPanel.IndexOfChild(parentGroup != null ? parentGroup : targetModel) + 1,
                                lap);
                        }
                        else if (parentGroupPanel != null)
                        {
                            var newParentPanel = new LayoutPanel() { Orientation = System.Windows.Controls.Orientation.Vertical };
                            parentGroupPanel.Children.Add(newParentPanel);
                            newParentPanel.Children.Add(parentGroup != null ? parentGroup : targetModel);
                            newParentPanel.Children.Add(lap);
                        }
                        else
                        {
                            throw new NotImplementedException();
                        }
                    }
                    break;

                #endregion

                case NestedDockPosition.Top:
                    #region NestedDockPosition.Top
                    {
                        lap.DockHeight = nds.Size;
                        anchorableActive.AutoHideHeight = nds.Size.Value;

                        if (parentGroupPanel != null &&
                            parentGroupPanel.ChildrenCount == 1)
                            parentGroupPanel.Orientation = System.Windows.Controls.Orientation.Vertical;

                        if (parentGroupPanel != null &&
                            parentGroupPanel.Orientation == System.Windows.Controls.Orientation.Vertical)
                        {
                            parentGroupPanel.Children.Insert(
                                parentGroupPanel.IndexOfChild(parentGroup != null ? parentGroup : targetModel),
                                lap);
                        }
                        else if (parentGroupPanel != null)
                        {
                            var newParentPanel = new LayoutPanel() { Orientation = System.Windows.Controls.Orientation.Vertical };
                            parentGroupPanel.ReplaceChild(parentGroup != null ? parentGroup : targetModel, newParentPanel);
                            newParentPanel.Children.Add(parentGroup != null ? parentGroup : targetModel);
                            newParentPanel.Children.Insert(0, lap);
                        }
                        else
                        {
                            throw new NotImplementedException();
                        }
                    }
                    break;
                #endregion

                case NestedDockPosition.Left:
                    #region NestedDockPosition.Left
                    {
                        lap.DockWidth = nds.Size;
                        anchorableActive.AutoHideWidth = nds.Size.Value;

                        if (parentGroupPanel != null &&
                            parentGroupPanel.ChildrenCount == 1)
                            parentGroupPanel.Orientation = System.Windows.Controls.Orientation.Horizontal;

                        if (parentGroupPanel != null &&
                            parentGroupPanel.Orientation == System.Windows.Controls.Orientation.Horizontal)
                        {
                            parentGroupPanel.Children.Insert(
                                parentGroupPanel.IndexOfChild(parentGroup != null ? parentGroup : targetModel),
                                lap);
                        }
                        else if (parentGroupPanel != null)
                        {
                            var newParentPanel = new LayoutPanel() { Orientation = System.Windows.Controls.Orientation.Horizontal };
                            parentGroupPanel.ReplaceChild(parentGroup != null ? parentGroup : targetModel, newParentPanel);
                            newParentPanel.Children.Add(parentGroup != null ? parentGroup : targetModel);
                            newParentPanel.Children.Insert(0, lap);
                        }
                        else
                        {
                            throw new NotImplementedException();
                        }
                    }
                    break;
                #endregion

                case NestedDockPosition.Right:
                    #region NestedDockPosition.Right
                    {
                        lap.DockWidth = nds.Size;
                        anchorableActive.AutoHideWidth = nds.Size.Value;

                        if (parentGroupPanel != null &&
                            parentGroupPanel.ChildrenCount == 1)
                            parentGroupPanel.Orientation = System.Windows.Controls.Orientation.Horizontal;

                        if (parentGroupPanel != null &&
                            parentGroupPanel.Orientation == System.Windows.Controls.Orientation.Horizontal)
                        {
                            parentGroupPanel.Children.Insert(
                                parentGroupPanel.IndexOfChild(parentGroup != null ? parentGroup : targetModel) + 1,
                                lap);
                        }
                        else if (parentGroupPanel != null)
                        {
                            var newParentPanel = new LayoutPanel() { Orientation = System.Windows.Controls.Orientation.Horizontal };
                            parentGroupPanel.ReplaceChild(parentGroup != null ? parentGroup : targetModel, newParentPanel);
                            newParentPanel.Children.Add(parentGroup != null ? parentGroup : targetModel);
                            newParentPanel.Children.Add(lap);
                        }
                        else
                        {
                            throw new NotImplementedException();
                        }
                    }
                    break;
                #endregion

                case NestedDockPosition.Inside:
                    throw new InvalidOperationException("Can not dock a pane inside a document.");
            }

            anchorableActive.IsActive = true;
            if (dm.AutoHide) anchorableActive.ToggleAutoHide();
        }

        #region bool FindParentLayoutDocumentPane(ILayoutDocumentPane documentPane, out LayoutDocumentPaneGroup containerPaneGroup, out LayoutPanel containerPanel)

        bool FindParentLayoutDocumentPane(ILayoutDocumentPane documentPane, out LayoutDocumentPaneGroup containerPaneGroup, out LayoutPanel containerPanel)
        {
            containerPaneGroup = null;
            containerPanel = null;

            if (documentPane.Parent is LayoutPanel)
            {
                containerPaneGroup = null;
                containerPanel = documentPane.Parent as LayoutPanel;
                return true;
            }
            else if (documentPane.Parent is LayoutDocumentPaneGroup)
            {
                var currentDocumentPaneGroup = documentPane.Parent as LayoutDocumentPaneGroup;
                while (!(currentDocumentPaneGroup.Parent is LayoutPanel))
                {
                    currentDocumentPaneGroup = currentDocumentPaneGroup.Parent as LayoutDocumentPaneGroup;

                    if (currentDocumentPaneGroup == null)
                        break;
                }

                if (currentDocumentPaneGroup == null)
                    return false;

                containerPaneGroup = currentDocumentPaneGroup;
                containerPanel = currentDocumentPaneGroup.Parent as LayoutPanel;
                return true;
            }

            return false;
        }

        #endregion

        #endregion

        #region void NestedDockOnAutoHidden(DockingMetadata dm)

        void NestedDockOnAutoHidden(DockingMetadata dm)
        {
            NestedDockStrategy nds = dm.DockStrategy as NestedDockStrategy;
            LayoutAnchorGroup targetModel = null;
            LayoutAnchorable targetAncorable = DockingManager.Layout.Descendents().OfType<LayoutAnchorable>().FirstOrDefault(p => p.Content == nds.TargetView);
            targetModel = targetAncorable.Parent as LayoutAnchorGroup;
            if (targetModel == null) throw new InvalidOperationException("Could not process drop target.");

            LayoutAnchorablePane lap = new LayoutAnchorablePane();
            LayoutAnchorable anchorableActive = new LayoutAnchorable();
            lap.Children.Add(anchorableActive);
            anchorableActive.Content = dm.View;
            if (dm.TitleBinding != null)
            {
                BindingOperations.SetBinding(anchorableActive, LayoutDocument.TitleProperty, dm.TitleBinding);
            }
            else
            {
                anchorableActive.Title = dm.Title;
            }
            anchorableActive.CanHide = dm.CanClose;
            anchorableActive.IconSource = dm.Icon;
            anchorableActive.ContentId = dm.ContentId;
            anchorableActive.Hiding += HidingClosing;

            lap.DockHeight = nds.Size;
            anchorableActive.AutoHideHeight = nds.Size.Value;
            targetModel.Children.Add(anchorableActive);


            anchorableActive.IsActive = true;
            if (dm.AutoHide) anchorableActive.ToggleAutoHide();
        }

        #endregion

        #endregion
    }
}