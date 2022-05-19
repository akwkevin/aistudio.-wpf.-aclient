using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIStudio.Core
{
    /// <summary>
    /// 前端SelectOption
    /// </summary>
    public class SelectOption : ISelectOption
    {
        public string Value { get; set; }
        public string Text { get; set; }

        public override string ToString()
        {
            return $"{Value}-{Text}";
        }
    }
}
