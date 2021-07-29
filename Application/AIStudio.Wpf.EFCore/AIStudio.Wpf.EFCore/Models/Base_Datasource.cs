using AIStudio.Core.Models;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace AIStudio.Wpf.EFCore.Models
{ 
    /// <summary>
    /// 常用数据配置表
    /// </summary>

    public partial class Base_Datasource : BindableBase
    {

        /// <summary>
        /// 主键
        /// </summary>
        [Description("主键")]
        public String Id { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
        [Description("编号")]
        public String Code { get; set; }



        private string name;
        /// <summary>
        /// 名称
        /// </summary>
        [Description("名称")]
        public string Name
        {

            get { return name; }
            set
            {
                if (value != name)
                {
                    name = value;
                    RaisePropertyChanged("Name");
                }
            }
        }


        /// <summary>
        /// 数据库主键
        /// </summary>
        [Description("数据源")]
        public String DbLinkId { get; set; }

        /// <summary>
        /// sql语句
        /// </summary>
        [Description("sql语句")]
        public String Sql { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Description("备注")]
        public String Description { get; set; }

        /// <summary>
        /// 创建人主键
        /// </summary>
        [Description("创建人主键")]
        public String CreatorId { get; set; }

        /// <summary>
        /// 创建人名字
        /// </summary>
        [Description("创建人")]
        public String CreatorName { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        [Description("创建日期")]
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 修改人主键
        /// </summary>
        [Description("修改人主键")]
        public String ModifyId { get; set; }

        /// <summary>
        /// 修改人名字
        /// </summary>
        [Description("修改人")]
        public String ModifyName { get; set; }

        /// <summary>
        /// 修改日期
        /// </summary>
        [Description("修改日期")]
        public DateTime? ModifyTime { get; set; } 

    }
}