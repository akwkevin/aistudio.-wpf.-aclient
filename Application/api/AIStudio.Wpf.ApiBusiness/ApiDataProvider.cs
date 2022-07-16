using AIStudio.Core;
using AIStudio.Wpf.Business;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AIStudio.Wpf.ApiBusiness
{
    public class ApiDataProvider : IDataProvider
    {
        private IHttpClientFactory _httpClientFactory;
        public ApiDataProvider(IHttpClientFactory httpClientFactory)
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

        #region 密匙模式
        public void Init(string url, string appId, string appSecret, TimeSpan timeout)
        {
            var header = new AppSecretHeader(appId, appSecret);
            Url = url;
            Header = header;
            TimeOut = timeout;
        }
        #endregion

        #region Token模式
        public void Init(string url, string userName, string password, int headMode, TimeSpan timeout)
        {
            var header = new AppTokenHeader(userName, password);
            Url = url;
            Header = header;
            TimeOut = timeout;
        }
        #endregion

        public async Task<AjaxResult> GetToken(string url, string userName, string password, int headMode, TimeSpan timeout)
        {
            Init(url, userName, password, headMode, timeout);
            try
            {
                if (Header is AppTokenHeader)
                {
                    AppTokenHeader header = Header as AppTokenHeader;

                    var content = await PostAsyncJson((string.Format("{0}/Base_Manage/Home/SubmitLogin", Url)), JsonConvert.SerializeObject(new { userName = header.UserName, password = header.Password }), TimeOut);
                    var result = JsonConvert.DeserializeObject<AjaxResult>(content);
                    header.Token = result.Data as string;

                    return result;
                }
                else
                {
                    throw new Exception("暂不支持");
                }
            }
            catch (Exception ex)
            {
                return new AjaxResult() { Msg = ex.Message, Success = false};
            }
         
        }

        public async Task<AjaxResult<T>> GetData<T>(string url, Dictionary<string, string> data)
        {
            try
            {
                if (!url.StartsWith("http"))
                {
                    url = Url + url;
                }
                MultipartFormDataContent stringContent = null;
                if (data != null)
                {
                    stringContent = new MultipartFormDataContent();

                    foreach (var item in data)
                    {
                        stringContent.Add(new StringContent(item.Value), item.Key);
                    }
                }
                var content = await PostAsync(url, content: stringContent, TimeOut, Header.GetHeader());
                var result = JsonConvert.DeserializeObject<AjaxResult<T>>(content);
                return result;
            }
            catch (Exception ex)
            {
                return new AjaxResult<T>() { Msg = ex.Message, Success = false };
            }           
        }

        public async Task<AjaxResult<T>> GetData<T>(string url, string json)
        {
            try
            {
                if (!url.StartsWith("http"))
                {
                    url = Url + url;
                }
                var content = await PostAsyncJson(url, json, TimeOut, Header.GetHeader());
                var result = JsonConvert.DeserializeObject<AjaxResult<T>>(content);
                return result;
            }
            catch (Exception ex)
            {
                return new AjaxResult<T>() { Msg = ex.Message, Success = false };
            }                      
        }

        public async Task<AjaxResult<T>> GetData<T>(string url, object data)
        {
            return await GetData<T>(url, JsonConvert.SerializeObject(data));
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="primaryKeyColumn">类型的主键，目前系统都是id</param>
        /// <param name="ids">需要删除的id列表</param>
        /// <returns></returns>
        public async Task<AjaxResult> UploadFile(string path, string fileName, string remark)
        {
            try
            {
                var data = new MultipartFormDataContent();
                ////添加字符串参数，参数名为qq
                //data.Add(new StringContent(qq), "qq");

                //添加文件参数，参数名为files，文件名为123.png
                data.Add(new ByteArrayContent(System.IO.File.ReadAllBytes(path)), "file", fileName);

                var content = await PostAsync(string.Format("{0}/api/FileServer/SaveFile", Url), data, TimeOut, Header.GetHeader());
                var result = JsonConvert.DeserializeObject<AjaxResult>(content);
                return result;
            }
            catch (Exception ex)
            {
                return new AjaxResult() { Msg = ex.Message, Success = false };
            }            
        }

        /// <summary>
        /// 下载文件
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="primaryKeyColumn">类型的主键，目前系统都是id</param>
        /// <param name="ids">需要删除的id列表</param>
        /// <returns></returns>
        public async Task<AjaxResult> DownLoadFile(string fullpath, string savepath)
        {
            try
            {
                FileStream fs = null;
                try
                {
                    var content = await GetByteArrayAsync(fullpath, TimeOut);
                    fs = new FileStream(savepath, FileMode.Create);
                    fs.Write(content, 0, content.Length);
                    return new AjaxResult() { Success = true };
                }
                catch (Exception ex)
                {
                    return new AjaxResult() { Success = false, Msg = ex.ToString() };
                }
                finally
                {
                    if (fs != null)
                        fs.Close();
                }
            }
            catch (Exception ex)
            {
                return new AjaxResult() { Msg = ex.Message, Success = false };
            }           
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="primaryKeyColumn">类型的主键，目前系统都是id</param>
        /// <param name="ids">需要删除的id列表</param>
        /// <returns></returns>
        public async Task<UploadResult> UploadFileByForm(string path)
        {
            try
            {
                var data = new MultipartFormDataContent();

                FileStream fStream = File.Open(path, FileMode.Open, FileAccess.Read);
                data.Add(new StreamContent(fStream, (int)fStream.Length), "file", Path.GetFileName(path));

                var content = await PostAsync(string.Format("{0}/Base_Manage/Upload/UploadFileByForm", Url), data, TimeOut, Header.GetHeader());
                var result = JsonConvert.DeserializeObject<UploadResult>(content);

                fStream.Close();
                return result;
            }
            catch (Exception ex)
            {
                return new UploadResult() { status = ex.Message };
            }
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
        /// <param name="json">发送的参数字符串，只能用json</param>
        /// <returns>返回的字符串</returns>
        public async Task<string> PostAsyncJson(string url, string json, TimeSpan timeSpan, Dictionary<string, string> header = null)
        {
            HttpClient client = _httpClientFactory.CreateClient();
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
        public async Task<string> PostAsync(string url, HttpContent content, TimeSpan timeSpan, Dictionary<string, string> header = null)
        {
            //HttpClient client = new HttpClient(new HttpClientHandler() { UseCookies = false });
            HttpClient client = _httpClientFactory.CreateClient();
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
                responseBody = await response.Content.ReadAsStringAsync();
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
        public async Task<string> PostAsync(string url, string data, TimeSpan timeSpan, Dictionary<string, string> header = null)
        {
            //HttpClient client = new HttpClient(new HttpClientHandler() { UseCookies = false });
            HttpClient client = _httpClientFactory.CreateClient();
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
                responseBody = await response.Content.ReadAsStringAsync();
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
            HttpClient client = _httpClientFactory.CreateClient();
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
        public async Task<string> GetAsync(string url, TimeSpan timeSpan, Dictionary<string, string> header = null)
        {
            HttpClient client = _httpClientFactory.CreateClient();
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
                responseBody = await response.Content.ReadAsStringAsync();
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
        #endregion
    }
}
