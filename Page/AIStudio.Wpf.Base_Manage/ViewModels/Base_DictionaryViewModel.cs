﻿using AIStudio.Core;
using AIStudio.Wpf.Base_Manage.Views;
using AIStudio.Wpf.BasePage.DTOModels;
using AIStudio.Wpf.BasePage.ViewModels;
using AIStudio.Wpf.Controls;
using AIStudio.Wpf.Entity.DTOModels;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AIStudio.Wpf.Base_Manage.ViewModels
{
    public class Base_DictionaryViewModel : BaseListWithEditViewModel<Base_DictionaryDTO, Base_DictionaryEdit>
    {
        private ObservableCollection<IBaseTreeItemViewModel> _data;
        public new ObservableCollection<IBaseTreeItemViewModel> Data
        {
            get { return _data; }
            set
            {
                if (_data != value)
                {
                    _data = value;
                    RaisePropertyChanged("Data");
                }
            }
        }

        private ICommand _addCommand;
        public new ICommand AddCommand
        {
            get
            {
                return this._addCommand ?? (this._addCommand = new DelegateCommand(() => this.Edit()));
            }
        }

        private ICommand _editCommand;
        public new ICommand EditCommand
        {
            get
            {
                return this._editCommand ?? (this._editCommand = new CanExecuteDelegateCommand<Base_DictionaryTree>(para => this.Edit(para)));
            }
        }

        private ICommand _deleteCommand;
        public new ICommand DeleteCommand
        {
            get
            {
                return this._deleteCommand ?? (this._deleteCommand = new CanExecuteDelegateCommand(async () => await this.Delete(), () => this.Data != null && this.Data.Count(p => p.IsChecked == true) > 0));
            }
        }

        public Base_DictionaryViewModel()
        {
            Area = "Base_Manage";
            GetDataList = "GetMenuTreeList";         
            NewTitle = "新建字典";
            EditTitle = "编辑字典";
            Pagination.PageRows = Int32.MaxValue;
            Pagination.SortField = "Sort";
            Pagination.SortType = "asc";
        }

        protected override async Task GetData(bool iswaiting = false)
        {
            try
            {
                if (iswaiting == false)
                {
                    ShowWait();
                }

                var result = await _dataProvider.GetData<List<Base_DictionaryTree>>($"/Base_Manage/Base_Dictionary/GetTreeDataList", GetDataJson());
                if (!result.Success)
                {
                    throw new Exception(result.Msg);
                }
                else
                {
                    Data = new ObservableCollection<IBaseTreeItemViewModel>(result.Data);
                }
            }
            catch (Exception ex)
            {
                Controls.MessageBox.Error(ex.Message);
            }
            finally
            {
                if (iswaiting == false)
                {
                    HideWait();
                }
            }
        }

        protected override IBaseEditViewModel GetEditViewModel()
        {
            return new Base_DictionaryEditViewModel();
        }

        protected void Edit(Base_DictionaryTree paraTree = null)
        {
            base.Edit(new Base_DictionaryDTO() { Id = paraTree?.Id });
        }

        protected override async Task Delete(string id = null)
        {
            List<string> ids = new List<string>();
            if (string.IsNullOrEmpty(id))
            {
                ids.AddRange(Data.Select(p => p as Base_DictionaryTree).Where(p => p.IsChecked == true).Select(p => p.Id));
            }
            else
            {
                ids.Add(id);
            }

            await base.Delete(ids);
        }

        protected override void Search(object para=null)
        {
            base.Search(para);
        }
    }
}
