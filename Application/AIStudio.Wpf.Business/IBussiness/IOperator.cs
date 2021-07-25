using AIStudio.Core.Models;
using AIStudio.Wpf.Entity.DTOModels;
using AIStudio.Wpf.Entity.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

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
        Base_UserDTO Property { get; set; }

        List<string> Permissions { get; set; }

        //菜单树
        ObservableCollection<AMenuItem> MenuItems { get; set; }

        //打平用于查询的菜单
        ObservableCollection<AMenuItem> SearchMenus { get; set; }

        #region 操作方法

        #endregion
    }
}