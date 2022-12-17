using AIStudio.Wpf.BasePage.ViewModels;
using AIStudio.Wpf.Entity.DTOModels;
using AIStudio.Wpf.Business;
using Prism.Ioc;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace AIStudio.Wpf.Base_Manage.ViewModels
{
    public class Base_CommonFormConfigEditViewModel : BaseEditViewModel2<Base_CommonFormConfigDTO>
    {
        public Base_CommonFormConfigEditViewModel()
        {
        }

        public string[] PropertyTypes
        {
            get
            {
                return new string[] { "string", "bool", "int", "long", "double", "decimal", "datetime", "list" };
            }
        }
    }
}
