using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using Xceed.Wpf.AvalonDock.Layout;

namespace Dataforge.PrismAvalonExtensions.DockStrategies
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
