using System;
using System.Collections.Generic;

namespace AIStudio.Wpf.Entity.Models
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
