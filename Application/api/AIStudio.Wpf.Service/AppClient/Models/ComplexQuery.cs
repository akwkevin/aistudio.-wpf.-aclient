using System;
using System.Collections.Generic;
using System.Text;

namespace AIStudio.Wpf.Service.AppClient.Models
{
    public class ComplexQuery
    {
        public string TableName { get; set; }
        public string[] Columns { get; set; }
        public string Condition { get; set; }
        public object[] Args { get; set; }
    }
}
