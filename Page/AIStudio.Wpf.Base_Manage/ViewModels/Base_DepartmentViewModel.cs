using AIStudio.Core;
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
    public class Base_DepartmentViewModel : BaseListWithEditViewModel<Base_DepartmentTree, Base_DepartmentEdit>
    {
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
            GetDataList = "GetTreeDataList";
            Condition = "Name";
            NewTitle = "新建部门";
            EditTitle = "编辑部门";
            Pagination.PageRows = Int32.MaxValue;
        }       

        protected override IBaseEditViewModel GetEditViewModel()
        {
            return new Base_DepartmentEditViewModel();
        }

        private async void Selected(Base_DepartmentTree para)
        {
            try
            {
                ShowWait();

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
                HideWait();
            }
        }
    }
}
