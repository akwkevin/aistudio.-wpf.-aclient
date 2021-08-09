using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DragablzPrism.Regions
{
    public static class RegionUtility
    {
        public static T GetInterfaceFromView<T>(object view)
        {
            if (view is T)
            {
                return (T)view;
            }
            else
            {
                FrameworkElement viewAsFrameworkElement = view as FrameworkElement;

                if (viewAsFrameworkElement?.DataContext is T)
                {
                    return (T)viewAsFrameworkElement.DataContext;
                }
            }

            return default(T);
        }
    }
}
