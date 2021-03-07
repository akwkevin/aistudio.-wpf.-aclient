﻿using Dataforge.PrismAvalonExtensions.ViewModels;
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
using Util.Controls;
using System.Collections;

namespace AIStudio.Wpf.DemoPage.ViewModels
{
    public class ComboBoxViewModel : DockWindowViewModel
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

        private IBaseTreeItemViewModel _selectedData;
        public IBaseTreeItemViewModel SelectedData
        {
            get { return _selectedData; }
            set
            {
                if (_selectedData != value)
                {
                    _selectedData = value;
                    RaisePropertyChanged("SelectedData");
                }
            }
        }

        private ObservableCollection<IBaseTreeItemViewModel> _selectedDatas = new ObservableCollection<IBaseTreeItemViewModel>();
        public ObservableCollection<IBaseTreeItemViewModel> SelectedDatas
        {
            get { return _selectedDatas; }
            set
            {
                if (_selectedDatas != value)
                {
                    _selectedDatas = value;
                    RaisePropertyChanged("SelectedDatas");
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

        public ComboBoxViewModel()
        {
            Data = BuildDataSource();
            SelectedData = Data[2].Children[2].Children[2];
            SelectedDatas.Add(SelectedData);
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

            DataList = DataService.GetComboBoxDemoDataList();


        }

        private ObservableCollection<IBaseTreeItemViewModel> BuildDataSource()
        {
            ObservableCollection<IBaseTreeItemViewModel> People = new ObservableCollection<IBaseTreeItemViewModel>();
            for (int i = 0; i < 5; i++)
            {
                var p1 = new Person("ID" + i.ToString(), "Name" + i.ToString(), i);
                for (int j = 0; j < 3; j++)
                {
                    var p2 = new Person("ID" + i.ToString() + j.ToString(), "Name" + i.ToString() + j.ToString(), j);
                    for (int t = 0; t < 3; t++)
                    {
                        var p3 = new Person("ID" + i.ToString() + j.ToString() + t.ToString(), "Name" + i.ToString() + j.ToString() + t.ToString(), t);
                        p2.AddChild(p3);
                    }
                    p1.AddChild(p2);
                }
                People.Add(p1);
            }
            return People;
        }

        private void OK()
		{

		}

        private IList<string> _dataList;
        public IList<string> DataList
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


    }

}
