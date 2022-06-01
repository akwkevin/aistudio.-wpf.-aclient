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
    public class Base_CommonFormConfigEditViewModel : BaseEditViewModel<Base_CommonFormConfigDTO>
    {
        public Base_CommonFormConfigEditViewModel(Base_CommonFormConfigDTO data, string area, string identifier, string title = "编辑表单") : base(data, area, identifier, title)
        {
        }

        public string[] PropertyTypes
        {
            get
            {
                return new string[] { "string", "bool", "int", "long", "double", "decimal", "datetime", "list" };
            }
        }


        protected override void InitData()
        {
            Data = new Base_CommonFormConfigDTO();
        }

        protected override void GetData(Base_CommonFormConfigDTO para)
        {
            base.GetData(para);
        }
    }
}
