using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIStudio.Wpf.DemoPage.Models
{
    public struct Dimension
    {
        public double Height;
        public double Weight;

        public Dimension(double height, double weight)
        {
            this.Height = height;
            this.Weight = weight;
        }
    }
}
