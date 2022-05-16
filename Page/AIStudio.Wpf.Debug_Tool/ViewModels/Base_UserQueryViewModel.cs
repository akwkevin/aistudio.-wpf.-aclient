

using AIStudio.Wpf.Debug_Tool.Models;

namespace AIStudio.Wpf.Debug_Tool.ViewModels
{
    class Base_UserQueryViewModel: CommonQueryViewModel<Base_UserDTO, Base_UserDTO>
    {
        public Base_UserQueryViewModel() : base("Base_Manage")
        {

        }
    }
}
