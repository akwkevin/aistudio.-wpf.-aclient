using System;
using System.Collections.Generic;

#nullable disable

namespace AIStudio.Wpf.EFCore.Models
{
    public partial class ExecutionError
    {
        public long PersistenceId { get; set; }
        public DateTime ErrorTime { get; set; }
        public string ExecutionPointerId { get; set; }
        public string Message { get; set; }
        public string WorkflowId { get; set; }
    }
}
