using AIStudio.Core;
using AIStudio.Core.Models;
using AIStudio.Core.Validation;
using AIStudio.Wpf.Entity.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Windows;

namespace AIStudio.Wpf.Entity.DTOModels
{
    public partial class Base_CommonFormConfigDTO : Base_CommonFormConfig, INotifyPropertyChanged, IIsChecked
    {
        /// <summary>
        /// 表名
        /// </summary>
        [Required(ErrorMessage = "请输入表名")]
        public new string Table { get; set; }

        /// <summary>
        /// 列头
        /// </summary>
        [Required(ErrorMessage = "请输入列头")]
        public new string Header { get; set; }

        /// <summary>
        /// 属性名
        /// </summary>
        [Required(ErrorMessage = "请输入属性名")]
        public new string PropertyName { get; set; }

        /// <summary>
        /// 属性类型
        /// </summary>
        [Required(ErrorMessage = "请输入属性类型")]
        public new string PropertyType { get; set; }

        /// <summary>
        /// 显示索引
        /// </summary>
        [Required(ErrorMessage = "请输入索引")]
        public new int DisplayIndex { get; set; }

        /// <summary>
        /// 配置类型 查询=0，列表=1
        /// </summary>
        [Required(ErrorMessage = "请输入配置类型")]
        public new int Type { get; set; }

        public string TypeName
        {
            get
            {
                if (Type == 0)
                    return "查询";
                else
                    return "列表";
            }
        }

        public string VisibilityName
        {
            get
            {
                if (Visibility == Visibility.Visible)
                    return "显示";
                else
                    return "隐藏";
            }
        }

        public string HorizontalAlignmentName
        {
            get
            {
                if (HorizontalAlignment == HorizontalAlignment.Left)
                    return "左对齐";
                else if (HorizontalAlignment == HorizontalAlignment.Center)
                    return "居中";
                else if (HorizontalAlignment == HorizontalAlignment.Right)
                    return "右对齐";
                else
                    return "拉伸";
            }
        }

        /// <summary>
        /// 是否可以重排
        /// </summary>
        public new bool CanUserReorder { get; set; } = true;

        /// <summary>
        /// 是否可以调整大小
        /// </summary>
        public new bool CanUserResize { get; set; } = true;

        /// <summary>
        /// 是否可以排序
        /// </summary>
        public new bool CanUserSort { get; set; } = true;

        private bool? _isChecked = false;
        public bool? IsChecked
        {
            get { return _isChecked; }
            set
            {
                if (value != _isChecked)
                {
                    _isChecked = value;
                    RaisePropertyChanged("IsChecked");
                }
            }
        }      

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged(string propertyName)
        {
            //this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    public partial class Base_CommonFormConfigDTO : IDataErrorInfo
    {
        [Browsable(false)]
        public string this[string columnName]
        {
            get
            {
                List<ValidationResult> validationResults = new List<ValidationResult>();

                bool result = Validator.TryValidateProperty(
                    GetType().GetProperty(columnName).GetValue(this),
                    new ValidationContext(this)
                    {
                        MemberName = columnName
                    },
                    validationResults);

                if (result)
                    return null;

                return validationResults.First().ErrorMessage;
            }
        }

        [Browsable(false)]
        public string Error
        {
            get
            {
                ICollection<ValidationResult> results;
                this.Validate(out results);

                return results.FirstOrDefault()?.ErrorMessage;
            }
        }
    }   
}
