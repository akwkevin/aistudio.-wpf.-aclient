using AIStudio.AOP;
using AIStudio.Core;
using AIStudio.Wpf.Business;
using AIStudio.Wpf.DataBusiness.Base_Manage;
using Microsoft.Extensions.DependencyInjection;
using Prism.Ioc;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace AIStudio.Wpf.DataBusiness.AOP
{
    public class DataSaveLogAttribute : WriteDataLogAttribute
    {
        public DataSaveLogAttribute(UserLogType logType, string nameField, string dataName)
            : base(logType, nameField, dataName)
        {
        }

        bool _isNew;
        public override async Task Befor(IAOPContext context)
        {
            var obj = context.Arguments[0];
            _isNew = string.IsNullOrEmpty(obj.GetPropertyValue("Id")?.ToString());

            await Task.CompletedTask;
        }
        public override async Task After(IAOPContext context)
        {
            var log = ContainerLocator.Current.Resolve<IBase_UserLogBusiness>();
            var obj = context.Arguments[0];
            await log.WriteUserLog(_logType, $"{(_isNew ? "添加" : "修改")}{_dataName}:{obj.GetPropertyValue(_nameField)?.ToString()}");
        }
    }
}
