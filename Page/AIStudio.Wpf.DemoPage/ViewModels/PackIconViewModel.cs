using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Util.Controls;

namespace AIStudio.Wpf.DemoPage.ViewModels
{
    public class PackIconViewModel : DockWindowViewModel
    {
        private readonly Lazy<IEnumerable<PackIconKind>> _packIconKinds;

        public PackIconViewModel()
        {
            _packIconKinds = new Lazy<IEnumerable<PackIconKind>>(() =>
                Enum.GetValues(typeof(PackIconKind)).OfType<PackIconKind>()
                    .OrderBy(k => k.ToString(), StringComparer.InvariantCultureIgnoreCase).ToList()
                );
        }

        private ICommand searchCommand;
        public ICommand SearchCommand
        {
            get
            {
                return this.searchCommand ?? (this.searchCommand = new DelegateCommand<object>(para => this.Search(para)));
            }
        }

        private ICommand copyToClipboardCommand;
        public ICommand CopyToClipboardCommand
        {
            get
            {
                return this.copyToClipboardCommand ?? (this.copyToClipboardCommand = new DelegateCommand<object>(para => this.CopyToClipboard(para)));
            }
        }


        private IEnumerable<PackIconKind> _kinds;
        public IEnumerable<PackIconKind> Kinds
        {
            get { return _kinds ?? (_kinds = _packIconKinds.Value); }
            set
            {
                _kinds = value;
                RaisePropertyChanged("Kinds");
            }
        }


        private void Search(object obj)
        {
            var text = obj as string;
            if (string.IsNullOrWhiteSpace(text))
                Kinds = _packIconKinds.Value;
            else
                Kinds =
                    _packIconKinds.Value.Where(
                        x => x.ToString().IndexOf(text, StringComparison.CurrentCultureIgnoreCase) >= 0);
        }

        private void CopyToClipboard(object obj)
        {
            var kind = (PackIconKind?)obj;
            string toBeCopied = $"<util:PackIcon Kind=\"{kind}\" />";
            Clipboard.SetDataObject(toBeCopied);
            WindowBase.ShowMessageQueue(toBeCopied + " copied to clipboard", "RootWindow");
        }
    }
}
