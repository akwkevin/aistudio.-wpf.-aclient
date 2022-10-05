using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace AIStudio.Core.Validation
{
    //IP格式检查
    public class EmailValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var ip = value as string;
            if (IsEmail(ip))
            {
                return true;
            }
            return false;
        }

        public override string FormatErrorMessage(string name)
        {
            return "请输入正确的邮箱格式,例：zhangsan@126.com";
        }

        /// <summary>
        /// 是否为email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static bool IsEmail(string email)
        {
            return email != null && Regex.IsMatch(email, @"^^[a-zA-Z0-9_-]+@[a-zA-Z0-9_-]+(\.[a-zA-Z0-9_-]+)+$");
        }

    }

}