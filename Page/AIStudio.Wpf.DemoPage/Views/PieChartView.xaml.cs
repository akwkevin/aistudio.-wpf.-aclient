using System.Windows.Controls;
using Util.Controls;

namespace AIStudio.Wpf.DemoPage.Views
{
    /// <summary>
    /// PieChartView.xaml 的交互逻辑
    /// </summary>
    public partial class PieChartView : UserControl
    {
        public PieChartView()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            ComboBox modeCombo = (ComboBox)sender;
            PieMode newMode = (PieMode)modeCombo.SelectedItem;
            this.endAngleSlider.IsEnabled = (newMode != PieMode.Slice);
            this.sliceSlider.IsEnabled = (newMode != PieMode.EndAngle);
        }
    }
}
