using Accelerider.Extensions.Mvvm;
using AIStudio.Core.Models;
using AIStudio.Wpf.BasePage.ViewModels;
using AIStudio.Wpf.Controls;
using AIStudio.Wpf.GridControls.ViewModel;
using NPOI.SS.Formula.Functions;
using NPOI.SS.Formula.PTG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIStudio.Wpf.BasePage.Views
{
    public class BaseEditFormView : ChildWindow
    {
        public static BaseEditFormView CreateView<EditForm, TData, Options>(Options option, string area, string identifier) where EditForm : BaseEditFormView where TData : class, IIsChecked
        {
            var dialog = Activator.CreateInstance<EditForm>();
            dialog.Init<TData, Options>(option, area, identifier);
            return dialog;
        }


        public virtual void Init<TData, Options>(Options option, string area, string identifier) where TData : class, IIsChecked
        {
            var viewmodel = GetEditViewModel<TData>();
            viewmodel.Options = option;
            viewmodel.Area = area;
            viewmodel.Identifier = identifier;

            ValidationActionAsync += () => { return viewmodel.ValidationAsync(); };
            Loaded += async (sender, e) => { await viewmodel.OnLoaded(sender, e); };
            Unloaded += async (sender, e) => { await viewmodel.OnUnloaded(sender, e); };
            DataContext = viewmodel;
        }

        protected virtual BaseEditViewModel2<TData> GetEditViewModel<TData>() where TData : class, IIsChecked
        {
            return new BaseEditViewModel2<TData>();
        }

      
    }


}
