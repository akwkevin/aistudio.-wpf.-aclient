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
using TestApp;

namespace AIStudio.Wpf.DemoPage.Views
{
    /// <summary>
    /// DataGridView.xaml 的交互逻辑
    /// </summary>
    public partial class DataGridView : UserControl
    {
        public DataGridView()
        {
            InitializeComponent();

            int c1 = 2500;
            int c2 = 3;
            int c3 = 1;
            var model = PersonModel.CreateTestModel(c1, c2, c3);
            _tree.Model = model;
        }
    }
}
