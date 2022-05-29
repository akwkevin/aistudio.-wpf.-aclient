using AIStudio.Wpf.BasePage.ViewModels;
using AIStudio.Wpf.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AIStudio.Wpf.AgileDevelopment.ViewModels
{
    public class FormCodeEditViewModel : Prism.Mvvm.BindableBase
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                SetProperty(ref _title, value);
            }
        }

        private string _code;
        public string Code
        {
            get { return _code; }
            set
            {
                SetProperty(ref _code, value);
            }
        }

        private object _data;
        public object Data
        {
            get
            {
                return _data;
            }
            set
            {
                SetProperty(ref _data, value);
            }
        }

        private int _selectedIndex;
        public int SelectedIndex
        {
            get { return _selectedIndex; }
            set
            {
                if (SetProperty(ref _selectedIndex, value))
                {
                    if (value == 1)
                    {
                        var form = System.Windows.Markup.XamlReader.Parse(Code) as Form;
                        form.DataContext = Data;
                        RootGrid.Children.Clear();
                        RootGrid.Children.Add(form);
                    }
                }
            }
        }

        public Grid RootGrid { get; set; }

        public FormCodeEditViewModel(string code, object data, string title = "编辑代码")
        {
            Code = code;
            Data = data;
            Title = title;
        }
    }
}
