using System;
using System.Collections.Generic;

namespace AIStudio.Wpf.EFCore.Models
{
    public partial class OA_UserForm
    {
        public string Id { get; set; }
        public string DefFormId { get; set; }
        public string DefFormName { get; set; }
        public string DefFormJsonId { get; set; }
        public int DefFormJsonVersion { get; set; }
        public int Grade { get; set; }
        public double Flag { get; set; }
        public string Remarks { get; set; }
        public string Appendix { get; set; }
        public string ExtendJSON { get; set; }
        public string ApplicantUser { get; set; }
        public string ApplicantUserId { get; set; }
        public string ApplicantDepartment { get; set; }
        public string ApplicantDepartmentId { get; set; }
        public string ApplicantRole { get; set; }
        public string ApplicantRoleId { get; set; }
        public string UserRoleNames { get; set; }
        public string UserRoleIds { get; set; }
        public string AlreadyUserNames { get; set; }
        public string AlreadyUserIds { get; set; }
        public int Status { get; set; }
        public string Type { get; set; }
        public string SubType { get; set; }
        public string Unit { get; set; }
        public DateTime? ExpectedDate { get; set; }
        public string CurrentNode { get; set; }
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
