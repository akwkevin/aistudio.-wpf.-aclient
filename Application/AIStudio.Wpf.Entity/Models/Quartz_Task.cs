using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AIStudio.Wpf.Entity.Models
{
    public partial class Quartz_Task
    {
        public string Id { get; set; }
        /// <summary>
        /// 作业名称
        /// </summary>
        [MaxLength(255)]
        public string TaskName { get; set; }

        [MaxLength(255)]
        public string GroupName { get; set; }

        /// <summary>
        /// 启用状态
        /// </summary>
        public bool IsEnabled { get; set; } = true;

        /// <summary>
        /// Cron表达式
        /// </summary>
        [MaxLength(50)]
        public string Cron { get; set; }

        /// <summary>
        /// 任务类名
        /// </summary>
        [MaxLength(500)]
        public string ActionClass { get; set; }

        [MaxLength(500)]
        public string Remark { get; set; }

        [MaxLength(50)]
        public string RequestType { get; set; }

        [MaxLength(500)]
        public string ApiUrl { get; set; }

        [MaxLength(50)]
        public string AuthKey { get; set; }

        [MaxLength(500)]
        public string AuthValue { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? ModifyTime { get; set; }
        public string CreatorId { get; set; }
        public string CreatorName { get; set; }
        public string ModifyId { get; set; }
        public string ModifyName { get; set; }
        public string TenantId { get; set; }
    }
}
