using AIStudio.Core;
using AIStudio.Wpf.Business;
using AIStudio.Wpf.ProtobufApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Zaabee.Protobuf;

namespace AIStudio.Wpf.ProtobufApi
{
    public class ProtobufDataProvider : IDataProvider
    {
        private IHttpClientFactory _httpClientFactory;
        public ProtobufDataProvider(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        #region 设置信息
        public string Url { get; set; }
        public IAppHeader Header { get; set; }
        public TimeSpan TimeOut { get; set; }
        public Dictionary<string, string> GetHeader()
        {
            return Header.GetHeader();
        }
        #endregion

        public async Task<AjaxResult> GetToken(string url, string userName, string password, int headMode, TimeSpan timeout)
        {
            throw new Exception("暂不支持");
        }

        public Task<AjaxResult<T>> GetData<T>(string url, Dictionary<string, string> data)
        {
            throw new NotImplementedException();
        }

        public Task<AjaxResult<T>> GetData<T>(string url, string json = "{}")
        {
            throw new NotImplementedException();
        }

        public async Task<AjaxResult<T>> GetData<T>(string url, object obj)
        {
            try
            {
                if (!url.StartsWith("http"))
                {
                    url = Url + url;
                }

                var result_protobuf = await PostAsyncProto<AjaxResult_Protobuf>(url, obj, TimeOut, Header.GetHeader());

                AjaxResult<T> result = result_protobuf.ChangeType<AjaxResult<T>>();
                result.Data = result_protobuf.Data.FromBytes<T>();
                return result;
            }
            catch (Exception ex)
            {
                return new AjaxResult<T>() { Msg = ex.Message, Success = false };
            }
        }

        public Task<UploadResult> UploadFileByForm(string path)
        {
            throw new NotImplementedException();
        }

        #region HttpClient
        /// <summary>
        /// 记录日志
        /// </summary>
        public Action<string> HandleLog { get; set; }

        /// <summary>
        /// 使用post方法异步请求
        /// </summary>
        /// <param name="url">目标链接</param>
        /// <param name="obj">目标object</param>
        /// <returns>返回的字符串</returns>
        public async Task<T> PostAsyncProto<T>(string url, object obj, TimeSpan timeSpan, Dictionary<string, string> header = null)
        {
            HttpClient client = _httpClientFactory.CreateClient();
            client.Timeout = timeSpan;

            var stream = obj.ToStream();
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, url)
            {
                Content = new StreamContent(stream)
            };
            httpRequestMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("application/x-protobuf");
            httpRequestMessage.Headers.Add("Accept", "application/x-protobuf");
            if (header != null)
            {
                foreach (var item in header)
                {
                    httpRequestMessage.Headers.Add(item.Key, item.Value);
                }
            }

            T responseBody;
            string resData = string.Empty;
            DateTime startTime = DateTime.Now;

            try
            {
                HttpResponseMessage response = await client.SendAsync(httpRequestMessage);
                response.EnsureSuccessStatusCode();
                var responseStream = await response.Content.ReadAsStreamAsync();
                responseBody = responseStream.FromStream<T>();
                resData = responseBody.ToString();
            }
            catch (Exception ex)
            {
                resData = $"异常:{ExceptionHelper.GetExceptionAllMsg(ex)}";

                throw ex;
            }
            finally
            {
                var time = DateTime.Now - startTime;
                if (resData?.Length > 1000)
                {
                    resData = new string(resData.Copy(0, 1000).ToArray());
                    resData += "......";
                }

                string log =
$@"方向:请求外部接口
url:{url}
method:{"Post"}
耗时:{(int)time.TotalMilliseconds}ms

返回:{resData}
";
                HandleLog?.Invoke(log);
            }

            return responseBody;
        }
        #endregion
    }
}
