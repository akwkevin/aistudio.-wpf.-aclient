using AIStudio.Core.Models;
using AIStudio.Wpf.Service.AppClient.ProtobufModels;
using System;

namespace AIStudio.Wpf.BasePage.ViewModels
{
    public class ProtobufEditViewModel<T> : BaseEditViewModel<T> where T : class, IIsChecked
    {      
        public ProtobufEditViewModel(T data, string area, string identifier, string title = "编辑表单", bool autoInit = true) : base(data,area,identifier,title, autoInit)
        {
        
        }

        protected override async void GetData(T para)
        {
            try
            {
                ShowWait();

                var result = await _dataProvider.GetData_Protobuf<T>($"/{Area}/{typeof(T).Name.Replace("DTO", "")}/GetTheData", new IdInputDTO_Protobuf(){ id = para.Id });
                if (!result.Success)
                {
                    throw new Exception(result.Msg);
                }
                Data = result.Data;
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
