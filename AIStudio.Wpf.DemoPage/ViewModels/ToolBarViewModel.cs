using Dataforge.PrismAvalonExtensions.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIStudio.Wpf.DemoPage.ViewModels
{
    public class ToolBarViewModel : DockWindowViewModel
    {
        /// <summary>
        ///     数据列表
        /// </summary>
        private IList<string> _dataList;

        /// <summary>
        ///     数据列表
        /// </summary>
        public IList<string> DataList
        {
            get { return _dataList; }
            set
            {
                if (value != _dataList)
                {
                    _dataList = value;
                    RaisePropertyChanged("DataList");
                }
            }

        }

        public ToolBarViewModel()
        {
            DataList = GetComboBoxDemoDataList();
        }

        internal List<string> GetComboBoxDemoDataList()
        {
            var list = new List<string>();
            for (var i = 1; i <= 9; i++)
            {
                list.Add($"下拉{i}");
            }

            return list;
        }

       
    }
}
