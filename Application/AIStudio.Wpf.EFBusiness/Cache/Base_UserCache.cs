using AIStudio.Core;
using AIStudio.Wpf.EFBusiness.Base_Manage;
using AIStudio.Wpf.EFCore.DTOModels;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AIStudio.Wpf.EFBusiness.Cache
{
    public class Base_UserCache : BaseCache<Base_UserDTO>, IBase_UserCache, ITransientDependency
    {
        public Base_UserCache()
        {
        
        }

        protected override async Task<Base_UserDTO> GetDbDataAsync(string key)
        {
            PageInput<Base_UsersInputDTO> input = new PageInput<Base_UsersInputDTO>
            {
                Search = new Base_UsersInputDTO
                {
                    all = true,
                    userId = key
                }
            };
            var list = await EFCoreDataProviderExtension.ServiceProvider.GetService<IBase_UserBusiness>().GetDataListAsync(input);

            return list.Data.FirstOrDefault();
        }
    }
}
