using AIStudio.Core;
using AIStudio.Wpf.Base_Manage.Views;
using AIStudio.Wpf.BasePage.ViewModels;
using AIStudio.Wpf.Entity.DTOModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using AIStudio.Wpf.Controls;
using System.Threading.Tasks;
using AIStudio.Wpf.Entity.Models;

namespace AIStudio.Wpf.Base_Manage.ViewModels
{
    public class Base_UserViewModel : BaseListWithEditViewModel<Base_UserDTO, Base_UserEdit>
    {
        public Base_UserViewModel()
        {
            Area = "Base_Manage";
            Condition = "UserName";
            NewTitle = "新建用户";
            EditTitle = "编辑用户";
        }

        protected override IBaseEditViewModel GetEditViewModel()
        {
            return new Base_UserEditViewModel();
        }
    }
}
