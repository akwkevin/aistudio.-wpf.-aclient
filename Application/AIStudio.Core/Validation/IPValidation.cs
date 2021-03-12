using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace AIStudio.Core.Validation
{
    //IP格式检查
    public class IPValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var ip = value as string;
            if (ip == null || IsIP(ip))
            {
                return true;
            }
            return false;
        }

        public override string FormatErrorMessage(string name)
        {
            return "请输入正确的IP格式！！！";
        }

        /// <summary>
        /// 是否为ip
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static bool IsIP(string ip)
        {
            return Regex.IsMatch(ip, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$");
        }

        public static bool IsIPSect(string ip)
        {
            return Regex.IsMatch(ip, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){2}((2[0-4]\d|25[0-5]|[01]?\d\d?|\*)\.)(2[0-4]\d|25[0-5]|[01]?\d\d?|\*)$");
        }
    }

}