using Aga.Diagrams.Extension.Flowchart;
using AIStudio.Core;
using AIStudio.Wpf.Business;
using AIStudio.Wpf.Entity.DTOModels;
using AIStudio.Wpf.OA_Manage.Models;
using Prism.Ioc;
using Prism.Mvvm;
using System.Collections.ObjectModel;

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

        private ObservableCollection<ISelectOption> _roles;
        public ObservableCollection<ISelectOption> Roles
        {
            get { return _roles; }
            set
            {
                SetProperty(ref _roles, value);
            }
        }


        private ObservableCollection<ISelectOption> _users;
        public ObservableCollection<ISelectOption> Users
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
            Roles = await _userData.GetBase_Role();
        }

        private async void GetUsers()
        {
            Users = await _userData.GetBase_User();
        }
    }


}
