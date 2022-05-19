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
    public partial class Base_UserDTO_Test : Base_UserDTO
    {
        private string _password;
        [Required(ErrorMessage = "密码不能为空")]
        [ColumnHeader("密码", Visibility = System.Windows.Visibility.Collapsed)]
        public new string Password
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

        /// <summary>
        /// 后台无实现此项，仅显示测试使用
        /// </summary>
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

        private string _email;
        [EmailValidation(ErrorMessage = "请输入正确的邮箱格式,例：zhangsan@126.com")]
        [ColumnHeader("邮箱", Ignore = true)]
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
    }  
}
