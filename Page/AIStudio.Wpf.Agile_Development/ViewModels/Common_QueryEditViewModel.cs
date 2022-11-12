using AIStudio.Core.Models;
using AIStudio.Wpf.Agile_Development.Commons;
using AIStudio.Wpf.BasePage.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIStudio.Wpf.Agile_Development.ViewModels
{
    public class Common_QueryEditViewModel<T> : BaseEditViewModel<T> where T : class, IIsChecked
    {
        public ObservableCollection<EditFormItem> EditFormItems
        {
            get; private set;
        } = new ObservableCollection<EditFormItem>();

        public Common_QueryEditViewModel(IEnumerable<EditFormItem> editFormItems, T data, string area, string identifier, string title = "编辑表单") : base(data, area, identifier, title, autoInit:false)
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
        }

        protected override void InitData()
        {
            base.InitData();

            BaseControlItem.ObjectToList(Data, EditFormItems);
        }

        protected override async void GetData(T para)
        {
            try
            {
                ShowWait();

                var result = await _dataProvider.GetData<T>($"/{Area}/{typeof(T).Name.Replace("DTO", "")}/GetTheData", JsonConvert.SerializeObject(new { id = para.Id }));
                if (!result.Success)
                {
                    throw new Exception(result.Msg);
                }
                Data = result.Data;

                BaseControlItem.ObjectToList(Data, EditFormItems);
            }
            catch (Exception ex)
            {
                Controls.MessageBox.Error(ex.Message);
            }
            finally
            {
                HideWait();
            }
        }
    }
}
