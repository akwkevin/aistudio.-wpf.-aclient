using System.Collections.Generic;
using System.Linq;

namespace AIStudio.Wpf.Entity.DTOModels
{
    public class OAData
    {
        public string Id { get; set; }
        public int Version { get; set; }
        public string DataType { get; set; }
        public bool FirstStart { get; set; } = true;
        public List<OAStep> Steps { get; set; } = new List<OAStep>();
        public List<CurrentStepId> CurrentStepIds { get; set; } = new List<CurrentStepId>();
        public MyEvent MyEvent { get; set; }
        public double Flag { get; set; }

        #region g6editor
        public nodes[] nodes { get; set; }
        public edges[] edges { get; set; }
        public groups[] groups { get; set; }
        #endregion
    }

    public class OAStep
    {
        public string Id { get; set; }
        public string Label { get; set; }
        public string StepType { get; set; }
        public List<string> PreStepId { get; set; }
        public string NextStepId { get; set; }
        public int Status { get; set; }

        public ActRule ActRules { get; set; }
        public Dictionary<string, string> SelectNextStep { get; set; }
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

    public class nodes
    {
        public string id { get; set; }
        public string name { get; set; }
        public string backImage { get; set; }
        public string color { get; set; }
        public string image { get; set; }
        public string label { get; set; }
        public int offsetX { get; set; }
        public int offsetY { get; set; }
        public string shape { get; set; }
        public int[] size { get; set; }
        public string stateImage { get; set; }
        public string type { get; set; }
        public double x { get; set; }
        public double y { get; set; }
        public double[][] inPoints { get; set; }
        public double[][] outPoints { get; set; }
        public bool isDoingStart { get; set; }
        public bool isDoingEnd { get; set; }
        public List<string> UserIds { get; set; }
        public List<string> RoleIds { get; set; }
        public string ActType { get; set; }
    }

    public class edges
    {
        public string id { get; set; }
        public point end { get; set; }
        public point endPoint { get; set; }
        public point start { get; set; }
        public point startPoint { get; set; }
        public string shape { get; set; }
        public string source { get; set; }
        public string sourceId { get; set; }
        public string target { get; set; }
        public string targetId { get; set; }
        public string type { get; set; }
        public string label { get; set; }
        public string textColor { get; set; }
    }

    public class groups
    {

    }

    public class point
    {
        public double x { get; set; }
        public double y { get; set; }
    }
  
}
