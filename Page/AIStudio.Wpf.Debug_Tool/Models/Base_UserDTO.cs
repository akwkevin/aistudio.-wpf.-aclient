using AIStudio.Core;
using AIStudio.Core.Models;
using AIStudio.Core.Validation;
using AIStudio.Wpf.Debug_Tool.Attributes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AIStudio.Wpf.Debug_Tool.Models
{
    public partial class Base_UserDTO : Prism.Mvvm.BindableBase, IIsChecked
    {
        private bool _isChecked;
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
        [Required(ErrorMessage = "密码不能为空")]
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
        [ColumnHeader("性别")]
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

       

        private ObservableCollection<SelectOption> _selectedRoles = new ObservableCollection<SelectOption>();
        [NullOrEmptyValidation(ErrorMessage = "请选择角色")]
        [ColumnHeader("角色",Ignore = true)]
        public ObservableCollection<SelectOption> SelectedRoles
        {
            get
            {
                return _selectedRoles;
            }
            set
            {
                SetProperty(ref _selectedRoles, value);
            }
        }      

        private string _selectedDuty;
        [Required(ErrorMessage = "请选择职能")]
        [ColumnHeader("职能", Ignore = true)]
        public string SelectedDuty
        {
            get
            {
                return _selectedDuty;
            }
            set
            {
                SetProperty(ref _selectedDuty, value);
            }
        }       

        private TreeModel _selectedDepartment;
        [Required(ErrorMessage = "请选择部门")]
        [ColumnHeader("部门",Ignore =true)]
        public TreeModel SelectedDepartment
        {
            get
            {
                return _selectedDepartment;
            }
            set
            {
                SetProperty(ref _selectedDepartment, value);
            }
        }

        public string DepartmentId { get; set; }

        private string _email;
        [EmailValidation]
        [ColumnHeader("邮箱")]
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                SetProperty(ref _email, value);
            }
        }

        private string _phoneNumber;
        [PhoneValidation]
        [ColumnHeader("电话号码")]
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

        [ColumnHeader("创建时间",IsReadOnly =true)]
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
            SelectedRoles.CollectionChanged += SelectedRoles_CollectionChanged;
        }

        private void SelectedRoles_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            RaisePropertyChanged("SelectedRoles");
        }
    }

    public partial class Base_UserDTO : IDataErrorInfo
    {
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
