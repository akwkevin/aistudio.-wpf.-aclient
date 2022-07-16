using System.Diagnostics;
using System.Threading.Tasks;

namespace AIStudio.AOP
{
    public class TestHandler : BaseAOPAttribute
    {
        public override async Task Befor(IAOPContext context)
        {
            Debug.WriteLine("-------------Method Excute Befored-------------");
            if (context.Arguments.Length > 0)
            {
                for (int i = 0; i < context.Arguments.Length; i++)
                {
                    Debug.WriteLine($"Arguments:{context.Arguments[i]}");
                }
            }

            await Task.CompletedTask;
        }

        public override async Task After(IAOPContext context)
        {
            Debug.WriteLine("-------------Method Excute After-------------");
            if (context.Result != null)
            {
                Debug.WriteLine($"ReturnValue:{context.Result}");
            }

            await Task.CompletedTask;
        }
    }

}
