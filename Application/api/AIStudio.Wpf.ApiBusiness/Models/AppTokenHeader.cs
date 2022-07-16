using AIStudio.Wpf.Business;
using System.Collections.Generic;

namespace AIStudio.Wpf.ApiBusiness
{
    public class AppTokenHeader : IAppHeader
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }

        public AppTokenHeader(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

        public Dictionary<string, string> GetHeader()
        {
            Dictionary<string, string> header = new Dictionary<string, string>();
            header.Add("Authorization", string.Format("Bearer {0}", Token));        

            return header;
        }
    }
}
