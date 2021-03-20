using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

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
