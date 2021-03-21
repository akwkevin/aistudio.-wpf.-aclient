using AIStudio.Core;
using AIStudio.Wpf.EFCore.Models;
using EFCore.Sharding;

namespace AIStudio.Wpf.EFBusiness.Base_Manage
{
    public class Base_UserRoleBusiness : BaseBusiness<Base_UserRole>, IBase_UserRoleBusiness, ITransientDependency
    {
        public Base_UserRoleBusiness()
        {
        }
    }
}