using Prism.Commands;
using Svg2XamlTestExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Util.Controls;

namespace AIStudio.Wpf.DemoPage.ViewModels
{
    public class SvgIconViewModel : DockWindowViewModel
    {
        private readonly IEnumerable<Tuple<string, string>> _packIconKinds;
        public SvgIconViewModel()
        {
            _packIconKinds = PackSvg.DataIndex.Value.Keys.Select(p => new Tuple<string, string>(p.Item1, p.Item2));
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


        private IEnumerable<Tuple<string, string>> _kinds;
        public IEnumerable<Tuple<string, string>> Kinds
        {
            get { return _kinds ?? (_kinds = _packIconKinds); }
            set
            {
                _kinds = value;
                RaisePropertyChanged("Kinds");
            }
        }

        private Tuple<string, string> _selectedKind;
        public Tuple<string, string> SelectedKind
        {
            get { return _selectedKind; }
            set
            {
                _selectedKind = value;
                RaisePropertyChanged("SelectedKind");
            }
        }       


        private void Search(object obj)
        {
            var text = obj as string;
            if (string.IsNullOrWhiteSpace(text))
                Kinds = _packIconKinds;
            else
                Kinds =
                    _packIconKinds.Where(
                        x => x.ToString().IndexOf(text, StringComparison.CurrentCultureIgnoreCase) >= 0);
        }

        private void CopyToClipboard(object obj)
        {
            var kind = (Tuple<string, string>)obj;
            string toBeCopied = $"<svg:PackSvg Theme=\"{kind.Item1}\" Kind=\"{kind.Item2}\" />";
            Clipboard.SetDataObject(toBeCopied);
            WindowBase.ShowMessageQueue(toBeCopied + " copied to clipboard", "RootWindow");
        }

    }

}
