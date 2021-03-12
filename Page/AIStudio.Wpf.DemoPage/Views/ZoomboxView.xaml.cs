using System.Windows;
using System.Windows.Controls;

namespace AIStudio.Wpf.DemoPage.Views
{
    /// <summary>
    /// ZoomboxViewView.xaml 的交互逻辑
    /// </summary>
    public partial class ZoomboxView : UserControl
    {
        public ZoomboxView()
        {
            InitializeComponent();
        }

        private void AdjustAnimationDuration(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider slider = sender as Slider;
            if (slider == null)
                return;

            zoombox.AnimationDuration = System.TimeSpan.FromMilliseconds(slider.Value);
        }

        private void CoerceAnimationRatios(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider slider = sender as Slider;
            if (slider == null)
                return;

            Slider otherRatio = (sender == this.AccelerationSlider) ? this.DecelerationSlider : this.AccelerationSlider;

            if (slider.Value + otherRatio.Value > 1)
            {
                otherRatio.Value = 1 - slider.Value;
            }
        }
    }
}
