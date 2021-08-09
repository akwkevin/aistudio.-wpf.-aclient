using Dragablz;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Text;

namespace AIStudio.Wpf.PrismDragablzExtensions.Regions
{
    public class TabablzControlRegionAdapter : RegionAdapterBase<TabablzControl>
    {
        public TabablzControlRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory)
          : base(regionBehaviorFactory)
        {
        }

        protected override void Adapt(IRegion region, TabablzControl regionTarget)
        {
        }

        protected override IRegion CreateRegion()
        {
            return new TabablzControlRegion();
        }

        protected override void AttachBehaviors(IRegion region, TabablzControl regionTarget)
        {
            if (region == null) throw new System.ArgumentNullException("region");
            region.Behaviors.Add(TabablzControlBehavior.BehaviorKey, new TabablzControlBehavior() { HostControl = regionTarget });
            base.AttachBehaviors(region, regionTarget);
        }
    }
}
