using AIStudio.Core;
using AIStudio.Wpf.Service.AppClient.Models;
using ICSharpCode.SharpZipLib.GZip;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AIStudio.Wpf.Service.AppClient.HttpClients
{
    public class HttpClientHelper
    {
        private static HttpClientHelper instance = null;
        private static object obj = new object();
        private IHttpClientFactory httpClientFactory;

        public static HttpClientHelper Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (obj)
                    {
                        if (instance == null)
                        {
                            instance = new HttpClientHelper();
                            var serviceProvider = new ServiceCollection().AddHttpClient().BuildServiceProvider();
                            instance.httpClientFactory = serviceProvider.GetService<IHttpClientFactory>();
                        }
                    }
                }
                return instance;
            }
        }

        /// <summary>
        /// 记录日志
        /// </summary>
        public Action<string> HandleLog { get; set; }


        /// <summary>
        /// 使用post方法异步请求
        /// </summary>
        /// <param name="url">目标链接</param>
        /// <param name="json">发送的参数字符串，只能用json</param>
        /// <returns>返回的字符串</returns>
        public async Task<string> PostAsyncJson(string url, string json, TimeSpan timeSpan, Dictionary<string, string> header = null, CompressionType zip = CompressionType.None)
        {
            HttpClient client = httpClientFactory.CreateClient();
            client.Timeout = timeSpan;
            HttpContent content = new StringContent(json);
            if (header != null)
            {
                client.DefaultRequestHeaders.Clear();
                foreach (var item in header)
                {
                    client.DefaultRequestHeaders.Add(item.Key, item.Value);
                }
            }
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            string responseBody = string.Empty;
            string resData = string.Empty;
            DateTime startTime = DateTime.Now;

            try
            {
                HttpResponseMessage response = await client.PostAsync(url, content);
                response.EnsureSuccessStatusCode();
                responseBody = await response.Content.ReadAsStringAsync();
                switch (zip)
                {
                    case CompressionType.None: break;
                    case CompressionType.GZip: responseBody = CompressionHelper.DeCompress(responseBody, zip); break;
                    case CompressionType.BZip2: responseBody = CompressionHelper.DeCompress(responseBody, zip); break;
                    case CompressionType.Zip: responseBody = CompressionHelper.DeCompress(responseBody, zip); break;
                }
                resData = responseBody;
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


        /// <summary>
        /// 使用post方法异步请求
        /// </summary>
        /// <param name="url">目标链接</param>
        /// <param name="data">发送的参数字符串</param>
        /// <returns>返回的字符串</returns>
        public async Task<string> PostAsync(string url, HttpContent content, TimeSpan timeSpan, Dictionary<string, string> header = null, bool Gzip = false)
        {
            //HttpClient client = new HttpClient(new HttpClientHandler() { UseCookies = false });
            HttpClient client = httpClientFactory.CreateClient();
            client.Timeout = timeSpan;
            if (header != null)
            {
                client.DefaultRequestHeaders.Clear();
                foreach (var item in header)
                {
                    client.DefaultRequestHeaders.Add(item.Key, item.Value);
                }
            }

            string responseBody = string.Empty;
            string resData = string.Empty;
            DateTime startTime = DateTime.Now;

            try
            {
                HttpResponseMessage response = await client.PostAsync(url, content);
                response.EnsureSuccessStatusCode();

                if (Gzip)
                {
                    GZipInputStream inputStream = new GZipInputStream(await response.Content.ReadAsStreamAsync());
                    responseBody = new StreamReader(inputStream).ReadToEnd();
                }
                else
                {
                    responseBody = await response.Content.ReadAsStringAsync();

                }
                resData = responseBody;
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

        /// <summary>
        /// 使用post方法异步请求
        /// </summary>
        /// <param name="url">目标链接</param>
        /// <param name="data">发送的参数字符串</param>
        /// <returns>返回的字符串</returns>
        public async Task<string> PostAsync(string url, string data, TimeSpan timeSpan, Dictionary<string, string> header = null, bool Gzip = false)
        {
            //HttpClient client = new HttpClient(new HttpClientHandler() { UseCookies = false });
            HttpClient client = httpClientFactory.CreateClient();
            client.Timeout = timeSpan;
            HttpContent content = new StringContent(data);
            if (header != null)
            {
                client.DefaultRequestHeaders.Clear();
                foreach (var item in header)
                {
                    client.DefaultRequestHeaders.Add(item.Key, item.Value);
                }
            }

            string responseBody = string.Empty;
            string resData = string.Empty;
            DateTime startTime = DateTime.Now;

            try
            {
                HttpResponseMessage response = await client.PostAsync(url, content);
                response.EnsureSuccessStatusCode();
                if (Gzip)
                {
                    GZipInputStream inputStream = new GZipInputStream(await response.Content.ReadAsStreamAsync());
                    responseBody = new StreamReader(inputStream).ReadToEnd();
                }
                else
                {
                    responseBody = await response.Content.ReadAsStringAsync();

                }
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

        public async Task<byte[]> GetByteArrayAsync(string uri, TimeSpan timeSpan, Dictionary<string, string> header = null)
        {
            HttpClient client = httpClientFactory.CreateClient();
            client.Timeout = timeSpan;
            if (header != null)
            {
                client.DefaultRequestHeaders.Clear();
                foreach (var item in header)
                {
                    client.DefaultRequestHeaders.Add(item.Key, item.Value);
                }
            }

            byte[] urlContents = await client.GetByteArrayAsync(uri);
            return urlContents;
        }

        /// <summary>
        /// 使用get方法异步请求
        /// </summary>
        /// <param name="url">目标链接</param>
        /// <returns>返回的字符串</returns>
        public async Task<string> GetAsync(string url, TimeSpan timeSpan, Dictionary<string, string> header = null, bool Gzip = false)
        {

            HttpClient client = new HttpClient(new HttpClientHandler() { UseCookies = false });
            client.Timeout = timeSpan;
            if (header != null)
            {
                client.DefaultRequestHeaders.Clear();
                foreach (var item in header)
                {
                    client.DefaultRequestHeaders.Add(item.Key, item.Value);
                }
            }

            string responseBody = string.Empty;
            string resData = string.Empty;
            DateTime startTime = DateTime.Now;

            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();//用来抛异常的
                if (Gzip)
                {
                    GZipInputStream inputStream = new GZipInputStream(await response.Content.ReadAsStreamAsync());
                    responseBody = new StreamReader(inputStream).ReadToEnd();
                }
                else
                {
                    responseBody = await response.Content.ReadAsStringAsync();

                }
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
method:{"Get"}
耗时:{(int)time.TotalMilliseconds}ms

返回:{resData}
";
                HandleLog?.Invoke(log);
            }

            return responseBody;
        }

    }
}
