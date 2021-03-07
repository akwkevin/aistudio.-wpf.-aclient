using AIStudio.Wpf.DemoPage.Models;
using AIStudio.Wpf.DemoPage.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Util.Controls;
using Util.Controls.Commands;
using Util.Controls.Data;

namespace AIStudio.Wpf.DemoPage.ViewModels
{
    public class PaginationViewModel : Dataforge.PrismAvalonExtensions.ViewModels.DockWindowViewModel
    {
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

        private IList<DemoDataModel> _dataList2;
        public IList<DemoDataModel> DataList2
        {
            get { return _dataList2; }
            set
            {
                if (_dataList2 != value)
                {
                    _dataList2 = value;
                    RaisePropertyChanged("DataList2");
                }
            }
        }

        /// <summary>
        ///     所有数据
        /// </summary>
        private readonly List<DemoDataModel> _totalDataList;

        /// <summary>
        ///     页码
        /// </summary>
        private int _pageIndex = 1;

        /// <summary>
        ///     页码
        /// </summary>
        public int PageIndex
        {
            get { return _pageIndex; }
            set
            {
                if (_pageIndex != value)
                {
                    _pageIndex = value;
                    RaisePropertyChanged("PageIndex");
                }
            }
        }

        /// <summary>
        ///     页码
        /// </summary>
        private int _pageIndex2 = 1;

        /// <summary>
        ///     页码
        /// </summary>
        public int PageIndex2
        {
            get { return _pageIndex2; }
            set
            {
                if (_pageIndex2 != value)
                {
                    _pageIndex2 = value;
                    RaisePropertyChanged("PageIndex2");
                }
            }
        }

        public PaginationViewModel()
        {
            _totalDataList = DataService.GetDemoDataList(100);
            DataList = _totalDataList.Take(10).ToList();
            DataList2 = _totalDataList.Take(10).ToList();
        }

        /// <summary>
        ///     页码改变命令
        /// </summary>
        public RelayCommand<FunctionEventArgs<int>> PageUpdatedCmd =>
            new Lazy<RelayCommand<FunctionEventArgs<int>>>(() =>
                new RelayCommand<FunctionEventArgs<int>>(PageUpdated)).Value;

        /// <summary>
        ///     页码改变
        /// </summary>
        private void PageUpdated(FunctionEventArgs<int> info)
        {
            DataList = _totalDataList.Skip((info.Info - 1) * 10).Take(10).ToList();
        }


        private ICommand _currentIndexChangedComamnd;
        public ICommand CurrentIndexChangedComamnd
        {
            get
            {
                return this._currentIndexChangedComamnd ?? (this._currentIndexChangedComamnd = new DelegateCommand<RoutedEventArgs>(para => this.CurrentIndexChanged(para)));
            }
        }

        public void CurrentIndexChanged(RoutedEventArgs para)
        {
            var args = para as CurrentIndexChangedEventArgs;
            if (args != null)
            {
                DataList2 = _totalDataList.Skip((args.CurrentIndex - 1) * 10).Take(10).ToList();
            }
        }
    }
}
