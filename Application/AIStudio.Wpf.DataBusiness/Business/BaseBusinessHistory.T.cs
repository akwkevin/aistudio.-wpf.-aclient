using AIStudio.Core;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AIStudio.Wpf.DataBusiness
{
    public abstract partial class BaseBusiness<T> : IBaseBusinessHistory<T>
    {
        #region 历史数据查询
        public IQueryable<T> GetHistoryDataQueryable(Expression<Func<T, bool>> expression, DateTime? start, DateTime? end, string dateField = "CreateTime")
        {
            if (end == DateTime.MinValue || end == null)
            {
                end = DateTime.Now;
            }
            if (start == DateTime.MinValue || start == null)
            {
                start = DateTime.Now.AddDays(-30);
            }

            List<T> dataList = new List<T>();
            var newWhere = DynamicExpressionParser.ParseLambda<T, bool>(
                  ParsingConfig.Default, false, $@"{dateField} > @0 && {dateField} < @1", new object[] { start, end });
            expression = expression.And(newWhere);

            return GetIQueryable().Where(expression);
        }
        public async Task<int> GetHistoryDataCount(Expression<Func<T, bool>> expression, DateTime? start, DateTime? end, string dateField = "CreateTime")
        {
            if (end == DateTime.MinValue || end == null)
            {
                end = DateTime.Now;
            }
            if (start == DateTime.MinValue || start == null)
            {
                start = DateTime.Now.AddDays(-30);
            }

            List<T> dataList = new List<T>();
            var newWhere = DynamicExpressionParser.ParseLambda<T, bool>(
                  ParsingConfig.Default, false, $@"{dateField} > @0 && {dateField} < @1", new object[] { start, end });
            expression = expression.And(newWhere);

            return await GetIQueryable().Where(expression).CountAsync();
        }

        public async Task<List<T>> GetHistoryDataList(Expression<Func<T, bool>> expression, DateTime? start, DateTime? end, string dateField = "CreateTime")
        {
            if (end == DateTime.MinValue || end == null)
            {
                end = DateTime.Now;
            }
            if (start == DateTime.MinValue || start == null)
            {
                start = DateTime.Now.AddDays(-30);
            }

            List<T> dataList = new List<T>();
            var newWhere = DynamicExpressionParser.ParseLambda<T, bool>(
                  ParsingConfig.Default, false, $@"{dateField} > @0 && {dateField} < @1", new object[] { start, end });
            expression = expression.And(newWhere);

            return await GetIQueryable().Where(expression).ToListAsync();
        }

        public async Task<PageResult<T>> GetPageHistoryDataList(PageInput input, Expression<Func<T, bool>> expression, DateTime? start, DateTime? end, string dateField = "CreateTime")
        {
            if (end == DateTime.MinValue || end == null)
            {
                end = DateTime.Now;
            }
            if (start == DateTime.MinValue || start == null)
            {
                start = DateTime.Now.AddDays(-30);
            }


            var newWhere = DynamicExpressionParser.ParseLambda<T, bool>(
                  ParsingConfig.Default, false, $@"{dateField} > @0 && {dateField} < @1", new object[] { start, end });
            expression = expression.And(newWhere);

            var q = GetIQueryable();
            return await q.Where(expression).GetPageResultAsync(input);

        }

        #endregion
    }
}
