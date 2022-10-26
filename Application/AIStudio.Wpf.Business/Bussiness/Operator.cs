using AIStudio.Core.Models;
using AIStudio.Wpf.Entity.DTOModels;
using AIStudio.Wpf.Entity.Models;
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
        public ObservableCollection<AMenuItem> MenuTrees { get; set; }

        //打平用于查询的菜单
        public ObservableCollection<AMenuItem> Menus { get; set; }

    }
}
