using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace AIStudio.Wpf.DemoPage.Views
{
    /// <summary>
    /// SwitchPanelView.xaml 的交互逻辑
    /// </summary>
    public partial class SwitchPanelView : UserControl
    {
        #region Members


        #endregion

        public SwitchPanelView()
        {
            InitializeComponent();
        }

        #region Event Handlers

        private void OnLayoutComboSelectionChanged(object sender, RoutedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            bool isPlusPanel = (comboBox.SelectedIndex >= 2);

            if (_openSourceScreenShot != null)
                _openSourceScreenShot.Visibility = isPlusPanel ? Visibility.Visible : Visibility.Collapsed;
            if (_openSourceScreenShotDesc != null)
                _openSourceScreenShotDesc.Visibility = isPlusPanel ? Visibility.Visible : Visibility.Collapsed;
            if (_openSourceTextHyperlink != null)
                _openSourceTextHyperlink.Visibility = isPlusPanel ? Visibility.Visible : Visibility.Collapsed;
            if (_switchPanel != null)
                _switchPanel.Visibility = isPlusPanel ? Visibility.Collapsed : Visibility.Visible;

            if (isPlusPanel)
            {
                BitmapImage bitmapImage = new BitmapImage();
                string desc;

                bitmapImage.BeginInit();
                switch (comboBox.SelectedIndex)
                {
                    case 2:
                        bitmapImage.UriSource = new Uri("..\\OpenSourceImages\\Canvas.png", UriKind.Relative);
                        desc = this.Resources["canvasPanelDescription"] as string;
                        break;
                    case 3:
                        bitmapImage.UriSource = new Uri("..\\OpenSourceImages\\Carousel.png", UriKind.Relative);
                        desc = this.Resources["carouselDescription"] as string;
                        break;
                    case 4:
                        bitmapImage.UriSource = new Uri("..\\OpenSourceImages\\DockPanel.png", UriKind.Relative);
                        desc = this.Resources["dockPanelDescription"] as string;
                        break;
                    case 5:
                        bitmapImage.UriSource = new Uri("..\\OpenSourceImages\\Grid.png", UriKind.Relative);
                        desc = this.Resources["gridDescription"] as string;
                        break;
                    case 6:
                        bitmapImage.UriSource = new Uri("..\\OpenSourceImages\\StackPanel.png", UriKind.Relative);
                        desc = this.Resources["stackPanelDescription"] as string;
                        break;
                    case 7:
                        bitmapImage.UriSource = new Uri("..\\OpenSourceImages\\StackedStackPanel.png", UriKind.Relative);
                        desc = this.Resources["stackedStackPanelDescription"] as string;
                        break;
                    case 8:
                        bitmapImage.UriSource = new Uri("..\\OpenSourceImages\\AutoStretchStackPanel.png", UriKind.Relative);
                        desc = this.Resources["autoStretchStackPanelDescription"] as string;
                        break;
                    case 9:
                        bitmapImage.UriSource = new Uri("..\\OpenSourceImages\\RelativeCanvas.png", UriKind.Relative);
                        desc = this.Resources["relativeCanvasDescription"] as string;
                        break;
                    case 10:
                        bitmapImage.UriSource = new Uri("..\\OpenSourceImages\\RadialCanvas.png", UriKind.Relative);
                        desc = this.Resources["radialCanvasDescription"] as string;
                        break;
                    case 11:
                        bitmapImage.UriSource = new Uri("..\\OpenSourceImages\\CameraPanel.png", UriKind.Relative);
                        desc = this.Resources["cameraPanelDescription"] as string;
                        break;
                    case 12:
                        bitmapImage.UriSource = new Uri("..\\OpenSourceImages\\PerspectivePanel.png", UriKind.Relative);
                        desc = this.Resources["perspectivePanelDescription"] as string;
                        break;
                    case 13:
                        bitmapImage.UriSource = new Uri("..\\OpenSourceImages\\AnimatedTimelinePanel.png", UriKind.Relative);
                        desc = this.Resources["animatedTimelinePanelDescription"] as string;
                        break;
                    default: throw new InvalidDataException("LayoutcomboBox.SelectedIndex is not valid.");
                }
                bitmapImage.EndInit();

                if (_openSourceScreenShot != null)
                    _openSourceScreenShot.Source = bitmapImage;
                if (_openSourceScreenShotDesc != null)
                    _openSourceScreenShotDesc.Text = desc;
            }
        }

        private void OnSwitchPanelLayoutChanged(object sender, RoutedEventArgs e)
        {
        }


        #endregion

        #region Methods (Private)
        internal void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }
        #endregion
    }



}
