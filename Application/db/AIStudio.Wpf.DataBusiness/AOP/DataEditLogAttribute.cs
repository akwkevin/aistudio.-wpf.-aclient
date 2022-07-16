using AIStudio.AOP;
using AIStudio.Core;
using AIStudio.Wpf.DataBusiness.Base_Manage;
using Microsoft.Extensions.DependencyInjection;
using Prism.Ioc;
using System.Threading.Tasks;

namespace AIStudio.Wpf.DataBusiness.AOP
{
    public class DataEditLogAttribute : WriteDataLogAttribute
    {
        public DataEditLogAttribute(UserLogType logType, string nameField, string dataName)
            : base(logType, nameField, dataName)
        {
        }

        public override async Task After(IAOPContext context)
        {
            var log = ContainerLocator.Current.Resolve<IBase_UserLogBusiness>();
            var obj = context.Arguments[0];
            await log.WriteUserLog(_logType, $"修改{_dataName}:{obj.GetPropertyValue(_nameField)?.ToString()}");
        }
    }
}
