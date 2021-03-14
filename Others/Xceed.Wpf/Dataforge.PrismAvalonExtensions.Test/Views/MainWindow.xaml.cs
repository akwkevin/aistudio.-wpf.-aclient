using Prism.Regions;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Dataforge.PrismAvalonExtensions.Test.Views
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private string dir = System.AppDomain.CurrentDomain.BaseDirectory;
        public MainWindow(IRegionManager regionManager)
        {
            InitializeComponent();

            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if (File.Exists(dir + "Layout.xml"))
                SerializationHelper.Deserialize(dock, "ContentRegion2", "Layout.xml");
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            SerializationHelper.Serialize(dock, "Layout.xml");
        }
    }
}
