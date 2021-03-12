using Aga.Diagrams.TestExtend.Flowchart;
using System.ComponentModel;

namespace AIStudio.Wpf.OA_Manage.Models
{
    public class CustomLink : Link
    {
        [Browsable(false)]
        public string Id { get; set; }

        public string TextColor { get; set; }

        public CustomLink(FlowNode source, PortKinds sourcePort, FlowNode target, PortKinds targetPort):base(source, sourcePort, target, targetPort)
        {
        }
    }
}
