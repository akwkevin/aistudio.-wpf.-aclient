using AIStudio.Core;
using AIStudio.Wpf.Service.AppClient.HttpClients;
using AIStudio.Wpf.Service.AppClient.ProtobufModels;
using System.Threading.Tasks;
using Zaabee.Protobuf;

namespace AIStudio.Wpf.Service.AppClient
{
    public partial class NetworkTransfer
    {
        public async Task<AjaxResult<T>> GetData_Protobuf<T>(string url, object obj)
        {
            if (!url.StartsWith("http"))
            {
                url = Url + url;
            }

            var result_protobuf = await HttpClientHelper.Instance.PostAsyncProto<AjaxResult_Protobuf>(url, obj, TimeSpan, Header.SetHeader());

            AjaxResult<T> result = result_protobuf.ChangeType<AjaxResult<T>>();
            result.Data = result_protobuf.Data.FromBytes<T>();
            return result;
        }
    }
}
