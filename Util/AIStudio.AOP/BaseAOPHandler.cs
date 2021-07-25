using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Unity.Interception.PolicyInjection.Pipeline;
using Unity.Interception.PolicyInjection.Policies;


namespace AIStudio.AOP
{
    /// <summary>
    /// AOP基类
    /// 注:不支持控制器,需要定义接口并实现接口,自定义AOP特性放到接口实现类上
    /// </summary>
    public abstract class BaseAOPHandler : ICallHandler
    {
        public int Order { get; set; }

        public virtual void Befor(IMethodInvocation input)
        {
           
        }

        public virtual void After(IMethodInvocation input, IMethodReturn result)
        {
           
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            Befor(input);
            var methodReturn = getNext()(input, getNext);
            After(input, methodReturn);

            return methodReturn;
        }
    }
}
