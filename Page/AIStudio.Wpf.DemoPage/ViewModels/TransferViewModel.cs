using AIStudio.Wpf.DemoPage.Models;
using AIStudio.Wpf.DemoPage.Service;
using Prism.Commands;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace AIStudio.Wpf.DemoPage.ViewModels
{
    public class TransferViewModel : DockWindowViewModel
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

        public TransferViewModel()
        {
            DataList = DataService.GetDemoDataList();
        }

		private void OK()
		{

		}

        private IList<DemoDataModel> _dataList;
        public IList<DemoDataModel> DataList
        {
            get { return _dataList; }
            set
            {
                if (_dataList != value)
                {
                    _dataList = value;
                    RaisePropertyChanged("DataList");
                }
            }
        }

    }

}
