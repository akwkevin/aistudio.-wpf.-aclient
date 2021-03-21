using AIStudio.Core;
using AIStudio.Wpf.Service.AppClient;
using System;

namespace AIStudio.Wpf.Business
{
    public interface IWSocketClient:IDisposable
    {
        void InitAndStart(string serverip, string url);

        event Action<WSMessageType, string> MessageReceived;
        void SendMessage(string Message);
    }
}
