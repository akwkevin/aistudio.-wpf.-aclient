using AIStudio.AOP;
using AIStudio.Core;
using AIStudio.Wpf.Business;
using AIStudio.Wpf.DataBusiness.Base_Manage;
using AIStudio.Wpf.Service.AppClient.Models;
using Newtonsoft.Json;
using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace AIStudio.Wpf.DataBusiness
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
                return WebResponse<string>.Failed((int)ResponseCode.CLIENT_EXCEPTION, "暂不支持");

            var result = await business.SubmitLoginAsync(new LoginInputDTO() { userName = userName, password = password });

            return await Task.Run(() =>
            {
                return WebResponse<string>.Success(result, 0);
            });
        }

        

        public Task<WebResponse<T>> GetData<T>(string url, Dictionary<string, string> data)
        {
            throw new Exception("暂不支持");
        }
   
        public async Task<WebResponse<T>> GetData<T>(string url, string json)
        {
            try
            {
                //url固定是三段，例：Base_Manage/Base_Role/GetOptionList
                var paras = url.Split(new string[] { @"/" }, StringSplitOptions.RemoveEmptyEntries);
                //第一段暂时可以
                //第二段对应不用的business
                var type = EFCoreDataProviderExtension.AllTypes.FirstOrDefault(p => p.Name == $"I{paras[1]}Business");
                if (type == null)
                    return WebResponse<T>.Failed((int)ResponseCode.CLIENT_EXCEPTION, "暂不支持");

                //获取接口
                var business = ContainerLocator.Current.Resolve(type);
                if (business == null)
                    return WebResponse<T>.Failed((int)ResponseCode.CLIENT_EXCEPTION, "暂不支持");

                //第三段为函数，根据名称获取方法
                Task task;
                MethodInfo methodInfo = business.GetType().GetMethod($"{paras[2]}Async");
                var para = methodInfo.GetParameters()?.FirstOrDefault();
                if (para != null)
                {
                    var data = JsonConvert.DeserializeObject(json, para.ParameterType);
                    task = methodInfo.Invoke(business, new Object[] { data }) as Task;
                }
                else
                {
                    task = methodInfo.Invoke(business, new Object[] { }) as Task;
                }

                await task;
                //获取执行结果
                var response = task.GetType().GetProperty("Result").GetValue(task, null);     
                if (response is AjaxResult) //解析分页数据
                {                   
                    var pageResult = (response as AjaxResult).ChangeType<AjaxResult<T>>();
                    return WebResponse<T>.Success(pageResult.Data, pageResult.Total);                       
                }
                else if (response is T result) //直接解析数据
                {
                    return WebResponse<T>.Success(result, 1);
                }
                else//解析数据（强制转换）
                {
                    return WebResponse<T>.Success(response.ChangeType<T>(), 1);
                }

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
        public Task<UploadResult> UploadFileByForm(string path)
        {
            throw new Exception("暂不支持");
        }
    }
}
