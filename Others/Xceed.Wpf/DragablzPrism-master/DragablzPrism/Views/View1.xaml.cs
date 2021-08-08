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
    /// Interaction logic for View1.xaml
    /// </summary>
    public partial class View1 : UserControl
    {
        public View1()
        {
            InitializeComponent();
        }

        [InjectionConstructor]
        public View1(BaseViewModel vm) : this()
        {
            vm.Title = "View 1";
            this.DataContext = vm;
        }
    }
}
