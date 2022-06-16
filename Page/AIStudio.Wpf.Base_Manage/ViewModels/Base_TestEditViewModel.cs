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
    public class Base_TestEditViewModel : BaseEditViewModel<Base_TestDTO>
    {
        public Base_TestEditViewModel(Base_TestDTO data, string area, string identifier, string title = "编辑表单") : base(data, area, identifier, title)
        {

        }

		protected override void InitData()
		{
			Data = new Base_TestDTO();
		}

        protected override void GetData(Base_TestDTO para)
        {
            base.GetData(para);
        }       
    }
}
