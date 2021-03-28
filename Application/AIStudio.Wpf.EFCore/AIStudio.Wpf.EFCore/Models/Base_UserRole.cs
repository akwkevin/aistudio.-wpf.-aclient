using System;
using System.Collections.Generic;

namespace AIStudio.Wpf.EFCore.Models
{
    public partial class Base_UserRole
    {
        public string Id { get; set; }
        public DateTime CreateTime { get; set; }
        public string CreatorId { get; set; }
        public bool Deleted { get; set; }
        public string UserId { get; set; }
        public string RoleId { get; set; }
    }
}
