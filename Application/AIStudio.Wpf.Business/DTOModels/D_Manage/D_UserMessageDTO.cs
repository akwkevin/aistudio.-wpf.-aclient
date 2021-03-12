using AIStudio.Core.Validation;
using AIStudio.Wpf.EFCore.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace AIStudio.Wpf.Business.DTOModels
{
    public partial class D_UserMessageDTO : D_UserMessage, INotifyPropertyChanged, IIsChecked
    {
        private bool isChecked;
        public bool IsChecked
        {
            get { return isChecked; }
            set
            {
                if (isChecked != value)
                {
                    isChecked = value;
                    RaisePropertyChanged("IsChecked");
                }
            }
        }

        public string Avatar { get; set; }

        public bool ShowTime { get; set; }

        public string Role { get; set; }

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

    public partial class D_UserMessageDTO : IDataErrorInfo
    {
        class D_UserMessageDTOMetadata
        {

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
                        error = this.ValidateProperty<D_UserMessageDTOMetadata>(pinfo.Name);
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
                return this.ValidateProperty<D_UserMessageDTOMetadata>(columnName);
            }
        }
    }


}
