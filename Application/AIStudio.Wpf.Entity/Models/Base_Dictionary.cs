using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AIStudio.Wpf.Entity.Models
{
    /// <summary>
    /// Base_Dictionary
    /// </summary>
    [Table("Base_Dictionary")]
    public class Base_Dictionary
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
        /// 类型,字典项=0,数据集=1
        /// </summary>
        public Int32 Type { get; set; }

        /// <summary>
        /// 数据类型
        /// </summary>
        public Int32 ControlType { get; set; }

        /// <summary>
        /// 显示值
        /// </summary>
        public String Text { get; set; }

        /// <summary>
        /// 数据值
        /// </summary>
        public String Value { get; set; }

        /// <summary>
        /// 字典名相同，使用Code区分，暂时没启用
        /// </summary>
        public String Code { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public String Remark { get; set; }

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