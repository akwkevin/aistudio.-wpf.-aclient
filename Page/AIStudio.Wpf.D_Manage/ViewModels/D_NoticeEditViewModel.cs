using AIStudio.Wpf.BasePage.ViewModels;
using AIStudio.Wpf.EFCore.DTOModels;
using AIStudio.Wpf.Business;
using Prism.Ioc;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using AIStudio.Core;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Util.Controls;

namespace AIStudio.Wpf.D_Manage.ViewModels
{
    public class D_NoticeEditViewModel : BaseEditViewModel<D_NoticeDTO>
    {
        private List<SelectOption> _users;
        public List<SelectOption> Users
        {
            get { return _users; }
            set
            {
                SetProperty(ref _users, value);
            }
        }


        private ObservableCollection<SelectOption> _selectedUsers = new ObservableCollection<SelectOption>();
        public ObservableCollection<SelectOption> SelectedUsers
        {
            get { return _selectedUsers; }
            set
            {
                SetProperty(ref _selectedUsers, value);
            }
        }

        private List<SelectOption> _roles;
        public List<SelectOption> Roles
        {
            get { return _roles; }
            set
            {
                SetProperty(ref _roles, value);
            }
        }


        private ObservableCollection<SelectOption> _selectedRoles = new ObservableCollection<SelectOption>();
        public ObservableCollection<SelectOption> SelectedRoles
        {
            get { return _selectedRoles; }
            set
            {
                SetProperty(ref _selectedRoles, value);
            }
        }

        protected IOperator _operator { get; }

        public D_NoticeEditViewModel(D_NoticeDTO data, string area, string identifier, string title = "编辑表单") : base(data, area, identifier, title, true)
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
			Data = new D_NoticeDTO();
            await GetUsers();
            await GetRoles();
        }

        protected override async void GetData(D_NoticeDTO para)
        {
            try
            {
                ShowWait();

                var result = await _dataProvider.GetData<D_NoticeDTO>($"/D_Manage/D_Notice/GetTheData", JsonConvert.SerializeObject(new { id = para.Id }));
                if (!result.IsOK)
                {
                    throw new Exception(result.ErrorMessage);
                }
                Data = result.ResponseItem;
                await GetUsers();
                await GetRoles();
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
            if (Data != null && Data.Mode == 1 && Data.AnyId != null)
            {
                SelectedUsers = new ObservableCollection<SelectOption>(Users.Where(p => Data.AnyId.Contains($"^{p.value}^")));
            }
        }

        private async Task GetRoles()
        {
            Roles = await _userData.GetAllRole();
            if (Data != null && Data.Mode == 2 && Data.AnyId != null)
            {
                SelectedRoles = new ObservableCollection<SelectOption>(Users.Where(p => Data.AnyId.Contains($"^{p.value}^")));
            }
        }
       
    }
}
