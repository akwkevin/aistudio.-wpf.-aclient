using System;
using System.Collections.Generic;

namespace AIStudio.Wpf.Entity.Models
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
