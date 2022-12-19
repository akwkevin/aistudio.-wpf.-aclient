using AIStudio.Wpf.BasePage.ViewModels;
using AIStudio.Wpf.Entity.DTOModels;
using AIStudio.Wpf.Business;
using Prism.Ioc;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using AIStudio.Wpf.BasePage.DTOModels;
using AIStudio.Wpf.Controls;
using System.Threading.Tasks;
using Newtonsoft.Json;
using AIStudio.Core;
using AIStudio.Wpf.GridControls.ViewModel;
using AIStudio.Wpf.BasePage.Models;

namespace AIStudio.Wpf.Base_Manage.ViewModels
{
    public class Base_DictionaryEditViewModel : BaseEditViewModel<Base_DictionaryDTO>
    {
        private ObservableCollection<Base_DictionaryTree> _parentIdTreeData;
        public ObservableCollection<Base_DictionaryTree> ParentIdTreeData
        {
            get { return _parentIdTreeData; }
            set
            {
                SetProperty(ref _parentIdTreeData, value);
            }
        }

        private Base_DictionaryTree _selectedParent;
        public Base_DictionaryTree SelectedParent
        {
            get { return _selectedParent; }
            set
            {
                SetProperty(ref _selectedParent, value);
            }
        }

        protected override async Task GetData(object option)
        {
            using (var waitfor = WaitFor.GetWaitFor(this.GetHashCode(), Identifier))
            {
                try
                {
                    await base.GetData(option);
                    await GetParentIdTreeData();                   
                }
                catch (Exception ex)
                {
                    Controls.MessageBox.Error(ex.Message);
                }
            }
        }

        protected override async Task<bool> SaveData()
        {
            using (var waitfor = WaitFor.GetWaitFor(this.GetHashCode(), Identifier))
            {
                try
                {
                    Data.ParentId = SelectedParent?.Id;                  
                    return await base.SaveData();
                }
                catch (Exception ex)
                {
                    MessageBox.Error(ex.Message);
                    return false;
                }
            }
        }

        private async Task GetParentIdTreeData()
        {
            var result = await _dataProvider.GetData<List<Base_DictionaryTree>>($"/Base_Manage/Base_Dictionary/GetTreeDataList");
            if (!result.Success)
            {
                throw new Exception(result.Msg);
            }
            else
            {
                ParentIdTreeData = new ObservableCollection<Base_DictionaryTree>(result.Data);
                SelectedParent = GetTreeItem(ParentIdTreeData, Data.ParentId);
            }
        }

        private Base_DictionaryTree GetTreeItem(ObservableCollection<Base_DictionaryTree> parentIdTreeData, string id)
        {
            foreach (var data in parentIdTreeData)
            {
                if (data.Id == id)
                {
                    return data;
                }
                else
                {
                    if (data.Children != null)
                    {
                        var child = GetTreeItem(data.Children, id);
                        if (child != null)
                            return child;
                    }
                }
            }

            return null;
        }
    }
}
