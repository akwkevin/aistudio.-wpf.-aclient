using AIStudio.Core;
using AIStudio.Wpf.Business;
using AIStudio.Wpf.EFCore.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AIStudio.Wpf.DataBusiness.Base_Manage
{
    public class HomeBusiness : BaseBusiness<Base_User>, IHomeBusiness, ITransientDependency
    {
        readonly IOperator _operator;
        readonly IMapper _mapper;
        readonly IPermissionBusiness _permissionBus;
        readonly IBase_UserBusiness _userBus;

        public HomeBusiness(IOperator @operator, IMapper mapper, IPermissionBusiness permissionBus, IBase_UserBusiness userBus)
        {
            _operator = @operator;
            _mapper = mapper;
            _permissionBus = permissionBus;
            _userBus = userBus;
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

            _operator.Property = theUser;
            return theUser.Id;
        }

        public async Task ChangePwdAsync(ChangePwdInputDTO input)
        {
            var theUser = _operator.Property;
            if (theUser.Password != input.oldPwd?.ToMD5String())
                throw new BusException("原密码错误!");

            theUser.Password = input.newPwd.ToMD5String();
            await UpdateAsync(_mapper.Map<Base_User>(theUser));

        }
        public async Task<object> GetOperatorInfoAsync()
        {
            var theInfo = await _userBus.GetTheDataAsync(_operator.UserId);
            var permissions = await _permissionBus.GetUserPermissionValuesAsync(_operator.UserId);
            var resObj = new
            {
                UserInfo = theInfo,
                Permissions = permissions
            };

            return resObj;
        }

        public async Task<List<Base_ActionDTO>> GetOperatorMenuListAsync()
        {
            return await _permissionBus.GetUserMenuListAsync(_operator.UserId);
        }
    }
}
