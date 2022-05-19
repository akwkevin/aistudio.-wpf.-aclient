using AIStudio.Core;
using AIStudio.Wpf.Business;
using AIStudio.Wpf.DataRepository;
using Coldairarrow.Util;
using Microsoft.EntityFrameworkCore;
using Prism.Ioc;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AIStudio.Wpf.DataBusiness
{
    /// <summary>
    /// 描述：业务处理基类
    /// </summary>
    /// <typeparam name="T">泛型约束（数据库实体）</typeparam>
    public abstract partial class BaseBusiness<T> : IBaseBusiness<T> where T : class, new()
    {
        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="db">注入数据库</param>
        public BaseBusiness()
        {

        }

        #endregion

        #region 私有成员
        private string _conString { get; } = LocalSetting.ConString;
        private DatabaseType _dbType { get; } = LocalSetting.DatabaseType.ToEnum<DatabaseType>();
        private ICollection<TableMapperRule> _rules { get; set; }

        private IDbAccessor _service { get; set; }

        private object _serviceLock = new object();
        protected virtual string _valueField { get; } = "Id";
        protected virtual string _textField { get => throw new Exception("请在子类重写"); }

        private BlockingCollection<IDbAccessor> _dbs { get; } = new BlockingCollection<IDbAccessor>();
        #endregion

        #region 初始化
        /// <summary>
        /// 切换实体对应的数据库表,分表使用
        /// </summary>
        /// <param name="rules"></param>
        protected void ChangeRules(ICollection<TableMapperRule> rules)
        {
            _rules = rules;
        }

        /// <summary>
        /// 切换实体对应的数据库表,分表使用
        /// </summary>
        /// <param name="tableSuffix"></param>
        protected void ChangeRules(string tableSuffix)
        {
            if (string.IsNullOrEmpty(tableSuffix))
                return;

            List<TableMapperRule> rules = new List<TableMapperRule>()
            {
                new TableMapperRule()
                {
                    MappingType = typeof(T),
                    TableName = typeof(T).Name + tableSuffix,
                    TableSuffix = tableSuffix,
                }
            };

            _rules = rules;
        }

        private IDbAccessor GetBusRepository(string conString, DatabaseType dbType, ICollection<TableMapperRule> rules, bool autoDispose)
        {
            var db = DbFactory.GetDbAccessor(conString, dbType, rules, LocalSetting.DeleteMode?.ToEnum<DeleteMode>() == DeleteMode.Logic);
            if (autoDispose)
                _dbs.Add(db);

            return db;
        }

        private void InitDb()
        {
            if (_service == null) //双if +lock
            {
                lock (_serviceLock)
                {
                    if (_service == null)
                    {
                        _service = GetBusRepository(_conString, _dbType, _rules, true);
                    }
                }
            }
        }
        #endregion

        #region 外部属性



        /// <summary>
        /// 业务仓储接口(支持软删除),支持联表操作
        /// 注：仅支持单线程操作
        /// 注：多线程请使用GetNewService(conString,dbType,false),并且需要手动释放
        /// </summary>
        public IDbAccessor Service
        {
            get
            {
                InitDb();

                return _service;
            }
        }

        #endregion

        #region 事物提交

        public (bool Success, Exception ex) RunTransaction(Action action, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            return Service.RunTransaction(action, isolationLevel);
        }
        public async Task<(bool Success, Exception ex)> RunTransactionAsync(Func<Task> action, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            return await Service.RunTransactionAsync(action, isolationLevel);
        }

        #endregion

        #region 增加数据

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="entity">实体对象</param>
        public int Insert(T entity)
        {
            return Service.Insert(entity);
        }

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="entity">实体对象</param>
        public async Task<int> InsertAsync(T entity)
        {
            return await Service.InsertAsync(entity);
        }

        /// <summary>
        /// 添加多条数据
        /// </summary>
        /// <param name="entities">实体对象集合</param>
        public int Insert(List<T> entities)
        {
            return Service.Insert(entities);
        }

        /// <summary>
        /// 添加多条数据
        /// </summary>
        /// <param name="entities">实体对象集合</param>
        public async Task<int> InsertAsync(List<T> entities)
        {
            return await Service.InsertAsync(entities);
        }

        /// <summary>
        /// 添加多条数据
        /// </summary>
        /// <param name="entities">实体对象集合</param>
        public async Task<int> InsertAsync(List<object> entities)
        {
            return await Service.InsertAsync(entities.OfType<T>().ToList());
        }

        /// <summary>
        /// 批量添加数据,速度快
        /// </summary>
        /// <param name="entities"></param>
        public void BulkInsert(List<T> entities)
        {
            Service.BulkInsert(entities);
        }

        #endregion

        #region 删除数据

        /// <summary>
        /// 删除所有数据
        /// </summary>
        public virtual int DeleteAll()
        {
            return Service.DeleteAll<T>();
        }

        /// <summary>
        /// 删除所有数据
        /// </summary>
        public virtual async Task<int> DeleteAllAsync()
        {
            return await Service.DeleteAllAsync<T>();
        }

        /// <summary>
        /// 删除指定主键数据
        /// </summary>
        /// <param name="key"></param>
        public virtual int Delete(string key)
        {
            return Service.Delete<T>(key);
        }

        /// <summary>
        /// 删除指定主键数据
        /// </summary>
        /// <param name="key"></param>
        public virtual async Task<int> DeleteAsync(string key)
        {
            return await Service.DeleteAsync<T>(key);
        }

        /// <summary>
        /// 通过主键删除多条数据
        /// </summary>
        /// <param name="keys"></param>
        public virtual int Delete(List<string> keys)
        {
            return Service.Delete<T>(keys);
        }

        /// <summary>
        /// 通过主键删除多条数据
        /// </summary>
        /// <param name="keys"></param>
        public virtual async Task<int> DeleteAsync(List<string> keys)
        {
            return await Service.DeleteAsync<T>(keys);
        }


        /// <summary>
        /// 删除单条数据
        /// </summary>
        /// <param name="entity">实体对象</param>
        public virtual int Delete(T entity)
        {
            return Service.Delete<T>(entity);
        }

        /// <summary>
        /// 删除单条数据
        /// </summary>
        /// <param name="entity">实体对象</param>
        public virtual async Task<int> DeleteAsync(T entity)
        {
            return await Service.DeleteAsync(entity);
        }

        /// <summary>
        /// 删除多条数据
        /// </summary>
        /// <param name="entities">实体对象集合</param>
        public virtual int Delete(List<T> entities)
        {
            return Service.Delete<T>(entities);
        }

        /// <summary>
        /// 删除多条数据
        /// </summary>
        /// <param name="entities">实体对象集合</param>
        public virtual async Task<int> DeleteAsync(List<T> entities)
        {
            return await Service.DeleteAsync<T>(entities);
        }


        /// <summary>
        /// 删除指定条件数据
        /// </summary>
        /// <param name="condition">筛选条件</param>
        public virtual int Delete(Expression<Func<T, bool>> condition)
        {
            return Service.Delete(condition);
        }

        /// <summary>
        /// 删除指定条件数据
        /// </summary>
        /// <param name="condition">筛选条件</param>
        public virtual async Task<int> DeleteAsync(Expression<Func<T, bool>> condition)
        {
            return await Service.DeleteAsync(condition);
        }

        /// <summary>
        /// 使用SQL语句按照条件删除数据
        /// 用法:Delete_Sql"Base_User"(x=&gt;x.Id == "Admin")
        /// 注：生成的SQL类似于DELETE FROM [Base_User] WHERE [Name] = 'xxx' WHERE [Id] = 'Admin'
        /// </summary>
        /// <param name="where">条件</param>
        /// <returns>
        /// 影响条数
        /// </returns>
        public virtual int DeleteSql(Expression<Func<T, bool>> where)
        {
            return Service.DeleteSql(where);
        }

        /// <summary>
        /// 使用SQL语句按照条件删除数据
        /// 用法:Delete_Sql"Base_User"(x=&gt;x.Id == "Admin")
        /// 注：生成的SQL类似于DELETE FROM [Base_User] WHERE [Name] = 'xxx' WHERE [Id] = 'Admin'
        /// </summary>
        /// <param name="where">条件</param>
        /// <returns>
        /// 影响条数
        /// </returns>
        public virtual async Task<int> DeleteSqlAsync(Expression<Func<T, bool>> where)
        {
            return await Service.DeleteSqlAsync(where);
        }

        #endregion

        #region 更新数据

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="entity">实体对象</param>
        public int Update(T entity)
        {
            return Service.Update(entity);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="entity">实体对象</param>
        public async Task<int> UpdateAsync(T entity)
        {
            return await Service.UpdateAsync(entity);
        }

        /// <summary>
        /// 更新多条数据
        /// </summary>
        /// <param name="entities">数据列表</param>
        public int Update(List<T> entities)
        {
            return Service.Update(entities);
        }

        /// <summary>
        /// 更新多条数据
        /// </summary>
        /// <param name="entities">数据列表</param>
        public async Task<int> UpdateAsync(List<T> entities)
        {
            return await Service.UpdateAsync(entities);
        }

        /// <summary>
        /// 更新多条数据
        /// </summary>
        /// <param name="entities">数据列表</param>
        public async Task<int> UpdateAsync(List<object> entities)
        {
            return await Service.UpdateAsync(entities.OfType<T>().ToList());
        }

        /// <summary>
        /// 指定条件更新
        /// </summary>
        /// <param name="whereExpre">筛选表达式</param>
        /// <param name="set">更改属性回调</param>
        public int Update(Expression<Func<T, bool>> whereExpre, Action<T> set)
        {
            return Service.Update(whereExpre, set);
        }

        /// <summary>
        /// 指定条件更新
        /// </summary>
        /// <param name="whereExpre">筛选表达式</param>
        /// <param name="set">更改属性回调</param>
        public async Task<int> UpdateAsync(Expression<Func<T, bool>> whereExpre, Action<T> set)
        {
            return await Service.UpdateAsync(whereExpre, set);
        }

        /// <summary>
        /// 使用SQL语句按照条件更新
        /// 用法:UpdateWhere_Sql"Base_User"(x=>x.Id == "Admin",("Name","小明"))
        /// 注：生成的SQL类似于UPDATE [TABLE] SET [Name] = 'xxx' WHERE [Id] = 'Admin'
        /// </summary>
        /// <param name="where">筛选条件</param>
        /// <param name="values">字段值设置</param>
        /// <returns>影响条数</returns>
        public int UpdateSql(Expression<Func<T, bool>> where, params (string field, UpdateType updateType, object value)[] values)
        {
            return Service.UpdateSql(where, values);
        }

        /// <summary>
        /// 使用SQL语句按照条件更新
        /// 用法:UpdateWhere_Sql"Base_User"(x=>x.Id == "Admin",("Name","小明"))
        /// 注：生成的SQL类似于UPDATE [TABLE] SET [Name] = 'xxx' WHERE [Id] = 'Admin'
        /// </summary>
        /// <param name="where">筛选条件</param>
        /// <param name="values">字段值设置</param>
        /// <returns>影响条数</returns>
        public async Task<int> UpdateSqlAsync(Expression<Func<T, bool>> where, params (string field, UpdateType updateType, object value)[] values)
        {
            return await Service.UpdateSqlAsync(where, values);
        }

        #endregion

        #region 查询数据
        /// <summary>
        /// 根据lambda表达式条件获取单个实体
        /// </summary>
        /// <param name="predicate">lambda表达式条件</param>
        /// <returns></returns>
        public T FirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return Service.GetIQueryable<T>().FirstOrDefault<T>(predicate);
        }

        /// <summary>
        /// 根据lambda表达式条件获取单个实体
        /// </summary>
        /// <param name="predicate">lambda表达式条件</param>
        /// <returns></returns>
        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await Service.GetIQueryable<T>().FirstOrDefaultAsync<T>(predicate);
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public T GetEntity(params object[] keyValue)
        {
            return Service.GetEntity<T>(keyValue);
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public async Task<T> GetEntityAsync(params object[] keyValue)
        {
            return await Service.GetEntityAsync<T>(keyValue);
        }

        /// <summary>
        /// 获取表的所有数据，当数据量很大时不要使用！
        /// </summary>
        /// <returns></returns>
        public List<T> GetList()
        {
            return GetIQueryable().ToList();
        }

        /// <summary>
        /// 获取表的所有数据，当数据量很大时不要使用！
        /// </summary>
        /// <returns></returns>
        public async Task<List<T>> GetListAsync()
        {
            return await GetIQueryable().ToListAsync();
        }

        /// <summary>
        /// 获取实体对应的表，延迟加载，主要用于支持Linq查询操作
        /// </summary>
        /// <returns></returns>
        public virtual IQueryable<T> GetIQueryable(bool tracking = false)
        {
            return Service.GetIQueryable<T>(tracking);
        }


        #endregion

        #region 执行Sql语句

        #endregion

        #region 业务返回

        /// <summary>
        /// 返回成功
        /// </summary>
        /// <returns></returns>
        public AjaxResult Success()
        {
            AjaxResult res = new AjaxResult
            {
                Success = true,
                Msg = "请求成功！",
            };

            return res;
        }

        /// <summary>
        /// 返回成功
        /// </summary>
        /// <param name="data">返回数据</param>
        /// <returns></returns>
        public AjaxResult<U> Success<U>(U data)
        {
            AjaxResult<U> res = new AjaxResult<U>
            {
                Success = true,
                Msg = "操作成功",
                Data = data
            };

            return res;
        }

        /// <summary>
        /// 返回成功
        /// </summary>
        /// <param name="data">返回数据</param>
        /// <param name="msg">返回消息</param>
        /// <returns></returns>
        public AjaxResult<U> Success<U>(U data, string msg)
        {
            AjaxResult<U> res = new AjaxResult<U>
            {
                Success = true,
                Msg = msg,
                Data = data
            };

            return res;
        }

        /// <summary>
        /// 返回错误
        /// </summary>
        /// <returns></returns>
        public AjaxResult Error()
        {
            AjaxResult res = new AjaxResult
            {
                Success = false,
                Msg = "请求失败！",
            };

            return res;
        }

        /// <summary>
        /// 返回错误
        /// </summary>
        /// <param name="msg">错误提示</param>
        /// <returns></returns>
        public AjaxResult Error(string msg)
        {
            AjaxResult res = new AjaxResult
            {
                Success = false,
                Msg = msg,
            };

            return res;
        }

        /// <summary>
        /// 构建前端Select远程搜索数据
        /// </summary>
        /// <param name="input">查询参数</param>
        /// <returns></returns>
        public async Task<List<SelectOption>> GetOptionListAsync(OptionListInputDTO input)
        {
            return await GetOptionListAsync(input, _textField, _valueField, null);
        }

        /// <summary>
        /// 构建前端Select远程搜索数据
        /// </summary>
        /// <param name="input">查询参数</param>
        /// <param name="textFiled">文本字段</param>
        /// <param name="valueField">值字段</param>
        /// <param name="source">指定数据源</param>
        /// <returns></returns>
        protected async Task<List<SelectOption>> GetOptionListAsync(OptionListInputDTO input, string textFiled, string valueField, IQueryable<T> source = null)
        {
            PageInput pageInput = new PageInput
            {
                PageRows = 10
            };

            List<T> selectedList = new List<T>();
            string where = " 1=1 ";
            List<string> ids = input.selectedValues ?? new List<string>();
            if (ids.Count > 0)
            {
                selectedList = await GetNewQ().Where($"@0.Contains({valueField})", ids).ToListAsync();

                where += $" && !@0.Contains({valueField})";
            }

            if (!input.q.IsNullOrEmpty())
            {
                where += $" && it.{textFiled}.Contains(@1)";
            }
            List<T> newQList = await GetNewQ().Where(where, ids, input.q).GetPageListAsync(pageInput);

            var resList = selectedList.Concat(newQList).Select(x => new SelectOption
            {
                Value = x.GetPropertyValue(valueField)?.ToString(),
                Text = x.GetPropertyValue(textFiled)?.ToString()
            }).ToList();

            return resList;

            IQueryable<T> GetNewQ()
            {
                return source ?? GetIQueryable();
            }
        }

        #endregion

        #region 其它操作

        protected void InitEntity(object obj)
        {
            var op = ContainerLocator.Current.Resolve<IOperator>();
            if (obj.ContainsProperty("Id"))
                obj.SetPropertyValue("Id", IdHelper.GetId());
            if (obj.ContainsProperty("CreateTime"))
                obj.SetPropertyValue("CreateTime", DateTime.Now);
            if (obj.ContainsProperty("CreatorId"))
                obj.SetPropertyValue("CreatorId", op?.UserId);
            if (obj.ContainsProperty("CreatorName"))
                obj.SetPropertyValue("CreatorName", op?.Property?.UserName);
        }

        protected void UpdateEntity(object obj)
        {
            var op = ContainerLocator.Current.Resolve<IOperator>();
            if (obj.ContainsProperty("ModifyTime"))
                obj.SetPropertyValue("ModifyTime", DateTime.Now);
            if (obj.ContainsProperty("ModifyId"))
                obj.SetPropertyValue("ModifyId", op?.UserId);
            if (obj.ContainsProperty("ModifyName"))
                obj.SetPropertyValue("ModifyName", op?.Property?.UserName);
        }
        #endregion

    }
}
