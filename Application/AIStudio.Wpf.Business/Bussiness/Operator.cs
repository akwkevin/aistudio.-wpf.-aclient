using AIStudio.Core.Models;
using AIStudio.Wpf.EFCore.DTOModels;
using AIStudio.Wpf.EFCore.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

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

        //菜单树
        public ObservableCollection<AMenuItem> MenuItems { get; set; }

        //打平用于查询的菜单
        public ObservableCollection<AMenuItem> SearchMenus { get; set; }

    }
}
