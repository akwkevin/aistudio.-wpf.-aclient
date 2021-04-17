using AIStudio.Wpf.DemoPage.Views;
using Prism.Commands;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Util.Controls;

namespace AIStudio.Wpf.DemoPage.ViewModels
{
    public class DialogViewModel : DockWindowViewModel
    {
        private ICommand _showMessageBoxCommand;
        public ICommand ShowMessageBoxCommand
        {
            get
            {
                return this._showMessageBoxCommand ?? (this._showMessageBoxCommand = new DelegateCommand(() => this.ShowMessageBox()));
            }
        }

        public async void ShowMessageBox()
        {
            await Util.Controls.DialogBox.Msg.Info("test");
            await Util.Controls.DialogBox.Msg.Question("test");
            await Util.Controls.DialogBox.Msg.Warning("test");
            await Util.Controls.DialogBox.Msg.Error("test");
        }

        private ICommand _showWaitingBoxCommand1;
        public ICommand ShowWaitingBoxCommand1
        {
            get
            {
                return this._showWaitingBoxCommand1 ?? (this._showWaitingBoxCommand1 = new DelegateCommand(() => this.ShowWaitingBox1()));
            }
        }

        public async void ShowWaitingBox1()
        {
            var control = WindowBase.ShowWaiting(WaitingType.Progress, "RootWindow");
            control.CanPercent = true;
            for (int i = 0; i < 10; i++)
            {
                await Task.Delay(1000);
                control.Percent += 0.1;
            }
            WindowBase.HideWaiting("RootWindow");
        }

        private ICommand _showWaitingBoxCommand2;
        public ICommand ShowWaitingBoxCommand2
        {
            get
            {
                return this._showWaitingBoxCommand2 ?? (this._showWaitingBoxCommand2 = new DelegateCommand(() => this.ShowWaitingBox2()));
            }
        }

        public async void ShowWaitingBox2()
        {
            var control = WindowBase.ShowWaiting(WaitingType.Busy, "RootWindow");
            control.CanPercent = true;
            for (int i = 0; i < 10; i++)
            {
                await Task.Delay(1000);
                control.Percent += 0.1;
            }
            WindowBase.HideWaiting("RootWindow");
        }

        private ICommand _showWaitingBoxCommand3;
        public ICommand ShowWaitingBoxCommand3
        {
            get
            {
                return this._showWaitingBoxCommand3 ?? (this._showWaitingBoxCommand3 = new DelegateCommand(() => this.ShowWaitingBox3()));
            }
        }

        public async void ShowWaitingBox3()
        {
            var control = WindowBase.ShowWaiting(WaitingType.Ring, "RootWindow");
            control.CanPercent = true;
            for (int i = 0; i < 10; i++)
            {
                await Task.Delay(1000);
                control.Percent += 0.1;
            }
            WindowBase.HideWaiting("RootWindow");
        }

        private ICommand _showMessageQueueCommand;
        public ICommand ShowMessageQueueCommand
        {
            get
            {
                return this._showMessageQueueCommand ?? (this._showMessageQueueCommand = new DelegateCommand(() => this.ShowMessageQueue()));
            }
        }

        private int i = 0;
        public void ShowMessageQueue()
        {
            WindowBase.ShowMessageQueue($"Welcome to Material Design In XAML Tookit {i++}", "RootWindow");            
        }

        private ICommand _showFlyoutCommand;
        public ICommand ShowFlyoutCommand
        {
            get
            {
                return this._showFlyoutCommand ?? (this._showFlyoutCommand = new DelegateCommand(() => this.ShowFlyout()));
            }
        }

        public void ShowFlyout()
        {
            var flyout = new DynamicFlyout
            {
                Header = "Dynamic flyout"
            };

            // when the flyout is closed, remove it from the hosting FlyoutsControl
            WindowBase.ShowFlyout(flyout, "RootWindow");

        }

        private ICommand _showDialogCommand;
        public ICommand ShowDialogCommand
        {
            get
            {
                return this._showDialogCommand ?? (this._showDialogCommand = new DelegateCommand(() => this.ShowDialog()));
            }
        }

        public async void ShowDialog()
        {
            var dialog = new DialogTest();
            var res = await WindowBase.ShowDialogAsync(dialog, "RootWindow");
        }

        private ICommand _showNormalModalWindowCommand;
        public ICommand ShowNormalModalWindowCommand
        {
            get
            {
                return this._showNormalModalWindowCommand ?? (this._showNormalModalWindowCommand = new DelegateCommand(() => this.ShowNormalModalWindow()));
            }
        }

        public void ShowNormalModalWindow()
        {
            var win = new WindowTest();
            win.Owner = Application.Current.MainWindow;
            win.ShowDialog();
        }

        private ICommand _showNormalWindowCommand;
        public ICommand ShowNormalWindowCommand
        {
            get
            {
                return this._showNormalWindowCommand ?? (this._showNormalWindowCommand = new DelegateCommand(() => this.ShowNormalWindow()));
            }
        }

        public void ShowNormalWindow()
        {
            var win = new WindowTest();
            win.Owner = Application.Current.MainWindow;
            win.Show();
        }

        private ICommand _showNoticeWindowCommand;
        public ICommand ShowNoticeWindowCommand
        {
            get
            {
                return this._showNoticeWindowCommand ?? (this._showNoticeWindowCommand = new DelegateCommand(() => this.ShowNoticeWindow()));
            }
        }

        public void ShowNoticeWindow()
        {
            Notice.Show("This is a notice.This is a notice.This is a notice.This is a notice.This is a notice.This is a notice.", "Notice", 3, MessageBoxIcon.Error);
        }

        private ICommand _showMessageBoxCommand2;
        public ICommand ShowMessageBoxCommand2
        {
            get
            {
                return this._showMessageBoxCommand2 ?? (this._showMessageBoxCommand2 = new DelegateCommand(() => this.ShowMessageBox2()));
            }
        }

        public void ShowMessageBox2()
        {
            Util.Controls.MessageBox.Show("GrowlAsk", "Title", MessageBoxButton.YesNo, MessageBoxImage.Question);
        }


        private ICommand _showHandyMainWindowCommand;
        public ICommand ShowHandyMainWindowCommand
        {
            get
            {
                return this._showHandyMainWindowCommand ?? (this._showHandyMainWindowCommand = new DelegateCommand(() => this.ShowHandyMainWindow()));
            }
        }

        public void ShowHandyMainWindow()
        {
            HandyMainWindow window = new HandyMainWindow();
            window.Show();
        }

        private ICommand _showMessageBoxWindowCommand;
        public ICommand ShowMessageBoxWindowCommand
        {
            get
            {
                return this._showMessageBoxWindowCommand ?? (this._showMessageBoxWindowCommand = new DelegateCommand(() => this.ShowMessageBoxWindow()));
            }
        }

        public void ShowMessageBoxWindow()
        {
            Util.Controls.Handy.Windows.MessageBoxWindow.Show("GrowlAsk", "Title", MessageBoxButton.YesNo, MessageBoxImage.Question);
        }

        private ICommand _showXceedMessageBoxCommand;
        public ICommand ShowXceedMessageBoxCommand
        {
            get
            {
                return this._showXceedMessageBoxCommand ?? (this._showXceedMessageBoxCommand = new DelegateCommand(() => this.ShowXceedMessageBox()));
            }
        }

        public void ShowXceedMessageBox()
        {
            Util.Controls.Xceed.MessageBox.Show("GrowlAsk", "Title", MessageBoxButton.YesNo, MessageBoxImage.Question);
        }


     
    }
}
