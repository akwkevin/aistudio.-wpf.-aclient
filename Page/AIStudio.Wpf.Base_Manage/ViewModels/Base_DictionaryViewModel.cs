using AIStudio.Core;
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
    public class Base_DictionaryViewModel : BaseListWithEditViewModel<Base_DictionaryTree, Base_DictionaryEdit>
    {
        public Base_DictionaryViewModel()
        {
            Area = "Base_Manage";
            GetDataList = "GetTreeDataList";         
            NewTitle = "新建字典";
            EditTitle = "编辑字典";
            Pagination.PageRows = Int32.MaxValue;
            Pagination.SortField = "Sort";
            Pagination.SortType = "asc";
        }
       
        protected override IBaseEditViewModel GetEditViewModel()
        {
            return new Base_DictionaryEditViewModel();
        }      
    }
}
