using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

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
