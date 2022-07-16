using AIStudio.Wpf.Agile_Development.Commons;
using AIStudio.Wpf.Protobuf_Test.Models;
using System.Collections.Generic;

namespace AIStudio.Wpf.Protobuf_Test.ViewModels
{
    class Protobuf_UserQueryEditViewModel : Protobuf_QueryEditViewModel<Protobuf_UserDTO>
    {
        public Protobuf_UserQueryEditViewModel(IEnumerable<EditFormItem> editFormItems, Protobuf_UserDTO data, string area, string identifier, string title = "编辑表单") : base(editFormItems, data, area, identifier, title)
        {

        }
    }
}
