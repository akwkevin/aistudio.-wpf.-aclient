using AIStudio.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AIStudio.Wpf.Business
{

    public interface IDataProvider
    {    
        Task<AjaxResult> GetToken(string url, string userName, string password, int headMode, TimeSpan timeout);

        Dictionary<string, string> GetHeader();
        //[LogHandler]
        Task<AjaxResult<T>> GetData<T>(string url, Dictionary<string, string> data);

        //[LogHandler]
        Task<AjaxResult<T>> GetData<T>(string url, string json = "{}");

        Task<UploadResult> UploadFileByForm(string path);

        Task<AjaxResult<T>> GetData_Protobuf<T>(string url, object obj);
    }
}
