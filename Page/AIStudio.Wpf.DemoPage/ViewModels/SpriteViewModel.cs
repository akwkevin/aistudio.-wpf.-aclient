using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Controls.Commands;
using System.Windows.Input;
using Util.Controls;
using AIStudio.Wpf.DemoPage.Views;
using System.Windows;

namespace AIStudio.Wpf.DemoPage.ViewModels
{
    public class SpriteViewModel : Dataforge.PrismAvalonExtensions.ViewModels.DockWindowViewModel
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
