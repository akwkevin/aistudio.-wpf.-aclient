using System;
using System.Collections.Generic;

#nullable disable

namespace AIStudio.Wpf.EFCore.Models
{
    public partial class ExecutionPointer
    {
        public ExecutionPointer()
        {
            ExtensionAttributes = new HashSet<ExtensionAttribute>();
        }

        public long PersistenceId { get; set; }
        public bool Active { get; set; }
        public int RetryCount { get; set; }
        public DateTime? EndTime { get; set; }
        public string EventData { get; set; }
        public string EventKey { get; set; }
        public string EventName { get; set; }
        public bool EventPublished { get; set; }
        public string Id { get; set; }
        public string PersistenceData { get; set; }
        public DateTime? SleepUntil { get; set; }
        public DateTime? StartTime { get; set; }
        public int StepId { get; set; }
        public string StepName { get; set; }
        public long WorkflowId { get; set; }
        public string Children { get; set; }
        public string ContextItem { get; set; }
        public string PredecessorId { get; set; }
        public string Outcome { get; set; }
        public string Scope { get; set; }
        public int Status { get; set; }

        public virtual Workflow Workflow { get; set; }
        public virtual ICollection<ExtensionAttribute> ExtensionAttributes { get; set; }
    }
}
