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
using AIStudio.Wpf.BasePage.Views;

namespace AIStudio.Wpf.Base_Manage.ViewModels
{
    public class Base_ActionViewModel : BaseListWithEditViewModel<Base_ActionDTO, Base_ActionEdit>
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
                return this._addCommand ?? (this._addCommand = new CanExecuteDelegateCommand(() => this.Edit()));
            }
        }

        private ICommand _editCommand;
        public new ICommand EditCommand
        {
            get
            {
                return this._editCommand ?? (this._editCommand = new CanExecuteDelegateCommand<Base_ActionTree>(para => this.Edit(para)));
            }
        }

        private ICommand _deleteCommand;
        public new ICommand DeleteCommand
        {
            get
            {
                return this._deleteCommand ?? (this._deleteCommand = new CanExecuteDelegateCommand(() => this.Delete(), () => this.Data != null && this.Data.Count(p => p.IsChecked == true) > 0));
            }
        }

        public Base_ActionViewModel()
        {
            Area = "Base_Manage";
            Condition = "";
            GetDataList = "GetMenuTreeList";
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


                var result = await _dataProvider.GetData<List<Base_ActionTree>>($"/Base_Manage/Base_Action/GetMenuTreeList", GetDataJson());
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

        protected override BaseEditViewModel2<Base_ActionDTO> GetEditViewModel()
        {
            return new Base_ActionEditViewModel();
        }

        protected void Edit(Base_ActionTree paraTree = null)
        {
            base.Edit(new Base_ActionDTO() { Id = paraTree.Id });
        }

        protected override async Task Delete(string id = null)
        {
            List<string> ids = new List<string>();
            if (string.IsNullOrEmpty(id))
            {
                ids.AddRange(Data.Select(p => p as Base_ActionTree).Where(p => p.IsChecked == true).Select(p => p.Id));
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
    }
}
