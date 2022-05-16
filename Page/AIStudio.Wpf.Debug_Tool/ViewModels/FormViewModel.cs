using AIStudio.Core;
using AIStudio.Wpf.BasePage.ViewModels;
using AIStudio.Wpf.Controls;
using AIStudio.Wpf.Debug_Tool.Models;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace AIStudio.Wpf.Debug_Tool.ViewModels
{
    class FormViewModel : BasePageViewModel
    {
        private Base_UserDTO _base_User = new Base_UserDTO();
        public Base_UserDTO Base_User
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
            RolesList = new List<SelectOption>()
            {
                new SelectOption(){value = "Manager",text = "管理员" },
                new SelectOption(){value ="Operator",text = "操作员" },
                new SelectOption(){value ="Engineer",text = "工程师" },
            };
            Duties = new List<SelectOption>()
            {
                new SelectOption(){value ="Develop",text = "开发" },
                new SelectOption(){value ="Operator",text = "经理" },
                new SelectOption(){value ="Engineer",text = "总监" },
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

        public FormSetting()
        {
            ItemMargin = new System.Windows.Thickness(HorizontalMargin, VerticalMargin, HorizontalMargin, VerticalMargin);
        }
    }

    //public class SelectOption
    //{
    //    public SelectOption(string value, string text)
    //    {
    //        Value = value;
    //        Text = text;
    //    }
    //    public string Value
    //    {
    //        get; set;
    //    }
    //    public string Text
    //    {
    //        get; set;
    //    }

    //    public override string ToString()
    //    {
    //        return $"{Value}-{Text}";
    //    }
    //}

    //public class TreeModel : BindableBase
    //{
    //    /// <summary>
    //    /// 唯一标识Id
    //    /// </summary>
    //    public string Id
    //    {
    //        get; set;
    //    }

    //    /// <summary>
    //    /// 数据值
    //    /// </summary>
    //    public string Value
    //    {
    //        get; set;
    //    }

    //    /// <summary>
    //    /// 父Id
    //    /// </summary>
    //    public string ParentId
    //    {
    //        get; set;
    //    }

    //    /// <summary>
    //    /// 节点深度
    //    /// </summary>
    //    public int? Level { get; set; } = 1;

    //    /// <summary>
    //    /// 显示的内容
    //    /// </summary>
    //    public string Text
    //    {
    //        get; set;
    //    }

    //    /// <summary>
    //    /// 孩子节点
    //    /// </summary>
    //    public List<TreeModel> Children
    //    {
    //        get; set;
    //    }

    //    /// <summary>
    //    /// 孩子节点
    //    /// </summary>
    //    public object children
    //    {
    //        get; set;
    //    }


    //    private bool isExpanded = true;
    //    public bool IsExpanded
    //    {
    //        get
    //        {
    //            return isExpanded;
    //        }
    //        set
    //        {
    //            SetProperty(ref isExpanded, value);
    //        }
    //    }

    //    private bool isSelected;
    //    public bool IsSelected
    //    {
    //        get
    //        {
    //            return isSelected;
    //        }
    //        set
    //        {
    //            SetProperty(ref isSelected, value);
    //        }
    //    }

    //    public override string ToString()
    //    {
    //        return $"{Value}-{Text}";
    //    }
    //}
}
