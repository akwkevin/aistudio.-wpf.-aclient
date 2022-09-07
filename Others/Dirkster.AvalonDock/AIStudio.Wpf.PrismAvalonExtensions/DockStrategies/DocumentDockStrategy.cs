namespace AIStudio.Wpf.PrismAvalonExtensions.DockStrategies
{
    public class DocumentDockStrategy : DockStrategy
    {
        public DocumentDockStrategy(object view, string title)
          : base(view, title)
        {
        }
        public DocumentDockStrategy(object view, string title, string id)
          : base(view, title, id)
        {
        }
    }
}
