﻿using AIStudio.Core;
using AIStudio.Wpf.BasePage.Models;
using AIStudio.Wpf.BasePage.ViewModels;
using AIStudio.Wpf.Business;
using AIStudio.Wpf.Controls;
using AIStudio.Wpf.Entity.DTOModels;
using AIStudio.Wpf.OA_Manage.Views;
using Newtonsoft.Json;
using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AIStudio.Wpf.OA_Manage.ViewModels
{
    public class OA_DefFormTreeViewModel : BaseListWithEditViewModel<OA_DefFormDTO, OA_DefFormEdit>
    {
        private ObservableCollection<OA_DefFormTree> _data;
        public new ObservableCollection<OA_DefFormTree> Data
        {
            get { return _data; }
            set
            {
                SetProperty(ref _data, value);
            }
        }

        private ICommand _editCommand;
        public new ICommand EditCommand
        {
            get
            {
                return this._editCommand ?? (this._editCommand = new CanExecuteDelegateCommand<OA_DefFormTree>(para => this.Edit(para)));
            }
        }

        private ICommand _openEditorCommand;
        public ICommand OpenEditorCommand
        {
            get
            {
                return this._openEditorCommand ?? (this._openEditorCommand = new CanExecuteDelegateCommand<OA_DefFormTree>(para => this.OpenEditor(para)));
            }
        }

        protected IUserData _userData { get; }
        protected IOperator _operator { get { return ContainerLocator.Current.Resolve<IOperator>(); } }

        public OA_DefFormTreeViewModel() 
        {
            Area = "OA_Manage";
            NewTitle = "新建流程";
            EditTitle = "编辑流程";
        }

        protected override async Task GetData()
        {
            using (var waitfor = WaitFor.GetWaitFor(this.GetHashCode(), Identifier))
            {
                try
                {
                    var result = await _dataProvider.GetData<List<OA_DefFormTree>>("/OA_Manage/OA_DefForm/GetTreeDataList");
                    if (!result.Success)
                    {
                        throw new Exception(result.Msg);
                    }
                    else
                    {
                        Data = new ObservableCollection<OA_DefFormTree>(result.Data);
                    }
                }
                catch (Exception ex)
                {
                    Controls.MessageBox.Error(ex.Message);
                }
            }
        }

        private async void Edit(OA_DefFormTree para)
        {
            var dialog = new OA_UserFormEdit();
            var viewmodel = new OA_UserFormEditViewModel();
            viewmodel.Options = new OA_UserFormDTO() { Type = para.type, DefFormId = para.key, DefFormName = para.title, JsonId = para.jsonId, JsonVersion = para.jsonVersion, WorkflowJSON = para.json, ApplicantUserId = _operator?.Property?.Id }; ;
            viewmodel.Area = Area;
            viewmodel.Identifier = Identifier;
         
            dialog.ValidationActionAsync += () => { return viewmodel.ValidationAsync(); };
            dialog.Loaded += async (sender, e) => { await viewmodel.OnLoaded(sender, e); };
            dialog.Unloaded += async (sender, e) => { await viewmodel.OnUnloaded(sender, e); };
            dialog.DataContext = viewmodel;

            if (dialog is ChildWindow childwindow)
            {
                var res = (DialogResult)await WindowBase.ShowChildWindowAsync(childwindow, "发起流程", Identifier);
            }
        }

        private async void OpenEditor(OA_DefFormTree para)
        {
            OA_DefFormTreeEdit dialog = new OA_DefFormTreeEdit() { DataContext = new OA_DefFormTreeEditViewModel(para.json) };
            var res = await WindowBase.ShowChildWindowAsync(dialog, "查看流程", Identifier);
        }
    }
}
