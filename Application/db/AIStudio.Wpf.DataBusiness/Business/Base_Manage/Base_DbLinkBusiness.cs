using AIStudio.Core;
using AIStudio.Wpf.Entity.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AIStudio.Wpf.DataBusiness.Base_Manage
{
    public class Base_DbLinkBusiness : BaseBusiness<Base_DbLink>, IBase_DbLinkBusiness, ITransientDependency
    {
        public Base_DbLinkBusiness()
        {
        }

        #region 外部接口

        public async Task<PageResult<Base_DbLink>> GetDataListAsync(PageInput input)
        {
            return await GetIQueryable().GetPageResultAsync(input);
        }

        public async Task<Base_DbLink> GetTheDataAsync(IdInputDTO input)
        {
            return await GetEntityAsync(input.id);
        }

        public async Task AddDataAsync(Base_DbLink newData)
        {
            await InsertAsync(newData);
        }

        public async Task UpdateDataAsync(Base_DbLink theData)
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

        #region 数据模型

        #endregion

        public async Task SaveDataAsync(Base_DbLink theData)
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