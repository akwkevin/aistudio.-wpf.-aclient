using AIStudio.Wpf.Controls;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AIStudio.Wpf.BasePage.Models
{
    public class WaitFor : IDisposable
    {
        public string Identifier;
        public int HashCode;
        public int Counter;
        public static ConcurrentDictionary<int, WaitFor> WaitForList = new ConcurrentDictionary<int, WaitFor>();

        public static WaitFor GetWaitFor(int hashcode, string identifier, string text = "正在获取数据")
        {
            WaitFor waitFor;
            if (!WaitForList.TryGetValue(hashcode, out waitFor))
            {
                waitFor = new WaitFor(hashcode, identifier, text);
                WaitForList.TryAdd(hashcode, waitFor);
            }
            Interlocked.Increment(ref waitFor.Counter);
            return waitFor;
        }

        public WaitFor(int hashcode, string identifier, string text = "正在获取数据")
        {
            HashCode = hashcode;
            Identifier = identifier;
            WindowBase.ShowWaiting(WaitingStyle.Busy, Identifier, text);
        }

        public void Dispose()
        {
            if (Interlocked.Decrement(ref Counter) == 0)
            {
                WindowBase.HideWaiting(Identifier);
                WaitForList.TryRemove(HashCode, out var waitFor);
            }
        }
    }
}
