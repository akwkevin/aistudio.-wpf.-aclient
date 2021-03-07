using System.Windows.Controls;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Media;

namespace AIStudio.Wpf.DemoPage.Views
{
    /// <summary>
    /// RangeSliderView.xaml 的交互逻辑
    /// </summary>
    public partial class RangeSliderView : UserControl
    {
        public RangeSliderView()
        {
            InitializeComponent();
        }

        private void RangeStyleComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0 && e.AddedItems[0] is ComboBoxItem)
            {
                ComboBoxItem item = e.AddedItems[0] as ComboBoxItem;
                //A style different from null is chosen
                if (item.Tag != null)
                {
                    //LowerRangeBackground is Transparent, force a color
                    if (object.Equals(sender, lowerRangeStyleComboBox) && ((SolidColorBrush)_rangeSlider.LowerRangeBackground).Color.Equals(Colors.Transparent))
                    {
                        _rangeSlider.LowerRangeBackground = new SolidColorBrush(Colors.Green);
                    }
                    //RangeBackground is Transparent, force a color
                    else if (object.Equals(sender, rangeStyleComboBox) && ((SolidColorBrush)_rangeSlider.RangeBackground).Color.Equals(Colors.Transparent))
                    {
                        _rangeSlider.RangeBackground = new SolidColorBrush(Colors.Blue);
                    }
                    //HigherRangeBackground is Transparent, force a color
                    else if (object.Equals(sender, higherRangeStyleComboBox) && ((SolidColorBrush)_rangeSlider.HigherRangeBackground).Color.Equals(Colors.Transparent))
                    {
                        _rangeSlider.HigherRangeBackground = new SolidColorBrush(Colors.Green);
                    }
                }
            }
        }
    }
}
