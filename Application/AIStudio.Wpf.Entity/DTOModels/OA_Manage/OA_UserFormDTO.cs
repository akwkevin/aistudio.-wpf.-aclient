using AIStudio.Core.Models;
using AIStudio.Core.Validation;
using AIStudio.Wpf.Entity.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AIStudio.Wpf.Entity.DTOModels
{
    public partial class OA_UserFormDTO : OA_UserForm, INotifyPropertyChanged, IIsChecked
    {
        [Required(ErrorMessage = "摘要不能为空")]
        public new string Text { get; set; }
        [Required(ErrorMessage = "申请人不能为空")]
        public new string ApplicantUserId { get; set; }

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

        public string ApplicantUserAndDepartment { get => ApplicantUser + "-" + ApplicantDepartment; }
        public string UserNamesAndRoles
        {
            get
            {
                var users = (UserNames ?? "").Replace("^", " ").Trim().Replace(" ", ",");
                var roles = (UserRoleNames ?? "").Replace("^", " ").Trim().Replace(" ", ",");
                return users + (string.IsNullOrEmpty(roles) ? "" : "-" + roles);
            }
        }

        public string Current
        {
            get { return CurrentNode?.Replace("^", "").Trim().Replace(" ", ","); }
        }


        public string ExpectedDateString { get => ExpectedDate?.ToString("yyyy-MM-dd"); }

        public List<OA_UserFormStepDTO> Comments { get; set; }

        private List<OA_Step> _steps;
        public List<OA_Step> Steps
        {
            get { return _steps; }
            set
            {
                if (_steps != value)
                {
                    _steps = value;
                    RaisePropertyChanged("Steps");
                }
            }
        }

        public int CurrentStepIndex { get; set; }
        public string CurrentStepId { get; set; }
        public string Avatar { get; set; }
    }

    public partial class OA_UserFormDTO : IDataErrorInfo
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
}
