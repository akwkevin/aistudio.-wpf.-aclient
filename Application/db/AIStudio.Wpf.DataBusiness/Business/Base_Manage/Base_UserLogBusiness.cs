using AIStudio.Core;
using AIStudio.Wpf.Business;
using AIStudio.Wpf.Entity.Models;
using Coldairarrow.Util;
using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AIStudio.Wpf.DataBusiness.Base_Manage
{
    public class Base_UserLogBusiness : BaseBusiness<Base_UserLog>, IBase_UserLogBusiness, ITransientDependency
    {
        readonly IOperator _operator;
        public Base_UserLogBusiness(IOperator @operator)
        {
            _operator = @operator;
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

        public async Task<List<SelectOption>> GetLogTypeListAsync()
        {
            return await Task.Run(() =>
            {
                return EnumHelper.ToOptionList(typeof(UserLogType));
            });
        }

        public async Task WriteUserLog(UserLogType userLogType, string msg)
        {
            var log = new Base_UserLog
            {
                Id = IdHelper.GetId(),
                CreateTime = DateTime.Now,
                CreatorId = _operator.Property?.Id,
                CreatorName = _operator.Property?.UserName,
                LogContent = msg,
                LogType = userLogType.ToString()
            };

            await InsertAsync(log);
        }
    }
}