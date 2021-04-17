using System.Collections.Generic;
using Util.Controls.Handy.Data;

namespace AIStudio.Wpf.DemoPage.Models
{
    public class DemoDataModel
    {
        public int Index { get; set; }

        public string Name { get; set; }

        public bool IsSelected { get; set; }

        public string Remark { get; set; }

        public DemoType Type { get; set; }

        public string ImgPath { get; set; }

        public List<DemoDataModel> DataList { get; set; }
    }
}