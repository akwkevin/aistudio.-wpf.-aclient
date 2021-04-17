using System;
using System.Threading.Tasks;
using System.Windows;
using Util.Controls.Handy;
using Prism.Mvvm;
using Util.Controls.Handy.Tools.Extension;

namespace AIStudio.Wpf.DemoPage.Views
{
    public class DialogDemoViewModel : BindableBase
    {
        private string _dialogResult;

        public string DialogResult
        {
            get => _dialogResult;
#if netle40
            set => Set(nameof(DialogResult), ref _dialogResult, value);
#else
            set => SetProperty(ref _dialogResult, value);
#endif
        }

        public RelayCommand ShowTextCmd => new Lazy<RelayCommand>(() =>
            new RelayCommand(ShowText)).Value;

        private void ShowText()
        {
            Dialog.Show(new TextDialog());
        }

#if netle40
        public RelayCommand<bool> ShowInteractiveDialogCmd => new Lazy<RelayCommand<bool>>(() =>
            new RelayCommand<bool>(ShowInteractiveDialog)).Value;

        private void ShowInteractiveDialog(bool withTimer)
        {
            if (!withTimer)
            {
                Dialog.Show<InteractiveDialog>()
                    .Initialize<InteractiveDialogViewModel>(vm => vm.Message = DialogResult)
                    .GetResultAsync<string>().ContinueWith(str => DialogResult = str.Result);
            }
            else
            {
                Dialog.Show<TextDialogWithTimer>(MessageToken.MainWindow).GetResultAsync<string>();
            }
        }
#else
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
#endif

        public RelayCommand NewWindowCmd => new Lazy<RelayCommand>(() =>
            new RelayCommand(() => new DialogDemoWindow
            {
                Owner = Application.Current.MainWindow
            }.Show())).Value;

        public RelayCommand<string> ShowWithTokenCmd => new Lazy<RelayCommand<string>>(() =>
            new RelayCommand<string>(token => Dialog.Show(new TextDialog(), token))).Value;


        
    }
}