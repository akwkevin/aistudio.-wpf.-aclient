using AIStudio.Wpf.Service.AppClient.Models;

namespace AIStudio.Wpf.Service.AppClient
{
    /// <summary>
    /// Ajax请求结果
    /// </summary>
    public class AjaxResult
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// 错误代码
        /// </summary>
        public int ErrorCode { get; set; }

        /// <summary>
        /// 返回消息
        /// </summary>
        public string Msg { get; set; }

        /// <summary>
        /// 返回数据
        /// </summary>
        public object Data { get; set; }

        public int Total { get; set; }
    }

    public class MessageResult : AjaxResult
    {
        /// <summary>
        /// 类型
        /// </summary>
        public WSMessageType MessageType { get; set; }

    }

    public class UploadResult
    {
        public string name { get; set; }
        public string status { get; set; }
        public string thumbUrl { get; set; }
        public string url { get; set; }
        public int uploaded { get; set; }
    } 

    public enum WSMessageType
    {
        Success,
        Error,
        MessageType,
        EmailType,
        UserFormType,
        PushType,
        ReadMessageType,
        PingType
    }
}
