using AIStudio.Core.Validation;
using AIStudio.Core;
using AIStudio.Wpf.EFCore.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace AIStudio.Wpf.EFCore.DTOModels
{
    public partial class OA_DefFormDTO : OA_DefForm, INotifyPropertyChanged, IIsChecked
    {
        private bool _isChecked;
        public bool IsChecked
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

        public string[] ValueRoles
        {
            get { return Value?.Split(new string[] { "^" }, System.StringSplitOptions.RemoveEmptyEntries); }
            set
            {
                if (value != null)
                {
                    Value = "^" + string.Join("^", value) + "^";
                }
                else
                {
                    Value = null;
                }
            }
        }

        private List<SelectOption> _roles = new List<SelectOption>();
        public List<SelectOption> Roles
        {
            get { return _roles; }
            set
            {
                if (_roles != value)
                {
                    _roles = value;
                    RaisePropertyChanged("Roles");
                }
            }
        }
    }

    public partial class OA_DefFormDTO : IDataErrorInfo
    {
        class OA_DefFormDTOMetadata
        {
            [StringNullValidation(ErrorMessage = "标题不能为空")]
            public string Name { get; set; }
            [StringNullValidation(ErrorMessage = "分类不能为空")]
            public string Type { get; set; }

            [StringNullValidation(ErrorMessage = "摘要不能为空")]
            public string Text { get; set; }
        }

        public string Error
        {
            get
            {
                string error = null;
                PropertyInfo[] propertys = this.GetType().GetProperties();
                foreach (PropertyInfo pinfo in propertys)
                {
                    //循环遍历属性
                    if (pinfo.CanRead && pinfo.CanWrite)
                    {
                        error = this.ValidateProperty<OA_DefFormDTOMetadata>(pinfo.Name);
                        if (error != null && error.Length > 0)
                        {
                            break;
                        }
                    }
                }
                return error;
            }
        }

        public string this[string columnName]
        {
            get
            {
                return this.ValidateProperty<OA_DefFormDTOMetadata>(columnName);
            }
        }
    }

    public class OA_DefFormTree : TreeModel
    {
        public string title { get => Text; }
        public string value { get => Id; }
        public string key { get => Id; }

        public object scopedSlots { get; set; }

        public int jsonVersion { get; set; }
        public string jsonId { get; set; }
        public string json { get; set; }

        public string type { get; set; }

        public new List<OA_DefFormTree> Children { get; set; }
    }
}
