using Newtonsoft.Json;
using ProtoBuf;
using System;
using System.Collections.Generic;

namespace AIStudio.Wpf.Service.AppClient.ProtobufModels
{
    /// <summary>
    /// 分页返回结果
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [ProtoContract]
    public class AjaxResult_Protobuf 
    {   /// <summary>
        /// 是否成功
        /// </summary>
        [ProtoMember(1)]
        public bool Success { get; set; }

        /// <summary>
        /// 错误代码
        /// </summary>
        [ProtoMember(2)]
        public int ErrorCode { get; set; }

        /// <summary>
        /// 返回消息
        /// </summary>
        [ProtoMember(3)]
        public string Msg { get; set; }

        [ProtoMember(4)]
        [JsonIgnore]
        public byte[] Data { get; set; }
        /// <summary>
        /// 总记录数
        /// </summary>
        [ProtoMember(5)]
        public int Total { get; set; }
    }
}
