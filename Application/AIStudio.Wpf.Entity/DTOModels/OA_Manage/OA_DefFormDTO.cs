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
    public partial class OA_DefFormDTO : OA_DefForm, INotifyPropertyChanged, IIsChecked
    {
        [Required(ErrorMessage = "标题不能为空")]
        public new string Name { get; set; }
        [Required(ErrorMessage = "分类不能为空")]
        public new string Type { get; set; }
        [Required(ErrorMessage = "摘要不能为空")]
        public new string Text { get; set; }

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

        public string[] ValueRoles
        {
            get { return Value?.Split(new string[] { "^" }, System.StringSplitOptions.RemoveEmptyEntries); }
            set
            {
                if (value != null)
                {
                    Value = "^" + string.Join("^", value) + "^";
                }
                else
                {
                    Value = null;
                }
            }
        }

        private List<ISelectOption> _roles = new List<ISelectOption>();
        public List<ISelectOption> Roles
        {
            get { return _roles; }
            set
            {
                if (_roles != value)
                {
                    _roles = value;
                    RaisePropertyChanged("Roles");
                }
            }
        }
    }

    public partial class OA_DefFormDTO : IDataErrorInfo
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

    public class OA_DefFormTree : TreeModel<OA_DefFormTree>
    {
        public string title { get => Text; }
        public string value { get => Id; }
        public string key { get => Id; }

        public object scopedSlots { get; set; }

        public int jsonVersion { get; set; }
        public string jsonId { get; set; }
        public string json { get; set; }

        public string type { get; set; }
    }
}
