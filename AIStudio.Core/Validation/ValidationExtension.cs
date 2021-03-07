using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIStudio.Core.Validation
{
    public static class ValidationExtension
    {
        public static string ValidateProperty<MetadataType>(this object obj, string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
                return string.Empty;

            var targetType = obj.GetType();

            if (targetType != typeof(MetadataType))
            {
                TypeDescriptor.AddProviderTransparent(
                       new AssociatedMetadataTypeTypeDescriptionProvider(targetType, typeof(MetadataType)), targetType);
            }

            var propertyValue = targetType.GetProperty(propertyName).GetValue(obj, null);
            var validationContext = new ValidationContext(obj, null, null);
            validationContext.MemberName = propertyName;
            var validationResults = new List<ValidationResult>();

            Validator.TryValidateProperty(propertyValue, validationContext, validationResults);

            if (validationResults.Count > 0)
            {
                return validationResults.First().ErrorMessage;
            }
            return string.Empty;
        }

        public static bool IsPropertyValid<Metadata>(this object obj, object value, ref Dictionary<string, string> errors)
        {

            TypeDescriptor.AddProviderTransparent(
                new AssociatedMetadataTypeTypeDescriptionProvider(obj.GetType(), typeof(Metadata)), obj.GetType());

            var validationContext = new ValidationContext(obj, null, null);
            var validationResults = new List<ValidationResult>();
            Validator.TryValidateProperty(value, validationContext, validationResults);

            if (validationResults.Count > 0 && errors == null)
                errors = new Dictionary<string, string>(validationResults.Count);

            foreach (var validationResult in validationResults)
            {
                errors.Add(validationResult.MemberNames.First(), validationResult.ErrorMessage);
            }

            if (validationResults.Count > 0)
                return false;
            else
                return true;
        }
    }
}
