using AIStudio.Core;
using AIStudio.Wpf.Agile_Development.Models;
using AIStudio.Wpf.Agile_Development.Views;
using AIStudio.Wpf.BasePage.ViewModels;
using AIStudio.Wpf.Business;
using AIStudio.Wpf.Controls;
using Prism.Commands;
using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows.Input;

namespace AIStudio.Wpf.Agile_Development.ViewModels
{
    public class FormCodeViewModel : BasePageViewModel
    {
        protected IUserData _userData { get; }

        public FormCodeViewModel()
        {
            //添加一个测试类放在最前面，标记最全
            Types.Add(typeof(Base_UserDTO_Test));
            var assembly = Assembly.Load("AIStudio.Wpf.Entity");
            Types.AddRange(assembly.GetTypes().Where(p => p.FullName.Contains("AIStudio.Wpf.Entity.DTOModels")));

            SelectedType = Types[0];

            _userData = ContainerLocator.Current.Resolve<IUserData>();
            Items = _userData.ItemSource;
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

        public List<Type> Types { get; set; } = new List<Type>();

        private Type _selectedType;
        public Type SelectedType
        {
            get
            {
                return _selectedType;
            }
            set
            {
                if (SetProperty(ref _selectedType, value))
                {
                    if (value != null)
                    {
                        Data = Activator.CreateInstance(value);
                    }
                    else
                    {
                        Data = null;
                    }
                }
            }
        }

        public Dictionary<string, ObservableCollection<ISelectOption>> Items { get; set; }

        private ICommand _submitCommand;
        public ICommand SubmitCommand
        {
            get
            {
                return this._submitCommand ?? (this._submitCommand = new DelegateCommand<object>(para => this.Submit(para)));
            }
        }

        private ICommand _bulidCommand;
        public ICommand BulidCommand
        {
            get
            {
                return this._bulidCommand ?? (this._bulidCommand = new DelegateCommand<object>(para => this.Bulid(para)));
            }
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

        private readonly string template =
"<ac:Form xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" xmlns:ac=\"https://gitee.com/akwkevin/AI-wpf-controls\" DataContext=\"{Binding Data}\">" + "\r\n" +
"%formColumns%" + "\r\n" +
"</ac:Form>";
        protected async void Bulid(object para)
        {
            if (para is Form form)
            {
                List<string> formColumnsList = new List<string>();

                var items = form.Items.OfType<FormCodeItem>();
                foreach (var item in items)
                {
                    formColumnsList.Add(item.ToString());
                }

                var code = template.Replace("%formColumns%", string.Join("\r\n", formColumnsList));
                var viewmodel = new FormCodeEditViewModel(code, SelectedType == null ? null : Activator.CreateInstance(SelectedType));
                var dialog = new FormCodeEdit(viewmodel);

                var res = (BaseDialogResult)await WindowBase.ShowDialogAsync2(dialog, Identifier);
                 
                if (res == BaseDialogResult.OK)
                {
                    System.Windows.Clipboard.SetDataObject(viewmodel.Code);
                }
                  
            }
        }
    }
}
