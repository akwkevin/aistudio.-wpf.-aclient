using AIStudio.Core.Models;
using System.Collections.Generic;

namespace AIStudio.Wpf.Entity.DTOModels
{
    /// <summary>
    /// 数据库所有表的信息
    /// </summary>
    public class BuildCode : BindableBase, IIsChecked
    {
        /// <summary>
        /// 表名
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// 表描述说明
        /// </summary>
        public string Description { get; set; }       

        public List<SubBuildCode> SubBuildCode { get; set; }

        private bool isChecked;
        public bool IsChecked
        {
            get { return isChecked; }
            set
            {
                if (value != isChecked)
                {
                    isChecked = value;
                    RaisePropertyChanged("IsChecked");
                }
            }
        }

        public string Id { get; set; }
        public string Error { get; }
    }

    public class SubBuildCode : BindableBase, IIsChecked
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                SetProperty(ref _name, value);
            }
        }

        private string _code;
        public string Code
        {
            get { return _code; }
            set
            {
                SetProperty(ref _code, value);
            }
        }

        private string _path;

        public string Path
        {
            get { return _path; }
            set
            {
                SetProperty(ref _path, value);
            }
        }

        public string TempPath { get; set; }

        private bool isChecked = true;
        public bool IsChecked
        {
            get { return isChecked; }
            set
            {
                if (value != isChecked)
                {
                    isChecked = value;
                    RaisePropertyChanged("IsChecked");
                }
            }
        }

        public string Id { get; set; }
        public string Error { get; }

        public string FileName { get; set; }
        public string Suffix { get; set; }
    }
}
