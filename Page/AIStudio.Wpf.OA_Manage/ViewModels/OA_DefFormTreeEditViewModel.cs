using Aga.Diagrams.TestExtend.Flowchart;
using AIStudio.Wpf.Business.DTOModels;
using AIStudio.Wpf.OA_Manage.Models;
using AIStudio.Wpf.Business;
using Prism.Ioc;
using Prism.Mvvm;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Util.Controls;

namespace AIStudio.Wpf.OA_Manage.ViewModels
{
    public class OA_DefFormTreeEditViewModel : BindableBase
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                SetProperty(ref _title, value);
            }
        }

        private List<SelectOption> _roles;
        public List<SelectOption> Roles
        {
            get { return _roles; }
            set
            {
                SetProperty(ref _roles, value);
            }
        }


        private List<SelectOption> _users;
        public List<SelectOption> Users
        {
            get { return _users; }
            set
            {
                SetProperty(ref _users, value);
            }
        }

        private FlowchartModel _flowchartModel;
        public FlowchartModel FlowchartModel
        {
            get { return _flowchartModel; }
            set
            {
                SetProperty(ref _flowchartModel, value);
            }
        }

        protected IUserData _userData { get; }

        public OA_DefFormTreeEditViewModel(string workflowJSON, string title = "查看流程图") 
        {
            _userData = ContainerLocator.Current.Resolve<IUserData>();

            var OAData = Newtonsoft.Json.JsonConvert.DeserializeObject<OAData>(workflowJSON);
            FlowchartModel model = new FlowchartModel();
            FlowChartHelper.G6ToFlowChart(OAData, model);
            FlowchartModel = model;
            Title = title;
            GetRoles();
            GetUsers();
        }

        private async void GetRoles()
        {
            Roles = await _userData.GetAllRole();
        }

        private async void GetUsers()
        {
            Users = await _userData.GetAllUser();
        }
    }


}
