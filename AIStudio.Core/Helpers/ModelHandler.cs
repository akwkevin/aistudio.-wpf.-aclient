using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AIStudio.Core
{
    public class ModelHandler<T> where T : new()
    {
        /// <summary>
        /// Table转换成实体
        /// </summary>
        /// <param name="dt">表</param>
        /// <returns></returns>
        public static List<T> FillModel(DataTable dt)
        {
            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }

            Dictionary<PropertyInfo, string> dic = new Dictionary<PropertyInfo, string>();
            if (FillByDisplayName)
            {
                //获取所有属性
                PropertyInfo[] properties = typeof(T).GetProperties();

                foreach (var prop in properties)
                {
                    var attrs = prop.GetCustomAttributes(typeof(DisplayNameAttribute), true);
                    if (attrs != null)
                    {
                        var displayName = ((DisplayNameAttribute)attrs[0]).DisplayName;
                        dic.Add(prop, displayName);
                    }
                }
            }

            List<T> modelList = new List<T>();
            foreach (DataRow dr in dt.Rows)
            {
                //T model = (T)Activator.CreateInstance(typeof(T));  
                T model = new T();
                for (int i = 0; i < dr.Table.Columns.Count; i++)
                {
                    PropertyInfo propertyInfo = model.GetType().GetProperty(dr.Table.Columns[i].ColumnName);
                    if (FillByDisplayName && propertyInfo == null)
                    {
                        propertyInfo = dic.Where(p => p.Value == dr.Table.Columns[i].ColumnName).Select(p => p.Key).FirstOrDefault();
                    }

                    if (propertyInfo != null && dr[i] != DBNull.Value)
                    {
                        object value = null;
                        if (propertyInfo.PropertyType.ToString().Contains("System.Nullable"))
                        {
                            value = Convert.ChangeType(dr[i], Nullable.GetUnderlyingType(propertyInfo.PropertyType));
                        }
                        else
                        {
                            value = Convert.ChangeType(dr[i], propertyInfo.PropertyType);
                        }
                        propertyInfo.SetValue(model, value, null);
                    }

                }

                modelList.Add(model);
            }
            return modelList;
        }

        /// <summary>
        /// 实体类转换成DataTable
        /// </summary>
        /// <param name="modelList">实体类列表</param>
        /// <returns></returns>
        public static DataTable FillDataTable(List<T> modelList)
        {
            if (modelList == null || modelList.Count == 0)
            {
                return null;
            }
            DataTable dt = CreateData(modelList[0]);

            foreach (T model in modelList)
            {
                DataRow dataRow = dt.NewRow();
                foreach (PropertyInfo prop in typeof(T).GetProperties())
                {
                    string parameterName = prop.Name;
                    if (FillByDisplayName == true && prop.IsDefined(typeof(DisplayNameAttribute), false))
                    {
                        DisplayNameAttribute attribute = (DisplayNameAttribute)prop.GetCustomAttribute(typeof(DisplayNameAttribute), false);
                        parameterName = string.IsNullOrEmpty(attribute.DisplayName) ? prop.Name : attribute.DisplayName;
                    }
                    dataRow[parameterName] = prop.GetValue(model, null)?? DBNull.Value;
                }
                dt.Rows.Add(dataRow);
            }
            return dt;
        }

        /// <summary>
        /// 根据实体类得到表结构
        /// </summary>
        /// <param name="model">实体类</param>
        /// <returns></returns>
        private static DataTable CreateData(T model)
        {
            DataTable dataTable = new DataTable();
            foreach (PropertyInfo prop in typeof(T).GetProperties())
            {
                string parameterName = prop.Name;
                if (FillByDisplayName == true && prop.IsDefined(typeof(DisplayNameAttribute), false))
                {
                    DisplayNameAttribute attribute = (DisplayNameAttribute)prop.GetCustomAttribute(typeof(DisplayNameAttribute), false);
                    parameterName = string.IsNullOrEmpty(attribute.DisplayName) ? prop.Name : attribute.DisplayName;
                }

                var propertyType = prop.PropertyType;
                if ((propertyType.IsGenericType) && (propertyType.GetGenericTypeDefinition() == typeof(Nullable<>)))
                    propertyType = propertyType.GetGenericArguments()[0];

                dataTable.Columns.Add(new DataColumn(parameterName, propertyType));
            }
            return dataTable;
        }

        public static bool FillByDisplayName
        {
            get; set;
        } = true;
    }
}
