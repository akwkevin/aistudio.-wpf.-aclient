using AIStudio.Core.Models;
using AIStudio.Wpf.Agile_Development.Commons;
using AIStudio.Wpf.BasePage.ViewModels;
using AIStudio.Wpf.Service.AppClient.ProtobufModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AIStudio.Wpf.Agile_Development.ViewModels
{
    public class Protobuf_QueryEditViewModel<T> : BaseEditViewModel<T> where T : class, IIsChecked
    {
        public ObservableCollection<EditFormItem> EditFormItems
        {
            get; private set;
        } = new ObservableCollection<EditFormItem>();

        public Protobuf_QueryEditViewModel(IEnumerable<EditFormItem> editFormItems, T data, string area, string identifier, string title = "编辑表单") : base(data, area, identifier, title, autoInit:false)
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

                var result = await _dataProvider.GetData_Protobuf<T>($"/{Area}/{typeof(T).Name.Replace("DTO", "")}/GetTheData", new IdInputDTO_Protobuf() { id = para.Id });
                if (!result.Success)
                {
                    throw new Exception(result.Msg);
                }
                Data = result.Data;

                BaseControlItem.ObjectToList(Data, EditFormItems);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                HideWait();
            }
        }
    }
}
