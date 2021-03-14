using AIStudio.AOP;
using AIStudio.Wpf.Service.AppClient;
using AIStudio.Wpf.Service.AppClient.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AIStudio.Wpf.Service.IAppClient
{
   
    public interface IDataProvider
    {
        void Init(string url, string userName, string password, int headMode, TimeSpan timeout);
        Task<WebResponse<string>> GetToken();

        [LogHandler]
        Task<WebResponse<T>> GetData<T>(string url, Dictionary<string, string> data);

        [LogHandler]
        Task<WebResponse<T>> GetData<T>(string url, string json = "{}");
        Task<UploadResult> UploadFileByForm(string path);
    }
}
