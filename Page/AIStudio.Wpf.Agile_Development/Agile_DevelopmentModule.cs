using AIStudio.Wpf.Controls;
using Prism.Ioc;
using Prism.Modularity;
using System.Reflection;
using System.Windows.Controls;


namespace AIStudio.Wpf.Agile_Development
{
    public class Agile_DevelopmentModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
         
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            var assembly = Assembly.GetExecutingAssembly();

            foreach (var type in assembly.GetTypes())
            {
                if (!type.IsSubclassOf(typeof(BaseDialog)) && type.IsSubclassOf(typeof(UserControl)))
                {
                    containerRegistry.RegisterForNavigation(type, type.FullName);
                }
            }
        }
    }
}
