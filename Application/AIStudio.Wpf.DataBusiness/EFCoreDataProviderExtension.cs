using AIStudio.Core;
using Coldairarrow.Util;
using Microsoft.Extensions.DependencyInjection;
using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AIStudio.Wpf.DataBusiness
{
    public static class EFCoreDataProviderExtension
    {
        public static readonly List<Type> AllTypes = new List<Type>();


        static EFCoreDataProviderExtension()
        {
            var assembly = Assembly.GetExecutingAssembly();
            AllTypes = assembly.GetTypes().ToList();
        }

        public static void AddEFCoreServices(this IContainerRegistry container)
        {
            List<Type> lifeTimeMap = new List<Type>
            {
                typeof(ITransientDependency), 
                typeof(IScopedDependency), 
                typeof(ISingletonDependency)
            };

            AllTypes.ForEach(aType =>
            {
                lifeTimeMap.ForEach(theDependency =>
                { 
                    if (theDependency.IsAssignableFrom(aType) && theDependency != aType && !aType.IsAbstract && aType.IsClass)
                    {    
                        var interfaces = AllTypes.Where(x => x.IsAssignableFrom(aType) && x.IsInterface && x != theDependency).ToList();
                        //有接口则注入接口
                        if (interfaces.Count > 0)
                        {
                            interfaces.ForEach(aInterface =>
                            {
                                container.Register(aInterface, aType);
                            });
                        }
                        //无接口则注入自己
                        else
                        {
                            container.Register(aType);
                        }
                    }
                });
            });

            new IdHelperBootstrapper()
                   //设置WorkerId
                   .SetWorkderId(1)
                   //使用Zookeeper
                   //.UseZookeeper("127.0.0.1:2181", 200, GlobalSwitch.ProjectName)
                   .Boot();

        }
    }
}
