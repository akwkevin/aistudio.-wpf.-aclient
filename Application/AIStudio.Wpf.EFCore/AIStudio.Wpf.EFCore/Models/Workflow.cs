using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AIStudio.Wpf.EFCore.Models
{
    public partial class Workflow
    {
        public Workflow()
        {
            ExecutionPointer = new HashSet<ExecutionPointer>();
        }

        public long PersistenceId { get; set; }
        public DateTime? CompleteTime { get; set; }
        public DateTime CreateTime { get; set; }
        public string Data { get; set; }
        public string Description { get; set; }
        public Guid InstanceId { get; set; }
        public long? NextExecution { get; set; }
        public int Status { get; set; }
        public int Version { get; set; }
        public string WorkflowDefinitionId { get; set; }
        public string Reference { get; set; }

        public virtual ICollection<ExecutionPointer> ExecutionPointer { get; set; }
    }
}
