using AIStudio.Core;
using AIStudio.Wpf.Business;
using AIStudio.Wpf.DataBusiness.AOP;
using AIStudio.Wpf.EFCore.DTOModels;
using AIStudio.Wpf.EFCore.Models;
using AutoMapper;
using Coldairarrow.Util;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AIStudio.Wpf.DataBusiness.Base_Manage
{
    public class Base_UserBusiness : BaseBusiness<Base_User>, IBase_UserBusiness, ITransientDependency
    {
        readonly IOperator _operator;
        readonly IMapper _mapper;
        readonly IBase_DepartmentBusiness _departmentBusiness;
        public Base_UserBusiness(
            IOperator @operator,
            IMapper mapper,
            IBase_DepartmentBusiness departmentBusiness
            )
        {
            _operator = @operator;
            _mapper = mapper;
            _departmentBusiness = departmentBusiness;
        }
        protected override string _textField => "UserName";

        #region 外部接口

        public async Task<PageResult<Base_UserDTO>> GetDataListAsync(PageInput<Base_UsersInputDTO> input)
        {
            Expression<Func<Base_User, Base_Department, Base_UserDTO>> select = (a, b) => new Base_UserDTO
            {
                DepartmentName = b.Name
            };
            var search = input.Search;
            select = select.BuildExtendSelectExpre();
            var q_User = search.all ? Service.GetIQueryable<Base_User>() : GetIQueryable();
            var q = from a in q_User.AsExpandable()
                    join b in Service.GetIQueryable<Base_Department>() on a.DepartmentId equals b.Id into ab
                    from b in ab.DefaultIfEmpty()
                    select @select.Invoke(a, b);

            q = q.WhereIf(!search.userId.IsNullOrEmpty(), x => x.Id == search.userId);
            if (!search.keyword.IsNullOrEmpty())
            {
                var keyword = $"%{search.keyword}%";
                q = q.Where(x =>
                      EF.Functions.Like(x.UserName, keyword)
                      || EF.Functions.Like(x.RealName, keyword));
            }

            var list = await q.GetPageResultAsync(input);

            await SetProperty(list.Data);

            return list;

            async Task SetProperty(List<Base_UserDTO> users)
            {
                //补充用户角色属性
                List<string> userIds = users.Select(x => x.Id).ToList();
                var userRoles = await (from a in Service.GetIQueryable<Base_UserRole>()
                                       join b in Service.GetIQueryable<Base_Role>() on a.RoleId equals b.Id
                                       where userIds.Contains(a.UserId)
                                       select new
                                       {
                                           a.UserId,
                                           RoleId = b.Id,
                                           b.RoleName
                                       }).ToListAsync();
                users.ForEach(aUser =>
                {
                    var roleList = userRoles.Where(x => x.UserId == aUser.Id);
                    aUser.RoleIdList = roleList.Select(x => x.RoleId).ToList();
                    aUser.RoleNameList = roleList.Select(x => x.RoleName).ToList();
                });
            }
        }


        public async Task<object> GetDataListByDepartmentAsync(IdInputDTO input)
        {
            var departments = await _departmentBusiness.GetIQueryable().Where(p => p.ParentIds.Contains(input.id)).Select(p => p.Id).ToListAsync();
            departments.Add(input.id);

            List<Base_User> users = new List<Base_User>();
            foreach (var department in departments)
            {
                users.AddRange(await GetIQueryable().Where(p => p.DepartmentId == department).ToListAsync());
            }
            return users;
        }

        public async Task<Base_UserDTO> GetTheDataAsync(IdInputDTO input)
        {
            if (input.id.IsNullOrEmpty())
                return null;
            else
            {
                PageInput<Base_UsersInputDTO> pageinput = new PageInput<Base_UsersInputDTO>
                {
                    Search = new Base_UsersInputDTO
                    {
                        all = true,
                        userId = input.id
                    }
                };
                return (await GetDataListAsync(pageinput)).Data.FirstOrDefault();
            }
        }


        public async Task AddDataAsync(UserEditInputDTO input)
        {
            await InsertAsync(_mapper.Map<Base_User>(input));
            await SetUserRoleAsync(input.Id, input.RoleIdList);
        }


        public async Task UpdateDataAsync(UserEditInputDTO input)
        {
            if (input.Id == GlobalData.ADMINID && _operator?.UserId != input.Id)
                throw new BusException("禁止更改超级管理员！");

            await UpdateAsync(_mapper.Map<Base_User>(input));
            await SetUserRoleAsync(input.Id, input.RoleIdList);
        }

        [DataDeleteLog(UserLogType.系统用户管理, "UserName", "用户", Order =1)]
        [Transactional(Order = 2)]
        public async Task DeleteDataAsync(List<string> ids)
        {
            if (ids.Contains(GlobalData.ADMINID))
                throw new BusException("超级管理员是内置账号,禁止删除！");

            await DeleteAsync(ids);
        }

        #endregion

        #region 私有成员

        public async Task SetUserRoleAsync(string userId, List<string> roleIds)
        {
            roleIds = roleIds ?? new List<string>();
            var userRoleList = roleIds.Select(x => new Base_UserRole
            {
                Id = IdHelper.GetId(),
                CreateTime = DateTime.Now,
                UserId = userId,
                RoleId = x
            }).ToList();
            await Service.DeleteAsync<Base_UserRole>(x => x.UserId == userId);
            await Service.InsertAsync(userRoleList);
        }

        #endregion

        public async Task<string> GetAvatar(string userId)
        {
            if (string.IsNullOrEmpty(userId))
                return null;

            var user = await GetEntityAsync(userId);

            return user?.Avatar;
        }

        [DataSaveLog(UserLogType.系统用户管理, "UserName", "用户", Order = 1)]
        [DataRepeatValidate( new string[] { "UserName" }, new string[] { "用户名" }, Order = 2)]
        [Transactional(Order = 3)]
        public async Task SaveDataAsync(UserEditInputDTO input)
        {
            if (!input.newPwd.IsNullOrEmpty())
                input.Password = input.newPwd.ToMD5String();
            if (input.Id.IsNullOrEmpty())
            {
                InitEntity(input);

                await AddDataAsync(input);
            }
            else
            {
                await UpdateDataAsync(input);
            }
        }
    }
}