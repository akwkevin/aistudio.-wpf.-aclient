using System;
using System.Collections.Generic;
using System.Text;

namespace AIStudio.Wpf.DataRepository
{
    public class TableMapperRule
    {
        /// <summary>
        /// 需要重新映射的类
        /// </summary>
        public Type MappingType
        {
            get; set;
        }

        /// <summary>
        /// 映射的表名
        /// </summary>
        public string TableName { get; set; }
    }
}
