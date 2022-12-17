using AIStudio.Core;
using AIStudio.Wpf.BasePage.DTOModels;
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

        public Base_RoleEditViewModel()
        {

        }

        protected override async Task GetData(object option)
        {
            try
            {
                WindowBase.ShowWaiting(WaitingStyle.Busy, Identifier, "正在获取数据");

                if (option is string id)
                {
                    var result = await _dataProvider.GetData<Base_RoleDTO>($"/Base_Manage/Base_Role/GetTheData", JsonConvert.SerializeObject(new { id = id }));
                    if (!result.Success)
                    {
                        throw new Exception(result.Msg);
                    }
                    Data = result.Data;
                }
                else
                {
                    Data = new Base_RoleDTO();
                }
                await GetActionsTreeData();
                //await GetAllActionList();

                SetChecked(ActionsTreeData);
            }
            catch (Exception ex)
            {
                Controls.MessageBox.Error(ex.Message);
            }
            finally
            {
                WindowBase.HideWaiting(Identifier);
            }
        }

        public override async Task<bool> SaveData()
        {
            try
            {
                ShowWait();
                Data.Actions = new ObservableCollection<string>(BaseTreeItemViewModelHelper.GetChecked(ActionsTreeData).OfType<Base_ActionTree>().Select(p => p.Id));
                var result = await _dataProvider.GetData<AjaxResult>($"/Base_Manage/Base_Role/SaveData", Data.ToJson());
                if (!result.Success)
                {
                    throw new Exception(result.Msg);
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Error(ex.Message);
                return false;
            }
            finally
            {
                HideWait();
            }
        }

        private async Task GetActionsTreeData()
        {
            var result = await _dataProvider.GetData<List<Base_ActionTree>>($"/Base_Manage/Base_Action/GetActionTreeList");
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
            var result = await _dataProvider.GetData<List<Base_ActionDTO>>($"/Base_Manage/Base_Action/GetAllActionList");
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

            foreach(var tree in trees)
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
