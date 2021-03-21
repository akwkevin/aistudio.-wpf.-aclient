using AIStudio.Wpf.Service.AppClient.HttpClients;
using AIStudio.Wpf.Service.AppClient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace AIStudio.Wpf.Service.AppClient
{
    public class NetworkTransfer
    {
        private static NetworkTransfer instance = null;
        private static object obj = new object();

        public static NetworkTransfer Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (obj)
                    {
                        if (instance == null)
                        {
                            instance = new NetworkTransfer();
                        }
                    }
                }
                return instance;
            }
        }

        public string Url { get; set; }
        public IAppHeader Header { get; set; }
        public TimeSpan TimeSpan { get; set; }
        public void Init(string url, IAppHeader header, TimeSpan timeout)
        {
            Url = url;
            Header = header;
            TimeSpan = timeout;
        }

        public async Task<AjaxResult> GetToken()
        {
            if (Header is AppTokenHeader)
            {
                AppTokenHeader header = Header as AppTokenHeader;

                var content = await HttpClientHelper.Instance.PostAsyncJson((string.Format("{0}/Base_Manage/Home/SubmitLogin", Url)), JsonConvert.SerializeObject(new { userName = header.UserName, password = header.Password }), TimeSpan);
                var result = JsonConvert.DeserializeObject<AjaxResult>(content);
                header.Token = result.Data as string;
                return result;
            }

            return null;
        }

        public async Task<AjaxResult> GetData(string url, Dictionary<string, string> data)
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
            var content = await HttpClientHelper.Instance.PostAsync(url, content: stringContent, TimeSpan, Header.SetHeader());
            var result = JsonConvert.DeserializeObject<AjaxResult>(content);
            return result;
        }

        public async Task<AjaxResult> GetData(string url, string json)
        {
            if (!url.StartsWith("http"))
            {
                url = Url + url;
            }
            var content = await HttpClientHelper.Instance.PostAsyncJson(url, json, TimeSpan, Header.SetHeader());
            var result = JsonConvert.DeserializeObject<AjaxResult>(content);
            return result;
        }

        public async Task<AjaxResult> PostData(AppMessage apiMessage)
        {
            string json = JsonConvert.SerializeObject(apiMessage);
            var content = await HttpClientHelper.Instance.PostAsyncJson(string.Format("{0}/api/AppServer/ProcessMessage", Url), json, TimeSpan, Header.SetHeader(), apiMessage.Zip);
            var result = JsonConvert.DeserializeObject<AjaxResult>(content);
            return result;
        }

        public async Task<AjaxResult> Query(string tableName, ICollection<string> columns, string condition, object[] args, CompressionType zip)
        {
            AppMessage apiMessage = new AppMessage();
            apiMessage.Type = WebMessageType.QueryRequest;
            apiMessage.Zip = zip;
            apiMessage.Datas = new string[]
            {
                tableName,
                StandardTimeFormatJsonConvertor.SerializeObject(columns),
                condition,
                StandardTimeFormatJsonConvertor.SerializeObject(args)
            };

            return await PostData(apiMessage);
        }

        public async Task<AjaxResult> Add(string tableName, string datajson, ICollection<string> columns, CompressionType zip)
        {
            AppMessage apiMessage = new AppMessage();
            apiMessage.Type = WebMessageType.AddRequest;
            apiMessage.Zip = zip;
            apiMessage.Datas = new string[]
            {
                tableName,
                datajson,
                StandardTimeFormatJsonConvertor.SerializeObject(columns),
            };

            return await PostData(apiMessage);
        }

        public async Task<AjaxResult> Modify(string tableName, ICollection<string> columns, string datajson, CompressionType zip)
        {
            AppMessage apiMessage = new AppMessage();
            apiMessage.Type = WebMessageType.ModifyRequest;
            apiMessage.Zip = zip;
            apiMessage.Datas = new string[]
            {
                tableName,
                StandardTimeFormatJsonConvertor.SerializeObject(columns),
                datajson,
            };

            return await PostData(apiMessage); ;
        }

        public async Task<AjaxResult> Delete(string tableName, string primaryKeyColumn, ICollection<object> ids, CompressionType zip)
        {
            AppMessage apiMessage = new AppMessage();
            apiMessage.Type = WebMessageType.DeleteRequest;
            apiMessage.Zip = zip;
            apiMessage.Datas = new string[]
            {
                tableName,
                primaryKeyColumn,
                StandardTimeFormatJsonConvertor.SerializeObject(ids),
            };

            return await PostData(apiMessage);
        }

        public async Task<AjaxResult> ComplexOperation(string addJson, string modifyJson, string deleteJson, CompressionType zip)
        {
            AppMessage apiMessage = new AppMessage();
            apiMessage.Type = WebMessageType.ComplexOperationRequest;
            apiMessage.Zip = zip;
            apiMessage.Datas = new string[]
            {
                addJson,
                modifyJson,
                deleteJson,
            };

            return await PostData(apiMessage);
        }

        public async Task<AjaxResult> ComplexQuery(ICollection<ComplexQuery> queries, CompressionType zip)
        {
            AppMessage apiMessage = new AppMessage();
            apiMessage.Type = WebMessageType.ComplexQueryRequest;
            apiMessage.Zip = zip;
            apiMessage.Datas = new string[]
            {
                StandardTimeFormatJsonConvertor.SerializeObject(queries)
            };

            return await PostData(apiMessage);
        }

        public async Task<AjaxResult> QueryWithCustomSQL(string tableName, string sql, object[] args, CompressionType zip)
        {
            AppMessage apiMessage = new AppMessage();
            apiMessage.Type = WebMessageType.QueryWithCustomSQLRequest;
            apiMessage.Zip = zip;
            apiMessage.Datas = new string[]
            {
                tableName,
                sql,
                StandardTimeFormatJsonConvertor.SerializeObject(args),
            };

            return await PostData(apiMessage);
        }

        public async Task<AjaxResult> UploadFile(string path, string fileName, string qq)
        {
            var data = new MultipartFormDataContent();
            //添加字符串参数，参数名为qq
            data.Add(new StringContent(qq), "qq");

            //添加文件参数，参数名为files，文件名为123.png
            data.Add(new ByteArrayContent(System.IO.File.ReadAllBytes(path)), "file", fileName);

            var content = await HttpClientHelper.Instance.PostAsync(string.Format("{0}/api/FileServer/SaveFile", Url), data, TimeSpan, Header.SetHeader());
            var result = JsonConvert.DeserializeObject<AjaxResult>(content);
            return result;
        }

        public async Task<AjaxResult> DownLoadFile(string fullpath, string savepath)
        {
            FileStream fs = null;
            try
            {
                var content = await HttpClientHelper.Instance.GetByteArrayAsync(fullpath, TimeSpan);
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

        public async Task<UploadResult> UploadFileByForm(string path)
        {
            var data = new MultipartFormDataContent();

            FileStream fStream = File.Open(path, FileMode.Open, FileAccess.Read);
            data.Add(new StreamContent(fStream, (int)fStream.Length), "file", Path.GetFileName(path));

            var content = await HttpClientHelper.Instance.PostAsync(string.Format("{0}/Base_Manage/Upload/UploadFileByForm", Url), data, TimeSpan, Header.SetHeader());
            var result = JsonConvert.DeserializeObject<UploadResult>(content);

            fStream.Close();


            return result;
        }
    }
}
