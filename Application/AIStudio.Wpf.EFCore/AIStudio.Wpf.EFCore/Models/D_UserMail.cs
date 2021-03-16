using System;
using System.Collections.Generic;

#nullable disable

namespace AIStudio.Wpf.EFCore.Models
{
    public partial class D_UserMail
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public int Type { get; set; }
        public string CCIds { get; set; }
        public string CCNames { get; set; }
        public string ReadingMarks { get; set; }
        public bool StarMark { get; set; }
        public string Appendix { get; set; }
        public bool IsDraft { get; set; }
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
