using System;
using System.ComponentModel.DataAnnotations;

namespace AIStudio.Wpf.Entity.Models
{

    public class Base_LogException 
    {
        /// <summary>
        /// 自然主键
        /// </summary>
        public string Id { get; set; }

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
        public string TenantId { get; set; }
        /// <summary>
        /// 异常事件Id
        /// </summary>
        public string EventId { get; set; }

        /// <summary>
        /// 异常名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 异常消息
        /// </summary>
        public string Message { get; set; }

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
        /// 异常源
        /// </summary>
        public string ExceptionSource { get; set; }

        /// <summary>
        /// 堆栈信息
        /// </summary>
        public string StackTrace { get; set; }

        /// <summary>
        /// 请求参数
        /// </summary>
        public string Parameters { get; set; }

        /// <summary>
        /// 异常时间
        /// </summary>
        public DateTime LogTime { get; set; }
    }
}
