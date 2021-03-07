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
    public class ListBoxViewModel : DockWindowViewModel
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

        private ObservableCollection<Person2> _person;
        public ObservableCollection<Person2> Person
        {
            get { return _person; }
            set
            {
                if (_person != value)
                {
                    _person = value;
                    RaisePropertyChanged("Person");
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

        public ListBoxViewModel()
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

            Person = new ObservableCollection<Person2>()
            {
                new Person2(){ID=101, FirstName="John", LastName="Smith"},
                new Person2(){ID=102, FirstName="Janel", LastName="Leverling"},
                new Person2(){ID=103, FirstName="Laura", LastName="Callahan"},
                new Person2(){ID=104, FirstName="Robert", LastName="King"},
                new Person2(){ID=105, FirstName="Margaret", LastName="Peacock"},
                new Person2(){ID=106, FirstName="Andrew", LastName="Fuller"},
                new Person2(){ID=107, FirstName="Anne", LastName="Dodsworth"},
                new Person2(){ID=108, FirstName="Nancy", LastName="Davolio"},
                new Person2(){ID=109, FirstName="Naomi", LastName="Suyama"},
            };

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

    public class Device
    {
        public string Name { get; set; }
        public string Mode { get; set; }
        public string Manufacturer { get; set; }
        public string SerialNumber { get; set; }
        public EnumOSType OSType { get; set; }
        public EnumDeviceState State { get; set; }
        //public string StateDesc { get { return this.State.GetDescription(); } }
        public string Version { get; set; }
        public bool IsRoot { get; set; }
        public string IsRootDesc { get { return this.IsRoot ? "已Root" : "未Root"; } }

        public override string ToString()
        {
            return this.Name;
        }
    }

    public enum EnumOSType
    {
        [Description("IOS")]
        IOS = 1,
        [Description("Android")]
        Android = 2,
    }

    public enum EnumDeviceState
    {
        [Description("在线")]
        Online = 1,
        [Description("离线")]
        Offline = 2,
        [Description("正忙")]
        Busy = 3,
    }



    public class Person2 : INotifyPropertyChanged
    {
        private bool _isSelected;
        private int _ID;
        private string _firstName;
        private string _lastName;

        public bool IsSelected
        {
            get
            {
                return _isSelected;
            }
            set
            {
                _isSelected = value;
                RaisePropertyChanged("IsSelected");
            }
        }

        public int ID
        {
            get
            {
                return _ID;
            }
            set
            {
                _ID = value;
                RaisePropertyChanged("ID");
            }
        }

        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
                RaisePropertyChanged("FirstName");
            }
        }

        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
                RaisePropertyChanged("LastName");
            }
        }

        public string ModelDisplay
        {
            get
            {
                string completeName = string.Format("{0} {1}", FirstName, LastName).PadRight(20);
                return string.Format(
                  "ID={0}: Name= {1}, IsSelected= {2}",
                  ID,
                  completeName,
                  IsSelected);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                PropertyChanged(this, new PropertyChangedEventArgs("ModelDisplay"));
            }
        }
    }
}
