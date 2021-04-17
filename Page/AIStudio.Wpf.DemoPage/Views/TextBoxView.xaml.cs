using AIStudio.Wpf.DemoPage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AIStudio.Wpf.DemoPage.Views
{
    /// <summary>
    /// TextBoxView.xaml 的交互逻辑
    /// </summary>
    public partial class TextBoxView : UserControl
    {
        public TextBoxView()
        {
            InitializeComponent();
            _dataGrid.DataContext = InitMovieList();
        }

        private List<Movie> InitMovieList()
        {
            List<Movie> movieList = new List<Movie>();
            movieList.Add(new Movie()
            {
                Title = "Lord Of The Rings",
                Review = "A great movie with many special effects.",
                Rating = 9
            });
            movieList.Add(new Movie()
            {
                Title = "Pirates Of The Caribbean",
                Review = "An epic pirate movie with ships, swords, explosions, and a treasure.",
                Rating = 9.5
            });
            movieList.Add(new Movie()
            {
                Title = "Batman",
                Review = "Batman returns after 8 years, stronger than ever, to deliver Gotham City from a new criminal.",
                Rating = 7.8
            });
            movieList.Add(new Movie()
            {
                Title = "Indiana Jones",
                Review = "Harrison Ford strikes back for an action-packed movie in the jungle to find a mysterious Crystal skull.",
                Rating = 6.4
            });

            return movieList;
        }
    }
}
