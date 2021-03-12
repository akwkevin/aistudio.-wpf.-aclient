using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace AIStudio.Wpf.BasePage.ViewModels
{
    public class BaseWaitingViewModel: BindableBase
    {
        private bool _iswaiting = false;
        public bool IsWaiting
        {
            get { return _iswaiting; }
            set
            {
                SetProperty(ref _iswaiting, value);
            }
        }

        private bool _hasMask = false;
        public bool HasMask
        {
            get { return _hasMask; }
            set
            {
                SetProperty(ref _hasMask, value);
            }
        }

        public string waitinfo = "";
        public string WaitInfo
        {
            get
            {
                return waitinfo;
            }
            set
            {
                waitinfo = value;
                RaisePropertyChanged("WaitInfo");
            }
        }

        private bool canCancel = false;
        public bool CanCancel
        {
            get
            {
                return canCancel;
            }
            set
            {
                canCancel = value;
                RaisePropertyChanged("CanCancel");
            }
        }

        private DelegateCommand cancelCommmad;
        public DelegateCommand CancelCommmad
        {
            get
            {
                return this.cancelCommmad ?? (this.cancelCommmad = new DelegateCommand(() => this.Cancel()));
            }
        }

        protected virtual void Cancel()
        {
            IsWaiting = false;
        }

        protected virtual void ShowWait(bool hasMask = false)
        {
            IsWaiting = true;
            HasMask = hasMask;
        }

        protected virtual void HideWait(bool hasMask = false)
        {
            IsWaiting = false;
            HasMask = hasMask;
        }

    }
}
