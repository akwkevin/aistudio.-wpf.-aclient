using AIStudio.Core.Validation;
using AIStudio.Wpf.EFCore.Models;
using System.ComponentModel;
using System.Reflection;

namespace AIStudio.Wpf.Business.DTOModels
{
    public partial class Base_AppSecretDTO : Base_AppSecret, INotifyPropertyChanged, IIsChecked
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

    public partial class Base_AppSecretDTO : IDataErrorInfo
    {
        class Base_AppSecretDTOMetadata
        {
            [StringNullValidation(ErrorMessage = "请输入应用Id")]
            public string AppId { get; set; }
            [StringNullValidation(ErrorMessage = "请输入密钥")]
            public string AppSecret { get; set; }
            [StringNullValidation(ErrorMessage = "请输入应用名")]
            public string AppName { get; set; }
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
                        error = this.ValidateProperty<Base_AppSecretDTOMetadata>(pinfo.Name);
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
                return this.ValidateProperty<Base_AppSecretDTOMetadata>(columnName);
            }
        }
    }   
}
