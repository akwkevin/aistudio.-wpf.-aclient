using System.ComponentModel.DataAnnotations;

namespace AIStudio.Core.Validation
{
    //字符串非空检查
    public class StringNullValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var str = value as string;
           
            if (str != null && str.Length > 0)
            {
                return true;
            }
            return false;
        }

        public override string FormatErrorMessage(string name)
        {
            return ErrorMessage ?? "不能为空, 请输入字符！！！";
        }
    }
}
