using System;
using System.Collections.Generic;

namespace AIStudio.Wpf.Entity.Models
{
    public partial class D_Notice
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public int Type { get; set; }
        public string Appendix { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? ModifyTime { get; set; }
        public string CreatorId { get; set; }
        public string CreatorName { get; set; }
        public string ModifyId { get; set; }
        public string ModifyName { get; set; }
        public string TenantId { get; set; }
        public string Text { get; set; }
        public int Status { get; set; }
        public int Mode { get; set; }
        public string AnyId { get; set; }
    }
}
