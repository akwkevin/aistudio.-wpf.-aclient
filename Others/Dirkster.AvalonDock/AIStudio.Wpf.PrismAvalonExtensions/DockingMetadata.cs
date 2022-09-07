using System;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace AIStudio.Wpf.PrismAvalonExtensions
{
    public class DockingMetadata
    {
        private DockingMetadata()
        {
        }

        public DockingMetadata(FrameworkElement view, DockStrategy dockStrategy)
        {
            View = view;
            ContentId = string.Format("{0}, {1}", view.GetType().FullName, view.GetType().Assembly.GetName().Name);

            if (dockStrategy == null)
            {
                //从ViewModel上找DockStrategy
                var dockStrategyPropertyInfo = view.DataContext.GetType().GetProperty("DockStrategy");
                if (dockStrategyPropertyInfo != null)
                {
                    dockStrategy = dockStrategyPropertyInfo.GetValue(view.DataContext, null) as DockStrategy;
                }
                if (dockStrategy == null)//如果ViewModel上没有默认为DocumentDock
                {
                    dockStrategy = new DocumentDockStrategy();
                }
            }

            var canClosePropertyInfo = view.DataContext.GetType().GetProperty("CanClose");
            if (canClosePropertyInfo != null)
            {
                CanClose = (bool)canClosePropertyInfo.GetValue(view.DataContext, null);
            }

            var canFloatPropertyInfo = view.DataContext.GetType().GetProperty("CanFloat");
            if (canFloatPropertyInfo != null)
            {
                CanFloat = (bool)canFloatPropertyInfo.GetValue(view.DataContext, null);
            }

            var autoHidePropertyInfo = view.DataContext.GetType().GetProperty("AutoHide");
            if (autoHidePropertyInfo != null)
            {
                AutoHide = (bool)autoHidePropertyInfo.GetValue(view.DataContext, null);
            }

            var iconSourcePropertyInfo = view.DataContext.GetType().GetProperty("IconSource");
            if (iconSourcePropertyInfo != null)
            {
                Icon = iconSourcePropertyInfo.GetValue(view.DataContext, null) as BitmapSource;
            }

            DockStrategy = dockStrategy;
        }

        string _contentId = Guid.NewGuid().ToString();
        public string ContentId
        {
            get
            {
                return _contentId;
            }
            set
            {
                _contentId = value;
            }
        }

        FrameworkElement _view;
        public FrameworkElement View
        {
            get
            {
                return _view;
            }
            private set
            {
                _view = value;
            }
        }

        DockStrategy _dockStrategy;
        public DockStrategy DockStrategy
        {
            get
            {
                return _dockStrategy;
            }
            private set
            {
                _dockStrategy = value;
            }
        }

        string _title;
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
            }
        }

        BindingBase _titleBinding;
        public BindingBase TitleBinding
        {
            get
            {
                return _titleBinding;
            }
            set
            {
                _titleBinding = value;
            }
        }

        bool _canClose = true;
        public bool CanClose
        {
            get
            {
                return _canClose;
            }
            set
            {
                _canClose = value;
            }
        }

        bool _canFloat = true;
        public bool CanFloat
        {
            get
            {
                return _canFloat;
            }
            set
            {
                _canFloat = value;
            }
        }

        bool _autoHide;
        public bool AutoHide
        {
            get
            {
                return _autoHide;
            }
            set
            {
                _autoHide = value;
            }
        }

        BitmapSource _icon;
        public BitmapSource Icon
        {
            get
            {
                return _icon;
            }
            set
            {
                _icon = value;
            }
        }
    }
}
