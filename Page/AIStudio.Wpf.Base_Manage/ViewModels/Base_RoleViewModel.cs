using AIStudio.Core;
using AIStudio.Wpf.Base_Manage.Views;
using AIStudio.Wpf.BasePage.DTOModels;
using AIStudio.Wpf.BasePage.ViewModels;
using AIStudio.Wpf.Entity.DTOModels;
using Newtonsoft.Json;
using System;
using System.Linq;
using AIStudio.Wpf.Controls;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace AIStudio.Wpf.Base_Manage.ViewModels
{
    public class Base_RoleViewModel : BaseListWithEditViewModel<Base_RoleDTO, Base_RoleEdit>
    {
        public Base_RoleViewModel()
        {
            Area = "Base_Manage";
            Condition = "RoleName";
            NewTitle = "新建角色";
            EditTitle = "编辑角色";
        }

        protected override IBaseEditViewModel GetEditViewModel()
        {
            return new Base_RoleEditViewModel();
        }
    }
}
