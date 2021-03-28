using AIStudio.Wpf.BasePage.ViewModels;
using AIStudio.Wpf.EFCore.DTOModels;
using AIStudio.Wpf.Business;
using Prism.Ioc;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace AIStudio.Wpf.D_Manage.ViewModels
{
    public class D_NoticeEditViewModel : BaseEditViewModel<D_NoticeDTO>
    {
        public D_NoticeEditViewModel(D_NoticeDTO data, string area, string identifier, string title = "编辑表单") : base(data, area, identifier, title)
        {
            if (Data == null)
            {
                InitData();
            }
            else
            {
                GetData(Data);
            }
        }

		protected override void InitData()
		{
			Data = new D_NoticeDTO();
		}

        protected override void GetData(D_NoticeDTO para)
        {
            base.GetData(para);
        }       
    }
}
