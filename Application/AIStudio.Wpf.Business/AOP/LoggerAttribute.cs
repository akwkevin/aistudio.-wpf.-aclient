using AIStudio.AOP;
using AIStudio.Core;
using AIStudio.Wpf.Business;
using Newtonsoft.Json;
using Prism.Ioc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AIStudio.Wpf.DataBusiness.AOP
{
    public class LoggerAttribute : BaseAOPAttribute
    {
        DateTime _startTime;
        public override async Task Befor(IAOPContext context)
        {
            _startTime = DateTime.Now;
            await Task.CompletedTask;
        }

        public override async Task After(IAOPContext context)
        {
            var logger = ContainerLocator.Current.Resolve<ILogger>();
            string log = string.Empty;
            var time = DateTime.Now - _startTime;

            string strRes = string.Empty;

            if (context.Result is string str)
            {
                strRes = str;
            }
            else if (context.Result != null)
            {
                try
                {
                    strRes = JsonConvert.SerializeObject(context.Result);
                }
                catch
                {
                    strRes = context.Result?.ToString();
                }
            }

            if (strRes?.Length > 1000)
            {
                strRes = new string(strRes.Copy(0, 1000).ToArray());
                strRes += "......";
            }

            log =
$@"请求方法：{context.TargetType.FullName}.{context.Method.Name}
参数:{string.Join(" ", context.Arguments)}
耗时:{(int)time.TotalMilliseconds}ms
返回:{strRes}";

            logger.Info(LogType.系统跟踪, log);

            await Task.CompletedTask;
        }
    }
}
