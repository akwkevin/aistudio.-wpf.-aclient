﻿using AIStudio.Core;
using AIStudio.Wpf.Base_Manage.Views;
using AIStudio.Wpf.BasePage.DTOModels;
using AIStudio.Wpf.BasePage.ViewModels;
using AIStudio.Wpf.Entity.DTOModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using AIStudio.Wpf.Controls;
using System.Threading.Tasks;

namespace AIStudio.Wpf.Base_Manage.ViewModels
{
    public class Base_DepartmentViewModel : BaseListViewModel<Base_DepartmentDTO, Base_DepartmentEdit>
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

        private ObservableCollection<Base_UserDTO> _data2;
        public ObservableCollection<Base_UserDTO> Data2
        {
            get { return _data2; }
            set
            {
                if (_data2 != value)
                {
                    _data2 = value;
                    RaisePropertyChanged("Data2");
                }
            }
        }


        private ICommand _addCommand;
        public new ICommand AddCommand
        {
            get
            {
                return this._addCommand ?? (this._addCommand = new CanExecuteDelegateCommand(() => this.Edit()));
            }
        }

        private ICommand _editCommand;
        public new ICommand EditCommand
        {
            get
            {
                return this._editCommand ?? (this._editCommand = new CanExecuteDelegateCommand<Base_DepartmentTree>(para => this.Edit(para)));
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

        private ICommand _selectedCommand;
        public ICommand SelectedCommand
        {
            get
            {
                return this._selectedCommand ?? (this._selectedCommand = new CanExecuteDelegateCommand<Base_DepartmentTree>(para => this.Selected(para)));
            }
        }

        public Base_DepartmentViewModel()
        {
            Area = "Base_Manage";
            Condition = "Name";
            Pagination = new Core.Models.Pagination() { PageRows = Int32.MaxValue };
        }

        protected override async Task GetData(bool iswaiting = false)
        {
            try
            {
                if (iswaiting == false)
                {
                    ShowWait();
                }

                var result = await _dataProvider.GetData<List<Base_DepartmentTree>>($"/Base_Manage/Base_Department/GetTreeDataList", GetDataJson());
                if (!result.Success)
                {
                    throw new Exception(result.Msg);
                }
                else
                {
                    Data = new ObservableCollection<IBaseTreeItemViewModel>(result.Data);
                    Data2 = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Error(ex.Message);
            }
            finally
            {
                if (iswaiting == false)
                {
                    HideWait();
                }
            }
        }

        protected override BaseEditViewModel2<Base_DepartmentDTO> GetEditViewModel()
        {
            return new Base_DepartmentEditViewModel();
        }

        protected void Edit(Base_DepartmentTree paraTree = null)
        {
            base.Edit(new Base_DepartmentDTO() { Id = paraTree.Id });
        }

        protected override async Task Delete(string id = null)
        {
            List<string> ids = new List<string>();
            if (string.IsNullOrEmpty(id))
            {
                ids.AddRange(Data.Select(p => p as Base_DepartmentTree).Where(p => p.IsChecked == true).Select(p => p.Id));
            }
            else
            {
                ids.Add(id);
            }

            await base.Delete(ids);
        }

        protected override void Print()
        {
            base.Print(Data);
        }

        protected override void Search(object para = null)
        {
            base.Search(para);
        }

        private async void Selected(Base_DepartmentTree para)
        {
            try
            {
                WindowBase.ShowWaiting(WaitingStyle.Busy, Identifier, "正在获取数据");

                var searchKeyValues = new Dictionary<string, object>() 
                {
                    {"DepartmentId", para.Id }
                };

                var data = new
                {
                    SearchKeyValues = searchKeyValues,
                };

                var result = await _dataProvider.GetData<List<Base_UserDTO>>($"/Base_Manage/Base_User/GetDataList", JsonConvert.SerializeObject(data));
                if (!result.Success)
                {
                    throw new Exception(result.Msg);
                }
                Data2 = new ObservableCollection<Base_UserDTO>(result.Data);
            }
            catch (Exception ex)
            {
                MessageBox.Error(ex.Message);
            }
            finally
            {
                WindowBase.HideWaiting(Identifier);
            }
        }
    }
}
