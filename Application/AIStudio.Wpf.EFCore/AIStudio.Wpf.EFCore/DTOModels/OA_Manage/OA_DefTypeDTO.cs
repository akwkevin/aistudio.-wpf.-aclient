using AIStudio.Core.Validation;
using AIStudio.Wpf.EFCore.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;

namespace AIStudio.Wpf.EFCore.DTOModels
{
    public partial class OA_DefTypeDTO : OA_DefType, INotifyPropertyChanged, IIsChecked
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
    }

    public partial class OA_DefTypeDTO : IDataErrorInfo
    {
        class OA_DefTypeDTOMetadata
        {
            [StringNullValidation(ErrorMessage = "字段名称不能为空")]
            public string Name { get; set; }
            [StringNullValidation(ErrorMessage = "类型不能为空")]
            public string Type { get; set; }
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
                        error = this.ValidateProperty<OA_DefTypeDTOMetadata>(pinfo.Name);
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
                return this.ValidateProperty<OA_DefTypeDTOMetadata>(columnName);
            }
        }
    }


}
