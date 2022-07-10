using AIStudio.Core;
using AIStudio.Wpf.Business;
using AIStudio.Wpf.DataBusiness.Base_Manage;
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

        public async Task<AjaxResult> GetToken(string url, string userName, string password, int headMode, TimeSpan timeout)
        {  
            var business = ContainerLocator.Current.Resolve<IHomeBusiness>();
            if (business == null)
                return new AjaxResult() { Msg = "暂不支持", Success = false };

            var result = await business.SubmitLoginAsync(new LoginInputDTO() { userName = userName, password = password });

            return await Task.Run(() =>
            {
                return new AjaxResult() { Msg = result, Success = true };
            });
        }

        public Dictionary<string, string> GetHeader()
        {
            return new Dictionary<string, string>();
        }

        public Task<AjaxResult<T>> GetData<T>(string url, Dictionary<string, string> data)
        {
            throw new Exception("暂不支持");
        }

        public Task<AjaxResult<T>> GetData_Protobuf<T>(string url, object obj)
        {
            throw new Exception("暂不支持");
        }

        public async Task<AjaxResult<T>> GetData<T>(string url, string json)
        {
            try
            {
                //url固定是三段，例：Base_Manage/Base_Role/GetOptionList
                var paras = url.Split(new string[] { @"/" }, StringSplitOptions.RemoveEmptyEntries);
                //第一段暂时可以
                //第二段对应不用的business
                var type = EFCoreDataProviderExtension.AllTypes.FirstOrDefault(p => p.Name == $"I{paras[1]}Business");
                if (type == null)
                    return new AjaxResult<T>() { Msg = "暂不支持", Success = false };

                //获取接口
                var business = ContainerLocator.Current.Resolve(type);
                if (business == null)
                    return new AjaxResult<T>() { Msg = "暂不支持", Success = false };

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
                    return new AjaxResult<T>() { Data = pageResult.Data, Total = pageResult.Total, Success = true };
                }
                else if (response is T result) //直接解析数据
                {
                    return new AjaxResult<T>() { Data = result, Success = true};
                }
                else//解析数据（强制转换）
                {
                    return new AjaxResult<T>() { Data = response.ChangeType<T>(), Success = true };
                }

            }
            catch (Exception ex)
            {
                return new AjaxResult<T>() { Msg = ex.ToString(), Success = false };
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
