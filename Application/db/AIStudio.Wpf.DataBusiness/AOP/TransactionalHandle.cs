using AIStudio.AOP;
using AIStudio.Core;
using AIStudio.Wpf.DataRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Interception.PolicyInjection.Pipeline;
using Unity.Interception.PolicyInjection.Policies;

namespace AIStudio.Wpf.DataBusiness.AOP
{
    public class TransactionalHandle : BaseAOPHandler
    {
        private readonly IsolationLevel _isolationLevel;
        public TransactionalHandle(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            _isolationLevel = isolationLevel;
        }

        public override void Befor(IMethodInvocation input)
        {
            var repository = input.Target.GetPropertyValue("Service") as IDbAccessor;
            repository.BeginTransaction(_isolationLevel);
        }

        public override void After(IMethodInvocation input, IMethodReturn result)
        {
            var repository = input.Target.GetPropertyValue("Service") as IDbAccessor;
            if (result.Exception == null)
            {      
                try
                {
                    repository.CommitTransaction();
                }
                catch (Exception ex)
                {
                    repository.RollbackTransaction();
                    throw new Exception("系统异常", ex);
                }
            }
            else
            {
                repository.RollbackTransaction();
            }
            
        }

    }

    public class TransactionalAttribute : HandlerAttribute
    {
        private readonly IsolationLevel _isolationLevel;

        public TransactionalAttribute(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            _isolationLevel = isolationLevel;
        }

        public override ICallHandler CreateHandler(IUnityContainer container)
        {
            return new TransactionalHandle(_isolationLevel) { Order = this.Order };
        }
    }

}
