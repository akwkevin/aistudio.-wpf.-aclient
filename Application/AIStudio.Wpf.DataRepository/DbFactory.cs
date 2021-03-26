using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace AIStudio.Wpf.DataRepository
{
    /// <summary>
    /// 数据库工厂
    /// </summary>
    public class DbFactory
    {
        #region 外部接口
        /// <summary>
        /// 根据配置文件获取数据库类型，并返回对应的工厂接口
        /// </summary>
        /// <param name="conString">链接字符串,默认为GlobalSwitch.DefaultDbConName</param>
        /// <param name="dbType">数据库类型,默认为GlobalSwitch.DatabaseType</param>
        /// <param name="rules"></param>
        /// <returns></returns>
        public static IDbAccessor GetDbAccessor(string conString, DatabaseType dbType, ICollection<TableMapperRule> rules = null, bool logicDelete = false, string deletedField = "Deleted", string keyField = "Id")
        {
            Type dbRepositoryType = Type.GetType("AIStudio.Wpf.DataRepository." + DbProviderFactoryHelper.DbTypeToDbTypeStr(dbType) + "DbAccessor");

            var dbAccessor = Activator.CreateInstance(dbRepositoryType, new object[] { conString, rules }) as IDbAccessor;
            if (logicDelete)
                dbAccessor = new LogicDeleteDbAccessor(dbAccessor, logicDelete, deletedField, keyField);
            return dbAccessor;
        }

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="conString"></param>
        /// <param name="dbType"></param>
        /// <param name="rules"></param>
        /// <returns></returns>
        internal static BaseDbContext GetDbContext(string conString, DatabaseType dbType, ICollection<TableMapperRule> rules = null)
        {
            return new BaseDbContext(CreateDbContextOption(conString, dbType, rules).Options);
        }

        public static DbContextOptionsBuilder CreateDbContextOption(string conString, DatabaseType dbType, ICollection<TableMapperRule> rules = null)
        {
            DbContextOptionsBuilder builder = new DbContextOptionsBuilder();

            var model = DbModelFactory.GetDbCompiledModel(conString, dbType, rules);

            switch (dbType)
            {
                //暂时只写了SqlServer，大家请自行添加
                case DatabaseType.SqlServer: builder.UseSqlServer(conString); break;
                default: throw new Exception("暂不支持该数据库！");
            }
            builder.EnableSensitiveDataLogging();
            builder.UseModel(model);

            return builder;
        }

        #endregion
    }
}
