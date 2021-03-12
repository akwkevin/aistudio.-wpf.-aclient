using System;
using System.Collections.Generic;



namespace AIStudio.Wpf.EFCore.Models
{
    public partial class Base_UserExtend
    {
        public string Id { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime ModifyTime { get; set; }
        public string CreatorId { get; set; }
        public string CreatorName { get; set; }
        public string ModifyId { get; set; }
        public string ModifyName { get; set; }
        public string TenantId { get; set; }
        public string NickName { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string Tag { get; set; }
        public string Sign { get; set; }
        public string DeckPhone { get; set; }
        public string Post { get; set; }
        public string PostGrade { get; set; }
    }
}
