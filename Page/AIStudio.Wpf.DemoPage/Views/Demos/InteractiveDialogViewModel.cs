using System;
using System.Windows;
using Util.Controls.Bindings;
using Util.Controls.Tools.Extension;

namespace AIStudio.Wpf.DemoPage.Views
{
    public class InteractiveDialogViewModel : BindableBase, IDialogResultable<string>
    {
        public Action CloseAction { get; set; }

        private string _result;

        public string Result
        {
            get => _result;
#if netle40
            set => Set(nameof(Result), ref _result, value);
#else
            set => SetProperty(ref _result, value);
#endif
        }

        private string _message;

        public string Message
        {
            get => _message;
#if netle40
            set => Set(nameof(Message), ref _message, value);
#else
            set => SetProperty(ref _message, value);
#endif
        }

        public RelayCommand CloseCmd => new Lazy<RelayCommand>(() => new RelayCommand(() => CloseAction?.Invoke())).Value;
    }
}
