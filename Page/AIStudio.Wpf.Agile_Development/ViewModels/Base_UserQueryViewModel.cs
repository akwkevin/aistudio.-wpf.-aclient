using AIStudio.Wpf.Agile_Development.Commons;
using AIStudio.Wpf.Agile_Development.Models;
using AIStudio.Wpf.Agile_Development.Views;

namespace AIStudio.Wpf.Agile_Development.ViewModels
{
    class Base_UserQueryViewModel: Common_QueryViewModel<Base_UserDTO, Base_UserDTO_Query>
    {
        public Base_UserQueryViewModel()
        {
            Area = "Base_Manage";
        }

    }
}
