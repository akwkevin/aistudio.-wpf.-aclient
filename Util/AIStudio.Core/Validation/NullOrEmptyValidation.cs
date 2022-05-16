using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AIStudio.Core.Validation
{
    //字符串非空检查
    public class NullOrEmptyValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is null)
                return false;

            if (value is string str)
            {
                if (!string.IsNullOrEmpty(str))
                {
                    return true;
                }
            }
            else if (value is IEnumerable<object> list)
            {
                if (list.Count() > 0)
                {
                    return true;
                }
            }

            return false;
        }

        public override string FormatErrorMessage(string name)
        {
            return ErrorMessage ?? "不能为空";
        }
    }
}
