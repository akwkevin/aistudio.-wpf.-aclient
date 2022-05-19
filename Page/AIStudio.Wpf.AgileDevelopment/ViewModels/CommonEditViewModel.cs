using AIStudio.Core.Models;
using AIStudio.Wpf.AgileDevelopment.Commons;
using AIStudio.Wpf.BasePage.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIStudio.Wpf.AgileDevelopment.ViewModels
{
    public class CommonEditViewModel<T> : BaseEditViewModel<T> where T : class, IIsChecked
    {
        public ObservableCollection<EditFormItem> EditFormItems
        {
            get; private set;
        } = new ObservableCollection<EditFormItem>();

        public CommonEditViewModel(IEnumerable<EditFormItem> editFormItems, T data, string area, string identifier, string title = "编辑表单") : base(data, area, identifier, title)
        {
            EditFormItems = new ObservableCollection<EditFormItem>(editFormItems);

            if (Data == null)
            {
                InitData();
            }
            else
            {
                GetData(Data);
            }

            BaseControlItem.ObjectToList(Data, EditFormItems);
        }


        //protected override void InitData()
        //{
        //    base.InitData();
        //    BaseControlItem.ObjectToList(Data, EditFormItems);
        //}

        //protected override void GetData(T para)
        //{
        //    base.GetData(para);
        //    BaseControlItem.ObjectToList(Data, EditFormItems);
        //}

    }
}
