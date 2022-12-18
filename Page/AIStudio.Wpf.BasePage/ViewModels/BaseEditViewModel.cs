using AIStudio.Core.Models;

namespace AIStudio.Wpf.BasePage.ViewModels
{
    public class BaseEditViewModel<TData> : BaseEditWithOptionViewModel<TData, object>, IBaseEditViewModel where TData : class, IIsChecked
    {
    }

    public interface IBaseEditViewModel : IBaseEditWithOptionViewModel<object>
    {

    }
}
