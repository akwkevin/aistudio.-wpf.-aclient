using Dataforge.PrismAvalonExtensions.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Controls.Commands;
using System.Windows.Input;
using System.Windows;
using Util.Controls;

namespace AIStudio.Wpf.DemoPage.ViewModels
{
    public class FIconViewModel : DockWindowViewModel
    {
        private readonly List<Tuple<string, string>> _packIconKinds;
        public FIconViewModel()
        {
            _packIconKinds = new List<Tuple<string, string>>();
            _packIconKinds.Add(new Tuple<string, string>("\ue600", "e600"));
            _packIconKinds.Add(new Tuple<string, string>("\ue601", "e601"));
            _packIconKinds.Add(new Tuple<string, string>("\ue602", "e602"));
            _packIconKinds.Add(new Tuple<string, string>("\ue603", "e603"));
            _packIconKinds.Add(new Tuple<string, string>("\ue604", "e604"));
            _packIconKinds.Add(new Tuple<string, string>("\ue605", "e605"));
            _packIconKinds.Add(new Tuple<string, string>("\ue606", "e606"));
            _packIconKinds.Add(new Tuple<string, string>("\ue607", "e607"));
            _packIconKinds.Add(new Tuple<string, string>("\ue608", "e608"));
            _packIconKinds.Add(new Tuple<string, string>("\ue609", "e609"));
            _packIconKinds.Add(new Tuple<string, string>("\ue60a", "e60a"));
            _packIconKinds.Add(new Tuple<string, string>("\ue60b", "e60b"));
            _packIconKinds.Add(new Tuple<string, string>("\ue60c", "e60c"));
            _packIconKinds.Add(new Tuple<string, string>("\ue60d", "e60d"));
            _packIconKinds.Add(new Tuple<string, string>("\ue60e", "e60e"));
            _packIconKinds.Add(new Tuple<string, string>("\ue60f", "e60f"));
            _packIconKinds.Add(new Tuple<string, string>("\ue610", "e610"));
            _packIconKinds.Add(new Tuple<string, string>("\ue611", "e611"));
            _packIconKinds.Add(new Tuple<string, string>("\ue612", "e612"));
            _packIconKinds.Add(new Tuple<string, string>("\ue613", "e613"));
            _packIconKinds.Add(new Tuple<string, string>("\ue614", "e614"));
            _packIconKinds.Add(new Tuple<string, string>("\ue615", "e615"));
            _packIconKinds.Add(new Tuple<string, string>("\ue616", "e616"));
            _packIconKinds.Add(new Tuple<string, string>("\ue617", "e617"));
            _packIconKinds.Add(new Tuple<string, string>("\ue618", "e618"));
            _packIconKinds.Add(new Tuple<string, string>("\ue619", "e619"));
            _packIconKinds.Add(new Tuple<string, string>("\ue61a", "e61a"));
            _packIconKinds.Add(new Tuple<string, string>("\ue61b", "e61b"));
            _packIconKinds.Add(new Tuple<string, string>("\ue61c", "e61c"));
            _packIconKinds.Add(new Tuple<string, string>("\ue61d", "e61d"));
            _packIconKinds.Add(new Tuple<string, string>("\ue61e", "e61e"));
            _packIconKinds.Add(new Tuple<string, string>("\ue61f", "e61f"));
            _packIconKinds.Add(new Tuple<string, string>("\ue620", "e620"));
            _packIconKinds.Add(new Tuple<string, string>("\ue621", "e621"));
            _packIconKinds.Add(new Tuple<string, string>("\ue622", "e622"));
            _packIconKinds.Add(new Tuple<string, string>("\ue623", "e623"));
            _packIconKinds.Add(new Tuple<string, string>("\ue624", "e624"));
            _packIconKinds.Add(new Tuple<string, string>("\ue625", "e625"));
            _packIconKinds.Add(new Tuple<string, string>("\ue626", "e626"));
            _packIconKinds.Add(new Tuple<string, string>("\ue627", "e627"));
            _packIconKinds.Add(new Tuple<string, string>("\ue628", "e628"));
            _packIconKinds.Add(new Tuple<string, string>("\ue629", "e629"));
            _packIconKinds.Add(new Tuple<string, string>("\ue62a", "e62a"));
            _packIconKinds.Add(new Tuple<string, string>("\ue62b", "e62b"));
            _packIconKinds.Add(new Tuple<string, string>("\ue62c", "e62c"));
            _packIconKinds.Add(new Tuple<string, string>("\ue62d", "e62d"));
            _packIconKinds.Add(new Tuple<string, string>("\ue62e", "e62e"));
            _packIconKinds.Add(new Tuple<string, string>("\ue62f", "e62f"));
            _packIconKinds.Add(new Tuple<string, string>("\ue630", "e630"));
            _packIconKinds.Add(new Tuple<string, string>("\ue631", "e631"));
            _packIconKinds.Add(new Tuple<string, string>("\ue632", "e632"));
            _packIconKinds.Add(new Tuple<string, string>("\ue633", "e633"));
            _packIconKinds.Add(new Tuple<string, string>("\ue634", "e634"));
            _packIconKinds.Add(new Tuple<string, string>("\ue635", "e635"));
            _packIconKinds.Add(new Tuple<string, string>("\ue636", "e636"));
            _packIconKinds.Add(new Tuple<string, string>("\ue637", "e637"));
            _packIconKinds.Add(new Tuple<string, string>("\ue638", "e638"));
            _packIconKinds.Add(new Tuple<string, string>("\ue639", "e639"));
            _packIconKinds.Add(new Tuple<string, string>("\ue63a", "e63a"));
            _packIconKinds.Add(new Tuple<string, string>("\ue63b", "e63b"));
            _packIconKinds.Add(new Tuple<string, string>("\ue63c", "e63c"));
            _packIconKinds.Add(new Tuple<string, string>("\ue63d", "e63d"));
            _packIconKinds.Add(new Tuple<string, string>("\ue63e", "e63e"));
            _packIconKinds.Add(new Tuple<string, string>("\ue63f", "e63f"));
            _packIconKinds.Add(new Tuple<string, string>("\ue640", "e640"));
            _packIconKinds.Add(new Tuple<string, string>("\ue641", "e641"));
            _packIconKinds.Add(new Tuple<string, string>("\ue642", "e642"));
            _packIconKinds.Add(new Tuple<string, string>("\ue643", "e643"));
            _packIconKinds.Add(new Tuple<string, string>("\ue644", "e644"));
            _packIconKinds.Add(new Tuple<string, string>("\ue645", "e645"));
            _packIconKinds.Add(new Tuple<string, string>("\ue646", "e646"));
            _packIconKinds.Add(new Tuple<string, string>("\ue647", "e647"));
            _packIconKinds.Add(new Tuple<string, string>("\ue648", "e648"));
            _packIconKinds.Add(new Tuple<string, string>("\ue649", "e649"));
            _packIconKinds.Add(new Tuple<string, string>("\ue64a", "e64a"));
            _packIconKinds.Add(new Tuple<string, string>("\ue64b", "e64b"));
            _packIconKinds.Add(new Tuple<string, string>("\ue64c", "e64c"));
            _packIconKinds.Add(new Tuple<string, string>("\ue64d", "e64d"));
            _packIconKinds.Add(new Tuple<string, string>("\ue64e", "e64e"));
            _packIconKinds.Add(new Tuple<string, string>("\ue64f", "e64f"));
            _packIconKinds.Add(new Tuple<string, string>("\ue650", "e650"));
            _packIconKinds.Add(new Tuple<string, string>("\ue651", "e651"));
            _packIconKinds.Add(new Tuple<string, string>("\ue652", "e652"));
            _packIconKinds.Add(new Tuple<string, string>("\ue653", "e653"));
            _packIconKinds.Add(new Tuple<string, string>("\ue654", "e654"));
            _packIconKinds.Add(new Tuple<string, string>("\ue655", "e655"));
            _packIconKinds.Add(new Tuple<string, string>("\ue656", "e656"));
            _packIconKinds.Add(new Tuple<string, string>("\ue657", "e657"));
            _packIconKinds.Add(new Tuple<string, string>("\ue658", "e658"));
            _packIconKinds.Add(new Tuple<string, string>("\ue659", "e659"));
            _packIconKinds.Add(new Tuple<string, string>("\ue65a", "e65a"));
            _packIconKinds.Add(new Tuple<string, string>("\ue65b", "e65b"));
            _packIconKinds.Add(new Tuple<string, string>("\ue65c", "e65c"));
            _packIconKinds.Add(new Tuple<string, string>("\ue65d", "e65d"));
            _packIconKinds.Add(new Tuple<string, string>("\ue65e", "e65e"));
            _packIconKinds.Add(new Tuple<string, string>("\ue65f", "e65f"));
            _packIconKinds.Add(new Tuple<string, string>("\ue660", "e660"));
            _packIconKinds.Add(new Tuple<string, string>("\ue661", "e661"));
            _packIconKinds.Add(new Tuple<string, string>("\ue662", "e662"));
            _packIconKinds.Add(new Tuple<string, string>("\ue663", "e663"));
            _packIconKinds.Add(new Tuple<string, string>("\ue664", "e664"));
            _packIconKinds.Add(new Tuple<string, string>("\ue665", "e665"));
            _packIconKinds.Add(new Tuple<string, string>("\ue666", "e666"));
            _packIconKinds.Add(new Tuple<string, string>("\ue667", "e667"));
            _packIconKinds.Add(new Tuple<string, string>("\ue668", "e668"));
            _packIconKinds.Add(new Tuple<string, string>("\ue669", "e669"));
            _packIconKinds.Add(new Tuple<string, string>("\ue66a", "e66a"));
            _packIconKinds.Add(new Tuple<string, string>("\ue66b", "e66b"));
            _packIconKinds.Add(new Tuple<string, string>("\ue66c", "e66c"));
            _packIconKinds.Add(new Tuple<string, string>("\ue66d", "e66d"));
            _packIconKinds.Add(new Tuple<string, string>("\ue66e", "e66e"));
            _packIconKinds.Add(new Tuple<string, string>("\ue66f", "e66f"));
            _packIconKinds.Add(new Tuple<string, string>("\ue670", "e670"));
            _packIconKinds.Add(new Tuple<string, string>("\ue671", "e671"));
            _packIconKinds.Add(new Tuple<string, string>("\ue672", "e672"));
            _packIconKinds.Add(new Tuple<string, string>("\ue673", "e673"));
            _packIconKinds.Add(new Tuple<string, string>("\ue674", "e674"));
            _packIconKinds.Add(new Tuple<string, string>("\ue675", "e675"));
            _packIconKinds.Add(new Tuple<string, string>("\ue676", "e676"));
            _packIconKinds.Add(new Tuple<string, string>("\ue677", "e677"));
            _packIconKinds.Add(new Tuple<string, string>("\ue678", "e678"));
            _packIconKinds.Add(new Tuple<string, string>("\ue679", "e679"));
            _packIconKinds.Add(new Tuple<string, string>("\ue67a", "e67a"));
            _packIconKinds.Add(new Tuple<string, string>("\ue67b", "e67b"));
            _packIconKinds.Add(new Tuple<string, string>("\ue67c", "e67c"));
            _packIconKinds.Add(new Tuple<string, string>("\ue67d", "e67d"));
            _packIconKinds.Add(new Tuple<string, string>("\ue67e", "e67e"));
            _packIconKinds.Add(new Tuple<string, string>("\ue67f", "e67f"));
            _packIconKinds.Add(new Tuple<string, string>("\ue680", "e680"));
            _packIconKinds.Add(new Tuple<string, string>("\ue681", "e681"));
            _packIconKinds.Add(new Tuple<string, string>("\ue682", "e682"));
            _packIconKinds.Add(new Tuple<string, string>("\ue683", "e683"));
            _packIconKinds.Add(new Tuple<string, string>("\ue684", "e684"));
            _packIconKinds.Add(new Tuple<string, string>("\ue685", "e685"));
            _packIconKinds.Add(new Tuple<string, string>("\ue686", "e686"));
            _packIconKinds.Add(new Tuple<string, string>("\ue687", "e687"));
            _packIconKinds.Add(new Tuple<string, string>("\ue688", "e688"));
            _packIconKinds.Add(new Tuple<string, string>("\ue689", "e689"));
            _packIconKinds.Add(new Tuple<string, string>("\ue68a", "e68a"));
            _packIconKinds.Add(new Tuple<string, string>("\ue68b", "e68b"));
            _packIconKinds.Add(new Tuple<string, string>("\ue68c", "e68c"));
            _packIconKinds.Add(new Tuple<string, string>("\ue68d", "e68d"));
            _packIconKinds.Add(new Tuple<string, string>("\ue68e", "e68e"));
            _packIconKinds.Add(new Tuple<string, string>("\ue68f", "e68f"));
            _packIconKinds.Add(new Tuple<string, string>("\ue690", "e690"));
            _packIconKinds.Add(new Tuple<string, string>("\ue691", "e691"));
            _packIconKinds.Add(new Tuple<string, string>("\ue692", "e692"));
            _packIconKinds.Add(new Tuple<string, string>("\ue693", "e693"));
            _packIconKinds.Add(new Tuple<string, string>("\ue694", "e694"));
            _packIconKinds.Add(new Tuple<string, string>("\ue695", "e695"));
            _packIconKinds.Add(new Tuple<string, string>("\ue696", "e696"));
            _packIconKinds.Add(new Tuple<string, string>("\ue697", "e697"));
            _packIconKinds.Add(new Tuple<string, string>("\ue698", "e698"));
            _packIconKinds.Add(new Tuple<string, string>("\ue699", "e699"));
            _packIconKinds.Add(new Tuple<string, string>("\ue69a", "e69a"));
            _packIconKinds.Add(new Tuple<string, string>("\ue69b", "e69b"));
            _packIconKinds.Add(new Tuple<string, string>("\ue69c", "e69c"));
            _packIconKinds.Add(new Tuple<string, string>("\ue69d", "e69d"));
            _packIconKinds.Add(new Tuple<string, string>("\ue69e", "e69e"));
            _packIconKinds.Add(new Tuple<string, string>("\ue69f", "e69f"));
            _packIconKinds.Add(new Tuple<string, string>("\ue6a0", "e6a0"));
            _packIconKinds.Add(new Tuple<string, string>("\ue6a1", "e6a1"));
            _packIconKinds.Add(new Tuple<string, string>("\ue6a2", "e6a2"));
            _packIconKinds.Add(new Tuple<string, string>("\ue6a3", "e6a3"));
            _packIconKinds.Add(new Tuple<string, string>("\ue6a4", "e6a4"));
            _packIconKinds.Add(new Tuple<string, string>("\ue6a5", "e6a5"));
            _packIconKinds.Add(new Tuple<string, string>("\ue6a6", "e6a6"));
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
            string toBeCopied = $"<TextBlock Text=\"\\u{kind.Item2}\"  Style = \"{{StaticResource FIcon}}\" />";
            Clipboard.SetDataObject(toBeCopied);
            WindowBase.ShowMessageQueue(toBeCopied + " copied to clipboard", "RootWindow");
        }

    }

}
