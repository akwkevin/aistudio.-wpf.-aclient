using System;
using System.ComponentModel.DataAnnotations;

namespace AIStudio.Wpf.Entity.Models
{
    /// <summary>
    /// 访问日志表
    /// </summary>
    public class Base_LogVisit 
    {

        public virtual string Id { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 创建人Id
        /// </summary>
        [MaxLength(50)]
        public string CreatorId { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        [MaxLength(255)]
        public string CreatorName { get; set; }

        /// <summary>
        /// 租户Id
        /// </summary>
        [MaxLength(50)]
        public virtual string TenantId { get; set; }

        /// <summary>
        /// 日志名称
        /// </summary>
        [MaxLength(128)]
        public string Name { get; set; } = "";

        /// <summary>
        /// 是否执行成功
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// 具体消息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 浏览器
        /// </summary>
        [MaxLength(512)]
        public string Browser { get; set; }

        /// <summary>
        /// 操作系统
        /// </summary>
        public string OperatingSystem { get; set; }

        /// <summary>
        /// IP
        /// </summary>
        [MaxLength(32)]
        public string Ip { get; set; }

        /// <summary>
        /// 完整请求地址
        /// </summary>
        [MaxLength(2048)]
        public string Url { get; set; }

        /// <summary>
        /// 请求路径
        /// </summary>
        [MaxLength(2048)]
        public string Path { get; set; }

        /// <summary>
        /// 类名称
        /// </summary>
        [MaxLength(256)]
        public string ClassName { get; set; }

        /// <summary>
        /// 方法名称
        /// </summary>
        [MaxLength(256)]
        public string MethodName { get; set; }

        /// <summary>
        /// 请求方式
        /// </summary>
        [MaxLength(16)]
        public string RequestMethod { get; set; }

        /// <summary>
        /// 请求Body
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// 返回结果
        /// </summary>
        public string Result { get; set; }

        /// <summary>
        /// 耗时（毫秒）
        /// </summary>
        public long ElapsedTime { get; set; }

        /// <summary>
        /// 日志时间
        /// </summary>
        public DateTime LogTime { get; set; }
    }
}
