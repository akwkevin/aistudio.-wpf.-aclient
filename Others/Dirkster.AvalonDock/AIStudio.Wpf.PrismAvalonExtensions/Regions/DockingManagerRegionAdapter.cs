using AvalonDock;
using Prism.Regions;

namespace AIStudio.Wpf.PrismAvalonExtensions.Regions
{
    public class DockingManagerRegionAdapter : RegionAdapterBase<DockingManager>
    {
        public DockingManagerRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory)
          : base(regionBehaviorFactory)
        {
        }

        protected override void Adapt(IRegion region, DockingManager regionTarget)
        {
        }

        protected override IRegion CreateRegion()
        {
            return new DockingManagerRegion();
        }

        protected override void AttachBehaviors(IRegion region, DockingManager regionTarget)
        {
            if (region == null) throw new System.ArgumentNullException("region");
            region.Behaviors.Add(DockingManagerBehavior.BehaviorKey, new DockingManagerBehavior() { HostControl = regionTarget });
            base.AttachBehaviors(region, regionTarget);
        }
    }
}
