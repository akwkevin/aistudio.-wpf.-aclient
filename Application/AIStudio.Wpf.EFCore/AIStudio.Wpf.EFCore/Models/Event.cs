using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AIStudio.Wpf.EFCore.Models
{
    public partial class Event
    {
        public long PersistenceId { get; set; }
        public string EventData { get; set; }
        public Guid EventId { get; set; }
        public string EventKey { get; set; }
        public string EventName { get; set; }
        public DateTime EventTime { get; set; }
        public bool IsProcessed { get; set; }
    }
}
