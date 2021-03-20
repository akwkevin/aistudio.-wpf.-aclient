using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AIStudio.Wpf.EFCore.Models
{
    public partial class Subscription
    {
        public long PersistenceId { get; set; }
        public string EventKey { get; set; }
        public string EventName { get; set; }
        public int StepId { get; set; }
        public Guid SubscriptionId { get; set; }
        public string WorkflowId { get; set; }
        public DateTime SubscribeAsOf { get; set; }
        public string SubscriptionData { get; set; }
        public string ExecutionPointerId { get; set; }
        public string ExternalToken { get; set; }
        public DateTime? ExternalTokenExpiry { get; set; }
        public string ExternalWorkerId { get; set; }
    }
}
