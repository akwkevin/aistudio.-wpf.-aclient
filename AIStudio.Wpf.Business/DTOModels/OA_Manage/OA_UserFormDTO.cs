using AIStudio.Core.Validation;
using AIStudio.Wpf.EFCore.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace AIStudio.Wpf.Business.DTOModels
{
    public partial class OA_UserFormDTO : OA_UserForm, INotifyPropertyChanged, IIsChecked
    {
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

        public string WorkflowJSON { get; set; }

        public List<OA_UserFormStepDTO> Comments { get; set; }

        private List<OAStep> _steps;
        public List<OAStep> Steps
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
        class OA_UserFormDTOMetadata
        {
            [StringNullValidation(ErrorMessage = "摘要不能为空")]
            public string Text { get; set; }
            [StringNullValidation(ErrorMessage = "申请人不能为空")]
            public string ApplicantUserId { get; set; }
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
                        error = this.ValidateProperty<OA_UserFormDTOMetadata>(pinfo.Name);
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
                return this.ValidateProperty<OA_UserFormDTOMetadata>(columnName);
            }
        }
    }   
}
