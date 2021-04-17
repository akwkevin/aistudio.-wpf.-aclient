using Prism.Commands;
using Prism.Mvvm;
using System.Windows.Input;

namespace AIStudio.Wpf.DemoPage.ViewModels
{
    public abstract class DockWindowViewModel : BindableBase
    {
        #region Properties

        #region CloseCommand
        private ICommand _CloseCommand;
        public ICommand CloseCommand
        {
            get
            {
                if (_CloseCommand == null)
                    _CloseCommand = new DelegateCommand(() => Close());
                return _CloseCommand;
            }
        }
        #endregion

        #region IsClosed
        private bool _IsClosed;
        public bool IsClosed
        {
            get { return _IsClosed; }
            set
            {
                if (_IsClosed != value)
                {
                    _IsClosed = value;
                    RaisePropertyChanged("IsClosed");
                }
            }
        }
        #endregion

        #region CanClose
        private bool _CanClose;
        public bool CanClose
        {
            get { return _CanClose; }
            set
            {
                if (_CanClose != value)
                {
                    _CanClose = value;
                    RaisePropertyChanged("CanClose");
                }
            }
        }
        #endregion

        #region CanFloat
        private bool _CanFloat;
        public bool CanFloat
        {
            get { return _CanFloat; }
            set
            {
                if (_CanFloat != value)
                {
                    _CanFloat = value;
                    RaisePropertyChanged("CanFloat");
                }
            }
        }
        #endregion

        #region Title
        private string _Title;
        public string Title
        {
            get { return _Title; }
            set
            {
                if (_Title != value)
                {
                    _Title = value;
                    RaisePropertyChanged("Title");
                }
            }
        }
        #endregion

        #endregion

        #region IsSelected
        private bool _IsSelected;
        public bool IsSelected
        {
            get { return _IsSelected; }
            set
            {
                if (_IsSelected != value)
                {
                    _IsSelected = value;
                    RaisePropertyChanged("IsSelected");
                }
            }
        }
        #endregion

        public DockWindowViewModel()
        {
            this.CanClose = true;
            this.CanFloat = true;
            this.IsClosed = false;
        }

        public virtual void Close()
        {            
            this.IsClosed = true;
        }
    }
}
