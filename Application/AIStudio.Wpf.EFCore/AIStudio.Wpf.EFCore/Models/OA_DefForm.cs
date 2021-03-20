using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AIStudio.Wpf.EFCore.Models
{
    public partial class OA_DefForm
    {
        public string Id { get; set; }
        public string WorkflowJSON { get; set; }
        public string JSONId { get; set; }
        public int JSONVersion { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public int Sort { get; set; }
        public int Status { get; set; }
        public string Value { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? ModifyTime { get; set; }
        public string CreatorId { get; set; }
        public string CreatorName { get; set; }
        public string ModifyId { get; set; }
        public string ModifyName { get; set; }
        public string TenantId { get; set; }
    }
}
