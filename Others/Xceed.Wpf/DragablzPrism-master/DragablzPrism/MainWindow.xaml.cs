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
using Dragablz;
using DragablzPrism.Regions;
using DragablzPrism.ViewModels;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Unity;

namespace DragablzPrism
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : DragablzWindow
    {
        private readonly IEventAggregator eventAggregator;

        public MainWindow()
        {
            InitializeComponent();
        }

        [InjectionConstructor]
        public MainWindow(MainWindowViewModel vm, IEventAggregator eventAggregator) : this()
        {
            this.eventAggregator = eventAggregator;
            DataContext = vm;

            eventAggregator.GetEvent<DragablzWindowEvent>().Publish(new DragablzWindowEventArgs() { TabControl = TabablzControl, Type = DragablzWindowEventType.Opened });
        }

        private void MainWindow_OnClosed(object sender, EventArgs e)
        {
            eventAggregator.GetEvent<DragablzWindowEvent>().Publish(new DragablzWindowEventArgs() { TabControl = TabablzControl, Type = DragablzWindowEventType.Closed });
        }

        private void MainWindow_OnActivated(object sender, EventArgs e)
        {
            eventAggregator.GetEvent<DragablzWindowEvent>().Publish(new DragablzWindowEventArgs() { TabControl = TabablzControl, Type = DragablzWindowEventType.Activated });
        }
    }
}
