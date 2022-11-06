using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIStudio.Core
{
    public interface ISelectOption
    {
        string Value { get; set; }
        string Text { get; set; }
        string Remark { get; set; }
    }
}
