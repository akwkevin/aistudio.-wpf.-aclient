using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AIStudio.Wpf.Entity.Models
{
    public partial class ColderAdminAntdVueContext : DbContext
    {
        public ColderAdminAntdVueContext()
        {
        }

        public ColderAdminAntdVueContext(DbContextOptions<ColderAdminAntdVueContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Base_Action> Base_Action { get; set; }
        public virtual DbSet<Base_AppSecret> Base_AppSecret { get; set; }
        public virtual DbSet<Base_DbLink> Base_DbLink { get; set; }
        public virtual DbSet<Base_Department> Base_Department { get; set; }
        public virtual DbSet<Base_Role> Base_Role { get; set; }
        public virtual DbSet<Base_RoleAction> Base_RoleAction { get; set; }
        public virtual DbSet<Base_User> Base_User { get; set; }
        public virtual DbSet<Base_UserLog> Base_UserLog { get; set; }
        public virtual DbSet<Base_UserRole> Base_UserRole { get; set; }
        public virtual DbSet<D_Notice> D_Notice { get; set; }
        public virtual DbSet<D_NoticeReadingMarks> D_NoticeReadingMarks { get; set; }
        public virtual DbSet<D_UserGroup> D_UserGroup { get; set; }
        public virtual DbSet<D_UserMail> D_UserMail { get; set; }
        public virtual DbSet<D_UserMessage> D_UserMessage { get; set; }
        public virtual DbSet<D_UserMessage_202102> D_UserMessage_202102 { get; set; }
        public virtual DbSet<D_UserMessage_202103> D_UserMessage_202103 { get; set; }
        public virtual DbSet<D_UserMessage_202104> D_UserMessage_202104 { get; set; }
        public virtual DbSet<OA_DefForm> OA_DefForm { get; set; }
        public virtual DbSet<OA_DefType> OA_DefType { get; set; }
        public virtual DbSet<OA_UserForm> OA_UserForm { get; set; }
        public virtual DbSet<OA_UserFormStep> OA_UserFormStep { get; set; }
        public virtual DbSet<Quartz_Task> Quartz_Task { get; set; }

    }
}
