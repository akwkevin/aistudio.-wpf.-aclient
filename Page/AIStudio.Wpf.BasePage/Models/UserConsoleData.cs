using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Controls;
using Util.Panels;

namespace AIStudio.Wpf.BasePage.Models
{
    public class UserItemData : MDIItemData
    {
        [JsonIgnore]
        public Control Content { get; set; }
        public string Type { get; set; }//序列化后重构控件使用
    }

    public class UserConsoleData : Prism.Mvvm.BindableBase
    {
        private PanelType _panelType = PanelType.TilePanel;
        public PanelType PanelType
        {
            get { return _panelType; }
            set
            {
                SetProperty(ref _panelType, value);
            }
        }

        private int _columnNum = 2;
        public int ColumnNum
        {
            get { return _columnNum; }
            set
            {
                SetProperty(ref _columnNum, value);
            }
        }

        private int rowNum = 2;
        public int RowNum
        {
            get { return rowNum; }
            set
            {
                SetProperty(ref rowNum, value);
            }
        }

        private ObservableCollection<UserItemData> _data = new ObservableCollection<UserItemData>();
        public ObservableCollection<UserItemData> Data
        {
            get { return _data; }
            set
            {
                SetProperty(ref _data, value);
            }
        }


    }
}
