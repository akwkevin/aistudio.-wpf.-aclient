using AIStudio.Wpf.EFCore.Models;
using System.Collections.Generic;

namespace AIStudio.Wpf.Business
{
    public interface IOperator
    {
        /// <summary>
        /// 当前操作者UserId
        /// </summary>
        string UserId { get; }
        string UserName { get; set; }
        string Avatar { get; set; }
        /// <summary>
        /// 当前操作者
        /// </summary>
        Base_User Property { get; set; }

        List<string> Permissions { get; set; }

        #region 操作方法

        #endregion
    }
}