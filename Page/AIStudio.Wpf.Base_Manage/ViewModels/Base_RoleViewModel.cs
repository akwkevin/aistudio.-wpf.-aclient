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
        }

        protected override async Task GetData(bool iswaiting = false)
        {
            await base.GetData(iswaiting);
        }

        protected override BaseEditViewModel2<Base_RoleDTO> GetEditViewModel()
        {
            return new Base_RoleEditViewModel();
        }

        protected override async Task Delete(string id = null)
        {
            await base.Delete(id);
        }

        protected override void Print()
        {
            base.Print(Data);
        }

        protected override void Search(object para=null)
        {
            base.Search(para);
        }
    }
}
