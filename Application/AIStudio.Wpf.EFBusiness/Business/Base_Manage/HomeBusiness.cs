using AIStudio.Core;
using AIStudio.Wpf.Business;
using AIStudio.Wpf.EFBusiness.Cache;
using AIStudio.Wpf.EFCore.Models;
using AutoMapper;
using EFCore.Sharding;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AIStudio.Wpf.EFBusiness.Base_Manage
{
    public class HomeBusiness : BaseBusiness<Base_User>, IHomeBusiness, ITransientDependency
    {
        readonly IOperator _operator;
        readonly IMapper _mapper;
        private readonly IBase_UserCache _base_UserCache;
        public HomeBusiness(IOperator @operator, IMapper mapper, IBase_UserCache base_UserCache)
        {
            _operator = @operator;
            _mapper = mapper;
            _base_UserCache = base_UserCache;
        }

        public async Task<string> SubmitLoginAsync(LoginInputDTO input)
        {
            var password = input.password;
            input.password = input.password.ToMD5String();
            var theUser = await GetIQueryable()
                .Where(x => x.UserName == input.userName && (x.Password == input.password || x.Password == password))
                .FirstOrDefaultAsync();

            if (theUser.IsNullOrEmpty())
                throw new BusException("账号或密码不正确！");

            return theUser.Id;
        }

        public async Task ChangePwdAsync(ChangePwdInputDTO input)
        {
            var theUser = _operator.Property;
            if (theUser.Password != input.oldPwd?.ToMD5String())
                throw new BusException("原密码错误!");

            theUser.Password = input.newPwd.ToMD5String();
            await UpdateAsync(_mapper.Map<Base_User>(theUser));

            //更新缓存
            await _base_UserCache.UpdateCacheAsync(theUser.Id);
        }
    }
}
