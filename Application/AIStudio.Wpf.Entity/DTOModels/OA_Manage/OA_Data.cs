using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace AIStudio.Wpf.Entity.DTOModels
{
    public class OA_Data
    {
        public string Id { get; set; }
        public int Version { get; set; }
        public string DataType { get; set; }
        public bool FirstStart { get; set; } = true;
        public List<OA_Step> Steps { get; set; } = new List<OA_Step>();
        public List<CurrentStepId> CurrentStepIds { get; set; } = new List<CurrentStepId>();
        public MyEvent MyEvent { get; set; }
        public double Flag { get; set; }

        /// <summary>
        /// Gets or sets the nodes.
        /// </summary>
        /// <value>
        /// The nodes.
        /// </value>
        public FlowchartNode[] Nodes { get; set; }
        /// <summary>
        /// Gets or sets the links.
        /// </summary>
        /// <value>
        /// The links.
        /// </value>
        public FlowchartLink[] Links { get; set; }
        /// <summary>
        /// Gets or sets the groups.
        /// </summary>
        /// <value>
        /// The groups.
        /// </value>
        public FlowchartGroup[] Groups { get; set; }
    }

    public class OA_Step
    {
        public string Id { get; set; }
        public string Label { get; set; }
        public string StepType { get; set; }
        public List<string> PreStepId { get; set; }
        public string NextStepId { get; set; }
        public int Status { get; set; }

        public ActRule ActRules { get; set; }
        public Dictionary<string, string> SelectNextStep { get; set; }

        public override string ToString()
        {
            return Id + "-" + Label;
        }
    }

    public class CurrentStepId
    {
        public string StepId { get; set; }

        public string StepLabel { get; set; }
        public ActRule ActRules { get; set; }
    }

    public class ActRule
    {
        public List<string> UserIds { get; set; }
        public List<string> UserNames { get; set; }
        public List<string> RoleIds { get; set; }
        public List<string> RoleNames { get; set; }
        public string ActType { get; set; }
    }


    public class MyEvent
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public int Status { get; set; }
        public string Remarks { get; set; }
    }


    /// <summary>
    /// FlowNode
    /// </summary>
    public class DiagramNode
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public string Id { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        /// <value>
        /// The color.
        /// </value>
        public string Color { get; set; }
        /// <summary>
        /// Gets or sets the label.
        /// </summary>
        /// <value>
        /// The label.
        /// </value>
        public string Label { get; set; }
        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        /// <value>
        /// The width.
        /// </value>
        public double Width { get; set; }
        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        /// <value>
        /// The height.
        /// </value>
        public double Height { get; set; }
        /// <summary>
        /// Gets or sets the x.
        /// </summary>
        /// <value>
        /// The x.
        /// </value>
        public double X { get; set; }
        /// <summary>
        /// Gets or sets the y.
        /// </summary>
        /// <value>
        /// The y.
        /// </value>
        public double Y { get; set; }
        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public string Type { get; set; }
        /// <summary>
        /// Gets or sets the index of the z.
        /// </summary>
        /// <value>
        /// The index of the z.
        /// </value>
        public int ZIndex { get; set; }
        /// <summary>
        /// Gets or sets the port alignment list.
        /// </summary>
        /// <value>
        /// The port alignment list.
        /// </value>
        public List<string> PortAlignmentList { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class DiagramLink
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public string Id { get; set; }
        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        /// <value>
        /// The color.
        /// </value>
        public string Color { get; set; }
        /// <summary>
        /// Gets or sets the color of the selected.
        /// </summary>
        /// <value>
        /// The color of the selected.
        /// </value>
        public string SelectedColor { get; set; }
        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        /// <value>
        /// The width.
        /// </value>
        public double Width { get; set; }
        /// <summary>
        /// Gets or sets the label.
        /// </summary>
        /// <value>
        /// The label.
        /// </value>
        public string Label { get; set; }//TODO

        /// <summary>
        /// Gets or sets the source identifier.
        /// </summary>
        /// <value>
        /// The source identifier.
        /// </value>
        public string SourceId { get; set; }
        /// <summary>
        /// Gets or sets the target identifier.
        /// </summary>
        /// <value>
        /// The target identifier.
        /// </value>
        public string TargetId { get; set; }

        /// <summary>
        /// Gets or sets the source port alignment.
        /// </summary>
        /// <value>
        /// The source port alignment.
        /// </value>
        public string SourcePortAlignment { get; set; }
        /// <summary>
        /// Gets or sets the target port alignment.
        /// </summary>
        /// <value>
        /// The target port alignment.
        /// </value>
        public string TargetPortAlignment { get; set; }
        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the router.
        /// </summary>
        /// <value>
        /// The router.
        /// </value>
        public string Router { get; set; }

        /// <summary>
        /// Gets or sets the path generator.
        /// </summary>
        /// <value>
        /// The path generator.
        /// </value>
        public string PathGenerator { get; set; }

        /// <summary>
        /// Gets or sets the source marker path.
        /// </summary>
        /// <value>
        /// The source marker path.
        /// </value>
        public string SourceMarkerPath { get; set; }
        /// <summary>
        /// Gets or sets the width of the source marker.
        /// </summary>
        /// <value>
        /// The width of the source marker.
        /// </value>
        public double? SourceMarkerWidth { get; set; }

        /// <summary>
        /// Gets or sets the target marker path.
        /// </summary>
        /// <value>
        /// The target marker path.
        /// </value>
        public string TargetMarkerPath { get; set; }
        /// <summary>
        /// Gets or sets the width of the target marker.
        /// </summary>
        /// <value>
        /// The width of the target marker.
        /// </value>
        public double? TargetMarkerWidth { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class DiagramGroup
    {
        /// <summary>
        /// Gets or sets the flow node ids.
        /// </summary>
        /// <value>
        /// The flow node ids.
        /// </value>
        public List<string> FlowNodeIds { get; set; } = new List<string>();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AIStudio.Util.DiagramEntity.DiagramNode" />
    public class FlowchartNode : DiagramNode
    {
        /// <summary>
        /// Gets or sets the kind.
        /// </summary>
        /// <value>
        /// The kind.
        /// </value>
        public NodeKinds Kind { get; set; }

        /// <summary>
        /// Gets or sets the user ids.
        /// </summary>
        /// <value>
        /// The user ids.
        /// </value>
        public IEnumerable<string> UserIds { get; set; }
        /// <summary>
        /// Gets or sets the role ids.
        /// </summary>
        /// <value>
        /// The role ids.
        /// </value>
        public IEnumerable<string> RoleIds { get; set; }
        /// <summary>
        /// Gets or sets the type of the act.
        /// </summary>
        /// <value>
        /// The type of the act.
        /// </value>
        public string ActType { get; set; }

    }

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AIStudio.Util.DiagramEntity.DiagramLink" />
    public class FlowchartLink : DiagramLink
    {
    }

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AIStudio.Util.DiagramEntity.DiagramGroup" />
    public class FlowchartGroup : DiagramGroup
    {
    }

    /// <summary>
    /// 
    /// </summary>
    public enum NodeKinds
    {
        /// <summary>
        /// 节点
        /// </summary>
        [Description("节点")]
        Normal = 0,
        /// <summary>
        /// 开始
        /// </summary>
        [Description("开始")]
        Start = 1,
        /// <summary>
        /// 结束
        /// </summary>
        [Description("结束")]
        End = 2,
        /// <summary>
        /// 中间节点
        /// </summary>
        [Description("中间节点")]
        Middle = 3,
        /// <summary>
        /// 条件节点
        /// </summary>
        [Description("条件节点")]
        Decide = 4,
        /// <summary>
        /// 并行开始
        /// </summary>
        [Description("并行开始")]
        COBegin = 5,
        /// <summary>
        /// 并行结束
        /// </summary>
        [Description("并行结束")]
        COEnd = 6,
    }

}
