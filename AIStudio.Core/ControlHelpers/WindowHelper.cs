using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AIStudio.Core
{
    public class WindowHelper
    {
        public static bool? ShowDialog(Window owner, Window win)
        {
            win.Owner = owner;
            return win.ShowDialog();
        }

        public static void Show(Window owner, Window win)
        {
            win.Owner = owner;
            win.Show();
        }
    }
}
