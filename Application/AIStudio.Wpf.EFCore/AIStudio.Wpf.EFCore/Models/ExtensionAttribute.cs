using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AIStudio.Wpf.EFCore.Models
{
    public partial class ExtensionAttribute
    {
        public long PersistenceId { get; set; }
        public string AttributeKey { get; set; }
        public string AttributeValue { get; set; }
        public long ExecutionPointerId { get; set; }

        public virtual ExecutionPointer ExecutionPointer { get; set; }
    }
}
