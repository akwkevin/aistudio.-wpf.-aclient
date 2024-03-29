﻿using AIStudio.Wpf.Entity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AIStudio.Wpf.DataRepository
{
    public static class DbModelFactory
    {
        public static readonly List<string> Assemblies =
                new List<string> {
                "AIStudio.Wpf.Entity",
    };

        public static List<Type> AllTypes;

        #region 构造函数

        static DbModelFactory()
        {
            InitEntityType();
        }

        #endregion

        #region 外部接口

        /// <summary>
        /// 获取DbCompiledModel
        /// </summary>
        /// <param name="conStr">数据库连接名或字符串</param>
        /// <param name="dbType">数据库类型</param>
        /// <param name="rules"></param>
        /// <returns></returns>
        public static IModel GetDbCompiledModel(string conStr, DatabaseType dbType, ICollection<TableMapperRule> rules)
        {
            string modelInfoId = GetCompiledModelIdentity(conStr, dbType, rules);
            bool success = _dbCompiledModel.TryGetValue(modelInfoId, out IModel resModel);
            if (!success)
            {
                var theLock = _lockDic.GetOrAdd(modelInfoId, new object());
                lock (theLock)
                {
                    success = _dbCompiledModel.TryGetValue(modelInfoId, out resModel);
                    if (!success)
                    {
                        resModel = BuildDbCompiledModel(dbType, rules);
                        _dbCompiledModel[modelInfoId] = resModel;
                    }
                }
            }

            return resModel;
        }

        /// <summary>
        /// 获取实体模型
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        public static Type GetEntityType(string tableName)
        {
            if (!_entityTypeMap.ContainsKey(tableName))
                throw new Exception($"表[{tableName}]缺少实体模型!");

            return _entityTypeMap[tableName];
        }

        /// <summary>
        /// 添加实体模型
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="entityType">实体模型</param>
        public static void AddEntityType(string tableName, Type entityType)
        {
            if (_entityTypeMap.ContainsKey(tableName))
                throw new Exception($"表[{tableName}]已存在实体模型!");

            _entityTypeMap[tableName] = entityType;
            _dbCompiledModel.Clear();
        }

        #endregion

        #region 私有成员

        private static void InitEntityType()
        {
            var assemblys = Assemblies.Select(x => Assembly.Load(x)).ToList();
            AllTypes = new List<Type>();
            assemblys.ForEach(aAssembly =>
            {
                AllTypes.AddRange(aAssembly.GetTypes());
            });


            //Model First 用这个方法
            //List<Type> types = allTypes
            //      .Where(x => x.GetCustomAttribute(typeof(TableAttribute), false) != null).ToList();
            //DB First 用这个方法
            List<Type> types = new List<Type>();
            var db = typeof(ColderAdminAntdVueContext);
            foreach(var pro in db.GetProperties())
            {
                var type = AllTypes.FirstOrDefault(p => p.Name == pro.Name);
                if (type != null)
                {
                    types.Add(type);
                }
            }

            types.ForEach(aType =>
            {
                _entityTypeMap[aType.Name] = aType;
            });
        }
        private static ConcurrentDictionary<string, Type> _entityTypeMap { get; } =
            new ConcurrentDictionary<string, Type>();
        private static ConcurrentDictionary<string, IModel> _dbCompiledModel { get; }
            = new ConcurrentDictionary<string, IModel>();
        private static IModel BuildDbCompiledModel(DatabaseType dbType, ICollection<TableMapperRule> rules)
        {
            ConventionSet conventionSet = null;
            switch (dbType)
            {
                case DatabaseType.SqlServer: conventionSet = SqlServerConventionSetBuilder.Build(); break;
                case DatabaseType.SQLite: conventionSet = SqliteConventionSetBuilder.Build(); break;
                default: throw new Exception("暂不支持该数据库!");
            }
            ModelBuilder modelBuilder = new ModelBuilder(conventionSet);
            foreach(var x in _entityTypeMap.Values)
            {
                modelBuilder.Model.AddEntityType(x);
            }

            if (rules != null)
            {
                foreach (var rule in rules)
                {
                    modelBuilder.Entity(rule.MappingType).ToTable(rule.TableName);
                }
            }
            return modelBuilder.FinalizeModel();
        }
        private static string GetCompiledModelIdentity(string conStr, DatabaseType dbType, ICollection<TableMapperRule> rules)
        {
            string rulestring = string.Empty;
            if (rules != null)
            {
                foreach (var rule in rules)
                {
                    rulestring += rule.TableName;
                }
            }
            return $"{dbType.ToString()}{conStr}{rulestring}";
        }
        private static readonly ConcurrentDictionary<string, object> _lockDic
            = new ConcurrentDictionary<string, object>();

        #endregion

        #region 数据结构

        #endregion
    }
}
