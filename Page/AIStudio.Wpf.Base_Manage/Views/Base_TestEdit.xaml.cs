﻿using AIStudio.Wpf.Base_Manage.ViewModels;
using AIStudio.Wpf.Controls;

namespace AIStudio.Wpf.Base_Manage.Views
{
    /// <summary>
    /// Base_TestEdit.xaml 的交互逻辑
    /// </summary>
    public partial class Base_TestEdit : BaseDialog
    {
        public Base_TestEdit(object viewModel)
        {
            InitializeComponent();

            this.DataContext = viewModel;
        }
    }
}
