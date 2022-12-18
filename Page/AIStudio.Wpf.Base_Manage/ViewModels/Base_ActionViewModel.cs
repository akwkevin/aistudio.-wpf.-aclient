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
    public class Base_ActionViewModel : BaseListWithEditViewModel<Base_ActionTree, Base_ActionEdit>
    {
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
                return this._deleteCommand ?? (this._deleteCommand = new CanExecuteDelegateCommand(async () => await this.Delete(), () => this.Data != null && this.Data.Count(p => p.IsChecked == true) > 0));
            }
        }

        public Base_ActionViewModel()
        {
            Area = "Base_Manage";
            GetDataList = "GetMenuTreeList";
            NewTitle = "新建权限";
            EditTitle = "编辑权限";
            Pagination.PageRows = Int32.MaxValue;
        }

        protected override IBaseEditViewModel GetEditViewModel()
        {
            return new Base_ActionEditViewModel();
        }   
    }
}
