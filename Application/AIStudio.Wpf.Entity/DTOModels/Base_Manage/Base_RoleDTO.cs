using AIStudio.Core.Models;
using AIStudio.Core.Validation;
using AIStudio.Wpf.Entity.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AIStudio.Wpf.Entity.DTOModels
{
    public partial class Base_RoleDTO : Base_Role, INotifyPropertyChanged, IIsChecked
    {
        [Required(ErrorMessage = "角色名不能为空")]
        public new string RoleName { get; set; }

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

        private ObservableCollection<string> _actions = new ObservableCollection<string>();
        public ObservableCollection<string> Actions
        {
            get { return _actions; }
            set
            {
                if (value != _actions)
                {
                    _actions = value;
                    RaisePropertyChanged("Actions");
                }
            }
        }
        public string actionsJson { get; set; }
    }

    public partial class Base_RoleDTO : IDataErrorInfo
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
