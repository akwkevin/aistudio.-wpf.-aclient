using AIStudio.Core.Models;
using AIStudio.Core.Validation;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AIStudio.Wpf.AgileDevelopment.Models
{
    public partial class Base_UserDTO_Test : DataErrorInfoBindableBase
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

        public string Id { get; set; }
        
        public bool Deleted { get; set; }

        private string _userName;
        [Required(ErrorMessage = "用户名不能为空")]
        [DisplayName("姓名")]
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
        [DisplayName("真实姓名")]
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
        [DisplayName("密码")]
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
        [DisplayName("性别")]
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
        [DisplayName("生日")]
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
        [DisplayName("角色")]
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
        [DisplayName("部门")]
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

        private string _selectedDuty;
        [Required(ErrorMessage = "请选择职能")]
        [DisplayName("职能")]
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

        private string _email;
        [EmailValidation(ErrorMessage = "请输入正确的邮箱格式,例：zhangsan@126.com")]
        [DisplayName("邮箱")]
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
        [DisplayName("手机号码")]
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

        [DisplayName("创建时间")]
        public DateTime CreateTime { get; set; }

        [DisplayName("修改时间")]
        public DateTime? ModifyTime { get; set; }

        public string CreatorId { get; set; }

        [DisplayName("创建者")]
        public string CreatorName { get; set; }

        public string ModifyId { get; set; }

        [DisplayName("修改者")]
        public string ModifyName { get; set; }

        public Base_UserDTO_Test()
        {
            RoleIdList.CollectionChanged += RoleIdList_CollectionChanged;
        }

        private void RoleIdList_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            RaisePropertyChanged("RoleIdList");
        }
    }
}
