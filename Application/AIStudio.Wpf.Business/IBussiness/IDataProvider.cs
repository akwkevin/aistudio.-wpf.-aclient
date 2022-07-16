using AIStudio.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AIStudio.Wpf.Business
{

    public interface IDataProvider
    {
        Task<AjaxResult> GetToken(string url, string userName, string password, int headMode, TimeSpan timeout);

        string Url { get; set; }
        IAppHeader Header { get; set; }
        TimeSpan TimeOut { get; set; }

        Dictionary<string, string> GetHeader();
        //[LogHandler]
        Task<AjaxResult<T>> GetData<T>(string url, Dictionary<string, string> data);
        //[LogHandler]
        Task<AjaxResult<T>> GetData<T>(string url, string json = "{}");

        Task<AjaxResult<T>> GetData<T>(string url, object data);

        Task<UploadResult> UploadFileByForm(string path);
    }
}
