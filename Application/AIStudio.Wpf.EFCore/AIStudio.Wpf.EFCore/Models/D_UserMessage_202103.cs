using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AIStudio.Wpf.EFCore.Models
{
    public partial class D_UserMessage_202103
    {
        public string Id { get; set; }
        public int Type { get; set; }
        public string ReadingMarks { get; set; }
        public string GroupId { get; set; }
        public string GroupName { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? ModifyTime { get; set; }
        public string CreatorId { get; set; }
        public string CreatorName { get; set; }
        public string ModifyId { get; set; }
        public string ModifyName { get; set; }
        public string TenantId { get; set; }
        public string UserIds { get; set; }
        public string UserNames { get; set; }
        public string Text { get; set; }
    }
}
