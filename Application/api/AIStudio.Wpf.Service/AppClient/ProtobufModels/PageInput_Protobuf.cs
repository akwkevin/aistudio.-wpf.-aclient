using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIStudio.Wpf.Service.AppClient.ProtobufModels
{
    [ProtoContract]
    public class PageInput_Protobuf
    {
        /// <summary>
        /// 当前页码
        /// </summary>
        [ProtoMember(1)]
        public int PageIndex { get; set; } = 1;

        /// <summary>
        /// 每页行数
        /// </summary>
        [ProtoMember(2)]
        public int PageRows { get; set; } = int.MaxValue;

        /// <summary>
        /// 排序列
        /// </summary>
        [ProtoMember(3)]
        public string SortField { get; set; } = "Id";

        /// <summary>
        /// 排序类型
        /// </summary>
        [ProtoMember(4)]
        public string SortType { get; set; } = "asc";

        [ProtoMember(5)]
        public Search_Protobuf Search { get; set; }

        [ProtoMember(6)]
        public Dictionary<string, string> SearchKeyValues { get; set; }
    }
}
