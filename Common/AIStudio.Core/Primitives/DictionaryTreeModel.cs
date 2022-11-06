using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIStudio.Core
{
    public class DictionaryTreeModel : TreeModel
    {
        public int Type { get; set; }
        public ControlType ControlType { get; set; }
        public string Code { get; set; }

        public string Remark { get; set; }

        /// <summary>
        /// 孩子节点
        /// </summary>
        public new List<DictionaryTreeModel> Children { get; set; }
    }
}
