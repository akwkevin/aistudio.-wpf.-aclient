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
using AIStudio.Wpf.DemoPage.Service;
using System.Windows;
using System.Windows.Controls;
using Util.Controls;

namespace AIStudio.Wpf.DemoPage.ViewModels
{
    public class StepBarViewModel : Dataforge.PrismAvalonExtensions.ViewModels.DockWindowViewModel
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

        public StepBarViewModel()
        {
            DataList = DataService.GetStepBarDemoDataList();
        }

		private void OK()
		{

		}

        /// <summary>
        ///     数据列表
        /// </summary>
        private IList<StepBarDemoModel> _dataList;

        /// <summary>
        ///     数据列表
        /// </summary>
        public IList<StepBarDemoModel> DataList
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

        /// <summary>
        ///     下一步
        /// </summary>
        public RelayCommand<Panel> NextCmd => new Lazy<RelayCommand<Panel>>(() => new RelayCommand<Panel>(Next)).Value;

        /// <summary>
        ///     上一步
        /// </summary>
        public RelayCommand<Panel> PrevCmd => new Lazy<RelayCommand<Panel>>(() => new RelayCommand<Panel>(Prev)).Value;

        private void Next(Panel panel)
        {
            foreach (var stepBar in panel.FindChildren<StepBar>())
            {
                stepBar.Next();
            }
        }

        private void Prev(Panel panel)
        {
            foreach (var stepBar in panel.FindChildren<StepBar>())
            {
                stepBar.Prev();
            }
        }
    }

}
