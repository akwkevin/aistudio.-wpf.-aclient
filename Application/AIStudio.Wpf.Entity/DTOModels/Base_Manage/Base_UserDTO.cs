using AIStudio.Core.Models;
using AIStudio.Core;
using AIStudio.Core.Validation;
using AIStudio.Wpf.Entity.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AIStudio.Wpf.Entity.DTOModels
{
    [Map(typeof(Base_User))]
    public partial class Base_UserDTO : Base_User, INotifyPropertyChanged, IIsChecked
    {
        [Required(ErrorMessage = "用户名不能为空")]
        public new string UserName { get; set; }

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
        [Browsable(false)]
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

        [Browsable(false)]
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

    public class UserInfoPermissions
    {
        public Base_UserDTO UserInfo { get; set; }

        public List<string> Permissions { get; set; }
    }

}
