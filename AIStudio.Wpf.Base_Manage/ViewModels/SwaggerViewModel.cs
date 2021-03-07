using AIStudio.Core;
using Dataforge.PrismAvalonExtensions.ViewModels;
using Prism.Ioc;

namespace AIStudio.Wpf.Base_Manage.ViewModels
{
    public class SwaggerViewModel : DockWindowViewModel
    {
        public SwaggerViewModel()
        {
            Url = LocalSetting.ServerIP + "/index.html";
        }
        private string _url;
        public string Url
        {
            get { return _url; }
            set
            {
                if (_url != value)
                {
                    _url = value;
                    RaisePropertyChanged("Url");
                }
            }
        }
    }
}
