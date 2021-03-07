using System;
using System.Windows;
using Util.Controls;
using Util.Controls.Data;

namespace AIStudio.Wpf.DemoPage.Views
{
    public class GrowlDemoViewModel
    {
        private readonly string _token;

        public GrowlDemoViewModel()
        {
            
        }

        public GrowlDemoViewModel(string token)
        {
            _token = token;
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