using AIStudio.Core.Models;
using AIStudio.Wpf.Agile_Development.Attributes;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIStudio.Wpf.Agile_Development.Models
{
    public class Protobuf_UserDTO_Query
    {
        [ColumnHeader("姓名", IsPin = true)]
        public string UserName { get; set; }
    }

    [ProtoContract]
    public class Protobuf_UserDTO : Prism.Mvvm.BindableBase, IIsChecked
    {
        private bool _isChecked;
        [ProtoIgnore]
        public bool IsChecked
        {
            get { return _isChecked; }
            set
            {
                SetProperty(ref _isChecked, value);
            }
        }

        [ProtoMember(1)]
        public string Id { get; set; }

        [ProtoMember(2)]
        public bool Deleted { get; set; }

        [ProtoMember(3)]
        public string UserName { get; set; }

        [ProtoMember(4)]
        public string RealName { get; set; }

        [ProtoMember(5)]
        public string Password { get; set; }

        [ProtoMember(6)]
        public int Sex { get; set; }

        [ProtoMember(7)]
        public DateTime? Birthday { get; set; }

        [ProtoMember(8)]
        public string DepartmentId { get; set; }

        [ProtoMember(9)]
        public string PhoneNumber { get; set; }

        [ProtoMember(10)]
        public DateTime CreateTime { get; set; }

        [ProtoMember(11)]
        public DateTime? ModifyTime { get; set; }

        [ProtoMember(12)]
        public string CreatorId { get; set; }

        [ProtoMember(13)]
        public string CreatorName { get; set; }

        [ProtoMember(14)]
        public string ModifyId { get; set; }

        [ProtoMember(15)]
        public string ModifyName { get; set; }

        [ProtoIgnore]
        public string Error { get; set; }

    }
}