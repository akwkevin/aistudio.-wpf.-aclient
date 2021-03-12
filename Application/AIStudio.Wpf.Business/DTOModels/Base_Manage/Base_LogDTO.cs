using AIStudio.Core.Validation;
using AIStudio.Wpf.EFCore.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace AIStudio.Wpf.Business.DTOModels
{
    public partial class Base_LogDTO : Base_Log, INotifyPropertyChanged, IIsChecked
    {
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

    public partial class Base_LogDTO : IDataErrorInfo
    {
        class Base_LogDTOMetadata
        {
            [StringNullValidation(ErrorMessage = "请输入角色名")]
            public string RoleName { get; set; }
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
                        error = this.ValidateProperty<Base_LogDTOMetadata>(pinfo.Name);
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
                return this.ValidateProperty<Base_LogDTOMetadata>(columnName);
            }
        }
    }   
}
