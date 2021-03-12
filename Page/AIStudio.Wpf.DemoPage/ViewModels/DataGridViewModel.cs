using Dataforge.PrismAvalonExtensions.ViewModels;
using AIStudio.Wpf.DemoPage.Models;
using AIStudio.Wpf.DemoPage.Service;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Util.Controls;

namespace AIStudio.Wpf.DemoPage.ViewModels
{
    public class DataGridViewModel : DockWindowViewModel
    {
        private ObservableCollection<IBaseTreeItemViewModel> _data;
        public ObservableCollection<IBaseTreeItemViewModel> Data
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


        public DataGridViewModel()
        {
            Data = BuildDataSource();
            DataList = DataService.GetDemoDataList();
        }

        private ObservableCollection<IBaseTreeItemViewModel> BuildDataSource()
        {
            ObservableCollection<IBaseTreeItemViewModel> People = new ObservableCollection<IBaseTreeItemViewModel>();
            for (int i = 0; i < 5; i++)
            {
                var p1 = new Person("ID" + i.ToString(), "名字" + i.ToString(), i);
                for (int j = 0; j < 3; j++)
                {
                    var p2 = new Person("ID" + i.ToString() + j.ToString(), "名字" + i.ToString() + j.ToString(), j);
                    for (int t = 0; t < 3; t++)
                    {
                        var p3 = new Person("ID" + i.ToString() + j.ToString() + t.ToString(), "名字" + i.ToString() + j.ToString() + t.ToString(), t);
                        p2.AddChild(p3);
                    }
                    p1.AddChild(p2);
                }
                People.Add(p1);
            }
            return People;
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

    class Person : BaseTreeItemViewModel
    {
        private string _id;
        public string Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        private int _number1;
        public int Number1
        {
            get
            {
                return _number1;
            }
            set
            {
                _number1 = value;
            }
        }

        private int _number2;
        public int Number2
        {
            get
            {
                return _number2;
            }
            set
            {
                _number2 = value;
            }
        }

        public Person()
        {
        }
        public Person(string id, string name, int number)
        {
            Id = id;
            Name = name;
            Number1 = number;
            Number2 = number + 10;
        }
    }
}
