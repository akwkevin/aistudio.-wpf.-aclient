using AIStudio.Wpf.Agile_Development.Commons;
using AIStudio.Wpf.Agile_Development.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIStudio.Wpf.Agile_Development.ViewModels
{
    class Protobuf_UserQueryEditViewModel : Protobuf_QueryEditViewModel<Protobuf_UserDTO>
    {
        public Protobuf_UserQueryEditViewModel(IEnumerable<EditFormItem> editFormItems, Protobuf_UserDTO data, string area, string identifier, string title = "编辑表单") : base(editFormItems, data, area, identifier, title)
        {

        }
    }
}
