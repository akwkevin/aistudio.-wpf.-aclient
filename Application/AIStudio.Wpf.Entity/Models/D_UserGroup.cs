﻿using System;
using System.Collections.Generic;

namespace AIStudio.Wpf.Entity.Models
{
    public partial class D_UserGroup
    {
        public string Id { get; set; }
        public string UserIds { get; set; }
        public string UserNames { get; set; }
        public string Title { get; set; }
        public int Type { get; set; }
        public string Remark { get; set; }
        public string Appendix { get; set; }
        public string Avatar { get; set; }
        public string ManagerIds { get; set; }
        public string ManagerNames { get; set; }
        public string Name { get; set; }
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
