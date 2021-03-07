using System;
using System.Collections.Generic;



namespace AIStudio.Wpf.EFCore.Models
{
    public partial class Quartz_Task
    {
        public string Id { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime ModifyTime { get; set; }
        public string CreatorId { get; set; }
        public string CreatorName { get; set; }
        public string ModifyId { get; set; }
        public string ModifyName { get; set; }
        public string TenantId { get; set; }
        public string TaskName { get; set; }
        public string GroupName { get; set; }
        public string Interval { get; set; }
        public string ApiUrl { get; set; }
        public string AuthKey { get; set; }
        public string AuthValue { get; set; }
        public string Describe { get; set; }
        public string RequestType { get; set; }
        public DateTime? LastRunTime { get; set; }
        public int Status { get; set; }
        public bool ForbidOperate { get; set; }
        public bool ForbidEdit { get; set; }
    }
}
