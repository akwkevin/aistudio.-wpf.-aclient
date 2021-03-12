using AIStudio.Wpf.BasePage.ViewModels;
using AIStudio.Wpf.Business;
using AIStudio.Wpf.Business.DTOModels;
using AIStudio.Wpf.Service.AppClient;
using Newtonsoft.Json;
using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Util.Controls;

namespace AIStudio.Wpf.D_Manage.ViewModels
{
    public class D_UserMailEditViewModel : BaseEditViewModel<D_UserMailDTO>
    {
        private List<Base_UserEasy> _users;
        public List<Base_UserEasy> Users
        {
            get { return _users; }
            set
            {
                SetProperty(ref _users, value);
            }
        }


        private ObservableCollection<Base_UserEasy> _selectedUsers = new ObservableCollection<Base_UserEasy>();
        public ObservableCollection<Base_UserEasy> SelectedUsers
        {
            get { return _selectedUsers; }
            set
            {
                SetProperty(ref _selectedUsers, value);
            }
        }

        protected IOperator _operator { get; }

        public D_UserMailEditViewModel(D_UserMailDTO data, string area, string identifier, string title = "编辑表单") : base(data, area,identifier, title, true)
        {
            _operator = ContainerLocator.Current.Resolve<IOperator>();
            if (Data == null)
            {
                InitData();
            }
            else
            {
                GetData(Data);
            }
        }


        protected override void InitData()
        {
            Data = new D_UserMailDTO();
		}

        protected override async void GetData(D_UserMailDTO para)
        {
            try
            {
                ShowWait();

                var result = await _dataProvider.GetData<D_UserMailDTO>($"/D_Manage/D_UserMail/GetTheData?id={para.Id}");
                if (!result.IsOK)
                {
                    throw new Exception(result.ErrorMessage);
                }
                Data = result.ResponseItem;
                await GetUsers();
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

        private async Task GetUsers()
        {
            Users = await _userData.GetAllUser();
            if (Data != null && Data.UserIds != null)
            {
                SelectedUsers = new ObservableCollection<Base_UserEasy>(Users.Where(p => Data.UserIds.Contains($"^{p.Id}^")));
            }
        }

        private async void Edit(bool isDraft = false)
        {
            if (!string.IsNullOrEmpty(Data.Error))
                return;

            try
            {
                ShowWait();

                this.Data.CreatorName = $"^{_operator?.Property?.UserName}^";
                this.Data.CreatorId = $"^{_operator?.Property?.Id}^";
                this.Data.UserIds = "^" + string.Join("^", this.SelectedUsers.Select(p => p.Id)) + "^";
                this.Data.UserNames = "^" + string.Join("^", this.SelectedUsers.Select(p => p.UserName)) + "^";
                this.Data.IsDraft = isDraft;

                var result = await _dataProvider.GetData<AjaxResult>("/D_Manage/D_UserMail/SaveData", JsonConvert.SerializeObject(this.Data));
                if (!result.IsOK)
                {
                    throw new Exception(result.ErrorMessage);
                }
                InitData();
                WindowBase.ShowMessageQueue(result.ResponseItem?.Msg, Identifier);
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
}
