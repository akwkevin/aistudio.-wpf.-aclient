using AIStudio.AOP;
using AIStudio.Core;
using AIStudio.Wpf.Business;
using AIStudio.Wpf.DataBusiness.Base_Manage;
using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Interception.PolicyInjection.Pipeline;
using Unity.Interception.PolicyInjection.Policies;

namespace AIStudio.Wpf.DataBusiness.AOP
{
    public class DataSaveLogHandle : WriteDataLogHandle
    {
        public DataSaveLogHandle(UserLogType logType, string nameField, string dataName)
            : base(logType, nameField, dataName)
        {
        }

        bool _isNew;

        public override void Befor(IMethodInvocation input)
        {
            var obj = input.Arguments[0];
            _isNew = string.IsNullOrEmpty(obj.GetPropertyValue("Id")?.ToString());
        }

        public override void After(IMethodInvocation input, IMethodReturn result)
        {
            if (result.Exception == null)
            {
                var log = ContainerLocator.Current.Resolve<IBase_UserLogBusiness>();
                var obj = input.Arguments[0];
                log.WriteUserLog(_logType, $"{(_isNew ? "添加":"修改")}{_dataName}:{obj.GetPropertyValue(_nameField)?.ToString()}").Wait();
            }
        }
    }

    public class DataSaveLogAttribute : HandlerAttribute
    {
        protected UserLogType _logType { get; }
        protected string _dataName { get; }
        protected string _nameField { get; }

        public DataSaveLogAttribute(UserLogType logType, string nameField, string dataName)
        {
            _logType = logType;
            _dataName = dataName;
            _nameField = nameField;
        }

        public override ICallHandler CreateHandler(IUnityContainer container)
        {
            return new DataSaveLogHandle(_logType, _nameField, _dataName) { Order = this.Order };
        }
    }
}
