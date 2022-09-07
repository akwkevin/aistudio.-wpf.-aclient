using System;
using System.Xml.Serialization;

namespace AIStudio.Wpf.PrismAvalonExtensions.DockStrategies
{
    [Serializable]
    public enum NestedDockPosition
    {
        Left,
        Right,
        Top,
        Bottom,
        Inside
    }

    [Serializable]
    public class NestedDockStrategy : DockStrategy
    {
        public NestedDockStrategy()
        {
        }

        public NestedDockStrategy(object view, string title, object target, NestedDockPosition position, int size)
          : base(view, title)
        {
            Position = position;
            TargetView = target;
            Size = size;
        }

        public NestedDockStrategy(object view, string title, object target, NestedDockPosition position)
          : base(view, title)
        {
            Position = position;
            TargetView = target;
        }

        public NestedDockStrategy(object view, string title, string id, object target, NestedDockPosition position, int size)
          : base(view, title, id)
        {
            Position = position;
            TargetView = target;
            Size = size;
        }

        public NestedDockStrategy(object view, string title, string id, object target, NestedDockPosition position)
          : base(view, title, id)
        {
            Position = position;
            TargetView = target;
        }

        int _size;
        public int Size
        {
            get
            {
                return _size;
            }
            set
            {
                _size = value;
            }
        }

        bool _autoHide = false;
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

        object _targetView;
        [XmlIgnore]
        public object TargetView
        {
            get
            {
                return _targetView;
            }
            set
            {
                _targetView = value;
                TargetViewType = string.Format("{0}, {1}", value.GetType().FullName, value.GetType().Assembly.GetName().Name);
            }
        }

        string _targetViewType;
        public string TargetViewType
        {
            get
            {
                return _targetViewType;
            }
            set
            {
                _targetViewType = value;
            }
        }

        NestedDockPosition _position;
        public NestedDockPosition Position
        {
            get
            {
                return _position;
            }
            set
            {
                _position = value;
            }
        }
    }
}
