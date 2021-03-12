using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIStudio.Wpf.DemoPage.Models
{
    public class Coordinates
    {
        public double X
        {
            get;
            set;
        }
        public double Y
        {
            get;
            set;
        }

        public override string ToString()
        {
            return "(" + this.X + ", " + this.Y + ")";
        }
    }
}
