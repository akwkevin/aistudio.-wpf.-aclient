using AIStudio.Wpf.DemoPage.Models;
using AIStudio.Wpf.DemoPage.Service;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AIStudio.Wpf.DemoPage.ViewModels
{
    public class CoverViewViewModel : DockWindowViewModel
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

        public CoverViewViewModel()
        {
            DataList = DataService.GetCoverViewDemoDataList();
        }


        private IList<CoverViewDemoModel> _dataList;
        public IList<CoverViewDemoModel> DataList
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
