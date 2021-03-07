using AIStudio.Wpf.BasePage.DTOModels;
using AIStudio.Wpf.BasePage.ViewModels;
using AIStudio.Wpf.Business.DTOModels;
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

        public Base_RoleEditViewModel(Base_RoleDTO data, string area, string identifier, string title = "编辑表单") : base(data, area, identifier, title)
        {
            if (Data == null)
            {
                InitData();
            }
            else
            {
                GetData(Data);
            }
        }

        protected override async void GetData(Base_RoleDTO para)
        {
            try
            {
                var control = Util.Controls.WindowBase.ShowWaiting(Util.Controls.WaitingType.Busy, Identifier);
                control.WaitInfo = "正在获取数据";

                var result = await _dataProvider.GetData<Base_RoleDTO>($"/Base_Manage/Base_Role/GetTheData?id={para.Id}");
                if (!result.IsOK)
                {
                    throw new Exception(result.ErrorMessage);
                }
                Data = result.ResponseItem;

                await GetActionsTreeData();
                //await GetAllActionList();

                SetChecked(ActionsTreeData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Util.Controls.WindowBase.HideWaiting(Identifier);
            }
        }

        protected override async void InitData()
        {
            Data = new Base_RoleDTO();
            await GetActionsTreeData();
        }

        private async Task GetActionsTreeData()
        {
            var result = await _dataProvider.GetData<List<Base_ActionTree>>($"/Base_Manage/Base_Action/GetActionTreeList");
            if (!result.IsOK)
            {
                throw new Exception(result.ErrorMessage);
            }
            else
            {
                ActionsTreeData = new ObservableCollection<Base_ActionTree>(result.ResponseItem);
            }
        }

        private async Task GetAllActionList()
        {
            var result = await _dataProvider.GetData<List<Base_ActionDTO>>($"/Base_Manage/Base_Action/GetAllActionList");
            if (!result.IsOK)
            {
                throw new Exception(result.ErrorMessage);
            }
            else
            {
                AllActionList = new ObservableCollection<Base_ActionDTO>(result.ResponseItem);
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
