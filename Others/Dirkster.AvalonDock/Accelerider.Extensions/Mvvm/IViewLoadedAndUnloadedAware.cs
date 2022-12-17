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
        void OnLoaded(TView view);

        void OnUnloaded(TView view);
    }

    public interface IViewLoadedAndUnloadedAwareAsync
    {
        Task OnLoaded(object sender, RoutedEventArgs e);

        Task OnUnloaded(object sender, RoutedEventArgs e);
    }
}
