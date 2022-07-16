using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIStudio.Wpf.ProtobufApi.Models
{
    [ProtoContract]
    public class Search_Protobuf
    {
        [ProtoMember(1)]
        public string keyword { get; set; }
        [ProtoMember(2)]
        public string condition { get; set; }
    }
}
