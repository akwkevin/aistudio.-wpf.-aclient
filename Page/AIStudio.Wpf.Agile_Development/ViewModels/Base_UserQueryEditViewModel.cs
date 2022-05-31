using AIStudio.Wpf.Agile_Development.Commons;
using AIStudio.Wpf.Agile_Development.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIStudio.Wpf.Agile_Development.ViewModels
{
    class Base_UserQueryEditViewModel : Common_QueryEditViewModel<Base_UserDTO>
    {
        public Base_UserQueryEditViewModel(IEnumerable<EditFormItem> editFormItems, Base_UserDTO data, string area, string identifier, string title = "编辑表单") : base(editFormItems, data, area, identifier, title)
        {

        }
    }
}
