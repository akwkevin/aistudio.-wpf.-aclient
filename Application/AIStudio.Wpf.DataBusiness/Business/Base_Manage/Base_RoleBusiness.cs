using AIStudio.Core;
using AIStudio.Wpf.DataBusiness.AOP;
using AIStudio.Wpf.EFCore.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Coldairarrow.Util;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AIStudio.Wpf.DataBusiness.Base_Manage
{
    public class Base_RoleBusiness : BaseBusiness<Base_Role>, IBase_RoleBusiness, ITransientDependency
    {
        readonly IMapper _mapper;
        public Base_RoleBusiness(IMapper mapper)
        {
            _mapper = mapper;
        }

        protected override string _textField => "RoleName";

        #region 外部接口

        public async Task<PageResult<Base_RoleInfoDTO>> GetDataListAsync(PageInput<RolesInputDTO> input)
        {
            var where = LinqHelper.True<Base_Role>();
            var search = input.Search;
            if (!search.roleId.IsNullOrEmpty())
                where = where.And(x => x.Id == search.roleId);
            if (!search.roleName.IsNullOrEmpty())
                where = where.And(x => x.RoleName.Contains(search.roleName));

            var page = await GetIQueryable()
                .Where(where)
                .ProjectTo<Base_RoleInfoDTO>(_mapper.ConfigurationProvider)
                .GetPageResultAsync(input);

            await SetProperty(page.Data);

            return page;

            async Task SetProperty(List<Base_RoleInfoDTO> _list)
            {
                var allActionIds = await Service.GetIQueryable<Base_Action>().Select(x => x.Id).ToListAsync();

                var ids = _list.Select(x => x.Id).ToList();
                var roleActions = await Service.GetIQueryable<Base_RoleAction>()
                    .Where(x => ids.Contains(x.RoleId))
                    .ToListAsync();
                _list.ForEach(aData =>
                {
                    if (aData.RoleName == RoleTypes.超级管理员.ToString())
                        aData.Actions = allActionIds;
                    else
                        aData.Actions = roleActions.Where(x => x.RoleId == aData.Id).Select(x => x.ActionId).ToList();
                });
            }
        }

        public async Task<Base_RoleInfoDTO> GetTheDataAsync(IdInputDTO input)
        {
            return (await GetDataListAsync(new PageInput<RolesInputDTO> { Search = new RolesInputDTO { roleId = input.id } })).Data.FirstOrDefault();
        }


        public async Task AddDataAsync(Base_RoleInfoDTO input)
        {
            await InsertAsync(_mapper.Map<Base_Role>(input));
            await SetRoleActionAsync(input.Id, input.Actions);
        }


        public async Task UpdateDataAsync(Base_RoleInfoDTO input)
        {
            await UpdateAsync(_mapper.Map<Base_Role>(input));
            await SetRoleActionAsync(input.Id, input.Actions);
        }

        [DataDeleteLog(UserLogType.系统角色管理, "RoleName", "角色", Order = 1)]
        [Transactional(Order = 2)]
        public async Task DeleteDataAsync(List<string> ids)
        {
            await DeleteAsync(ids);
            await Service.DeleteAsync<Base_RoleAction>(x => ids.Contains(x.RoleId));
        }

        #endregion

        #region 私有成员

        private async Task SetRoleActionAsync(string roleId, List<string> actions)
        {
            var roleActions = (actions ?? new List<string>())
                .Select(x => new Base_RoleAction
                {
                    Id = IdHelper.GetId(),
                    ActionId = x,
                    CreateTime = DateTime.Now,
                    RoleId = roleId
                }).ToList();
            await Service.DeleteAsync<Base_RoleAction>(x => x.RoleId == roleId);
            await Service.InsertAsync(roleActions);
        }

        #endregion

        #region 数据模型

        #endregion

        [DataSaveLog(UserLogType.系统角色管理, "RoleName", "角色", Order = 1)]
        [DataRepeatValidate(new string[] { "RoleName" }, new string[] { "角色名" }, Order = 2)]
        [Transactional(Order = 3)]
        public async Task SaveDataAsync(Base_RoleInfoDTO input)
        {
            if (input.Id.IsNullOrEmpty())
            {
                InitEntity(input);

                await AddDataAsync(input);
            }
            else
            {
                UpdateEntity(input);

                await UpdateDataAsync(input);
            }
        }
    }
}