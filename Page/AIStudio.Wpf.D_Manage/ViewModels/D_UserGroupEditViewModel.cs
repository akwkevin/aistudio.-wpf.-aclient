using AIStudio.Core;
using AIStudio.Wpf.BasePage.ViewModels;
using AIStudio.Wpf.Business;
using AIStudio.Wpf.Controls;
using AIStudio.Wpf.Entity.DTOModels;
using Newtonsoft.Json;
using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace AIStudio.Wpf.D_Manage.ViewModels
{
    public class D_UserGroupEditViewModel : BaseEditViewModel<D_UserGroupDTO>
    {
        private ObservableCollection<ISelectOption> _users;
        public ObservableCollection<ISelectOption> Users
        {
            get { return _users; }
            set
            {
                SetProperty(ref _users, value);
            }
        }

        private ObservableCollection<ISelectOption> _selectedUsers = new ObservableCollection<ISelectOption>();
        public ObservableCollection<ISelectOption> SelectedUsers
        {
            get { return _selectedUsers; }
            set
            {
                SetProperty(ref _selectedUsers, value);
            }
        }

        protected IOperator _operator { get; }
        public D_UserGroupEditViewModel(D_UserGroupDTO data, string area, string identifier, string title = "编辑表单") : base(data, area,identifier, title)
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

		protected override async void InitData()
		{
			Data = new D_UserGroupDTO();
            await GetUsers();
        }

        protected override async void GetData(D_UserGroupDTO para)
        {
            try
            {
                WindowBase.ShowWaiting(WaitingStyle.Busy, Identifier, "正在获取数据");

                var result = await _dataProvider.GetData<D_UserGroupDTO>($"/{Area}/D_UserMessage/GetTheData", JsonConvert.SerializeObject(new { id = para.Id }));
                if (!result.Success)
                {
                    throw new Exception(result.Msg);
                }
                Data = result.Data;
                Disabled = Data.CreatorId != _operator?.Property?.Id;
                await GetUsers();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                WindowBase.HideWaiting(Identifier);
            }
        }

        private async Task GetUsers()
        {
            Users = await _userData.GetAllUser();
            if (Data != null && Data.UserIds != null)
            {
                SelectedUsers = new ObservableCollection<ISelectOption>(Users.Where(p => Data.UserIds.Contains($"^{p.Value}^")));
            }
        }
    }
}
