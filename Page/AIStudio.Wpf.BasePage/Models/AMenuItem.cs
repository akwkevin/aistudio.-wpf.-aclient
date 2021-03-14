using AutoMapper;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Controls;

namespace AIStudio.Wpf.BasePage.Models
{
    [AutoMap(typeof(AToolItem))]
    public class AMenuItem : HamburgerTreeMenuGlyphItem
    {
        private string glyph;
        [Browsable(true)]
        [StyleName("GlyphStyle")]
        public new string Glyph
        {
            get { return glyph; }
            set
            {
                if (value == glyph) return;
                glyph = value;
                OnPropertyChanged("Glyph");
            }
        }

        public string Code { get; set; }

        public string WpfCode
        {
            get
            {
                if (Code == null)
                    return null;

                if (Code.Contains("AIStudio.Wpf"))
                    return Code;

                var subcode = Code.Replace("/Index", "IndexView").Replace("/TreeList", "TreeView").Replace("/List", "View").Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
                   if (subcode.Length == 1)
                    return Code;
                
                subcode[subcode.Length - 1] = $"Views.{subcode[subcode.Length - 1]}";

                if (!subcode[subcode.Length - 1].EndsWith("View"))
                {
                    subcode[subcode.Length - 1] = subcode[subcode.Length - 1] + "View";
                }

                return $"AIStudio.Wpf.{string.Join(".", subcode)}";
            }
        }

        public int Type { get; set; } = -1;

        public AMenuItem Parent { get; set; }
        public string Id { get; set; }
        public string ParentId { get; set; }

        private bool isChecked;
        public bool IsChecked
        {
            get { return isChecked; }
            set
            {
                if (value == isChecked) return;
                isChecked = value;
                OnPropertyChanged("IsChecked");
            }
        }



        public void AddChildren(AMenuItem child)
        {
            child.Parent = this;
            this.Children.Add(child);
        }
    }
}
