using AIStudio.Core;
using AIStudio.Wpf.DataBusiness.AOP;
using AIStudio.Wpf.EFCore.Models;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AIStudio.Wpf.DataBusiness.Base_Manage
{
    public class Base_DepartmentBusiness : BaseBusiness<Base_Department>, IBase_DepartmentBusiness, ITransientDependency
    {
        public Base_DepartmentBusiness()
        {
        }

        #region 外部接口

        public async Task<List<Base_DepartmentTreeDTO>> GetTreeDataListAsync(DepartmentsTreeInputDTO input)
        {
            var where = LinqHelper.True<Base_Department>();
            if (!input.parentId.IsNullOrEmpty())
                where = where.And(x => x.ParentId == input.parentId);

            var list = await GetIQueryable().Where(where).ToListAsync();
            var treeList = list
                .Select(x => new Base_DepartmentTreeDTO
                {
                    Id = x.Id,
                    ParentId = x.ParentId,
                    ParentIds = x.ParentIds,
                    Text = x.Name,
                    Value = x.Id
                }).ToList();

            return TreeHelper.BuildTree(treeList);
        }

        public async Task<List<string>> GetChildrenIdsAsync(string departmentId)
        {
            var allNode = await GetIQueryable().Select(x => new TreeModel
            {
                Id = x.Id,
                ParentId = x.ParentId,
                Text = x.Name,
                Value = x.Id
            }).ToListAsync();

            var children = TreeHelper
                .GetChildren(allNode, allNode.Where(x => x.Id == departmentId).FirstOrDefault(), true)
                .Select(x => x.Id)
                .ToList();

            return children;
        }

        public async Task<Base_Department> GetTheDataAsync(IdInputDTO input)
        {
            return await GetEntityAsync(input.id);
        }


        public async Task AddDataAsync(Base_Department newData)
        {
            await InsertAsync(newData);
        }


        public async Task UpdateDataAsync(Base_Department theData)
        {
            await UpdateAsync(theData);
        }

        [DataDeleteLog(UserLogType.部门管理, "Name", "部门名")]
        public async Task DeleteDataAsync(List<string> ids)
        {
            if (await GetIQueryable().AnyAsync(x => ids.Contains(x.ParentId)))
                throw new BusException("禁止删除！请先删除所有子级！");

            await DeleteAsync(ids);
        }

        #endregion

        [DataRepeatValidate(new string[] { "Name" }, new string[] { "部门名" }, Order = 1)]
        [DataSaveLog(UserLogType.部门管理, "Name", "部门名", Order = 2)]

        public async Task SaveDataAsync(Base_Department theData)
        {
            if (theData.Id.IsNullOrEmpty())
            {
                InitEntity(theData);

                await AddDataAsync(theData);
            }
            else
            {
                UpdateEntity(theData);
                await UpdateDataAsync(theData);
            }
        }
    }
}