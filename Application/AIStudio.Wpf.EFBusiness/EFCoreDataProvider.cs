using AIStudio.Core;
using AIStudio.Wpf.Business;
using AIStudio.Wpf.EFBusiness.Base_Manage;
using AIStudio.Wpf.Service.AppClient;
using AIStudio.Wpf.Service.AppClient.Models;
using Newtonsoft.Json;
using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AIStudio.Wpf.EFBusiness
{
    public class EFCoreDataProvider : IDataProvider
    {
        public EFCoreDataProvider()
        {

        }

        public async Task<WebResponse<string>> GetToken(string url, string userName, string password, int headMode, TimeSpan timeout)
        {  
            var business = ContainerLocator.Current.Resolve<IHomeBusiness>();
            if (business == null)
                return WebResponse<string>.Failed(-1, "暂不支持");

            var result = await business.SubmitLoginAsync(new LoginInputDTO() { userName = userName, password = password });

            return await Task.Run(() =>
            {
                return WebResponse<string>.Success(result, 0);
            });
        }

        

        public async Task<WebResponse<T>> GetData<T>(string url, Dictionary<string, string> data)
        {
            try
            {
                var response = await NetworkTransfer.Instance.GetData(url, data);
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
                var paras = url.Split(new string[] { "//" }, StringSplitOptions.RemoveEmptyEntries);
                var type = EFCoreDataProviderExtension.AllTypes.FirstOrDefault(p => p.Name == $"I{paras[1]}Business");
                if (type == null)
                    return WebResponse<T>.Failed(-1, "暂不支持");

                var business = ContainerLocator.Current.Resolve(type);
                if (business == null)
                    return WebResponse<T>.Failed(-1, "暂不支持");

                return WebResponse<T>.Failed((int)ResponseCode.CLIENT_EXCEPTION, "");

            }
            catch (Exception ex)
            {
                return WebResponse<T>.Failed((int)ResponseCode.CLIENT_EXCEPTION, ex.ToString());
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
                var response = await NetworkTransfer.Instance.UploadFileByForm(path);

                return response;
            }
            catch (Exception ex)
            {
                return new UploadResult() { status = ex.Message };
            }
        }
    }
}
