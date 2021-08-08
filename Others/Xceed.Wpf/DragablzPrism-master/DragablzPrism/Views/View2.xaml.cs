using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DragablzPrism.ViewModels;
using Microsoft.Practices.Unity;

namespace DragablzPrism.Views
{
    /// <summary>
    /// Interaction logic for View2.xaml
    /// </summary>
    public partial class View2 : UserControl
    {
        public View2()
        {
            InitializeComponent();
        }

        [InjectionConstructor]
        public View2(BaseViewModel vm) : this()
        {
            vm.Title = "View 2";
            this.DataContext = vm;
        }
    }
}
