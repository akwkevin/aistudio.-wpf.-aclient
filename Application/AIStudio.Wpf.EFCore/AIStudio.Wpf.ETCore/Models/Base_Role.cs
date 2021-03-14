using System;
using System.Collections.Generic;

#nullable disable

namespace AIStudio.Wpf.EFCore.Models
{
    public partial class Base_Role
    {
        public string Id { get; set; }
        public string RoleName { get; set; }
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
