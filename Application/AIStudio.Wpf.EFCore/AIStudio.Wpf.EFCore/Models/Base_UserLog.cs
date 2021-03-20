using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AIStudio.Wpf.EFCore.Models
{
    public partial class Base_UserLog
    {
        public string Id { get; set; }
        public DateTime CreateTime { get; set; }
        public string CreatorId { get; set; }
        public string CreatorName { get; set; }
        public string LogType { get; set; }
        public string LogContent { get; set; }
    }
}
