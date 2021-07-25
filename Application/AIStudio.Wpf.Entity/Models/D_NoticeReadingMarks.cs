using System;
using System.Collections.Generic;

namespace AIStudio.Wpf.Entity.Models
{
    public partial class D_NoticeReadingMarks
    {
        public string Id { get; set; }
        public string NoticeId { get; set; }
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
