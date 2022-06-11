using AIStudio.Core;
using AIStudio.Wpf.BasePage.ViewModels;
using AIStudio.Wpf.Controls;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace AIStudio.Wpf.Agile_Development.ViewModels
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

        public Dictionary<string, ObservableCollection<ISelectOption>> Items { get; set; }

        private List<SelectOption> _duties;
        public List<SelectOption> Duties
        {
            get
            {
                return _duties;
            }
            set
            {
                SetProperty(ref _duties, value);
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
                        RootGrid.Children.Clear();
                        RootGrid.Children.Add(form);
                    }
                }
            }
        }

        private ICommand _submitCommand;
        public ICommand SubmitCommand
        {
            get
            {
                return this._submitCommand ?? (this._submitCommand = new DelegateCommand<object>(para => this.Submit(para)));
            }
        }

        public Grid RootGrid { get; set; }

        public FormCodeEditViewModel(string code, object data, Dictionary<string, ObservableCollection<ISelectOption>> _items, string title = "编辑代码")
        {
            Code = code;
            Data = data; 
            Items = _items;
            Title = title;

            Duties = new List<SelectOption>()
            {
                new SelectOption(){Value ="Develop",Text = "开发" },
                new SelectOption(){Value ="Operator",Text = "经理" },
                new SelectOption(){Value ="Engineer",Text = "总监" },
            };
        }

        public void Submit(object para)
        {
            string message = string.Empty;
            Type type = para.GetType();
            if (type.GetProperty("Error") != null)
            {
                message = type.GetProperty("Error").GetValue(para)?.ToString();
            }

            if (string.IsNullOrEmpty(message))
            {
                foreach (var prop in type.GetProperties())
                {
                    if (prop.CanRead && prop.CanWrite)
                    {
                        var ignoreAttr = prop.GetCustomAttributes(typeof(System.Xml.Serialization.XmlIgnoreAttribute), true);
                        if (ignoreAttr.Length > 0)
                        {
                            continue;
                        }

                        var displayAttr = prop.GetCustomAttributes(typeof(DisplayNameAttribute), true);
                        string name = string.Empty;
                        if (displayAttr.Length > 0)
                        {
                            name = (displayAttr[0] as DisplayNameAttribute).DisplayName;
                        }
                        else
                        {
                            name = prop.Name;
                        }

                        var value = prop.GetValue(para);
                        if (value is IEnumerable<object> list)
                        {
                            value = string.Join(",", list.Select(p => p?.ToString()));
                        }

                        if (value == null || value.ToString() == "")
                        {
                            continue;
                        }
                        message += $"{name}:{value?.ToString()},";
                    }
                }
            }

            MessageBox.Show(System.Windows.Application.Current.MainWindow, message);
        }
    }
}
