using AIStudio.Core;
using AIStudio.Core.Models;
using AIStudio.Wpf.Service.AppClient;
using AIStudio.Wpf.Service.AppClient.HttpClients;
using AIStudio.Wpf.Service.AppClient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AIStudio.Wpf.Business
{
    public class ApiDataProvider : IDataProvider
    {
        public ApiDataProvider()
        {

        }
        #region 密匙模式
        public ApiDataProvider(string url, string appId, string appSecret, TimeSpan timeout)
        {
            var header = new AppSecretHeader(appId, appSecret);
            NetworkTransfer.Instance.Init(url, header, timeout);
        }
        #endregion

        #region Token模式
        public void Init(string url, string userName, string password, int headMode, TimeSpan timeout)
        {
            var header = new AppTokenHeader(userName, password);
            NetworkTransfer.Instance.Init(url, header, timeout);
        }
        #endregion

        public async Task<AjaxResult> GetToken(string url, string userName, string password, int headMode, TimeSpan timeout)
        {
            Init(url, userName, password, headMode, timeout);
            try
            {
                return  await NetworkTransfer.Instance.GetToken();
            }
            catch (Exception ex)
            {
                return new AjaxResult() { Msg = ex.Message, Success = false};
            }
         
        }

        public Dictionary<string, string> GetHeader()
        {
            return NetworkTransfer.Instance.Header.SetHeader();
        }

        public async Task<AjaxResult<T>> GetData<T>(string url, Dictionary<string, string> data)
        {
            try
            {
                return await NetworkTransfer.Instance.GetData<T>(url, data);
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
                return await NetworkTransfer.Instance.GetData<T>(url, json);
            }
            catch (Exception ex)
            {
                return new AjaxResult<T>() { Msg = ex.Message, Success = false };
            }                      
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
                return await NetworkTransfer.Instance.UploadFile(path, fileName, remark);
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
                return await NetworkTransfer.Instance.DownLoadFile(fullpath, savepath);
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
                return await NetworkTransfer.Instance.UploadFileByForm(path);
            }
            catch (Exception ex)
            {
                return new UploadResult() { status = ex.Message };
            }
        }
    }
}
