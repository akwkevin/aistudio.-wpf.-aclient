using AIStudio.Core.Models;

namespace AIStudio.Wpf.BasePage.ViewModels
{
    public class BaseEditViewModel2<TData> : BaseEditWithOptionViewModel<TData, object> where TData : class, IIsChecked
    {
    }
}
