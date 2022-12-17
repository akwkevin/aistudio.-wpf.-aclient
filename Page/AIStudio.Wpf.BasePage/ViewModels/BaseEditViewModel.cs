using AIStudio.Core.Models;

namespace AIStudio.Wpf.BasePage.ViewModels
{
    public class BaseEditViewModel<TData> : BaseEditWithOptionViewModel<TData, object> where TData : class, IIsChecked
    {
    }
}
