using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace AIStudio.Core.Validation
{
    //IP格式检查
    public class EmailsValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var nameAndEmails = value as string;
            if (string.IsNullOrWhiteSpace(nameAndEmails))
            {
                return true;
            }
            string[] nameAndEmailArray = nameAndEmails.Replace("\n", "").Replace(" ", "").Replace("\t", "").Replace("\r", "").Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
            foreach(var nameAndEmail in nameAndEmailArray)
            {
                var names = nameAndEmail.Split(new string[] { "<", ">" }, StringSplitOptions.RemoveEmptyEntries);
                if (names.Length != 2)
                {
                    return false;
                }
                if (!IsEmail(names[1]))
                {
                    return false;
                }
            }

            return true;
        }

        public override string FormatErrorMessage(string name)
        {
            return "请输入正确的邮箱格式！！！例：张三<zhangsan@126.com>;李四<lisi@qq.com>";
        }

        /// <summary>
        /// 是否为email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static bool IsEmail(string email)
        {
            return Regex.IsMatch(email, @"^^[a-zA-Z0-9_-]+@[a-zA-Z0-9_-]+(\.[a-zA-Z0-9_-]+)+$");
        }

    }

}