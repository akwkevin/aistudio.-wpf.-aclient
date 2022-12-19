﻿using AIStudio.Core;
using AIStudio.Wpf.BasePage.ViewModels;
using AIStudio.Wpf.Business;
using AIStudio.Wpf.Controls;
using AIStudio.Wpf.Entity.DTOModels;
using AIStudio.Wpf.OA_Manage.Views;
using Newtonsoft.Json;
using Prism.Ioc;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Org.BouncyCastle.Crypto;
using AIStudio.Wpf.BasePage.Models;

namespace AIStudio.Wpf.OA_Manage.ViewModels
{
    public class OA_DefFormViewModel : BaseListWithEditViewModel<OA_DefFormDTO, OA_DefFormEdit>
    {
        private ObservableCollection<ISelectOption> _roles;
        public ObservableCollection<ISelectOption> Roles
        {
            get { return _roles; }
            set
            {
                SetProperty(ref _roles, value);
            }
        }

        private ICommand _stopCommand;
        public ICommand StopCommand
        {
            get
            {
                return this._stopCommand ?? (this._stopCommand = new CanExecuteDelegateCommand(() => this.Stop(null), () => this.Data != null && this.Data.Count(p => p.IsChecked == true) > 0));
            }
        }

        private ICommand _startCommand;
        public ICommand StartCommand
        {
            get
            {
                return this._startCommand ?? (this._startCommand = new CanExecuteDelegateCommand(() => this.Start(null), () => this.Data != null && this.Data.Count(p => p.IsChecked == true) > 0));
            }
        }

        private ICommand _startOneCommand;
        public ICommand StartOneCommand
        {
            get
            {
                return this._startOneCommand ?? (this._startOneCommand = new DelegateCommand<string>(para => this.Start(para)));
            }
        }

        private ICommand _stopOneCommand;
        public ICommand StopOneCommand
        {
            get
            {
                return this._stopOneCommand ?? (this._stopOneCommand = new DelegateCommand<string>(para => this.Stop(para)));
            }
        }

        protected IUserData _userData { get { return ContainerLocator.Current.Resolve<IUserData>(); } }
        public OA_DefFormViewModel()
        {
            Area = "OA_Manage";
            Condition = "Name";                      
        }

        private async Task GetRoles()
        {
            Roles = await _userData.GetBase_Role();
        }

        protected override async Task GetData()
        {
            using (var waitfor = WaitFor.GetWaitFor(this.GetHashCode(), Identifier))
            {
                try
                {
                    var result = await _dataProvider.GetData<List<OA_DefFormDTO>>($"/{Area}/{typeof(OA_DefFormDTO).Name.Replace("DTO", "")}/{GetDataList}", GetDataJson());
                    if (!result.Success)
                    {
                        throw new Exception(result.Msg);
                    }
                    else
                    {
                        Pagination.Total = result.Total;
                        Data = new ObservableCollection<OA_DefFormDTO>(result.Data);

                        await GetRoles();
                        foreach (var item in Data)
                        {
                            if (item.ValueRoles != null)
                                item.Roles = Roles.Where(p => item.ValueRoles.Contains(p.Value)).ToList();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Controls.MessageBox.Error(ex.Message);
                }
            }
        }

        protected override IBaseEditViewModel GetEditViewModel()
        {
            return new OA_DefFormEditViewModel();
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

        private async void Start(string id)
        {
            List<string> ids = new List<string>();
            if (string.IsNullOrEmpty(id))
            {
                ids.AddRange(Data.Where(p => p.IsChecked == true).Select(p => p.Id));
            }
            else
            {
                ids.Add(id);
            }
            var sure = await MessageBoxDialog.Show("确认启用吗?", "提示", ControlStatus.Mid, Identifier);
            if (sure == DialogResult.OK)
            {
                using (var waitfor = WaitFor.GetWaitFor(this.GetHashCode(), Identifier))
                {
                    try
                    {

                        var result = await _dataProvider.GetData<AjaxResult>($"/OA_Manage/OA_DefForm/StartData", JsonConvert.SerializeObject(ids));
                        if (!result.Success)
                        {
                            throw new Exception(result.Msg);
                        }
                        await GetData();
                    }
                    catch (Exception ex)
                    {
                        Controls.MessageBox.Error(ex.Message);
                    }
                }
            }
        }

        private async void Stop(string id)
        {
            List<string> ids = new List<string>();
            if (string.IsNullOrEmpty(id))
            {
                ids.AddRange(Data.Where(p => p.IsChecked == true).Select(p => p.Id));
            }
            else
            {
                ids.Add(id);
            }
            var sure = await MessageBoxDialog.Show("确认停用吗?", "提示", ControlStatus.Mid, Identifier);
            if (sure == DialogResult.OK)
            {
                using (var waitfor = WaitFor.GetWaitFor(this.GetHashCode(), Identifier))
                {
                    try
                    {
                        var result = await _dataProvider.GetData<AjaxResult>($"/OA_Manage/OA_DefForm/StopData", JsonConvert.SerializeObject(ids));
                        if (!result.Success)
                        {
                            throw new Exception(result.Msg);
                        }
                        await GetData();
                    }
                    catch (Exception ex)
                    {
                        Controls.MessageBox.Error(ex.Message);
                    }
                }
            }
        }
    }
}
