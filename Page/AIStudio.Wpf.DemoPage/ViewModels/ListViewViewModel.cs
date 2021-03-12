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
using AIStudio.Wpf.DemoPage.Models;
using Util.Controls.Data;
using AIStudio.Wpf.DemoPage.Service;

namespace AIStudio.Wpf.DemoPage.ViewModels
{
    public class ListViewViewModel : DockWindowViewModel
    {
        private ObservableCollection<Device> data;
        public ObservableCollection<Device> Data
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

        public ListViewViewModel()
        {
            DataList = DataService.GetDemoDataList();
            List<Device> ds = new List<Device>();
            for (int i = 0; i < 10; i++)
            {
                var d1 = new Device()
                {
                    Name = "MX33333333333333333333333331_" + i,
                    Manufacturer = "Meizu--" + i,
                    Mode = "M303",
                    OSType = EnumOSType.Android,
                    State = EnumDeviceState.Online,
                    Version = "4,2,1",
                    SerialNumber = "0123456789",
                    IsRoot = true,
                };
                ds.Add(d1);
            }

            Data = new ObservableCollection<Device>(ds);
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
