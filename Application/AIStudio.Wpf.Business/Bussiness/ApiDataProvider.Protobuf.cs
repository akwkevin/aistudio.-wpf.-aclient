using AIStudio.Core;
using AIStudio.Wpf.Service.AppClient;
using System;
using System.Threading.Tasks;

namespace AIStudio.Wpf.Business
{
    public partial class ApiDataProvider : IDataProvider
    {
        public async Task<AjaxResult<T>> GetData_Protobuf<T>(string url, object obj)
        {
            try
            {
                return await NetworkTransfer.Instance.GetData_Protobuf<T>(url, obj);
            }
            catch (Exception ex)
            {
                return new AjaxResult<T>() { Msg = ex.Message, Success = false };
            }
        }
    }
}
