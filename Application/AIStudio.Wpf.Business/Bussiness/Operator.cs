using AIStudio.Wpf.EFCore.DTOModels;
using AIStudio.Wpf.EFCore.Models;
using System.Collections.Generic;

namespace AIStudio.Wpf.Business
{
    /// <summary>
    /// 操作者
    /// </summary>
    public class Operator : IOperator
    {
        public string UserId { get { return Property?.Id; } }
        /// <summary>
        /// 当前操作者UserName
        /// </summary>
        public string UserName { get; set; }

        public string Avatar { get; set; }

        public Base_UserDTO Property { get; set; }

        public List<string> Permissions { get; set; }      
    }
}
