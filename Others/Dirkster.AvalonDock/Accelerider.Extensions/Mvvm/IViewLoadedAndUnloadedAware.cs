using System.Threading.Tasks;
using System.Windows;

namespace Accelerider.Extensions.Mvvm
{
    public interface IViewLoadedAndUnloadedAware
    {
        void OnLoaded(object sender, RoutedEventArgs e);

        void OnUnloaded(object sender, RoutedEventArgs e);
    }

    public interface IViewLoadedAndUnloadedAware<in TView>
    {
        void OnLoaded(TView view, RoutedEventArgs e);

        void OnUnloaded(TView view, RoutedEventArgs e);
    }

    public interface IViewLoadedAndUnloadedAwareAsync
    {
        Task OnLoaded(object sender, RoutedEventArgs e);

        Task OnUnloaded(object sender, RoutedEventArgs e);
    }

    public interface IViewLoadedAndUnloadedAwareAsync<in TView>
    {
        Task OnLoaded(TView view, RoutedEventArgs e);

        Task OnUnloaded(TView view, RoutedEventArgs e);
    }
}
