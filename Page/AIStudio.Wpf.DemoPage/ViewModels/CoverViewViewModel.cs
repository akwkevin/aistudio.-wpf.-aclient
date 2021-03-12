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
using AIStudio.Wpf.DemoPage.Service;
using AIStudio.Wpf.DemoPage.Models;

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
