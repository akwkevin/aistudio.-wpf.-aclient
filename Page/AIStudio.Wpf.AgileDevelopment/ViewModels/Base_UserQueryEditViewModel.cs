using AIStudio.Wpf.AgileDevelopment.Commons;
using AIStudio.Wpf.AgileDevelopment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIStudio.Wpf.AgileDevelopment.ViewModels
{
    class Base_UserQueryEditViewModel : CommonEditViewModel<Base_UserDTO>
    {
        public Base_UserQueryEditViewModel(IEnumerable<EditFormItem> editFormItems, Base_UserDTO data, string area, string identifier, string title = "编辑表单") : base(editFormItems, data, area, identifier, title)
        {

        }
    }
}
