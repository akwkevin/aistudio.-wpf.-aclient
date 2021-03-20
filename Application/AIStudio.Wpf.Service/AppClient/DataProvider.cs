using AIStudio.Wpf.Service.AppClient.HttpClients;
using AIStudio.Wpf.Service.AppClient.Models;
using AIStudio.Wpf.Service.IAppClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AIStudio.Wpf.Service.AppClient
{
    public class DataProvider : IDataProvider
    {
        private NetworkTransfer _transfer = null;
        public string Url { get; set; }
        public IAppHeader Header { get; set; }

        #region 密匙模式
        public DataProvider(string url, string appId, string appSecret)
           : this(url, appId, appSecret, TimeSpan.FromSeconds(30))
        {
        }

        public DataProvider(string url, string appId, string appSecret, TimeSpan timeout)
        {
            Url = url;
            Header = new AppSecretHeader(appId, appSecret);
            _transfer = new NetworkTransfer(url, Header, timeout);
        }
        #endregion

        #region Token模式
        public DataProvider(string url, string userName, string password, int headMode)
         : this(url, userName, password, headMode, TimeSpan.FromSeconds(30))
        {
        }

        public DataProvider(string url, string userName, string password, int headMode,  TimeSpan timeout)
        {
            Url = url;
            Header = new AppTokenHeader(userName, password);
            _transfer = new NetworkTransfer(url, Header, timeout);
        }
        #endregion

        public DataProvider()
        {

        }

        public void Init(string url, string userName, string password, int headMode, TimeSpan timeout)
        {
            Url = url;
            Header = new AppTokenHeader(userName, password);
            _transfer = new NetworkTransfer(url, Header, timeout);
        }

        public async Task<WebResponse<string>> GetToken()
        {
            try
            {
                var response = await _transfer.GetToken();
                if (response.Success == true)
                {
                    return WebResponse<string>.Success(response.Data as string, response.Total);
                }

                return WebResponse<string>.Failed(response.ErrorCode, response.Msg);
            }
            catch (Exception ex)
            {
                return WebResponse<string>.Failed((int)ResponseCode.CLIENT_EXCEPTION, ex.ToString());
            }
        }

        public async Task<WebResponse<string>> GetToken(string url, string userName, string password, int headMode, TimeSpan timeout)
        {     
            Init(url, userName, password, headMode, timeout);
            return await GetToken();
        }

        public async Task<WebResponse<T>> GetData<T>(string url, Dictionary<string, string> data)
        {
            try
            {
                if (!url.StartsWith("http"))
                {
                    url = Url + url;
                }
                var response = await _transfer.GetData(url, data);
                if (response.Success == true)
                {
                    if (response is T)
                    {
                        return WebResponse<T>.Success(JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(response)), response.Total);
                    }
                    else
                    {
                        return WebResponse<T>.Success(JsonConvert.DeserializeObject<T>((response.Data ?? "").ToString()), response.Total);
                    }
                }

                return WebResponse<T>.Failed(response.ErrorCode, response.Msg);
            }
            catch (Exception ex)
            {
                return WebResponse<T>.Failed((int)ResponseCode.CLIENT_EXCEPTION, ex.ToString());
            }
        }

        public async Task<WebResponse<T>> GetData<T>(string url, string json)
        {
            try
            {
                if (!url.StartsWith("http"))
                {
                    url = Url + url;
                }
                var response = await _transfer.GetData(url, json);
                if (response.Success == true)
                {
                    if (response is T)
                    {
                        return WebResponse<T>.Success(JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(response)), response.Total);
                    }
                    else
                    {
                        return WebResponse<T>.Success(JsonConvert.DeserializeObject<T>((response.Data ?? "").ToString()), response.Total);
                    }
                }

                return WebResponse<T>.Failed(response.ErrorCode, response.Msg);
            }
            catch (Exception ex)
            {
                return WebResponse<T>.Failed((int)ResponseCode.CLIENT_EXCEPTION, ex.ToString());
            }
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="columns">需要返回的列字段，如果需要返回全部请设置null</param>
        /// <param name="condition">where条件，不带where，例如id = @0，参数使用@0，@1，@2，@3...</param>
        /// <param name="args">对应的参数列表new object[] { guid }</param>
        /// <returns></returns>
        public async Task<WebResponse<List<T>>> Query<T>(ICollection<string> columns, string condition, object[] args, CompressionType zip = CompressionType.None)
        {
            try
            {
                var response = await _transfer.Query(typeof(T).Name, columns, condition, args, zip);
                if (response.Success == true)
                {
                    return WebResponse<List<T>>.Success(JsonConvert.DeserializeObject<List<T>>((response.Data ?? "").ToString()), response.Total);
                }

                return WebResponse<List<T>>.Failed(response.ErrorCode, response.Msg);
            }
            catch (Exception ex)
            {
                return WebResponse<List<T>>.Failed((int)ResponseCode.CLIENT_EXCEPTION, ex.ToString());
            }
        }

        /// <summary>
        /// 创建,column如果没有，那么不会返回,主要为了返回自增长主键，或者是否需要时间戳
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="objs">要插入的T对象列表，逐渐如果是自增长则不必设置</param>
        /// <returns></returns>
        public async Task<WebResponse<List<T>>> Add<T>(ICollection<T> objs, ICollection<string> columns = null, CompressionType zip = CompressionType.None)
        {
            try
            {
                var response = await _transfer.Add(typeof(T).Name, StandardTimeFormatJsonConvertor.SerializeObject(objs), columns, zip);
                if (response.Success == true)
                {
                    return WebResponse<List<T>>.Success(JsonConvert.DeserializeObject<List<T>>((response.Data ?? "").ToString()), response.Total);
                }

                return WebResponse<List<T>>.Failed(response.ErrorCode, response.Msg);
            }
            catch (Exception ex)
            {
                return WebResponse<List<T>>.Failed((int)ResponseCode.CLIENT_EXCEPTION, ex.ToString());
            }
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// /// <param name="columns">需要更新的列字段，如果需要全部更新请设置null</param>
        /// <param name="objs">要更新的T对象列表</param>
        /// <returns></returns>
        public async Task<WebResponse> Modify<T>(ICollection<string> columns, ICollection<T> objs, CompressionType zip = CompressionType.None)
        {
            try
            {
                var response = await _transfer.Modify(typeof(T).Name, columns, StandardTimeFormatJsonConvertor.SerializeObject(objs), zip);
                if (response.Success == true)
                {
                    return WebResponse.Success();
                }

                return WebResponse.Failed(response.ErrorCode, response.Msg);
            }
            catch (Exception ex)
            {
                return WebResponse.Failed((int)ResponseCode.CLIENT_EXCEPTION, ex.ToString());
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="primaryKeyColumn">类型的主键，目前系统都是id</param>
        /// <param name="ids">需要删除的id列表</param>
        /// <returns></returns>
        public async Task<WebResponse> Delete<T>(string primaryKeyColumn, ICollection<object> ids, CompressionType zip = CompressionType.None)
        {
            try
            {
                var response = await _transfer.Delete(typeof(T).Name, primaryKeyColumn, ids, zip);
                if (response.Success == true)
                {
                    return WebResponse.Success();
                }

                return WebResponse.Failed(response.ErrorCode, response.Msg);
            }
            catch (Exception ex)
            {
                return WebResponse.Failed((int)ResponseCode.CLIENT_EXCEPTION, ex.ToString());
            }
        }

        /// <summary>
        /// 复合操作,返回的是Add的类的json格式，自己解吧
        /// </summary>
        /// <param name="addObjs">需要添加的对象，Key是类名</param>
        /// <param name="modifyObjs">需要更新的对象，Key是类名</param>
        /// <param name="deleteObjs">需要删除的对象，Key是类名</param>
        /// <returns></returns>
        public async Task<WebResponse<IDictionary<string, ICollection<object>>>> ComplexOperation(
            IDictionary<string, Tuple<ICollection<string>, ICollection<object>>> addObjs,
            IDictionary<string, Tuple<ICollection<string>, ICollection<object>>> modifyObjs,
            IDictionary<string, Tuple<string, ICollection<object>>> deleteObjs,
            CompressionType zip = CompressionType.None)
        {
            try
            {
                var response = await _transfer.ComplexOperation(StandardTimeFormatJsonConvertor.SerializeObject(addObjs),
                    StandardTimeFormatJsonConvertor.SerializeObject(modifyObjs),
                    StandardTimeFormatJsonConvertor.SerializeObject(deleteObjs), zip);
                if (response.Success == true)
                {
                    return WebResponse<IDictionary<string, ICollection<object>>>.Success(
                        JsonConvert.DeserializeObject<IDictionary<string, ICollection<object>>>((response.Data ?? "").ToString()), response.Total);
                }

                return WebResponse<IDictionary<string, ICollection<object>>>.Failed(response.ErrorCode, response.Msg);
            }
            catch (Exception ex)
            {
                return WebResponse<IDictionary<string, ICollection<object>>>.Failed((int)ResponseCode.CLIENT_EXCEPTION,
                    ex.ToString());
            }
        }

        /// <summary>
        /// 复合查询
        /// </summary>
        /// <param name="queries">需要查询的表列表以及相关参数</param>
        /// <returns></returns>
        public async Task<WebResponse<ComplexQueryResult>> ComplexQuery(
            ICollection<ComplexQuery> queries, CompressionType zip = CompressionType.None)
        {
            try
            {
                var response = await _transfer.ComplexQuery(queries, zip);
                if (response.Success == true)
                {
                    ComplexQueryResult result = JsonConvert.DeserializeObject<ComplexQueryResult>((response.Data ?? "").ToString());
                    return WebResponse<ComplexQueryResult>.Success(result, response.Total);
                }

                return WebResponse<ComplexQueryResult>.Failed(response.ErrorCode, response.Msg);
            }
            catch (Exception ex)
            {
                return WebResponse<ComplexQueryResult>.Failed((int)ResponseCode.CLIENT_EXCEPTION,
                    ex.ToString());
            }
        }



        /// <summary>
        /// 通用SQL查询数据，这个接口不规范，只有在使用常规接口无法实现功能的情况下才使用，请勿滥用
        /// </summary>
        /// <typeparam name="T">结果表对象</typeparam>
        /// <param name="sql">查询完整SQL语句</param>
        /// <param name="args">条件参数</param>
        /// <param name="fromMaster">是否从Master库查询数据，默认是false</param>
        /// <returns>结果集合</returns>
        public async Task<WebResponse<List<T>>> QueryWithCustomSQL<T>(string sql, object[] args, CompressionType zip = CompressionType.None)
        {
            try
            {
                var response = await _transfer.QueryWithCustomSQL(typeof(T).Name, sql, args, zip);
                if (response.Success == true)
                {
                    return WebResponse<List<T>>.Success(JsonConvert.DeserializeObject<List<T>>((response.Data ?? "").ToString()), response.Total);
                }

                return WebResponse<List<T>>.Failed(response.ErrorCode, response.Msg);
            }
            catch (Exception ex)
            {
                return WebResponse<List<T>>.Failed((int)ResponseCode.CLIENT_EXCEPTION, ex.ToString());
            }
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="primaryKeyColumn">类型的主键，目前系统都是id</param>
        /// <param name="ids">需要删除的id列表</param>
        /// <returns></returns>
        public async Task<WebResponse> UploadFile(string path, string fileName, string remark)
        {
            try
            {
                var response = await _transfer.UploadFile(path, fileName, remark);
                if (response.Success == true)
                {
                    return WebResponse.Success();
                }

                return WebResponse.Failed(response.ErrorCode, response.Msg);
            }
            catch (Exception ex)
            {
                return WebResponse.Failed((int)ResponseCode.CLIENT_EXCEPTION, ex.ToString());
            }
        }

        /// <summary>
        /// 下载文件
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="primaryKeyColumn">类型的主键，目前系统都是id</param>
        /// <param name="ids">需要删除的id列表</param>
        /// <returns></returns>
        public async Task<WebResponse> DownLoadFile(string fullpath, string savepath)
        {
            try
            {
                var response = await _transfer.DownLoadFile(fullpath, savepath);
                if (response.Success == true)
                {
                    return WebResponse.Success();
                }

                return WebResponse.Failed(response.ErrorCode, response.Msg);
            }
            catch (Exception ex)
            {
                return WebResponse.Failed((int)ResponseCode.CLIENT_EXCEPTION, ex.ToString());
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
                var response = await _transfer.UploadFileByForm(path);               

                return response;
            }
            catch (Exception ex)
            {
                return new UploadResult() { status = ex.Message };
            }
        }
    }
}
