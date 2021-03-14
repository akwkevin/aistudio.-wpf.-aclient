using System;
using System.Collections.Generic;



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
