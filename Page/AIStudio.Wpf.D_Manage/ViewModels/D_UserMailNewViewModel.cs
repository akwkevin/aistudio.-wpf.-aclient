using AIStudio.Core;
using AIStudio.Wpf.BasePage.ViewModels;
using AIStudio.Wpf.Business;
using AIStudio.Wpf.Entity.DTOModels;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using AIStudio.Wpf.Controls;

namespace AIStudio.Wpf.D_Manage.ViewModels
{
    public class D_UserMailNewViewModel : BaseEditViewModel<D_UserMailDTO>
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

        private ICommand _addCommand;
        public ICommand AddCommand
        {
            get
            {
                return this._addCommand ?? (this._addCommand = new DelegateCommand(() => this.Edit()));
            }
        }

        private ICommand _editCommand;
        public ICommand EditCommand
        {
            get
            {
                return this._editCommand ?? (this._editCommand = new DelegateCommand(() => this.Edit(true)));
            }
        }

        private ICommand _resetCommand;
        public ICommand ResetCommand
        {
            get
            {
                return this._resetCommand ?? (this._resetCommand = new DelegateCommand(() => this.Reset()));
            }
        }

        protected IOperator _operator { get; }

        public D_UserMailNewViewModel(string area, string identifier, string title = "编辑表单") : base(null, area, identifier, title, autoInit:false)
        {
            _operator = ContainerLocator.Current.Resolve<IOperator>();
            if (Data == null)
            {
                InitData();
            }
        }



        protected override async void InitData()
        {
            Data = new D_UserMailDTO();
            SelectedUsers = new ObservableCollection<ISelectOption>();
            await GetUsers();
        }

        private async Task GetUsers()
        {
            Users = await _userData.GetBase_User();
            if (Data != null && Data.UserIds != null)
            {
                SelectedUsers = new ObservableCollection<ISelectOption>(Users.Where(p => Data.UserIds.Contains($"^{p.Value}^")));
            }
        }
    

        private async void Edit(bool isDraft=false)
        {
            if (!string.IsNullOrEmpty(Data.Error))
                return;

            try
            {
                ShowWait();

                this.Data.CreatorName = $"^{_operator?.Property?.UserName}^";
                this.Data.CreatorId = $"^{_operator?.Property?.Id}^";
                this.Data.UserIds = "^" + string.Join("^", this.SelectedUsers.Select(p => p.Value)) + "^";
                this.Data.UserNames = "^" + string.Join("^", this.SelectedUsers.Select(p => p.Text)) + "^";
                this.Data.Status = isDraft ? 0 : 1;

                var result = await _dataProvider.GetData<AjaxResult>("/D_Manage/D_UserMail/SaveData", JsonConvert.SerializeObject(this.Data));
                if (!result.Success)
                {
                    throw new Exception(result.Msg);
                }
                InitData();
                WindowBase.ShowMessageQueue("发送成功", Identifier);
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

        private void Reset()
        {
            InitData();
        }

    }
}
