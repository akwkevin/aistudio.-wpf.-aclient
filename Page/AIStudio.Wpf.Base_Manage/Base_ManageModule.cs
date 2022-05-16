using Prism.Ioc;
using Prism.Modularity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using AIStudio.Wpf.Controls;

namespace AIStudio.Wpf.Base_Manage
{
    public class Base_ManageModule : IModule
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
