using AIStudio.Core;
using AIStudio.Wpf.BasePage.ViewModels;
using AIStudio.Wpf.Controls;
using AIStudio.Wpf.AgileDevelopment.Models;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using System.Collections.ObjectModel;
using AIStudio.Wpf.AgileDevelopment.ItemSources;

namespace AIStudio.Wpf.AgileDevelopment.ViewModels
{
    class FormViewModel : BasePageViewModel
    {
        private Base_UserDTO_Test _base_User = new Base_UserDTO_Test();
        public Base_UserDTO_Test Base_User
        {
            get
            {
                return _base_User;
            }
            set
            {
                SetProperty(ref _base_User, value);
            }
        }

        private Base_UserDTO_Test _base_User2 = new Base_UserDTO_Test();
        public Base_UserDTO_Test Base_User2
        {
            get
            {
                return _base_User2;
            }
            set
            {
                SetProperty(ref _base_User2, value);
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

        private List<SelectOption> _sexList;
        public List<SelectOption> SexList
        {
            get
            {
                return _sexList;
            }
            set
            {
                SetProperty(ref _sexList, value);
            }
        }

        private List<SelectOption> _rolesList;
        public List<SelectOption> RolesList
        {
            get
            {
                return _rolesList;
            }
            set
            {
                SetProperty(ref _rolesList, value);
            }
        }

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

        private List<TreeModel> _departments;
        public List<TreeModel> Departments
        {
            get
            {
                return _departments;
            }
            set
            {
                SetProperty(ref _departments, value);
            }
        }

        public Dictionary<string, ObservableCollection<ISelectOption>> Items { get; set; } = ItemSourceDictionary.Items;

        private ICommand _submitCommand;
        public ICommand SubmitCommand
        {
            get
            {
                return this._submitCommand ?? (this._submitCommand = new DelegateCommand<object>(para => this.Submit(para)));
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

        public FormViewModel()
        {
            SexList = new List<SelectOption>()
            {
                new SelectOption(){Value = "0",Text = "女" },
                new SelectOption(){Value ="1",Text = "男" },
            };
            RolesList = new List<SelectOption>()
            {
                new SelectOption(){Value = "Manager",Text = "管理员" },
                new SelectOption(){Value ="Operator",Text = "操作员" },
                new SelectOption(){Value ="Engineer",Text = "工程师" },
            };
            Duties = new List<SelectOption>()
            {
                new SelectOption(){Value ="Develop",Text = "开发" },
                new SelectOption(){Value ="Operator",Text = "经理" },
                new SelectOption(){Value ="Engineer",Text = "总监" },
            };

            Departments = new List<TreeModel>()
            {
                new TreeModel()
                {
                    Value = "Depart1",
                    Text = "部门1",
                    Children = new List<TreeModel>()
                    {
                        new TreeModel()
                        {
                              Value = "Depart1_1",
                              Text = "部门1_1",
                        },
                        new TreeModel()
                        {
                              Value = "Depart1_2",
                              Text = "部门1_2",
                        },
                    },
                },
                new TreeModel()
                {
                    Value = "Depart2",
                    Text = "部门2",
                    Children = new List<TreeModel>()
                    {
                        new TreeModel()
                        {
                              Value = "Depart2_1",
                              Text = "部门2_1",
                        },
                        new TreeModel()
                        {
                              Value = "Depart2_2",
                              Text = "部门2_2",
                        },
                    },
                },
                new TreeModel()
                {
                    Value = "Depart3",
                    Text = "部门3",
                    Children = new List<TreeModel>()
                    {
                        new TreeModel()
                        {
                              Value = "Depart3_1",
                              Text = "部门3_1",
                        },
                        new TreeModel()
                        {
                              Value = "Depart3_2",
                              Text = "部门3_2",
                        },
                    },
                },
            };
        }
    }

    public class FormSetting : BindableBase
    {
        private System.Windows.Controls.Orientation _orientation;
        public System.Windows.Controls.Orientation Orientation
        {
            get
            {
                return _orientation;
            }
            set
            {
                SetProperty(ref _orientation, value);
            }
        }

        private int _panelType;
        public int PanelType
        {
            get
            {
                return _panelType;
            }
            set
            {
                SetProperty(ref _panelType, value);
            }
        }

        private string _headerWidth = "50";
        public string HeaderWidth
        {
            get
            {
                return _headerWidth;
            }
            set
            {
                SetProperty(ref _headerWidth, value);
            }
        }

        private string _bodyWidth = "*";
        public string BodyWidth
        {
            get
            {
                return _bodyWidth;
            }
            set
            {
                SetProperty(ref _bodyWidth, value);
            }
        }

        private double _horizontalMargin;
        public double HorizontalMargin
        {
            get
            {
                return _horizontalMargin;
            }
            set
            {
                if (SetProperty(ref _horizontalMargin, value))
                {
                    ItemMargin = new System.Windows.Thickness(HorizontalMargin, VerticalMargin, HorizontalMargin, VerticalMargin);
                }
            }
        }

        private double _verticalMargin = 8.0;
        public double VerticalMargin
        {
            get
            {
                return _verticalMargin;
            }
            set
            {
                if (SetProperty(ref _verticalMargin, value))
                {
                    ItemMargin = new System.Windows.Thickness(HorizontalMargin, VerticalMargin, HorizontalMargin, VerticalMargin);
                }
            }
        }

        private System.Windows.Thickness _itemMargin;
        public System.Windows.Thickness ItemMargin
        {
            get
            {
                return _itemMargin;
            }
            set
            {
                SetProperty(ref _itemMargin, value);
            }
        }

        private bool _allowDrop;
        public bool AllowDrop
        {
            get
            {
                return _allowDrop;
            }
            set
            {
                SetProperty(ref _allowDrop, value);
            }
        }

        public FormSetting()
        {
            ItemMargin = new System.Windows.Thickness(HorizontalMargin, VerticalMargin, HorizontalMargin, VerticalMargin);
        }
    }
}
