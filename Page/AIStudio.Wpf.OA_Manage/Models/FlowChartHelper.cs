using Aga.Diagrams.TestExtend.Flowchart;
using AIStudio.Wpf.EFCore.DTOModels;
using System.Collections.Generic;
using System.Linq;

namespace AIStudio.Wpf.OA_Manage.Models
{
    public class FlowChartHelper
    {
        public static void G6ToFlowChart(OAData oAData, FlowchartModel model)
        {
            model.Nodes.Clear();
            model.Links.Clear();

            if (oAData.nodes != null)
            {
                foreach (var node in oAData.nodes)
                {
                    CustomFlowNode flowNode = null;
                    switch (node.name)
                    {
                        case "开始节点": flowNode = new CustomFlowNode(NodeKinds.Start); break;
                        case "中间节点": flowNode = new MiddleFlowNode(NodeKinds.Middle); break;
                        case "结束节点": flowNode = new CustomFlowNode(NodeKinds.End); break;
                        case "条件节点": flowNode = new CustomFlowNode(NodeKinds.Decide); break;
                        case "并行开始节点": flowNode = new CustomFlowNode(NodeKinds.COBegin); break;
                        case "并行结束节点": flowNode = new CustomFlowNode(NodeKinds.COEnd); break;
                        default: flowNode = new CustomFlowNode(NodeKinds.Normal); break;
                    }

                    flowNode.Id = node.id;
                    flowNode.Label = node.label;
                    flowNode.Row = (int)(node.y / 90);
                    flowNode.Column = (int)(node.x / 200);
                    flowNode.Color = node.color?? "1890ff";
                    flowNode.StateImage = node.stateImage;
                    if (flowNode is MiddleFlowNode middleFlowNode)
                    {
                        middleFlowNode.UserIds = node.UserIds ?? new List<string>();
                        middleFlowNode.RoleIds = node.RoleIds ?? new List<string>();
                        middleFlowNode.ActType = node.ActType;
                    }
                    model.Nodes.Add(flowNode);
                }
            }
            if (oAData.edges != null)
            {
                foreach (var edge in oAData.edges)
                {
                    var source = model.Nodes.OfType<CustomFlowNode>().FirstOrDefault(p => p.Id == edge.sourceId);
                    var target = model.Nodes.OfType<CustomFlowNode>().FirstOrDefault(p => p.Id == edge.targetId);

                    CustomLink link = new CustomLink(source, PortKinds.Bottom, target, PortKinds.Top);
                    link.Id = edge.id;
                    link.Label = edge.label;
                    link.TextColor = edge.textColor;

                    model.Links.Add(link);
                }
            }
        }

        public static void FlowChartToG6(FlowchartModel model, OAData oAData)
        {
            List<string> nodenames = model.Nodes?.OfType<CustomFlowNode>().Select(p => p.Id).Union(oAData.nodes?.Select(p => p.id)).Distinct().ToList();
            List<string> edgenames = model.Links?.OfType<CustomLink>().Select(p => p.Id).Union(oAData.edges?.Select(p => p.id)).Distinct().ToList();

            List<nodes> nodes = new List<nodes>();
            foreach (var flowNode in model.Nodes.OfType<CustomFlowNode>())
            {
                var node = oAData.nodes?.FirstOrDefault(p => p.id == flowNode.Id);
                if (node == null)
                {
                    node = new nodes();
                    switch (flowNode.Kind)
                    {
                        case NodeKinds.Start:
                            node.name = "开始节点";
                            node.inPoints = new double[][] { new double[] { 0, 0.5 } };
                            node.outPoints = new double[][] { new double[] { 1, 0.5 } };
                            node.stateImage = flowNode.StateImage ?? "/assets/start.e502ed95.svg"; 
                            break;
                        case NodeKinds.Middle:
                            node.name = "中间节点";
                            node.inPoints = new double[][] { new double[] { 0, 0.5 } };
                            node.outPoints = new double[][] { new double[] { 1, 0.5 } };
                            node.stateImage = flowNode.StateImage ?? "/assets/jiahao.ecf71c51.svg";
                            break;
                        case NodeKinds.End:
                            node.name = "结束节点";
                            node.inPoints = new double[][] { new double[] { 0, 0.5 } };
                            node.outPoints = new double[][] { new double[] { 1, 0.5 } };
                            node.stateImage = flowNode.StateImage ?? "/assets/close.7ec40520.svg";
                            break;
                        case NodeKinds.Decide:
                            node.name = "条件节点";
                            node.inPoints = new double[][] { new double[] { 0, 0.5 } };
                            node.outPoints = new double[][] { new double[] { 1, 0.4 }, new double[] { 1, 0.6 } };
                            node.stateImage = flowNode.StateImage ?? "/assets/jiahao.ecf71c51.svg";
                            break;
                        case NodeKinds.COBegin:
                            node.name = "并行开始节点";
                            node.inPoints = new double[][] { new double[] { 0, 0.5 } };
                            node.outPoints = new double[][] { new double[] { 1, 0.4 }, new double[] { 1, 0.6 } };
                            node.stateImage = flowNode.StateImage ?? "/assets/jiahao.ecf71c51.svg"; 
                            break;
                        case NodeKinds.COEnd:
                            node.name = "并行结束节点";
                            node.inPoints = new double[][] { new double[] { 0, 0.4 }, new double[] { 0, 0.6 } };
                            node.outPoints = new double[][] { new double[] { 1, 0.5 } };
                            node.stateImage = flowNode.StateImage ?? "/assets/jiahao.ecf71c51.svg"; 
                            break;
                    }

                    flowNode.Id = GetName(nodenames, "node");
                    node.id = flowNode.Id;
                    node.shape = "customNode";
                    node.image = "/assets/Shape.486da24a.svg";
                    node.type = "node";
                    node.color = "#1890ff";
                }       
               
                node.label = flowNode.Label;
                node.y = flowNode.Row * 90;
                node.x = flowNode.Column * 200;
                if (flowNode is MiddleFlowNode middleFlowNode)
                {
                    node.UserIds = middleFlowNode.UserIds;
                    node.RoleIds = middleFlowNode.RoleIds;
                    node.ActType = middleFlowNode.ActType;
                }
                nodes.Add(node);
            }
            oAData.nodes = nodes.ToArray();

            List<edges> edges = new List<edges>();
            foreach (var link in model.Links.OfType<CustomLink>())
            {
                var edge = oAData.edges?.FirstOrDefault(p => p.id == link.Id);
                if (edge == null)
                {
                    edge = new edges();

                    link.Id = GetName(edgenames, "edge");
                    edge.id = link.Id;
                    edge.shape = "customEdge";
                    edge.type = "edge";
                }

                edge.source = (link.Source as CustomFlowNode)?.Id;
                edge.sourceId = (link.Source as CustomFlowNode)?.Id;
                edge.target = (link.Target as CustomFlowNode)?.Id;
                edge.targetId = (link.Target as CustomFlowNode)?.Id;

                edges.Add(edge);
            }
            oAData.edges = edges.ToArray();
        }

        private static string GetName(List<string> nodenames, string type)
        {
            for (int i = 1; i < 1000; i++)
            {
                string name = $"{type}{i}";
                if (!nodenames.Contains(name))
                {
                    nodenames.Add(name);
                    return name;
                }
            }

            return "node-1";
        }
    }

}
