using AIStudio.Core;
using AIStudio.Wpf.Base_Manage.Views;
using AIStudio.Wpf.BasePage.DTOModels;
using AIStudio.Wpf.BasePage.ViewModels;
using AIStudio.Wpf.EFCore.DTOModels;
using Newtonsoft.Json;
using System;
using System.Linq;
using Util.Controls;

namespace AIStudio.Wpf.Base_Manage.ViewModels
{
    public class Base_RoleViewModel : BaseWindowViewModel<Base_RoleDTO>
    {
        public Base_RoleViewModel():base("Base_Manage", typeof(Base_RoleEditViewModel),typeof(Base_RoleEdit))
        {
           
        }

        protected override void Initialize()
        {
            base.Initialize();
            GetData();
        }

        protected override void GetData(bool iswaiting = false)
        {
            base.GetData(iswaiting);
        }

        protected override async void Edit(Base_RoleDTO para = null)
        {
            var viewmodel = new Base_RoleEditViewModel(para, Area, Identifier);

            var dialog = new Base_RoleEdit(viewmodel);
            dialog.ValidationAction = (() =>
            {
                if (!string.IsNullOrEmpty(viewmodel.Data.Error))
                    return false;
                else
                    return true;
            });
            var res = (BaseDialogResult)await WindowBase.ShowDialogAsync(dialog, Identifier);
            if (res == BaseDialogResult.OK)
            {
                try
                {
                    ShowWait();
                    viewmodel.Data.Actions = BaseTreeItemViewModelHelper.GetChecked(viewmodel.ActionsTreeData).OfType<Base_ActionTree>().Select(p => p.Id).ToList();
                    var result = await _dataProvider.GetData<AjaxResult>($"/Base_Manage/Base_Role/SaveData", JsonConvert.SerializeObject(viewmodel.Data));
                    if (!result.IsOK)
                    {
                        throw new Exception(result.ErrorMessage);
                    }
                    GetData(true);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    HideWait();
                }
            }
        }

        protected override void Delete(string id = null)
        {
            base.Delete(id);
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
