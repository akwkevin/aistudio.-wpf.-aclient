using AIStudio.AOP;
using AIStudio.Core;
using AIStudio.Wpf.Business;
using AIStudio.Wpf.DataBusiness.Base_Manage;
using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Interception.PolicyInjection.Pipeline;
using Unity.Interception.PolicyInjection.Policies;

namespace AIStudio.Wpf.DataBusiness.AOP
{
    public class DataDeleteLogHandle : WriteDataLogHandle
    {
        public DataDeleteLogHandle(UserLogType logType, string nameField, string dataName)
            : base(logType, nameField, dataName)
        {
        }


        private string _names;
        public override void Befor(IMethodInvocation input)
        {
            List<string> ids = input.Arguments[0] as List<string>;
            var q = input.Target.GetType().GetMethod("GetIQueryable").Invoke(input.Target, new object[] { false }) as IQueryable;
            var deleteList = q.Where("@0.Contains(Id)", ids).CastToList<object>();

            _names = string.Join(",", deleteList.Select(x => x.GetPropertyValue(_nameField)?.ToString()));
        }

        public override void After(IMethodInvocation input, IMethodReturn result)
        {
            if (result.Exception == null)
            {
                var log = ContainerLocator.Current.Resolve<IBase_UserLogBusiness>();
                log.WriteUserLog(_logType, $"删除{_dataName}:{_names}").Wait();
            }
        }
    }

    public class DataDeleteLogAttribute : HandlerAttribute
    {
        protected UserLogType _logType { get; }
        protected string _dataName { get; }
        protected string _nameField { get; }

        public DataDeleteLogAttribute(UserLogType logType, string nameField, string dataName)
        {
            _logType = logType;
            _dataName = dataName;
            _nameField = nameField;
        }

        public override ICallHandler CreateHandler(IUnityContainer container)
        {
            return new DataDeleteLogHandle(_logType, _nameField, _dataName) { Order = this.Order };
        }
    }
}
