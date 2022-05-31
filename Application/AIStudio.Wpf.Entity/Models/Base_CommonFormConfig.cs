using AIStudio.Core;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Windows;

namespace AIStudio.Wpf.Entity.Models
{
    /// <summary>
    /// Base_CommonFormConfig
    /// </summary>
    [Table("Base_CommonFormConfig")]
    public class Base_CommonFormConfig
    {

        /// <summary>
        /// 自然主键
        /// </summary>
        [Key, Column(Order = 1)]
        public String Id { get; set; }

        /// <summary>
        /// 表名
        /// </summary>
        public String Table { get; set; }

        /// <summary>
        /// 列头
        /// </summary>
        public String Header { get; set; }

        /// <summary>
        /// 属性名
        /// </summary>
        public String PropertyName { get; set; }

        /// <summary>
        /// 属性类型
        /// </summary>
        public String PropertyType{ get; set; }

        /// <summary>
        /// 显示索引
        /// </summary>
        public Int32 DisplayIndex { get; set; }

        /// <summary>
        /// 配置类型 查询=0，列表=1
        /// </summary>
        public Int32 Type { get; set; }

        /// <summary>
        /// 格式化
        /// </summary>
        public String StringFormat { get; set; }

        /// <summary>
        /// 是否显示 Visible = 0,Hidden = 1,Collapsed = 2
        /// </summary>
        public Visibility Visibility { get; set; }

        /// <summary>
        /// 控件类型，仅控件框使用
        /// </summary>
        public ControlType ControlType { get; set; }

        /// <summary>
        /// 只读
        /// </summary>
        public Boolean IsReadOnly { get; set; }

        /// <summary>
        /// 必输项
        /// </summary>
        public Boolean IsRequired { get; set; }

        /// <summary>
        /// 字典名
        /// </summary>
        public String ItemSource { get; set; }

        /// <summary>
        /// 默认值
        /// </summary>
        public String Value { get; set; }

        /// <summary>
        /// 正则校验表达式
        /// </summary>
        public string Regex { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// 排序名
        /// </summary>
        public String SortMemberPath { get; set; }

        /// <summary>
        /// 转换器
        /// </summary>
        public String Converter { get; set; }

        /// <summary>
        /// 转换参数
        /// </summary>
        public String ConverterParameter { get; set; }

        /// <summary>
        /// 对齐方式 Left = 0,Center = 1,Right = 2,Stretch = 3
        /// </summary>
        public HorizontalAlignment HorizontalAlignment { get; set; }

        /// <summary>
        /// 最大宽度
        /// </summary>
        public Double MaxWidth { get; set; }

        /// <summary>
        /// 最小宽度
        /// </summary>
        public Double MinWidth { get; set; }

        /// <summary>
        /// 列表宽度
        /// </summary>
        public String Width { get; set; }

        /// <summary>
        /// 是否可以重排
        /// </summary>
        public Boolean CanUserReorder { get; set; }

        /// <summary>
        /// 是否可以调整大小
        /// </summary>
        public Boolean CanUserResize { get; set; }

        /// <summary>
        /// 是否可以排序
        /// </summary>
        public Boolean CanUserSort { get; set; }

        /// <summary>
        /// 单元格样式，暂未实现
        /// </summary>
        public String CellStyle { get; set; }

        /// <summary>
        /// 列头样式，赞未实现
        /// </summary>
        public String HeaderStyle { get; set; }

        /// <summary>
        /// 背景颜色触发公式
        /// </summary>
        public String BackgroundExpression { get; set; }

        /// <summary>
        /// 前景颜色触发公式
        /// </summary>
        public String ForegroundExpression { get; set; }

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