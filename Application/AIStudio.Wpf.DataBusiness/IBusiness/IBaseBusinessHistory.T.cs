using AIStudio.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AIStudio.Wpf.DataBusiness
{
    public partial interface IBaseBusinessHistory<T>
    {
        #region 历史数据查询
        IQueryable<T> GetHistoryDataQueryable(Expression<Func<T, bool>> expression, DateTime? start, DateTime? end, string dateField = "CreateTime");
        Task<int> GetHistoryDataCount(Expression<Func<T, bool>> expression, DateTime? start = null, DateTime? end = null, string dateField = "CreateTime");
        Task<List<T>> GetHistoryDataList(Expression<Func<T, bool>> expression, DateTime? start = null, DateTime? end = null, string dateField = "CreateTime");
        Task<PageResult<T>> GetPageHistoryDataList(PageInput pagination, Expression<Func<T, bool>> expression, DateTime? start = null, DateTime? end = null, string dateField = "CreateTime");

        #endregion
    }

}
