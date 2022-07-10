using AIStudio.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Zaabee.Protobuf;

namespace AIStudio.Wpf.Service.AppClient.HttpClients
{
    public partial class HttpClientHelper
    {
        /// <summary>
        /// 使用post方法异步请求
        /// </summary>
        /// <param name="url">目标链接</param>
        /// <param name="json">发送的参数字符串，只能用json</param>
        /// <returns>返回的字符串</returns>
        public async Task<T> PostAsyncProto<T>(string url, object obj, TimeSpan timeSpan, Dictionary<string, string> header = null)
        {
            HttpClient client = httpClientFactory.CreateClient();
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
    }
}
