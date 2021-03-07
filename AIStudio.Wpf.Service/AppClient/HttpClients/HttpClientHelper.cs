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

        #region
        ///// <summary>
        ///// get请求
        ///// </summary>
        ///// <param name="url"></param>
        ///// <returns></returns>
        //public string GetResponse(string url)
        //{
        //    if (url.StartsWith("https"))
        //        System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;

        //    var httpClient = httpClientFactory.CreateClient();
        //    httpClient.DefaultRequestHeaders.Accept.Add(
        //      new MediaTypeWithQualityHeaderValue("application/json"));
        //    HttpResponseMessage response = httpClient.GetAsync(url).Result;

        //    if (response.IsSuccessStatusCode)
        //    {
        //        string result = response.Content.ReadAsStringAsync().Result;
        //        return result;
        //    }
        //    return null;
        //}

        //public  T GetResponse<T>(string url)
        //    where T : class, new()
        //{
        //    if (url.StartsWith("https"))
        //        System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;

        //    var httpClient = httpClientFactory.CreateClient();
        //    httpClient.DefaultRequestHeaders.Accept.Add(
        //        new MediaTypeWithQualityHeaderValue("application/json"));
        //    HttpResponseMessage response = httpClient.GetAsync(url).Result;

        //    T result = default(T);

        //    if (response.IsSuccessStatusCode)
        //    {
        //        Task<string> t = response.Content.ReadAsStringAsync();
        //        string s = t.Result;

        //        result = JsonConvert.DeserializeObject<T>(s);
        //    }
        //    return result;
        //}

        ///// <summary>
        ///// post请求
        ///// </summary>
        ///// <param name="url"></param>
        ///// <param name="postData">post数据</param>
        ///// <returns></returns>
        //public  string PostResponse(string url, string postData)
        //{
        //    if (url.StartsWith("https"))
        //        System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;

        //    HttpContent httpContent = new StringContent(postData);
        //    httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        //    var httpClient = httpClientFactory.CreateClient();

        //    HttpResponseMessage response = httpClient.PostAsync(url, httpContent).Result;

        //    if (response.IsSuccessStatusCode)
        //    {
        //        string result = response.Content.ReadAsStringAsync().Result;
        //        return result;
        //    }
        //    return null;
        //}

        ///// <summary>
        ///// 发起post请求
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="url">url</param>
        ///// <param name="postData">post数据</param>
        ///// <returns></returns>
        //public  T PostResponse<T>(string url, string postData)
        //   where T : class, new()
        //{
        //    if (url.StartsWith("https"))
        //        System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;

        //    HttpContent httpContent = new StringContent(postData);
        //    httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        //    var httpClient = httpClientFactory.CreateClient();

        //    T result = default(T);

        //    HttpResponseMessage response = httpClient.PostAsync(url, httpContent).Result;

        //    if (response.IsSuccessStatusCode)
        //    {
        //        Task<string> t = response.Content.ReadAsStringAsync();
        //        string s = t.Result;

        //        result = JsonConvert.DeserializeObject<T>(s);
        //    }
        //    return result;
        //}

        ///// <summary>
        ///// V3接口全部为Xml形式，故有此方法
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="url"></param>
        ///// <param name="xmlString"></param>
        ///// <returns></returns>
        //public  T PostXmlResponse<T>(string url, string xmlString)
        //    where T : class, new()
        //{
        //    if (url.StartsWith("https"))
        //        System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;

        //    HttpContent httpContent = new StringContent(xmlString);
        //    httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        //    var httpClient = httpClientFactory.CreateClient();

        //    T result = default(T);

        //    HttpResponseMessage response = httpClient.PostAsync(url, httpContent).Result;

        //    if (response.IsSuccessStatusCode)
        //    {
        //        Task<string> t = response.Content.ReadAsStringAsync();
        //        string s = t.Result;

        //        result = XmlDeserialize<T>(s);
        //    }
        //    return result;
        //}

        ///// <summary>
        ///// 反序列化Xml
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="xmlString"></param>
        ///// <returns></returns>
        //public  T XmlDeserialize<T>(string xmlString)
        //    where T : class, new()
        //{
        //    try
        //    {
        //        XmlSerializer ser = new XmlSerializer(typeof(T));
        //        using (StringReader reader = new StringReader(xmlString))
        //        {
        //            return (T)ser.Deserialize(reader);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("XmlDeserialize发生异常：xmlString:" + xmlString + "异常信息：" + ex.Message);
        //    }

        //}
        #endregion

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

        /// <summary>
        /// 使用post返回异步请求直接返回对象
        /// </summary>
        /// <typeparam name="T">返回对象类型</typeparam>
        /// <typeparam name="T2">请求对象类型</typeparam>
        /// <param name="url">请求链接</param>
        /// <param name="obj">请求对象数据</param>
        /// <returns>请求返回的目标对象</returns>
        public async Task<T> PostObjectAsync<T, T2>(string url, T2 obj)
        {
            String json = JsonConvert.SerializeObject(obj);
            string responseBody = await PostAsyncJson(url, json, TimeSpan.FromSeconds(8)); //请求当前账户的信息
            return JsonConvert.DeserializeObject<T>(responseBody);//把收到的字符串序列化
        }

        /// <summary>
        /// 使用Get返回异步请求直接返回对象
        /// </summary>
        /// <typeparam name="T">请求对象类型</typeparam>
        /// <param name="url">请求链接</param>
        /// <returns>返回请求的对象</returns>
        public async Task<T> GetObjectAsync<T>(string url)
        {
            string responseBody = await GetAsync(url, TimeSpan.FromSeconds(8)); //请求当前账户的信息
            return JsonConvert.DeserializeObject<T>(responseBody);//把收到的字符串序列化
        }

    }
}
