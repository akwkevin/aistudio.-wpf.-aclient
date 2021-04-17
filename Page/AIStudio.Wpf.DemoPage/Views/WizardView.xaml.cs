using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Util.Controls;
using Util.Controls.Xceed;

namespace AIStudio.Wpf.DemoPage.Views
{
    /// <summary>
    /// WizardView.xaml 的交互逻辑
    /// </summary>
    public partial class WizardView : UserControl
    {
        public WizardView()
        {
            InitializeComponent();
        }

        private System.Windows.Window _window;

        private void OnButtonClick(object sender, EventArgs e)
        {
            Wizard wizard = this.Resources["_wizard"] as Wizard;
            if (wizard != null)
            {
                wizard.CurrentPage = wizard.Items[0] as WizardPage;

                if (_window != null)
                {
                    _window.Content = null;
                    _window = null;
                }
                _window = new System.Windows.Window();
                _window.Title = "Wizard demonstration";
                _window.Content = wizard;
                _window.Width = 600;
                _window.Height = 400;
                _window.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                // Window will be closed by Wizard because FinishButtonClosesWindow = true and CancelButtonClosesWindow = true
                _window.ShowDialog();
            }
        }

        private void OnWizardHelp(object sender, EventArgs e)
        {
            System.Windows.MessageBox.Show("This is the Help for the Wizard\n\n\n\n\n", "Wizard Help");
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            List<GuidVo> list = new List<GuidVo>()
            {
                new GuidVo()
                {
                    Uc=btn1,
                    Content="我是button，是第一步"
                },
                new GuidVo()
                {
                    Uc=tb1,
                    Content="我是textbox，是第二步"
                },
                new GuidVo()
                {
                    Uc=rb1,
                    Content="我是RadioButton，是第三步，也是最后一步了"
                }
            };

            GuideWin win = new GuideWin(Window.GetWindow(this), list);

            win.ShowDialog();
        }
    }
}
