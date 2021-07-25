using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using AIStudio.Core;

namespace AIStudio.Wpf.Service.AppClient.HttpClients
{
    public class AppSecretHeader: IAppHeader
    {
        public string AppId { get; set; }
        public string AppSecret { get; set; }
        public string Body { get; set; } = "";

        public AppSecretHeader(string appId, string appSecret)
        {
            AppId = appId;
            AppSecret = appSecret;
        }

        public Dictionary<string, string> SetHeader()
        {
            Dictionary<string, string> header = new Dictionary<string, string>();
            string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string guid = Guid.NewGuid().ToString();
            header.Add("appId", AppId);
            header.Add("time", time);
            header.Add("guid", guid);
            string sign = BuildApiSign(AppId, AppSecret, guid, Convert.ToDateTime(time), Body);
            header.Add("sign", sign);

            return header;
        }

        /// <summary>
        /// 生成接口签名sign
        /// 注：md5(appId+time+guid+body+appSecret)
        /// </summary>
        /// <param name="appId">应用Id</param>
        /// <param name="appSecret">应用密钥</param>
        /// <param name="guid">唯一GUID</param>
        /// <param name="time">时间</param>
        /// <param name="body">请求体</param>
        /// <returns></returns>
        public static string BuildApiSign(string appId, string appSecret, string guid, DateTime time, string body)
        {
            return $"{appId}{time.ToString("yyyy-MM-dd HH:mm:ss")}{guid}{body}{appSecret}".ToMD5String();
        }

    }

    
}
