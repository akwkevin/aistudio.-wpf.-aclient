using AIStudio.Core;
using AIStudio.Core.Validation;
using AIStudio.Wpf.EFCore.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace AIStudio.Wpf.EFCore.DTOModels
{
    //[MapFrom(typeof(Base_User))]
    //[MapTo(typeof(Base_User))]
    public partial class Base_UserDTO : Base_User, INotifyPropertyChanged, IIsChecked
    {
        //private string userName;
        //public new string UserName
        //{
        //    get { return userName; }
        //    set
        //    {
        //        if (value != userName)
        //        {
        //            userName = value;
        //            RaisePropertyChanged("UserName");
        //        }
        //    }
        //}

        public string RoleNames { get => string.Join(",", RoleNameList ?? new List<string>()); }
        public List<string> RoleIdList { get; set; }
        public List<string> RoleNameList { get; set; }
        public RoleTypes RoleType
        {
            get
            {
                int type = 0;

                var values = typeof(RoleTypes).GetEnumValues();
                foreach (var aValue in values)
                {
                    if (RoleNames.Contains(aValue.ToString()))
                        type += (int)aValue;
                }

                return (RoleTypes)type;
            }
        }
        public string DepartmentName { get; set; }
        public string DepartmentFullName { get; set; }
        public string SexText { get => Sex == 1 ? "男" : "女"; }
        public string BirthdayText { get => Birthday?.ToString("yyyy-MM-dd"); }
        public string newPwd { get; set; }
        public string roleIdsJson { get; set; }

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

    public partial class Base_UserDTO : IDataErrorInfo
    {
        class Base_UserDTOMetadata
        {
            [StringNullValidation(ErrorMessage = "用户名不能为空")]
            public string UserName { get; set; }
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
                        error = this.ValidateProperty<Base_UserDTOMetadata>(pinfo.Name);
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
                return this.ValidateProperty<Base_UserDTOMetadata>(columnName);
            }
        }
    }

    public class UserInfoPermissions
    {
        public Base_UserDTO UserInfo { get; set; }

        public List<string> Permissions { get; set; }
    }

}
