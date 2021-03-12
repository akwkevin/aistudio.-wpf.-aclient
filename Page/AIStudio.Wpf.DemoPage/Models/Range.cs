using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Controls;

namespace AIStudio.Wpf.DemoPage.Models
{
    public class Range : INotifyPropertyChanged
    {
        public int IntText { get; set; }
        public int StringText { get; set; }

        [StyleName("ComboBoxStyle")]
        public string ComboBox { get; set; }

        [StyleName("MultiComboBoxStyle")]
        public List<string> MultiComboBox { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
