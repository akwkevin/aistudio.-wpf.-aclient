using Prism.Ioc;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Accelerider.Extensions.Mvvm
{
    public class ViewModelResolver : IViewModelResolver
    {
        private readonly Func<IContainerProvider> _containerFactory;
        private Action<object, object, IContainerProvider> _configureViewAndViewModel;
        private IContainerProvider _container;

        public IContainerProvider Container => _container ?? (_container = _containerFactory());

        public ViewModelResolver(Func<IContainerProvider> containerFactory)
        {
            Guards.ThrowIfNull(containerFactory);

            _containerFactory = containerFactory;
        }

        public object ResolveViewModelForView(object view, Type viewModelType)
        {
            var viewModel = Container.Resolve(viewModelType);
            _configureViewAndViewModel?.Invoke(view, viewModel, Container);

            return viewModel;
        }

        public IViewModelResolver IfInheritsFrom<TView, TViewModel>(Action<TView, TViewModel, IContainerProvider> configuration)
        {
            var previousAction = _configureViewAndViewModel;
            _configureViewAndViewModel = (view, viewModel, container) =>
            {
                previousAction?.Invoke(view, viewModel, container);
                if (view is TView tView && viewModel is TViewModel tViewModel)
                {
                    configuration?.Invoke(tView, tViewModel, container);
                }
            };
            return this;
        }

        public IViewModelResolver IfInheritsFrom<TView>(Type genericInterfaceType, Action<TView, object, IGenericInterface, IContainerProvider> configuration)
        {
            var previousAction = _configureViewAndViewModel;
            _configureViewAndViewModel = (view, viewModel, container) =>
            {
                previousAction?.Invoke(view, viewModel, container);
                var interfaceInstance = viewModel.AsGenericInterface(genericInterfaceType);
                if (view is TView tView && interfaceInstance != null)
                {
                    configuration?.Invoke(tView, viewModel, interfaceInstance, container);
                }
            };
            return this;
        }
    }

    public static class ViewModelResolverExtensions
    {
        public static IViewModelResolver UseDefaultConfigure(this IViewModelResolver @this) => @this
            .IfInheritsFrom<ViewModelBase>((view, viewModel) =>
            {
                viewModel.Dispatcher = view.Dispatcher;
            })
            .IfInheritsFrom<IViewLoadedAndUnloadedAware>((view, viewModel) =>
            {
                view.Loaded += (sender, e) => viewModel.OnLoaded(sender, e);
                view.Unloaded += (sender, e) =>  viewModel.OnUnloaded(sender, e);
            })
            .IfInheritsFrom<IViewLoadedAndUnloadedAwareAsync>((view, viewModel) =>
            {
                view.Loaded += async (sender, e) => await viewModel.OnLoaded(sender, e);
                view.Unloaded += async (sender, e) => await viewModel.OnUnloaded(sender, e);
            })
            .IfInheritsFrom(typeof(IViewLoadedAndUnloadedAware<>), (view, viewModel, interfaceInstance) =>
            {
                var viewType = view.GetType();
                if (interfaceInstance.GenericArguments.Single() != viewType)
                {
                    throw new InvalidOperationException();
                }

                var onLoadedMethod = interfaceInstance.GetMethod<Action<object, RoutedEventArgs>>("OnLoaded", viewType);
                var onUnloadedMethod = interfaceInstance.GetMethod<Action<object, RoutedEventArgs>>("OnUnloaded", viewType);

                view.Loaded += (sender, args) => onLoadedMethod(sender, args);
                view.Unloaded += (sender, args) =>  onUnloadedMethod(sender, args);
            })
             .IfInheritsFrom(typeof(IViewLoadedAndUnloadedAwareAsync<>), (view, viewModel, interfaceInstance) =>
             {
                 var viewType = view.GetType();
                 if (interfaceInstance.GenericArguments.Single() != viewType)
                 {
                     throw new InvalidOperationException();
                 }

                 var onLoadedMethod = interfaceInstance.GetMethod<Action<object, RoutedEventArgs>>("OnLoaded", viewType);
                 var onUnloadedMethod = interfaceInstance.GetMethod<Action<object, RoutedEventArgs>>("OnUnloaded", viewType);

                 //待验证
                 view.Loaded += (sender, args) => onLoadedMethod.BeginInvoke(sender, args, a => onLoadedMethod(sender, args), null);
                 view.Unloaded += (sender, args) => onUnloadedMethod.BeginInvoke(sender, args, a => onUnloadedMethod(sender, args), null);
             });



        public static IViewModelResolver IfInheritsFrom<TViewModel>(this IViewModelResolver @this, Action<FrameworkElement, TViewModel> configuration)
        {
            Guards.ThrowIfNull(@this, configuration);

            return @this.IfInheritsFrom<FrameworkElement, TViewModel>((view, viewModel, container) => configuration(view, viewModel));
        }

        public static IViewModelResolver IfInheritsFrom<TViewModel>(this IViewModelResolver @this, Action<FrameworkElement, TViewModel, IContainerProvider> configuration)
        {
            Guards.ThrowIfNull(@this, configuration);

            return @this.IfInheritsFrom(configuration);
        }

        public static IViewModelResolver IfInheritsFrom(this IViewModelResolver @this, Type genericInterfaceType, Action<FrameworkElement, object, IGenericInterface> configuration)
        {
            Guards.ThrowIfNull(@this, configuration);

            return @this.IfInheritsFrom<FrameworkElement>(
                genericInterfaceType,
                (view, viewModel, interfaceInstance, container) => configuration(view, viewModel, interfaceInstance));
        }
    }
}
