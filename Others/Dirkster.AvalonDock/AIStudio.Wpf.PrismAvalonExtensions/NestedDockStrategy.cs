using System.Windows;

namespace AIStudio.Wpf.PrismAvalonExtensions
{
    public enum NestedDockPosition
    {
        Left,
        Right,
        Top,
        Bottom,
        Inside
    }

    public class NestedDockStrategy : DockStrategy
    {
        public NestedDockStrategy(object targetView, NestedDockPosition position, GridLength size)
        {
            _targetView = targetView;
            _position = position;
            _size = size;
        }

        public NestedDockStrategy(object targetView, NestedDockPosition position)
        {
            _targetView = targetView;
            _position = position;
        }

        GridLength _size = new GridLength();
        public GridLength Size
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

        object _targetView;
        public object TargetView
        {
            get
            {
                return _targetView;
            }
            private set
            {
                _targetView = value;
            }
        }

        NestedDockPosition _position;
        public NestedDockPosition Position
        {
            get
            {
                return _position;
            }
            private set
            {
                _position = value;
            }
        }
    }
}
