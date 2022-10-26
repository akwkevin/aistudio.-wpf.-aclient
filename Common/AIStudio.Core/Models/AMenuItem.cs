using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace AIStudio.Core.Models
{
    [AutoMap(typeof(AToolItem))]
    public class AMenuItem : TreeMenuItem
    {
        private string icon;
        [Browsable(true)]
        public string Icon
        {
            get { return icon; }
            set
            {
                if (value == icon) return;
                icon = value;
                OnPropertyChanged("Icon");
            }
        }

        public string Code { get; set; }

        public string Value { get; set; }

        public string WpfName
        {
            get
            {
                if (WpfCode == null)
                    return null;

                return WpfCode.Substring(WpfCode.LastIndexOf(".") + 1).Replace("View","");
            }
        }

        public string WpfCode
        {
            get
            {
                if (Code == null)
                    return null;

                //三个特例，移动了位置菜单还没有改
                if (Code == "/Home/UserConsole")
                {
                    return "AIStudio.Wpf.LayoutPage.Views.UserConsoleView";
                }
                else if (Code == "/Home/_3DShowcase")
                {
                    return "AIStudio.Wpf.LayoutPage.Views._3DShowcaseView";
                }
                else if (Code == "/Home/Statis")
                {
                    return "AIStudio.Wpf.LayoutPage.Views.StatisView";
                }
                else if (Code.StartsWith("/Agile_Development/Common_FormConfigQuery/List"))
                {
                    return "AIStudio.Wpf.Agile_Development.Views.Common_FormConfigQueryView";
                }

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

        public bool NeedAction { get; set; }
        public List<string> PermissionValues { get; set; }

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
