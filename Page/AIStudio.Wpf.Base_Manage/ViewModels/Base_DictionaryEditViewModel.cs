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

        public Base_DictionaryEditViewModel(Base_DictionaryTree dataTree, string area, string identifier, string title = "编辑表单") : base(null, area, identifier, title, autoInit:false)
        {
            if (dataTree == null)
            {
                InitData();
            }
            else
            {
                GetData(dataTree);
            }
        }

        protected override async void InitData()
        {
            Data = new Base_DictionaryDTO();
            await GetParentIdTreeData();
        }

        protected async  void GetData(Base_DictionaryTree dataTree)
        {
            try
            {
                WindowBase.ShowWaiting(WaitingStyle.Busy, Identifier, "正在获取数据");

                var result = await _dataProvider.GetData<Base_DictionaryDTO>($"/Base_Manage/Base_Dictionary/GetTheData", JsonConvert.SerializeObject(new { id = dataTree.Id }));
                if (!result.Success)
                {
                    throw new Exception(result.Msg);
                }
                Data = result.Data;

                await GetParentIdTreeData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                WindowBase.HideWaiting(Identifier);
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
