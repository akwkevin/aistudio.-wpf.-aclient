using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DragablzPrism.Interfaces;

namespace DragablzPrism.Regions
{
    public class TabClientProxy
    {
        public ICommonData CommonData { get; set; }
        public object Content { get; set; }
    }
}
