using System.Windows;

namespace AIStudio.Wpf.PrismAvalonExtensions
{
    public enum DockSide
    {
        Left,
        Right,
        Top,
        Bottom
    }

    public class SideDockStrategy : DockStrategy
    {
        public SideDockStrategy(DockSide side)
        {
            _side = side;
        }

        public SideDockStrategy(DockSide side, GridLength size)
        {
            _side = side;
            _size = size;
        }

        DockSide _side;
        public DockSide Side
        {
            get
            {
                return _side;
            }
            private set
            {
                _side = value;
            }
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
    }
}
