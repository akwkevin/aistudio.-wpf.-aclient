using AIStudio.Wpf.DemoPage.Views;
using Prism.Commands;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using Util.Controls.Handy;

namespace AIStudio.Wpf.DemoPage.ViewModels
{
    public class SpriteViewModel : DockWindowViewModel
    {
        private ObservableCollection<string> data;
        public ObservableCollection<string> Data
        {
            get { return data; }
            set
            {
                if (data != value)
                {
                    data = value;
                    RaisePropertyChanged("Data");
                }
            }
        }

		private ICommand okCommand;
        public ICommand OKCommand
        {
            get
            {
                return this.okCommand ?? (this.okCommand = new DelegateCommand(() => this.OK()));
            }
        }

        public RelayCommand OpenCmd => new Lazy<RelayCommand>(() =>  
            new RelayCommand(() => Sprite.Show(new AppSprite()))).Value;


        public SpriteViewModel()
        {

        }

		private void OK()
		{

		}

    }

}
