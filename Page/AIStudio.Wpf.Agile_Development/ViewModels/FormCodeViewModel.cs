using AIStudio.Core;
using AIStudio.Wpf.Agile_Development.Models;
using AIStudio.Wpf.Agile_Development.Views;
using AIStudio.Wpf.BasePage.Converters;
using AIStudio.Wpf.BasePage.ViewModels;
using AIStudio.Wpf.Business;
using AIStudio.Wpf.Controls;
using AIStudio.Wpf.Entity.DTOModels;
using AIStudio.Wpf.Entity.Models;
using Prism.Commands;
using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows.Controls;
using System.Windows.Data;
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
            ItemsSources = _userData.ItemSource.Select(p => $"Items[{p.Key}]").ToList();

            Duties = new List<SelectOption>()
            {
                new SelectOption(){Value ="Develop",Text = "开发" },
                new SelectOption(){Value ="Operator",Text = "经理" },
                new SelectOption(){Value ="Engineer",Text = "总监" },
            };
            ItemsSources.Add(nameof(Duties));
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
                        Paths = Data.GetType().GetProperties().Select(p => p.Name).Union(new List<string> { "SubmitCommand" }).ToList();
                    }
                    else
                    {
                        Data = null;
                        Paths = new List<string>();
                    }
                }
            }
        }

        private List<string> _paths;
        public List<string> Paths
        {
            get
            {
                return _paths;
            }
            set
            {
                SetProperty(ref _paths, value);
            }
        }

        private object _selectedItem;
        public object SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                SetProperty(ref _selectedItem, value);
            }
        }

        public List<string> ItemsSources { get; set; }

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

        private FormSetting _formSetting = new FormSetting();
        public FormSetting FormSetting
        {
            get
            {
                return _formSetting;
            }
            set
            {
                SetProperty(ref _formSetting, value);
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

        private ICommand _clearCommand;
        public ICommand ClearCommand
        {
            get
            {
                return this._clearCommand ?? (this._clearCommand = new DelegateCommand<object>(para => this.Clear(para)));
            }
        }

        private ICommand _deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                return this._deleteCommand ?? (this._deleteCommand = new DelegateCommand<object>(para => this.Delete(para)));
            }
        }

        private ICommand _copyCommand;
        public ICommand CopyCommand
        {
            get
            {
                return this._copyCommand ?? (this._copyCommand = new DelegateCommand<object>(para => this.Copy(para)));
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

        private ICommand _settingCommand;
        public ICommand SettingCommand
        {
            get
            {
                return this._settingCommand ?? (this._settingCommand = new DelegateCommand<object>(para => this.Setting(para)));
            }
        }

        private ICommand _quickExample1Command;
        public ICommand QuickExample1Command
        {
            get
            {
                return this._quickExample1Command ?? (this._quickExample1Command = new DelegateCommand<object>(para => this.QuickExample1(para)));
            }
        }

        private ICommand _quickExample2Command;
        public ICommand QuickExample2Command
        {
            get
            {
                return this._quickExample2Command ?? (this._quickExample2Command = new DelegateCommand<object>(para => this.QuickExample2(para)));
            }
        }

        private ICommand _quickExample3Command;
        public ICommand QuickExample3Command
        {
            get
            {
                return this._quickExample3Command ?? (this._quickExample3Command = new DelegateCommand<object>(para => this.QuickExample3(para)));
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

        private void Clear(object para)
        {
            if (para is Form form)
            {
                form.Items.Clear();
            }
        }

        private void Delete(object para)
        {
            if (para is Form form && form.SelectedItem != null)
            {
                form.Items.Remove(form.SelectedItem);
            }
        }

        private void Copy(object para)
        {
            if (para is Form form && form.SelectedItem != null)
            {
                form.CopySelectItem();
            }
        }

        private void Setting(object para)
        {
            if (para is FormCodeItem item)
            {
                item.Setting();
            }
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

        private async void QuickExample1(object para)
        {
            if (para is Form form)
            {
                try
                {
                    ShowWait();

                    await form.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        SelectedType = typeof(Base_UserDTO_Test);
                        form.Items.Clear();
                        form.Items.Add(new FormCodeItem() { Header = "姓名", Path = "UserName", ControlType = FormControlType.TextBox });
                        form.Items.Add(new FormCodeItem() { Header = "密码", Path = "Password", ControlType = FormControlType.PasswordBox });
                        form.Items.Add(new FormCodeItem() { Header = "性别", Path = "Sex", ItemsSource = "Items[Sex]", ControlType = FormControlType.ComboBox });
                        form.Items.Add(new FormCodeItem() { Header = "生日", Path = "Birthday", ControlType = FormControlType.DatePicker });
                        form.Items.Add(new FormCodeItem() { Header = "部门", Path = "DepartmentId", ItemsSource = "Items[Base_Department]", ControlType = FormControlType.TreeSelect });
                        form.Items.Add(new FormCodeItem() { Header = "角色", Path = "RoleIdList", ItemsSource = "Items[Base_Role]", ControlType = FormControlType.MultiComboBox });
                        form.Items.Add(new FormCodeItem() { Header = "职能", Path = "SelectedDuty", ItemsSource = "Duties", ControlType = FormControlType.ComboBox });
                        form.Items.Add(new FormCodeItem() { Header = "手机", Path = "PhoneNumber", ControlType = FormControlType.TextBox });
                        form.Items.Add(new FormCodeItem() { Header = "邮箱", Path = "Email", ControlType = FormControlType.TextBox });
                        form.Items.Add(new FormCodeItem() { Header = "提交", Path = "SubmitCommand", ControlType = FormControlType.Submit });

                        FormSetting.PanelType = FormPanelType.StackPanel;
                        FormSetting.HeaderWidth = "80";
                        FormSetting.BodyWidth = "*";
                    }));
                }
                finally
                {
                    HideWait();
                }

            }
        }

        private async void QuickExample2(object para)
        {
            if (para is Form form)
            {
                try
                {
                    ShowWait();

                    await form.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        SelectedType = typeof(OA_UserFormDTO);
                        form.Items.Clear();
                        var item1 = new FormCodeItem()
                        {
                            Header = "步骤",
                            Path = "Steps",
                            ControlType = FormControlType.DataGrid,
                            Span = 4,
                            ExtField1 = new List<DataGridColumn>
                    {
                        new DataGridTextColumn()
                        {
                            Binding = new Binding("Label"),
                            Header = "审批节点",
                            Width = new DataGridLength(1, DataGridLengthUnitType.Star),
                        },
                        new DataGridTextColumn()
                        {
                            Binding = new Binding("ActRules.RoleNames"){ Converter = new CollectionToStringConverter() },
                            Header = "审批角色",
                            Width = new DataGridLength(1, DataGridLengthUnitType.Star),
                        },
                        new DataGridTextColumn()
                        {
                            Binding = new Binding("ActRules.UserNames"){ Converter = new CollectionToStringConverter() },
                            Header = "审批人",
                            Width = new DataGridLength(1, DataGridLengthUnitType.Star),
                        },
                        new DataGridTextColumn()
                        {
                            Binding = new Binding("Status"){ Converter = new StepStatusConverter()},
                            Header = "状态",
                            Width = new DataGridLength(1, DataGridLengthUnitType.Star),
                        }
                    }
                        };
                        var item2 = new FormCodeItem() { Header = "摘要", Path = "Text", ControlType = FormControlType.TextBox, Span = 2 };
                        var item3 = new FormCodeItem() { Header = "申请人", Path = "ApplicantUserId", ItemsSource = "Items[Base_User]", ControlType = FormControlType.ComboBox };
                        var item4 = new FormCodeItem() { Header = "紧急程度", Path = "Grade", ItemsSource = "Items[Grade]", ControlType = FormControlType.ComboBox };
                        var item5 = new FormCodeItem() { Header = "备注", Path = "Remarks", ControlType = FormControlType.TextBox, Span = 2 };
                        var item6 = new FormCodeItem() { Header = "数值", Path = "Flag", ControlType = FormControlType.TextBox };
                        var item7 = new FormCodeItem() { Header = "完成日期", Path = "ExpectedDate", ControlType = FormControlType.DatePicker };
                        var item8 = new FormCodeItem() { Header = "附件", Path = "Appendix", ControlType = FormControlType.UploadFile, Span = 4 };
                        var item9 = new FormCodeItem()
                        {
                            Header = "评论",
                            Path = "Comments",
                            ControlType = FormControlType.DataGrid,
                            Span = 4,
                            ExtField1 = new List<DataGridColumn>
                    {
                        new DataGridTextColumn()
                        {
                            Binding = new Binding("CreatorName"),
                            Header = "审批人",
                            Width = new DataGridLength(1, DataGridLengthUnitType.Star),
                        },
                        new DataGridTextColumn()
                        {
                            Binding = new Binding("RoleNames"),
                            Header = "审批角色",
                            Width = new DataGridLength(1, DataGridLengthUnitType.Star),
                        },
                        new DataGridTextColumn()
                        {
                            Binding = new Binding("CreateTime"),
                            Header = "审批时间",
                            Width = new DataGridLength(1, DataGridLengthUnitType.Star),
                        },
                        new DataGridTextColumn()
                        {
                            Binding = new Binding("Remarks"),
                            Header = "备注",
                            Width = new DataGridLength(1, DataGridLengthUnitType.Star),
                        },
                        new DataGridTextColumn()
                        {
                            Binding = new Binding("Status"){ Converter = new StepStatusConverter()},
                            Header = "状态",
                            Width = new DataGridLength(1, DataGridLengthUnitType.Star),
                        }
                    }
                        };
                        var item10 = new FormCodeItem() { Header = "提交", Path = "SubmitCommand", ControlType = FormControlType.Submit, Span = 4, };

                        form.Items.Add(item1);
                        form.Items.Add(item2);
                        form.Items.Add(item3);
                        form.Items.Add(item4);
                        form.Items.Add(item5);
                        form.Items.Add(item6);
                        form.Items.Add(item7);
                        form.Items.Add(item8);
                        form.Items.Add(item9);
                        form.Items.Add(item10);

                        FormSetting.PanelType = FormPanelType.UniformWrapPanel;
                        FormSetting.PanelColumns = 4;
                        FormSetting.HeaderWidth = "80";
                        FormSetting.BodyWidth = "*";

                        if (Data is OA_UserFormDTO oA_UserForm)
                        {
                            oA_UserForm.Steps = new List<OAStep>()
                    {
                        new OAStep()
                        {
                            Id = "Id1",
                            Label = "开始",
                            ActRules = new ActRule()
                            {
                                RoleNames = new List<string>{ "超级管理员"},
                                UserNames = new List<string>{ "Admin" },
                            },
                            Status = 100,
                        },
                        new OAStep()
                        {
                            Id = "Id2",
                            Label = "主管审批",
                            ActRules = new ActRule()
                            {
                                RoleNames = new List<string>{ "超级管理员"},
                                UserNames = new List<string>{ "Admin" },
                            },
                            Status = 10,
                        },
                        new OAStep()
                        {
                            Id = "Id3",
                            Label = "人力审批",
                            ActRules = new ActRule()
                            {
                                RoleNames = new List<string>{ "超级管理员"},
                                UserNames = new List<string>{ "Admin" },
                            },
                            Status = 0,
                        },
                        new OAStep()
                        {
                            Id = "Id4",
                            Label = "条件",
                        },
                        new OAStep()
                        {
                            Id = "Id5",
                            Label = "分管领导",
                            ActRules = new ActRule()
                            {
                                RoleNames = new List<string>{ "超级管理员"},
                                UserNames = new List<string>{ "Admin" },
                            },
                            Status = 0,
                        },
                        new OAStep()
                        {
                            Id = "Id6",
                            Label = "人力归档",
                            ActRules = new ActRule()
                            {
                                RoleNames = new List<string>{ "超级管理员"},
                                UserNames = new List<string>{ "Admin" },
                            },
                            Status = 0,
                        },
                        new OAStep()
                        {
                            Id = "Id7",
                            Label = "结束",
                        },
                    };

                            oA_UserForm.Comments = new List<OA_UserFormStepDTO>()
                    {
                        new OA_UserFormStepDTO()
                        {
                            Id = "Id1",
                            CreatorName = "Admin",
                            RoleNames = "发起人",
                            CreateTime = DateTime.Now,
                            Status = 100,
                            Remarks = "发起了流程",
                        },
                    };
                        }
                    }));
                }
                finally
                {
                    HideWait();
                }
            }
        }

        private async void QuickExample3(object para)
        {
            if (para is Form form)
            {
                try
                {
                    ShowWait();

                    await form.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        SelectedType = typeof(Base_UserDTO_Test);
                        form.Items.Clear();
                        form.Items.Add(new FormCodeItem() { Header = "姓名", Path = "UserName", ControlType = FormControlType.TextBox });
                        form.Items.Add(new FormCodeItem() { Header = "密码", Path = "Password", ControlType = FormControlType.PasswordBox });
                        form.Items.Add(new FormCodeItem() { Header = "性别", Path = "Sex", ItemsSource = "Items[Sex]", ControlType = FormControlType.ComboBox });
                        form.Items.Add(new FormCodeItem() { Header = "生日", Path = "Birthday", ControlType = FormControlType.DatePicker });
                        form.Items.Add(new FormCodeItem() { Header = "部门", Path = "DepartmentId", ItemsSource = "Items[Base_Department]", ControlType = FormControlType.TreeSelect });
                        form.Items.Add(new FormCodeItem() { Header = "角色", Path = "RoleIdList", ItemsSource = "Items[Base_Role]", ControlType = FormControlType.MultiComboBox });
                        form.Items.Add(new FormCodeItem() { Header = "职能", Path = "SelectedDuty", ItemsSource = "Duties", ControlType = FormControlType.ComboBox });
                        form.Items.Add(new FormCodeItem() { Header = "手机", Path = "PhoneNumber", ControlType = FormControlType.TextBox });
                        form.Items.Add(new FormCodeItem() { Header = "邮箱", Path = "Email", ControlType = FormControlType.TextBox });
                        form.Items.Add(new FormCodeItem() { Header = "查询", Path = "SubmitCommand", ControlType = FormControlType.Submit });

                        FormSetting.PanelType = FormPanelType.WrapPanel;
                        FormSetting.HeaderWidth = "Auto";
                        FormSetting.BodyWidth = "150";
                    }));
                }
                finally
                {
                    HideWait();
                }
            }
        }
    }
}
