using AIStudio.Core;
using AIStudio.Wpf.BasePage.DTOModels;
using AIStudio.Wpf.BasePage.Models;
using AIStudio.Wpf.BasePage.ViewModels;
using AIStudio.Wpf.Controls;
using AIStudio.Wpf.Entity.DTOModels;
using AIStudio.Wpf.GridControls.ViewModel;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace AIStudio.Wpf.Base_Manage.ViewModels
{
    public class Base_RoleEditViewModel : BaseEditViewModel<Base_RoleDTO>
    {
        private ObservableCollection<Base_ActionTree> _actionsTreeData;
        public ObservableCollection<Base_ActionTree> ActionsTreeData
        {
            get { return _actionsTreeData; }
            set
            {
                SetProperty(ref _actionsTreeData, value);
            }
        }

        private ObservableCollection<Base_ActionDTO> _allActionList;
        public ObservableCollection<Base_ActionDTO> AllActionList
        {
            get { return _allActionList; }
            set
            {
                SetProperty(ref _allActionList, value);
            }
        }

        protected override async Task GetData(object option)
        {
            using (var waitfor = WaitFor.GetWaitFor(this.GetHashCode(), Identifier))
            {
                try
                {
                    await base.GetData(option);
                    await GetActionsTreeData();                 
                    SetChecked(ActionsTreeData);
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
                    Data.Actions = new ObservableCollection<string>(BaseTreeItemViewModelHelper.GetChecked(ActionsTreeData).OfType<Base_ActionTree>().Select(p => p.Id));
                    return await base.SaveData();
                }
                catch (Exception ex)
                {
                    MessageBox.Error(ex.Message);
                    return false;
                }
            }
        }

        private async Task GetActionsTreeData()
        {
            var result = await _dataProvider.PostData<List<Base_ActionTree>>($"/Base_Manage/Base_Action/GetActionTreeList");
            if (!result.Success)
            {
                throw new Exception(result.Msg);
            }
            else
            {
                ActionsTreeData = new ObservableCollection<Base_ActionTree>(result.Data);
            }            
        }

        private async Task GetAllActionList()
        {
            var result = await _dataProvider.PostData<List<Base_ActionDTO>>($"/Base_Manage/Base_Action/GetAllActionList");
            if (!result.Success)
            {
                throw new Exception(result.Msg);
            }
            else
            {
                AllActionList = new ObservableCollection<Base_ActionDTO>(result.Data);
            }
        }

        private void SetChecked(IEnumerable<Base_ActionTree> trees)
        {
            if (trees == null || Data == null) return;

            foreach (var tree in trees)
            {
                if (Data.Actions.Any(p => p == tree.Id))
                {
                    tree.SetChecked(true);
                }
                SetChecked(tree.Children);
            }
        }
    }
}
