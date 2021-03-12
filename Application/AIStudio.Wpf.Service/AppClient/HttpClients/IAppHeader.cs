using System.Collections.Generic;

namespace AIStudio.Wpf.Service.AppClient.HttpClients
{
    public interface IAppHeader
    {
        Dictionary<string, string> SetHeader();
    }
}
