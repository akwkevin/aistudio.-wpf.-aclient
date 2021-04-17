using AIStudio.Wpf.DemoPage.Models;
using AIStudio.Wpf.DemoPage.Service;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Util.Controls.Handy;

namespace AIStudio.Wpf.DemoPage.Views
{
    public class HandyWindowViewModel: BindableBase
    {
        public HandyWindowViewModel()
        {           
            DataList = DataService.GetDemoDataList();
            DemoInfoList = DataService.GetDemoInfo();
            OpenPracticalDemo();
            NoUserViewModel = new NoUserViewModel();
            NoUserViewModel.LoadShowContent += LoadShowContent;
        }

        public NoUserViewModel NoUserViewModel { get; set; }

        #region 属性

        /// <summary>
        ///     当前选中的demo项
        /// </summary>
        public DemoItemModel DemoItemCurrent { get; private set; }

        public DemoInfoModel DemoInfoCurrent { get; set; }


        private object _subContent;
        /// <summary>
        ///     子内容
        /// </summary>
        public object SubContent
        {
            get => _subContent;
            set => SetProperty(ref _subContent, value);
        }

        private object _contentTitle;
        /// <summary>
        ///     内容标题
        /// </summary>
        public object ContentTitle
        {
            get => _contentTitle;
            set => SetProperty(ref _contentTitle, value);
        }

        private object _targetCtlName;
        /// <summary>
        ///     内容标题
        /// </summary>
        public object TargetCtlName
        {
            get => _targetCtlName;
            set => SetProperty(ref _targetCtlName, value);
        }

        private bool _isFull;
        /// <summary>
        ///    全屏
        /// </summary>
        public bool IsFull
        {
            get => _isFull;
            set => SetProperty(ref _isFull, value);
        }

        private List<DemoInfoModel> _demoInfoList;
        /// <summary>
        ///     demo信息
        /// </summary>
        public List<DemoInfoModel> DemoInfoList
        {
            get => _demoInfoList;
#if netle40
            set => Set(nameof(DemoInfoList), ref _demoInfoList, value);
#else
            set => SetProperty(ref _demoInfoList, value);
#endif
        }

        private IList<DemoDataModel> _dataList;
        /// <summary>
        ///     数据列表
        /// </summary>
        public IList<DemoDataModel> DataList
        {
            get => _dataList;
            set => SetProperty(ref _dataList, value);      
        }

        #endregion

        #region 命令

        /// <summary>
        ///     切换例子命令
        /// </summary>
        public RelayCommand<SelectionChangedEventArgs> SwitchDemoCmd =>
            new Lazy<RelayCommand<SelectionChangedEventArgs>>(() =>
                new RelayCommand<SelectionChangedEventArgs>(SwitchDemo)).Value;

        public RelayCommand OpenPracticalDemoCmd => new Lazy<RelayCommand>(() =>
            new RelayCommand(OpenPracticalDemo)).Value;

        public RelayCommand GlobalShortcutInfoCmd => new Lazy<RelayCommand>(() =>
            new RelayCommand(() => Growl.Info("Global Shortcut Info"))).Value;

        public RelayCommand GlobalShortcutWarningCmd => new Lazy<RelayCommand>(() =>
            new RelayCommand(() => Growl.Warning("Global Shortcut Warning"))).Value;

        #endregion

        #region 方法

        /// <summary>
        ///     切换例子
        /// </summary>
        private void SwitchDemo(SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count == 0) return;
            if (e.AddedItems[0] is DemoItemModel item)
            {
                if (Equals(DemoItemCurrent, item)) return;

                DemoItemCurrent = item;
                ContentTitle = item.Name;
                TargetCtlName = item.TargetCtlName;               
                LoadShowContent(item.TargetCtlName);
            }
        }

        private void OpenPracticalDemo()
        {
            DemoItemCurrent = null;
            ContentTitle = "PracticalView";
            TargetCtlName = "PracticalView";
            LoadShowContent("PracticalView");
        }

        private void LoadShowContent(string name)
        {
            var type = Type.GetType($"{"AIStudio.Wpf.DemoPage.Views"}.{name}");
            var obj = type == null ? null: Activator.CreateInstance(type) as UserControl;

            if(obj != null)
            {
                var viewmodeltype = Type.GetType($"{"AIStudio.Wpf.DemoPage.ViewModels"}.{name}Model");
                var viewmodel = viewmodeltype == null ? null : Activator.CreateInstance(viewmodeltype);
                if (viewmodel != null)
                {
                    obj.DataContext = viewmodel;
                }
            }

            
            if (SubContent is IDisposable disposable)
            {
                disposable.Dispose();
            }
            SubContent = obj;

            IsFull = obj is IFull;
        }

        #endregion
    }
}