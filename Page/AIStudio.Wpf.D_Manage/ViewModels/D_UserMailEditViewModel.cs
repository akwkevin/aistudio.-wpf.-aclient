using AIStudio.Core;
using AIStudio.Wpf.BasePage.ViewModels;
using AIStudio.Wpf.Business;
using AIStudio.Wpf.Entity.DTOModels;
using Newtonsoft.Json;
using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using AIStudio.Wpf.Controls;

namespace AIStudio.Wpf.D_Manage.ViewModels
{
    public class D_UserMailEditViewModel : BaseEditViewModel<D_UserMailDTO>
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

        public D_UserMailEditViewModel(D_UserMailDTO data, string area, string identifier, string title = "编辑表单") : base(data, area,identifier, title)
        {
            _operator = ContainerLocator.Current.Resolve<IOperator>();
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

                var result = await _dataProvider.GetData<D_UserMailDTO>($"/D_Manage/D_UserMail/GetTheData", JsonConvert.SerializeObject(new { id = para.Id }));
                if (!result.Success)
                {
                    throw new Exception(result.Msg);
                }
                Data = result.Data;
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
            Users = await _userData.GetBase_User();
            if (Data != null && Data.UserIds != null)
            {
                SelectedUsers = new ObservableCollection<ISelectOption>(Users.Where(p => Data.UserIds.Contains($"^{p.Value}^")));
            }
        }        

    }
}
