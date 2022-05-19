using AIStudio.Core;
using AIStudio.Core.Models;
using AIStudio.Core.Validation;
using AIStudio.Wpf.AgileDevelopment.Attributes;
using AIStudio.Wpf.AgileDevelopment.Converter;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AIStudio.Wpf.AgileDevelopment.Models
{
    public partial class Base_UserDTO_Query
    {
        [ColumnHeader("姓名", IsPin = true)]
        public string UserName { get; set; }
    }

    public partial class Base_UserDTO : Prism.Mvvm.BindableBase, IIsChecked
    {
        private bool _isChecked;
        [ColumnHeader(Ignore = true)]
        public bool IsChecked
        {
            get { return _isChecked; }
            set
            {
                SetProperty(ref _isChecked, value);
            }
        }

        [ColumnHeader("Id", IsReadOnly = true)]
        public string Id { get; set; }

        [ColumnHeader(Ignore = true)]
        public bool Deleted { get; set; }

        private string _userName;
        [Required(ErrorMessage = "用户名不能为空")]
        [ColumnHeader("姓名")]
        public string UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                SetProperty(ref _userName, value);
            }
        }

        private string _realName;
        [ColumnHeader("真实姓名")]
        public string RealName
        {
            get
            {
                return _realName;
            }
            set
            {
                SetProperty(ref _realName, value);
            }
        }

        private string _password;
        [ColumnHeader("密码", Visibility = System.Windows.Visibility.Collapsed)]
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                SetProperty(ref _password, value);
            }
        }

        private int _sex;
        [Required(ErrorMessage = "请选择性别")]
        [ColumnHeader("性别", Converter = typeof(ObjectToStringConverter), ControlType = Commons.ControlType.ComboBox)]
        public int Sex
        {
            get
            {
                return _sex;
            }
            set
            {
                SetProperty(ref _sex, value);
            }
        }

        private DateTime? _birthday;
        [Required(ErrorMessage = "请选择出生日期")]
        [ColumnHeader("生日")]
        public DateTime? Birthday
        {
            get
            {
                return _birthday;
            }
            set
            {
                SetProperty(ref _birthday, value);
            }
        }

        private ObservableCollection<string> _roleIdList = new ObservableCollection<string>();
        [NullOrEmptyValidation(ErrorMessage = "请选择角色")]
        [ColumnHeader("角色", ItemSource = "Role", ControlType = Commons.ControlType.MultiComboBox, Converter = typeof(ObjectToStringConverter))]
        public ObservableCollection<string> RoleIdList
        {
            get
            {
                return _roleIdList;
            }
            set
            {
                SetProperty(ref _roleIdList, value);
            }
        }

        private string _departmentId;
        [NullOrEmptyValidation(ErrorMessage = "请选择部门")]
        [ColumnHeader("部门", ItemSource = "TreeDepartment", ControlType = Commons.ControlType.TreeSelect, Converter = typeof(ObjectToStringConverter), ConverterParameter = "Department")]
        public string DepartmentId
        {
            get
            {
                return _departmentId;
            }
            set
            {
                SetProperty(ref _departmentId, value);
            }
        }

        private string _phoneNumber;
        [PhoneValidation]
        [ColumnHeader("手机号码")]
        public string PhoneNumber
        {
            get
            {
                return _phoneNumber;
            }
            set
            {
                SetProperty(ref _phoneNumber, value);
            }
        }

        [ColumnHeader("创建时间", IsReadOnly = true)]
        public DateTime CreateTime { get; set; }

        [ColumnHeader("修改时间", IsReadOnly = true)]
        public DateTime? ModifyTime { get; set; }

        [ColumnHeader(Ignore = true)]
        public string CreatorId { get; set; }

        [ColumnHeader("创建者", IsReadOnly = true)]
        public string CreatorName { get; set; }

        [ColumnHeader(Ignore = true)]
        public string ModifyId { get; set; }

        [ColumnHeader("修改者", IsReadOnly = true)]
        public string ModifyName { get; set; }

        public Base_UserDTO()
        {
            RoleIdList.CollectionChanged += RoleIdList_CollectionChanged;
        }

        private void RoleIdList_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            RaisePropertyChanged("RoleIdList");
        }
    }

    public partial class Base_UserDTO : IDataErrorInfo
    {
        [ColumnHeader(Ignore = true)]
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

        [ColumnHeader(Ignore = true)]
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
