using System;
using System.Collections.Generic;
using System.Configuration;

namespace AIStudio.Core
{
    public class UserSettingSection : System.Configuration.ConfigurationSection
    {
        [ConfigurationProperty("name", IsRequired = false)]
        public string Name
        {
            get { return (string)base["name"]; }
            set { base["name"] = value; }
        }

        [ConfigurationProperty("windowItems", IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(WindowItemElement), CollectionType = ConfigurationElementCollectionType.AddRemoveClearMap, RemoveItemName = "remove")]
        public WindowItemCollection WindowItems
        {
            get { return (WindowItemCollection)base["windowItems"]; }
            set { base["windowItems"] = value; }
        }
    }

    public class WindowItemCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new WindowItemElement();
        }
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((WindowItemElement)element).Name;
        }

        public override ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return ConfigurationElementCollectionType.BasicMap;
            }
        }
        protected override string ElementName
        {
            get
            {
                return "windowItem";
            }
        }

        public WindowItemElement this[int index]
        {
            get
            {
                return (WindowItemElement)BaseGet(index);
            }
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }
        }

        new public WindowItemElement this[string key]
        {
            get { return (WindowItemElement)base.BaseGet(key); }
            set
            {
                if (BaseGet(key) != null)
                {
                    Remove(key);
                }
                BaseAdd(value);
            }
        }

        public int IndexOf(WindowItemElement url)
        {
            return BaseIndexOf(url);
        }

        public void Add(WindowItemElement url)
        {
            BaseAdd(url);
        }

        public void AddRange(IEnumerable<WindowItemElement> urls)
        {
            foreach (var url in urls)
            {
                BaseAdd(url);
            }
        }

        protected override void BaseAdd(ConfigurationElement element)
        {
            BaseAdd(element, false);
        }

        public void Remove(WindowItemElement url)
        {
            if (BaseIndexOf(url) >= 0)
            {
                BaseRemove(url.Name);
            }
        }

        public void RemoveAt(int index)
        {
            BaseRemoveAt(index);
        }

        public void Remove(string name)
        {
            BaseRemove(name);
        }

        public void Clear()
        {
            BaseClear();
        }
    }

    public class WindowItemElement : ConfigurationElement
    {
        [ConfigurationProperty("name", IsRequired = true, IsKey = true)]
        public string Name
        {
            get
            {
                return (string)base["name"];
            }
            set
            {
                base["name"] = value;
            }
        }

        [ConfigurationProperty("toolItems", IsDefaultCollection = true)]
        public ToolItemCollection ToolItems
        {
            get { return (ToolItemCollection)base["toolItems"]; }
            set { base["toolItems"] = value; }
        }
    }

    public class ToolItemCollection : ConfigurationElementCollection
    {
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ToolItemElement)element).Code;
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new ToolItemElement();
        }

        public override ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return ConfigurationElementCollectionType.BasicMap;
            }
        }

        protected override string ElementName
        {
            get
            {
                return "toolItem";
            }
        }

        public ToolItemElement this[int i]
        {
            get { return (ToolItemElement)base.BaseGet(i); }
        }

        new public ToolItemElement this[string key]
        {
            get { return (ToolItemElement)base.BaseGet(key); }
        }

        public int IndexOf(ToolItemElement url)
        {
            return BaseIndexOf(url);
        }

        public void Add(ToolItemElement url)
        {
            BaseAdd(url);

            // Your custom code goes here.

        }

        public void AddRange(IEnumerable<ToolItemElement> urls)
        {
            foreach (var url in urls)
            {
                BaseAdd(url);
            }
        }

        protected override void BaseAdd(ConfigurationElement element)
        {
            BaseAdd(element, false);

            // Your custom code goes here.

        }

        public void Remove(ToolItemElement url)
        {
            if (BaseIndexOf(url) >= 0)
            {
                BaseRemove(url.Code);
                // Your custom code goes here.
                //Console.WriteLine("UrlsCollection: {0}", "Removed collection element!");
            }
        }

        public void RemoveAt(int index)
        {
            BaseRemoveAt(index);

            // Your custom code goes here.

        }

        public void Remove(string name)
        {
            BaseRemove(name);

            // Your custom code goes here.

        }

        public void Clear()
        {
            BaseClear();

            // Your custom code goes here.
            //Console.WriteLine("UrlsCollection: {0}", "Removed entire collection!");
        }     
    }

    public class ToolItemElement : ConfigurationElement
    {
        [ConfigurationProperty("code", IsRequired = true, IsKey = true)]
        public string Code
        {
            get { return (string)base["code"]; }
            set { base["code"] = value; }
        }
        [ConfigurationProperty("parentcode", IsRequired = true)]
        public string ParentCode
        {
            get { return (string)base["parentcode"]; }
            set { base["parentcode"] = value; }
        }
        [ConfigurationProperty("label", IsRequired = true)]
        public string Label
        {
            get { return (string)base["label"]; }
            set { base["label"] = value; }
        }
        [ConfigurationProperty("glyph", IsRequired = false)]
        public string Glyph
        {
            get { return (string)base["glyph"]; }
            set { base["glyph"] = value; }
        }
        [ConfigurationProperty("badge", IsRequired = false)]
        public string Badge
        {
            get { return (string)base["badge"]; }
            set { base["badge"] = value; }
        }
        [ConfigurationProperty("badgeBrush", IsRequired = false)]
        public string BadgeBrush
        {
            get { return (string)base["badgeBrush"]; }
            set { base["badgeBrush"] = value; }
        }
        [ConfigurationProperty("sort", IsRequired = false)]
        public int Sort
        {
            get { return (int)base["sort"]; }
            set { base["sort"] = value; }
        }
        [ConfigurationProperty("width", IsRequired = false)]
        public double Width
        {
            get { return (double)base["width"]; }
            set { base["width"] = value; }
        }
        [ConfigurationProperty("height", IsRequired = false)]
        public double Height
        {
            get { return (double)base["height"]; }
            set { base["height"] = value; }
        }
        [ConfigurationProperty("margin", IsRequired = false)]
        public double Margin
        {
            get { return (double)base["margin"]; }
            set { base["margin"] = value; }
        }

        [ConfigurationProperty("type", IsRequired = false)]
        public int Type
        {
            get { return (int)base["type"]; }
            set { base["type"] = value; }
        }
    }


}
