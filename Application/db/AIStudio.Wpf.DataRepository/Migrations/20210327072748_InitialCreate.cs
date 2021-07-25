using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AIStudio.Wpf.DataRepository.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Base_Action",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ParentId = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    NeedAction = table.Column<bool>(nullable: false),
                    Icon = table.Column<string>(nullable: true),
                    Sort = table.Column<int>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    CreatorId = table.Column<string>(nullable: true),
                    CreatorName = table.Column<string>(nullable: true),
                    ModifyId = table.Column<string>(nullable: true),
                    ModifyName = table.Column<string>(nullable: true),
                    TenantId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Base_Action", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Base_AppSecret",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AppId = table.Column<string>(nullable: true),
                    AppSecret = table.Column<string>(nullable: true),
                    AppName = table.Column<string>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    CreatorId = table.Column<string>(nullable: true),
                    CreatorName = table.Column<string>(nullable: true),
                    ModifyId = table.Column<string>(nullable: true),
                    ModifyName = table.Column<string>(nullable: true),
                    TenantId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Base_AppSecret", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Base_DbLink",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    LinkName = table.Column<string>(nullable: true),
                    ConnectionStr = table.Column<string>(nullable: true),
                    DbType = table.Column<string>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    CreatorId = table.Column<string>(nullable: true),
                    CreatorName = table.Column<string>(nullable: true),
                    ModifyId = table.Column<string>(nullable: true),
                    ModifyName = table.Column<string>(nullable: true),
                    TenantId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Base_DbLink", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Base_Department",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ParentId = table.Column<string>(nullable: true),
                    ParentIds = table.Column<string>(nullable: true),
                    ParentNames = table.Column<string>(nullable: true),
                    Level = table.Column<int>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    CreatorId = table.Column<string>(nullable: true),
                    CreatorName = table.Column<string>(nullable: true),
                    ModifyId = table.Column<string>(nullable: true),
                    ModifyName = table.Column<string>(nullable: true),
                    TenantId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Base_Department", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Base_Role",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    RoleName = table.Column<string>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    CreatorId = table.Column<string>(nullable: true),
                    CreatorName = table.Column<string>(nullable: true),
                    ModifyId = table.Column<string>(nullable: true),
                    ModifyName = table.Column<string>(nullable: true),
                    TenantId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Base_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Base_RoleAction",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: true),
                    ActionId = table.Column<string>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    CreatorId = table.Column<string>(nullable: true),
                    CreatorName = table.Column<string>(nullable: true),
                    ModifyId = table.Column<string>(nullable: true),
                    ModifyName = table.Column<string>(nullable: true),
                    TenantId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Base_RoleAction", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Base_User",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    RealName = table.Column<string>(nullable: true),
                    Sex = table.Column<int>(nullable: false),
                    Birthday = table.Column<DateTime>(nullable: true),
                    DepartmentId = table.Column<string>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    CreatorId = table.Column<string>(nullable: true),
                    CreatorName = table.Column<string>(nullable: true),
                    ModifyId = table.Column<string>(nullable: true),
                    ModifyName = table.Column<string>(nullable: true),
                    TenantId = table.Column<string>(nullable: true),
                    Avatar = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Base_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Base_UserLog",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<string>(nullable: true),
                    CreatorName = table.Column<string>(nullable: true),
                    LogType = table.Column<string>(nullable: true),
                    LogContent = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Base_UserLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Base_UserRole",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<string>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    RoleId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Base_UserRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "D_UserGroup",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserIds = table.Column<string>(nullable: true),
                    UserNames = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    Remark = table.Column<string>(nullable: true),
                    Appendix = table.Column<string>(nullable: true),
                    Avatar = table.Column<string>(nullable: true),
                    ManagerIds = table.Column<string>(nullable: true),
                    ManagerNames = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    CreatorId = table.Column<string>(nullable: true),
                    CreatorName = table.Column<string>(nullable: true),
                    ModifyId = table.Column<string>(nullable: true),
                    ModifyName = table.Column<string>(nullable: true),
                    TenantId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_D_UserGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "D_UserMail",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    CCIds = table.Column<string>(nullable: true),
                    CCNames = table.Column<string>(nullable: true),
                    ReadingMarks = table.Column<string>(nullable: true),
                    StarMark = table.Column<bool>(nullable: false),
                    Appendix = table.Column<string>(nullable: true),
                    IsDraft = table.Column<bool>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    CreatorId = table.Column<string>(nullable: true),
                    CreatorName = table.Column<string>(nullable: true),
                    ModifyId = table.Column<string>(nullable: true),
                    ModifyName = table.Column<string>(nullable: true),
                    TenantId = table.Column<string>(nullable: true),
                    UserIds = table.Column<string>(nullable: true),
                    UserNames = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_D_UserMail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "D_UserMessage",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    ReadingMarks = table.Column<string>(nullable: true),
                    GroupId = table.Column<string>(nullable: true),
                    GroupName = table.Column<string>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    CreatorId = table.Column<string>(nullable: true),
                    CreatorName = table.Column<string>(nullable: true),
                    ModifyId = table.Column<string>(nullable: true),
                    ModifyName = table.Column<string>(nullable: true),
                    TenantId = table.Column<string>(nullable: true),
                    UserIds = table.Column<string>(nullable: true),
                    UserNames = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_D_UserMessage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "D_UserMessage_202103",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    ReadingMarks = table.Column<string>(nullable: true),
                    GroupId = table.Column<string>(nullable: true),
                    GroupName = table.Column<string>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    CreatorId = table.Column<string>(nullable: true),
                    CreatorName = table.Column<string>(nullable: true),
                    ModifyId = table.Column<string>(nullable: true),
                    ModifyName = table.Column<string>(nullable: true),
                    TenantId = table.Column<string>(nullable: true),
                    UserIds = table.Column<string>(nullable: true),
                    UserNames = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_D_UserMessage_202103", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "D_UserMessage_202104",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    ReadingMarks = table.Column<string>(nullable: true),
                    GroupId = table.Column<string>(nullable: true),
                    GroupName = table.Column<string>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    CreatorId = table.Column<string>(nullable: true),
                    CreatorName = table.Column<string>(nullable: true),
                    ModifyId = table.Column<string>(nullable: true),
                    ModifyName = table.Column<string>(nullable: true),
                    TenantId = table.Column<string>(nullable: true),
                    UserIds = table.Column<string>(nullable: true),
                    UserNames = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_D_UserMessage_202104", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OA_DefForm",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    WorkflowJSON = table.Column<string>(nullable: true),
                    JSONId = table.Column<string>(nullable: true),
                    JSONVersion = table.Column<int>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true),
                    Sort = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Value = table.Column<string>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    CreatorId = table.Column<string>(nullable: true),
                    CreatorName = table.Column<string>(nullable: true),
                    ModifyId = table.Column<string>(nullable: true),
                    ModifyName = table.Column<string>(nullable: true),
                    TenantId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OA_DefForm", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OA_DefType",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Unit = table.Column<string>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    CreatorId = table.Column<string>(nullable: true),
                    CreatorName = table.Column<string>(nullable: true),
                    ModifyId = table.Column<string>(nullable: true),
                    ModifyName = table.Column<string>(nullable: true),
                    TenantId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OA_DefType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OA_UserForm",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    DefFormId = table.Column<string>(nullable: true),
                    DefFormName = table.Column<string>(nullable: true),
                    DefFormJsonId = table.Column<string>(nullable: true),
                    DefFormJsonVersion = table.Column<int>(nullable: false),
                    Grade = table.Column<int>(nullable: false),
                    Flag = table.Column<double>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    Appendix = table.Column<string>(nullable: true),
                    ExtendJSON = table.Column<string>(nullable: true),
                    ApplicantUser = table.Column<string>(nullable: true),
                    ApplicantUserId = table.Column<string>(nullable: true),
                    ApplicantDepartment = table.Column<string>(nullable: true),
                    ApplicantDepartmentId = table.Column<string>(nullable: true),
                    ApplicantRole = table.Column<string>(nullable: true),
                    ApplicantRoleId = table.Column<string>(nullable: true),
                    UserRoleNames = table.Column<string>(nullable: true),
                    UserRoleIds = table.Column<string>(nullable: true),
                    AlreadyUserNames = table.Column<string>(nullable: true),
                    AlreadyUserIds = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    SubType = table.Column<string>(nullable: true),
                    Unit = table.Column<string>(nullable: true),
                    ExpectedDate = table.Column<DateTime>(nullable: true),
                    CurrentNode = table.Column<string>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    CreatorId = table.Column<string>(nullable: true),
                    CreatorName = table.Column<string>(nullable: true),
                    ModifyId = table.Column<string>(nullable: true),
                    ModifyName = table.Column<string>(nullable: true),
                    TenantId = table.Column<string>(nullable: true),
                    UserIds = table.Column<string>(nullable: true),
                    UserNames = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OA_UserForm", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OA_UserFormStep",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserFormId = table.Column<string>(nullable: true),
                    RoleIds = table.Column<string>(nullable: true),
                    RoleNames = table.Column<string>(nullable: true),
                    Remarks = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    StepName = table.Column<string>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    CreatorId = table.Column<string>(nullable: true),
                    CreatorName = table.Column<string>(nullable: true),
                    ModifyId = table.Column<string>(nullable: true),
                    ModifyName = table.Column<string>(nullable: true),
                    TenantId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OA_UserFormStep", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Quartz_Task",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    TaskName = table.Column<string>(nullable: true),
                    GroupName = table.Column<string>(nullable: true),
                    Interval = table.Column<string>(nullable: true),
                    ApiUrl = table.Column<string>(nullable: true),
                    AuthKey = table.Column<string>(nullable: true),
                    AuthValue = table.Column<string>(nullable: true),
                    Describe = table.Column<string>(nullable: true),
                    RequestType = table.Column<string>(nullable: true),
                    LastRunTime = table.Column<DateTime>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    ForbidOperate = table.Column<bool>(nullable: false),
                    ForbidEdit = table.Column<bool>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    CreatorId = table.Column<string>(nullable: true),
                    CreatorName = table.Column<string>(nullable: true),
                    ModifyId = table.Column<string>(nullable: true),
                    ModifyName = table.Column<string>(nullable: true),
                    TenantId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quartz_Task", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Base_Action");

            migrationBuilder.DropTable(
                name: "Base_AppSecret");

            migrationBuilder.DropTable(
                name: "Base_DbLink");

            migrationBuilder.DropTable(
                name: "Base_Department");

            migrationBuilder.DropTable(
                name: "Base_Role");

            migrationBuilder.DropTable(
                name: "Base_RoleAction");

            migrationBuilder.DropTable(
                name: "Base_User");

            migrationBuilder.DropTable(
                name: "Base_UserLog");

            migrationBuilder.DropTable(
                name: "Base_UserRole");

            migrationBuilder.DropTable(
                name: "D_UserGroup");

            migrationBuilder.DropTable(
                name: "D_UserMail");

            migrationBuilder.DropTable(
                name: "D_UserMessage");

            migrationBuilder.DropTable(
                name: "D_UserMessage_202103");

            migrationBuilder.DropTable(
                name: "D_UserMessage_202104");

            migrationBuilder.DropTable(
                name: "OA_DefForm");

            migrationBuilder.DropTable(
                name: "OA_DefType");

            migrationBuilder.DropTable(
                name: "OA_UserForm");

            migrationBuilder.DropTable(
                name: "OA_UserFormStep");

            migrationBuilder.DropTable(
                name: "Quartz_Task");
        }
    }
}
