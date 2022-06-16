using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AIStudio.Wpf.Entity.Models
{
    /// <summary>
    /// Base_Test
    /// </summary>
    [Table("Base_Test")]
    public class Base_Test
    {

        /// <summary>
        /// 自然主键
        /// </summary>
        [Key, Column(Order = 1)]
        public String Id { get; set; }

        /// <summary>
        /// 父级Id
        /// </summary>
        public String ParentId { get; set; }

        /// <summary>
        /// 类型,菜单=0,页面=1,权限=2
        /// </summary>
        public Int32 Type { get; set; }

        /// <summary>
        /// 权限名/菜单名
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        /// 菜单地址
        /// </summary>
        public String Url { get; set; }

        /// <summary>
        /// 权限值
        /// </summary>
        public String Value { get; set; }

        /// <summary>
        /// 是否需要权限(仅页面有效)
        /// </summary>
        public Boolean NeedTest { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        public String Icon { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public Int32 Sort { get; set; }

        /// <summary>
        /// 否已删除
        /// </summary>
        public Boolean Deleted { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? ModifyTime { get; set; }

        /// <summary>
        /// 创建人Id
        /// </summary>
        public String CreatorId { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public String CreatorName { get; set; }

        /// <summary>
        /// 修改人Id
        /// </summary>
        public String ModifyId { get; set; }

        /// <summary>
        /// 修改人
        /// </summary>
        public String ModifyName { get; set; }

        /// <summary>
        /// 租户Id
        /// </summary>
        public String TenantId { get; set; }

    }
}