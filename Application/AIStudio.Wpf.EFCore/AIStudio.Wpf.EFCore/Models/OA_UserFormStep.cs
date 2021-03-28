using System;
using System.Collections.Generic;

namespace AIStudio.Wpf.EFCore.Models
{
    public partial class OA_UserFormStep
    {
        public string Id { get; set; }
        public string UserFormId { get; set; }
        public string RoleIds { get; set; }
        public string RoleNames { get; set; }
        public string Remarks { get; set; }
        public int Status { get; set; }
        public string StepName { get; set; }
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
