using System;
using System.Collections.Generic;

namespace AIStudio.Wpf.EFCore.Models
{
    public partial class Base_Action
    {
        public string Id { get; set; }
        public string ParentId { get; set; }
        public int Type { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Value { get; set; }
        public bool NeedAction { get; set; }
        public string Icon { get; set; }
        public int Sort { get; set; }
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
