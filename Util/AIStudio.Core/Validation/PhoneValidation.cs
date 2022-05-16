using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace AIStudio.Core.Validation
{
    //电话格式检查
    public class PhoneValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var ip = value as string;
            if (IsPhone(ip))
            {
                return true;
            }
            return false;
        }

        public override string FormatErrorMessage(string name)
        {
            return "请输入正确的手机号码格式！！！";
        }

        /// <summary>
        /// 是否为ip
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static bool IsPhone(string ip)
        {
            return ip != null && Regex.IsMatch(ip, @"^(13[0-9]|14[01456879]|15[0-35-9]|16[2567]|17[0-8]|18[0-9]|19[0-35-9])\d{8}$");
        }

    }

}