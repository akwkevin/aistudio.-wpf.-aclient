using AIStudio.Core;
using AIStudio.Wpf.DataRepository;
using AutoMapper;
using Coldairarrow.Util;
using Microsoft.Extensions.DependencyInjection;
using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Unity;
using Unity.Interception;
using Unity.Interception.ContainerIntegration;
using Unity.Interception.Interceptors.InstanceInterceptors.InterfaceInterception;
using Unity.Interception.PolicyInjection;

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

        public static void AddEFCoreServices(this IUnityContainer container)
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
                                container.AddNewExtension<Interception>()//add Extension Aop
                                .RegisterType(aInterface, aType, new Interceptor<InterfaceInterceptor>(), new InterceptionBehavior<PolicyInjectionBehavior>());
                            });
                        }
                        //无接口则注入自己
                        else
                        {
                            container.AddNewExtension<Interception>()//add Extension Aop
                               .RegisterType(aType, new Interceptor<InterfaceInterceptor>(), new InterceptionBehavior<PolicyInjectionBehavior>());
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

        public static IMapper AddAutoMapper(IEnumerable<string> _assemblies)
        {
            List<(Type from, Type[] targets)> maps = new List<(Type from, Type[] targets)>();

            maps.AddRange(DbModelFactory.AllTypes.Where(x => x.GetCustomAttribute<MapAttribute>() != null)
                .Select(x => (x, x.GetCustomAttribute<MapAttribute>().TargetTypes)));

            maps.AddRange(AllTypes.Where(x => x.GetCustomAttribute<MapAttribute>() != null)
              .Select(x => (x, x.GetCustomAttribute<MapAttribute>().TargetTypes)));

            var config = new MapperConfiguration(cfg =>
            {
                maps.ForEach(aMap =>
                {
                    aMap.targets.ToList().ForEach(aTarget =>
                    {
                        cfg.CreateMap(aMap.from, aTarget).IgnoreAllNonExisting(aMap.from, aTarget).ReverseMap();
                    });
                });

                cfg.AddMaps(DbModelFactory.Assemblies);

                _assemblies.ForEach(p => cfg.AddMaps(p));
            });

            return config.CreateMapper();
        }

        public static IMappingExpression IgnoreAllNonExisting(this IMappingExpression expression, Type from, Type to)
        {
            var flags = BindingFlags.Public | BindingFlags.Instance;
            to.GetProperties(flags).Where(x => from.GetProperty(x.Name, flags) == null).ForEach(aProperty =>
            {
                expression.ForMember(aProperty.Name, opt => opt.Ignore());
            });

            return expression;
        }
    }
}
