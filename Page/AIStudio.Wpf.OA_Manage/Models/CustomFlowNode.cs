using Aga.Diagrams.Extension.Flowchart;
using System.ComponentModel;

namespace AIStudio.Wpf.OA_Manage.Models
{
    public class CustomFlowNode : FlowNode
    {
        public CustomFlowNode(NodeKinds kind) :base(kind)
        {
           
        }

        [Browsable(false)]
        public string Id { get; set; }

        [Browsable(false)]
        public string Color { get; set; }
        [Browsable(false)]
        public string StateImage { get; set; }
       
    }
}
