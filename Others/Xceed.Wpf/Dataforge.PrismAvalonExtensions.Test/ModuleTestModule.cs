using Dataforge.PrismAvalonExtensions.Test.Views;
using Prism.Ioc;
using Prism.Modularity;

namespace Dataforge.PrismAvalonExtensions.Test
{

    public class ModuleTestModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<TestView>();
            containerRegistry.RegisterForNavigation<Test2View>();
            containerRegistry.RegisterForNavigation<Test3View>();
        }
    }
}
