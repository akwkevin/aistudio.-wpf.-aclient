﻿using AIStudio.Core.Models;
using AIStudio.Core.Validation;
using AIStudio.Wpf.Entity.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AIStudio.Wpf.Entity.DTOModels
{
    public partial class D_UserGroupDTO : D_UserGroup, INotifyPropertyChanged, IIsChecked
    {
        [Required(ErrorMessage = "组名不能为空")]
        public new string Name { get; set; }

        private bool _isChecked;
        public bool IsChecked
        {
            get { return _isChecked; }
            set
            {
                if (_isChecked != value)
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
    }

    public partial class D_UserGroupDTO : IDataErrorInfo
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
