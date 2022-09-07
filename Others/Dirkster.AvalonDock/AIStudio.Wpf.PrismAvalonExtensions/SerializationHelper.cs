using AvalonDock;
using AvalonDock.Layout.Serialization;
using Prism.Ioc;
using Prism.Regions;
using System;
using System.IO;

namespace AIStudio.Wpf.PrismAvalonExtensions
{
    public class SerializationHelper
    {
        public static void Serialize(DockingManager dm, string filename)
        {
            XmlLayoutSerializer s = new XmlLayoutSerializer(dm);
            s.Serialize(filename);
        }

        public static void Deserialize(DockingManager dm, string regionName, string filename)
        {
            FileInfo fi = new FileInfo(filename);
            if (!fi.Exists) return;

            XmlLayoutSerializer s = new XmlLayoutSerializer(dm);
            s.LayoutSerializationCallback += (sender, e) => {
                Type viewType = Type.GetType(e.Model.ContentId);
                if (viewType == null) return;
                IRegionManager rm = ContainerLocator.Current.Resolve<IRegionManager>();
                object o = ContainerLocator.Current.Resolve(viewType);
                rm.Regions[regionName].Add(o);
                e.Content = o;
            };
            s.Deserialize(filename);
        }
    }
}
