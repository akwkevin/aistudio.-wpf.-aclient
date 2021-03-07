﻿using AIStudio.Wpf.BasePage.ViewModels;
using AIStudio.Wpf.Business;
using AIStudio.Wpf.Business.DTOModels;
using AIStudio.Wpf.Service.AppClient;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Util.Controls;

namespace AIStudio.Wpf.D_Manage.ViewModels
{
    public class D_UserMailNewViewModel : BaseEditViewModel<D_UserMailDTO>
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

        public D_UserMailNewViewModel(string area, string identifier, string title = "编辑表单") : base(null, area, identifier, title, true)
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
            SelectedUsers = new ObservableCollection<Base_UserEasy>();
            await GetUsers();
        }

        private async Task GetUsers()
        {
            Users = await _userData.GetAllUser();
            if (Data != null && Data.UserIds != null)
            {
                SelectedUsers = new ObservableCollection<Base_UserEasy>(Users.Where(p => Data.UserIds.Contains($"^{p.Id}^")));
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
                this.Data.UserIds = "^" + string.Join("^", this.SelectedUsers.Select(p => p.Id)) + "^";
                this.Data.UserNames = "^" + string.Join("^", this.SelectedUsers.Select(p => p.UserName)) + "^";
                this.Data.IsDraft = isDraft;

                var result = await _dataProvider.GetData<AjaxResult>("/D_Manage/D_UserMail/SaveData", JsonConvert.SerializeObject(this.Data));
                if (!result.IsOK)
                {
                    throw new Exception(result.ErrorMessage);
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
