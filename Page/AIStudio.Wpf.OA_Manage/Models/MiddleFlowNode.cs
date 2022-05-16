using Aga.Diagrams.TestExtend.Flowchart;
using System.Collections.Generic;
using AIStudio.Wpf.Controls;

namespace AIStudio.Wpf.OA_Manage.Models
{
    public class MiddleFlowNode : CustomFlowNode
    {
        public MiddleFlowNode(NodeKinds kind) :base(kind)
        {
           
        }

        private List<string> _userIds = new List<string>();
        [StyleName("UserIdsStyle")]
        public List<string> UserIds
        {
            get { return _userIds; }
            set
            {
                _userIds = value;
                OnPropertyChanged("UserIds");
            }
        }

        private List<string> _roleIds = new List<string>();
        [StyleName("RoleIdsStyle")]
        public List<string> RoleIds
        {
            get { return _roleIds; }
            set
            {
                _roleIds = value;
                OnPropertyChanged("RoleIds");
            }
        }

        private string _actType;
        [StyleName("ActTypeStyle")]
        public string ActType
        {
            get { return _actType; }
            set
            {
                _actType = value;
                OnPropertyChanged("ActType");
            }
        }
    }
}
