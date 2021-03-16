using System;
using System.Collections.Generic;

#nullable disable

namespace AIStudio.Wpf.EFCore.Models
{
    public partial class Workflow
    {
        public Workflow()
        {
            ExecutionPointers = new HashSet<ExecutionPointer>();
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

        public virtual ICollection<ExecutionPointer> ExecutionPointers { get; set; }
    }
}
