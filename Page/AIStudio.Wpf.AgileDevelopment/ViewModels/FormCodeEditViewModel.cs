using AIStudio.Wpf.BasePage.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public FormCodeEditViewModel(string code, string title = "编辑代码")
        {
            Code = code;
            Title = title;
        }
    }
}
