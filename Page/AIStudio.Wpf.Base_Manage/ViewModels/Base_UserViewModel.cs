using AIStudio.Wpf.Base_Manage.Views;
using AIStudio.Wpf.BasePage.ViewModels;
using AIStudio.Wpf.BasePage.Views;
using AIStudio.Wpf.Business.DTOModels;
using AIStudio.Wpf.Service.AppClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using Util.Controls;

namespace AIStudio.Wpf.Base_Manage.ViewModels
{
    public class Base_UserViewModel : BaseWindowViewModel<Base_UserDTO>
    {
        public Base_UserViewModel():base("Base_Manage", typeof(Base_UserEditViewModel), typeof(Base_UserEdit))
        {

        }

        protected override void Initialize()
        {
            base.Initialize();
            GetData();
        }

        public List<SelectOption> Roles { get; set; }

        public List<TreeModel> Departments { get; set; }     

        protected override void GetData(bool iswaiting = false)
        {
            base.GetData(iswaiting);
        }

        protected override async void Edit(Base_UserDTO para = null)
        {
            var viewmodel = new Base_UserEditViewModel(para, Area, Identifier);
            var dialog = new Base_UserEdit(viewmodel);
            dialog.ValidationAction = (() =>
            {
                if (!string.IsNullOrEmpty(para.Error))
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
                    viewmodel.Data.RoleIdList = viewmodel.SelectedRoles.Select(p => p.value).ToList();
                    viewmodel.Data.DepartmentId = viewmodel.SelectedDepartment?.Id;
                    var result = await _dataProvider.GetData<AjaxResult>("/Base_Manage/Base_User/SaveData", JsonConvert.SerializeObject(viewmodel.Data));
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
            PrintPreviewWindow previewWnd = new PrintPreviewWindow("/AIStudio.Wpf.Base_Manage;component/Views/Base_UserFlowDocument.xaml", Data[0], new Base_UserDocumentRenderer());
            previewWnd.ShowDialog();
        }

        protected override void Search(object para=null)
        {
            base.Search(para);
        }
    }
}
