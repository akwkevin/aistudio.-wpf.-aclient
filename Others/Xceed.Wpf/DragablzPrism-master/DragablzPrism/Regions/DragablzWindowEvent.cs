using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dragablz;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.PubSubEvents;

namespace DragablzPrism.Regions
{
    public class DragablzWindowEvent : PubSubEvent<DragablzWindowEventArgs>
    {

    }

    public class DragablzWindowEventArgs
    {
        public DragablzWindowEventType Type { get; set; }
        public TabablzControl TabControl { get; set; }
    }

    public enum DragablzWindowEventType
    {
        Opened,
        Closed,
        Activated
    }
}
