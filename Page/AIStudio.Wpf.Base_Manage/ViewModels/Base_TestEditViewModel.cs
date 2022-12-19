using AIStudio.Wpf.BasePage.ViewModels;
using AIStudio.Wpf.Entity.DTOModels;
using AIStudio.Wpf.Business;
using Prism.Ioc;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using AIStudio.Core;
using AIStudio.Wpf.BasePage.Models;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace AIStudio.Wpf.Base_Manage.ViewModels
{
    public class Base_TestEditViewModel : BaseEditViewModel<Base_TestDTO>
    {
        protected override async Task GetData(object option)
        {
           await base.GetData(option);
        }

        protected override async Task<bool> SaveData()
        {
            return await base.SaveData();
        }

        public override async Task<bool> ValidationAsync()
        {
           return await base.ValidationAsync();
        }
    }
}
