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
using System.Globalization;
using Util.Controls.Tools.Converter;

namespace AIStudio.Wpf.DemoPage.ViewModels
{
    public class GroupBoxViewModel : DockWindowViewModel
    {
        private ObservableCollection<string> _data;
        public ObservableCollection<string> Data
        {
            get { return _data; }
            set
            {
                if (_data != value)
                {
                    _data = value;
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

        public GroupBoxViewModel()
        {
            DataList = GetComboBoxDemoDataList();
        }

		private void OK()
		{

		}

        private IList<string> _datalist;
        public IList<string> DataList
        {
            get { return _datalist; }
            set
            {
                if (_datalist != value)
                {
                    _datalist = value;
                    RaisePropertyChanged("DataList");
                }
            }
        }
        internal List<string> GetComboBoxDemoDataList()
        {
            var converter = new StringRepeatConverter();
            var list = new List<string>();
            for (var i = 1; i <= 9; i++)
            {
                list.Add($"{converter.Convert("Text", null, i, CultureInfo.CurrentCulture)}{i}");
            }

            return list;
        }

    }

}
