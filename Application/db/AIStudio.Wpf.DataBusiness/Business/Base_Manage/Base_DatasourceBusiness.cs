using AIStudio.Core;
using AIStudio.Wpf.DataBusiness.AOP;
using AIStudio.Wpf.Entity.Models;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AIStudio.Wpf.DataBusiness.Base_Manage
{
    public class Base_DatasourceBusiness : BaseBusiness<Base_Datasource>, IBase_DatasourceBusiness, ITransientDependency
    {
        public Base_DatasourceBusiness()
        {
        }

        #region 外部接口

        public async Task<PageResult<Base_Datasource>> GetDataListAsync(PageInput<Base_DatasourceInputDTO> input)
        {
            var q = GetIQueryable();
            var where = LinqHelper.True<Base_Datasource>();
            var search = input.Search;
            if (!search.keyword.IsNullOrEmpty())
            {
                where = where.And(x =>
                    x.Name.Contains(search.keyword));
            }

            return await q.Where(where).GetPageResultAsync(input);
        }

    
        public async Task<Base_Datasource> GetTheDataAsync(IdInputDTO input)
        {
            return await GetEntityAsync(input.id);
        }
  
        public async Task AddDataAsync(Base_Datasource newData)
        {
            await InsertAsync(newData);
        }

        public async Task UpdateDataAsync(Base_Datasource theData)
        {
            await UpdateAsync(theData);
        }

        public async Task DeleteDataAsync(List<string> ids)
        {
            await DeleteAsync(ids);
        }

        #endregion

        #region 私有成员

        #endregion

        public async Task SaveDataAsync(Base_Datasource theData)
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