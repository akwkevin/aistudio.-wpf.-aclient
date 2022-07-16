using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIStudio.Wpf.ProtobufApi.Models
{
    [ProtoContract]
    public class Delete_Protobuf
    {
        [ProtoMember(1)] 
        public List<string> ids { get; set; }
    }
}
