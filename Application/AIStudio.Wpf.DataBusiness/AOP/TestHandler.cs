using AIStudio.AOP;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Unity;
using Unity.Interception.PolicyInjection.Pipeline;
using Unity.Interception.PolicyInjection.Policies;

namespace AIStudio.Wpf.DataBusiness.AOP
{
    public class TestHandler : BaseAOPHandler
    {
        public override void Befor(IMethodInvocation input)
        {
            Debug.WriteLine("-------------Method Excute Befored-------------");
            Debug.WriteLine($"Method Name:{input.MethodBase.Name}");
            if (input.Arguments.Count > 0)
            {
                Debug.WriteLine("Arguments:");
                for (int i = 0; i < input.Arguments.Count; i++)
                {
                    Debug.WriteLine($"parameterName:{input.Arguments.ParameterName(i)},parameterValue:{input.Arguments[i]}");
                }
            }
        }

        public override void After(IMethodInvocation input, IMethodReturn result)
        {
            Debug.WriteLine("-------------Method Excute After-------------");
            if (result.Exception != null)
            {
                Debug.WriteLine($"Exception:{result.Exception.Message} \n");
            }
            else
            {
                Debug.WriteLine($"Excuted Successed \n");
            }
        }
    }


    public class TestHandlerAttribute : HandlerAttribute
    {
        public override ICallHandler CreateHandler(IUnityContainer container)
        {
            return new TestHandler() { Order = this.Order };
        }
    }
}
