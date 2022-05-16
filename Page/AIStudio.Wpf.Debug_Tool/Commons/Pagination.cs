using AIStudio.Wpf.Controls.Bindings;
using System.Collections.Generic;

namespace AIStudio.Wpf.Debug_Tool.Commons
{
    /// <summary>
    /// 数据表格分页
    /// </summary>
    public class Pagination : BindableBase
    {
        #region 默认方案

        private int pageIndex = 1;
        /// <summary>
        /// 当前页码
        /// </summary>
        public int PageIndex
        {
            get
            {
                return pageIndex;
            }
            set
            {
                SetProperty(ref pageIndex, value);
            }
        }

        private int pageRows = int.MaxValue;
        /// <summary>
        /// 每页行数
        /// </summary>
        public int PageRows
        {
            get
            {
                return pageRows;
            }
            set
            {
                SetProperty(ref pageRows, value);
                RaisePropertyChanged("TotalText");
            }
        }


        /// <summary>
        /// 排序列
        /// </summary>
        public string SortField { get; set; } = "Id";

        private string _sortType { get; set; } = "desc";
        /// <summary>
        /// 排序类型
        /// </summary>
        public string SortType
        {
            get => _sortType; set => _sortType = (value ?? string.Empty).Contains("desc") ? "desc" : "asc";
        }

        private int total;
        /// <summary>
        /// 总记录数
        /// </summary>
        public int Total
        {
            get
            {
                return total;
            }
            set
            {
                if (SetProperty(ref total, value))
                {
                    RaisePropertyChanged("TotalText");
                }
            }
        }

        /// <summary>
        /// 总页数
        /// </summary>
        public int PageCount
        {
            get
            {
                if (PageRows == 0)
                    return 1;
                int pages = Total / PageRows;
                pages = Total % PageRows == 0 ? pages : pages + 1;
                return pages;
            }
        }

        public Dictionary<string, object> Keywords
        {
            get;set;
        }
        #endregion
    }
}
