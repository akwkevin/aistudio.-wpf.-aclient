using AIStudio.Wpf.DemoPage.Views;
using System;
using System.Threading.Tasks;
using System.Windows;
using Util.Controls.Handy;
using Util.Controls.Handy.Tools.Extension;

namespace AIStudio.Wpf.DemoPage.ViewModels
{
    public class PracticalViewModel : DockWindowViewModel
    {
        private string _dialogResult;

        public string DialogResult
        {
            get { return _dialogResult; }
            set
            {
                if (_dialogResult != value)
                {
                    _dialogResult = value;
                    RaisePropertyChanged("DialogResult");
                }
            }
        }

        public RelayCommand ShowTextCmd => new Lazy<RelayCommand>(() =>
            new RelayCommand(ShowText)).Value;

        private void ShowText()
        {
            Dialog.Show(new TextDialog());
        }

        public RelayCommand<bool> ShowInteractiveDialogCmd => new Lazy<RelayCommand<bool>>(() =>
            new RelayCommand<bool>(async withTimer => await ShowInteractiveDialog(withTimer))).Value;

        private async Task ShowInteractiveDialog(bool withTimer)
        {
            if (!withTimer)
            {
                DialogResult = await Dialog.Show<InteractiveDialog>()
                    .Initialize<InteractiveDialogViewModel>(vm => vm.Message = DialogResult)
                    .GetResultAsync<string>();
            }
            else
            {
                await Dialog.Show<TextDialogWithTimer>("MainWindow").GetResultAsync<string>();
            }
        }

        public RelayCommand NewWindowCmd => new Lazy<RelayCommand>(() =>
            new RelayCommand(() => new DialogDemoWindow
            {
                Owner = Application.Current.MainWindow
            }.Show())).Value;

        public RelayCommand<string> ShowWithTokenCmd => new Lazy<RelayCommand<string>>(() =>
            new RelayCommand<string>(token => Dialog.Show(new TextDialog(), token))).Value;
    }
}
