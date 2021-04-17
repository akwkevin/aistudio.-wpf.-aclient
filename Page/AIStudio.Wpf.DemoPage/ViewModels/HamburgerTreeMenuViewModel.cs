using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using System.Windows.Input;
using Util.Controls;

namespace AIStudio.Wpf.DemoPage.ViewModels
{
    public class HamburgerTreeMenuViewModel : DockWindowViewModel
    {
        private ObservableCollection<string> _data;
        public ObservableCollection<string> Data
        {
            get { return _data; }
            set
            {
                if (_data != value)
                {
					SetProperty(ref _data, value);
                }
            }
        }

		private ICommand _okCommand;
        public ICommand OKCommand
        {
            get
            {
                return this._okCommand ?? (this._okCommand = new DelegateCommand(() => this.OK()));
            }
        }

        public HamburgerTreeMenuViewModel()
        {
            HamburgerTreeMenuItem = new ObservableCollection<HamburgerTreeMenuItem>();
            HamburgerTreeMenuItem.Add(new HamburgerTreeMenuGlyphItem() { Glyph = "/AIStudio.Wpf.DemoPage;component/Resources/Img/Photos/BigFourSummerHeat.png", Label = "Big four summer heat", });
            HamburgerTreeMenuItem.Add(new HamburgerTreeMenuGlyphItem() { Glyph = "/AIStudio.Wpf.DemoPage;component/Resources/Img/Photos/BisonBadlandsChillin.png", Label = "Bison badlands Chillin", });
            HamburgerTreeMenuItem.Add(new HamburgerTreeMenuGlyphItem() { Glyph = "/AIStudio.Wpf.DemoPage;component/Resources/Img/Photos/GiantSlabInOregon.png", Label = "Giant slab in Oregon", });
            HamburgerTreeMenuItem.Add(new HamburgerTreeMenuGlyphItem() { Glyph = "/AIStudio.Wpf.DemoPage;component/Resources/Img/Photos/LakeAnnMushroom.png", Label = "Lake Ann Mushroom", });
            HamburgerTreeMenuItem[0].Children.Add(new HamburgerTreeMenuGlyphItem() { Glyph = "/AIStudio.Wpf.DemoPage;component/Resources/Img/Photos/BisonBadlandsChillin.png", Label = "1Bison badlands Chillin", });
            HamburgerTreeMenuItem[0].Children.Add(new HamburgerTreeMenuGlyphItem() { Glyph = "/AIStudio.Wpf.DemoPage;component/Resources/Img/Photos/LakeAnnMushroom.png", Label = "2Bison badlands Chillin", });
            HamburgerTreeMenuItem[1].Children.Add(new HamburgerTreeMenuGlyphItem() { Glyph = "/AIStudio.Wpf.DemoPage;component/Resources/Img/Photos/BisonBadlandsChillin.png", Label = "3Bison badlands Chillin", });
            HamburgerTreeMenuItem[1].Children.Add(new HamburgerTreeMenuGlyphItem() { Glyph = "/AIStudio.Wpf.DemoPage;component/Resources/Img/Photos/LakeAnnMushroom.png", Label = "4Bison badlands Chillin", });
            HamburgerTreeMenuItem[2].Children.Add(new HamburgerTreeMenuGlyphItem() { Glyph = "/AIStudio.Wpf.DemoPage;component/Resources/Img/Photos/BisonBadlandsChillin.png", Label = "5Bison badlands Chillin", });
            HamburgerTreeMenuItem[2].Children.Add(new HamburgerTreeMenuGlyphItem() { Glyph = "/AIStudio.Wpf.DemoPage;component/Resources/Img/Photos/LakeAnnMushroom.png", Label = "6Bison badlands Chillin", });
            HamburgerTreeMenuItem[3].Children.Add(new HamburgerTreeMenuGlyphItem() { Glyph = "/AIStudio.Wpf.DemoPage;component/Resources/Img/Photos/BisonBadlandsChillin.png", Label = "7Bison badlands Chillin", });
            HamburgerTreeMenuItem[3].Children.Add(new HamburgerTreeMenuGlyphItem() { Glyph = "/AIStudio.Wpf.DemoPage;component/Resources/Img/Photos/LakeAnnMushroom.png", Label = "8Bison badlands Chillin", });
            HamburgerTreeMenuItem[0].Children[0].Children.Add(new HamburgerTreeMenuGlyphItem() { Glyph = "/AIStudio.Wpf.DemoPage;component/Resources/Img/Photos/BisonBadlandsChillin.png", Label = "11Bison badlands Chillin", });
            HamburgerTreeMenuItem[0].Children[0].Children.Add(new HamburgerTreeMenuGlyphItem() { Glyph = "/AIStudio.Wpf.DemoPage;component/Resources/Img/Photos/LakeAnnMushroom.png", Label = "12Bison badlands Chillin", });
            HamburgerTreeMenuItem[0].Children[1].Children.Add(new HamburgerTreeMenuGlyphItem() { Glyph = "/AIStudio.Wpf.DemoPage;component/Resources/Img/Photos/BisonBadlandsChillin.png", Label = "21Bison badlands Chillin", });
            HamburgerTreeMenuItem[0].Children[1].Children.Add(new HamburgerTreeMenuGlyphItem() { Glyph = "/AIStudio.Wpf.DemoPage;component/Resources/Img/Photos/LakeAnnMushroom.png", Label = "22Bison badlands Chillin", });
            HamburgerTreeMenuItem[1].Children[0].Children.Add(new HamburgerTreeMenuGlyphItem() { Glyph = "/AIStudio.Wpf.DemoPage;component/Resources/Img/Photos/BisonBadlandsChillin.png", Label = "31Bison badlands Chillin", });
            HamburgerTreeMenuItem[1].Children[0].Children.Add(new HamburgerTreeMenuGlyphItem() { Glyph = "/AIStudio.Wpf.DemoPage;component/Resources/Img/Photos/LakeAnnMushroom.png", Label = "32Bison badlands Chillin", });
            HamburgerTreeMenuItem[1].Children[1].Children.Add(new HamburgerTreeMenuGlyphItem() { Glyph = "/AIStudio.Wpf.DemoPage;component/Resources/Img/Photos/BisonBadlandsChillin.png", Label = "41Bison badlands Chillin", });
            HamburgerTreeMenuItem[1].Children[1].Children.Add(new HamburgerTreeMenuGlyphItem() { Glyph = "/AIStudio.Wpf.DemoPage;component/Resources/Img/Photos/LakeAnnMushroom.png", Label = "42Bison badlands Chillin", });
        }

		private void OK()
		{

		}


        private ICommand addCommand;

        public ICommand AddCommand
        {
            get
            {
                return this.addCommand ?? (this.addCommand = new SimpleCommand2
                {
                    CanExecuteDelegate = x => true,
                    ExecuteDelegate = x => Test(x)
                });
            }
        }

        private void Test(object value)
        {
            HamburgerTreeMenuItem.Add(new HamburgerTreeMenuGlyphItem() { Glyph = "/AIStudio.Wpf.DemoPage;component/Resources/Img/Photos/BigFourSummerHeat.png", Label = "5Big four summer heat", });
        }

        private ObservableCollection<HamburgerTreeMenuItem> hamburgerTreeMenuItem;
        public ObservableCollection<HamburgerTreeMenuItem> HamburgerTreeMenuItem
        {
            get { return hamburgerTreeMenuItem; }
            set
            {
                if (value == hamburgerTreeMenuItem) return;
                hamburgerTreeMenuItem = value;
                RaisePropertyChanged("HamburgerTreeMenuItem");
            }
        }

      



    }

}
