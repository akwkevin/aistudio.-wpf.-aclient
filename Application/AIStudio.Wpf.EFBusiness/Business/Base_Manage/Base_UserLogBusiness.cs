using AIStudio.Core;
using AIStudio.Wpf.EFCore.Models;
using EFCore.Sharding;
using LinqKit;
using System.Linq;
using System.Threading.Tasks;

namespace AIStudio.Wpf.EFBusiness.Base_Manage
{
    public class Base_UserLogBusiness : BaseBusiness<Base_UserLog>, IBase_UserLogBusiness, ITransientDependency
    {
        public Base_UserLogBusiness()
        {
        }

        public async Task<PageResult<Base_UserLog>> GetLogListAsync(PageInput<UserLogsInputDTO> input)
        {
            var whereExp = LinqHelper.True<Base_UserLog>();
            var search = input.Search;
            if (!search.logContent.IsNullOrEmpty())
                whereExp = whereExp.And(x => x.LogContent.Contains(search.logContent));
            if (!search.logType.IsNullOrEmpty())
                whereExp = whereExp.And(x => x.LogType == search.logType);
            if (!search.opUserName.IsNullOrEmpty())
                whereExp = whereExp.And(x => x.CreatorName.Contains(search.opUserName));
            if (!search.startTime.IsNullOrEmpty())
                whereExp = whereExp.And(x => x.CreateTime >= search.startTime);
            if (!search.endTime.IsNullOrEmpty())
                whereExp = whereExp.And(x => x.CreateTime <= search.endTime);

            return await GetIQueryable().Where(whereExp).GetPageResultAsync(input);
        }
    }
}