using AIStudio.Wpf.EFCore.Models;
using System.Collections.Generic;

namespace AIStudio.Wpf.Business
{
    /// <summary>
    /// 操作者
    /// </summary>
    public class Operator : IOperator
    {
        /// <summary>
        /// 当前操作者UserName
        /// </summary>
        public string UserName { get; set; }

        public string Avatar { get; set; }

        public Base_User Property { get; set; }

        public List<string> Permissions { get; set; }      
    }
}
