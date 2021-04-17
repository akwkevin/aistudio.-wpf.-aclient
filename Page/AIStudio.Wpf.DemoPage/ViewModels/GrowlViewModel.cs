using AIStudio.Wpf.DemoPage.Views;
using Prism.Commands;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using Util.Controls.Handy;
using Util.Controls.Handy.Data;

namespace AIStudio.Wpf.DemoPage.ViewModels
{
    public class GrowlViewModel : DockWindowViewModel
    {
        private ObservableCollection<string> data;
        public ObservableCollection<string> Data
        {
            get { return data; }
            set
            {
                if (data != value)
                {
                    data = value;
                    RaisePropertyChanged("Data");
                }
            }
        }

		private ICommand okCommand;
        public ICommand OKCommand
        {
            get
            {
                return this.okCommand ?? (this.okCommand = new DelegateCommand(() => this.OK()));
            }
        }

		private void OK()
		{

		}

        private readonly string _token;



        public GrowlViewModel()
        {

        }

        #region Window

        public RelayCommand InfoCmd => new Lazy<RelayCommand>(() =>
            new RelayCommand(() => Growl.Info("GrowlInfo", _token))).Value;

        public RelayCommand SuccessCmd => new Lazy<RelayCommand>(() =>
            new RelayCommand(() => Growl.Success("GrowlSuccess", _token))).Value;

        public RelayCommand WarningCmd => new Lazy<RelayCommand>(() =>
            new RelayCommand(() => Growl.Warning(new GrowlInfo
            {
                Message = "GrowlWarning",
                CancelStr = "Ignore",
                ActionBeforeClose = isConfirmed =>
                {
                    Growl.Info(isConfirmed.ToString());
                    return true;
                },
                Token = _token
            }))).Value;

        public RelayCommand ErrorCmd => new Lazy<RelayCommand>(() =>
            new RelayCommand(() => Growl.Error("GrowlError", _token))).Value;

        public RelayCommand AskCmd => new Lazy<RelayCommand>(() =>
            new RelayCommand(() => Growl.Ask("GrowlAsk", isConfirmed =>
            {
                Growl.Info(isConfirmed.ToString());
                return true;
            }, _token))).Value;

        public RelayCommand FatalCmd => new Lazy<RelayCommand>(() =>
            new RelayCommand(() => Growl.Fatal(new GrowlInfo
            {
                Message = "GrowlFatal",
                ShowDateTime = false,
                Token = _token
            }))).Value;

        public RelayCommand ClearCmd => new Lazy<RelayCommand>(() =>
            new RelayCommand(() => Growl.Clear(_token))).Value;

        #endregion

        #region Desktop

        public RelayCommand InfoGlobalCmd => new Lazy<RelayCommand>(() =>
            new RelayCommand(() => Growl.InfoGlobal("GrowlInfo"))).Value;

        public RelayCommand SuccessGlobalCmd => new Lazy<RelayCommand>(() =>
            new RelayCommand(() => Growl.SuccessGlobal("GrowlSuccess"))).Value;

        public RelayCommand WarningGlobalCmd => new Lazy<RelayCommand>(() =>
            new RelayCommand(() => Growl.WarningGlobal(new GrowlInfo
            {
                Message = "GrowlWarning",
                CancelStr = "Ignore",
                ActionBeforeClose = isConfirmed =>
                {
                    Growl.InfoGlobal(isConfirmed.ToString());
                    return true;
                }
            }))).Value;

        public RelayCommand ErrorGlobalCmd => new Lazy<RelayCommand>(() =>
            new RelayCommand(() => Growl.ErrorGlobal("GrowlError"))).Value;

        public RelayCommand AskGlobalCmd => new Lazy<RelayCommand>(() =>
            new RelayCommand(() => Growl.AskGlobal("GrowlAsk", isConfirmed =>
            {
                Growl.InfoGlobal(isConfirmed.ToString());
                return true;
            }))).Value;

        public RelayCommand FatalGlobalCmd => new Lazy<RelayCommand>(() =>
            new RelayCommand(() => Growl.FatalGlobal(new GrowlInfo
            {
                Message = "GrowlFatal",
                ShowDateTime = false
            }))).Value;

        public RelayCommand ClearGlobalCmd => new Lazy<RelayCommand>(() =>
            new RelayCommand(Growl.ClearGlobal)).Value;

        #endregion

        public RelayCommand NewWindowCmd => new Lazy<RelayCommand>(() =>
            new RelayCommand(() => new GrowlDemoWindow
            {
                Owner = Application.Current.MainWindow
            }.Show())).Value;
    }

}
