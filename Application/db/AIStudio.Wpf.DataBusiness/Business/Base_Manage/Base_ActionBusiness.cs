using AIStudio.Core;
using AIStudio.Wpf.DataBusiness.AOP;
using AIStudio.Wpf.Entity.Models;
using AutoMapper;
using Coldairarrow.Util;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AIStudio.Wpf.DataBusiness.Base_Manage
{
    public class Base_ActionBusiness : BaseBusiness<Base_Action>, IBase_ActionBusiness, ITransientDependency
    {
        readonly IMapper _mapper;
        public Base_ActionBusiness(IMapper mapper)
        {
            _mapper = mapper;
        }

        #region 外部接口

        public async Task<List<Base_Action>> GetDataListAsync(Base_ActionsInputDTO input)
        {
            var q = GetIQueryable();
            q = q
                .WhereIf(!input.parentId.IsNullOrEmpty(), x => x.ParentId == input.parentId)
                .WhereIf(input.types?.Length > 0, x => input.types.Contains((ActionType)x.Type))
                .WhereIf(input.ActionIds?.Length > 0, x => input.ActionIds.Contains(x.Id))
                ;

            return await q.OrderBy(x => x.Sort).ToListAsync();
        }

        public async Task<List<Base_ActionDTO>> GetTreeDataListAsync(Base_ActionsInputDTO input)
        {
            var qList = await GetDataListAsync(input);

            var treeList = qList.Select(x => new Base_ActionDTO
            {
                Id = x.Id,
                NeedAction = x.NeedAction,
                Text = x.Name,
                ParentId = x.ParentId,
                Type = (ActionType)x.Type,
                Url = x.Url,
                Value = x.Id,
                Icon = x.Icon,
                Sort = x.Sort,
                selectable = input.selectable
            }).ToList();

            //菜单节点中,若子节点为空则移除父节点
            if (input.checkEmptyChildren)
                treeList = treeList.Where(x => x.Type != 0 || TreeHelper.GetChildren(treeList, x, false).Count > 0).ToList();

            await SetProperty(treeList);

            return TreeHelper.BuildTree(treeList);

            async Task SetProperty(List<Base_ActionDTO> _list)
            {
                var ids = _list.Select(x => x.Id).ToList();
                var allPermissions = await GetIQueryable()
                    .Where(x => ids.Contains(x.ParentId) && (int)x.Type == 2)
                    .ToListAsync();

                _list.ForEach(aData =>
                {
                    var permissionValues = allPermissions
                        .Where(x => x.ParentId == aData.Id)
                        .Select(x => $"{x.Name}({x.Value})")
                        .ToList();

                    aData.PermissionValues = permissionValues;
                });
            }
        }

        public async Task<Base_Action> GetTheDataAsync(IdInputDTO input)
        {
            return await GetEntityAsync(input.id);
        }

        [Transactional]
        public async Task AddDataAsync(ActionEditInputDTO input)
        {
            await InsertAsync(_mapper.Map<Base_Action>(input));
            await SavePermissionAsync(input.Id, input.permissionList);
        }

        [Transactional]
        public async Task UpdateDataAsync(ActionEditInputDTO input)
        {
            await UpdateAsync(_mapper.Map<Base_Action>(input));
            await SavePermissionAsync(input.Id, input.permissionList);
        }

        public async Task DeleteDataAsync(List<string> ids)
        {
            await DeleteAsync(ids);
            await DeleteAsync(x => ids.Contains(x.ParentId));
        }

        public async Task SavePermissionAsync(string parentId, List<Base_Action> permissionList)
        {
            permissionList.ForEach(aData =>
            {
                aData.Id = IdHelper.GetId();
                aData.CreateTime = DateTime.Now;
                aData.CreatorId = null;
                aData.ParentId = parentId;
                aData.NeedAction = true;
            });
            //删除原来
            await DeleteAsync(x => x.ParentId == parentId && (int)x.Type == 2);
            //新增
            await InsertAsync(permissionList);

            //权限值必须唯一
            var repeatValues = await GetIQueryable()
                .GroupBy(x => x.Value)
                .Where(x => !string.IsNullOrEmpty(x.Key) && x.Count() > 1)
                .Select(x => x.Key)
                .ToListAsync();
            if (repeatValues.Count > 0)
                throw new Exception($"以下权限值重复:{string.Join(",", repeatValues)}");
        }

        #endregion

        #region 私有成员

        #endregion

        public async Task<List<Base_Action>> GetPermissionListAsync(Base_ActionsInputDTO input)
        {
            input.types = new ActionType[] { ActionType.权限 };

            return await GetDataListAsync(input);
        }

        public async Task<List<Base_Action>> GetAllActionListAsync()
        {
            return await GetDataListAsync(new Base_ActionsInputDTO
            {
                types = new ActionType[] { ActionType.菜单, ActionType.页面, ActionType.权限 }
            });
        }

        public async Task<List<Base_ActionDTO>> GetMenuTreeListAsync(Base_ActionsInputDTO input)
        {
            input.selectable = true;
            input.types = new ActionType[] { ActionType.菜单, ActionType.页面 };

            return await GetTreeDataListAsync(input);
        }

        public async Task<List<Base_ActionDTO>> GetActionTreeListAsync(Base_ActionsInputDTO input)
        {
            input.selectable = false;

            return await GetTreeDataListAsync(input);
        }

        public async Task SaveDataAsyncAsync(ActionEditInputDTO input)
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