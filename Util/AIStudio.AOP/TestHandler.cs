using System.Diagnostics;
using System.Threading.Tasks;

namespace AIStudio.AOP
{
    public class TestHandler : BaseAOPAttribute
    {
        public override async Task Befor(IAOPContext context)
        {
            Debug.WriteLine("-------------Method Excute Befored-------------");
            //Debug.WriteLine($"Method Name:{context.Arguments[0]}");
            //if (context.Arguments.Length > 0)
            //{
            //    Debug.WriteLine("Arguments:");
            //    for (int i = 0; i < context.Arguments.Length; i++)
            //    {
            //        Debug.WriteLine($"parameterName:{context.Arguments[i]},parameterValue:{context.Arguments[i]}");
            //    }
            //}

            await Task.CompletedTask;
        }

        public override async Task After(IAOPContext context)
        {
            Debug.WriteLine("-------------Method Excute After-------------");
            //if (context. != null)
            //{
            //    Debug.WriteLine($"Exception:{result.Exception.Message} \n");
            //}
            //else
            //{
            //    Debug.WriteLine($"Excuted Successed \n");
            //}

            await Task.CompletedTask;
        }
    }

}
