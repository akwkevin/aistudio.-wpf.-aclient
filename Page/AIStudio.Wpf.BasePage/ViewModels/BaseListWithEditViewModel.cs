using AIStudio.Core;
using AIStudio.Core.Models;
using AIStudio.Core.Helpers;
using AIStudio.Wpf.BasePage.Views;
using AIStudio.Wpf.Business;
using AIStudio.Wpf.Controls;
using AIStudio.Wpf.Entity.DTOModels;
using Newtonsoft.Json;
using Prism.Ioc;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using System.Threading.Tasks;
using Prism.Commands;
using AIStudio.Wpf.PrismAvalonExtensions.ViewModels;
using NPOI.SS.Formula.Functions;
using Org.BouncyCastle.Crypto.Engines;

namespace AIStudio.Wpf.BasePage.ViewModels
{
    public class BaseListWithEditViewModel<TData, EditForm> : BaseListViewModel<TData> where TData : class, IIsChecked where EditForm : ChildWindow
    {
        protected virtual async void Edit(TData para = null)
        {
            var dialog = CreateView<string>(para?.Id, Area, Identifier);
            if (dialog is ChildWindow childwindow)
            {
                var res = (DialogResult)await WindowBase.ShowChildWindowAsync(childwindow, "编辑表单", Identifier);
                if (res == DialogResult.OK)
                {
                    await GetData();
                }
            }
        }

        #region
        public virtual ChildWindow CreateView<Options>(Options option, string area, string identifier)
        {
            var dialog = Activator.CreateInstance<EditForm>() as ChildWindow;
            var viewmodel = GetEditViewModel();
            viewmodel.Options = option;
            viewmodel.Area = area;
            viewmodel.Identifier = identifier;

            dialog.ValidationActionAsync += () => { return viewmodel.ValidationAsync(); };
            dialog.Loaded += async (sender, e) => { await viewmodel.OnLoaded(sender, e); };
            dialog.Unloaded += async (sender, e) => { await viewmodel.OnUnloaded(sender, e); };
            dialog.DataContext = viewmodel;

            return dialog;
        }

        protected virtual BaseEditViewModel2<TData> GetEditViewModel()
        {
            return new BaseEditViewModel2<TData>();
        }
        #endregion
   
    }
}
