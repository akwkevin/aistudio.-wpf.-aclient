USE [Colder.Admin.AntdVue]
GO
/****** Object:  Schema [wfc]    Script Date: 2022/6/1 15:49:29 ******/
CREATE SCHEMA [wfc]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 2022/6/1 15:49:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Base_Action]    Script Date: 2022/6/1 15:49:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Base_Action](
	[Id] [nvarchar](50) NOT NULL,
	[ParentId] [nvarchar](max) NULL,
	[Type] [int] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Url] [nvarchar](max) NULL,
	[Value] [nvarchar](max) NULL,
	[NeedAction] [bit] NOT NULL,
	[Icon] [nvarchar](max) NULL,
	[Sort] [int] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[CreateTime] [datetime2](7) NOT NULL,
	[ModifyTime] [datetime2](7) NULL,
	[CreatorId] [nvarchar](50) NULL,
	[CreatorName] [nvarchar](255) NULL,
	[ModifyId] [nvarchar](50) NULL,
	[ModifyName] [nvarchar](255) NULL,
	[TenantId] [nvarchar](50) NULL,
 CONSTRAINT [PK_Base_Action] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Base_AppSecret]    Script Date: 2022/6/1 15:49:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Base_AppSecret](
	[Id] [nvarchar](50) NOT NULL,
	[AppId] [nvarchar](max) NULL,
	[AppSecret] [nvarchar](max) NULL,
	[AppName] [nvarchar](max) NULL,
	[Deleted] [bit] NOT NULL,
	[CreateTime] [datetime2](7) NOT NULL,
	[ModifyTime] [datetime2](7) NULL,
	[CreatorId] [nvarchar](50) NULL,
	[CreatorName] [nvarchar](255) NULL,
	[ModifyId] [nvarchar](50) NULL,
	[ModifyName] [nvarchar](255) NULL,
	[TenantId] [nvarchar](50) NULL,
 CONSTRAINT [PK_Base_AppSecret] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Base_CommonFormConfig]    Script Date: 2022/6/1 15:49:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Base_CommonFormConfig](
	[Id] [nvarchar](50) NOT NULL,
	[Table] [nvarchar](max) NULL,
	[Header] [nvarchar](max) NULL,
	[PropertyName] [nvarchar](max) NULL,
	[DisplayIndex] [int] NOT NULL,
	[Type] [int] NOT NULL,
	[StringFormat] [nvarchar](max) NULL,
	[Visibility] [int] NOT NULL,
	[ControlType] [int] NOT NULL,
	[IsReadOnly] [bit] NOT NULL,
	[IsRequired] [bit] NOT NULL,
	[ItemSource] [nvarchar](max) NULL,
	[Value] [nvarchar](max) NULL,
	[SortMemberPath] [nvarchar](max) NULL,
	[Converter] [nvarchar](max) NULL,
	[ConverterParameter] [nvarchar](max) NULL,
	[HorizontalAlignment] [int] NOT NULL,
	[MaxWidth] [float] NOT NULL,
	[MinWidth] [float] NOT NULL,
	[Width] [nvarchar](max) NULL,
	[CanUserReorder] [bit] NOT NULL,
	[CanUserResize] [bit] NOT NULL,
	[CanUserSort] [bit] NOT NULL,
	[CellStyle] [nvarchar](max) NULL,
	[BackgroundExpression] [nvarchar](max) NULL,
	[ForegroundExpression] [nvarchar](max) NULL,
	[Deleted] [bit] NOT NULL,
	[CreateTime] [datetime2](7) NOT NULL,
	[ModifyTime] [datetime2](7) NULL,
	[CreatorId] [nvarchar](50) NULL,
	[CreatorName] [nvarchar](255) NULL,
	[ModifyId] [nvarchar](50) NULL,
	[ModifyName] [nvarchar](255) NULL,
	[TenantId] [nvarchar](50) NULL,
	[HeaderStyle] [nvarchar](max) NULL,
	[PropertyType] [nvarchar](max) NULL,
	[ErrorMessage] [nvarchar](max) NULL,
	[Regex] [nvarchar](max) NULL,
 CONSTRAINT [PK_Base_CommonFormConfig] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Base_DbLink]    Script Date: 2022/6/1 15:49:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Base_DbLink](
	[Id] [nvarchar](50) NOT NULL,
	[LinkName] [nvarchar](max) NULL,
	[ConnectionStr] [nvarchar](max) NULL,
	[DbType] [nvarchar](max) NULL,
	[Deleted] [bit] NOT NULL,
	[CreateTime] [datetime2](7) NOT NULL,
	[ModifyTime] [datetime2](7) NULL,
	[CreatorId] [nvarchar](50) NULL,
	[CreatorName] [nvarchar](255) NULL,
	[ModifyId] [nvarchar](50) NULL,
	[ModifyName] [nvarchar](255) NULL,
	[TenantId] [nvarchar](50) NULL,
 CONSTRAINT [PK_Base_DbLink] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Base_Department]    Script Date: 2022/6/1 15:49:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Base_Department](
	[Id] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[ParentId] [nvarchar](max) NULL,
	[ParentIds] [nvarchar](max) NULL,
	[ParentNames] [nvarchar](max) NULL,
	[Level] [int] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[CreateTime] [datetime2](7) NOT NULL,
	[ModifyTime] [datetime2](7) NULL,
	[CreatorId] [nvarchar](50) NULL,
	[CreatorName] [nvarchar](255) NULL,
	[ModifyId] [nvarchar](50) NULL,
	[ModifyName] [nvarchar](255) NULL,
	[TenantId] [nvarchar](50) NULL,
 CONSTRAINT [PK_Base_Department] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Base_Dictionary]    Script Date: 2022/6/1 15:49:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Base_Dictionary](
	[Id] [nvarchar](50) NOT NULL,
	[ParentId] [nvarchar](max) NULL,
	[Type] [int] NOT NULL,
	[Code] [nvarchar](max) NULL,
	[Sort] [int] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[CreateTime] [datetime2](7) NOT NULL,
	[ModifyTime] [datetime2](7) NULL,
	[CreatorId] [nvarchar](50) NULL,
	[CreatorName] [nvarchar](255) NULL,
	[ModifyId] [nvarchar](50) NULL,
	[ModifyName] [nvarchar](255) NULL,
	[TenantId] [nvarchar](50) NULL,
	[Text] [nvarchar](max) NULL,
	[Value] [nvarchar](max) NULL,
	[ControlType] [int] NOT NULL,
	[Remark] [nvarchar](max) NULL,
 CONSTRAINT [PK_Base_Dictionary] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Base_Role]    Script Date: 2022/6/1 15:49:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Base_Role](
	[Id] [nvarchar](50) NOT NULL,
	[RoleName] [nvarchar](max) NULL,
	[Deleted] [bit] NOT NULL,
	[CreateTime] [datetime2](7) NOT NULL,
	[ModifyTime] [datetime2](7) NULL,
	[CreatorId] [nvarchar](50) NULL,
	[CreatorName] [nvarchar](255) NULL,
	[ModifyId] [nvarchar](50) NULL,
	[ModifyName] [nvarchar](255) NULL,
	[TenantId] [nvarchar](50) NULL,
 CONSTRAINT [PK_Base_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Base_RoleAction]    Script Date: 2022/6/1 15:49:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Base_RoleAction](
	[Id] [nvarchar](50) NOT NULL,
	[RoleId] [nvarchar](max) NULL,
	[ActionId] [nvarchar](max) NULL,
	[Deleted] [bit] NOT NULL,
	[CreateTime] [datetime2](7) NOT NULL,
	[ModifyTime] [datetime2](7) NULL,
	[CreatorId] [nvarchar](50) NULL,
	[CreatorName] [nvarchar](255) NULL,
	[ModifyId] [nvarchar](50) NULL,
	[ModifyName] [nvarchar](255) NULL,
	[TenantId] [nvarchar](50) NULL,
 CONSTRAINT [PK_Base_RoleAction] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Base_Test]    Script Date: 2022/6/1 15:49:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Base_Test](
	[Id] [nvarchar](450) NOT NULL,
	[ParentId] [nvarchar](max) NULL,
	[Type] [int] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Url] [nvarchar](max) NULL,
	[Value] [nvarchar](max) NULL,
	[NeedTest] [bit] NOT NULL,
	[Icon] [nvarchar](max) NULL,
	[Sort] [int] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[CreateTime] [datetime2](7) NOT NULL,
	[ModifyTime] [datetime2](7) NULL,
	[CreatorId] [nvarchar](max) NULL,
	[CreatorName] [nvarchar](max) NULL,
	[ModifyId] [nvarchar](max) NULL,
	[ModifyName] [nvarchar](max) NULL,
	[TenantId] [nvarchar](max) NULL,
 CONSTRAINT [PK_Base_Test] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Base_User]    Script Date: 2022/6/1 15:49:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Base_User](
	[Id] [nvarchar](50) NOT NULL,
	[UserName] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[RealName] [nvarchar](max) NULL,
	[Sex] [int] NOT NULL,
	[Birthday] [datetime2](7) NULL,
	[DepartmentId] [nvarchar](max) NULL,
	[Deleted] [bit] NOT NULL,
	[CreateTime] [datetime2](7) NOT NULL,
	[ModifyTime] [datetime2](7) NULL,
	[CreatorId] [nvarchar](50) NULL,
	[CreatorName] [nvarchar](255) NULL,
	[ModifyId] [nvarchar](50) NULL,
	[ModifyName] [nvarchar](255) NULL,
	[TenantId] [nvarchar](50) NULL,
	[Avatar] [nvarchar](500) NULL,
	[PhoneNumber] [nvarchar](255) NULL,
 CONSTRAINT [PK_Base_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Base_UserLog]    Script Date: 2022/6/1 15:49:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Base_UserLog](
	[Id] [nvarchar](450) NOT NULL,
	[CreateTime] [datetime2](7) NOT NULL,
	[CreatorId] [nvarchar](max) NULL,
	[CreatorName] [nvarchar](max) NULL,
	[LogType] [nvarchar](max) NULL,
	[LogContent] [nvarchar](max) NULL,
 CONSTRAINT [PK_Base_UserLog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Base_UserRole]    Script Date: 2022/6/1 15:49:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Base_UserRole](
	[Id] [nvarchar](450) NOT NULL,
	[CreateTime] [datetime2](7) NOT NULL,
	[CreatorId] [nvarchar](max) NULL,
	[Deleted] [bit] NOT NULL,
	[UserId] [nvarchar](max) NULL,
	[RoleId] [nvarchar](max) NULL,
 CONSTRAINT [PK_Base_UserRole] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[D_Notice]    Script Date: 2022/6/1 15:49:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[D_Notice](
	[Id] [nvarchar](50) NOT NULL,
	[Title] [nvarchar](max) NULL,
	[Type] [int] NOT NULL,
	[Appendix] [nvarchar](max) NULL,
	[Deleted] [bit] NOT NULL,
	[CreateTime] [datetime2](7) NOT NULL,
	[ModifyTime] [datetime2](7) NULL,
	[CreatorId] [nvarchar](50) NULL,
	[CreatorName] [nvarchar](255) NULL,
	[ModifyId] [nvarchar](50) NULL,
	[ModifyName] [nvarchar](255) NULL,
	[TenantId] [nvarchar](50) NULL,
	[Text] [nvarchar](max) NULL,
	[Status] [int] NOT NULL,
	[Mode] [int] NOT NULL,
	[AnyId] [nvarchar](max) NULL,
 CONSTRAINT [PK_D_Notice] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[D_NoticeReadingMarks]    Script Date: 2022/6/1 15:49:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[D_NoticeReadingMarks](
	[Id] [nvarchar](50) NOT NULL,
	[NoticeId] [nvarchar](max) NULL,
	[Deleted] [bit] NOT NULL,
	[CreateTime] [datetime2](7) NOT NULL,
	[ModifyTime] [datetime2](7) NULL,
	[CreatorId] [nvarchar](50) NULL,
	[CreatorName] [nvarchar](255) NULL,
	[ModifyId] [nvarchar](50) NULL,
	[ModifyName] [nvarchar](255) NULL,
	[TenantId] [nvarchar](50) NULL,
 CONSTRAINT [PK_D_NoticeReadingMarks] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[D_UserGroup]    Script Date: 2022/6/1 15:49:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[D_UserGroup](
	[Id] [nvarchar](50) NOT NULL,
	[UserIds] [nvarchar](max) NULL,
	[UserNames] [nvarchar](max) NULL,
	[Title] [nvarchar](255) NULL,
	[Type] [int] NOT NULL,
	[Remark] [nvarchar](max) NULL,
	[Appendix] [nvarchar](max) NULL,
	[Avatar] [nvarchar](500) NULL,
	[ManagerIds] [nvarchar](max) NULL,
	[ManagerNames] [nvarchar](max) NULL,
	[Name] [nvarchar](50) NULL,
	[Deleted] [bit] NOT NULL,
	[CreateTime] [datetime2](7) NOT NULL,
	[ModifyTime] [datetime2](7) NULL,
	[CreatorId] [nvarchar](50) NULL,
	[CreatorName] [nvarchar](255) NULL,
	[ModifyId] [nvarchar](50) NULL,
	[ModifyName] [nvarchar](255) NULL,
	[TenantId] [nvarchar](50) NULL,
 CONSTRAINT [PK_D_UserGroup] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[D_UserMail]    Script Date: 2022/6/1 15:49:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[D_UserMail](
	[Id] [nvarchar](50) NOT NULL,
	[Title] [nvarchar](max) NULL,
	[Type] [int] NOT NULL,
	[CCIds] [nvarchar](max) NULL,
	[CCNames] [nvarchar](max) NULL,
	[ReadingMarks] [nvarchar](max) NULL,
	[StarMark] [bit] NOT NULL,
	[Appendix] [nvarchar](max) NULL,
	[Deleted] [bit] NOT NULL,
	[CreateTime] [datetime2](7) NOT NULL,
	[ModifyTime] [datetime2](7) NULL,
	[CreatorId] [nvarchar](50) NULL,
	[CreatorName] [nvarchar](255) NULL,
	[ModifyId] [nvarchar](50) NULL,
	[ModifyName] [nvarchar](255) NULL,
	[TenantId] [nvarchar](50) NULL,
	[UserIds] [nvarchar](max) NULL,
	[UserNames] [nvarchar](max) NULL,
	[Text] [nvarchar](max) NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_D_UserMail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[D_UserMessage]    Script Date: 2022/6/1 15:49:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[D_UserMessage](
	[Id] [nvarchar](50) NOT NULL,
	[Type] [int] NOT NULL,
	[ReadingMarks] [nvarchar](max) NULL,
	[GroupId] [nvarchar](max) NULL,
	[GroupName] [nvarchar](max) NULL,
	[Deleted] [bit] NOT NULL,
	[CreateTime] [datetime2](7) NOT NULL,
	[ModifyTime] [datetime2](7) NULL,
	[CreatorId] [nvarchar](50) NULL,
	[CreatorName] [nvarchar](255) NULL,
	[ModifyId] [nvarchar](50) NULL,
	[ModifyName] [nvarchar](255) NULL,
	[TenantId] [nvarchar](50) NULL,
	[UserIds] [nvarchar](max) NULL,
	[UserNames] [nvarchar](max) NULL,
	[Text] [nvarchar](max) NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_D_UserMessage] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Event]    Script Date: 2022/6/1 15:49:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Event](
	[PersistenceId] [bigint] IDENTITY(1,1) NOT NULL,
	[EventId] [uniqueidentifier] NOT NULL,
	[EventName] [nvarchar](200) NULL,
	[EventKey] [nvarchar](200) NULL,
	[EventData] [nvarchar](max) NULL,
	[EventTime] [datetime2](7) NOT NULL,
	[IsProcessed] [bit] NOT NULL,
 CONSTRAINT [PK_Event] PRIMARY KEY CLUSTERED 
(
	[PersistenceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExecutionError]    Script Date: 2022/6/1 15:49:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExecutionError](
	[PersistenceId] [bigint] IDENTITY(1,1) NOT NULL,
	[WorkflowId] [nvarchar](100) NULL,
	[ExecutionPointerId] [nvarchar](100) NULL,
	[ErrorTime] [datetime2](7) NOT NULL,
	[Message] [nvarchar](max) NULL,
 CONSTRAINT [PK_ExecutionError] PRIMARY KEY CLUSTERED 
(
	[PersistenceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExecutionPointer]    Script Date: 2022/6/1 15:49:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExecutionPointer](
	[PersistenceId] [bigint] IDENTITY(1,1) NOT NULL,
	[WorkflowId] [bigint] NOT NULL,
	[Id] [nvarchar](50) NULL,
	[StepId] [int] NOT NULL,
	[Active] [bit] NOT NULL,
	[SleepUntil] [datetime2](7) NULL,
	[PersistenceData] [nvarchar](max) NULL,
	[StartTime] [datetime2](7) NULL,
	[EndTime] [datetime2](7) NULL,
	[EventName] [nvarchar](100) NULL,
	[EventKey] [nvarchar](100) NULL,
	[EventPublished] [bit] NOT NULL,
	[EventData] [nvarchar](max) NULL,
	[StepName] [nvarchar](100) NULL,
	[RetryCount] [int] NOT NULL,
	[Children] [nvarchar](max) NULL,
	[ContextItem] [nvarchar](max) NULL,
	[PredecessorId] [nvarchar](100) NULL,
	[Outcome] [nvarchar](max) NULL,
	[Status] [int] NOT NULL,
	[Scope] [nvarchar](max) NULL,
 CONSTRAINT [PK_ExecutionPointer] PRIMARY KEY CLUSTERED 
(
	[PersistenceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExtensionAttribute]    Script Date: 2022/6/1 15:49:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExtensionAttribute](
	[PersistenceId] [bigint] IDENTITY(1,1) NOT NULL,
	[ExecutionPointerId] [bigint] NOT NULL,
	[AttributeKey] [nvarchar](100) NULL,
	[AttributeValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_ExtensionAttribute] PRIMARY KEY CLUSTERED 
(
	[PersistenceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OA_DefForm]    Script Date: 2022/6/1 15:49:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OA_DefForm](
	[Id] [nvarchar](50) NOT NULL,
	[WorkflowJSON] [nvarchar](max) NULL,
	[JSONId] [nvarchar](50) NULL,
	[JSONVersion] [int] NOT NULL,
	[Type] [nvarchar](50) NULL,
	[Name] [nvarchar](255) NULL,
	[Text] [nvarchar](max) NULL,
	[Sort] [int] NOT NULL,
	[Status] [int] NOT NULL,
	[Value] [nvarchar](500) NULL,
	[Deleted] [bit] NOT NULL,
	[CreateTime] [datetime2](7) NOT NULL,
	[ModifyTime] [datetime2](7) NULL,
	[CreatorId] [nvarchar](50) NULL,
	[CreatorName] [nvarchar](255) NULL,
	[ModifyId] [nvarchar](50) NULL,
	[ModifyName] [nvarchar](255) NULL,
	[TenantId] [nvarchar](50) NULL,
 CONSTRAINT [PK_OA_DefForm] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OA_DefType]    Script Date: 2022/6/1 15:49:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OA_DefType](
	[Id] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](255) NULL,
	[Type] [nvarchar](50) NULL,
	[Unit] [nvarchar](50) NULL,
	[Deleted] [bit] NOT NULL,
	[CreateTime] [datetime2](7) NOT NULL,
	[ModifyTime] [datetime2](7) NULL,
	[CreatorId] [nvarchar](50) NULL,
	[CreatorName] [nvarchar](255) NULL,
	[ModifyId] [nvarchar](50) NULL,
	[ModifyName] [nvarchar](255) NULL,
	[TenantId] [nvarchar](50) NULL,
 CONSTRAINT [PK_OA_DefType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OA_UserForm]    Script Date: 2022/6/1 15:49:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OA_UserForm](
	[Id] [nvarchar](50) NOT NULL,
	[DefFormId] [nvarchar](50) NULL,
	[DefFormName] [nvarchar](255) NULL,
	[DefFormJsonId] [nvarchar](50) NULL,
	[DefFormJsonVersion] [int] NOT NULL,
	[Grade] [int] NOT NULL,
	[Flag] [float] NOT NULL,
	[Remarks] [nvarchar](max) NULL,
	[Appendix] [nvarchar](max) NULL,
	[ExtendJSON] [nvarchar](max) NULL,
	[ApplicantUser] [nvarchar](255) NULL,
	[ApplicantUserId] [nvarchar](50) NULL,
	[ApplicantDepartment] [nvarchar](255) NULL,
	[ApplicantDepartmentId] [nvarchar](50) NULL,
	[ApplicantRole] [nvarchar](255) NULL,
	[ApplicantRoleId] [nvarchar](50) NULL,
	[UserRoleNames] [nvarchar](max) NULL,
	[UserRoleIds] [nvarchar](max) NULL,
	[AlreadyUserNames] [nvarchar](max) NULL,
	[AlreadyUserIds] [nvarchar](max) NULL,
	[Status] [int] NOT NULL,
	[Type] [nvarchar](50) NULL,
	[SubType] [nvarchar](50) NULL,
	[Unit] [nvarchar](50) NULL,
	[ExpectedDate] [datetime2](7) NULL,
	[CurrentNode] [nvarchar](500) NULL,
	[Deleted] [bit] NOT NULL,
	[CreateTime] [datetime2](7) NOT NULL,
	[ModifyTime] [datetime2](7) NULL,
	[CreatorId] [nvarchar](50) NULL,
	[CreatorName] [nvarchar](255) NULL,
	[ModifyId] [nvarchar](50) NULL,
	[ModifyName] [nvarchar](255) NULL,
	[TenantId] [nvarchar](50) NULL,
	[UserIds] [nvarchar](max) NULL,
	[UserNames] [nvarchar](max) NULL,
	[Text] [nvarchar](max) NULL,
 CONSTRAINT [PK_OA_UserForm] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OA_UserFormStep]    Script Date: 2022/6/1 15:49:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OA_UserFormStep](
	[Id] [nvarchar](50) NOT NULL,
	[UserFormId] [nvarchar](50) NULL,
	[RoleIds] [nvarchar](max) NULL,
	[RoleNames] [nvarchar](max) NULL,
	[Remarks] [nvarchar](max) NULL,
	[Status] [int] NOT NULL,
	[StepName] [nvarchar](max) NULL,
	[Deleted] [bit] NOT NULL,
	[CreateTime] [datetime2](7) NOT NULL,
	[ModifyTime] [datetime2](7) NULL,
	[CreatorId] [nvarchar](50) NULL,
	[CreatorName] [nvarchar](255) NULL,
	[ModifyId] [nvarchar](50) NULL,
	[ModifyName] [nvarchar](255) NULL,
	[TenantId] [nvarchar](50) NULL,
 CONSTRAINT [PK_OA_UserFormStep] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Quartz_Task]    Script Date: 2022/6/1 15:49:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Quartz_Task](
	[Id] [nvarchar](50) NOT NULL,
	[TaskName] [nvarchar](255) NULL,
	[GroupName] [nvarchar](255) NULL,
	[Interval] [nvarchar](50) NULL,
	[ApiUrl] [nvarchar](500) NULL,
	[AuthKey] [nvarchar](50) NULL,
	[AuthValue] [nvarchar](500) NULL,
	[Describe] [nvarchar](500) NULL,
	[RequestType] [nvarchar](50) NULL,
	[LastRunTime] [datetime2](7) NULL,
	[Status] [int] NOT NULL,
	[ForbidOperate] [bit] NOT NULL,
	[ForbidEdit] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[CreateTime] [datetime2](7) NOT NULL,
	[ModifyTime] [datetime2](7) NULL,
	[CreatorId] [nvarchar](50) NULL,
	[CreatorName] [nvarchar](255) NULL,
	[ModifyId] [nvarchar](50) NULL,
	[ModifyName] [nvarchar](255) NULL,
	[TenantId] [nvarchar](50) NULL,
 CONSTRAINT [PK_Quartz_Task] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subscription]    Script Date: 2022/6/1 15:49:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subscription](
	[PersistenceId] [bigint] IDENTITY(1,1) NOT NULL,
	[SubscriptionId] [uniqueidentifier] NOT NULL,
	[WorkflowId] [nvarchar](200) NULL,
	[StepId] [int] NOT NULL,
	[ExecutionPointerId] [nvarchar](200) NULL,
	[EventName] [nvarchar](200) NULL,
	[EventKey] [nvarchar](200) NULL,
	[SubscribeAsOf] [datetime2](7) NOT NULL,
	[SubscriptionData] [nvarchar](max) NULL,
	[ExternalToken] [nvarchar](200) NULL,
	[ExternalWorkerId] [nvarchar](200) NULL,
	[ExternalTokenExpiry] [datetime2](7) NULL,
 CONSTRAINT [PK_Subscription] PRIMARY KEY CLUSTERED 
(
	[PersistenceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Workflow]    Script Date: 2022/6/1 15:49:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Workflow](
	[PersistenceId] [bigint] IDENTITY(1,1) NOT NULL,
	[InstanceId] [uniqueidentifier] NOT NULL,
	[WorkflowDefinitionId] [nvarchar](200) NULL,
	[Version] [int] NOT NULL,
	[Description] [nvarchar](500) NULL,
	[Reference] [nvarchar](200) NULL,
	[NextExecution] [bigint] NULL,
	[Data] [nvarchar](max) NULL,
	[CreateTime] [datetime2](7) NOT NULL,
	[CompleteTime] [datetime2](7) NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_Workflow] PRIMARY KEY CLUSTERED 
(
	[PersistenceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [wfc].[Event]    Script Date: 2022/6/1 15:49:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [wfc].[Event](
	[PersistenceId] [bigint] IDENTITY(1,1) NOT NULL,
	[EventData] [nvarchar](max) NULL,
	[EventId] [uniqueidentifier] NOT NULL,
	[EventKey] [nvarchar](200) NULL,
	[EventName] [nvarchar](200) NULL,
	[EventTime] [datetime2](7) NOT NULL,
	[IsProcessed] [bit] NOT NULL,
 CONSTRAINT [PK_Event] PRIMARY KEY CLUSTERED 
(
	[PersistenceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [wfc].[ExecutionError]    Script Date: 2022/6/1 15:49:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [wfc].[ExecutionError](
	[PersistenceId] [bigint] IDENTITY(1,1) NOT NULL,
	[ErrorTime] [datetime2](7) NOT NULL,
	[ExecutionPointerId] [nvarchar](100) NULL,
	[Message] [nvarchar](max) NULL,
	[WorkflowId] [nvarchar](100) NULL,
 CONSTRAINT [PK_ExecutionError] PRIMARY KEY CLUSTERED 
(
	[PersistenceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [wfc].[ExecutionPointer]    Script Date: 2022/6/1 15:49:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [wfc].[ExecutionPointer](
	[PersistenceId] [bigint] IDENTITY(1,1) NOT NULL,
	[Active] [bit] NOT NULL,
	[RetryCount] [int] NOT NULL,
	[EndTime] [datetime2](7) NULL,
	[EventData] [nvarchar](max) NULL,
	[EventKey] [nvarchar](100) NULL,
	[EventName] [nvarchar](100) NULL,
	[EventPublished] [bit] NOT NULL,
	[Id] [nvarchar](50) NULL,
	[PersistenceData] [nvarchar](max) NULL,
	[SleepUntil] [datetime2](7) NULL,
	[StartTime] [datetime2](7) NULL,
	[StepId] [int] NOT NULL,
	[StepName] [nvarchar](100) NULL,
	[WorkflowId] [bigint] NOT NULL,
	[Children] [nvarchar](max) NULL,
	[ContextItem] [nvarchar](max) NULL,
	[PredecessorId] [nvarchar](100) NULL,
	[Outcome] [nvarchar](max) NULL,
	[Scope] [nvarchar](max) NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_ExecutionPointer] PRIMARY KEY CLUSTERED 
(
	[PersistenceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [wfc].[ExtensionAttribute]    Script Date: 2022/6/1 15:49:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [wfc].[ExtensionAttribute](
	[PersistenceId] [bigint] IDENTITY(1,1) NOT NULL,
	[AttributeKey] [nvarchar](100) NULL,
	[AttributeValue] [nvarchar](max) NULL,
	[ExecutionPointerId] [bigint] NOT NULL,
 CONSTRAINT [PK_ExtensionAttribute] PRIMARY KEY CLUSTERED 
(
	[PersistenceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [wfc].[Subscription]    Script Date: 2022/6/1 15:49:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [wfc].[Subscription](
	[PersistenceId] [bigint] IDENTITY(1,1) NOT NULL,
	[EventKey] [nvarchar](200) NULL,
	[EventName] [nvarchar](200) NULL,
	[StepId] [int] NOT NULL,
	[SubscriptionId] [uniqueidentifier] NOT NULL,
	[WorkflowId] [nvarchar](200) NULL,
	[SubscribeAsOf] [datetime2](7) NOT NULL,
	[SubscriptionData] [nvarchar](max) NULL,
	[ExecutionPointerId] [nvarchar](200) NULL,
	[ExternalToken] [nvarchar](200) NULL,
	[ExternalTokenExpiry] [datetime2](7) NULL,
	[ExternalWorkerId] [nvarchar](200) NULL,
 CONSTRAINT [PK_Subscription] PRIMARY KEY CLUSTERED 
(
	[PersistenceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [wfc].[Workflow]    Script Date: 2022/6/1 15:49:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [wfc].[Workflow](
	[PersistenceId] [bigint] IDENTITY(1,1) NOT NULL,
	[CompleteTime] [datetime2](7) NULL,
	[CreateTime] [datetime2](7) NOT NULL,
	[Data] [nvarchar](max) NULL,
	[Description] [nvarchar](500) NULL,
	[InstanceId] [uniqueidentifier] NOT NULL,
	[NextExecution] [bigint] NULL,
	[Status] [int] NOT NULL,
	[Version] [int] NOT NULL,
	[WorkflowDefinitionId] [nvarchar](200) NULL,
	[Reference] [nvarchar](200) NULL,
 CONSTRAINT [PK_Workflow] PRIMARY KEY CLUSTERED 
(
	[PersistenceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20170126230839_InitialDatabase', N'5.0.1')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20170312161610_Events', N'5.0.1')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20170507214430_ControlStructures', N'5.0.1')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20170519231452_PersistOutcome', N'5.0.1')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20170722195832_WfReference', N'5.0.1')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20171223020645_StepScope', N'5.0.1')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20191214232800_SubscriptionData', N'5.0.1')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20191221210710_Activities', N'5.0.1')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210109172432_EFCore5', N'5.0.1')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210214112752_InitialCreate', N'5.0.3')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210218140025_InitialCreate22', N'5.0.3')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210322131406_D_Notice', N'5.0.3')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210322132040_D_NoticeReadingMarks', N'5.0.3')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210322134435_D_NoticeReadingMarks2', N'5.0.3')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210322135418_D_NoticeReadingMarks3', N'5.0.3')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210323141357_Status', N'5.0.3')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210324142248_mmm', N'5.0.3')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210325140135_InitialCreate111', N'5.0.3')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210417081800_Status2', N'5.0.3')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220520002827_Base_Dictionary', N'5.0.3')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220520022017_Base_Dictionary2', N'5.0.3')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220520122814_Base_Dictionary3', N'5.0.3')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220530014540_Base_CommonFormConfig', N'5.0.3')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220530070239_Base_CommonFormConfig2', N'5.0.3')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220530123327_Base_CommonFormConfig3', N'5.0.3')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220530131216_Base_CommonFormConfig4', N'5.0.3')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220530234831_Base_CommonFormConfig5', N'5.0.3')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220530235019_Base_CommonFormConfig6', N'5.0.3')
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'Id0', NULL, 0, N'首页', NULL, NULL, 1, N'home', 0, 0, CAST(N'2022-06-01T10:51:53.4690453' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'Id0_1', N'Id0', 1, N'框架介绍', N'/Home/Introduce', NULL, 0, NULL, 1, 0, CAST(N'2022-06-01T10:51:53.4690583' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'Id0_2', N'Id0', 1, N'运营统计', N'/Home/Statis', NULL, 0, NULL, 2, 0, CAST(N'2022-06-01T10:51:53.4690587' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'Id0_3', N'Id0', 1, N'我的控制台', N'/Home/UserConsole', NULL, 0, NULL, 3, 0, CAST(N'2022-06-01T10:51:53.4690590' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'Id0_4', N'Id0', 1, N'3D展台', N'/Home/_3DShowcase', NULL, 0, NULL, 4, 0, CAST(N'2022-06-01T10:51:53.4690592' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'Id1', NULL, 0, N'系统管理', NULL, NULL, 1, N'setting', 1, 0, CAST(N'2022-06-01T10:51:53.4690601' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'Id1_1', N'Id1', 1, N'权限管理', N'/Base_Manage/Base_Action/List', NULL, 1, N'lock', 1, 0, CAST(N'2022-06-01T10:51:53.4690604' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'Id1_1_1', N'Id1_1', 2, N'增', NULL, N'Base_Action.Add', 1, NULL, 1, 0, CAST(N'2022-06-01T10:51:53.4690632' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'Id1_1_2', N'Id1_1', 2, N'改', NULL, N'Base_Action.Edit', 1, NULL, 1, 0, CAST(N'2022-06-01T10:51:53.4690635' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'Id1_1_3', N'Id1_1', 2, N'删', NULL, N'Base_Action.Delete', 1, NULL, 1, 0, CAST(N'2022-06-01T10:51:53.4690639' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'Id1_2', N'Id1', 1, N'密钥管理', N'/Base_Manage/Base_AppSecret/List', NULL, 1, N'key', 2, 0, CAST(N'2022-06-01T10:51:53.4690609' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'Id1_2_1', N'Id1_2', 2, N'增', NULL, N'Base_AppSecret.Add', 1, NULL, 1, 0, CAST(N'2022-06-01T10:51:53.4690641' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'Id1_2_2', N'Id1_2', 2, N'改', NULL, N'Base_AppSecret.Edit', 1, NULL, 1, 0, CAST(N'2022-06-01T10:51:53.4690682' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'Id1_2_3', N'Id1_2', 2, N'删', NULL, N'Base_AppSecret.Delete', 1, NULL, 1, 0, CAST(N'2022-06-01T10:51:53.4690686' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'Id1_3', N'Id1', 1, N'用户管理', N'/Base_Manage/Base_User/List', NULL, 1, N'user-add', 3, 0, CAST(N'2022-06-01T10:51:53.4690611' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'Id1_3_1', N'Id1_3', 2, N'增', NULL, N'Base_User.Add', 1, NULL, 1, 0, CAST(N'2022-06-01T10:51:53.4690688' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'Id1_3_2', N'Id1_3', 2, N'改', NULL, N'Base_User.Edit', 1, NULL, 1, 0, CAST(N'2022-06-01T10:51:53.4690690' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'Id1_3_3', N'Id1_3', 2, N'删', NULL, N'Base_User.Delete', 1, NULL, 1, 0, CAST(N'2022-06-01T10:51:53.4690693' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'Id1_4', N'Id1', 1, N'角色管理', N'/Base_Manage/Base_Role/List', NULL, 1, N'safety', 4, 0, CAST(N'2022-06-01T10:51:53.4690615' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'Id1_4_1', N'Id1_4', 2, N'增', NULL, N'Base_Role.Add', 1, NULL, 1, 0, CAST(N'2022-06-01T10:51:53.4690695' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'Id1_4_2', N'Id1_4', 2, N'改', NULL, N'Base_Role.Edit', 1, NULL, 1, 0, CAST(N'2022-06-01T10:51:53.4690697' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'Id1_4_3', N'Id1_4', 2, N'删', NULL, N'Base_Role.Delete', 1, NULL, 1, 0, CAST(N'2022-06-01T10:51:53.4690699' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'Id1_5', N'Id1', 1, N'部门管理', N'/Base_Manage/Base_Department/List', NULL, 1, N'usergroup-add', 5, 0, CAST(N'2022-06-01T10:51:53.4690617' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'Id1_5_1', N'Id1_5', 2, N'增', NULL, N'Base_Department.Add', 1, NULL, 1, 0, CAST(N'2022-06-01T10:51:53.4690701' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'Id1_5_2', N'Id1_5', 2, N'改', NULL, N'Base_Department.Edit', 1, NULL, 1, 0, CAST(N'2022-06-01T10:51:53.4690703' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'Id1_5_3', N'Id1_5', 2, N'删', NULL, N'Base_Department.Delete', 1, NULL, 1, 0, CAST(N'2022-06-01T10:51:53.4690705' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'Id1_6', N'Id1', 1, N'字典管理', N'/Base_Manage/Base_Dictionary/List', NULL, 1, N'edit', 6, 0, CAST(N'2022-06-01T10:51:53.4690620' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'Id1_7', N'Id1', 1, N'表单配置', N'/Base_Manage/Base_CommonFormConfig/List', NULL, 1, N'form', 7, 0, CAST(N'2022-06-01T10:51:53.4690623' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'Id1_8', N'Id1', 1, N'操作日志', N'/Base_Manage/Base_UserLog/List', NULL, 1, N'file-search', 8, 0, CAST(N'2022-06-01T10:51:53.4690626' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'Id1_9', N'Id1', 1, N'任务管理', N'/Quartz_Manage/Quartz_Task/List', NULL, 1, N'calendar', 9, 0, CAST(N'2022-06-01T10:51:53.4690629' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'Id10', NULL, 0, N'个人页', NULL, NULL, 1, N'user', 10, 0, CAST(N'2022-06-01T10:51:53.4690757' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'Id10_1', N'Id10', 1, N'个人中心', N'/account/center/Index', NULL, 0, N'user', 1, 0, CAST(N'2022-06-01T10:51:53.4690760' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'Id10_2', N'Id10', 1, N'个人设置', N'/account/settings/Index', NULL, 0, N'user', 1, 0, CAST(N'2022-06-01T10:51:53.4690762' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'Id2', NULL, 0, N'消息中心', NULL, NULL, 1, N'notification', 2, 0, CAST(N'2022-06-01T10:51:53.4690707' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'Id2_1', N'Id2', 1, N'站内消息', N'/D_Manage/D_UserMessage/List', NULL, 0, N'message', 1, 0, CAST(N'2022-06-01T10:51:53.4690710' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'Id2_2', N'Id2', 1, N'站内信', N'/D_Manage/D_UserMail/Index', NULL, 0, N'mail', 2, 0, CAST(N'2022-06-01T10:51:53.4690712' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'Id2_3', N'Id2', 1, N'通告', N'/D_Manage/D_Notice/List', NULL, 0, N'sound', 3, 0, CAST(N'2022-06-01T10:51:53.4690715' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'Id3', NULL, 0, N'流程中心', NULL, NULL, 1, N'clock-circle', 3, 0, CAST(N'2022-06-01T10:51:53.4690717' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'Id3_1', N'Id3', 1, N'流程管理', N'/OA_Manage/OA_DefForm/List', NULL, 1, N'interaction', 1, 0, CAST(N'2022-06-01T10:51:53.4690720' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'Id3_1_1', N'Id3_1', 2, N'增', NULL, N'OA_DefForm.Add', 1, NULL, 1, 0, CAST(N'2022-06-01T10:51:53.4690722' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'Id3_1_2', N'Id3_1', 2, N'改', NULL, N'OA_DefForm.Edit', 1, NULL, 1, 0, CAST(N'2022-06-01T10:51:53.4690724' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'Id3_1_3', N'Id3_1', 2, N'删', NULL, N'OA_DefForm.Delete', 1, NULL, 1, 0, CAST(N'2022-06-01T10:51:53.4690726' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'Id3_2', N'Id3', 1, N'发起流程', N'/OA_Manage/OA_DefForm/TreeList', NULL, 1, N'file-add', 1, 0, CAST(N'2022-06-01T10:51:53.4690728' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'Id3_3', N'Id3', 1, N'我的流程', N'/OA_Manage/OA_UserForm/List', NULL, 1, N'file-done', 1, 0, CAST(N'2022-06-01T10:51:53.4690730' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'Id3_3_1', N'Id3_3', 2, N'增', NULL, N'OA_UserForm.Add', 1, NULL, 1, 0, CAST(N'2022-06-01T10:51:53.4690733' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'Id3_3_2', N'Id3_3', 2, N'改', NULL, N'OA_UserForm.Edit', 1, NULL, 1, 0, CAST(N'2022-06-01T10:51:53.4690736' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'Id3_3_3', N'Id3_3', 2, N'删', NULL, N'OA_UserForm.Delete', 1, NULL, 1, 0, CAST(N'2022-06-01T10:51:53.4690737' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'Id3_4', N'Id3', 1, N'流程字典管理', N'/OA_Manage/OA_DefType/List', NULL, 1, N'edit', 1, 0, CAST(N'2022-06-01T10:51:53.4690740' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'Id3_4_1', N'Id3_4', 2, N'增', NULL, N'OA_DefType.Add', 1, NULL, 1, 0, CAST(N'2022-06-01T10:51:53.4690741' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'Id3_4_2', N'Id3_4', 2, N'改', NULL, N'OA_DefType.Edit', 1, NULL, 1, 0, CAST(N'2022-06-01T10:51:53.4690743' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'Id3_4_3', N'Id3_4', 2, N'删', NULL, N'OA_DefType.Delete', 1, NULL, 1, 0, CAST(N'2022-06-01T10:51:53.4690745' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'Id4', NULL, 0, N'通用查询', NULL, NULL, 1, N'search', 4, 0, CAST(N'2022-06-01T10:51:53.4690747' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'Id4_1', N'Id4', 1, N'用户查询', N'/Agile_Development/Common_FormConfigQuery/List', N'Base_Manage.Base_User', 1, N'user-add', 1, 0, CAST(N'2022-06-01T10:51:53.4690749' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'Id4_2', N'Id4', 1, N'角色查询', N'/Agile_Development/Common_FormConfigQuery/List', N'Base_Manage.Base_Role', 1, N'safety', 1, 0, CAST(N'2022-06-01T10:51:53.4690751' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'Id4_3', N'Id4', 1, N'密钥查询', N'/Agile_Development/Common_FormConfigQuery/List', N'Base_Manage.Base_AppSecret', 1, N'key', 1, 0, CAST(N'2022-06-01T10:51:53.4690753' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_AppSecret] ([Id], [AppId], [AppSecret], [AppName], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1172497995938271232', N'PcAdmin', N'wtMaiTRPTT3hrf5e', N'后台AppId', 0, CAST(N'2022-05-30T09:51:58.0308948' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_AppSecret] ([Id], [AppId], [AppSecret], [AppName], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1173937877642383360', N'AppAdmin', N'IVh9LLSVFcoQPQ5K', N'APP密钥', 0, CAST(N'2022-05-30T09:51:58.0309043' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_AppSecret] ([Id], [AppId], [AppSecret], [AppName], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1531899758308757504', N'test', N'test2', N'test', 0, CAST(N'2022-06-01T15:25:38.3590000' AS DateTime2), CAST(N'2022-06-01T15:25:43.9972244' AS DateTime2), N'Admin', N'Admin', N'Admin', N'Admin', NULL)
GO
INSERT [dbo].[Base_CommonFormConfig] ([Id], [Table], [Header], [PropertyName], [DisplayIndex], [Type], [StringFormat], [Visibility], [ControlType], [IsReadOnly], [IsRequired], [ItemSource], [Value], [SortMemberPath], [Converter], [ConverterParameter], [HorizontalAlignment], [MaxWidth], [MinWidth], [Width], [CanUserReorder], [CanUserResize], [CanUserSort], [CellStyle], [BackgroundExpression], [ForegroundExpression], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [HeaderStyle], [PropertyType], [ErrorMessage], [Regex]) VALUES (N'Id1_1', N'Base_User', N'姓名', N'UserName', 0, 0, NULL, 0, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, NULL, 0, 0, 0, NULL, NULL, NULL, 0, CAST(N'2022-06-01T10:51:54.5586796' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'string', NULL, NULL)
GO
INSERT [dbo].[Base_CommonFormConfig] ([Id], [Table], [Header], [PropertyName], [DisplayIndex], [Type], [StringFormat], [Visibility], [ControlType], [IsReadOnly], [IsRequired], [ItemSource], [Value], [SortMemberPath], [Converter], [ConverterParameter], [HorizontalAlignment], [MaxWidth], [MinWidth], [Width], [CanUserReorder], [CanUserResize], [CanUserSort], [CellStyle], [BackgroundExpression], [ForegroundExpression], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [HeaderStyle], [PropertyType], [ErrorMessage], [Regex]) VALUES (N'Id1_11', N'Base_User', N'Id', N'Id', 0, 1, NULL, 2, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, NULL, 1, 1, 1, NULL, NULL, NULL, 0, CAST(N'2022-06-01T10:51:54.5588730' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'string', NULL, NULL)
GO
INSERT [dbo].[Base_CommonFormConfig] ([Id], [Table], [Header], [PropertyName], [DisplayIndex], [Type], [StringFormat], [Visibility], [ControlType], [IsReadOnly], [IsRequired], [ItemSource], [Value], [SortMemberPath], [Converter], [ConverterParameter], [HorizontalAlignment], [MaxWidth], [MinWidth], [Width], [CanUserReorder], [CanUserResize], [CanUserSort], [CellStyle], [BackgroundExpression], [ForegroundExpression], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [HeaderStyle], [PropertyType], [ErrorMessage], [Regex]) VALUES (N'Id1_12', N'Base_User', N'姓名', N'UserName', 1, 1, NULL, 0, 0, 0, 1, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, NULL, 1, 1, 1, NULL, NULL, NULL, 0, CAST(N'2022-06-01T10:51:54.5589879' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'string', N'请输入姓名', NULL)
GO
INSERT [dbo].[Base_CommonFormConfig] ([Id], [Table], [Header], [PropertyName], [DisplayIndex], [Type], [StringFormat], [Visibility], [ControlType], [IsReadOnly], [IsRequired], [ItemSource], [Value], [SortMemberPath], [Converter], [ConverterParameter], [HorizontalAlignment], [MaxWidth], [MinWidth], [Width], [CanUserReorder], [CanUserResize], [CanUserSort], [CellStyle], [BackgroundExpression], [ForegroundExpression], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [HeaderStyle], [PropertyType], [ErrorMessage], [Regex]) VALUES (N'Id1_13', N'Base_User', N'真实姓名', N'RealName', 2, 1, NULL, 0, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, NULL, 1, 1, 1, NULL, NULL, NULL, 0, CAST(N'2022-06-01T10:51:54.5589889' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'string', NULL, NULL)
GO
INSERT [dbo].[Base_CommonFormConfig] ([Id], [Table], [Header], [PropertyName], [DisplayIndex], [Type], [StringFormat], [Visibility], [ControlType], [IsReadOnly], [IsRequired], [ItemSource], [Value], [SortMemberPath], [Converter], [ConverterParameter], [HorizontalAlignment], [MaxWidth], [MinWidth], [Width], [CanUserReorder], [CanUserResize], [CanUserSort], [CellStyle], [BackgroundExpression], [ForegroundExpression], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [HeaderStyle], [PropertyType], [ErrorMessage], [Regex]) VALUES (N'Id1_14', N'Base_User', N'密码', N'Password', 3, 1, NULL, 0, 3, 0, 0, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, NULL, 1, 1, 1, NULL, NULL, NULL, 0, CAST(N'2022-06-01T10:51:54.5590521' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'string', NULL, NULL)
GO
INSERT [dbo].[Base_CommonFormConfig] ([Id], [Table], [Header], [PropertyName], [DisplayIndex], [Type], [StringFormat], [Visibility], [ControlType], [IsReadOnly], [IsRequired], [ItemSource], [Value], [SortMemberPath], [Converter], [ConverterParameter], [HorizontalAlignment], [MaxWidth], [MinWidth], [Width], [CanUserReorder], [CanUserResize], [CanUserSort], [CellStyle], [BackgroundExpression], [ForegroundExpression], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [HeaderStyle], [PropertyType], [ErrorMessage], [Regex]) VALUES (N'Id1_15', N'Base_User', N'性别', N'Sex', 4, 1, NULL, 0, 2, 0, 0, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, NULL, 1, 1, 1, NULL, NULL, NULL, 0, CAST(N'2022-06-01T10:51:54.5590531' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'int', NULL, NULL)
GO
INSERT [dbo].[Base_CommonFormConfig] ([Id], [Table], [Header], [PropertyName], [DisplayIndex], [Type], [StringFormat], [Visibility], [ControlType], [IsReadOnly], [IsRequired], [ItemSource], [Value], [SortMemberPath], [Converter], [ConverterParameter], [HorizontalAlignment], [MaxWidth], [MinWidth], [Width], [CanUserReorder], [CanUserResize], [CanUserSort], [CellStyle], [BackgroundExpression], [ForegroundExpression], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [HeaderStyle], [PropertyType], [ErrorMessage], [Regex]) VALUES (N'Id1_16', N'Base_User', N'生日', N'Birthday', 5, 1, NULL, 0, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, NULL, 1, 1, 1, NULL, NULL, NULL, 0, CAST(N'2022-06-01T10:51:54.5590536' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'datetime', NULL, NULL)
GO
INSERT [dbo].[Base_CommonFormConfig] ([Id], [Table], [Header], [PropertyName], [DisplayIndex], [Type], [StringFormat], [Visibility], [ControlType], [IsReadOnly], [IsRequired], [ItemSource], [Value], [SortMemberPath], [Converter], [ConverterParameter], [HorizontalAlignment], [MaxWidth], [MinWidth], [Width], [CanUserReorder], [CanUserResize], [CanUserSort], [CellStyle], [BackgroundExpression], [ForegroundExpression], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [HeaderStyle], [PropertyType], [ErrorMessage], [Regex]) VALUES (N'Id1_17', N'Base_User', N'角色', N'RoleIdList', 6, 1, NULL, 0, 6, 0, 0, N'Base_Role', NULL, NULL, NULL, NULL, 0, 0, 0, NULL, 1, 1, 1, NULL, NULL, NULL, 0, CAST(N'2022-06-01T10:51:54.5591189' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'list', NULL, NULL)
GO
INSERT [dbo].[Base_CommonFormConfig] ([Id], [Table], [Header], [PropertyName], [DisplayIndex], [Type], [StringFormat], [Visibility], [ControlType], [IsReadOnly], [IsRequired], [ItemSource], [Value], [SortMemberPath], [Converter], [ConverterParameter], [HorizontalAlignment], [MaxWidth], [MinWidth], [Width], [CanUserReorder], [CanUserResize], [CanUserSort], [CellStyle], [BackgroundExpression], [ForegroundExpression], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [HeaderStyle], [PropertyType], [ErrorMessage], [Regex]) VALUES (N'Id1_18', N'Base_User', N'部门', N'DepartmentId', 7, 1, NULL, 0, 5, 0, 0, N'Base_Department', NULL, NULL, NULL, NULL, 0, 0, 0, NULL, 1, 1, 1, NULL, NULL, NULL, 0, CAST(N'2022-06-01T10:51:54.5591237' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'string', NULL, NULL)
GO
INSERT [dbo].[Base_CommonFormConfig] ([Id], [Table], [Header], [PropertyName], [DisplayIndex], [Type], [StringFormat], [Visibility], [ControlType], [IsReadOnly], [IsRequired], [ItemSource], [Value], [SortMemberPath], [Converter], [ConverterParameter], [HorizontalAlignment], [MaxWidth], [MinWidth], [Width], [CanUserReorder], [CanUserResize], [CanUserSort], [CellStyle], [BackgroundExpression], [ForegroundExpression], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [HeaderStyle], [PropertyType], [ErrorMessage], [Regex]) VALUES (N'Id1_19', N'Base_User', N'手机号码', N'PhoneNumber', 8, 1, NULL, 0, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, NULL, 1, 1, 1, NULL, NULL, NULL, 0, CAST(N'2022-06-01T10:51:54.5591828' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'string', N'请输入正确的手机号码格式', N'^(13[0-9]|14[01456879]|15[0-35-9]|16[2567]|17[0-8]|18[0-9]|19[0-35-9])\d{8}$')
GO
INSERT [dbo].[Base_CommonFormConfig] ([Id], [Table], [Header], [PropertyName], [DisplayIndex], [Type], [StringFormat], [Visibility], [ControlType], [IsReadOnly], [IsRequired], [ItemSource], [Value], [SortMemberPath], [Converter], [ConverterParameter], [HorizontalAlignment], [MaxWidth], [MinWidth], [Width], [CanUserReorder], [CanUserResize], [CanUserSort], [CellStyle], [BackgroundExpression], [ForegroundExpression], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [HeaderStyle], [PropertyType], [ErrorMessage], [Regex]) VALUES (N'Id1_2', N'Base_User', N'手机号码', N'PhoneNumber', 1, 0, NULL, 0, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, NULL, 0, 0, 0, NULL, NULL, NULL, 0, CAST(N'2022-06-01T10:51:54.5586905' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'string', NULL, NULL)
GO
INSERT [dbo].[Base_CommonFormConfig] ([Id], [Table], [Header], [PropertyName], [DisplayIndex], [Type], [StringFormat], [Visibility], [ControlType], [IsReadOnly], [IsRequired], [ItemSource], [Value], [SortMemberPath], [Converter], [ConverterParameter], [HorizontalAlignment], [MaxWidth], [MinWidth], [Width], [CanUserReorder], [CanUserResize], [CanUserSort], [CellStyle], [BackgroundExpression], [ForegroundExpression], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [HeaderStyle], [PropertyType], [ErrorMessage], [Regex]) VALUES (N'Id1_20', N'Base_User', N'创建时间', N'CreateTime', 9, 1, NULL, 0, 0, 1, 0, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, NULL, 1, 1, 1, NULL, NULL, NULL, 0, CAST(N'2022-06-01T10:51:54.5592895' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'datetime', NULL, NULL)
GO
INSERT [dbo].[Base_CommonFormConfig] ([Id], [Table], [Header], [PropertyName], [DisplayIndex], [Type], [StringFormat], [Visibility], [ControlType], [IsReadOnly], [IsRequired], [ItemSource], [Value], [SortMemberPath], [Converter], [ConverterParameter], [HorizontalAlignment], [MaxWidth], [MinWidth], [Width], [CanUserReorder], [CanUserResize], [CanUserSort], [CellStyle], [BackgroundExpression], [ForegroundExpression], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [HeaderStyle], [PropertyType], [ErrorMessage], [Regex]) VALUES (N'Id1_21', N'Base_User', N'修改时间', N'ModifyTime', 10, 1, NULL, 0, 0, 1, 0, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, NULL, 1, 1, 1, NULL, NULL, NULL, 0, CAST(N'2022-06-01T10:51:54.5592904' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'datetime', NULL, NULL)
GO
INSERT [dbo].[Base_CommonFormConfig] ([Id], [Table], [Header], [PropertyName], [DisplayIndex], [Type], [StringFormat], [Visibility], [ControlType], [IsReadOnly], [IsRequired], [ItemSource], [Value], [SortMemberPath], [Converter], [ConverterParameter], [HorizontalAlignment], [MaxWidth], [MinWidth], [Width], [CanUserReorder], [CanUserResize], [CanUserSort], [CellStyle], [BackgroundExpression], [ForegroundExpression], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [HeaderStyle], [PropertyType], [ErrorMessage], [Regex]) VALUES (N'Id1_22', N'Base_User', N'创建者', N'CreatorName', 11, 1, NULL, 0, 0, 1, 0, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, NULL, 1, 1, 1, NULL, NULL, NULL, 0, CAST(N'2022-06-01T10:51:54.5592907' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'string', NULL, NULL)
GO
INSERT [dbo].[Base_CommonFormConfig] ([Id], [Table], [Header], [PropertyName], [DisplayIndex], [Type], [StringFormat], [Visibility], [ControlType], [IsReadOnly], [IsRequired], [ItemSource], [Value], [SortMemberPath], [Converter], [ConverterParameter], [HorizontalAlignment], [MaxWidth], [MinWidth], [Width], [CanUserReorder], [CanUserResize], [CanUserSort], [CellStyle], [BackgroundExpression], [ForegroundExpression], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [HeaderStyle], [PropertyType], [ErrorMessage], [Regex]) VALUES (N'Id1_23', N'Base_User', N'修改者', N'ModifyName', 12, 1, NULL, 0, 0, 1, 0, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, NULL, 1, 1, 1, NULL, NULL, NULL, 0, CAST(N'2022-06-01T10:51:54.5592910' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'string', NULL, NULL)
GO
INSERT [dbo].[Base_CommonFormConfig] ([Id], [Table], [Header], [PropertyName], [DisplayIndex], [Type], [StringFormat], [Visibility], [ControlType], [IsReadOnly], [IsRequired], [ItemSource], [Value], [SortMemberPath], [Converter], [ConverterParameter], [HorizontalAlignment], [MaxWidth], [MinWidth], [Width], [CanUserReorder], [CanUserResize], [CanUserSort], [CellStyle], [BackgroundExpression], [ForegroundExpression], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [HeaderStyle], [PropertyType], [ErrorMessage], [Regex]) VALUES (N'Id2_1', N'Base_Role', N'角色名', N'RoleName', 0, 0, NULL, 0, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, NULL, 0, 0, 0, NULL, NULL, NULL, 0, CAST(N'2022-06-01T10:51:54.5592915' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'string', NULL, NULL)
GO
INSERT [dbo].[Base_CommonFormConfig] ([Id], [Table], [Header], [PropertyName], [DisplayIndex], [Type], [StringFormat], [Visibility], [ControlType], [IsReadOnly], [IsRequired], [ItemSource], [Value], [SortMemberPath], [Converter], [ConverterParameter], [HorizontalAlignment], [MaxWidth], [MinWidth], [Width], [CanUserReorder], [CanUserResize], [CanUserSort], [CellStyle], [BackgroundExpression], [ForegroundExpression], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [HeaderStyle], [PropertyType], [ErrorMessage], [Regex]) VALUES (N'Id2_11', N'Base_Role', N'Id', N'Id', 0, 1, NULL, 2, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, NULL, 1, 1, 1, NULL, NULL, NULL, 0, CAST(N'2022-06-01T10:51:54.5592918' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'string', NULL, NULL)
GO
INSERT [dbo].[Base_CommonFormConfig] ([Id], [Table], [Header], [PropertyName], [DisplayIndex], [Type], [StringFormat], [Visibility], [ControlType], [IsReadOnly], [IsRequired], [ItemSource], [Value], [SortMemberPath], [Converter], [ConverterParameter], [HorizontalAlignment], [MaxWidth], [MinWidth], [Width], [CanUserReorder], [CanUserResize], [CanUserSort], [CellStyle], [BackgroundExpression], [ForegroundExpression], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [HeaderStyle], [PropertyType], [ErrorMessage], [Regex]) VALUES (N'Id2_12', N'Base_Role', N'角色名', N'RoleName', 1, 1, NULL, 0, 0, 0, 1, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, NULL, 1, 1, 1, NULL, NULL, NULL, 0, CAST(N'2022-06-01T10:51:54.5592927' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'string', N'请输入角色名', NULL)
GO
INSERT [dbo].[Base_CommonFormConfig] ([Id], [Table], [Header], [PropertyName], [DisplayIndex], [Type], [StringFormat], [Visibility], [ControlType], [IsReadOnly], [IsRequired], [ItemSource], [Value], [SortMemberPath], [Converter], [ConverterParameter], [HorizontalAlignment], [MaxWidth], [MinWidth], [Width], [CanUserReorder], [CanUserResize], [CanUserSort], [CellStyle], [BackgroundExpression], [ForegroundExpression], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [HeaderStyle], [PropertyType], [ErrorMessage], [Regex]) VALUES (N'Id2_13', N'Base_Role', N'权限', N'Actions', 2, 1, NULL, 0, 7, 0, 0, N'Base_Action', NULL, NULL, NULL, NULL, 0, 0, 0, N'300', 1, 1, 1, NULL, NULL, NULL, 0, CAST(N'2022-06-01T10:51:54.5594340' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'list', NULL, NULL)
GO
INSERT [dbo].[Base_CommonFormConfig] ([Id], [Table], [Header], [PropertyName], [DisplayIndex], [Type], [StringFormat], [Visibility], [ControlType], [IsReadOnly], [IsRequired], [ItemSource], [Value], [SortMemberPath], [Converter], [ConverterParameter], [HorizontalAlignment], [MaxWidth], [MinWidth], [Width], [CanUserReorder], [CanUserResize], [CanUserSort], [CellStyle], [BackgroundExpression], [ForegroundExpression], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [HeaderStyle], [PropertyType], [ErrorMessage], [Regex]) VALUES (N'Id2_14', N'Base_Role', N'创建时间', N'CreateTime', 3, 1, NULL, 0, 0, 1, 0, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, NULL, 1, 1, 1, NULL, NULL, NULL, 0, CAST(N'2022-06-01T10:51:54.5594364' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'datetime', NULL, NULL)
GO
INSERT [dbo].[Base_CommonFormConfig] ([Id], [Table], [Header], [PropertyName], [DisplayIndex], [Type], [StringFormat], [Visibility], [ControlType], [IsReadOnly], [IsRequired], [ItemSource], [Value], [SortMemberPath], [Converter], [ConverterParameter], [HorizontalAlignment], [MaxWidth], [MinWidth], [Width], [CanUserReorder], [CanUserResize], [CanUserSort], [CellStyle], [BackgroundExpression], [ForegroundExpression], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [HeaderStyle], [PropertyType], [ErrorMessage], [Regex]) VALUES (N'Id2_15', N'Base_Role', N'修改时间', N'ModifyTime', 4, 1, NULL, 0, 0, 1, 0, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, NULL, 1, 1, 1, NULL, NULL, NULL, 0, CAST(N'2022-06-01T10:51:54.5594369' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'datetime', NULL, NULL)
GO
INSERT [dbo].[Base_CommonFormConfig] ([Id], [Table], [Header], [PropertyName], [DisplayIndex], [Type], [StringFormat], [Visibility], [ControlType], [IsReadOnly], [IsRequired], [ItemSource], [Value], [SortMemberPath], [Converter], [ConverterParameter], [HorizontalAlignment], [MaxWidth], [MinWidth], [Width], [CanUserReorder], [CanUserResize], [CanUserSort], [CellStyle], [BackgroundExpression], [ForegroundExpression], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [HeaderStyle], [PropertyType], [ErrorMessage], [Regex]) VALUES (N'Id2_16', N'Base_Role', N'创建者', N'CreatorName', 5, 1, NULL, 0, 0, 1, 0, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, NULL, 1, 1, 1, NULL, NULL, NULL, 0, CAST(N'2022-06-01T10:51:54.5594372' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'string', NULL, NULL)
GO
INSERT [dbo].[Base_CommonFormConfig] ([Id], [Table], [Header], [PropertyName], [DisplayIndex], [Type], [StringFormat], [Visibility], [ControlType], [IsReadOnly], [IsRequired], [ItemSource], [Value], [SortMemberPath], [Converter], [ConverterParameter], [HorizontalAlignment], [MaxWidth], [MinWidth], [Width], [CanUserReorder], [CanUserResize], [CanUserSort], [CellStyle], [BackgroundExpression], [ForegroundExpression], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [HeaderStyle], [PropertyType], [ErrorMessage], [Regex]) VALUES (N'Id2_17', N'Base_Role', N'修改者', N'ModifyName', 6, 1, NULL, 0, 0, 1, 0, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, NULL, 1, 1, 1, NULL, NULL, NULL, 0, CAST(N'2022-06-01T10:51:54.5594374' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'string', NULL, NULL)
GO
INSERT [dbo].[Base_CommonFormConfig] ([Id], [Table], [Header], [PropertyName], [DisplayIndex], [Type], [StringFormat], [Visibility], [ControlType], [IsReadOnly], [IsRequired], [ItemSource], [Value], [SortMemberPath], [Converter], [ConverterParameter], [HorizontalAlignment], [MaxWidth], [MinWidth], [Width], [CanUserReorder], [CanUserResize], [CanUserSort], [CellStyle], [BackgroundExpression], [ForegroundExpression], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [HeaderStyle], [PropertyType], [ErrorMessage], [Regex]) VALUES (N'Id3_1', N'Base_AppSecret', N'应用Id', N'AppId', 0, 0, NULL, 0, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, NULL, 0, 0, 0, NULL, NULL, NULL, 0, CAST(N'2022-06-01T10:51:54.5594378' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'string', NULL, NULL)
GO
INSERT [dbo].[Base_CommonFormConfig] ([Id], [Table], [Header], [PropertyName], [DisplayIndex], [Type], [StringFormat], [Visibility], [ControlType], [IsReadOnly], [IsRequired], [ItemSource], [Value], [SortMemberPath], [Converter], [ConverterParameter], [HorizontalAlignment], [MaxWidth], [MinWidth], [Width], [CanUserReorder], [CanUserResize], [CanUserSort], [CellStyle], [BackgroundExpression], [ForegroundExpression], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [HeaderStyle], [PropertyType], [ErrorMessage], [Regex]) VALUES (N'Id3_11', N'Base_AppSecret', N'Id', N'Id', 0, 1, NULL, 2, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, NULL, 1, 1, 1, NULL, NULL, NULL, 0, CAST(N'2022-06-01T10:51:54.5594387' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'string', NULL, NULL)
GO
INSERT [dbo].[Base_CommonFormConfig] ([Id], [Table], [Header], [PropertyName], [DisplayIndex], [Type], [StringFormat], [Visibility], [ControlType], [IsReadOnly], [IsRequired], [ItemSource], [Value], [SortMemberPath], [Converter], [ConverterParameter], [HorizontalAlignment], [MaxWidth], [MinWidth], [Width], [CanUserReorder], [CanUserResize], [CanUserSort], [CellStyle], [BackgroundExpression], [ForegroundExpression], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [HeaderStyle], [PropertyType], [ErrorMessage], [Regex]) VALUES (N'Id3_12', N'Base_AppSecret', N'应用Id', N'AppId', 1, 1, NULL, 0, 0, 0, 1, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, NULL, 1, 1, 1, NULL, NULL, NULL, 0, CAST(N'2022-06-01T10:51:54.5594390' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'string', N'请输入应用Id', NULL)
GO
INSERT [dbo].[Base_CommonFormConfig] ([Id], [Table], [Header], [PropertyName], [DisplayIndex], [Type], [StringFormat], [Visibility], [ControlType], [IsReadOnly], [IsRequired], [ItemSource], [Value], [SortMemberPath], [Converter], [ConverterParameter], [HorizontalAlignment], [MaxWidth], [MinWidth], [Width], [CanUserReorder], [CanUserResize], [CanUserSort], [CellStyle], [BackgroundExpression], [ForegroundExpression], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [HeaderStyle], [PropertyType], [ErrorMessage], [Regex]) VALUES (N'Id3_13', N'Base_AppSecret', N'密钥', N'AppSecret', 2, 1, NULL, 0, 0, 0, 1, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, NULL, 1, 1, 1, NULL, NULL, NULL, 0, CAST(N'2022-06-01T10:51:54.5594393' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'string', N'请输入密钥', NULL)
GO
INSERT [dbo].[Base_CommonFormConfig] ([Id], [Table], [Header], [PropertyName], [DisplayIndex], [Type], [StringFormat], [Visibility], [ControlType], [IsReadOnly], [IsRequired], [ItemSource], [Value], [SortMemberPath], [Converter], [ConverterParameter], [HorizontalAlignment], [MaxWidth], [MinWidth], [Width], [CanUserReorder], [CanUserResize], [CanUserSort], [CellStyle], [BackgroundExpression], [ForegroundExpression], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [HeaderStyle], [PropertyType], [ErrorMessage], [Regex]) VALUES (N'Id3_14', N'Base_AppSecret', N'应用名', N'AppName', 3, 1, NULL, 0, 0, 0, 1, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, NULL, 1, 1, 1, NULL, NULL, NULL, 0, CAST(N'2022-06-01T10:51:54.5594398' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'string', N'请输入应用名', NULL)
GO
INSERT [dbo].[Base_CommonFormConfig] ([Id], [Table], [Header], [PropertyName], [DisplayIndex], [Type], [StringFormat], [Visibility], [ControlType], [IsReadOnly], [IsRequired], [ItemSource], [Value], [SortMemberPath], [Converter], [ConverterParameter], [HorizontalAlignment], [MaxWidth], [MinWidth], [Width], [CanUserReorder], [CanUserResize], [CanUserSort], [CellStyle], [BackgroundExpression], [ForegroundExpression], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [HeaderStyle], [PropertyType], [ErrorMessage], [Regex]) VALUES (N'Id3_15', N'Base_AppSecret', N'创建时间', N'CreateTime', 4, 1, NULL, 0, 0, 1, 0, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, NULL, 1, 1, 1, NULL, NULL, NULL, 0, CAST(N'2022-06-01T10:51:54.5594400' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'datetime', NULL, NULL)
GO
INSERT [dbo].[Base_CommonFormConfig] ([Id], [Table], [Header], [PropertyName], [DisplayIndex], [Type], [StringFormat], [Visibility], [ControlType], [IsReadOnly], [IsRequired], [ItemSource], [Value], [SortMemberPath], [Converter], [ConverterParameter], [HorizontalAlignment], [MaxWidth], [MinWidth], [Width], [CanUserReorder], [CanUserResize], [CanUserSort], [CellStyle], [BackgroundExpression], [ForegroundExpression], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [HeaderStyle], [PropertyType], [ErrorMessage], [Regex]) VALUES (N'Id3_16', N'Base_AppSecret', N'修改时间', N'ModifyTime', 5, 1, NULL, 0, 0, 1, 0, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, NULL, 1, 1, 1, NULL, NULL, NULL, 0, CAST(N'2022-06-01T10:51:54.5594403' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'datetime', NULL, NULL)
GO
INSERT [dbo].[Base_CommonFormConfig] ([Id], [Table], [Header], [PropertyName], [DisplayIndex], [Type], [StringFormat], [Visibility], [ControlType], [IsReadOnly], [IsRequired], [ItemSource], [Value], [SortMemberPath], [Converter], [ConverterParameter], [HorizontalAlignment], [MaxWidth], [MinWidth], [Width], [CanUserReorder], [CanUserResize], [CanUserSort], [CellStyle], [BackgroundExpression], [ForegroundExpression], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [HeaderStyle], [PropertyType], [ErrorMessage], [Regex]) VALUES (N'Id3_17', N'Base_AppSecret', N'创建者', N'CreatorName', 6, 1, NULL, 0, 0, 1, 0, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, NULL, 1, 1, 1, NULL, NULL, NULL, 0, CAST(N'2022-06-01T10:51:54.5594407' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'string', NULL, NULL)
GO
INSERT [dbo].[Base_CommonFormConfig] ([Id], [Table], [Header], [PropertyName], [DisplayIndex], [Type], [StringFormat], [Visibility], [ControlType], [IsReadOnly], [IsRequired], [ItemSource], [Value], [SortMemberPath], [Converter], [ConverterParameter], [HorizontalAlignment], [MaxWidth], [MinWidth], [Width], [CanUserReorder], [CanUserResize], [CanUserSort], [CellStyle], [BackgroundExpression], [ForegroundExpression], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [HeaderStyle], [PropertyType], [ErrorMessage], [Regex]) VALUES (N'Id3_18', N'Base_AppSecret', N'修改者', N'ModifyName', 7, 1, NULL, 0, 0, 1, 0, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, NULL, 1, 1, 1, NULL, NULL, NULL, 0, CAST(N'2022-06-01T10:51:54.5594410' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'string', NULL, NULL)
GO
INSERT [dbo].[Base_CommonFormConfig] ([Id], [Table], [Header], [PropertyName], [DisplayIndex], [Type], [StringFormat], [Visibility], [ControlType], [IsReadOnly], [IsRequired], [ItemSource], [Value], [SortMemberPath], [Converter], [ConverterParameter], [HorizontalAlignment], [MaxWidth], [MinWidth], [Width], [CanUserReorder], [CanUserResize], [CanUserSort], [CellStyle], [BackgroundExpression], [ForegroundExpression], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [HeaderStyle], [PropertyType], [ErrorMessage], [Regex]) VALUES (N'Id3_2', N'Base_AppSecret', N'应用名', N'AppName', 1, 0, NULL, 0, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, NULL, 0, 0, 0, NULL, NULL, NULL, 0, CAST(N'2022-06-01T10:51:54.5594380' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'string', NULL, NULL)
GO
INSERT [dbo].[Base_DbLink] ([Id], [LinkName], [ConnectionStr], [DbType], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1421455377660121088', N'BaseDb', N'Data Source=.;Initial Catalog=Colder.Admin.AntdVue;Integrated Security=True;Pooling=true;', N'SqlServer', 0, CAST(N'2021-07-31T20:59:06.0558609' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Department] ([Id], [Name], [ParentId], [ParentIds], [ParentNames], [Level], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'Id1', N'Wpf控件公司', NULL, NULL, NULL, 0, 0, CAST(N'2022-06-01T11:42:15.3562746' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Department] ([Id], [Name], [ParentId], [ParentIds], [ParentNames], [Level], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'Id2', N'UI部门', N'Id1', NULL, NULL, 0, 0, CAST(N'2022-06-01T11:42:15.3562842' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Department] ([Id], [Name], [ParentId], [ParentIds], [ParentNames], [Level], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'Id2_1', N'UI子部门1', N'Id2', NULL, NULL, 0, 0, CAST(N'2022-06-01T11:42:15.3562850' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Department] ([Id], [Name], [ParentId], [ParentIds], [ParentNames], [Level], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'Id2_2', N'UI子部门2', N'Id2', NULL, NULL, 0, 0, CAST(N'2022-06-01T11:42:15.3562945' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Department] ([Id], [Name], [ParentId], [ParentIds], [ParentNames], [Level], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'Id3', N'C#部门', N'Id1', NULL, NULL, 0, 0, CAST(N'2022-06-01T11:42:15.3562951' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Department] ([Id], [Name], [ParentId], [ParentIds], [ParentNames], [Level], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'Id3_1', N'C#子部门1', N'Id3', NULL, NULL, 0, 0, CAST(N'2022-06-01T11:42:15.3562963' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Department] ([Id], [Name], [ParentId], [ParentIds], [ParentNames], [Level], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'Id3_2', N'C#子部门2', N'Id3', NULL, NULL, 0, 0, CAST(N'2022-06-01T11:42:15.3562967' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Dictionary] ([Id], [ParentId], [Type], [Code], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [Text], [Value], [ControlType], [Remark]) VALUES (N'Id1', NULL, 0, N'', 1, 0, CAST(N'2022-06-01T10:51:54.2115598' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL, N'性别', N'Sex', 2, NULL)
GO
INSERT [dbo].[Base_Dictionary] ([Id], [ParentId], [Type], [Code], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [Text], [Value], [ControlType], [Remark]) VALUES (N'Id1_1', N'Id1', 1, N'', 1, 0, CAST(N'2022-06-01T10:51:54.2115662' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL, N'女', N'0', 0, NULL)
GO
INSERT [dbo].[Base_Dictionary] ([Id], [ParentId], [Type], [Code], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [Text], [Value], [ControlType], [Remark]) VALUES (N'Id1_2', N'Id1', 1, N'', 2, 0, CAST(N'2022-06-01T10:51:54.2115666' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL, N'男', N'1', 0, NULL)
GO
INSERT [dbo].[Base_Dictionary] ([Id], [ParentId], [Type], [Code], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [Text], [Value], [ControlType], [Remark]) VALUES (N'Id10', NULL, 0, N'', 10, 0, CAST(N'2022-06-01T10:51:54.2115690' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL, N'修改时间', N'ModifyTime', 0, NULL)
GO
INSERT [dbo].[Base_Dictionary] ([Id], [ParentId], [Type], [Code], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [Text], [Value], [ControlType], [Remark]) VALUES (N'Id11', NULL, 0, N'', 11, 0, CAST(N'2022-06-01T10:51:54.2115693' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL, N'创建者', N'CreatorName', 0, NULL)
GO
INSERT [dbo].[Base_Dictionary] ([Id], [ParentId], [Type], [Code], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [Text], [Value], [ControlType], [Remark]) VALUES (N'Id12', NULL, 0, N'', 12, 0, CAST(N'2022-06-01T10:51:54.2115695' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL, N'修改者', N'ModifyName', 0, NULL)
GO
INSERT [dbo].[Base_Dictionary] ([Id], [ParentId], [Type], [Code], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [Text], [Value], [ControlType], [Remark]) VALUES (N'Id2', NULL, 0, N'', 2, 0, CAST(N'2022-06-01T10:51:54.2115668' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL, N'姓名', N'UserName', 0, NULL)
GO
INSERT [dbo].[Base_Dictionary] ([Id], [ParentId], [Type], [Code], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [Text], [Value], [ControlType], [Remark]) VALUES (N'Id3', NULL, 0, N'', 3, 0, CAST(N'2022-06-01T10:51:54.2115670' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL, N'真实姓名', N'RealName', 0, NULL)
GO
INSERT [dbo].[Base_Dictionary] ([Id], [ParentId], [Type], [Code], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [Text], [Value], [ControlType], [Remark]) VALUES (N'Id4', NULL, 0, N'', 4, 0, CAST(N'2022-06-01T10:51:54.2115677' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL, N'密码', N'Password', 0, NULL)
GO
INSERT [dbo].[Base_Dictionary] ([Id], [ParentId], [Type], [Code], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [Text], [Value], [ControlType], [Remark]) VALUES (N'Id5', NULL, 0, N'', 5, 0, CAST(N'2022-06-01T10:51:54.2115679' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL, N'生日', N'Birthday', 0, NULL)
GO
INSERT [dbo].[Base_Dictionary] ([Id], [ParentId], [Type], [Code], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [Text], [Value], [ControlType], [Remark]) VALUES (N'Id6', NULL, 0, N'Base_Role', 6, 0, CAST(N'2022-06-01T10:51:54.2115681' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL, N'角色', N'RoleIdList', 6, NULL)
GO
INSERT [dbo].[Base_Dictionary] ([Id], [ParentId], [Type], [Code], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [Text], [Value], [ControlType], [Remark]) VALUES (N'Id7', NULL, 0, N'Base_Department', 7, 0, CAST(N'2022-06-01T10:51:54.2115683' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL, N'部门', N'DepartmentId', 5, NULL)
GO
INSERT [dbo].[Base_Dictionary] ([Id], [ParentId], [Type], [Code], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [Text], [Value], [ControlType], [Remark]) VALUES (N'Id8', NULL, 0, N'', 8, 0, CAST(N'2022-06-01T10:51:54.2115685' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL, N'手机号码', N'PhoneNumber', 0, NULL)
GO
INSERT [dbo].[Base_Dictionary] ([Id], [ParentId], [Type], [Code], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [Text], [Value], [ControlType], [Remark]) VALUES (N'Id9', NULL, 0, N'', 9, 0, CAST(N'2022-06-01T10:51:54.2115688' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL, N'创建时间', N'CreateTime', 0, NULL)
GO
INSERT [dbo].[Base_Role] ([Id], [RoleName], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1531843539074289664', N'部门管理员', 0, CAST(N'2022-06-01T11:42:14.6499278' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Role] ([Id], [RoleName], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1531843540269666304', N'超级管理员', 0, CAST(N'2022-06-01T11:42:14.9341512' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_User] ([Id], [UserName], [Password], [RealName], [Sex], [Birthday], [DepartmentId], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [Avatar], [PhoneNumber]) VALUES (N'1531843544593993728', N'alice', N'e10adc3949ba59abbe56e057f20f883e', NULL, 0, NULL, N'Id2', 0, CAST(N'2022-06-01T11:42:15.9656797' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_User] ([Id], [UserName], [Password], [RealName], [Sex], [Birthday], [DepartmentId], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [Avatar], [PhoneNumber]) VALUES (N'1531843545260888064', N'bob', N'e10adc3949ba59abbe56e057f20f883e', NULL, 0, NULL, N'Id3', 0, CAST(N'2022-06-01T11:42:16.1245166' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_User] ([Id], [UserName], [Password], [RealName], [Sex], [Birthday], [DepartmentId], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [Avatar], [PhoneNumber]) VALUES (N'1531892930329972736', N'test', N'098f6bcd4621d373cade4e832627b4f6', NULL, 0, NULL, NULL, 0, CAST(N'2022-06-01T14:58:30.4420000' AS DateTime2), CAST(N'2022-06-01T15:24:47.7809361' AS DateTime2), N'Admin', N'Admin', N'Admin', N'Admin', NULL, NULL, N'13207067777')
GO
INSERT [dbo].[Base_User] ([Id], [UserName], [Password], [RealName], [Sex], [Birthday], [DepartmentId], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [Avatar], [PhoneNumber]) VALUES (N'1531895920516403200', N'test2', N'ad0234829205b9033196ba818f7a872b', N'test3', 0, CAST(N'2022-06-01T15:27:42.0000000' AS DateTime2), N'Id2_2', 0, CAST(N'2022-06-01T15:10:23.0000000' AS DateTime2), CAST(N'2022-06-01T15:28:02.0552591' AS DateTime2), N'Admin', N'Admin', N'Admin', N'Admin', NULL, NULL, N'13244445555')
GO
INSERT [dbo].[Base_User] ([Id], [UserName], [Password], [RealName], [Sex], [Birthday], [DepartmentId], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [Avatar], [PhoneNumber]) VALUES (N'Admin', N'Admin', N'e3afed0047b08059d0fada10f400c1e5', NULL, 0, NULL, N'Id1', 0, CAST(N'2022-06-01T11:42:15.7231479' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_UserLog] ([Id], [CreateTime], [CreatorId], [CreatorName], [LogType], [LogContent]) VALUES (N'1527634829103861760', CAST(N'2022-05-20T20:58:19.9988424' AS DateTime2), N'Admin', N'Admin', N'部门管理', N'添加部门名:部门1')
GO
INSERT [dbo].[Base_UserLog] ([Id], [CreateTime], [CreatorId], [CreatorName], [LogType], [LogContent]) VALUES (N'1527636271042662400', CAST(N'2022-05-20T21:04:03.7839306' AS DateTime2), N'Admin', N'Admin', N'部门管理', N'删除部门名:部门1')
GO
INSERT [dbo].[Base_UserLog] ([Id], [CreateTime], [CreatorId], [CreatorName], [LogType], [LogContent]) VALUES (N'1527837954339246080', CAST(N'2022-05-21T10:25:28.8288141' AS DateTime2), N'Admin', N'Admin', N'部门管理', N'添加部门名:部门2')
GO
INSERT [dbo].[Base_UserLog] ([Id], [CreateTime], [CreatorId], [CreatorName], [LogType], [LogContent]) VALUES (N'1527838494259417088', CAST(N'2022-05-21T10:27:37.5559976' AS DateTime2), N'Admin', N'Admin', N'系统用户管理', N'修改用户:bob')
GO
INSERT [dbo].[Base_UserLog] ([Id], [CreateTime], [CreatorId], [CreatorName], [LogType], [LogContent]) VALUES (N'1527839696711847936', CAST(N'2022-05-21T10:32:24.2423595' AS DateTime2), N'Admin', N'Admin', N'系统用户管理', N'修改用户:bob')
GO
INSERT [dbo].[Base_UserLog] ([Id], [CreateTime], [CreatorId], [CreatorName], [LogType], [LogContent]) VALUES (N'1527840338146758656', CAST(N'2022-05-21T10:34:57.1725743' AS DateTime2), N'Admin', N'Admin', N'系统用户管理', N'修改用户:bob')
GO
INSERT [dbo].[Base_UserLog] ([Id], [CreateTime], [CreatorId], [CreatorName], [LogType], [LogContent]) VALUES (N'1531272262139777024', CAST(N'2022-05-30T21:52:11.6145245' AS DateTime2), N'Admin', N'Admin', N'系统用户管理', N'修改用户:bob')
GO
INSERT [dbo].[Base_UserLog] ([Id], [CreateTime], [CreatorId], [CreatorName], [LogType], [LogContent]) VALUES (N'1531273779433443328', CAST(N'2022-05-30T21:58:13.3650224' AS DateTime2), N'Admin', N'Admin', N'系统用户管理', N'修改用户:bob')
GO
INSERT [dbo].[Base_UserLog] ([Id], [CreateTime], [CreatorId], [CreatorName], [LogType], [LogContent]) VALUES (N'1531273810483875840', CAST(N'2022-05-30T21:58:20.7684250' AS DateTime2), N'Admin', N'Admin', N'系统用户管理', N'修改用户:bob')
GO
INSERT [dbo].[Base_UserLog] ([Id], [CreateTime], [CreatorId], [CreatorName], [LogType], [LogContent]) VALUES (N'1531428457446117376', CAST(N'2022-05-31T08:12:51.4771172' AS DateTime2), N'Admin', N'Admin', N'系统用户管理', N'修改用户:bob')
GO
INSERT [dbo].[Base_UserLog] ([Id], [CreateTime], [CreatorId], [CreatorName], [LogType], [LogContent]) VALUES (N'1531431770895945728', CAST(N'2022-05-31T08:26:01.4651919' AS DateTime2), N'Admin', N'Admin', N'系统用户管理', N'修改用户:bob2')
GO
INSERT [dbo].[Base_UserLog] ([Id], [CreateTime], [CreatorId], [CreatorName], [LogType], [LogContent]) VALUES (N'1531525817304092672', CAST(N'2022-05-31T14:39:43.8768364' AS DateTime2), N'Admin', N'Admin', N'系统用户管理', N'添加用户:test2')
GO
INSERT [dbo].[Base_UserLog] ([Id], [CreateTime], [CreatorId], [CreatorName], [LogType], [LogContent]) VALUES (N'1531525886715629568', CAST(N'2022-05-31T14:40:00.4253750' AS DateTime2), N'Admin', N'Admin', N'系统用户管理', N'删除用户:test2')
GO
INSERT [dbo].[Base_UserLog] ([Id], [CreateTime], [CreatorId], [CreatorName], [LogType], [LogContent]) VALUES (N'1531536453685743616', CAST(N'2022-05-31T15:21:59.7874753' AS DateTime2), N'Admin', N'Admin', N'系统用户管理', N'删除用户:bob')
GO
INSERT [dbo].[Base_UserLog] ([Id], [CreateTime], [CreatorId], [CreatorName], [LogType], [LogContent]) VALUES (N'1531536487009488896', CAST(N'2022-05-31T15:22:07.7325542' AS DateTime2), N'Admin', N'Admin', N'系统用户管理', N'修改用户:bob')
GO
INSERT [dbo].[Base_UserLog] ([Id], [CreateTime], [CreatorId], [CreatorName], [LogType], [LogContent]) VALUES (N'1531536514033389568', CAST(N'2022-05-31T15:22:14.1751987' AS DateTime2), N'Admin', N'Admin', N'系统用户管理', N'修改用户:bob')
GO
INSERT [dbo].[Base_UserLog] ([Id], [CreateTime], [CreatorId], [CreatorName], [LogType], [LogContent]) VALUES (N'1531537308891746304', CAST(N'2022-05-31T15:25:23.6844568' AS DateTime2), N'Admin', N'Admin', N'系统用户管理', N'修改用户:Admin')
GO
INSERT [dbo].[Base_UserLog] ([Id], [CreateTime], [CreatorId], [CreatorName], [LogType], [LogContent]) VALUES (N'1531537360854978560', CAST(N'2022-05-31T15:25:36.0737992' AS DateTime2), N'Admin', N'Admin', N'系统用户管理', N'修改用户:Admin')
GO
INSERT [dbo].[Base_UserLog] ([Id], [CreateTime], [CreatorId], [CreatorName], [LogType], [LogContent]) VALUES (N'1531537404584792064', CAST(N'2022-05-31T15:25:46.4999043' AS DateTime2), N'Admin', N'Admin', N'系统用户管理', N'修改用户:Admin')
GO
INSERT [dbo].[Base_UserLog] ([Id], [CreateTime], [CreatorId], [CreatorName], [LogType], [LogContent]) VALUES (N'1531539303509790720', CAST(N'2022-05-31T15:33:19.2383286' AS DateTime2), N'Admin', N'Admin', N'系统用户管理', N'修改用户:Admin')
GO
INSERT [dbo].[Base_UserLog] ([Id], [CreateTime], [CreatorId], [CreatorName], [LogType], [LogContent]) VALUES (N'1531575803395969024', CAST(N'2022-05-31T17:58:21.4891626' AS DateTime2), N'Admin', N'Admin', N'系统用户管理', N'修改用户:bob')
GO
INSERT [dbo].[Base_UserLog] ([Id], [CreateTime], [CreatorId], [CreatorName], [LogType], [LogContent]) VALUES (N'1531575866172116992', CAST(N'2022-05-31T17:58:36.4566169' AS DateTime2), N'Admin', N'Admin', N'系统用户管理', N'修改用户:bob')
GO
INSERT [dbo].[Base_UserLog] ([Id], [CreateTime], [CreatorId], [CreatorName], [LogType], [LogContent]) VALUES (N'1531839228508377088', CAST(N'2022-06-01T11:25:06.9310891' AS DateTime2), N'Admin', N'Admin', N'系统角色管理', N'修改角色:部门管理员')
GO
INSERT [dbo].[Base_UserLog] ([Id], [CreateTime], [CreatorId], [CreatorName], [LogType], [LogContent]) VALUES (N'1531841131598319616', CAST(N'2022-06-01T11:32:40.6625895' AS DateTime2), N'Admin', N'Admin', N'系统角色管理', N'修改角色:部门管理员')
GO
INSERT [dbo].[Base_UserLog] ([Id], [CreateTime], [CreatorId], [CreatorName], [LogType], [LogContent]) VALUES (N'1531841165307940864', CAST(N'2022-06-01T11:32:48.6996985' AS DateTime2), N'Admin', N'Admin', N'系统角色管理', N'修改角色:部门管理员')
GO
INSERT [dbo].[Base_UserLog] ([Id], [CreateTime], [CreatorId], [CreatorName], [LogType], [LogContent]) VALUES (N'1531892931080753152', CAST(N'2022-06-01T14:58:30.6214783' AS DateTime2), N'Admin', N'Admin', N'系统用户管理', N'添加用户:test')
GO
INSERT [dbo].[Base_UserLog] ([Id], [CreateTime], [CreatorId], [CreatorName], [LogType], [LogContent]) VALUES (N'1531895187314315264', CAST(N'2022-06-01T15:07:28.5490476' AS DateTime2), N'Admin', N'Admin', N'系统角色管理', N'添加角色:test')
GO
INSERT [dbo].[Base_UserLog] ([Id], [CreateTime], [CreatorId], [CreatorName], [LogType], [LogContent]) VALUES (N'1531895216603140096', CAST(N'2022-06-01T15:07:35.5327213' AS DateTime2), N'Admin', N'Admin', N'系统角色管理', N'删除角色:test')
GO
INSERT [dbo].[Base_UserLog] ([Id], [CreateTime], [CreatorId], [CreatorName], [LogType], [LogContent]) VALUES (N'1531895847141249024', CAST(N'2022-06-01T15:10:05.8649450' AS DateTime2), N'Admin', N'Admin', N'系统用户管理', N'添加用户:test2')
GO
INSERT [dbo].[Base_UserLog] ([Id], [CreateTime], [CreatorId], [CreatorName], [LogType], [LogContent]) VALUES (N'1531895870683877376', CAST(N'2022-06-01T15:10:11.4773485' AS DateTime2), N'Admin', N'Admin', N'系统用户管理', N'删除用户:test2')
GO
INSERT [dbo].[Base_UserLog] ([Id], [CreateTime], [CreatorId], [CreatorName], [LogType], [LogContent]) VALUES (N'1531895920608677888', CAST(N'2022-06-01T15:10:23.3800108' AS DateTime2), N'Admin', N'Admin', N'系统用户管理', N'添加用户:test2')
GO
INSERT [dbo].[Base_UserLog] ([Id], [CreateTime], [CreatorId], [CreatorName], [LogType], [LogContent]) VALUES (N'1531896000052989952', CAST(N'2022-06-01T15:10:42.3219004' AS DateTime2), N'Admin', N'Admin', N'系统用户管理', N'修改用户:test2')
GO
INSERT [dbo].[Base_UserLog] ([Id], [CreateTime], [CreatorId], [CreatorName], [LogType], [LogContent]) VALUES (N'1531896831359848448', CAST(N'2022-06-01T15:14:00.5202408' AS DateTime2), N'Admin', N'Admin', N'系统用户管理', N'修改用户:test2')
GO
INSERT [dbo].[Base_UserLog] ([Id], [CreateTime], [CreatorId], [CreatorName], [LogType], [LogContent]) VALUES (N'1531899424681234432', CAST(N'2022-06-01T15:24:18.8172008' AS DateTime2), N'Admin', N'Admin', N'系统用户管理', N'修改用户:test2')
GO
INSERT [dbo].[Base_UserLog] ([Id], [CreateTime], [CreatorId], [CreatorName], [LogType], [LogContent]) VALUES (N'1531899454477570048', CAST(N'2022-06-01T15:24:25.9207896' AS DateTime2), N'Admin', N'Admin', N'系统用户管理', N'修改用户:test')
GO
INSERT [dbo].[Base_UserLog] ([Id], [CreateTime], [CreatorId], [CreatorName], [LogType], [LogContent]) VALUES (N'1531899487507714048', CAST(N'2022-06-01T15:24:33.7959349' AS DateTime2), N'Admin', N'Admin', N'系统用户管理', N'修改用户:test')
GO
INSERT [dbo].[Base_UserLog] ([Id], [CreateTime], [CreatorId], [CreatorName], [LogType], [LogContent]) VALUES (N'1531899546219581440', CAST(N'2022-06-01T15:24:47.7931171' AS DateTime2), N'Admin', N'Admin', N'系统用户管理', N'修改用户:test')
GO
INSERT [dbo].[Base_UserLog] ([Id], [CreateTime], [CreatorId], [CreatorName], [LogType], [LogContent]) VALUES (N'1531899591761334272', CAST(N'2022-06-01T15:24:58.6519906' AS DateTime2), N'Admin', N'Admin', N'系统用户管理', N'修改用户:test2')
GO
INSERT [dbo].[Base_UserLog] ([Id], [CreateTime], [CreatorId], [CreatorName], [LogType], [LogContent]) VALUES (N'1531899759348944896', CAST(N'2022-06-01T15:25:38.6079807' AS DateTime2), N'Admin', N'Admin', N'接口密钥管理', N'添加应用Id:test')
GO
INSERT [dbo].[Base_UserLog] ([Id], [CreateTime], [CreatorId], [CreatorName], [LogType], [LogContent]) VALUES (N'1531899782006575104', CAST(N'2022-06-01T15:25:44.0093501' AS DateTime2), N'Admin', N'Admin', N'接口密钥管理', N'修改应用Id:test')
GO
INSERT [dbo].[Base_UserLog] ([Id], [CreateTime], [CreatorId], [CreatorName], [LogType], [LogContent]) VALUES (N'1531900361181237248', CAST(N'2022-06-01T15:28:02.0953294' AS DateTime2), N'Admin', N'Admin', N'系统用户管理', N'修改用户:test2')
GO
INSERT [dbo].[Base_UserLog] ([Id], [CreateTime], [CreatorId], [CreatorName], [LogType], [LogContent]) VALUES (N'1531901940131172352', CAST(N'2022-06-01T15:34:18.5467006' AS DateTime2), N'Admin', N'Admin', N'系统角色管理', N'添加角色:test')
GO
INSERT [dbo].[Base_UserLog] ([Id], [CreateTime], [CreatorId], [CreatorName], [LogType], [LogContent]) VALUES (N'1531902078140551168', CAST(N'2022-06-01T15:34:51.4509623' AS DateTime2), N'Admin', N'Admin', N'系统角色管理', N'删除角色:test')
GO
INSERT [dbo].[Base_UserRole] ([Id], [CreateTime], [CreatorId], [Deleted], [UserId], [RoleId]) VALUES (N'1531843543990013952', CAST(N'2022-06-01T11:42:15.8220188' AS DateTime2), NULL, 0, N'Admin', N'1531843540269666304')
GO
INSERT [dbo].[Base_UserRole] ([Id], [CreateTime], [CreatorId], [Deleted], [UserId], [RoleId]) VALUES (N'1531843544933732352', CAST(N'2022-06-01T11:42:16.0460921' AS DateTime2), NULL, 0, N'1531843544593993728', N'1531843539074289664')
GO
INSERT [dbo].[Base_UserRole] ([Id], [CreateTime], [CreatorId], [Deleted], [UserId], [RoleId]) VALUES (N'1531900361059602432', CAST(N'2022-06-01T15:28:02.0664305' AS DateTime2), NULL, 0, N'1531895920516403200', N'1531843539074289664')
GO
INSERT [dbo].[Base_UserRole] ([Id], [CreateTime], [CreatorId], [Deleted], [UserId], [RoleId]) VALUES (N'1531900361059602433', CAST(N'2022-06-01T15:28:02.0666571' AS DateTime2), NULL, 0, N'1531895920516403200', N'1531843540269666304')
GO
INSERT [dbo].[OA_DefForm] ([Id], [WorkflowJSON], [JSONId], [JSONVersion], [Type], [Name], [Text], [Sort], [Status], [Value], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1421455381778927616', N'{
  "Id": "1274618511506804736",
  "Version": 0,
  "DataType": "Coldairarrow.Util.OAData, Coldairarrow.Util",
  "FirstStart": true,
  "Steps": [
    {
      "Id": "node2",
      "Label": "开始",
      "StepType": "AIStudio.Service.WorkflowCore.OAStartStep, AIStudio.Service",
      "NextStepId": "node9",
      "Status": 0,
      "ActRules": {}
    },
    {
      "Id": "node9",
      "Label": "主管审批",
      "StepType": "AIStudio.Service.WorkflowCore.OAMiddleStep, AIStudio.Service",
      "NextStepId": "node137",
      "Status": 0,
      "ActRules": { "UserIds": [ "Admin" ] }
    },
    {
      "Id": "node137",
      "Label": "人力审批",
      "StepType": "AIStudio.Service.WorkflowCore.OAMiddleStep, AIStudio.Service",
      "NextStepId": "node144",
      "Status": 0,
      "ActRules": { "UserIds": [ "Admin" ] }
    },
    {
      "Id": "node144",
      "Label": "人力归档",
      "StepType": "AIStudio.Service.WorkflowCore.OAMiddleStep, AIStudio.Service",
      "NextStepId": "node61",
      "Status": 0,
      "ActRules": { "UserIds": [ "Admin" ] }
    },
    {
      "Id": "node61",
      "Label": "结束",
      "StepType": "AIStudio.Service.WorkflowCore.OAEndStep, AIStudio.Service",
      "Status": 0,
      "ActRules": {}
    }
  ],
  "CurrentStepIds": [],
  "Flag": 0.0,
  "nodes": [
    {
      "id": "node2",
      "name": "开始节点",
      "color": "#1890ff",
      "image": "/assets/Shape.486da24a.svg",
      "label": "开始",
      "offsetX": 85,
      "offsetY": 26,
      "shape": "customNode",
      "size": [ 170, 34 ],
      "stateImage": "/assets/start.e502ed95.svg",
      "type": "node",
      "x": 221.55001831054688,
      "y": 84.0,
      "inPoints": [ [ 0.0, 0.5 ] ],
      "outPoints": [ [ 1.0, 0.5 ] ],
      "isDoingStart": false,
      "isDoingEnd": false
    },
    {
      "id": "node9",
      "name": "中间节点",
      "color": "#1890ff",
      "image": "/assets/Shape.486da24a.svg",
      "label": "主管审批",
      "offsetX": 76,
      "offsetY": 21,
      "shape": "customNode",
      "size": [ 170, 34 ],
      "stateImage": "/assets/jiahao.ecf71c51.svg",
      "type": "node",
      "x": 220.55001831054688,
      "y": 161.0,
      "inPoints": [ [ 0.0, 0.5 ] ],
      "outPoints": [ [ 1.0, 0.5 ] ],
      "isDoingStart": false,
      "isDoingEnd": false,
      "UserIds": [ "Admin" ]
    },
    {
      "id": "node61",
      "name": "结束节点",
      "color": "#1890ff",
      "image": "/assets/Shape.486da24a.svg",
      "label": "结束",
      "offsetX": 81,
      "offsetY": 25,
      "shape": "customNode",
      "size": [ 170, 34 ],
      "stateImage": "/assets/end.dfe4a5ab.svg",
      "type": "node",
      "x": 218.55001831054688,
      "y": 408.0,
      "inPoints": [ [ 0.0, 0.5 ] ],
      "outPoints": [ [ 1.0, 0.5 ] ],
      "isDoingStart": false,
      "isDoingEnd": false
    },
    {
      "id": "node137",
      "name": "中间节点",
      "color": "#1890ff",
      "image": "/assets/Shape.486da24a.svg",
      "label": "人力审批",
      "offsetX": 116,
      "offsetY": 20,
      "shape": "customNode",
      "size": [ 170, 34 ],
      "stateImage": "/assets/jiahao.ecf71c51.svg",
      "type": "node",
      "x": 221.55001831054688,
      "y": 243.0,
      "inPoints": [ [ 0.0, 0.5 ] ],
      "outPoints": [ [ 1.0, 0.5 ] ],
      "isDoingStart": false,
      "isDoingEnd": false,
      "UserIds": [ "Admin" ]
    },
    {
      "id": "node144",
      "name": "中间节点",
      "color": "#1890ff",
      "image": "/assets/Shape.486da24a.svg",
      "label": "人力归档",
      "offsetX": 102,
      "offsetY": 15,
      "shape": "customNode",
      "size": [ 170, 34 ],
      "stateImage": "/assets/jiahao.ecf71c51.svg",
      "type": "node",
      "x": 220.55001831054688,
      "y": 323.0,
      "inPoints": [ [ 0.0, 0.5 ] ],
      "outPoints": [ [ 1.0, 0.5 ] ],
      "isDoingStart": false,
      "isDoingEnd": false,
      "UserIds": [ "Admin" ]
    }
  ],
  "edges": [
    {
      "id": "edge56",
      "end": {
        "x": 0.0,
        "y": -17.0
      },
      "endPoint": {
        "x": 220.77729103781962,
        "y": 143.5
      },
      "start": {
        "x": 0.0,
        "y": 17.0
      },
      "startPoint": {
        "x": 221.32274558327413,
        "y": 101.5
      },
      "shape": "customEdge",
      "source": "node2",
      "sourceId": "node2",
      "target": "node9",
      "targetId": "node9",
      "type": "edge"
    },
    {
      "id": "edge180",
      "end": {
        "x": 0.0,
        "y": -17.0
      },
      "endPoint": {
        "x": 221.33660367640056,
        "y": 225.5
      },
      "start": {
        "x": 0.0,
        "y": 17.0
      },
      "startPoint": {
        "x": 220.7634329446932,
        "y": 178.5
      },
      "shape": "customEdge",
      "source": "node9",
      "sourceId": "node9",
      "target": "node137",
      "targetId": "node137",
      "type": "edge"
    },
    {
      "id": "edge219",
      "end": {
        "x": 0.0,
        "y": -17.0
      },
      "endPoint": {
        "x": 220.76876831054688,
        "y": 305.5
      },
      "start": {
        "x": 0.0,
        "y": 17.0
      },
      "startPoint": {
        "x": 221.33126831054688,
        "y": 260.5
      },
      "shape": "customEdge",
      "source": "node137",
      "sourceId": "node137",
      "target": "node144",
      "targetId": "node144",
      "type": "edge"
    },
    {
      "id": "edge261",
      "end": {
        "x": 0.0,
        "y": -17.0
      },
      "endPoint": {
        "x": 218.96178301642922,
        "y": 390.5
      },
      "start": {
        "x": 0.0,
        "y": 17.0
      },
      "startPoint": {
        "x": 220.13825360466453,
        "y": 340.5
      },
      "shape": "customEdge",
      "source": "node144",
      "sourceId": "node144",
      "target": "node61",
      "targetId": "node61",
      "type": "edge"
    }
  ],
  "groups": []
}', N'1274618511506804736', 0, N'请假', N'请假流程', N'最简单的请假流程', 0, 1, NULL, 0, CAST(N'2021-07-31T20:59:07.0595371' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[OA_DefForm] ([Id], [WorkflowJSON], [JSONId], [JSONVersion], [Type], [Name], [Text], [Sort], [Status], [Value], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1421455381871202304', N'{
  "Id": "1274620801831669760",
  "Version": 0,
  "DataType": "Coldairarrow.Util.OAData, Coldairarrow.Util",
  "FirstStart": true,
  "Steps": [
    {
      "Id": "node4",
      "Label": "开始",
      "StepType": "AIStudio.Service.WorkflowCore.OAStartStep, AIStudio.Service",
      "NextStepId": "node11",
      "Status": 0,
      "ActRules": {}
    },
    {
      "Id": "node11",
      "Label": "财务人力同时审批",
      "StepType": "AIStudio.Service.WorkflowCore.OAMiddleStep, AIStudio.Service",
      "NextStepId": "node18",
      "Status": 0,
      "ActRules": {
        "UserIds": [ "Admin", "1267011854366937088", "1267011853830066176" ],
        "ActType": "and"
      }
    },
    {
      "Id": "node18",
      "Label": "结束",
      "StepType": "AIStudio.Service.WorkflowCore.OAEndStep, AIStudio.Service",
      "Status": 0,
      "ActRules": {}
    }
  ],
  "CurrentStepIds": [],
  "Flag": 0.0,
  "nodes": [
    {
      "id": "node4",
      "name": "开始节点",
      "color": "#1890ff",
      "image": "/assets/Shape.486da24a.svg",
      "label": "开始",
      "offsetX": 106,
      "offsetY": 24,
      "shape": "customNode",
      "size": [ 170, 34 ],
      "stateImage": "/assets/start.e502ed95.svg",
      "type": "node",
      "x": 358.5500183105469,
      "y": 112.0,
      "inPoints": [ [ 0.0, 0.5 ] ],
      "outPoints": [ [ 1.0, 0.5 ] ],
      "isDoingStart": false,
      "isDoingEnd": false
    },
    {
      "id": "node11",
      "name": "中间节点",
      "color": "#1890ff",
      "image": "/assets/Shape.486da24a.svg",
      "label": "财务人力同时审批",
      "offsetX": 95,
      "offsetY": 12,
      "shape": "customNode",
      "size": [ 170, 34 ],
      "stateImage": "/assets/jiahao.ecf71c51.svg",
      "type": "node",
      "x": 361.5500183105469,
      "y": 212.0,
      "inPoints": [ [ 0.0, 0.5 ] ],
      "outPoints": [ [ 1.0, 0.5 ] ],
      "isDoingStart": false,
      "isDoingEnd": false,
      "UserIds": [ "Admin", "1267011854366937088", "1267011853830066176" ],
      "ActType": "and"
    },
    {
      "id": "node18",
      "name": "结束节点",
      "color": "#1890ff",
      "image": "/assets/Shape.486da24a.svg",
      "label": "结束",
      "offsetX": 115,
      "offsetY": 22,
      "shape": "customNode",
      "size": [ 170, 34 ],
      "stateImage": "/assets/end.dfe4a5ab.svg",
      "type": "node",
      "x": 363.5500183105469,
      "y": 314.0,
      "inPoints": [ [ 0.0, 0.5 ] ],
      "outPoints": [ [ 1.0, 0.5 ] ],
      "isDoingStart": false,
      "isDoingEnd": false
    }
  ],
  "edges": [
    {
      "id": "edge68",
      "end": {
        "x": 0.0,
        "y": -17.0
      },
      "endPoint": {
        "x": 361.0250183105469,
        "y": 194.5
      },
      "start": {
        "x": 0.0,
        "y": 17.0
      },
      "startPoint": {
        "x": 359.07501831054685,
        "y": 129.5
      },
      "shape": "customEdge",
      "source": "node4",
      "sourceId": "node4",
      "target": "node11",
      "targetId": "node11",
      "type": "edge"
    },
    {
      "id": "edge111",
      "end": {
        "x": 0.0,
        "y": -17.0
      },
      "endPoint": {
        "x": 363.2068810556449,
        "y": 296.5
      },
      "start": {
        "x": 0.0,
        "y": 17.0
      },
      "startPoint": {
        "x": 361.89315556544886,
        "y": 229.5
      },
      "shape": "customEdge",
      "source": "node11",
      "sourceId": "node11",
      "target": "node18",
      "targetId": "node18",
      "type": "edge"
    }
  ],
  "groups": []
}', N'1274620801831669760', 0, N'报销', N'报销审批-与签', N'所有审批人都要同意', 0, 1, NULL, 0, CAST(N'2021-07-31T20:59:07.0652500' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[OA_DefForm] ([Id], [WorkflowJSON], [JSONId], [JSONVersion], [Type], [Name], [Text], [Sort], [Status], [Value], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1421455381896368128', N'{
  "Id": "1274621154383892480",
  "Version": 0,
  "DataType": "Coldairarrow.Util.OAData, Coldairarrow.Util",
  "FirstStart": true,
  "Steps": [
    {
      "Id": "node166",
      "Label": "开始",
      "StepType": "AIStudio.Service.WorkflowCore.OAStartStep, AIStudio.Service",
      "NextStepId": "node173",
      "Status": 0,
      "ActRules": {}
    },
    {
      "Id": "node173",
      "Label": "或签",
      "StepType": "AIStudio.Service.WorkflowCore.OAMiddleStep, AIStudio.Service",
      "NextStepId": "node180",
      "Status": 0,
      "ActRules": {
        "UserIds": [ "1267011853830066176", "1267011854366937088", "Admin" ],
        "ActType": "or"
      }
    },
    {
      "Id": "node180",
      "Label": "结束",
      "StepType": "AIStudio.Service.WorkflowCore.OAEndStep, AIStudio.Service",
      "Status": 0,
      "ActRules": {}
    }
  ],
  "CurrentStepIds": [],
  "Flag": 0.0,
  "nodes": [
    {
      "id": "node166",
      "name": "开始节点",
      "color": "#1890ff",
      "image": "/assets/Shape.486da24a.svg",
      "label": "开始",
      "offsetX": 103,
      "offsetY": 24,
      "shape": "customNode",
      "size": [ 170, 34 ],
      "stateImage": "/assets/start.e502ed95.svg",
      "type": "node",
      "x": 393.5500183105469,
      "y": 75.0,
      "inPoints": [ [ 0.0, 0.5 ] ],
      "outPoints": [ [ 1.0, 0.5 ] ],
      "isDoingStart": false,
      "isDoingEnd": false
    },
    {
      "id": "node173",
      "name": "中间节点",
      "color": "#1890ff",
      "image": "/assets/Shape.486da24a.svg",
      "label": "或签",
      "offsetX": 105,
      "offsetY": 15,
      "shape": "customNode",
      "size": [ 170, 34 ],
      "stateImage": "/assets/jiahao.ecf71c51.svg",
      "type": "node",
      "x": 395.5500183105469,
      "y": 164.0,
      "inPoints": [ [ 0.0, 0.5 ] ],
      "outPoints": [ [ 1.0, 0.5 ] ],
      "isDoingStart": false,
      "isDoingEnd": false,
      "UserIds": [ "1267011853830066176", "1267011854366937088", "Admin" ],
      "ActType": "or"
    },
    {
      "id": "node180",
      "name": "结束节点",
      "color": "#1890ff",
      "image": "/assets/Shape.486da24a.svg",
      "label": "结束",
      "offsetX": 94,
      "offsetY": 16,
      "shape": "customNode",
      "size": [ 170, 34 ],
      "stateImage": "/assets/end.dfe4a5ab.svg",
      "type": "node",
      "x": 396.5500183105469,
      "y": 254.0,
      "inPoints": [ [ 0.0, 0.5 ] ],
      "outPoints": [ [ 1.0, 0.5 ] ],
      "isDoingStart": false,
      "isDoingEnd": false
    }
  ],
  "edges": [
    {
      "id": "edge215",
      "end": {
        "x": 0.0,
        "y": -17.0
      },
      "endPoint": {
        "x": 395.15675988358055,
        "y": 146.5
      },
      "start": {
        "x": 0.0,
        "y": 17.0
      },
      "startPoint": {
        "x": 393.9432767375132,
        "y": 92.5
      },
      "shape": "customEdge",
      "source": "node166",
      "sourceId": "node166",
      "target": "node173",
      "targetId": "node173",
      "type": "edge"
    },
    {
      "id": "edge253",
      "end": {
        "x": 0.0,
        "y": -17.0
      },
      "endPoint": {
        "x": 396.3555738661024,
        "y": 236.5
      },
      "start": {
        "x": 0.0,
        "y": 17.0
      },
      "startPoint": {
        "x": 395.74446275499133,
        "y": 181.5
      },
      "shape": "customEdge",
      "source": "node173",
      "sourceId": "node173",
      "target": "node180",
      "targetId": "node180",
      "type": "edge"
    }
  ],
  "groups": []
}', N'1274621154383892480', 0, N'报销', N'报销审批-或签', N'只要有一个人审批就行', 0, 1, NULL, 0, CAST(N'2021-07-31T20:59:07.0806715' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[OA_DefForm] ([Id], [WorkflowJSON], [JSONId], [JSONVersion], [Type], [Name], [Text], [Sort], [Status], [Value], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1421455381959282688', N'{
  "Id": "1274621654579810304",
  "Version": 0,
  "DataType": "Coldairarrow.Util.OAData, Coldairarrow.Util",
  "FirstStart": true,
  "Steps": [
    {
      "Id": "node285",
      "Label": "开始",
      "StepType": "AIStudio.Service.WorkflowCore.OAStartStep, AIStudio.Service",
      "NextStepId": "node292",
      "Status": 0,
      "ActRules": {}
    },
    {
      "Id": "node292",
      "Label": "角色审批",
      "StepType": "AIStudio.Service.WorkflowCore.OAMiddleStep, AIStudio.Service",
      "NextStepId": "node299",
      "Status": 0,
      "ActRules": { "RoleIds": [ "1267011847224037376" ] }
    },
    {
      "Id": "node299",
      "Label": "结束",
      "StepType": "AIStudio.Service.WorkflowCore.OAEndStep, AIStudio.Service",
      "Status": 0,
      "ActRules": {}
    }
  ],
  "CurrentStepIds": [],
  "Flag": 0.0,
  "nodes": [
    {
      "id": "node285",
      "name": "开始节点",
      "color": "#1890ff",
      "image": "/assets/Shape.486da24a.svg",
      "label": "开始",
      "offsetX": 97,
      "offsetY": 16,
      "shape": "customNode",
      "size": [ 170, 34 ],
      "stateImage": "/assets/start.e502ed95.svg",
      "type": "node",
      "x": 358.5500183105469,
      "y": 78.0,
      "inPoints": [ [ 0.0, 0.5 ] ],
      "outPoints": [ [ 1.0, 0.5 ] ],
      "isDoingStart": false,
      "isDoingEnd": false
    },
    {
      "id": "node292",
      "name": "中间节点",
      "color": "#1890ff",
      "image": "/assets/Shape.486da24a.svg",
      "label": "角色审批",
      "offsetX": 99,
      "offsetY": 12,
      "shape": "customNode",
      "size": [ 170, 34 ],
      "stateImage": "/assets/jiahao.ecf71c51.svg",
      "type": "node",
      "x": 359.5500183105469,
      "y": 172.0,
      "inPoints": [ [ 0.0, 0.5 ] ],
      "outPoints": [ [ 1.0, 0.5 ] ],
      "isDoingStart": false,
      "isDoingEnd": false,
      "RoleIds": [ "1267011847224037376" ]
    },
    {
      "id": "node299",
      "name": "结束节点",
      "color": "#1890ff",
      "image": "/assets/Shape.486da24a.svg",
      "label": "结束",
      "offsetX": 99,
      "offsetY": 19,
      "shape": "customNode",
      "size": [ 170, 34 ],
      "stateImage": "/assets/end.dfe4a5ab.svg",
      "type": "node",
      "x": 363.5500183105469,
      "y": 269.0,
      "inPoints": [ [ 0.0, 0.5 ] ],
      "outPoints": [ [ 1.0, 0.5 ] ],
      "isDoingStart": false,
      "isDoingEnd": false
    }
  ],
  "edges": [
    {
      "id": "edge345",
      "end": {
        "x": 0.0,
        "y": -17.0
      },
      "endPoint": {
        "x": 359.36384809778093,
        "y": 154.5
      },
      "start": {
        "x": 0.0,
        "y": 17.0
      },
      "startPoint": {
        "x": 358.7361885233128,
        "y": 95.5
      },
      "shape": "customEdge",
      "source": "node285",
      "sourceId": "node285",
      "target": "node292",
      "targetId": "node292",
      "type": "edge"
    },
    {
      "id": "edge391",
      "end": {
        "x": 0.0,
        "y": -17.0
      },
      "endPoint": {
        "x": 362.8283688260108,
        "y": 251.5
      },
      "start": {
        "x": 0.0,
        "y": 17.0
      },
      "startPoint": {
        "x": 360.271667795083,
        "y": 189.5
      },
      "shape": "customEdge",
      "source": "node292",
      "sourceId": "node292",
      "target": "node299",
      "targetId": "node299",
      "type": "edge"
    }
  ],
  "groups": []
}', N'1274621654579810304', 0, N'顺序', N'部门领导审批', N'根据申请人所在部门自动查找生成审批人', 0, 1, NULL, 0, CAST(N'2021-07-31T20:59:07.0877195' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[OA_DefForm] ([Id], [WorkflowJSON], [JSONId], [JSONVersion], [Type], [Name], [Text], [Sort], [Status], [Value], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1421455381988642816', N'{
  "Id": "1274622508779180032",
  "Version": 0,
  "DataType": "Coldairarrow.Util.OAData, Coldairarrow.Util",
  "FirstStart": true,
  "Steps": [
    {
      "Id": "node431",
      "Label": "开始",
      "StepType": "AIStudio.Service.WorkflowCore.OAStartStep, AIStudio.Service",
      "NextStepId": "node445",
      "Status": 0,
      "ActRules": {}
    },
    {
      "Id": "node445",
      "Label": "并行开始",
      "StepType": "AIStudio.Service.WorkflowCore.OACOBeginStep, AIStudio.Service",
      "Status": 0,
      "ActRules": {},
      "SelectNextStep": {
        "node438": "True",
        "node461": "True"
      }
    },
    {
      "Id": "node438",
      "Label": "财务审批",
      "StepType": "AIStudio.Service.WorkflowCore.OAMiddleStep, AIStudio.Service",
      "NextStepId": "node454",
      "Status": 0,
      "ActRules": { "UserIds": [ "Admin" ] }
    },
    {
      "Id": "node454",
      "Label": "财务主管审批",
      "StepType": "AIStudio.Service.WorkflowCore.OAMiddleStep, AIStudio.Service",
      "NextStepId": "node475",
      "Status": 0,
      "ActRules": { "UserIds": [ "Admin" ] }
    },
    {
      "Id": "node461",
      "Label": "人力审批",
      "StepType": "AIStudio.Service.WorkflowCore.OAMiddleStep, AIStudio.Service",
      "NextStepId": "node468",
      "Status": 0,
      "ActRules": { "UserIds": [ "Admin" ] }
    },
    {
      "Id": "node468",
      "Label": "人力主管审批",
      "StepType": "AIStudio.Service.WorkflowCore.OAMiddleStep, AIStudio.Service",
      "NextStepId": "node475",
      "Status": 0,
      "ActRules": { "UserIds": [ "Admin" ] }
    },
    {
      "Id": "node475",
      "Label": "并行结束",
      "StepType": "AIStudio.Service.WorkflowCore.OACOEndStep, AIStudio.Service",
      "NextStepId": "node484",
      "Status": 0,
      "ActRules": {}
    },
    {
      "Id": "node484",
      "Label": "结束",
      "StepType": "AIStudio.Service.WorkflowCore.OAEndStep, AIStudio.Service",
      "Status": 0,
      "ActRules": {}
    }
  ],
  "CurrentStepIds": [],
  "Flag": 0.0,
  "nodes": [
    {
      "id": "node431",
      "name": "开始节点",
      "color": "#1890ff",
      "image": "/assets/Shape.486da24a.svg",
      "label": "开始",
      "offsetX": 123,
      "offsetY": 26,
      "shape": "customNode",
      "size": [ 170, 34 ],
      "stateImage": "/assets/start.e502ed95.svg",
      "type": "node",
      "x": 220.55001831054688,
      "y": 72.0,
      "inPoints": [ [ 0.0, 0.5 ] ],
      "outPoints": [ [ 1.0, 0.5 ] ],
      "isDoingStart": false,
      "isDoingEnd": false
    },
    {
      "id": "node438",
      "name": "中间节点",
      "color": "#1890ff",
      "image": "/assets/Shape.486da24a.svg",
      "label": "财务审批",
      "offsetX": 104,
      "offsetY": 22,
      "shape": "customNode",
      "size": [ 170, 34 ],
      "stateImage": "/assets/jiahao.ecf71c51.svg",
      "type": "node",
      "x": 126.55001831054688,
      "y": 234.0,
      "inPoints": [ [ 0.0, 0.5 ] ],
      "outPoints": [ [ 1.0, 0.5 ] ],
      "isDoingStart": false,
      "isDoingEnd": false,
      "UserIds": [ "Admin" ]
    },
    {
      "id": "node445",
      "name": "并行开始节点",
      "color": "#1890ff",
      "image": "/assets/Shape.486da24a.svg",
      "label": "并行开始",
      "offsetX": 107,
      "offsetY": 20,
      "shape": "customNode",
      "size": [ 170, 34 ],
      "stateImage": "/assets/open.ed232014.svg",
      "type": "node",
      "x": 224.55001831054688,
      "y": 155.0,
      "inPoints": [ [ 0.0, 0.5 ] ],
      "outPoints": [
        [ 1.0, 0.4 ],
        [ 1.0, 0.6 ]
      ],
      "isDoingStart": false,
      "isDoingEnd": false
    },
    {
      "id": "node454",
      "name": "中间节点",
      "color": "#1890ff",
      "image": "/assets/Shape.486da24a.svg",
      "label": "财务主管审批",
      "offsetX": 87,
      "offsetY": 20,
      "shape": "customNode",
      "size": [ 170, 34 ],
      "stateImage": "/assets/jiahao.ecf71c51.svg",
      "type": "node",
      "x": 127.55001831054688,
      "y": 317.0,
      "inPoints": [ [ 0.0, 0.5 ] ],
      "outPoints": [ [ 1.0, 0.5 ] ],
      "isDoingStart": false,
      "isDoingEnd": false,
      "UserIds": [ "Admin" ]
    },
    {
      "id": "node461",
      "name": "中间节点",
      "color": "#1890ff",
      "image": "/assets/Shape.486da24a.svg",
      "label": "人力审批",
      "offsetX": 88,
      "offsetY": 13,
      "shape": "customNode",
      "size": [ 170, 34 ],
      "stateImage": "/assets/jiahao.ecf71c51.svg",
      "type": "node",
      "x": 342.5500183105469,
      "y": 227.0,
      "inPoints": [ [ 0.0, 0.5 ] ],
      "outPoints": [ [ 1.0, 0.5 ] ],
      "isDoingStart": false,
      "isDoingEnd": false,
      "UserIds": [ "Admin" ]
    },
    {
      "id": "node468",
      "name": "中间节点",
      "color": "#1890ff",
      "image": "/assets/Shape.486da24a.svg",
      "label": "人力主管审批",
      "offsetX": 82,
      "offsetY": 19,
      "shape": "customNode",
      "size": [ 170, 34 ],
      "stateImage": "/assets/jiahao.ecf71c51.svg",
      "type": "node",
      "x": 345.5500183105469,
      "y": 315.0,
      "inPoints": [ [ 0.0, 0.5 ] ],
      "outPoints": [ [ 1.0, 0.5 ] ],
      "isDoingStart": false,
      "isDoingEnd": false,
      "UserIds": [ "Admin" ]
    },
    {
      "id": "node475",
      "name": "并行结束节点",
      "color": "#1890ff",
      "image": "/assets/Shape.486da24a.svg",
      "label": "并行结束",
      "offsetX": 111,
      "offsetY": 35,
      "shape": "customNode",
      "size": [ 170, 34 ],
      "stateImage": "/assets/close.7ec40520.svg",
      "type": "node",
      "x": 237.55001831054688,
      "y": 409.1800079345703,
      "inPoints": [
        [ 0.0, 0.4 ],
        [ 0.0, 0.6 ]
      ],
      "outPoints": [ [ 1.0, 0.5 ] ],
      "isDoingStart": false,
      "isDoingEnd": false
    },
    {
      "id": "node484",
      "name": "结束节点",
      "color": "#1890ff",
      "image": "/assets/Shape.486da24a.svg",
      "label": "结束",
      "offsetX": 67,
      "offsetY": 23,
      "shape": "customNode",
      "size": [ 170, 34 ],
      "stateImage": "/assets/end.dfe4a5ab.svg",
      "type": "node",
      "x": 240.55001831054688,
      "y": 493.1800079345703,
      "inPoints": [ [ 0.0, 0.5 ] ],
      "outPoints": [ [ 1.0, 0.5 ] ],
      "isDoingStart": false,
      "isDoingEnd": false
    }
  ],
  "edges": [
    {
      "id": "edge538",
      "end": {
        "x": 0.0,
        "y": -17.0
      },
      "endPoint": {
        "x": 223.70664481657099,
        "y": 137.5
      },
      "start": {
        "x": 0.0,
        "y": 17.0
      },
      "startPoint": {
        "x": 221.39339180452276,
        "y": 89.5
      },
      "shape": "customEdge",
      "source": "node431",
      "sourceId": "node431",
      "target": "node445",
      "targetId": "node445",
      "type": "edge"
    },
    {
      "id": "edge576",
      "end": {
        "x": 0.0,
        "y": -17.0
      },
      "endPoint": {
        "x": 148.25887907004056,
        "y": 216.5
      },
      "start": {
        "x": -17.0,
        "y": 17.0
      },
      "startPoint": {
        "x": 202.8411575510532,
        "y": 172.5
      },
      "shape": "customEdge",
      "source": "node445",
      "sourceId": "node445",
      "target": "node438",
      "targetId": "node438",
      "type": "edge"
    },
    {
      "id": "edge649",
      "end": {
        "x": 0.0,
        "y": -17.0
      },
      "endPoint": {
        "x": 313.86946275499133,
        "y": 209.5
      },
      "start": {
        "x": 17.0,
        "y": 17.0
      },
      "startPoint": {
        "x": 253.23057386610242,
        "y": 172.5
      },
      "shape": "customEdge",
      "source": "node445",
      "sourceId": "node445",
      "target": "node461",
      "targetId": "node461",
      "type": "edge"
    },
    {
      "id": "edge684",
      "end": {
        "x": 0.0,
        "y": -17.0
      },
      "endPoint": {
        "x": 127.33917493705289,
        "y": 299.5
      },
      "start": {
        "x": 0.0,
        "y": 17.0
      },
      "startPoint": {
        "x": 126.76086168404086,
        "y": 251.5
      },
      "shape": "customEdge",
      "source": "node438",
      "sourceId": "node438",
      "target": "node454",
      "targetId": "node454",
      "type": "edge"
    },
    {
      "id": "edge734",
      "end": {
        "x": 0.0,
        "y": -17.0
      },
      "endPoint": {
        "x": 344.953427401456,
        "y": 297.5
      },
      "start": {
        "x": 0.0,
        "y": 17.0
      },
      "startPoint": {
        "x": 343.14660921963775,
        "y": 244.5
      },
      "shape": "customEdge",
      "source": "node461",
      "sourceId": "node461",
      "target": "node468",
      "targetId": "node468",
      "type": "edge"
    },
    {
      "id": "edge785",
      "end": {
        "x": -17.0,
        "y": -17.0
      },
      "endPoint": {
        "x": 216.6669652154943,
        "y": 391.6800079345703
      },
      "start": {
        "x": 0.0,
        "y": 17.0
      },
      "startPoint": {
        "x": 148.43307140559946,
        "y": 334.5
      },
      "shape": "customEdge",
      "source": "node454",
      "sourceId": "node454",
      "target": "node475",
      "targetId": "node475",
      "type": "edge"
    },
    {
      "id": "edge867",
      "end": {
        "x": 17.0,
        "y": -17.0
      },
      "endPoint": {
        "x": 257.61797159966784,
        "y": 391.6800079345703
      },
      "start": {
        "x": 0.0,
        "y": 17.0
      },
      "startPoint": {
        "x": 325.4820650214259,
        "y": 332.5
      },
      "shape": "customEdge",
      "source": "node468",
      "sourceId": "node468",
      "target": "node475",
      "targetId": "node475",
      "type": "edge"
    },
    {
      "id": "edge900",
      "end": {
        "x": 0.0,
        "y": -17.0
      },
      "endPoint": {
        "x": 239.92501831054688,
        "y": 475.6800079345703
      },
      "start": {
        "x": 0.0,
        "y": 17.0
      },
      "startPoint": {
        "x": 238.17501831054688,
        "y": 426.6800079345703
      },
      "shape": "customEdge",
      "source": "node475",
      "sourceId": "node475",
      "target": "node484",
      "targetId": "node484",
      "type": "edge"
    }
  ],
  "groups": []
}', N'1274622508779180032', 0, N'报销', N'并行流程', N'两个分管部门同时进行审批', 0, 1, NULL, 0, CAST(N'2021-07-31T20:59:07.0969167' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[OA_DefForm] ([Id], [WorkflowJSON], [JSONId], [JSONVersion], [Type], [Name], [Text], [Sort], [Status], [Value], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1421455382026391552', N'{
  "Id": "1274623039325081600",
  "Version": 0,
  "DataType": "Coldairarrow.Util.OAData, Coldairarrow.Util",
  "FirstStart": true,
  "Steps": [
    {
      "Id": "node1036",
      "Label": "开始",
      "StepType": "AIStudio.Service.WorkflowCore.OAStartStep, AIStudio.Service",
      "NextStepId": "node1043",
      "Status": 0,
      "ActRules": {}
    },
    {
      "Id": "node1043",
      "Label": "节点",
      "StepType": "AIStudio.Service.WorkflowCore.OAMiddleStep, AIStudio.Service",
      "NextStepId": "node1050",
      "Status": 0,
      "ActRules": { "UserIds": [ "Admin" ] }
    },
    {
      "Id": "node1050",
      "Label": "结束",
      "StepType": "AIStudio.Service.WorkflowCore.OAEndStep, AIStudio.Service",
      "Status": 0,
      "ActRules": {}
    }
  ],
  "CurrentStepIds": [],
  "Flag": 0.0,
  "nodes": [
    {
      "id": "node1036",
      "name": "开始节点",
      "color": "#1890ff",
      "image": "/assets/Shape.486da24a.svg",
      "label": "开始",
      "offsetX": 93,
      "offsetY": 20,
      "shape": "customNode",
      "size": [ 170, 34 ],
      "stateImage": "/assets/start.e502ed95.svg",
      "type": "node",
      "x": 422.5500183105469,
      "y": 68.0,
      "inPoints": [ [ 0.0, 0.5 ] ],
      "outPoints": [ [ 1.0, 0.5 ] ],
      "isDoingStart": false,
      "isDoingEnd": false
    },
    {
      "id": "node1043",
      "name": "中间节点",
      "color": "#1890ff",
      "image": "/assets/Shape.486da24a.svg",
      "label": "节点",
      "offsetX": 83,
      "offsetY": 12,
      "shape": "customNode",
      "size": [ 170, 34 ],
      "stateImage": "/assets/jiahao.ecf71c51.svg",
      "type": "node",
      "x": 420.5500183105469,
      "y": 157.0,
      "inPoints": [ [ 0.0, 0.5 ] ],
      "outPoints": [ [ 1.0, 0.5 ] ],
      "isDoingStart": false,
      "isDoingEnd": false,
      "UserIds": [ "Admin" ]
    },
    {
      "id": "node1050",
      "name": "结束节点",
      "color": "#1890ff",
      "image": "/assets/Shape.486da24a.svg",
      "label": "结束",
      "offsetX": 106,
      "offsetY": 18,
      "shape": "customNode",
      "size": [ 170, 34 ],
      "stateImage": "/assets/end.dfe4a5ab.svg",
      "type": "node",
      "x": 423.5500183105469,
      "y": 244.0,
      "inPoints": [ [ 0.0, 0.5 ] ],
      "outPoints": [ [ 1.0, 0.5 ] ],
      "isDoingStart": false,
      "isDoingEnd": false
    }
  ],
  "edges": [
    {
      "id": "edge1091",
      "end": {
        "x": 0.0,
        "y": -17.0
      },
      "endPoint": {
        "x": 420.94327673751314,
        "y": 139.5
      },
      "start": {
        "x": 0.0,
        "y": 17.0
      },
      "startPoint": {
        "x": 422.1567598835806,
        "y": 85.5
      },
      "shape": "customEdge",
      "source": "node1036",
      "sourceId": "node1036",
      "target": "node1043",
      "targetId": "node1043",
      "type": "edge"
    },
    {
      "id": "edge1128",
      "end": {
        "x": 0.0,
        "y": -17.0
      },
      "endPoint": {
        "x": 422.9465700346848,
        "y": 226.5
      },
      "start": {
        "x": 0.0,
        "y": 17.0
      },
      "startPoint": {
        "x": 421.15346658640897,
        "y": 174.5
      },
      "shape": "customEdge",
      "source": "node1043",
      "sourceId": "node1043",
      "target": "node1050",
      "targetId": "node1050",
      "type": "edge"
    }
  ],
  "groups": []
}', N'1274623039325081600', 0, N'顺序', N'有创建权限的流程', N'只有管理员能创建的流程', 0, 1, N'^1421455370911485952^', 0, CAST(N'2021-07-31T20:59:07.1043701' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[OA_DefForm] ([Id], [WorkflowJSON], [JSONId], [JSONVersion], [Type], [Name], [Text], [Sort], [Status], [Value], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1421455382059945984', N'{
  "Id": "1274623664695808000",
  "Version": 0,
  "DataType": "Coldairarrow.Util.OAData, Coldairarrow.Util",
  "FirstStart": true,
  "Steps": [
    {
      "Id": "node2",
      "Label": "开始",
      "StepType": "AIStudio.Service.WorkflowCore.OAStartStep, AIStudio.Service",
      "NextStepId": "node9",
      "Status": 0,
      "ActRules": {}
    },
    {
      "Id": "node9",
      "Label": "主管审批",
      "StepType": "AIStudio.Service.WorkflowCore.OAMiddleStep, AIStudio.Service",
      "NextStepId": "node137",
      "Status": 0,
      "ActRules": { "UserIds": [ "Admin" ] }
    },
    {
      "Id": "node137",
      "Label": "人力审批",
      "StepType": "AIStudio.Service.WorkflowCore.OAMiddleStep, AIStudio.Service",
      "NextStepId": "node467",
      "Status": 0,
      "ActRules": { "UserIds": [ "Admin" ] }
    },
    {
      "Id": "node467",
      "Label": "条件",
      "StepType": "AIStudio.Service.WorkflowCore.OADecideStep, AIStudio.Service",
      "Status": 0,
      "ActRules": {},
      "SelectNextStep": {
        "node144": "data.Flag<=3",
        "node479": "data.Flag>3"
      }
    },
    {
      "Id": "node479",
      "Label": "分管领导",
      "StepType": "AIStudio.Service.WorkflowCore.OAMiddleStep, AIStudio.Service",
      "NextStepId": "node144",
      "Status": 0,
      "ActRules": { "UserIds": [ "Admin" ] }
    },
    {
      "Id": "node144",
      "Label": "人力归档",
      "StepType": "AIStudio.Service.WorkflowCore.OAMiddleStep, AIStudio.Service",
      "NextStepId": "node61",
      "Status": 0,
      "ActRules": { "UserIds": [ "Admin" ] }
    },
    {
      "Id": "node61",
      "Label": "结束",
      "StepType": "AIStudio.Service.WorkflowCore.OAEndStep, AIStudio.Service",
      "Status": 0,
      "ActRules": {}
    }
  ],
  "CurrentStepIds": [],
  "Flag": 0.0,
  "nodes": [
    {
      "id": "node2",
      "name": "开始节点",
      "color": "#1890ff",
      "image": "/assets/Shape.486da24a.svg",
      "label": "开始",
      "offsetX": 85,
      "offsetY": 26,
      "shape": "customNode",
      "size": [ 170, 34 ],
      "stateImage": "/assets/start.e502ed95.svg",
      "type": "node",
      "x": 221.55001831054688,
      "y": 84.0,
      "inPoints": [ [ 0.0, 0.5 ] ],
      "outPoints": [ [ 1.0, 0.5 ] ],
      "isDoingStart": false,
      "isDoingEnd": false
    },
    {
      "id": "node9",
      "name": "中间节点",
      "color": "#1890ff",
      "image": "/assets/Shape.486da24a.svg",
      "label": "主管审批",
      "offsetX": 76,
      "offsetY": 21,
      "shape": "customNode",
      "size": [ 170, 34 ],
      "stateImage": "/assets/jiahao.ecf71c51.svg",
      "type": "node",
      "x": 220.55001831054688,
      "y": 161.0,
      "inPoints": [ [ 0.0, 0.5 ] ],
      "outPoints": [ [ 1.0, 0.5 ] ],
      "isDoingStart": false,
      "isDoingEnd": false,
      "UserIds": [ "Admin" ]
    },
    {
      "id": "node61",
      "name": "结束节点",
      "color": "#1890ff",
      "image": "/assets/Shape.486da24a.svg",
      "label": "结束",
      "offsetX": 81,
      "offsetY": 25,
      "shape": "customNode",
      "size": [ 170, 34 ],
      "stateImage": "/assets/end.dfe4a5ab.svg",
      "type": "node",
      "x": 213.55001831054688,
      "y": 550.0,
      "inPoints": [ [ 0.0, 0.5 ] ],
      "outPoints": [ [ 1.0, 0.5 ] ],
      "isDoingStart": false,
      "isDoingEnd": false
    },
    {
      "id": "node137",
      "name": "中间节点",
      "color": "#1890ff",
      "image": "/assets/Shape.486da24a.svg",
      "label": "人力审批",
      "offsetX": 116,
      "offsetY": 20,
      "shape": "customNode",
      "size": [ 170, 34 ],
      "stateImage": "/assets/jiahao.ecf71c51.svg",
      "type": "node",
      "x": 221.55001831054688,
      "y": 243.0,
      "inPoints": [ [ 0.0, 0.5 ] ],
      "outPoints": [ [ 1.0, 0.5 ] ],
      "isDoingStart": false,
      "isDoingEnd": false,
      "UserIds": [ "Admin" ]
    },
    {
      "id": "node144",
      "name": "中间节点",
      "color": "#1890ff",
      "image": "/assets/Shape.486da24a.svg",
      "label": "人力归档",
      "offsetX": 102,
      "offsetY": 15,
      "shape": "customNode",
      "size": [ 170, 34 ],
      "stateImage": "/assets/jiahao.ecf71c51.svg",
      "type": "node",
      "x": 214.55001831054688,
      "y": 464.0,
      "inPoints": [ [ 0.0, 0.5 ] ],
      "outPoints": [ [ 1.0, 0.5 ] ],
      "isDoingStart": false,
      "isDoingEnd": false,
      "UserIds": [ "Admin" ]
    },
    {
      "id": "node467",
      "name": "条件节点",
      "color": "#1890ff",
      "image": "/assets/Shape.486da24a.svg",
      "label": "条件",
      "offsetX": 84,
      "offsetY": 22,
      "shape": "customNode",
      "size": [ 170, 34 ],
      "stateImage": "/assets/wenhao.71b31d27.svg",
      "type": "node",
      "x": 221.55001831054688,
      "y": 329.0,
      "inPoints": [ [ 0.0, 0.5 ] ],
      "outPoints": [
        [ 1.0, 0.4 ],
        [ 1.0, 0.6 ]
      ],
      "isDoingStart": false,
      "isDoingEnd": false
    },
    {
      "id": "node479",
      "name": "中间节点",
      "color": "#1890ff",
      "image": "/assets/Shape.486da24a.svg",
      "label": "分管领导",
      "offsetX": 104,
      "offsetY": 24,
      "shape": "customNode",
      "size": [ 170, 34 ],
      "stateImage": "/assets/jiahao.ecf71c51.svg",
      "type": "node",
      "x": 408.0752708357994,
      "y": 396.07070707070704,
      "inPoints": [ [ 0.0, 0.5 ] ],
      "outPoints": [ [ 1.0, 0.5 ] ],
      "isDoingStart": false,
      "isDoingEnd": false,
      "UserIds": [ "Admin" ]
    }
  ],
  "edges": [
    {
      "id": "edge56",
      "end": {
        "x": 0.0,
        "y": -17.0
      },
      "endPoint": {
        "x": 220.77729103781962,
        "y": 143.5
      },
      "start": {
        "x": 0.0,
        "y": 17.0
      },
      "startPoint": {
        "x": 221.32274558327413,
        "y": 101.5
      },
      "shape": "customEdge",
      "source": "node2",
      "sourceId": "node2",
      "target": "node9",
      "targetId": "node9",
      "type": "edge"
    },
    {
      "id": "edge180",
      "end": {
        "x": 0.0,
        "y": -17.0
      },
      "endPoint": {
        "x": 221.33660367640056,
        "y": 225.5
      },
      "start": {
        "x": 0.0,
        "y": 17.0
      },
      "startPoint": {
        "x": 220.7634329446932,
        "y": 178.5
      },
      "shape": "customEdge",
      "source": "node9",
      "sourceId": "node9",
      "target": "node137",
      "targetId": "node137",
      "type": "edge"
    },
    {
      "id": "edge261",
      "end": {
        "x": 0.0,
        "y": -17.0
      },
      "endPoint": {
        "x": 213.7535066826399,
        "y": 532.5
      },
      "start": {
        "x": 0.0,
        "y": 17.0
      },
      "startPoint": {
        "x": 214.34652993845384,
        "y": 481.5
      },
      "shape": "customEdge",
      "source": "node144",
      "sourceId": "node144",
      "target": "node61",
      "targetId": "node61",
      "type": "edge"
    },
    {
      "id": "edge539",
      "end": {
        "x": 0.0,
        "y": -17.0
      },
      "endPoint": {
        "x": 215.45742571795427,
        "y": 446.5
      },
      "start": {
        "x": -17.0,
        "y": 17.0
      },
      "startPoint": {
        "x": 220.64261090313948,
        "y": 346.5
      },
      "shape": "customEdge",
      "source": "node467",
      "sourceId": "node467",
      "target": "node144",
      "targetId": "node144",
      "type": "edge",
      "label": "<=3",
      "textColor": "#3AB70D"
    },
    {
      "id": "edge622",
      "end": {
        "x": 0.0,
        "y": -17.0
      },
      "endPoint": {
        "x": 359.4073491490524,
        "y": 378.57070707070704
      },
      "start": {
        "x": 17.0,
        "y": 17.0
      },
      "startPoint": {
        "x": 270.2179399972939,
        "y": 346.5
      },
      "shape": "customEdge",
      "source": "node467",
      "sourceId": "node467",
      "target": "node479",
      "targetId": "node479",
      "type": "edge",
      "label": ">3",
      "textColor": "#D61F1F"
    },
    {
      "id": "edge735",
      "end": {
        "x": 0.0,
        "y": -17.0
      },
      "endPoint": {
        "x": 264.4061521395431,
        "y": 446.5
      },
      "start": {
        "x": 0.0,
        "y": 17.0
      },
      "startPoint": {
        "x": 358.2191370068032,
        "y": 413.57070707070704
      },
      "shape": "customEdge",
      "source": "node479",
      "sourceId": "node479",
      "target": "node144",
      "targetId": "node144",
      "type": "edge"
    },
    {
      "id": "edge770",
      "end": {
        "x": 0.0,
        "y": -17.0
      },
      "endPoint": {
        "x": 221.55001831054688,
        "y": 311.5
      },
      "start": {
        "x": 0.0,
        "y": 17.0
      },
      "startPoint": {
        "x": 221.55001831054688,
        "y": 260.5
      },
      "shape": "customEdge",
      "source": "node137",
      "sourceId": "node137",
      "target": "node467",
      "targetId": "node467",
      "type": "edge"
    }
  ],
  "groups": []
}', N'1274623664695808000', 0, N'请假', N'请假流程-条件', N'根据请假天数是否需要分管领导审批', 0, 1, NULL, 0, CAST(N'2021-07-31T20:59:07.1133311' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[OA_DefType] ([Id], [Name], [Type], [Unit], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1421455380344475648', N'请假', N'分类', NULL, 0, CAST(N'2021-07-31T20:59:06.6960499' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[OA_DefType] ([Id], [Name], [Type], [Unit], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1421455380348669952', N'报销', N'分类', NULL, 0, CAST(N'2021-07-31T20:59:06.6960566' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[OA_DefType] ([Id], [Name], [Type], [Unit], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1421455380348669953', N'顺序', N'分类', NULL, 0, CAST(N'2021-07-31T20:59:06.6960572' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[OA_DefType] ([Id], [Name], [Type], [Unit], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1421455380348669954', N'选择', N'分类', NULL, 0, CAST(N'2021-07-31T20:59:06.6960576' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[OA_DefType] ([Id], [Name], [Type], [Unit], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1421455380348669955', N'或签', N'分类', NULL, 0, CAST(N'2021-07-31T20:59:06.6960579' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[OA_DefType] ([Id], [Name], [Type], [Unit], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1421455380348669956', N'与签', N'分类', NULL, 0, CAST(N'2021-07-31T20:59:06.6960587' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[OA_DefType] ([Id], [Name], [Type], [Unit], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1421455380348669957', N'病假', N'请假', N'天数', 0, CAST(N'2021-07-31T20:59:06.6961056' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[OA_DefType] ([Id], [Name], [Type], [Unit], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1421455380348669958', N'事假', N'请假', N'天数', 0, CAST(N'2021-07-31T20:59:06.6961070' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[OA_DefType] ([Id], [Name], [Type], [Unit], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1421455380348669959', N'调休', N'请假', N'天数', 0, CAST(N'2021-07-31T20:59:06.6961074' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[OA_DefType] ([Id], [Name], [Type], [Unit], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1421455380348669960', N'年假', N'请假', N'天数', 0, CAST(N'2021-07-31T20:59:06.6961081' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[OA_DefType] ([Id], [Name], [Type], [Unit], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1421455380348669961', N'差旅费用', N'报销', N'费用(元)', 0, CAST(N'2021-07-31T20:59:06.6961085' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[OA_DefType] ([Id], [Name], [Type], [Unit], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1421455380348669962', N'采购费用', N'报销', N'费用(元)', 0, CAST(N'2021-07-31T20:59:06.6961088' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[OA_DefType] ([Id], [Name], [Type], [Unit], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1421455380348669963', N'活动费用', N'报销', N'费用(元)', 0, CAST(N'2021-07-31T20:59:06.6961092' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[OA_DefType] ([Id], [Name], [Type], [Unit], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1421455380348669964', N'日常费用', N'报销', N'费用(元)', 0, CAST(N'2021-07-31T20:59:06.6961095' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Quartz_Task] ([Id], [TaskName], [GroupName], [Interval], [ApiUrl], [AuthKey], [AuthValue], [Describe], [RequestType], [LastRunTime], [Status], [ForbidOperate], [ForbidEdit], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1421455378759028736', N'ResetDataJob', N'SystemJob', N'0/10 * * * * ?', N'ResetDataJob', NULL, NULL, NULL, N'System', NULL, 0, 0, 1, 0, CAST(N'2021-07-31T20:59:06.3173940' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Quartz_Task] ([Id], [TaskName], [GroupName], [Interval], [ApiUrl], [AuthKey], [AuthValue], [Describe], [RequestType], [LastRunTime], [Status], [ForbidOperate], [ForbidEdit], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1421455379056824320', N'SaveMessageJob', N'SystemJob', N'0/10 * * * * ?', N'SaveMessageJob', NULL, NULL, NULL, N'System', NULL, 0, 0, 1, 0, CAST(N'2021-07-31T20:59:06.3886604' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Quartz_Task] ([Id], [TaskName], [GroupName], [Interval], [ApiUrl], [AuthKey], [AuthValue], [Describe], [RequestType], [LastRunTime], [Status], [ForbidOperate], [ForbidEdit], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1421455379195236352', N'PushMessageJob', N'SystemJob', N'0/10 * * * * ?', N'PushMessageJob', NULL, NULL, NULL, N'System', NULL, 0, 0, 1, 0, CAST(N'2021-07-31T20:59:06.4219365' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Quartz_Task] ([Id], [TaskName], [GroupName], [Interval], [ApiUrl], [AuthKey], [AuthValue], [Describe], [RequestType], [LastRunTime], [Status], [ForbidOperate], [ForbidEdit], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1421455379325259776', N'GetLog', N'Test', N'0/10 * * * * ?', N'http://localhost:5000/Test/GetLogList', N'Authorization', N'Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VySWQiOiJBZG1pbiIsImV4cCI6MTYxMzQ1NTI0MX0.XbnD6R0Ozgp1xoI6BUrRjYaHwRYYAJ7OgU6gRO1sdbA', NULL, N'System', NULL, 1, 0, 0, 0, CAST(N'2021-07-31T20:59:06.4525868' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
ALTER TABLE [dbo].[Base_CommonFormConfig] ADD  DEFAULT ((0)) FOR [DisplayIndex]
GO
ALTER TABLE [dbo].[Base_Dictionary] ADD  DEFAULT ((0)) FOR [ControlType]
GO
ALTER TABLE [dbo].[D_Notice] ADD  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[D_Notice] ADD  DEFAULT ((0)) FOR [Mode]
GO
ALTER TABLE [dbo].[D_UserMail] ADD  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[D_UserMessage] ADD  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [wfc].[ExecutionPointer] ADD  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [wfc].[Subscription] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [SubscribeAsOf]
GO
ALTER TABLE [wfc].[ExecutionPointer]  WITH CHECK ADD  CONSTRAINT [FK_ExecutionPointer_Workflow_WorkflowId] FOREIGN KEY([WorkflowId])
REFERENCES [wfc].[Workflow] ([PersistenceId])
ON DELETE CASCADE
GO
ALTER TABLE [wfc].[ExecutionPointer] CHECK CONSTRAINT [FK_ExecutionPointer_Workflow_WorkflowId]
GO
ALTER TABLE [wfc].[ExtensionAttribute]  WITH CHECK ADD  CONSTRAINT [FK_ExtensionAttribute_ExecutionPointer_ExecutionPointerId] FOREIGN KEY([ExecutionPointerId])
REFERENCES [wfc].[ExecutionPointer] ([PersistenceId])
ON DELETE CASCADE
GO
ALTER TABLE [wfc].[ExtensionAttribute] CHECK CONSTRAINT [FK_ExtensionAttribute_ExecutionPointer_ExecutionPointerId]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自然主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_Action', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'父级Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_Action', @level2type=N'COLUMN',@level2name=N'ParentId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'类型,菜单=0,页面=1,权限=2' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_Action', @level2type=N'COLUMN',@level2name=N'Type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'权限名/菜单名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_Action', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'菜单地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_Action', @level2type=N'COLUMN',@level2name=N'Url'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'权限值' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_Action', @level2type=N'COLUMN',@level2name=N'Value'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否需要权限(仅页面有效)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_Action', @level2type=N'COLUMN',@level2name=N'NeedAction'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'图标' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_Action', @level2type=N'COLUMN',@level2name=N'Icon'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'排序' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_Action', @level2type=N'COLUMN',@level2name=N'Sort'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'否已删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_Action', @level2type=N'COLUMN',@level2name=N'Deleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_Action', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_Action', @level2type=N'COLUMN',@level2name=N'ModifyTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_Action', @level2type=N'COLUMN',@level2name=N'CreatorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_Action', @level2type=N'COLUMN',@level2name=N'CreatorName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改人Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_Action', @level2type=N'COLUMN',@level2name=N'ModifyId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_Action', @level2type=N'COLUMN',@level2name=N'ModifyName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'租户Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_Action', @level2type=N'COLUMN',@level2name=N'TenantId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自然主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_AppSecret', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'应用Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_AppSecret', @level2type=N'COLUMN',@level2name=N'AppId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'应用密钥' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_AppSecret', @level2type=N'COLUMN',@level2name=N'AppSecret'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'应用名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_AppSecret', @level2type=N'COLUMN',@level2name=N'AppName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'否已删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_AppSecret', @level2type=N'COLUMN',@level2name=N'Deleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_AppSecret', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_AppSecret', @level2type=N'COLUMN',@level2name=N'ModifyTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_AppSecret', @level2type=N'COLUMN',@level2name=N'CreatorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_AppSecret', @level2type=N'COLUMN',@level2name=N'CreatorName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改人Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_AppSecret', @level2type=N'COLUMN',@level2name=N'ModifyId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_AppSecret', @level2type=N'COLUMN',@level2name=N'ModifyName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'租户Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_AppSecret', @level2type=N'COLUMN',@level2name=N'TenantId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自然主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_CommonFormConfig', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'表名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_CommonFormConfig', @level2type=N'COLUMN',@level2name=N'Table'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'列头' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_CommonFormConfig', @level2type=N'COLUMN',@level2name=N'Header'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'属性名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_CommonFormConfig', @level2type=N'COLUMN',@level2name=N'PropertyName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'显示索引' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_CommonFormConfig', @level2type=N'COLUMN',@level2name=N'DisplayIndex'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'配置类型 查询=0，列表=1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_CommonFormConfig', @level2type=N'COLUMN',@level2name=N'Type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'格式化' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_CommonFormConfig', @level2type=N'COLUMN',@level2name=N'StringFormat'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否显示 Visible = 0,Hidden = 1,Collapsed = 2' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_CommonFormConfig', @level2type=N'COLUMN',@level2name=N'Visibility'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'控件类型，仅控件框使用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_CommonFormConfig', @level2type=N'COLUMN',@level2name=N'ControlType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'只读' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_CommonFormConfig', @level2type=N'COLUMN',@level2name=N'IsReadOnly'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'必输项' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_CommonFormConfig', @level2type=N'COLUMN',@level2name=N'IsRequired'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'字典名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_CommonFormConfig', @level2type=N'COLUMN',@level2name=N'ItemSource'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'默认值' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_CommonFormConfig', @level2type=N'COLUMN',@level2name=N'Value'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'排序名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_CommonFormConfig', @level2type=N'COLUMN',@level2name=N'SortMemberPath'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'转换器' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_CommonFormConfig', @level2type=N'COLUMN',@level2name=N'Converter'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'转换参数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_CommonFormConfig', @level2type=N'COLUMN',@level2name=N'ConverterParameter'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'对齐方式 Left = 0,Center = 1,Right = 2,Stretch = 3' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_CommonFormConfig', @level2type=N'COLUMN',@level2name=N'HorizontalAlignment'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最大宽度' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_CommonFormConfig', @level2type=N'COLUMN',@level2name=N'MaxWidth'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最小宽度' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_CommonFormConfig', @level2type=N'COLUMN',@level2name=N'MinWidth'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'列表宽度' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_CommonFormConfig', @level2type=N'COLUMN',@level2name=N'Width'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否可以重排' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_CommonFormConfig', @level2type=N'COLUMN',@level2name=N'CanUserReorder'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否可以调整大小' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_CommonFormConfig', @level2type=N'COLUMN',@level2name=N'CanUserResize'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否可以排序' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_CommonFormConfig', @level2type=N'COLUMN',@level2name=N'CanUserSort'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'单元格样式，暂未实现' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_CommonFormConfig', @level2type=N'COLUMN',@level2name=N'CellStyle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'背景颜色触发公式' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_CommonFormConfig', @level2type=N'COLUMN',@level2name=N'BackgroundExpression'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'前景颜色触发公式' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_CommonFormConfig', @level2type=N'COLUMN',@level2name=N'ForegroundExpression'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'否已删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_CommonFormConfig', @level2type=N'COLUMN',@level2name=N'Deleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_CommonFormConfig', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_CommonFormConfig', @level2type=N'COLUMN',@level2name=N'ModifyTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_CommonFormConfig', @level2type=N'COLUMN',@level2name=N'CreatorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_CommonFormConfig', @level2type=N'COLUMN',@level2name=N'CreatorName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改人Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_CommonFormConfig', @level2type=N'COLUMN',@level2name=N'ModifyId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_CommonFormConfig', @level2type=N'COLUMN',@level2name=N'ModifyName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'租户Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_CommonFormConfig', @level2type=N'COLUMN',@level2name=N'TenantId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'列头样式，赞未实现' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_CommonFormConfig', @level2type=N'COLUMN',@level2name=N'HeaderStyle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'属性类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_CommonFormConfig', @level2type=N'COLUMN',@level2name=N'PropertyType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'错误信息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_CommonFormConfig', @level2type=N'COLUMN',@level2name=N'ErrorMessage'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'正则校验表达式' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_CommonFormConfig', @level2type=N'COLUMN',@level2name=N'Regex'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自然主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_DbLink', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'连接名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_DbLink', @level2type=N'COLUMN',@level2name=N'LinkName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'连接字符串' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_DbLink', @level2type=N'COLUMN',@level2name=N'ConnectionStr'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'数据库类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_DbLink', @level2type=N'COLUMN',@level2name=N'DbType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'否已删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_DbLink', @level2type=N'COLUMN',@level2name=N'Deleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_DbLink', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_DbLink', @level2type=N'COLUMN',@level2name=N'ModifyTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_DbLink', @level2type=N'COLUMN',@level2name=N'CreatorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_DbLink', @level2type=N'COLUMN',@level2name=N'CreatorName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改人Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_DbLink', @level2type=N'COLUMN',@level2name=N'ModifyId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_DbLink', @level2type=N'COLUMN',@level2name=N'ModifyName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'租户Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_DbLink', @level2type=N'COLUMN',@level2name=N'TenantId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自然主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_Department', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'部门名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_Department', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'上级部门Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_Department', @level2type=N'COLUMN',@level2name=N'ParentId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'否已删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_Department', @level2type=N'COLUMN',@level2name=N'Deleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_Department', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_Department', @level2type=N'COLUMN',@level2name=N'ModifyTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_Department', @level2type=N'COLUMN',@level2name=N'CreatorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_Department', @level2type=N'COLUMN',@level2name=N'CreatorName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改人Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_Department', @level2type=N'COLUMN',@level2name=N'ModifyId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_Department', @level2type=N'COLUMN',@level2name=N'ModifyName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'租户Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_Department', @level2type=N'COLUMN',@level2name=N'TenantId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自然主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_Dictionary', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'父级Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_Dictionary', @level2type=N'COLUMN',@level2name=N'ParentId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'类型,字典项=0,数据集=1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_Dictionary', @level2type=N'COLUMN',@level2name=N'Type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Value相同，使用Code区分，暂时没启用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_Dictionary', @level2type=N'COLUMN',@level2name=N'Code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'排序' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_Dictionary', @level2type=N'COLUMN',@level2name=N'Sort'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'否已删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_Dictionary', @level2type=N'COLUMN',@level2name=N'Deleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_Dictionary', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_Dictionary', @level2type=N'COLUMN',@level2name=N'ModifyTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_Dictionary', @level2type=N'COLUMN',@level2name=N'CreatorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_Dictionary', @level2type=N'COLUMN',@level2name=N'CreatorName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改人Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_Dictionary', @level2type=N'COLUMN',@level2name=N'ModifyId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_Dictionary', @level2type=N'COLUMN',@level2name=N'ModifyName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'租户Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_Dictionary', @level2type=N'COLUMN',@level2name=N'TenantId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'显示值' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_Dictionary', @level2type=N'COLUMN',@level2name=N'Text'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'数据值' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_Dictionary', @level2type=N'COLUMN',@level2name=N'Value'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'数据类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_Dictionary', @level2type=N'COLUMN',@level2name=N'ControlType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'描述' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_Dictionary', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自然主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_Role', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_Role', @level2type=N'COLUMN',@level2name=N'RoleName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'否已删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_Role', @level2type=N'COLUMN',@level2name=N'Deleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_Role', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_Role', @level2type=N'COLUMN',@level2name=N'ModifyTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_Role', @level2type=N'COLUMN',@level2name=N'CreatorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_Role', @level2type=N'COLUMN',@level2name=N'CreatorName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改人Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_Role', @level2type=N'COLUMN',@level2name=N'ModifyId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_Role', @level2type=N'COLUMN',@level2name=N'ModifyName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'租户Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_Role', @level2type=N'COLUMN',@level2name=N'TenantId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自然主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_RoleAction', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_RoleAction', @level2type=N'COLUMN',@level2name=N'RoleId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'权限Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_RoleAction', @level2type=N'COLUMN',@level2name=N'ActionId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'否已删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_RoleAction', @level2type=N'COLUMN',@level2name=N'Deleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_RoleAction', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_RoleAction', @level2type=N'COLUMN',@level2name=N'ModifyTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_RoleAction', @level2type=N'COLUMN',@level2name=N'CreatorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_RoleAction', @level2type=N'COLUMN',@level2name=N'CreatorName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改人Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_RoleAction', @level2type=N'COLUMN',@level2name=N'ModifyId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_RoleAction', @level2type=N'COLUMN',@level2name=N'ModifyName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'租户Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_RoleAction', @level2type=N'COLUMN',@level2name=N'TenantId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自然主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_Test', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'父级Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_Test', @level2type=N'COLUMN',@level2name=N'ParentId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'类型,菜单=0,页面=1,权限=2' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_Test', @level2type=N'COLUMN',@level2name=N'Type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'权限名/菜单名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_Test', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'菜单地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_Test', @level2type=N'COLUMN',@level2name=N'Url'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'权限值' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_Test', @level2type=N'COLUMN',@level2name=N'Value'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否需要权限(仅页面有效)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_Test', @level2type=N'COLUMN',@level2name=N'NeedTest'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'图标' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_Test', @level2type=N'COLUMN',@level2name=N'Icon'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'排序' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_Test', @level2type=N'COLUMN',@level2name=N'Sort'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'否已删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_Test', @level2type=N'COLUMN',@level2name=N'Deleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_Test', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_Test', @level2type=N'COLUMN',@level2name=N'ModifyTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_Test', @level2type=N'COLUMN',@level2name=N'CreatorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_Test', @level2type=N'COLUMN',@level2name=N'CreatorName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改人Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_Test', @level2type=N'COLUMN',@level2name=N'ModifyId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_Test', @level2type=N'COLUMN',@level2name=N'ModifyName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'租户Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_Test', @level2type=N'COLUMN',@level2name=N'TenantId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自然主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_User', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_User', @level2type=N'COLUMN',@level2name=N'UserName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'密码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_User', @level2type=N'COLUMN',@level2name=N'Password'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_User', @level2type=N'COLUMN',@level2name=N'RealName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'性别' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_User', @level2type=N'COLUMN',@level2name=N'Sex'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'出生日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_User', @level2type=N'COLUMN',@level2name=N'Birthday'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所属部门Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_User', @level2type=N'COLUMN',@level2name=N'DepartmentId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'否已删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_User', @level2type=N'COLUMN',@level2name=N'Deleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_User', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_User', @level2type=N'COLUMN',@level2name=N'ModifyTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_User', @level2type=N'COLUMN',@level2name=N'CreatorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_User', @level2type=N'COLUMN',@level2name=N'CreatorName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改人Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_User', @level2type=N'COLUMN',@level2name=N'ModifyId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_User', @level2type=N'COLUMN',@level2name=N'ModifyName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'租户Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_User', @level2type=N'COLUMN',@level2name=N'TenantId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自然主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_UserLog', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_UserLog', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_UserLog', @level2type=N'COLUMN',@level2name=N'CreatorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_UserLog', @level2type=N'COLUMN',@level2name=N'CreatorName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'日志类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_UserLog', @level2type=N'COLUMN',@level2name=N'LogType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'日志内容' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_UserLog', @level2type=N'COLUMN',@level2name=N'LogContent'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_UserRole', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_UserRole', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_UserRole', @level2type=N'COLUMN',@level2name=N'CreatorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'否已删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_UserRole', @level2type=N'COLUMN',@level2name=N'Deleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_UserRole', @level2type=N'COLUMN',@level2name=N'UserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_UserRole', @level2type=N'COLUMN',@level2name=N'RoleId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自然主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_Notice', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'标题' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_Notice', @level2type=N'COLUMN',@level2name=N'Title'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'类型=0，通告' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_Notice', @level2type=N'COLUMN',@level2name=N'Type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'附件' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_Notice', @level2type=N'COLUMN',@level2name=N'Appendix'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'否已删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_Notice', @level2type=N'COLUMN',@level2name=N'Deleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_Notice', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_Notice', @level2type=N'COLUMN',@level2name=N'ModifyTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_Notice', @level2type=N'COLUMN',@level2name=N'CreatorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_Notice', @level2type=N'COLUMN',@level2name=N'CreatorName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改人Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_Notice', @level2type=N'COLUMN',@level2name=N'ModifyId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_Notice', @level2type=N'COLUMN',@level2name=N'ModifyName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'租户Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_Notice', @level2type=N'COLUMN',@level2name=N'TenantId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'内容' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_Notice', @level2type=N'COLUMN',@level2name=N'Text'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态 =0草稿中，=1已发布，=2撤回' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_Notice', @level2type=N'COLUMN',@level2name=N'Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'类型=0，全部，=1，发给指定用户，=2，发给指定角色，=3，发给指定部门' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_Notice', @level2type=N'COLUMN',@level2name=N'Mode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Mode=0，对应ALL,Mode=1,对应用户Id,Mode=2,对应角色Id，Mode=3，对应部门Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_Notice', @level2type=N'COLUMN',@level2name=N'AnyId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自然主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_NoticeReadingMarks', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'否已删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_NoticeReadingMarks', @level2type=N'COLUMN',@level2name=N'Deleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_NoticeReadingMarks', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_NoticeReadingMarks', @level2type=N'COLUMN',@level2name=N'ModifyTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_NoticeReadingMarks', @level2type=N'COLUMN',@level2name=N'CreatorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_NoticeReadingMarks', @level2type=N'COLUMN',@level2name=N'CreatorName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改人Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_NoticeReadingMarks', @level2type=N'COLUMN',@level2name=N'ModifyId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_NoticeReadingMarks', @level2type=N'COLUMN',@level2name=N'ModifyName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'租户Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_NoticeReadingMarks', @level2type=N'COLUMN',@level2name=N'TenantId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自然主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_UserGroup', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'否已删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_UserGroup', @level2type=N'COLUMN',@level2name=N'Deleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_UserGroup', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_UserGroup', @level2type=N'COLUMN',@level2name=N'ModifyTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_UserGroup', @level2type=N'COLUMN',@level2name=N'CreatorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_UserGroup', @level2type=N'COLUMN',@level2name=N'CreatorName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改人Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_UserGroup', @level2type=N'COLUMN',@level2name=N'ModifyId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_UserGroup', @level2type=N'COLUMN',@level2name=N'ModifyName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'租户Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_UserGroup', @level2type=N'COLUMN',@level2name=N'TenantId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自然主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_UserMail', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'否已删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_UserMail', @level2type=N'COLUMN',@level2name=N'Deleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_UserMail', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_UserMail', @level2type=N'COLUMN',@level2name=N'ModifyTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_UserMail', @level2type=N'COLUMN',@level2name=N'CreatorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_UserMail', @level2type=N'COLUMN',@level2name=N'CreatorName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改人Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_UserMail', @level2type=N'COLUMN',@level2name=N'ModifyId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_UserMail', @level2type=N'COLUMN',@level2name=N'ModifyName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'租户Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_UserMail', @level2type=N'COLUMN',@level2name=N'TenantId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态 =0草稿中，=1已发布，=2撤回' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_UserMail', @level2type=N'COLUMN',@level2name=N'Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自然主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_UserMessage', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'否已删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_UserMessage', @level2type=N'COLUMN',@level2name=N'Deleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_UserMessage', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_UserMessage', @level2type=N'COLUMN',@level2name=N'ModifyTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_UserMessage', @level2type=N'COLUMN',@level2name=N'CreatorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_UserMessage', @level2type=N'COLUMN',@level2name=N'CreatorName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改人Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_UserMessage', @level2type=N'COLUMN',@level2name=N'ModifyId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_UserMessage', @level2type=N'COLUMN',@level2name=N'ModifyName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'租户Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_UserMessage', @level2type=N'COLUMN',@level2name=N'TenantId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态 =0草稿中，=1已发送，=2废弃撤回，=3发送失败' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_UserMessage', @level2type=N'COLUMN',@level2name=N'Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自然主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OA_DefForm', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'权限值' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OA_DefForm', @level2type=N'COLUMN',@level2name=N'Value'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'否已删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OA_DefForm', @level2type=N'COLUMN',@level2name=N'Deleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OA_DefForm', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OA_DefForm', @level2type=N'COLUMN',@level2name=N'ModifyTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OA_DefForm', @level2type=N'COLUMN',@level2name=N'CreatorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OA_DefForm', @level2type=N'COLUMN',@level2name=N'CreatorName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改人Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OA_DefForm', @level2type=N'COLUMN',@level2name=N'ModifyId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OA_DefForm', @level2type=N'COLUMN',@level2name=N'ModifyName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'租户Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OA_DefForm', @level2type=N'COLUMN',@level2name=N'TenantId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自然主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OA_DefType', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'否已删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OA_DefType', @level2type=N'COLUMN',@level2name=N'Deleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OA_DefType', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OA_DefType', @level2type=N'COLUMN',@level2name=N'ModifyTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OA_DefType', @level2type=N'COLUMN',@level2name=N'CreatorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OA_DefType', @level2type=N'COLUMN',@level2name=N'CreatorName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改人Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OA_DefType', @level2type=N'COLUMN',@level2name=N'ModifyId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OA_DefType', @level2type=N'COLUMN',@level2name=N'ModifyName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'租户Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OA_DefType', @level2type=N'COLUMN',@level2name=N'TenantId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自然主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OA_UserForm', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'否已删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OA_UserForm', @level2type=N'COLUMN',@level2name=N'Deleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OA_UserForm', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OA_UserForm', @level2type=N'COLUMN',@level2name=N'ModifyTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OA_UserForm', @level2type=N'COLUMN',@level2name=N'CreatorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OA_UserForm', @level2type=N'COLUMN',@level2name=N'CreatorName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改人Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OA_UserForm', @level2type=N'COLUMN',@level2name=N'ModifyId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OA_UserForm', @level2type=N'COLUMN',@level2name=N'ModifyName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'租户Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OA_UserForm', @level2type=N'COLUMN',@level2name=N'TenantId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自然主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OA_UserFormStep', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'否已删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OA_UserFormStep', @level2type=N'COLUMN',@level2name=N'Deleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OA_UserFormStep', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OA_UserFormStep', @level2type=N'COLUMN',@level2name=N'ModifyTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OA_UserFormStep', @level2type=N'COLUMN',@level2name=N'CreatorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OA_UserFormStep', @level2type=N'COLUMN',@level2name=N'CreatorName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改人Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OA_UserFormStep', @level2type=N'COLUMN',@level2name=N'ModifyId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OA_UserFormStep', @level2type=N'COLUMN',@level2name=N'ModifyName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'租户Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OA_UserFormStep', @level2type=N'COLUMN',@level2name=N'TenantId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自然主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Quartz_Task', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'否已删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Quartz_Task', @level2type=N'COLUMN',@level2name=N'Deleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Quartz_Task', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Quartz_Task', @level2type=N'COLUMN',@level2name=N'ModifyTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Quartz_Task', @level2type=N'COLUMN',@level2name=N'CreatorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Quartz_Task', @level2type=N'COLUMN',@level2name=N'CreatorName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改人Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Quartz_Task', @level2type=N'COLUMN',@level2name=N'ModifyId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Quartz_Task', @level2type=N'COLUMN',@level2name=N'ModifyName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'租户Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Quartz_Task', @level2type=N'COLUMN',@level2name=N'TenantId'
GO
