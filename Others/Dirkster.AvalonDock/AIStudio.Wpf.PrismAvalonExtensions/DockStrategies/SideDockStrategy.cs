using System;

namespace AIStudio.Wpf.PrismAvalonExtensions.DockStrategies
{
    [Serializable]
    public enum DockSide
    {
        Left,
        Right,
        Top,
        Bottom
    }

    [Serializable]
    public class SideDockStrategy : DockStrategy
    {
        public SideDockStrategy()
        {
        }

        public SideDockStrategy(object view, string title, string id, DockSide side, int size)
          : base(view, title, id)
        {
            Side = side;
            Size = size;
        }

        public SideDockStrategy(object view, string title, DockSide side, int size)
          : base(view, title)
        {
            Side = side;
            Size = size;
        }

        DockSide _side;
        public DockSide Side
        {
            get
            {
                return _side;
            }
            set
            {
                _side = value;
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
    }
}
