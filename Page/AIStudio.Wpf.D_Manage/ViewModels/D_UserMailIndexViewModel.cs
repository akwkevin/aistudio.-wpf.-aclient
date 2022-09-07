using AIStudio.Core;
using AIStudio.Wpf.PrismAvalonExtensions.ViewModels;
using Prism.Regions;

namespace AIStudio.Wpf.D_Manage.ViewModels
{
    public class D_UserMailIndexViewModel : NavigationDockWindowViewModel
    {
        private D_UserMailNewViewModel _newViewModel;
        public D_UserMailNewViewModel NewViewModel
        {
            get { return _newViewModel; }
            set
            {
                if (_newViewModel != value)
                {
                    _newViewModel = value;
                    RaisePropertyChanged("NewViewModel");
                }
            }
        }


        private D_UserMailViewModel _sendViewModel;
        public D_UserMailViewModel SendViewModel
        {
            get { return _sendViewModel; }
            set
            {
                if (_sendViewModel != value)
                {
                    _sendViewModel = value;
                    RaisePropertyChanged("SendViewModel");
                }
            }
        }

        private D_UserMailViewModel _receiveViewModel;
        public D_UserMailViewModel ReceiveViewModel
        {
            get { return _receiveViewModel; }
            set
            {
                if (_receiveViewModel != value)
                {
                    _receiveViewModel = value;
                    RaisePropertyChanged("ReceiveViewModel");
                }
            }
        }

        private D_UserMailViewModel _draftViewModel;
        public D_UserMailViewModel DraftViewModel
        {
            get { return _draftViewModel; }
            set
            {
                if (_draftViewModel != value)
                {
                    _draftViewModel = value;
                    RaisePropertyChanged("DraftViewModel");
                }
            }
        }

        protected string Identifier { get; set; } = LocalSetting.RootWindow;

        public D_UserMailIndexViewModel()
        {

        }

        public override void Initialize()
        {
            NewViewModel = new D_UserMailNewViewModel("D_Manage", Identifier);
            SendViewModel = new D_UserMailViewModel(1, Identifier);
            ReceiveViewModel = new D_UserMailViewModel(2, Identifier);
            DraftViewModel = new D_UserMailViewModel(3, Identifier);

            SendViewModel.Initialize();
            ReceiveViewModel.Initialize();
            DraftViewModel.Initialize();
        }

        public D_UserMailIndexViewModel(string[] id)//无效参数，做个标记
        {
            SendViewModel = new D_UserMailViewModel(id);
        }


        public void EditById(object[] id)
        {
            SendViewModel.EditById(id);
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            base.OnNavigatedTo(navigationContext);

            var identifier = navigationContext.Parameters["Identifier"] as string;
            if (!string.IsNullOrEmpty(identifier))
            {
                Identifier = identifier;
            }

            Initialize();
        }

    }
}
