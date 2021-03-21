using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AIStudio.Wpf.DataRepository
{
      internal abstract class DbRepository : IRepository
    {
        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="conString">构造参数，可以为数据库连接字符串或者DbContext</param>
        /// <param name="dbType">数据库类型</param>
        /// <param name="rules"></param>
        public DbRepository(string conString, DatabaseType dbType, ICollection<TableMapperRule> rules)
        {
            ConnectionString = conString;
            DbType = dbType;
            _db = DbFactory.GetDbContext(conString, dbType, rules);
        }
        #endregion

        #region 私有成员
        protected BaseDbContext _db { get; }
        protected IDbContextTransaction _transaction { get; set; }
        protected bool _openedTransaction { get; set; } = false;
        protected virtual string FormatFieldName(string name)
        {
            throw new NotImplementedException("请在子类实现!");
        }
        protected virtual string FormatParamterName(string name)
        {
            return $"@{name}";
        }
        protected virtual string GetSchema(string schema)
        {
            throw new Exception("请在子类实现");
        }
        private (string sql, List<(string paramterName, object paramterValue)> paramters) GetWhereSql(IQueryable query)
        {
            List<(string paramterName, object paramterValue)> paramters =
                new List<(string paramterName, object paramterValue)>();
            var querySql = query.ToSql();
            var theSql = querySql.sql.Replace("\r\n", "\n").Replace("\n", " ");

            //替换AS
            var asPattern = "FROM (.*?) AS (.*?) ";
            //倒排防止别名出错
            var asMatchs = Regex.Matches(theSql, asPattern).Cast<Match>().Reverse();
            foreach (Match aMatch in asMatchs)
            {
                var tableName = aMatch.Groups[1].ToString();
                var asName = aMatch.Groups[2].ToString();

                theSql = theSql.Replace(aMatch.Groups[0].ToString(), $"FROM {tableName} ");
                theSql = theSql.Replace(asName + ".", tableName + ".");
            }

            //无筛选
            if (!theSql.Contains("WHERE"))
                return (" 1=1 ", paramters);

            var firstIndex = theSql.IndexOf("WHERE") + 5;
            string whereSql = theSql.Substring(firstIndex, theSql.Length - firstIndex);

            querySql.parameters?.ForEach(aData =>
            {
                if (whereSql.Contains(aData.Key))
                    paramters.Add((aData.Key, aData.Value));
            });

            return (whereSql, paramters);
        }
        private (string sql, List<(string paramterName, object paramterValue)> paramters) GetDeleteSql(IQueryable iq)
        {
            string tableName = iq.ElementType.Name;
            var whereSql = GetWhereSql(iq);
            string sql = $"DELETE FROM {tableName} WHERE {whereSql.sql}";

            return (sql, whereSql.paramters);
        }
        private (string sql, List<(string paramterName, object paramterValue)> paramters) GetUpdateWhereSql(IQueryable iq, params (string field, UpdateType updateType, object value)[] values)
        {
            string tableName = iq.ElementType.Name;
            var whereSql = GetWhereSql(iq);

            List<string> propertySetStr = new List<string>();

            values.ToList().ForEach(aProperty =>
            {
                var paramterName = FormatParamterName($"_p_{aProperty.field}");
                string formatedField = FormatFieldName(aProperty.field);
                whereSql.paramters.Add((paramterName, aProperty.value));

                string setValueBody = string.Empty;
                switch (aProperty.updateType)
                {
                    case UpdateType.Equal: setValueBody = paramterName; break;
                    case UpdateType.Add: setValueBody = $" {formatedField} + {paramterName} "; break;
                    case UpdateType.Minus: setValueBody = $" {formatedField} - {paramterName} "; break;
                    case UpdateType.Multiply: setValueBody = $" {formatedField} * {paramterName} "; break;
                    case UpdateType.Divide: setValueBody = $" {formatedField} / {paramterName} "; break;
                    default: throw new Exception("updateType无效");
                }

                propertySetStr.Add($" {formatedField} = {setValueBody} ");
            });
            string sql = $"UPDATE {tableName} SET {string.Join(",", propertySetStr)} WHERE {whereSql.sql}";

            return (sql, whereSql.paramters);
        }
        private DynamicParameters CreateDynamicParameters((string paramterName, object paramterValue)[] paramters)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();

            paramters?.ForEach(aParamter =>
            {
                dynamicParameters.Add(aParamter.paramterName, aParamter.paramterValue);
            });

            return dynamicParameters;
        }
        private List<DbParameter> CreateDbParamters((string paramterName, object paramterValue)[] paramters)
        {
            DbProviderFactory dbProviderFactory = DbProviderFactoryHelper.GetDbProviderFactory(DbType);
            List<DbParameter> dbParamters = new List<DbParameter>();
            paramters?.ForEach(aParamter =>
            {
                var newParamter = dbProviderFactory.CreateParameter();
                newParamter.ParameterName = aParamter.paramterName;
                newParamter.Value = aParamter.paramterValue;
                dbParamters.Add(newParamter);
            });

            return dbParamters;
        }

        #endregion

        protected static List<PropertyInfo> GetKeyPropertys(Type type)
        {
            var properties = type
                .GetProperties()
                .Where(x => x.GetCustomAttributes(true).Select(o => o.GetType().FullName).Contains(typeof(KeyAttribute).FullName))
                .ToList();

            return properties;
        }
        private List<object> GetDeleteList(Type type, List<string> keys)
        {
            var theProperty = GetKeyPropertys(type).FirstOrDefault();
            if (theProperty == null)
                throw new Exception("该实体没有主键标识！请使用[Key]标识主键！");

            List<object> deleteList = new List<object>();
            keys.ForEach(aKey =>
            {
                object newData = Activator.CreateInstance(type);
                var value = aKey.ChangeType(theProperty.PropertyType);
                theProperty.SetValue(newData, value);
                deleteList.Add(newData);
            });

            return deleteList;
        }

        #region 已实现

        public (bool Success, Exception ex) RunTransaction(Action action, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            bool success = true;
            Exception resEx = null;
            try
            {
                BeginTransaction(isolationLevel);

                action();

                CommitTransaction();
            }
            catch (Exception ex)
            {
                success = false;
                resEx = ex;
                RollbackTransaction();
            }
            finally
            {
                DisposeTransaction();
            }

            return (success, resEx);
        }
        public async Task<(bool Success, Exception ex)> RunTransactionAsync(Func<Task> action, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            bool success = true;
            Exception resEx = null;
            try
            {
                await BeginTransactionAsync(isolationLevel);

                await action();

                CommitTransaction();
            }
            catch (Exception ex)
            {
                success = false;
                resEx = ex;
                RollbackTransaction();
            }
            finally
            {
                DisposeTransaction();
            }

            return (success, resEx);

        }
        public void BeginTransaction(IsolationLevel isolationLevel)
        {
            AsyncHelper.RunSync(() => BeginTransactionAsync(isolationLevel));
        }
        public int Delete<T>(T entity) where T : class
        {
            return Delete(new List<T> { entity });
        }
        public int Delete<T>(List<T> entities) where T : class
        {
            return AsyncHelper.RunSync(() => DeleteAsync(entities));
        }
        public int Delete<T>(Expression<Func<T, bool>> condition) where T : class
        {
            return AsyncHelper.RunSync(() => DeleteAsync(condition));
        }
        public int DeleteAll<T>() where T : class
        {
            return AsyncHelper.RunSync(() => DeleteAllAsync<T>());
        }
        public Task<int> DeleteAsync<T>(T entity) where T : class
        {
            return DeleteAsync(new List<T> { entity });
        }
        public int DeleteSql<T>(Expression<Func<T, bool>> where) where T : class
        {
            return AsyncHelper.RunSync(() => DeleteSqlAsync(where));
        }
        public int Insert<T>(T entity, bool tracking = false) where T : class
        {
            return Insert(new List<T> { entity }, tracking);
        }
        public int Insert<T>(List<T> entities, bool tracking = false) where T : class
        {
            return AsyncHelper.RunSync(() => InsertAsync(entities, tracking));
        }
        public Task<int> InsertAsync<T>(T entity, bool tracking = false) where T : class
        {
            return InsertAsync(new List<T> { entity }, tracking);
        }
        public int Update<T>(T entity, bool tracking = false) where T : class
        {
            return Update(new List<T> { entity }, tracking);
        }
        public int Update<T>(List<T> entities, bool tracking = false) where T : class
        {
            return AsyncHelper.RunSync(() => UpdateAsync(entities, tracking));
        }
        public int Update<T>(T entity, List<string> properties, bool tracking = false) where T : class
        {
            return Update(new List<T> { entity }, properties, tracking);
        }
        public int Update<T>(List<T> entities, List<string> properties, bool tracking = false) where T : class
        {
            return AsyncHelper.RunSync(() => UpdateAsync(entities, properties, tracking));
        }
        public int Update<T>(Expression<Func<T, bool>> whereExpre, Action<T> set, bool tracking = false) where T : class
        {
            return AsyncHelper.RunSync(() => UpdateAsync(whereExpre, set, tracking));
        }
        public Task<int> UpdateAsync<T>(T entity, bool tracking = false) where T : class
        {
            return UpdateAsync(new List<T> { entity }, tracking);
        }
        public Task<int> UpdateAsync<T>(T entity, List<string> properties, bool tracking = false) where T : class
        {
            return UpdateAsync(new List<T> { entity }, properties, tracking);
        }

        public int Delete<T>(string key) where T : class
        {
            return Delete<T>(new List<string> { key });
        }
        public int Delete<T>(List<string> keys) where T : class
        {
            return AsyncHelper.RunSync(() => DeleteAsync<T>(keys));
        }
        public Task<int> DeleteAsync<T>(string key) where T : class
        {
            return DeleteAsync<T>(new List<string> { key });
        }
        public int DeleteSql(IQueryable source)
        {
            return AsyncHelper.RunSync(() => DeleteSqlAsync(source));
        }
        public int ExecuteSql(string sql, params (string paramterName, object paramterValue)[] parameters)
        {
            return AsyncHelper.RunSync(() => ExecuteSqlAsync(sql, parameters));
        }
        public DataTable GetDataTableWithSql(string sql, params (string paramterName, object value)[] parameters)
        {
            return AsyncHelper.RunSync(() => GetDataTableWithSqlAsync(sql, parameters));
        }
        public DataSet GetDataSetWithSql(string sql, params (string paramterName, object value)[] parameters)
        {
            return AsyncHelper.RunSync(() => GetDataSetWithSqlAsync(sql, parameters));
        }
        public List<T> GetListBySql<T>(string sqlStr, params (string paramterName, object value)[] parameters) where T : class
        {
            return AsyncHelper.RunSync(() => GetListBySqlAsync<T>(sqlStr, parameters));
        }
        public T GetEntity<T>(params object[] keyValue) where T : class
        {
            return AsyncHelper.RunSync(() => GetEntityAsync<T>(keyValue));
        }
        public int SaveChanges(bool tracking = true)
        {
            return AsyncHelper.RunSync(() => SaveChangesAsync(tracking));
        }
        public int UpdateSql<T>(Expression<Func<T, bool>> where, params (string field, UpdateType updateType, object value)[] values) where T : class
        {
            return AsyncHelper.RunSync(() => UpdateSqlAsync(where, values));
        }
        public int UpdateSql(IQueryable source, params (string field, UpdateType updateType, object value)[] values)
        {
            return AsyncHelper.RunSync(() => UpdateSqlAsync(source, values));
        }
        public Task<int> UpdateSqlAsync<T>(Expression<Func<T, bool>> where, params (string field, UpdateType updateType, object value)[] values) where T : class
        {
            return UpdateSqlAsync(GetIQueryable<T>().Where(where), values);
        }
        public async Task<int> DeleteSqlAsync<T>(Expression<Func<T, bool>> where) where T : class
        {
            var iq = GetIQueryable<T>(false).Where(where);

            return await DeleteSqlAsync(iq);
        }
        public async Task<int> DeleteAsync<T>(Expression<Func<T, bool>> condition) where T : class
        {
            var list = await GetIQueryable<T>().Where(condition).ToListAsync();

            return await DeleteAsync(list);
        }
        public async Task<int> UpdateAsync<T>(Expression<Func<T, bool>> whereExpre, Action<T> set, bool tracking = false) where T : class
        {
            var list = await GetIQueryable<T>(false).Where(whereExpre).ToListAsync();

            list.ForEach(aData =>
            {
                set(aData);
            });

            return await UpdateAsync(list, tracking);
        }
        public async Task<int> DeleteAllAsync<T>() where T : class
        {
            return await DeleteSqlAsync(GetIQueryable<T>());
        }
        public virtual async Task<int> DeleteAsync<T>(List<string> keys) where T : class
        {
            return await DeleteAsync(GetDeleteList(typeof(T), keys));
        }

        #endregion

        #region 事物相关

        public async Task BeginTransactionAsync(IsolationLevel isolationLevel)
        {
            _openedTransaction = true;
            _transaction = await _db.Database.BeginTransactionAsync(isolationLevel);
        }
        public void CommitTransaction()
        {
            _transaction?.Commit();
        }
        public void DisposeTransaction()
        {
            if (!_disposed)
            {
                _db.Detach();
            }

            _transaction?.Dispose();
            _openedTransaction = false;
        }
        public void RollbackTransaction()
        {
            _transaction?.Rollback();
        }

        #endregion

        #region 数据库相关

        public string ConnectionString { get; }
        public DatabaseType DbType { get; }
        public async Task<int> SaveChangesAsync(bool tracking = true)
        {
            int count = await _db.SaveChangesAsync();
            if (!tracking && !_openedTransaction)
            {
                _db.Detach();
            }

            return count;
        }

        #endregion

        #region 增加数据

        public virtual void BulkInsert<T>(List<T> entities, string tableName = null) where T : class
        {
            throw new Exception("待支持");
        }
        public async Task<int> InsertAsync<T>(List<T> entities, bool tracking = false) where T : class
        {
            await _db.AddRangeAsync(entities);

            return await _db.SaveChangesAsync(tracking);
        }

        #endregion

        #region 删除数据

        public async Task<int> DeleteSqlAsync(IQueryable source)
        {
            var sql = GetDeleteSql(source);

            return await ExecuteSqlAsync(sql.sql, sql.paramters.ToArray());
        }
        public async Task<int> DeleteAsync<T>(List<T> entities) where T : class
        {
            _db.RemoveRange(entities);

            return await SaveChangesAsync(false);
        }

        #endregion

        #region 更新数据

        public async Task<int> UpdateAsync<T>(List<T> entities, bool tracking = false) where T : class
        {
            entities.ForEach(aEntity =>
            {
                _db.Entry(aEntity).State = EntityState.Modified;
            });

            return await SaveChangesAsync(tracking);
        }
        public async Task<int> UpdateAsync<T>(List<T> entities, List<string> properties, bool tracking = false) where T : class
        {
            entities.ForEach(aEntity =>
            {
                properties.ForEach(aProperty =>
                {
                    _db.Entry(aEntity).Property(aProperty).IsModified = true;
                });
            });

            return await SaveChangesAsync(tracking);
        }
        public async Task<int> UpdateSqlAsync(IQueryable source, params (string field, UpdateType updateType, object value)[] values)
        {
            var sql = GetUpdateWhereSql(source, values);

            return await ExecuteSqlAsync(sql.sql, sql.paramters.ToArray());
        }

        #endregion

        #region 查询数据

        public async Task<T> GetEntityAsync<T>(params object[] keyValue) where T : class
        {
            var obj = await _db.Set<T>().FindAsync(keyValue);
            if (!obj.IsNullOrEmpty())
                _db.Entry(obj).State = EntityState.Detached;

            return obj;
        }
        public IQueryable<T> GetIQueryable<T>(bool tracking = false) where T : class
        {
            var q = _db.Set<T>() as IQueryable<T>;

            if (!tracking)
                q = q.AsNoTracking();

            return q;
        }
        public async Task<DataTable> GetDataTableWithSqlAsync(string sql, params (string paramterName, object value)[] parameters)
        {
            var conn = _db.Database.GetDbConnection();
            using var reader = await conn.ExecuteReaderAsync(
                sql, CreateDynamicParameters(parameters), _transaction?.GetDbTransaction());
            DataTable table = new DataTable();

            table.Load(reader);

            return table;
        }
        public async Task<DataSet> GetDataSetWithSqlAsync(string sql, params (string paramterName, object value)[] parameters)
        {
            DbProviderFactory dbProviderFactory = DbProviderFactoryHelper.GetDbProviderFactory(DbType);
            DbConnection conn = _db.Database.GetDbConnection();

            if (conn.State != ConnectionState.Open)
                await conn.OpenAsync();

            using (DbCommand cmd = conn.CreateCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = sql;
                if (parameters != null && parameters.Count() > 0)
                    cmd.Parameters.AddRange(CreateDbParamters(parameters).ToArray());

                DbDataAdapter adapter = dbProviderFactory.CreateDataAdapter();
                adapter.SelectCommand = cmd;
                DataSet ds = new DataSet();

                adapter.Fill(ds);
                cmd.Parameters.Clear();
                return ds;
            }
        }
        public async Task<List<T>> GetListBySqlAsync<T>(string sql, params (string paramterName, object value)[] parameters) where T : class
        {
            var conn = _db.Database.GetDbConnection();

            return (await conn.QueryAsync<T>(sql, CreateDynamicParameters(parameters), _transaction?.GetDbTransaction())).ToList();
        }

        #endregion

        #region 执行Sql语句

        public async Task<int> ExecuteSqlAsync(string sql, params (string paramterName, object paramterValue)[] parameters)
        {
            return await _db.Database.ExecuteSqlRawAsync(sql, CreateDbParamters(parameters).ToArray());
        }

        #endregion

        #region Dispose

        private bool _disposed = false;
        public void Dispose()
        {
            if (_disposed)
                return;

            _disposed = true;
            DisposeTransaction();
            _db.Dispose();
        }

        #endregion
    }
}
