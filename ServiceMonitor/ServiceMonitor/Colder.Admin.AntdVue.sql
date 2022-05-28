USE [master]
GO
/****** Object:  Database [Colder.Admin.AntdVue]    Script Date: 2021/7/31 21:17:42 ******/
CREATE DATABASE [Colder.Admin.AntdVue]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Colder.Admin.AntdVue', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Colder.Admin.AntdVue.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Colder.Admin.AntdVue_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Colder.Admin.AntdVue_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Colder.Admin.AntdVue] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Colder.Admin.AntdVue].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Colder.Admin.AntdVue] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Colder.Admin.AntdVue] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Colder.Admin.AntdVue] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Colder.Admin.AntdVue] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Colder.Admin.AntdVue] SET ARITHABORT OFF 
GO
ALTER DATABASE [Colder.Admin.AntdVue] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Colder.Admin.AntdVue] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Colder.Admin.AntdVue] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Colder.Admin.AntdVue] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Colder.Admin.AntdVue] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Colder.Admin.AntdVue] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Colder.Admin.AntdVue] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Colder.Admin.AntdVue] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Colder.Admin.AntdVue] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Colder.Admin.AntdVue] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Colder.Admin.AntdVue] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Colder.Admin.AntdVue] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Colder.Admin.AntdVue] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Colder.Admin.AntdVue] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Colder.Admin.AntdVue] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Colder.Admin.AntdVue] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Colder.Admin.AntdVue] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Colder.Admin.AntdVue] SET RECOVERY FULL 
GO
ALTER DATABASE [Colder.Admin.AntdVue] SET  MULTI_USER 
GO
ALTER DATABASE [Colder.Admin.AntdVue] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Colder.Admin.AntdVue] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Colder.Admin.AntdVue] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Colder.Admin.AntdVue] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Colder.Admin.AntdVue] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Colder.Admin.AntdVue', N'ON'
GO
ALTER DATABASE [Colder.Admin.AntdVue] SET QUERY_STORE = OFF
GO
USE [Colder.Admin.AntdVue]
GO
/****** Object:  Schema [wfc]    Script Date: 2021/7/31 21:17:42 ******/
CREATE SCHEMA [wfc]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 2021/7/31 21:17:42 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Base_Dictionary]    Script Date: 2022/5/28 11:25:16 ******/
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

ALTER TABLE [dbo].[Base_Dictionary] ADD  DEFAULT ((0)) FOR [ControlType]
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
/****** Object:  Table [dbo].[Base_Action]    Script Date: 2021/7/31 21:17:42 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Base_AppSecret]    Script Date: 2021/7/31 21:17:42 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Base_Datasource]    Script Date: 2021/7/31 21:17:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Base_Datasource](
	[Id] [nvarchar](50) NOT NULL,
	[Code] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[DbLinkId] [nvarchar](50) NOT NULL,
	[Sql] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[CreatorId] [nvarchar](50) NULL,
	[CreatorName] [nvarchar](50) NULL,
	[CreateTime] [datetime2](7) NULL,
	[ModifyId] [nvarchar](50) NULL,
	[ModifyName] [nvarchar](50) NULL,
	[ModifyTime] [datetime2](7) NULL,
	[TenantId] [nvarchar](50) NULL,
	[Deleted] [bit] NULL,
 CONSTRAINT [PK__Base_Dat__3214EC07E304798D] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Base_DbLink]    Script Date: 2021/7/31 21:17:42 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Base_Department]    Script Date: 2021/7/31 21:17:42 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Base_Role]    Script Date: 2021/7/31 21:17:42 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Base_RoleAction]    Script Date: 2021/7/31 21:17:42 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Base_User]    Script Date: 2021/7/31 21:17:42 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Base_UserLog]    Script Date: 2021/7/31 21:17:42 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Base_UserRole]    Script Date: 2021/7/31 21:17:42 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[D_Notice]    Script Date: 2021/7/31 21:17:42 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[D_NoticeReadingMarks]    Script Date: 2021/7/31 21:17:42 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[D_UserGroup]    Script Date: 2021/7/31 21:17:42 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[D_UserMail]    Script Date: 2021/7/31 21:17:42 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[D_UserMessage]    Script Date: 2021/7/31 21:17:42 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[D_UserMessage_202104]    Script Date: 2021/7/31 21:17:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[D_UserMessage_202104](
	[Id] [nvarchar](50) NOT NULL,
	[Type] [int] NOT NULL,
	[ReadingMarks] [nvarchar](max) NULL,
	[GroupId] [nvarchar](max) NULL,
	[GroupName] [nvarchar](max) NULL,
	[Status] [int] NOT NULL,
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
 CONSTRAINT [PK_D_UserMessage_202104] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[D_UserMessage_202105]    Script Date: 2021/7/31 21:17:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[D_UserMessage_202105](
	[Id] [nvarchar](50) NOT NULL,
	[Type] [int] NOT NULL,
	[ReadingMarks] [nvarchar](max) NULL,
	[GroupId] [nvarchar](max) NULL,
	[GroupName] [nvarchar](max) NULL,
	[Status] [int] NOT NULL,
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
 CONSTRAINT [PK_D_UserMessage_202105] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[D_UserMessage_202106]    Script Date: 2021/7/31 21:17:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[D_UserMessage_202106](
	[Id] [nvarchar](50) NOT NULL,
	[Type] [int] NOT NULL,
	[ReadingMarks] [nvarchar](max) NULL,
	[GroupId] [nvarchar](max) NULL,
	[GroupName] [nvarchar](max) NULL,
	[Status] [int] NOT NULL,
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
 CONSTRAINT [PK_D_UserMessage_202106] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[D_UserMessage_202107]    Script Date: 2021/7/31 21:17:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[D_UserMessage_202107](
	[Id] [nvarchar](50) NOT NULL,
	[Type] [int] NOT NULL,
	[ReadingMarks] [nvarchar](max) NULL,
	[GroupId] [nvarchar](max) NULL,
	[GroupName] [nvarchar](max) NULL,
	[Status] [int] NOT NULL,
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
 CONSTRAINT [PK_D_UserMessage_202107] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[D_UserMessage_202108]    Script Date: 2021/7/31 21:17:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[D_UserMessage_202108](
	[Id] [nvarchar](50) NOT NULL,
	[Type] [int] NOT NULL,
	[ReadingMarks] [nvarchar](max) NULL,
	[GroupId] [nvarchar](max) NULL,
	[GroupName] [nvarchar](max) NULL,
	[Status] [int] NOT NULL,
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
 CONSTRAINT [PK_D_UserMessage_202108] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OA_DefForm]    Script Date: 2021/7/31 21:17:42 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OA_DefType]    Script Date: 2021/7/31 21:17:42 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OA_UserForm]    Script Date: 2021/7/31 21:17:42 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OA_UserFormStep]    Script Date: 2021/7/31 21:17:42 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Quartz_Task]    Script Date: 2021/7/31 21:17:42 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [wfc].[Event]    Script Date: 2021/7/31 21:17:42 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [wfc].[ExecutionError]    Script Date: 2021/7/31 21:17:42 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [wfc].[ExecutionPointer]    Script Date: 2021/7/31 21:17:42 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [wfc].[ExtensionAttribute]    Script Date: 2021/7/31 21:17:42 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [wfc].[Subscription]    Script Date: 2021/7/31 21:17:42 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [wfc].[Workflow]    Script Date: 2021/7/31 21:17:42 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
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
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1178957405992521728', NULL, 0, N'系统管理', NULL, NULL, 1, N'setting', 1, 0, CAST(N'2021-05-09T20:01:55.3227752' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1178957553778823168', N'1178957405992521728', 1, N'权限管理', N'/Base_Manage/Base_Action/List', NULL, 1, N'lock', 1, 0, CAST(N'2021-05-09T20:01:55.3227801' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1179018395304071168', N'1178957405992521728', 1, N'密钥管理', N'/Base_Manage/Base_AppSecret/List', NULL, 1, N'key', 2, 0, CAST(N'2021-05-09T20:01:55.3220000' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1182652266117599232', N'1178957405992521728', 1, N'用户管理', N'/Base_Manage/Base_User/List', NULL, 1, N'user-add', 1, 0, CAST(N'2021-05-09T20:01:55.3227807' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1182652367447789568', N'1178957405992521728', 1, N'角色管理', N'/Base_Manage/Base_Role/List', NULL, 1, N'safety', 1, 0, CAST(N'2021-05-09T20:01:55.3227809' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1182652433302556672', N'1178957405992521728', 1, N'部门管理', N'/Base_Manage/Base_Department/List', NULL, 1, N'usergroup-add', 1, 0, CAST(N'2021-05-09T20:01:55.3227817' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1182652599069839360', N'1178957405992521728', 1, N'操作日志', N'/Base_Manage/Base_UserLog/List', NULL, 1, N'file-search', 1, 0, CAST(N'2021-05-09T20:01:55.3227823' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1182652599069839361', N'1178957405992521728', 1, N'任务管理', N'/Quartz_Manage/Quartz_Task/List', NULL, 1, N'calendar', 1, 0, CAST(N'2021-05-09T20:01:55.3227825' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1188800845714558976', N'1182652266117599232', 2, N'增', NULL, N'Base_User.Add', 1, NULL, 1, 0, CAST(N'2021-05-09T20:01:55.3227827' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1188800845714558977', N'1182652266117599232', 2, N'改', NULL, N'Base_User.Edit', 1, NULL, 1, 0, CAST(N'2021-05-09T20:01:55.3227830' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1188800845714558978', N'1182652266117599232', 2, N'删', NULL, N'Base_User.Delete', 1, NULL, 1, 0, CAST(N'2021-05-09T20:01:55.3227832' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1188800845714558986', N'1412051431724158976', 2, N'增', NULL, N'Base_Datasource.Add', 1, NULL, 1, 0, CAST(N'2021-05-09T20:01:55.3227827' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1188800845714558987', N'1412051431724158976', 2, N'改', NULL, N'Base_Datasource.Edit', 1, NULL, 1, 0, CAST(N'2021-05-09T20:01:55.3227830' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1188800845714558988', N'1412051431724158976', 2, N'删', NULL, N'Base_Datasource.Delete', 1, NULL, 1, 0, CAST(N'2021-05-09T20:01:55.3227832' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1188801057778569216', N'1182652367447789568', 2, N'增', NULL, N'Base_Role.Add', 1, NULL, 1, 0, CAST(N'2021-05-09T20:01:55.3227833' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1188801057778569217', N'1182652367447789568', 2, N'改', NULL, N'Base_Role.Edit', 1, NULL, 1, 0, CAST(N'2021-05-09T20:01:55.3227835' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1188801057778569218', N'1182652367447789568', 2, N'删', NULL, N'Base_Role.Delete', 1, NULL, 1, 0, CAST(N'2021-05-09T20:01:55.3227837' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1188801109783744512', N'1182652433302556672', 2, N'增', NULL, N'Base_Department.Add', 1, NULL, 1, 0, CAST(N'2021-05-09T20:01:55.3227839' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1188801109783744513', N'1182652433302556672', 2, N'改', NULL, N'Base_Department.Edit', 1, NULL, 1, 0, CAST(N'2021-05-09T20:01:55.3227842' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1188801109783744514', N'1182652433302556672', 2, N'删', NULL, N'Base_Department.Delete', 1, NULL, 1, 0, CAST(N'2021-05-09T20:01:55.3227844' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1188801273885888512', N'1179018395304071168', 2, N'增', NULL, N'Base_AppSecret.Add', 1, NULL, 1, 0, CAST(N'2021-07-31T20:59:05.3806610' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1188801273885888513', N'1179018395304071168', 2, N'改', NULL, N'Base_AppSecret.Edit', 1, NULL, 1, 0, CAST(N'2021-07-31T20:59:05.3806612' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1188801273885888514', N'1179018395304071168', 2, N'删', NULL, N'Base_AppSecret.Delete', 1, NULL, 1, 0, CAST(N'2021-07-31T20:59:05.3806614' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1188801341661646848', N'1178957553778823168', 2, N'增', NULL, N'Base_Action.Add', 1, NULL, 1, 0, CAST(N'2021-05-09T20:01:55.3227865' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1188801341661646849', N'1178957553778823168', 2, N'改', NULL, N'Base_Action.Edit', 1, NULL, 1, 0, CAST(N'2021-05-09T20:01:55.3227866' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1188801341661646850', N'1178957553778823168', 2, N'删', NULL, N'Base_Action.Delete', 1, NULL, 1, 0, CAST(N'2021-05-09T20:01:55.3227868' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1193158266167758848', NULL, 0, N'首页', NULL, NULL, 1, N'home', 1, 0, CAST(N'2021-05-09T20:01:55.3227870' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1193158266167758849', NULL, 0, N'消息中心', NULL, NULL, 1, N'notification', 1, 0, CAST(N'2021-05-09T20:01:55.3227881' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1193158266167758850', NULL, 0, N'流程中心', NULL, NULL, 1, N'clock-circle', 1, 0, CAST(N'2021-05-09T20:01:55.3227890' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1193158266167758851', NULL, 1, N'流程管理', N'/OA_Manage/OA_DefForm/List', NULL, 1, N'interaction', 1, 0, CAST(N'2021-05-09T20:01:55.0000000' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1193158266167758852', N'1193158266167758851', 2, N'增', NULL, N'OA_DefForm.Add', 1, NULL, 1, 0, CAST(N'2021-07-31T20:59:05.3806703' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1193158266167758853', N'1193158266167758851', 2, N'改', NULL, N'OA_DefForm.Edit', 1, NULL, 1, 0, CAST(N'2021-07-31T20:59:05.3806706' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1193158266167758854', N'1193158266167758851', 2, N'删', NULL, N'OA_DefForm.Delete', 1, NULL, 1, 0, CAST(N'2021-07-31T20:59:05.3806709' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1193158266167758855', N'1193158266167758850', 1, N'发起流程', N'/OA_Manage/OA_DefForm/TreeList', NULL, 1, N'file-add', 1, 0, CAST(N'2021-05-09T20:01:55.3227901' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1193158266167758856', NULL, 1, N'我的流程', N'/OA_Manage/OA_UserForm/List', NULL, 1, N'file-done', 1, 0, CAST(N'2021-05-09T20:01:55.0000000' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1193158266167758860', N'1193158266167758856', 2, N'增', NULL, N'OA_UserForm.Add', 1, NULL, 1, 0, CAST(N'2021-07-31T20:59:05.3806717' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1193158266167758861', N'1193158266167758856', 2, N'改', NULL, N'OA_UserForm.Edit', 1, NULL, 1, 0, CAST(N'2021-07-31T20:59:05.3806719' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1193158266167758862', N'1193158266167758856', 2, N'删', NULL, N'OA_UserForm.Delete', 1, NULL, 1, 0, CAST(N'2021-07-31T20:59:05.3806720' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1193158266167758863', N'1193158266167758850', 1, N'表单管理', N'/OA_Manage/OA_DefType/List', NULL, 1, N'form', 1, 0, CAST(N'2021-05-09T20:01:55.3227911' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1193158266167758864', N'1193158266167758863', 2, N'增', NULL, N'OA_DefType.Add', 1, NULL, 1, 0, CAST(N'2021-05-09T20:01:55.3227913' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1193158266167758865', N'1193158266167758863', 2, N'改', NULL, N'OA_DefType.Edit', 1, NULL, 1, 0, CAST(N'2021-05-09T20:01:55.3227915' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1193158266167758866', N'1193158266167758863', 2, N'删', NULL, N'OA_DefType.Delete', 1, NULL, 1, 0, CAST(N'2021-05-09T20:01:55.3227916' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1193158266167758867', N'1193158266167758849', 1, N'站内消息', N'/D_Manage/D_UserMessage/List', NULL, 0, N'message', 1, 0, CAST(N'2021-05-09T20:01:55.3227883' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1193158266167758868', N'1193158266167758849', 1, N'站内信', N'/D_Manage/D_UserMail/Index', NULL, 0, N'mail', 1, 0, CAST(N'2021-05-09T20:01:55.3227886' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1193158266167758869', N'1193158266167758849', 1, N'通告', N'/D_Manage/D_Notice/List', NULL, 0, N'sound', 1, 0, CAST(N'2021-05-09T20:01:55.3227888' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1193158266167758967', NULL, 0, N'个人页', NULL, NULL, 1, N'user', 1, 0, CAST(N'2021-05-09T20:01:55.3227921' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1193158266167758968', N'1193158266167758967', 1, N'个人中心', N'/account/center/Index', NULL, 0, N'user', 1, 0, CAST(N'2021-05-09T20:01:55.3227923' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1193158266167758969', N'1193158266167758967', 1, N'个人设置', N'/account/settings/Index', NULL, 0, N'user', 1, 0, CAST(N'2021-05-09T20:01:55.3227925' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1193158630615027712', N'1193158266167758848', 1, N'框架介绍', N'/Home/Introduce', NULL, 0, NULL, 1, 0, CAST(N'2021-05-09T20:01:55.3227872' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1193158780011941888', N'1193158266167758848', 1, N'运营统计', N'/Home/Statis', NULL, 0, NULL, 1, 0, CAST(N'2021-05-09T20:01:55.3227874' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1193158780011941889', N'1193158266167758848', 1, N'我的控制台', N'/Home/UserConsole', NULL, 0, NULL, 1, 0, CAST(N'2021-05-09T20:01:55.3227876' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1193158780011941890', N'1193158266167758848', 1, N'3D展台', N'/Home/_3DShowcase', NULL, 0, NULL, 1, 0, CAST(N'2021-05-09T20:01:55.3227879' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1388800845714558978', N'1412051431724158976', 2, N'查', NULL, N'Base_Datasource.View', 1, NULL, 1, 0, CAST(N'2021-05-09T20:01:55.3227832' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1412051431724158976', N'1178957405992521728', 1, N'数据源设置', N'/Base_Manage/Base_Datasource/List', NULL, 1, N'user-add', 1, 0, CAST(N'2021-07-05T22:11:10.0000000' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1420568664029007872', N'1179018395304071168', 2, N'增', NULL, N'Base_AppSecret.Add', 1, NULL, 1, 0, CAST(N'2021-07-29T10:15:37.0514540' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1420568664029007873', N'1179018395304071168', 2, N'改', NULL, N'Base_AppSecret.Edit', 1, NULL, 1, 0, CAST(N'2021-07-29T10:15:37.0514931' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Action] ([Id], [ParentId], [Type], [Name], [Url], [Value], [NeedAction], [Icon], [Sort], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1420568664029007874', N'1179018395304071168', 2, N'删', NULL, N'Base_AppSecret.Delete', 1, NULL, 1, 0, CAST(N'2021-07-29T10:15:37.0514955' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_AppSecret] ([Id], [AppId], [AppSecret], [AppName], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1415961648509751296', N'v2', N'aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa', N'ssssssssss', 0, CAST(N'2021-07-16T17:08:58.9575801' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL)
GO
INSERT [dbo].[Base_AppSecret] ([Id], [AppId], [AppSecret], [AppName], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1420186330884739072', N'111', N'11', N'11', 0, CAST(N'2021-07-28T08:56:21.0000000' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL)
GO
INSERT [dbo].[Base_DbLink] ([Id], [LinkName], [ConnectionStr], [DbType], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1371083607036137472', N'BaseDb', N'Data Source=121.36.12.76;Initial Catalog=Colder.Admin.AntdVue;uid=sa;pwd=aic3600!', N'SqlServer', 0, CAST(N'2021-03-14T20:59:40.0770541' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_DbLink] ([Id], [LinkName], [ConnectionStr], [DbType], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1421455377660121088', N'BaseDb', N'Data Source=.;Initial Catalog=Colder.Admin.AntdVue;Integrated Security=True;Pooling=true;', N'SqlServer', 0, CAST(N'2021-07-31T20:59:06.0558609' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Department] ([Id], [Name], [ParentId], [ParentIds], [ParentNames], [Level], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1384700356423847936', N'部门1', NULL, NULL, NULL, 0, 0, CAST(N'2021-04-21T10:47:46.1174926' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Department] ([Id], [Name], [ParentId], [ParentIds], [ParentNames], [Level], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1420177716941950976', N'部门2', NULL, NULL, NULL, 0, 0, CAST(N'2021-07-28T08:22:08.0023472' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Role] ([Id], [RoleName], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1371083605253558272', N'超级管理员', 0, CAST(N'2021-03-14T20:59:39.6518679' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Role] ([Id], [RoleName], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1421455369992933376', N'部门管理员', 0, CAST(N'2021-07-31T20:59:04.2276166' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_Role] ([Id], [RoleName], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1421455370911485952', N'超级管理员', 0, CAST(N'2021-07-31T20:59:04.4465795' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_User] ([Id], [UserName], [Password], [RealName], [Sex], [Birthday], [DepartmentId], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [Avatar], [PhoneNumber]) VALUES (N'1421459632328544256', N'alice', N'e10adc3949ba59abbe56e057f20f883e', NULL, 0, NULL, NULL, 0, CAST(N'2021-07-31T21:16:00.4471912' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_User] ([Id], [UserName], [Password], [RealName], [Sex], [Birthday], [DepartmentId], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [Avatar], [PhoneNumber]) VALUES (N'1421459632378875904', N'bob', N'e10adc3949ba59abbe56e057f20f883e', NULL, 0, NULL, NULL, 0, CAST(N'2021-07-31T21:16:00.4591023' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_User] ([Id], [UserName], [Password], [RealName], [Sex], [Birthday], [DepartmentId], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [Avatar], [PhoneNumber]) VALUES (N'Admin', N'Admin', N'e3afed0047b08059d0fada10f400c1e5', NULL, 0, NULL, NULL, 0, CAST(N'2021-07-31T21:16:00.2098349' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Base_UserLog] ([Id], [CreateTime], [CreatorId], [CreatorName], [LogType], [LogContent]) VALUES (N'1381545553464135680', CAST(N'2021-04-12T17:51:42.4784635' AS DateTime2), N'Admin', N'Admin', N'系统用户管理', N'删除用户:bob')
GO
INSERT [dbo].[Base_UserLog] ([Id], [CreateTime], [CreatorId], [CreatorName], [LogType], [LogContent]) VALUES (N'1384700356583231488', CAST(N'2021-04-21T10:47:46.1554630' AS DateTime2), N'Admin', N'Admin', N'部门管理', N'添加部门名:部门1')
GO
INSERT [dbo].[Base_UserLog] ([Id], [CreateTime], [CreatorId], [CreatorName], [LogType], [LogContent]) VALUES (N'1406944644813557760', CAST(N'2021-06-21T19:58:37.7490086' AS DateTime2), N'Admin', N'Admin', N'系统用户管理', N'修改用户:bob')
GO
INSERT [dbo].[Base_UserLog] ([Id], [CreateTime], [CreatorId], [CreatorName], [LogType], [LogContent]) VALUES (N'1407354379886923776', CAST(N'2021-06-22T23:06:46.2020034' AS DateTime2), N'Admin', N'Admin', N'系统用户管理', N'修改用户:Admin')
GO
INSERT [dbo].[Base_UserLog] ([Id], [CreateTime], [CreatorId], [CreatorName], [LogType], [LogContent]) VALUES (N'1411234913327255552', CAST(N'2021-07-03T16:06:37.4717604' AS DateTime2), N'Admin', N'Admin', N'系统用户管理', N'添加用户:addy')
GO
INSERT [dbo].[Base_UserLog] ([Id], [CreateTime], [CreatorId], [CreatorName], [LogType], [LogContent]) VALUES (N'1411235329020530688', CAST(N'2021-07-03T16:08:16.5805908' AS DateTime2), N'Admin', N'Admin', N'系统用户管理', N'修改用户:addy')
GO
INSERT [dbo].[Base_UserLog] ([Id], [CreateTime], [CreatorId], [CreatorName], [LogType], [LogContent]) VALUES (N'1411235555676524544', CAST(N'2021-07-03T16:09:10.6191052' AS DateTime2), N'Admin', N'Admin', N'系统用户管理', N'修改用户:addy')
GO
INSERT [dbo].[Base_UserLog] ([Id], [CreateTime], [CreatorId], [CreatorName], [LogType], [LogContent]) VALUES (N'1415961648627191808', CAST(N'2021-07-16T17:08:58.9855023' AS DateTime2), N'Admin', N'Admin', N'接口密钥管理', N'添加应用Id:v2')
GO
INSERT [dbo].[Base_UserLog] ([Id], [CreateTime], [CreatorId], [CreatorName], [LogType], [LogContent]) VALUES (N'1416276184928358400', CAST(N'2021-07-17T13:58:50.2838388' AS DateTime2), N'Admin', N'Admin', N'系统用户管理', N'添加用户:2131')
GO
INSERT [dbo].[Base_UserLog] ([Id], [CreateTime], [CreatorId], [CreatorName], [LogType], [LogContent]) VALUES (N'1420177717030031360', CAST(N'2021-07-28T08:22:08.0231914' AS DateTime2), N'Admin', N'Admin', N'部门管理', N'添加部门名:部门2')
GO
INSERT [dbo].[Base_UserLog] ([Id], [CreateTime], [CreatorId], [CreatorName], [LogType], [LogContent]) VALUES (N'1420186330939265024', CAST(N'2021-07-28T08:56:21.7398422' AS DateTime2), N'Admin', N'Admin', N'接口密钥管理', N'添加应用Id:11')
GO
INSERT [dbo].[Base_UserLog] ([Id], [CreateTime], [CreatorId], [CreatorName], [LogType], [LogContent]) VALUES (N'1420258229828456448', CAST(N'2021-07-28T13:42:03.7703921' AS DateTime2), N'Admin', N'Admin', N'接口密钥管理', N'修改应用Id:111')
GO
INSERT [dbo].[Base_UserLog] ([Id], [CreateTime], [CreatorId], [CreatorName], [LogType], [LogContent]) VALUES (N'1420672863693705216', CAST(N'2021-07-29T17:09:40.1870588' AS DateTime2), N'Admin', N'Admin', N'系统角色管理', N'删除角色:部门管理员')
GO
INSERT [dbo].[Base_UserLog] ([Id], [CreateTime], [CreatorId], [CreatorName], [LogType], [LogContent]) VALUES (N'1420681624676208640', CAST(N'2021-07-29T17:44:28.9687102' AS DateTime2), N'Admin', N'Admin', N'系统用户管理', N'修改用户:Admin')
GO
INSERT [dbo].[Base_UserRole] ([Id], [CreateTime], [CreatorId], [Deleted], [UserId], [RoleId]) VALUES (N'1371083605970784256', CAST(N'2021-03-14T20:59:39.8223798' AS DateTime2), NULL, 0, N'1371083605962395648', N'1371083604494389248')
GO
INSERT [dbo].[Base_UserRole] ([Id], [CreateTime], [CreatorId], [Deleted], [UserId], [RoleId]) VALUES (N'1411235555668135936', CAST(N'2021-07-03T16:09:10.6173240' AS DateTime2), NULL, 0, N'1411234913281118208', N'1371083605253558272')
GO
INSERT [dbo].[Base_UserRole] ([Id], [CreateTime], [CreatorId], [Deleted], [UserId], [RoleId]) VALUES (N'1416276184911581184', CAST(N'2021-07-17T13:58:50.2791990' AS DateTime2), NULL, 0, N'1416276184878026752', N'1371083604494389248')
GO
INSERT [dbo].[Base_UserRole] ([Id], [CreateTime], [CreatorId], [Deleted], [UserId], [RoleId]) VALUES (N'1421455373549703168', CAST(N'2021-07-31T20:59:05.0757686' AS DateTime2), NULL, 0, N'1421455373495177216', N'1421455369992933376')
GO
INSERT [dbo].[Base_UserRole] ([Id], [CreateTime], [CreatorId], [Deleted], [UserId], [RoleId]) VALUES (N'1421459632114634752', CAST(N'2021-07-31T21:16:00.3969767' AS DateTime2), NULL, 0, N'Admin', N'1371083605253558272')
GO
INSERT [dbo].[Base_UserRole] ([Id], [CreateTime], [CreatorId], [Deleted], [UserId], [RoleId]) VALUES (N'1421459632336932864', CAST(N'2021-07-31T21:16:00.4495187' AS DateTime2), NULL, 0, N'1421459632328544256', N'1421455369992933376')
GO
INSERT [dbo].[D_Notice] ([Id], [Title], [Type], [Appendix], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [Text], [Status], [Mode], [AnyId]) VALUES (N'1376338455537127424', N'111', 0, NULL, 0, CAST(N'2021-03-29T09:00:33.5897288' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'111<br>1', 1, 0, NULL)
GO
INSERT [dbo].[D_Notice] ([Id], [Title], [Type], [Appendix], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [Text], [Status], [Mode], [AnyId]) VALUES (N'1376695050762719232', N'1', 0, NULL, 0, CAST(N'2021-03-30T08:37:32.5160676' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'1<br>', 1, 1, NULL)
GO
INSERT [dbo].[D_Notice] ([Id], [Title], [Type], [Appendix], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [Text], [Status], [Mode], [AnyId]) VALUES (N'1376695360780505088', N'12', 0, NULL, 0, CAST(N'2021-03-30T08:38:46.4302165' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'2<br>1', 1, 1, NULL)
GO
INSERT [dbo].[D_Notice] ([Id], [Title], [Type], [Appendix], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [Text], [Status], [Mode], [AnyId]) VALUES (N'1376696551413387264', N'12', 0, NULL, 0, CAST(N'2021-03-30T08:43:30.2992640' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'3<br>1', 1, 1, N'^1371083605962395648^1371083606008532992^Admin^')
GO
INSERT [dbo].[D_Notice] ([Id], [Title], [Type], [Appendix], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [Text], [Status], [Mode], [AnyId]) VALUES (N'1376699138657226752', N'1111', 0, NULL, 0, CAST(N'2021-03-30T08:53:47.1468102' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'11<br>11', 1, 0, NULL)
GO
INSERT [dbo].[D_Notice] ([Id], [Title], [Type], [Appendix], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [Text], [Status], [Mode], [AnyId]) VALUES (N'1376700158544187392', N'111', 0, NULL, 0, CAST(N'2021-03-30T08:57:50.3065124' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'11<br>', 1, 0, NULL)
GO
INSERT [dbo].[D_Notice] ([Id], [Title], [Type], [Appendix], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [Text], [Status], [Mode], [AnyId]) VALUES (N'1416575804858437632', N'123', 0, N'', 0, CAST(N'2021-07-18T09:49:25.2416400' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'<p>112231321</p>', 1, 0, NULL)
GO
INSERT [dbo].[D_Notice] ([Id], [Title], [Type], [Appendix], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [Text], [Status], [Mode], [AnyId]) VALUES (N'1419817875589304320', N'1', 0, N'', 0, CAST(N'2021-07-27T08:32:15.1382812' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'<p>1</p>', 1, 0, NULL)
GO
INSERT [dbo].[D_NoticeReadingMarks] ([Id], [NoticeId], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1376338492505722880', N'1376338455537127424', 0, CAST(N'2021-03-29T09:00:42.4037190' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL)
GO
INSERT [dbo].[D_NoticeReadingMarks] ([Id], [NoticeId], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1376695088083636224', N'1376695050762719232', 0, CAST(N'2021-03-30T08:37:41.4149078' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL)
GO
INSERT [dbo].[D_NoticeReadingMarks] ([Id], [NoticeId], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1376696595013177344', N'1376696551413387264', 0, CAST(N'2021-03-30T08:43:40.6949582' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL)
GO
INSERT [dbo].[D_NoticeReadingMarks] ([Id], [NoticeId], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1376700104068567040', N'1376699138657226752', 0, CAST(N'2021-03-30T08:57:37.3182155' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL)
GO
INSERT [dbo].[D_NoticeReadingMarks] ([Id], [NoticeId], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1376700175170408448', N'1376700158544187392', 0, CAST(N'2021-03-30T08:57:54.2705494' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL)
GO
INSERT [dbo].[D_NoticeReadingMarks] ([Id], [NoticeId], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1416575928133226496', N'1416575804858437632', 0, CAST(N'2021-07-18T09:49:54.6323232' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL)
GO
INSERT [dbo].[D_NoticeReadingMarks] ([Id], [NoticeId], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1419818920067469312', N'1419817875589304320', 0, CAST(N'2021-07-27T08:36:24.1610704' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL)
GO
INSERT [dbo].[D_UserGroup] ([Id], [UserIds], [UserNames], [Title], [Type], [Remark], [Appendix], [Avatar], [ManagerIds], [ManagerNames], [Name], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1416959971798552576', N'^1371083605962395648^1385225937288695808^1411234913281118208^', N'^alice^bob^addy^', N'4242', 0, N'42424', N'', N'/Images/group.jpg', NULL, NULL, N'111', 0, CAST(N'2021-07-19T11:15:57.7776545' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL)
GO
INSERT [dbo].[D_UserGroup] ([Id], [UserIds], [UserNames], [Title], [Type], [Remark], [Appendix], [Avatar], [ManagerIds], [ManagerNames], [Name], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1416960042992668672', N'^1371083605962395648^1385225937288695808^1411234913281118208^Admin^', N'^alice^bob^addy^Admin^', N'12', 0, N'2121', N'', N'/Images/group.jpg', NULL, NULL, N'wwwwwwwwwww', 0, CAST(N'2021-07-19T11:16:14.7515740' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL)
GO
INSERT [dbo].[D_UserGroup] ([Id], [UserIds], [UserNames], [Title], [Type], [Remark], [Appendix], [Avatar], [ManagerIds], [ManagerNames], [Name], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1416980889455300608', N'^1416276184878026752^1385225937288695808^1371083605962395648^', N'^2131^bob^alice^', N'3223', 0, N'3', N'', N'/Images/group.jpg', NULL, NULL, N'332233', 0, CAST(N'2021-07-19T12:39:04.9355833' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL)
GO
INSERT [dbo].[D_UserMail] ([Id], [Title], [Type], [CCIds], [CCNames], [ReadingMarks], [StarMark], [Appendix], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text], [Status]) VALUES (N'1376695607636267008', N'11', 0, NULL, NULL, N'^Admin^', 0, NULL, 0, CAST(N'2021-03-30T08:39:45.2854746' AS DateTime2), CAST(N'2021-03-30T08:39:54.2454193' AS DateTime2), N'Admin', N'Admin', N'Admin', N'Admin', NULL, N'^1371083605962395648^1371083606008532992^Admin^', N'^alice^bob^Admin^', N'1<br>1', 1)
GO
INSERT [dbo].[D_UserMail] ([Id], [Title], [Type], [CCIds], [CCNames], [ReadingMarks], [StarMark], [Appendix], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text], [Status]) VALUES (N'1383246902304182272', N'11', 0, NULL, NULL, N'^Admin^', 0, NULL, 0, CAST(N'2021-04-17T10:32:15.6514918' AS DateTime2), CAST(N'2021-05-19T15:07:29.2361550' AS DateTime2), N'Admin', N'Admin', N'Admin', N'Admin', NULL, N'^1371083605962395648^Admin^', N'^alice^Admin^', N'1<br>11', 1)
GO
INSERT [dbo].[D_UserMail] ([Id], [Title], [Type], [CCIds], [CCNames], [ReadingMarks], [StarMark], [Appendix], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text], [Status]) VALUES (N'1406658981975298048', N'rewrewrewrew', 0, NULL, NULL, N'^Admin^', 0, NULL, 0, CAST(N'2021-06-21T01:03:30.4209182' AS DateTime2), CAST(N'2021-07-03T17:39:13.8934628' AS DateTime2), N'Admin', N'Admin', N'Admin', N'Admin', NULL, N'^Admin^1371083605962395648^1385225937288695808^', N'^Admin^alice^bob^', N'rewrewrewr', 1)
GO
INSERT [dbo].[D_UserMail] ([Id], [Title], [Type], [CCIds], [CCNames], [ReadingMarks], [StarMark], [Appendix], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text], [Status]) VALUES (N'1411257094471946240', N'rr', 0, NULL, NULL, NULL, 0, NULL, 0, CAST(N'2021-07-03T17:34:45.8681961' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^1411234913281118208^', N'^addy^', N'sd<br>', 0)
GO
INSERT [dbo].[D_UserMail] ([Id], [Title], [Type], [CCIds], [CCNames], [ReadingMarks], [StarMark], [Appendix], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text], [Status]) VALUES (N'1411257175862415360', N'66', 0, NULL, NULL, NULL, 0, NULL, 0, CAST(N'2021-07-03T17:35:05.2737511' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^1411234913281118208^', N'^addy^', N'345<br>', 0)
GO
INSERT [dbo].[D_UserMail] ([Id], [Title], [Type], [CCIds], [CCNames], [ReadingMarks], [StarMark], [Appendix], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text], [Status]) VALUES (N'1411257195751804928', NULL, 0, NULL, NULL, NULL, 0, NULL, 0, CAST(N'2021-07-03T17:35:10.0158708' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^^', N'^^', N'<br>', 0)
GO
INSERT [dbo].[D_UserMail] ([Id], [Title], [Type], [CCIds], [CCNames], [ReadingMarks], [StarMark], [Appendix], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text], [Status]) VALUES (N'1412394794193260544', N' 11', 0, NULL, NULL, N'^Admin^', 0, NULL, 0, CAST(N'2021-07-06T20:55:34.6193358' AS DateTime2), CAST(N'2021-07-16T11:11:08.6846605' AS DateTime2), N'Admin', N'Admin', N'Admin', N'Admin', NULL, N'^1371083605962395648^1385225937288695808^1411234913281118208^Admin^', N'^alice^bob^addy^Admin^', N'33<br>33', 1)
GO
INSERT [dbo].[D_UserMail] ([Id], [Title], [Type], [CCIds], [CCNames], [ReadingMarks], [StarMark], [Appendix], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text], [Status]) VALUES (N'1412394806063140864', NULL, 0, NULL, NULL, NULL, 0, NULL, 0, CAST(N'2021-07-06T20:55:37.4492627' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^^', N'^^', N'<br>', 1)
GO
INSERT [dbo].[D_UserMail] ([Id], [Title], [Type], [CCIds], [CCNames], [ReadingMarks], [StarMark], [Appendix], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text], [Status]) VALUES (N'1416576134446845952', N'T01', 0, NULL, NULL, N'^Admin^', 0, N'', 0, CAST(N'2021-07-18T09:50:43.8217178' AS DateTime2), CAST(N'2021-07-18T09:51:07.0775102' AS DateTime2), N'Admin', N'Admin', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'<p>879797987988908080</p>', 1)
GO
INSERT [dbo].[D_UserMail] ([Id], [Title], [Type], [CCIds], [CCNames], [ReadingMarks], [StarMark], [Appendix], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text], [Status]) VALUES (N'1420922057855602688', N'145', 0, NULL, NULL, NULL, 0, N'', 0, CAST(N'2021-07-30T09:39:52.7052350' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^1385225937288695808^1411234913281118208^1416276184878026752^', N'^bob^addy^2131^', N'<h2>32yd<a href="dfdhdfg"><strong>dfdhdfg</strong></a></h2>', 1)
GO
INSERT [dbo].[D_UserMessage_202104] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1385227717540057088', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-04-22T21:43:18.0000000' AS DateTime2), CAST(N'2021-04-22T21:43:19.0967599' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202104] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1385227717540057089', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-04-22T21:43:18.8054185' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'111')
GO
INSERT [dbo].[D_UserMessage_202104] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1385227761878044672', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-04-22T21:43:29.0000000' AS DateTime2), CAST(N'2021-04-22T21:43:29.5261060' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202104] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1385227761878044673', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-04-22T21:43:29.3767477' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'212')
GO
INSERT [dbo].[D_UserMessage_202104] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1385227774934913024', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-04-22T21:43:32.4890000' AS DateTime2), CAST(N'2021-04-23T16:30:49.0648830' AS DateTime2), N'Admin', N'Admin', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'12312')
GO
INSERT [dbo].[D_UserMessage_202104] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1385511500180885504', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-04-23T16:30:57.8590000' AS DateTime2), CAST(N'2021-04-23T16:31:07.9308602' AS DateTime2), N'Admin', N'Admin', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'h')
GO
INSERT [dbo].[D_UserMessage_202104] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1385511535786332160', 1, NULL, NULL, NULL, 0, 0, CAST(N'2021-04-23T16:31:06.3481512' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^1371083605962395648^', N'^alice^', N'hg')
GO
INSERT [dbo].[D_UserMessage_202104] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1385511626081308672', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-04-23T16:31:27.8760000' AS DateTime2), CAST(N'2021-04-23T16:31:27.9362253' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202104] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1385511626081308673', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-04-23T16:31:27.8760471' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'u')
GO
INSERT [dbo].[D_UserMessage_202104] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1388038809051992064', 1, NULL, NULL, NULL, 0, 0, CAST(N'2021-04-30T15:53:35.2493794' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^1371083605962395648^', N'^alice^', N'你好啊')
GO
INSERT [dbo].[D_UserMessage_202104] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1388038838231764992', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-04-30T15:53:42.2060000' AS DateTime2), CAST(N'2021-04-30T15:53:42.2473030' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你好')
GO
INSERT [dbo].[D_UserMessage_202104] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1388038838231764993', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-04-30T15:53:42.2065472' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'你好啊')
GO
INSERT [dbo].[D_UserMessage_202104] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1388038879705042944', 1, NULL, NULL, NULL, 0, 0, CAST(N'2021-04-30T15:53:52.0941976' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^1371083605962395648^', N'^alice^', N'你好')
GO
INSERT [dbo].[D_UserMessage_202105] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1389075243494019072', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-05-03T12:32:00.4760000' AS DateTime2), CAST(N'2021-05-03T12:35:03.9815027' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你好')
GO
INSERT [dbo].[D_UserMessage_202105] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1389075243494019073', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-05-03T12:32:00.4764591' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'你好')
GO
INSERT [dbo].[D_UserMessage_202105] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1389075256651550720', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-05-03T12:32:03.6130000' AS DateTime2), CAST(N'2021-05-03T12:35:03.9816786' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202105] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1389075256651550721', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-05-03T12:32:03.6137015' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'测试')
GO
INSERT [dbo].[D_UserMessage_202105] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1389479471181991936', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-05-04T15:18:15.0000000' AS DateTime2), CAST(N'2021-05-04T15:18:36.5765278' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202105] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1389479471181991937', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-05-04T15:18:15.8680021' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'/::~')
GO
INSERT [dbo].[D_UserMessage_202105] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1389479668985368576', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-05-04T15:19:03.0270000' AS DateTime2), CAST(N'2021-05-04T15:33:30.3369865' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202105] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1389479668985368577', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-05-04T15:19:03.0276353' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'/::B')
GO
INSERT [dbo].[D_UserMessage_202105] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1389483325076279296', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-05-04T15:33:34.7070000' AS DateTime2), CAST(N'2021-05-04T15:36:12.1083625' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202105] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1389483325076279297', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-05-04T15:33:34.7070957' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'/::|')
GO
INSERT [dbo].[D_UserMessage_202105] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1389484146975313920', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-05-04T15:36:50.6630000' AS DateTime2), CAST(N'2021-05-04T15:39:23.6882043' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202105] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1389484146975313921', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-05-04T15:36:50.6634102' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'11')
GO
INSERT [dbo].[D_UserMessage_202105] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1389484167258968064', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-05-04T15:36:55.4990000' AS DateTime2), CAST(N'2021-05-04T15:39:23.6883749' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202105] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1389484167258968065', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-05-04T15:36:55.4998483' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'/::D')
GO
INSERT [dbo].[D_UserMessage_202105] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1389484798975676416', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-05-04T15:39:26.0000000' AS DateTime2), CAST(N'2021-05-04T15:39:26.1897017' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202105] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1389484798975676417', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-05-04T15:39:26.1124860' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'111')
GO
INSERT [dbo].[D_UserMessage_202105] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1389484965040754688', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-05-04T15:40:05.7050000' AS DateTime2), CAST(N'2021-05-04T15:41:38.1306543' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202105] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1389484965040754689', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-05-04T15:40:05.7058789' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'/::~')
GO
INSERT [dbo].[D_UserMessage_202105] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1389485538712489984', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-05-04T15:42:22.4790000' AS DateTime2), CAST(N'2021-05-04T15:43:41.8771242' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202105] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1389485538712489985', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-05-04T15:42:22.4792267' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'/::P')
GO
INSERT [dbo].[D_UserMessage_202105] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1389485918317973504', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-05-04T15:43:52.9840000' AS DateTime2), CAST(N'2021-05-04T15:48:52.0993459' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202105] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1389485918317973505', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-05-04T15:43:52.9849046' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'/::|')
GO
INSERT [dbo].[D_UserMessage_202105] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1389487192119709696', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-05-04T15:48:56.0000000' AS DateTime2), CAST(N'2021-05-04T15:48:56.7875303' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202105] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1389487192119709697', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-05-04T15:48:56.6822979' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'/::B')
GO
INSERT [dbo].[D_UserMessage_202105] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1389487210037776384', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-05-04T15:49:00.0000000' AS DateTime2), CAST(N'2021-05-04T15:49:01.0090917' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202105] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1389487210041970688', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-05-04T15:49:00.9550174' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'/::(')
GO
INSERT [dbo].[D_UserMessage_202105] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1389487228522074112', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-05-04T15:49:05.0000000' AS DateTime2), CAST(N'2021-05-04T15:49:05.4245053' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202105] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1389487228522074113', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-05-04T15:49:05.3614773' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'/::<')
GO
INSERT [dbo].[D_UserMessage_202105] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1389487252203114496', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-05-04T15:49:11.0000000' AS DateTime2), CAST(N'2021-05-04T15:49:11.1760792' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202105] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1389487252203114497', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-05-04T15:49:11.0074495' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'/::|')
GO
INSERT [dbo].[D_UserMessage_202105] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1389487276496523264', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-05-04T15:49:16.0000000' AS DateTime2), CAST(N'2021-05-04T15:49:16.8613279' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202105] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1389487276496523265', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-05-04T15:49:16.7995023' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'/::@')
GO
INSERT [dbo].[D_UserMessage_202105] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1389487373598855168', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-05-04T15:49:39.0000000' AS DateTime2), CAST(N'2021-05-04T15:49:40.0471942' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202105] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1389487373598855169', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-05-04T15:49:39.9503157' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'/::)')
GO
INSERT [dbo].[D_UserMessage_202105] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1389487388622852096', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-05-04T15:49:43.0000000' AS DateTime2), CAST(N'2021-05-04T15:49:43.6147916' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202105] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1389487388622852097', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-05-04T15:49:43.5328036' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'/::~')
GO
INSERT [dbo].[D_UserMessage_202105] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1389487404418600960', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-05-04T15:49:47.0000000' AS DateTime2), CAST(N'2021-05-04T15:49:47.3787994' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202105] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1389487404418600961', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-05-04T15:49:47.2988552' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'/::B')
GO
INSERT [dbo].[D_UserMessage_202105] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1389487419132219392', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-05-04T15:49:50.0000000' AS DateTime2), CAST(N'2021-05-04T15:49:50.9013833' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202105] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1389487419132219393', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-05-04T15:49:50.8063046' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'/::|')
GO
INSERT [dbo].[D_UserMessage_202105] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1389487466813067264', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-05-04T15:50:02.0000000' AS DateTime2), CAST(N'2021-05-04T15:50:02.2201837' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202105] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1389487466813067265', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-05-04T15:50:02.1741348' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'/::|')
GO
INSERT [dbo].[D_UserMessage_202105] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1389487484240400384', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-05-04T15:50:06.0000000' AS DateTime2), CAST(N'2021-05-04T15:50:06.4000306' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202105] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1389487484240400385', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-05-04T15:50:06.3299100' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'Document.ContentEnd')
GO
INSERT [dbo].[D_UserMessage_202105] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1389487504339505152', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-05-04T15:50:11.0000000' AS DateTime2), CAST(N'2021-05-04T15:50:11.1938717' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202105] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1389487504339505153', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-05-04T15:50:11.1217388' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'/::<')
GO
INSERT [dbo].[D_UserMessage_202105] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1389487621285089280', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-05-04T15:50:39.0000000' AS DateTime2), CAST(N'2021-05-04T15:50:39.0436340' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202105] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1389487621285089281', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-05-04T15:50:39.0038049' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'/:8-)')
GO
INSERT [dbo].[D_UserMessage_202105] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1389487767204925440', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-05-04T15:51:13.0000000' AS DateTime2), CAST(N'2021-05-04T15:51:13.9330998' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202105] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1389487767204925441', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-05-04T15:51:13.7931653' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'/:8-)')
GO
INSERT [dbo].[D_UserMessage_202105] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1389487871039115264', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-05-04T15:51:38.0000000' AS DateTime2), CAST(N'2021-05-04T15:56:30.0998224' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202105] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1389487871039115265', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-05-04T15:51:38.5497537' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'/:8-)')
GO
INSERT [dbo].[D_UserMessage_202105] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1389489176088416256', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-05-04T15:56:49.6970000' AS DateTime2), CAST(N'2021-05-04T17:46:06.0744353' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202105] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1389489176088416257', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-05-04T15:56:49.6979746' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'/::<')
GO
INSERT [dbo].[D_UserMessage_202105] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1389516725216612352', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-05-04T17:46:17.0000000' AS DateTime2), CAST(N'2021-05-04T17:46:17.9830010' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202105] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1389516725216612353', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-05-04T17:46:17.9210764' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'/:B-)')
GO
INSERT [dbo].[D_UserMessage_202105] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1389516813460574208', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-05-04T17:46:38.0000000' AS DateTime2), CAST(N'2021-05-04T17:46:39.0213609' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202105] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1389516813460574209', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-05-04T17:46:38.9603861' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'/:B-)')
GO
INSERT [dbo].[D_UserMessage_202105] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1389516873325875200', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-05-04T17:46:53.2330000' AS DateTime2), CAST(N'2021-05-04T17:52:05.6512619' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202105] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1389516873325875201', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-05-04T17:46:53.2331998' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'/:<@')
GO
INSERT [dbo].[D_UserMessage_202105] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1389518228299976704', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-05-04T17:52:16.0000000' AS DateTime2), CAST(N'2021-05-04T17:52:16.4599053' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202105] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1389518228299976705', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-05-04T17:52:16.2840839' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'/:?')
GO
INSERT [dbo].[D_UserMessage_202105] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1389518246926880768', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-05-04T17:52:20.0000000' AS DateTime2), CAST(N'2021-05-04T17:52:20.7903461' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202105] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1389518246926880769', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-05-04T17:52:20.7256134' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'/::)')
GO
INSERT [dbo].[D_UserMessage_202105] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1389518263930589184', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-05-04T17:52:24.0000000' AS DateTime2), CAST(N'2021-05-04T17:52:24.8651679' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202105] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1389518263930589185', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-05-04T17:52:24.7790832' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'/:hug')
GO
INSERT [dbo].[D_UserMessage_202105] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1389518281106264064', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-05-04T17:52:28.0000000' AS DateTime2), CAST(N'2021-05-04T17:52:28.9926721' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202105] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1389518281106264065', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-05-04T17:52:28.8748108' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'/::Q')
GO
INSERT [dbo].[D_UserMessage_202105] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1389518300500725760', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-05-04T17:52:33.0000000' AS DateTime2), CAST(N'2021-05-04T17:52:33.5678204' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202105] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1389518300500725761', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-05-04T17:52:33.4987038' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'/:bye')
GO
INSERT [dbo].[D_UserMessage_202105] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1389518319769358336', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-05-04T17:52:38.0000000' AS DateTime2), CAST(N'2021-05-04T17:52:38.3494296' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202105] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1389518319769358337', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-05-04T17:52:38.0923421' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'/::T')
GO
INSERT [dbo].[D_UserMessage_202105] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1389518363138461696', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-05-04T17:52:48.0000000' AS DateTime2), CAST(N'2021-05-04T17:52:48.4896708' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202105] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1389518363138461697', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-05-04T17:52:48.4324542' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'/::<')
GO
INSERT [dbo].[D_UserMessage_202105] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1389518382834913280', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-05-04T17:52:53.0000000' AS DateTime2), CAST(N'2021-05-04T17:52:53.3149377' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202105] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1389518382834913281', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-05-04T17:52:53.1285417' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'/:8-)')
GO
INSERT [dbo].[D_UserMessage_202105] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1389568318888742912', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-05-04T21:11:18.0000000' AS DateTime2), CAST(N'2021-05-04T21:11:18.8899109' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你好')
GO
INSERT [dbo].[D_UserMessage_202105] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1389568318888742913', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-05-04T21:11:18.8111751' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'你好啊')
GO
INSERT [dbo].[D_UserMessage_202105] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1389568333723996160', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-05-04T21:11:22.0000000' AS DateTime2), CAST(N'2021-05-04T21:11:22.4151788' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202105] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1389568333723996161', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-05-04T21:11:22.3489378' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'测试')
GO
INSERT [dbo].[D_UserMessage_202105] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1389568354343194624', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-05-04T21:11:27.0000000' AS DateTime2), CAST(N'2021-05-04T21:11:27.3165022' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202105] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1389568354343194625', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-05-04T21:11:27.2645416' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'gogogo')
GO
INSERT [dbo].[D_UserMessage_202105] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1394912406441824256', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-05-19T15:06:48.5720000' AS DateTime2), CAST(N'2021-05-19T15:06:48.6240547' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202105] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1394912406441824257', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-05-19T15:06:48.5725996' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'fffe')
GO
INSERT [dbo].[D_UserMessage_202105] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1394912436103942144', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-05-19T15:06:55.6440000' AS DateTime2), CAST(N'2021-05-19T15:06:55.6942691' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202105] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1394912436103942145', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-05-19T15:06:55.6447313' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'rreeeeer')
GO
INSERT [dbo].[D_UserMessage_202105] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1394912497739239424', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-05-19T15:07:10.3390000' AS DateTime2), CAST(N'2021-05-20T01:39:45.3097631' AS DateTime2), N'Admin', N'Admin', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你好')
GO
INSERT [dbo].[D_UserMessage_202105] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1394912528873558016', 1, NULL, NULL, NULL, 0, 0, CAST(N'2021-05-19T15:07:17.7629516' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^1371083605962395648^', N'^alice^', N'在吗')
GO
INSERT [dbo].[D_UserMessage_202105] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1395285397101088768', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-05-20T15:48:56.0000000' AS DateTime2), CAST(N'2021-05-20T15:48:56.6279110' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202105] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1395285397101088769', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-05-20T15:48:56.4755789' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'erv er v 4')
GO
INSERT [dbo].[D_UserMessage_202106] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1402499862833926144', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-06-09T13:36:39.1440000' AS DateTime2), CAST(N'2021-06-09T13:36:39.2013843' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202106] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1402499862833926145', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-06-09T13:36:39.1442719' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'/::$')
GO
INSERT [dbo].[D_UserMessage_202106] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1402532386184368128', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-06-09T15:45:53.3150000' AS DateTime2), CAST(N'2021-06-14T00:11:18.1438306' AS DateTime2), N'Admin', N'Admin', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'')
GO
INSERT [dbo].[D_UserMessage_202106] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1402532387023228928', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-06-09T15:45:53.5150000' AS DateTime2), CAST(N'2021-06-14T00:11:18.1440490' AS DateTime2), N'Admin', N'Admin', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'')
GO
INSERT [dbo].[D_UserMessage_202106] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1402532401325805568', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-06-09T15:45:56.9250000' AS DateTime2), CAST(N'2021-06-14T00:11:18.1440910' AS DateTime2), N'Admin', N'Admin', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'lkjljljl')
GO
INSERT [dbo].[D_UserMessage_202106] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1402532428169351168', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-06-09T15:46:03.3250000' AS DateTime2), CAST(N'2021-06-09T15:46:03.4226572' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202106] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1402532428169351169', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-06-09T15:46:03.3257779' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'dsfsdfs')
GO
INSERT [dbo].[D_UserMessage_202106] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1405889272950558720', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-06-18T22:04:57.0000000' AS DateTime2), CAST(N'2021-06-18T22:04:57.6159659' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202106] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1405889272950558721', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-06-18T22:04:57.4882639' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'hi')
GO
INSERT [dbo].[D_UserMessage_202106] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1405889304416227328', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-06-18T22:05:04.0000000' AS DateTime2), CAST(N'2021-06-18T22:05:05.0976979' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202106] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1405889304416227329', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-06-18T22:05:04.9903152' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'hi')
GO
INSERT [dbo].[D_UserMessage_202106] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1405889319587024896', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-06-18T22:05:08.0000000' AS DateTime2), CAST(N'2021-06-18T22:05:08.7311256' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202106] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1405889319587024897', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-06-18T22:05:08.6074388' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'nih')
GO
INSERT [dbo].[D_UserMessage_202106] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1406084030289416192', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-06-19T10:58:51.0000000' AS DateTime2), CAST(N'2021-06-19T10:58:51.3562232' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202106] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1406084030289416193', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-06-19T10:58:51.2560433' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'111')
GO
INSERT [dbo].[D_UserMessage_202106] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1406084047167295488', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-06-19T10:58:55.2800000' AS DateTime2), CAST(N'2021-06-19T10:59:03.0741207' AS DateTime2), N'Admin', N'Admin', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'11')
GO
INSERT [dbo].[D_UserMessage_202106] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1406084062698803200', 1, NULL, NULL, NULL, 0, 0, CAST(N'2021-06-19T10:58:58.9837546' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^1385225937288695808^', N'^bob^', N'111')
GO
INSERT [dbo].[D_UserMessage_202106] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1406084071888523264', 1, NULL, NULL, NULL, 0, 0, CAST(N'2021-06-19T10:59:01.1748542' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^1371083605962395648^', N'^alice^', N'22')
GO
INSERT [dbo].[D_UserMessage_202106] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1406658802207428608', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-06-21T01:02:47.5600000' AS DateTime2), CAST(N'2021-06-21T01:02:53.4035859' AS DateTime2), N'Admin', N'Admin', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'111')
GO
INSERT [dbo].[D_UserMessage_202106] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1406658820293267456', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-06-21T01:02:51.0000000' AS DateTime2), CAST(N'2021-06-21T01:02:51.9447674' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202106] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1406658820293267457', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-06-21T01:02:51.8724535' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'11')
GO
INSERT [dbo].[D_UserMessage_202106] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1406658856485916672', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-06-21T01:03:00.0000000' AS DateTime2), CAST(N'2021-06-21T01:03:00.5509610' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202106] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1406658856485916673', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-06-21T01:03:00.5011304' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'11')
GO
INSERT [dbo].[D_UserMessage_202106] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1406916752113143808', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-06-21T18:07:47.6100000' AS DateTime2), CAST(N'2021-06-21T18:07:52.2846495' AS DateTime2), N'Admin', N'Admin', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'1111')
GO
INSERT [dbo].[D_UserMessage_202106] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1406916789744439296', 1, NULL, NULL, NULL, 0, 0, CAST(N'2021-06-21T18:07:56.5824615' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^1371083605962395648^', N'^alice^', N'1111')
GO
INSERT [dbo].[D_UserMessage_202106] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1409668034905247744', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-06-29T08:20:24.5440000' AS DateTime2), CAST(N'2021-06-29T08:20:24.6016633' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202106] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1409668034905247745', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-06-29T08:20:24.5442768' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'aaa')
GO
INSERT [dbo].[D_UserMessage_202106] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1409668074151350272', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-06-29T08:20:33.9010000' AS DateTime2), CAST(N'2021-06-29T08:20:33.9610722' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202106] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1409668074151350273', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-06-29T08:20:33.9011789' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'bbb')
GO
INSERT [dbo].[D_UserMessage_202106] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1409668118820687872', 1, NULL, NULL, NULL, 0, 0, CAST(N'2021-06-29T08:20:44.5515632' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^1371083605962395648^', N'^alice^', N'fasf')
GO
INSERT [dbo].[D_UserMessage_202106] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1409809230013140992', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-06-29T17:41:28.0810000' AS DateTime2), CAST(N'2021-06-29T17:50:29.2321165' AS DateTime2), N'Admin', N'Admin', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'111')
GO
INSERT [dbo].[D_UserMessage_202106] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1409809248237391872', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-06-29T17:41:32.4260000' AS DateTime2), CAST(N'2021-06-29T17:41:32.4671801' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202106] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1409809248237391873', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-06-29T17:41:32.4266234' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'12312】')
GO
INSERT [dbo].[D_UserMessage_202106] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1410107808304599040', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-06-30T13:27:54.0000000' AS DateTime2), CAST(N'2021-06-30T13:27:54.8004403' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202106] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1410107808304599041', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-06-30T13:27:54.6936552' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'1')
GO
INSERT [dbo].[D_UserMessage_202106] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1410107820694573056', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-06-30T13:27:57.0000000' AS DateTime2), CAST(N'2021-06-30T13:27:57.7126749' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202106] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1410107820694573057', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-06-30T13:27:57.6475345' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'前往')
GO
INSERT [dbo].[D_UserMessage_202106] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1410107831339716608', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-06-30T13:28:00.0000000' AS DateTime2), CAST(N'2021-06-30T13:28:00.2656156' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202106] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1410107831339716609', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-06-30T13:28:00.1852317' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'带我去')
GO
INSERT [dbo].[D_UserMessage_202106] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1410107886301876224', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-06-30T13:28:13.2890000' AS DateTime2), CAST(N'2021-07-01T21:26:16.5404014' AS DateTime2), N'Admin', N'Admin', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'1')
GO
INSERT [dbo].[D_UserMessage_202106] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1410107899228721152', 1, NULL, NULL, NULL, 0, 0, CAST(N'2021-06-30T13:28:16.3718063' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^1371083605962395648^', N'^alice^', N'12')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1410590602193539072', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-01T21:26:21.7260000' AS DateTime2), CAST(N'2021-07-01T21:59:47.2203685' AS DateTime2), N'Admin', N'Admin', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'1')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1411877806496813056', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-05T10:41:15.1480000' AS DateTime2), CAST(N'2021-07-05T10:41:15.2084927' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1411877806501007360', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-07-05T10:41:15.1480142' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'111')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1411877826545586176', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-05T10:41:19.9270000' AS DateTime2), CAST(N'2021-07-05T10:41:19.9868469' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1411877826545586177', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-07-05T10:41:19.9273829' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'222')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1411877841305341952', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-05T10:41:23.4460000' AS DateTime2), CAST(N'2021-07-05T10:41:23.5107451' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'我叫小美，编号9527,哈哈...')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1411877841305341953', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-07-05T10:41:23.4467256' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'名字')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1411877885060321280', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-05T10:41:33.8780000' AS DateTime2), CAST(N'2021-07-05T10:43:10.5101670' AS DateTime2), N'Admin', N'Admin', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'111')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1411883892553551872', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-05T11:05:26.1760000' AS DateTime2), CAST(N'2021-07-05T11:05:26.2942686' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1411883892553551873', 2, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-07-05T11:05:26.1760947' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'http://localhost:5000/Upload/caceca389d9540feb0084e4f384b9dc8/ZMbz.jpg')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1411898559229333504', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-05T12:03:42.9840000' AS DateTime2), CAST(N'2021-07-05T12:03:43.0283794' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1411898559229333505', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-07-05T12:03:42.9842374' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'33')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1411898615458172928', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-05T12:03:56.3900000' AS DateTime2), CAST(N'2021-07-05T12:03:56.4255135' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你好')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1411898615458172929', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-07-05T12:03:56.3905301' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'你好')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1411898632017285120', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-05T12:04:00.3380000' AS DateTime2), CAST(N'2021-07-05T12:04:00.3723860' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1411898632017285121', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-07-05T12:04:00.3384757' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'你是')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1413065166290948096', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-08T17:19:23.7820000' AS DateTime2), CAST(N'2021-07-08T17:19:23.8178956' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1413065166290948097', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-07-08T17:19:23.7828918' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'哈哈')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1413065196838064128', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-08T17:19:31.0650000' AS DateTime2), CAST(N'2021-07-08T17:23:01.3109775' AS DateTime2), N'Admin', N'Admin', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'哈哈')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1413140508305264640', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-08T22:18:46.7180000' AS DateTime2), CAST(N'2021-07-08T22:18:46.7865593' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1413140508305264641', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-07-08T22:18:46.7183597' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'/::(')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1413404457441431552', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-09T15:47:37.0960000' AS DateTime2), CAST(N'2021-07-10T10:15:01.6372075' AS DateTime2), N'Admin', N'Admin', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'凄凄切切')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1415188677331521536', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-14T13:57:28.2670000' AS DateTime2), CAST(N'2021-07-14T13:57:28.3124023' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1415188677331521537', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-07-14T13:57:28.2671343' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'1111')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1416576271172767744', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-18T09:51:16.4190000' AS DateTime2), CAST(N'2021-07-18T09:52:22.8347938' AS DateTime2), N'Admin', N'Admin', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'IUOUOO')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1416576322632683520', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-18T09:51:28.6880000' AS DateTime2), CAST(N'2021-07-18T09:51:28.7283298' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1416576322632683521', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-07-18T09:51:28.6882480' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'000')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1416576369810214912', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-18T09:51:39.9360000' AS DateTime2), CAST(N'2021-07-18T09:51:39.9964019' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1416576369810214913', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-07-18T09:51:39.9361139' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'/:,@@')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1416960059233013760', 1, N'^Admin^', N'1416960042992668672', N'wwwwwwwwwww', 0, 0, CAST(N'2021-07-19T11:16:18.6230000' AS DateTime2), CAST(N'2021-07-19T12:39:19.0700202' AS DateTime2), N'Admin', N'Admin', N'Admin', N'Admin', NULL, N'^1371083605962395648^1385225937288695808^1411234913281118208^Admin^Admin^', N'^alice^bob^addy^Admin^Admin^', N'111')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1416960074298953728', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-19T11:16:22.2150000' AS DateTime2), CAST(N'2021-07-19T11:16:22.2731152' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1416960074298953729', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-07-19T11:16:22.2151775' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'111')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1416960084327534592', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-19T11:16:24.6060000' AS DateTime2), CAST(N'2021-07-19T11:16:24.6617296' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1416960084327534593', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-07-19T11:16:24.6063290' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'1111')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1416980987908198400', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-19T12:39:28.4080000' AS DateTime2), CAST(N'2021-07-19T12:39:47.1346361' AS DateTime2), N'Admin', N'Admin', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'1')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1416981044061540352', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-19T12:39:41.7960000' AS DateTime2), CAST(N'2021-07-19T16:05:05.7002394' AS DateTime2), N'Admin', N'Admin', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'22')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1416981083395723264', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-19T12:39:51.1740000' AS DateTime2), CAST(N'2021-07-19T12:39:51.2349196' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1416981083395723265', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-07-19T12:39:51.1741045' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'2')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1416981099833200640', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-19T12:39:55.0930000' AS DateTime2), CAST(N'2021-07-19T12:39:55.1552791' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1416981099833200641', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-07-19T12:39:55.0935065' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'天气')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1417032767039868928', 1, NULL, NULL, NULL, 0, 0, CAST(N'2021-07-19T16:05:13.5159343' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^1371083605962395648^', N'^alice^', N'测')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1417032836052946944', 1, NULL, NULL, NULL, 0, 0, CAST(N'2021-07-19T16:05:29.9695401' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^1371083605962395648^', N'^alice^', N'/:,@@')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1417363312512864256', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-20T13:58:41.6970000' AS DateTime2), CAST(N'2021-07-20T13:58:41.7361652' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1417363312512864257', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-07-20T13:58:41.6977929' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'1')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1417363325733310464', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-20T13:58:44.8490000' AS DateTime2), CAST(N'2021-07-20T13:58:44.8926514' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1417363325733310465', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-07-20T13:58:44.8496136' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'2')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1417363332209315840', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-20T13:58:46.3930000' AS DateTime2), CAST(N'2021-07-20T13:58:46.4343384' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1417363332209315841', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-07-20T13:58:46.3935031' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'3')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1417396832304107520', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-20T16:11:53.4380000' AS DateTime2), CAST(N'2021-07-20T16:11:53.4847440' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1417396832304107521', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-07-20T16:11:53.4381156' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'3333')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1417396848578007040', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-20T16:11:57.3180000' AS DateTime2), CAST(N'2021-07-20T16:11:57.3658895' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1417396848578007041', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-07-20T16:11:57.3182064' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'0000')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1417396862641508352', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-20T16:12:00.6710000' AS DateTime2), CAST(N'2021-07-20T16:12:00.7205250' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1417396862641508353', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-07-20T16:12:00.6719878' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'nihao ')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1417396868706471936', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-20T16:12:02.1170000' AS DateTime2), CAST(N'2021-07-20T16:12:02.1634564' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1417396868706471937', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-07-20T16:12:02.1177709' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'hi')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1417396876428185600', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-20T16:12:03.9580000' AS DateTime2), CAST(N'2021-07-20T16:12:04.0078793' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你好')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1417396876428185601', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-07-20T16:12:03.9589969' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'你好')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1417396887463399424', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-20T16:12:06.5890000' AS DateTime2), CAST(N'2021-07-20T16:12:06.6366867' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1417396887463399425', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-07-20T16:12:06.5893786' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'滚')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1417396905083670528', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-20T16:12:10.7900000' AS DateTime2), CAST(N'2021-07-20T16:12:10.8398077' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1417396905083670529', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-07-20T16:12:10.7908763' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'你大爷')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1417396918870347776', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-20T16:12:14.0770000' AS DateTime2), CAST(N'2021-07-20T16:12:14.1252490' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1417396918870347777', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-07-20T16:12:14.0774431' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'你在干嘛')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1417396931218378752', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-20T16:12:17.0210000' AS DateTime2), CAST(N'2021-07-20T16:12:17.0698784' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你好')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1417396931218378753', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-07-20T16:12:17.0215563' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'你好')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1417396940752031744', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-20T16:12:19.2940000' AS DateTime2), CAST(N'2021-07-20T16:12:19.3413229' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1417396940752031745', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-07-20T16:12:19.2946129' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'走人')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1417757680306491392', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-21T16:05:46.3060000' AS DateTime2), CAST(N'2021-07-21T16:57:46.3412813' AS DateTime2), N'Admin', N'Admin', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'6666')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1417757758391848960', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-21T16:06:04.9230000' AS DateTime2), CAST(N'2021-07-21T16:06:04.9727357' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1417757758391848961', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-07-21T16:06:04.9236233' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'66666')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1417757818097766400', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-21T16:06:19.1580000' AS DateTime2), CAST(N'2021-07-21T16:06:19.2060992' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1417757818097766401', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-07-21T16:06:19.1583278' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'机器人')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1418216407165833216', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-22T22:28:35.3120000' AS DateTime2), CAST(N'2021-07-22T22:28:49.4272375' AS DateTime2), N'Admin', N'Admin', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'aaa')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1418216449259868160', 1, N'^Admin^', N'1416980889455300608', N'332233', 0, 0, CAST(N'2021-07-22T22:28:45.3480000' AS DateTime2), CAST(N'2021-07-22T22:28:55.3930914' AS DateTime2), N'Admin', N'Admin', N'Admin', N'Admin', NULL, N'^1416276184878026752^1385225937288695808^1371083605962395648^Admin^', N'^2131^bob^alice^Admin^', N'aa')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1418497499445858304', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-23T17:05:32.9340000' AS DateTime2), CAST(N'2021-07-23T17:05:48.0219733' AS DateTime2), N'Admin', N'Admin', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'123')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1418497512758579200', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-23T17:05:36.1080000' AS DateTime2), CAST(N'2021-07-24T13:49:12.5289462' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1418497512758579201', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-07-23T17:05:36.1088248' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'123')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1418589546630615040', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-23T23:11:18.6930000' AS DateTime2), CAST(N'2021-07-23T23:13:47.9542953' AS DateTime2), N'Admin', N'Admin', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'/:handclap')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1418810383031865344', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-24T13:48:50.1940000' AS DateTime2), CAST(N'2021-07-25T09:43:35.1602325' AS DateTime2), N'Admin', N'Admin', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'111')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1418810411918036992', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-24T13:48:57.0810000' AS DateTime2), CAST(N'2021-07-25T09:43:35.1604615' AS DateTime2), N'Admin', N'Admin', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'2222')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1418810461264023552', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-24T13:49:08.8460000' AS DateTime2), CAST(N'2021-07-25T09:43:35.1605048' AS DateTime2), N'Admin', N'Admin', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'333')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1418810486165606400', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-24T13:49:14.0000000' AS DateTime2), CAST(N'2021-07-24T13:49:14.8309669' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1418810486165606401', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-07-24T13:49:14.7835039' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'111')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1418810538527297536', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-24T13:49:27.0000000' AS DateTime2), CAST(N'2021-07-24T13:49:27.5019343' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1418810538527297537', 2, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-07-24T13:49:27.2676429' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'http://localhost:5000/Upload/40a1a40e02b14c81be9d7d2c951f35e5/809298-20210314215728859-1650551509.png')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1418810572392108032', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-24T13:49:35.0000000' AS DateTime2), CAST(N'2021-07-24T13:49:35.5847013' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1418810572392108033', 2, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-07-24T13:49:35.3419029' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'http://localhost:5000/Upload/9f7d6433a39b4a6ebf3d37bb789c2971/809298-20210314215728859-1650551509.png')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1419122342323294208', 1, NULL, NULL, NULL, 0, 0, CAST(N'2021-07-25T10:28:27.0850852' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^1371083605962395648^', N'^alice^', N'434')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1419122362086854656', 1, NULL, NULL, NULL, 0, 0, CAST(N'2021-07-25T10:28:31.7972653' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^1371083605962395648^', N'^alice^', N'遥')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1419468239812956160', 1, N'^Admin^', N'1416960042992668672', N'wwwwwwwwwww', 0, 0, CAST(N'2021-07-26T09:22:55.4730000' AS DateTime2), CAST(N'2021-07-26T09:24:06.9565948' AS DateTime2), N'Admin', N'Admin', N'Admin', N'Admin', NULL, N'^1371083605962395648^1385225937288695808^1411234913281118208^Admin^Admin^', N'^alice^bob^addy^Admin^Admin^', N'666888')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1419482488857694208', 1, N'^Admin^', N'1416959971798552576', N'111', 0, 0, CAST(N'2021-07-26T10:19:32.7100000' AS DateTime2), CAST(N'2021-07-26T10:19:50.2997798' AS DateTime2), N'Admin', N'Admin', N'Admin', N'Admin', NULL, N'^1371083605962395648^1385225937288695808^1411234913281118208^Admin^', N'^alice^bob^addy^Admin^', N'1')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1419482523817218048', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-26T10:19:41.0450000' AS DateTime2), CAST(N'2021-07-26T10:19:41.1265308' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1419482523821412352', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-07-26T10:19:41.0462428' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'2')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1419482546852335616', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-26T10:19:46.5370000' AS DateTime2), CAST(N'2021-07-26T10:19:46.5689593' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1419482546852335617', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-07-26T10:19:46.5376854' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'??/\')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1419560639029841920', 1, NULL, NULL, NULL, 0, 0, CAST(N'2021-07-26T15:30:05.1636234' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^1385225937288695808^', N'^bob^', N'111')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1419572287509630976', 1, NULL, NULL, NULL, 0, 0, CAST(N'2021-07-26T16:16:22.3779014' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^1371083605962395648^', N'^alice^', N'1')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1419677201120366592', 1, N'^Admin^', N'1416980889455300608', N'332233', 0, 0, CAST(N'2021-07-26T23:13:15.7310000' AS DateTime2), CAST(N'2021-07-27T08:31:03.4158945' AS DateTime2), N'Admin', N'Admin', N'Admin', N'Admin', NULL, N'^1416276184878026752^1385225937288695808^1371083605962395648^Admin^', N'^2131^bob^alice^Admin^', N'ffff')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1419821398393622528', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-27T08:46:15.0400000' AS DateTime2), CAST(N'2021-07-27T08:46:15.1274398' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1419821398393622529', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-07-27T08:46:15.0409820' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'dsfasf')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1419821416580124672', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-27T08:46:19.3760000' AS DateTime2), CAST(N'2021-07-27T08:46:27.5582089' AS DateTime2), N'Admin', N'Admin', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'asdfasdf')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1419821553536733184', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-27T08:46:52.0290000' AS DateTime2), CAST(N'2021-07-27T08:47:00.9980792' AS DateTime2), N'Admin', N'Admin', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'afasf')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1419821564282540032', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-27T08:46:54.5910000' AS DateTime2), CAST(N'2021-07-27T08:47:00.9983244' AS DateTime2), N'Admin', N'Admin', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'asfasf')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1419821567256301568', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-27T08:46:55.3000000' AS DateTime2), CAST(N'2021-07-27T08:47:00.9983857' AS DateTime2), N'Admin', N'Admin', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'asdfaa')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1419821569269567488', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-27T08:46:55.7800000' AS DateTime2), CAST(N'2021-07-27T08:47:00.9984327' AS DateTime2), N'Admin', N'Admin', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'sdfa')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1419821570855014400', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-27T08:46:56.1580000' AS DateTime2), CAST(N'2021-07-27T08:47:00.9984928' AS DateTime2), N'Admin', N'Admin', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'sdfadsf')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1419821573707141120', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-27T08:46:56.8390000' AS DateTime2), CAST(N'2021-07-27T08:47:00.9985378' AS DateTime2), N'Admin', N'Admin', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'asdfafa')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1419821575351308288', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-27T08:46:57.2300000' AS DateTime2), CAST(N'2021-07-27T08:47:00.9985804' AS DateTime2), N'Admin', N'Admin', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'sf')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1419821577217773568', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-27T08:46:57.6750000' AS DateTime2), CAST(N'2021-07-27T08:47:00.9986335' AS DateTime2), N'Admin', N'Admin', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'asfas')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1419821579772104704', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-27T08:46:58.2840000' AS DateTime2), CAST(N'2021-07-27T08:47:00.9986885' AS DateTime2), N'Admin', N'Admin', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'f')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1419821622398816256', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-27T08:47:08.4470000' AS DateTime2), CAST(N'2021-07-27T08:47:08.5021543' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1419821622398816257', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-07-27T08:47:08.4480054' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'afdas')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1419821634746847232', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-27T08:47:11.3910000' AS DateTime2), CAST(N'2021-07-27T08:47:11.4538622' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1419821634746847233', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-07-27T08:47:11.3915241' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'asdfasdf')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1419846123274637312', 1, N'^Admin^', N'1416980889455300608', N'332233', 0, 0, CAST(N'2021-07-27T10:24:29.9110000' AS DateTime2), CAST(N'2021-07-27T15:59:47.8897530' AS DateTime2), N'Admin', N'Admin', N'Admin', N'Admin', NULL, N'^1416276184878026752^1385225937288695808^1371083605962395648^Admin^', N'^2131^bob^alice^Admin^', N'123')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1419861334584987648', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-27T11:24:56.5700000' AS DateTime2), CAST(N'2021-07-27T11:24:56.6205919' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1419861334584987649', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-07-27T11:24:56.5700826' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'1231')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1419861335792947200', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-27T11:24:56.8580000' AS DateTime2), CAST(N'2021-07-27T11:24:56.9082777' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1419861335792947201', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-07-27T11:24:56.8583598' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1419861341828550656', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-27T11:24:58.2970000' AS DateTime2), CAST(N'2021-07-27T11:24:58.3408082' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1419861341828550657', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-07-27T11:24:58.2974300' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'12312')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1419861344173166592', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-27T11:24:58.8560000' AS DateTime2), CAST(N'2021-07-27T11:24:58.9026694' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1419861344173166593', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-07-27T11:24:58.8568679' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'1231')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1419861345192382464', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-27T11:24:59.0990000' AS DateTime2), CAST(N'2021-07-27T11:24:59.1486739' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1419861345192382465', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-07-27T11:24:59.0996961' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'31')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1419861346027048960', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-27T11:24:59.2980000' AS DateTime2), CAST(N'2021-07-27T11:24:59.3481858' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1419861346027048961', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-07-27T11:24:59.2988971' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'23')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1419861346782023680', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-27T11:24:59.4780000' AS DateTime2), CAST(N'2021-07-27T11:24:59.5249568' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1419861346782023681', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-07-27T11:24:59.4788891' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'12')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1419861347532804096', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-27T11:24:59.6570000' AS DateTime2), CAST(N'2021-07-27T11:24:59.7053507' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1419861347532804097', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-07-27T11:24:59.6577016' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'31')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1419861348279390208', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-27T11:24:59.8350000' AS DateTime2), CAST(N'2021-07-27T11:24:59.8805085' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1419861348279390209', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-07-27T11:24:59.8350552' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'23')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1419861349017587712', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-27T11:25:00.0110000' AS DateTime2), CAST(N'2021-07-27T11:25:00.0582563' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1419861349017587713', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-07-27T11:25:00.0112994' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'12')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1419861349806116864', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-27T11:25:00.1990000' AS DateTime2), CAST(N'2021-07-27T11:25:00.2447084' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1419861349806116865', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-07-27T11:25:00.1993385' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'3')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1419861350510759936', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-27T11:25:00.3670000' AS DateTime2), CAST(N'2021-07-27T11:25:00.4120799' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1419861350510759937', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-07-27T11:25:00.3675483' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'123')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1419861351311872000', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-27T11:25:00.5580000' AS DateTime2), CAST(N'2021-07-27T11:25:00.6013366' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1419861351311872001', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-07-27T11:25:00.5587970' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'1')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1419861352003932160', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-27T11:25:00.7230000' AS DateTime2), CAST(N'2021-07-27T11:25:00.7678775' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1419861352003932161', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-07-27T11:25:00.7234182' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'23')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1419861352737935360', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-27T11:25:00.8980000' AS DateTime2), CAST(N'2021-07-27T11:25:00.9469836' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1419861352737935361', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-07-27T11:25:00.8986586' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'12')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1419861353396441088', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-27T11:25:01.0550000' AS DateTime2), CAST(N'2021-07-27T11:25:01.1041701' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1419861353396441089', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-07-27T11:25:01.0551406' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'3')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1419861354126249984', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-27T11:25:01.2290000' AS DateTime2), CAST(N'2021-07-27T11:25:01.2744820' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1419861354126249985', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-07-27T11:25:01.2296876' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'123')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1419861354902196224', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-27T11:25:01.4140000' AS DateTime2), CAST(N'2021-07-27T11:25:01.4562883' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1419861354902196225', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-07-27T11:25:01.4146485' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'12')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1419861355623616512', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-27T11:25:01.5860000' AS DateTime2), CAST(N'2021-07-27T11:25:01.6340547' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1419861355623616513', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-07-27T11:25:01.5862262' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'3')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1419861356345036800', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-27T11:25:01.7580000' AS DateTime2), CAST(N'2021-07-27T11:25:01.8081765' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1419861356345036801', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-07-27T11:25:01.7589120' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'12')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1419861357137760256', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-27T11:25:01.9470000' AS DateTime2), CAST(N'2021-07-27T11:25:01.9924354' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1419861357137760257', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-07-27T11:25:01.9471139' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'3')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1419861362112204800', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-27T11:25:03.1330000' AS DateTime2), CAST(N'2021-07-27T11:25:03.1816077' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1419861362112204801', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-07-27T11:25:03.1332010' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'123')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1419915720753418240', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-27T15:01:03.0000000' AS DateTime2), CAST(N'2021-07-27T15:01:03.3124094' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1419915720753418241', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-07-27T15:01:03.2431336' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'000')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1419915797249134592', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-27T15:01:21.0000000' AS DateTime2), CAST(N'2021-07-27T15:01:21.6299966' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1419915797249134593', 2, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-07-27T15:01:21.4818808' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'http://121.36.12.76:5000/Upload/6473e61cd50e44d4bd6de13cf62546e9/Capture001.png')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1419931459392638976', 1, N'^Admin^', N'1416959971798552576', N'111', 0, 0, CAST(N'2021-07-27T16:03:35.6270000' AS DateTime2), CAST(N'2021-07-28T08:21:34.9251727' AS DateTime2), N'Admin', N'Admin', N'Admin', N'Admin', NULL, N'^1371083605962395648^1385225937288695808^1411234913281118208^Admin^', N'^alice^bob^addy^Admin^', N'123')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1420186109089943552', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-28T08:55:28.8460000' AS DateTime2), CAST(N'2021-07-28T08:55:28.9000191' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1420186109089943553', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-07-28T08:55:28.8461063' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'wwww')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1420255603070078976', 1, N'^Admin^', N'1416959971798552576', N'111', 0, 0, CAST(N'2021-07-28T13:31:37.5020000' AS DateTime2), CAST(N'2021-07-28T13:31:43.2065645' AS DateTime2), N'Admin', N'Admin', N'Admin', N'Admin', NULL, N'^1371083605962395648^1385225937288695808^1411234913281118208^Admin^', N'^alice^bob^addy^Admin^', N'22')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1420258270047637504', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-28T13:42:13.0000000' AS DateTime2), CAST(N'2021-07-28T13:42:13.4887342' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1420258270047637505', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-07-28T13:42:13.3592420' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'123')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1420258278901813248', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-28T13:42:15.0000000' AS DateTime2), CAST(N'2021-07-28T13:42:15.5319667' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1420258278901813249', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-07-28T13:42:15.4709890' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'213')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1420258291744772096', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-28T13:42:18.5320000' AS DateTime2), CAST(N'2021-07-28T14:01:42.5733835' AS DateTime2), N'Admin', N'Admin', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'213')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1420258317141282816', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-28T13:42:24.0000000' AS DateTime2), CAST(N'2021-07-28T13:42:24.6788545' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你才傻，你全家都傻！！！')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1420258317141282817', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-07-28T13:42:24.5878700' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'sb')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1420258343800279040', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-28T13:42:30.0000000' AS DateTime2), CAST(N'2021-07-28T13:42:31.0275374' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1420258343800279041', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-07-28T13:42:30.9432271' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'你牛逼')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1420258378139045888', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-28T13:42:39.0000000' AS DateTime2), CAST(N'2021-07-28T13:42:39.3377194' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1420258378139045889', 2, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-07-28T13:42:39.1307944' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'http://121.36.12.76:5000/Upload/d3836f93e9614553a84d7a6e13522571/test.jpg')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1420263721770422272', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-28T14:03:53.1510000' AS DateTime2), CAST(N'2021-07-28T14:13:48.4077246' AS DateTime2), N'Admin', N'Admin', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'66')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1420321248814043136', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-28T17:52:28.0000000' AS DateTime2), CAST(N'2021-07-28T17:52:28.8096065' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1420321248814043137', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-07-28T17:52:28.6678867' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'对方身上的')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1420321268552437760', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-28T17:52:33.0000000' AS DateTime2), CAST(N'2021-07-28T17:52:33.5161060' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1420321268552437761', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-07-28T17:52:33.3739028' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'撒打算')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1420321274520932352', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-28T17:52:34.0000000' AS DateTime2), CAST(N'2021-07-28T17:52:34.8642665' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1420321274520932353', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-07-28T17:52:34.7968915' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'sd')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1420321283152809984', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-28T17:52:36.0000000' AS DateTime2), CAST(N'2021-07-28T17:52:36.9216862' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1420321283152809985', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-07-28T17:52:36.8542021' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'？？')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1420321288584433664', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-28T17:52:38.0000000' AS DateTime2), CAST(N'2021-07-28T17:52:38.2169798' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1420321288584433665', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-07-28T17:52:38.1495276' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'？')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1420321292820680704', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-28T17:52:39.0000000' AS DateTime2), CAST(N'2021-07-28T17:52:39.2310923' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1420321292820680705', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-07-28T17:52:39.1599187' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'？？')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1420321317344776192', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-28T17:52:45.0060000' AS DateTime2), CAST(N'2021-07-28T17:53:16.6985160' AS DateTime2), N'Admin', N'Admin', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'真的消息称')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1420569515116204032', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-29T10:18:59.9660000' AS DateTime2), CAST(N'2021-07-29T10:19:00.0268855' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1420569515116204033', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-07-29T10:18:59.9666617' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'111')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1420581926317592576', 1, NULL, NULL, NULL, 0, 0, CAST(N'2021-07-29T11:08:19.0278002' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^1416276184878026752^', N'^2131^', N'awsfsad')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1420581946429280256', 1, NULL, NULL, NULL, 0, 0, CAST(N'2021-07-29T11:08:23.8220204' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^1416276184878026752^', N'^2131^', N'sadfasdf')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1420693235151409152', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-29T18:30:37.1210000' AS DateTime2), CAST(N'2021-07-29T18:30:37.1593497' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1420693235151409153', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-07-29T18:30:37.1211616' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'wrwerewr')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1420772924062699520', 1, N'^Admin^', N'1416980889455300608', N'332233', 0, 0, CAST(N'2021-07-29T23:47:16.4380000' AS DateTime2), CAST(N'2021-07-30T09:19:32.0418196' AS DateTime2), N'Admin', N'Admin', N'Admin', N'Admin', NULL, N'^1416276184878026752^1385225937288695808^1371083605962395648^Admin^', N'^2131^bob^alice^Admin^', N'ertrw')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1420912196505833472', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-30T09:00:41.5760000' AS DateTime2), CAST(N'2021-07-30T09:00:52.7947478' AS DateTime2), N'Admin', N'Admin', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'驱蚊器无')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1420912210602889216', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-30T09:00:44.0000000' AS DateTime2), CAST(N'2021-07-30T09:00:44.9752342' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1420912210602889217', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-07-30T09:00:44.9371870' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'12')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1420912238352404480', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-30T09:00:51.0000000' AS DateTime2), CAST(N'2021-07-30T09:00:51.6147688' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1420912238352404481', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-07-30T09:00:51.5538949' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'12121')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1420912275128061952', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-30T09:01:00.3210000' AS DateTime2), CAST(N'2021-07-30T09:07:44.0039565' AS DateTime2), N'Admin', N'Admin', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'1212')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1420912293582999552', 1, N'^Admin^', N'1416959971798552576', N'111', 0, 0, CAST(N'2021-07-30T09:01:04.7210000' AS DateTime2), CAST(N'2021-07-30T09:13:31.7941153' AS DateTime2), N'Admin', N'Admin', N'Admin', N'Admin', NULL, N'^1371083605962395648^1385225937288695808^1411234913281118208^Admin^', N'^alice^bob^addy^Admin^', N'1212')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1420912309991116800', 1, N'^Admin^', N'1416959971798552576', N'111', 0, 0, CAST(N'2021-07-30T09:01:08.6330000' AS DateTime2), CAST(N'2021-07-30T09:13:31.7943563' AS DateTime2), N'Admin', N'Admin', N'Admin', N'Admin', NULL, N'^1371083605962395648^1385225937288695808^1411234913281118208^Admin^', N'^alice^bob^addy^Admin^', N'/::B')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1420915459607236608', 1, N'^Admin^', N'1416959971798552576', N'111', 0, 0, CAST(N'2021-07-30T09:13:39.5600000' AS DateTime2), CAST(N'2021-07-30T09:19:34.4231473' AS DateTime2), N'Admin', N'Admin', N'Admin', N'Admin', NULL, N'^1371083605962395648^1385225937288695808^1411234913281118208^Admin^', N'^alice^bob^addy^Admin^', N'111')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1420921732973203456', 1, N'^Admin^', N'1416980889455300608', N'332233', 0, 0, CAST(N'2021-07-30T09:38:35.2470000' AS DateTime2), CAST(N'2021-07-30T09:54:02.3717633' AS DateTime2), N'Admin', N'Admin', N'Admin', N'Admin', NULL, N'^1416276184878026752^1385225937288695808^1371083605962395648^Admin^', N'^2131^bob^alice^Admin^', N'1')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1420921773595037696', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-30T09:38:44.9320000' AS DateTime2), CAST(N'2021-07-30T09:38:44.9972721' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1420921773595037697', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-07-30T09:38:44.9327569' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'12')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1420921798853136384', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-30T09:38:50.9540000' AS DateTime2), CAST(N'2021-07-30T09:38:50.9901582' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1420921798853136385', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-07-30T09:38:50.9542902' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'nih ')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1420921806654541824', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-30T09:38:52.8150000' AS DateTime2), CAST(N'2021-07-30T09:38:52.8268238' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1420921806658736128', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-07-30T09:38:52.8150181' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'dfg')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1420921817027055616', 1, N'^Admin^', NULL, NULL, 0, 0, CAST(N'2021-07-30T09:38:55.2870000' AS DateTime2), CAST(N'2021-07-30T09:38:55.3224337' AS DateTime2), N'smallAssistant', N'智能助手', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'你可以和我聊天哦')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1420921817027055617', 1, N'^smallAssistant^', NULL, NULL, 0, 0, CAST(N'2021-07-30T09:38:55.2876632' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL, N'^smallAssistant^', N'^智能助手^', N'sgfsdgdfg')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1420921837855969280', 1, N'^Admin^', N'1416959971798552576', N'111', 0, 0, CAST(N'2021-07-30T09:39:00.2530000' AS DateTime2), CAST(N'2021-07-30T09:54:01.4020736' AS DateTime2), N'Admin', N'Admin', N'Admin', N'Admin', NULL, N'^1371083605962395648^1385225937288695808^1411234913281118208^Admin^', N'^alice^bob^addy^Admin^', N'dsfh')
GO
INSERT [dbo].[D_UserMessage_202107] ([Id], [Type], [ReadingMarks], [GroupId], [GroupName], [Status], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'1420921862979850240', 1, N'^Admin^', N'1416960042992668672', N'wwwwwwwwwww', 0, 0, CAST(N'2021-07-30T09:39:06.2430000' AS DateTime2), CAST(N'2021-07-30T09:54:01.8963858' AS DateTime2), N'Admin', N'Admin', N'Admin', N'Admin', NULL, N'^1371083605962395648^1385225937288695808^1411234913281118208^Admin^Admin^', N'^alice^bob^addy^Admin^Admin^', N'fg')
GO
INSERT [dbo].[OA_DefForm] ([Id], [WorkflowJSON], [JSONId], [JSONVersion], [Type], [Name], [Text], [Sort], [Status], [Value], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1371083607946301440', N'{
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
}', N'1274618511506804736', 0, N'请假', N'请假流程', N'最简单的请假流程', 0, 1, NULL, 0, CAST(N'2021-03-14T20:59:40.2940000' AS DateTime2), CAST(N'2021-07-27T08:44:44.7054330' AS DateTime2), NULL, NULL, N'Admin', N'Admin', NULL)
GO
INSERT [dbo].[OA_DefForm] ([Id], [WorkflowJSON], [JSONId], [JSONVersion], [Type], [Name], [Text], [Sort], [Status], [Value], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1371083607950495744', N'{
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
}', N'1274620801831669760', 0, N'报销', N'报销审批-与签', N'所有审批人都要同意', 0, 1, NULL, 0, CAST(N'2021-03-14T20:59:40.2950704' AS DateTime2), CAST(N'2021-07-23T11:54:16.3266494' AS DateTime2), NULL, NULL, N'Admin', N'Admin', NULL)
GO
INSERT [dbo].[OA_DefForm] ([Id], [WorkflowJSON], [JSONId], [JSONVersion], [Type], [Name], [Text], [Sort], [Status], [Value], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1371083607954690048', N'{
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
}', N'1274621154383892480', 0, N'报销', N'报销审批-或签', N'只要有一个人审批就行', 0, 0, NULL, 0, CAST(N'2021-03-14T20:59:40.2954185' AS DateTime2), CAST(N'2021-07-29T17:17:27.9308673' AS DateTime2), NULL, NULL, N'Admin', N'Admin', NULL)
GO
INSERT [dbo].[OA_DefForm] ([Id], [WorkflowJSON], [JSONId], [JSONVersion], [Type], [Name], [Text], [Sort], [Status], [Value], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1371083607954690049', N'{
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
}', N'1274621654579810304', 0, N'顺序', N'部门领导审批', N'根据申请人所在部门自动查找生成审批人', 0, 1, NULL, 0, CAST(N'2021-03-14T20:59:40.2956754' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[OA_DefForm] ([Id], [WorkflowJSON], [JSONId], [JSONVersion], [Type], [Name], [Text], [Sort], [Status], [Value], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1371083607954690050', N'{
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
}', N'1274622508779180032', 0, N'报销', N'并行流程', N'两个分管部门同时进行审批', 0, 1, NULL, 0, CAST(N'2021-03-14T20:59:40.2959363' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[OA_DefForm] ([Id], [WorkflowJSON], [JSONId], [JSONVersion], [Type], [Name], [Text], [Sort], [Status], [Value], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1371083607954690051', N'{
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
}', N'1274623039325081600', 0, N'顺序', N'有创建权限的流程', N'只有管理员能创建的流程', 0, 1, N'^1371083605253558272^', 0, CAST(N'2021-03-14T20:59:40.2962895' AS DateTime2), CAST(N'2021-07-05T10:26:57.3830119' AS DateTime2), NULL, NULL, N'Admin', N'Admin', NULL)
GO
INSERT [dbo].[OA_DefForm] ([Id], [WorkflowJSON], [JSONId], [JSONVersion], [Type], [Name], [Text], [Sort], [Status], [Value], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1371083607958884352', N'{
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
}', N'1274623664695808000', 0, N'请假', N'请假流程-条件', N'根据请假天数是否需要分管领导审批', 0, 1, NULL, 0, CAST(N'2021-03-14T20:59:40.0000000' AS DateTime2), CAST(N'2021-07-25T21:27:04.3627986' AS DateTime2), NULL, NULL, N'Admin', N'Admin', NULL)
GO
INSERT [dbo].[OA_DefForm] ([Id], [WorkflowJSON], [JSONId], [JSONVersion], [Type], [Name], [Text], [Sort], [Status], [Value], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1418461048880500736', N'{"Id":"1418461048880500736","Version":0,"DataType":"Coldairarrow.Util.OAData, Coldairarrow.Util","FirstStart":true,"Steps":[{"Id":"node76","Label":"开始","StepType":"AIStudio.Service.WorkflowCore.OAStartStep, AIStudio.Service","PreStepId":null,"NextStepId":"node90","Status":0,"ActRules":{"UserIds":null,"UserNames":null,"RoleIds":null,"RoleNames":null,"ActType":null},"SelectNextStep":{}},{"Id":"node90","Label":"节点","StepType":"AIStudio.Service.WorkflowCore.OAMiddleStep, AIStudio.Service","PreStepId":null,"NextStepId":"node83","Status":0,"ActRules":{"UserIds":null,"UserNames":null,"RoleIds":["1371083604494389248"],"RoleNames":null,"ActType":null},"SelectNextStep":{}},{"Id":"node83","Label":"结束","StepType":"AIStudio.Service.WorkflowCore.OAEndStep, AIStudio.Service","PreStepId":null,"NextStepId":null,"Status":0,"ActRules":{"UserIds":null,"UserNames":null,"RoleIds":null,"RoleNames":null,"ActType":null},"SelectNextStep":{}}],"CurrentStepIds":[],"MyEvent":null,"Flag":0.0,"nodes":[{"id":"node76","name":"开始节点","backImage":null,"color":"#1890ff","image":"/assets/Shape.486da24a.svg","label":"开始","offsetX":80,"offsetY":20,"shape":"customNode","size":[170,34],"stateImage":"/assets/start.e502ed95.svg","type":"node","x":273.90625,"y":78.0,"inPoints":[[0.0,0.5]],"outPoints":[[1.0,0.5]],"isDoingStart":false,"isDoingEnd":false,"UserIds":null,"RoleIds":null,"ActType":null},{"id":"node83","name":"结束节点","backImage":null,"color":"#1890ff","image":"/assets/Shape.486da24a.svg","label":"结束","offsetX":74,"offsetY":19,"shape":"customNode","size":[170,34],"stateImage":"/assets/end.dfe4a5ab.svg","type":"node","x":275.90625,"y":378.0,"inPoints":[[0.0,0.5]],"outPoints":[[1.0,0.5]],"isDoingStart":false,"isDoingEnd":false,"UserIds":null,"RoleIds":null,"ActType":null},{"id":"node90","name":"中间节点","backImage":null,"color":"#1890ff","image":"/assets/Shape.486da24a.svg","label":"节点","offsetX":78,"offsetY":15,"shape":"customNode","size":[170,34],"stateImage":"/assets/jiahao.ecf71c51.svg","type":"node","x":270.90625,"y":212.0,"inPoints":[[0.0,0.5]],"outPoints":[[1.0,0.5]],"isDoingStart":false,"isDoingEnd":false,"UserIds":null,"RoleIds":["1371083604494389248"],"ActType":null}],"edges":[{"id":"edge100","end":{"x":0.0,"y":-17.0},"endPoint":{"x":271.29804104477614,"y":194.5},"start":{"x":0.0,"y":17.0},"startPoint":{"x":273.51445895522386,"y":95.5},"shape":"customEdge","source":"node76","sourceId":"node76","target":"node90","targetId":"node90","type":"edge","label":null,"textColor":null},{"id":"edge104","end":{"x":0.0,"y":-17.0},"endPoint":{"x":275.37914156626505,"y":360.5},"start":{"x":0.0,"y":17.0},"startPoint":{"x":271.43335843373495,"y":229.5},"shape":"customEdge","source":"node90","sourceId":"node90","target":"node83","targetId":"node83","type":"edge","label":null,"textColor":null}],"groups":[]}', N'1418461048880500736', 0, N'顺序', N'123', N'123', 0, 1, NULL, 0, CAST(N'2021-07-23T14:40:42.4426908' AS DateTime2), CAST(N'2021-07-25T21:27:08.1253310' AS DateTime2), N'Admin', N'Admin', N'Admin', N'Admin', NULL)
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
INSERT [dbo].[OA_DefType] ([Id], [Name], [Type], [Unit], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1371083607673671681', N'报销', N'分类', NULL, 0, CAST(N'2021-03-14T20:59:40.0000000' AS DateTime2), CAST(N'2021-07-28T10:55:43.3164267' AS DateTime2), NULL, NULL, N'Admin', N'Admin', NULL)
GO
INSERT [dbo].[OA_DefType] ([Id], [Name], [Type], [Unit], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1371083607673671682', N'顺序', N'分类', NULL, 0, CAST(N'2021-03-14T20:59:40.2288793' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[OA_DefType] ([Id], [Name], [Type], [Unit], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1371083607673671683', N'选择', N'分类', NULL, 0, CAST(N'2021-03-14T20:59:40.2288825' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[OA_DefType] ([Id], [Name], [Type], [Unit], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1371083607673671684', N'或签', N'分类', NULL, 0, CAST(N'2021-03-14T20:59:40.2288855' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[OA_DefType] ([Id], [Name], [Type], [Unit], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1371083607673671685', N'与签', N'分类', NULL, 0, CAST(N'2021-03-14T20:59:40.2288890' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[OA_DefType] ([Id], [Name], [Type], [Unit], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1371083607673671686', N'病假', N'请假', N'天数', 0, CAST(N'2021-03-14T20:59:40.2289106' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[OA_DefType] ([Id], [Name], [Type], [Unit], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1371083607673671687', N'事假', N'请假', N'天数', 0, CAST(N'2021-03-14T20:59:40.2289142' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[OA_DefType] ([Id], [Name], [Type], [Unit], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1371083607673671688', N'调休', N'请假', N'天数', 0, CAST(N'2021-03-14T20:59:40.2289171' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[OA_DefType] ([Id], [Name], [Type], [Unit], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1371083607673671689', N'年假', N'请假', N'天数', 0, CAST(N'2021-03-14T20:59:40.2289205' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[OA_DefType] ([Id], [Name], [Type], [Unit], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1371083607673671690', N'差旅费用', N'报销', N'费用(元)', 0, CAST(N'2021-03-14T20:59:40.2280000' AS DateTime2), CAST(N'2021-07-05T10:26:40.4200390' AS DateTime2), NULL, NULL, N'Admin', N'Admin', NULL)
GO
INSERT [dbo].[OA_DefType] ([Id], [Name], [Type], [Unit], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1371083607673671691', N'采购费用', N'报销', N'费用(元)', 0, CAST(N'2021-03-14T20:59:40.2289263' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[OA_DefType] ([Id], [Name], [Type], [Unit], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1371083607673671692', N'活动费用', N'报销', N'费用(元)', 0, CAST(N'2021-03-14T20:59:40.2289292' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[OA_DefType] ([Id], [Name], [Type], [Unit], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1371083607673671693', N'日常费用', N'报销', N'费用(元)', 0, CAST(N'2021-03-14T20:59:40.2289321' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[OA_DefType] ([Id], [Name], [Type], [Unit], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1411874902713044992', N'11', N'12313', N'11', 0, CAST(N'2021-07-05T10:29:42.8310286' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL)
GO
INSERT [dbo].[OA_DefType] ([Id], [Name], [Type], [Unit], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1411898781598748672', N'11', N'11', N'1', 0, CAST(N'2021-07-05T12:04:36.0015226' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL)
GO
INSERT [dbo].[OA_DefType] ([Id], [Name], [Type], [Unit], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1418422804889473024', N'e', N'w', NULL, 0, CAST(N'2021-07-23T12:08:44.3649586' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL)
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
INSERT [dbo].[OA_UserForm] ([Id], [DefFormId], [DefFormName], [DefFormJsonId], [DefFormJsonVersion], [Grade], [Flag], [Remarks], [Appendix], [ExtendJSON], [ApplicantUser], [ApplicantUserId], [ApplicantDepartment], [ApplicantDepartmentId], [ApplicantRole], [ApplicantRoleId], [UserRoleNames], [UserRoleIds], [AlreadyUserNames], [AlreadyUserIds], [Status], [Type], [SubType], [Unit], [ExpectedDate], [CurrentNode], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'5b32ca8d-ee12-4773-b348-54af04410863', N'1371083607958884352', N'请假流程-条件', N'1274623664695808000', 0, 0, 0, N'11', NULL, NULL, NULL, N'Admin', NULL, NULL, NULL, NULL, NULL, NULL, N'^Admin^Admin^Admin^', N'^Admin^Admin^Admin^', 100, N'请假', N'调休', N'天数', NULL, N'^人力归档^', 0, CAST(N'2021-03-19T11:39:03.1560410' AS DateTime2), CAST(N'2021-07-12T09:14:34.3200619' AS DateTime2), N'Admin', N'Admin', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'11')
GO
INSERT [dbo].[OA_UserForm] ([Id], [DefFormId], [DefFormName], [DefFormJsonId], [DefFormJsonVersion], [Grade], [Flag], [Remarks], [Appendix], [ExtendJSON], [ApplicantUser], [ApplicantUserId], [ApplicantDepartment], [ApplicantDepartmentId], [ApplicantRole], [ApplicantRoleId], [UserRoleNames], [UserRoleIds], [AlreadyUserNames], [AlreadyUserIds], [Status], [Type], [SubType], [Unit], [ExpectedDate], [CurrentNode], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'86938f57-5ea4-4af9-8ea7-022815f24ac8', N'1371083607946301440', N'请假流程', N'1274618511506804736', 0, 0, 1, NULL, NULL, NULL, NULL, N'Admin', NULL, NULL, NULL, NULL, NULL, NULL, N'^Admin^Admin^Admin^Admin^Admin^', N'^Admin^Admin^Admin^Admin^Admin^', 4, N'请假', N'调休', N'天数', NULL, N'^人力归档^', 0, CAST(N'2021-03-20T11:16:20.6918069' AS DateTime2), CAST(N'2021-07-10T09:32:34.5438635' AS DateTime2), N'Admin', N'Admin', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'有事请假')
GO
INSERT [dbo].[OA_UserForm] ([Id], [DefFormId], [DefFormName], [DefFormJsonId], [DefFormJsonVersion], [Grade], [Flag], [Remarks], [Appendix], [ExtendJSON], [ApplicantUser], [ApplicantUserId], [ApplicantDepartment], [ApplicantDepartmentId], [ApplicantRole], [ApplicantRoleId], [UserRoleNames], [UserRoleIds], [AlreadyUserNames], [AlreadyUserIds], [Status], [Type], [SubType], [Unit], [ExpectedDate], [CurrentNode], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'e7ad4db9-0f57-46fa-a397-7d8cc3229081', N'1371083607946301440', N'请假流程', N'1274618511506804736', 0, 0, 4, N'123123', N'', NULL, N'Admin', N'Admin', NULL, NULL, NULL, NULL, NULL, NULL, N'^Admin^Admin^Admin^', N'^Admin^Admin^Admin^', 100, N'请假', N'病假', N'天数', NULL, N'^人力归档^', 0, CAST(N'2021-07-12T14:57:08.6013561' AS DateTime2), CAST(N'2021-07-22T22:30:57.5324470' AS DateTime2), N'Admin', N'Admin', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'123123123')
GO
INSERT [dbo].[OA_UserForm] ([Id], [DefFormId], [DefFormName], [DefFormJsonId], [DefFormJsonVersion], [Grade], [Flag], [Remarks], [Appendix], [ExtendJSON], [ApplicantUser], [ApplicantUserId], [ApplicantDepartment], [ApplicantDepartmentId], [ApplicantRole], [ApplicantRoleId], [UserRoleNames], [UserRoleIds], [AlreadyUserNames], [AlreadyUserIds], [Status], [Type], [SubType], [Unit], [ExpectedDate], [CurrentNode], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'ea776dda-c4a4-4dc3-9a81-31ac4ef4f639', N'1371083607946301440', N'请假流程', N'1274618511506804736', 0, 0, 4, N'123123', N'', NULL, N'Admin', N'Admin', NULL, NULL, NULL, NULL, NULL, NULL, N'^Admin^', N'^Admin^', 4, N'请假', N'事假', N'天数', CAST(N'2021-07-14T22:02:50.0000000' AS DateTime2), N'^主管审批^', 0, CAST(N'2021-07-14T22:02:56.2974403' AS DateTime2), CAST(N'2021-07-19T11:05:49.4864904' AS DateTime2), N'Admin', N'Admin', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'12312')
GO
INSERT [dbo].[OA_UserForm] ([Id], [DefFormId], [DefFormName], [DefFormJsonId], [DefFormJsonVersion], [Grade], [Flag], [Remarks], [Appendix], [ExtendJSON], [ApplicantUser], [ApplicantUserId], [ApplicantDepartment], [ApplicantDepartmentId], [ApplicantRole], [ApplicantRoleId], [UserRoleNames], [UserRoleIds], [AlreadyUserNames], [AlreadyUserIds], [Status], [Type], [SubType], [Unit], [ExpectedDate], [CurrentNode], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId], [UserIds], [UserNames], [Text]) VALUES (N'fc3c5f3e-26c7-4603-8c19-b40a6ef103e5', N'1371083607946301440', N'请假流程', N'1274618511506804736', 0, 0, 1, N'1', N'', NULL, N'Admin', N'Admin', NULL, NULL, NULL, NULL, NULL, NULL, N'^Admin^', N'^Admin^', 100, N'请假', N'事假', N'天数', CAST(N'2021-07-14T09:16:00.0000000' AS DateTime2), N'^主管审批^', 0, CAST(N'2021-07-14T09:16:01.7816369' AS DateTime2), CAST(N'2021-07-19T13:24:00.1992243' AS DateTime2), N'Admin', N'Admin', N'Admin', N'Admin', NULL, N'^Admin^', N'^Admin^', N'1')
GO
INSERT [dbo].[OA_UserFormStep] ([Id], [UserFormId], [RoleIds], [RoleNames], [Remarks], [Status], [StepName], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1372754469078437888', N'5b32ca8d-ee12-4773-b348-54af04410863', NULL, N'发起人', N'发起了流程', 100, NULL, 0, CAST(N'2021-03-19T11:39:04.6303333' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL)
GO
INSERT [dbo].[OA_UserFormStep] ([Id], [UserFormId], [RoleIds], [RoleNames], [Remarks], [Status], [StepName], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1373111140464201728', N'86938f57-5ea4-4af9-8ea7-022815f24ac8', NULL, N'发起人', N'发起了流程', 100, NULL, 0, CAST(N'2021-03-20T11:16:21.7155667' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL)
GO
INSERT [dbo].[OA_UserFormStep] ([Id], [UserFormId], [RoleIds], [RoleNames], [Remarks], [Status], [StepName], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1381539861579698176', N'86938f57-5ea4-4af9-8ea7-022815f24ac8', N'', N'', N'123123', 2, NULL, 0, CAST(N'2021-04-12T17:29:05.4280203' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL)
GO
INSERT [dbo].[OA_UserFormStep] ([Id], [UserFormId], [RoleIds], [RoleNames], [Remarks], [Status], [StepName], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1395250835503452160', N'86938f57-5ea4-4af9-8ea7-022815f24ac8', N'', N'', N'fgfn 
驳回上一级失败，该节点不支持驳回上一级', 8, NULL, 0, CAST(N'2021-05-20T13:31:36.3490849' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL)
GO
INSERT [dbo].[OA_UserFormStep] ([Id], [UserFormId], [RoleIds], [RoleNames], [Remarks], [Status], [StepName], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1411874589981544448', N'5b32ca8d-ee12-4773-b348-54af04410863', N'', N'', N'13123', 100, NULL, 0, CAST(N'2021-07-05T10:28:28.2703343' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL)
GO
INSERT [dbo].[OA_UserFormStep] ([Id], [UserFormId], [RoleIds], [RoleNames], [Remarks], [Status], [StepName], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1413033609031323648', N'86938f57-5ea4-4af9-8ea7-022815f24ac8', N'', N'', N'n', 100, NULL, 0, CAST(N'2021-07-08T15:13:59.9459601' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL)
GO
INSERT [dbo].[OA_UserFormStep] ([Id], [UserFormId], [RoleIds], [RoleNames], [Remarks], [Status], [StepName], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1413033682494558208', N'86938f57-5ea4-4af9-8ea7-022815f24ac8', N'', N'', N'  ', 100, NULL, 0, CAST(N'2021-07-08T15:14:17.4608633' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL)
GO
INSERT [dbo].[OA_UserFormStep] ([Id], [UserFormId], [RoleIds], [RoleNames], [Remarks], [Status], [StepName], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1413060355562672128', N'86938f57-5ea4-4af9-8ea7-022815f24ac8', N'', N'', N'nn', 100, NULL, 0, CAST(N'2021-07-08T17:00:16.8155490' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL)
GO
INSERT [dbo].[OA_UserFormStep] ([Id], [UserFormId], [RoleIds], [RoleNames], [Remarks], [Status], [StepName], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1413672458547892224', N'86938f57-5ea4-4af9-8ea7-022815f24ac8', N'', N'', N'nn', 4, NULL, 0, CAST(N'2021-07-10T09:32:33.5396520' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL)
GO
INSERT [dbo].[OA_UserFormStep] ([Id], [UserFormId], [RoleIds], [RoleNames], [Remarks], [Status], [StepName], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1414392674978369536', N'5b32ca8d-ee12-4773-b348-54af04410863', N'', N'', N'饿起额前完成v从vv', 100, NULL, 0, CAST(N'2021-07-12T09:14:26.5170300' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL)
GO
INSERT [dbo].[OA_UserFormStep] ([Id], [UserFormId], [RoleIds], [RoleNames], [Remarks], [Status], [StepName], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1414392707572305920', N'5b32ca8d-ee12-4773-b348-54af04410863', N'', N'', N'而', 100, NULL, 0, CAST(N'2021-07-12T09:14:34.2882642' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL)
GO
INSERT [dbo].[OA_UserFormStep] ([Id], [UserFormId], [RoleIds], [RoleNames], [Remarks], [Status], [StepName], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1414478922959032320', N'e7ad4db9-0f57-46fa-a397-7d8cc3229081', NULL, N'发起人', N'发起了流程', 100, NULL, 0, CAST(N'2021-07-12T14:57:09.6389376' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL)
GO
INSERT [dbo].[OA_UserFormStep] ([Id], [UserFormId], [RoleIds], [RoleNames], [Remarks], [Status], [StepName], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1415117850397380608', N'fc3c5f3e-26c7-4603-8c19-b40a6ef103e5', NULL, N'发起人', N'发起了流程', 100, NULL, 0, CAST(N'2021-07-14T09:16:01.8110006' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL)
GO
INSERT [dbo].[OA_UserFormStep] ([Id], [UserFormId], [RoleIds], [RoleNames], [Remarks], [Status], [StepName], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1415123139045625856', N'e7ad4db9-0f57-46fa-a397-7d8cc3229081', N'', N'', N'1', 100, NULL, 0, CAST(N'2021-07-14T09:37:02.7224343' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL)
GO
INSERT [dbo].[OA_UserFormStep] ([Id], [UserFormId], [RoleIds], [RoleNames], [Remarks], [Status], [StepName], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1415310853443424256', N'ea776dda-c4a4-4dc3-9a81-31ac4ef4f639', NULL, N'发起人', N'发起了流程', 100, NULL, 0, CAST(N'2021-07-14T22:02:57.3229246' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL)
GO
INSERT [dbo].[OA_UserFormStep] ([Id], [UserFormId], [RoleIds], [RoleNames], [Remarks], [Status], [StepName], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1416957420395040768', N'ea776dda-c4a4-4dc3-9a81-31ac4ef4f639', N'', N'', N'1', 4, NULL, 0, CAST(N'2021-07-19T11:05:49.4758152' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL)
GO
INSERT [dbo].[OA_UserFormStep] ([Id], [UserFormId], [RoleIds], [RoleNames], [Remarks], [Status], [StepName], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1416992189992407040', N'fc3c5f3e-26c7-4603-8c19-b40a6ef103e5', N'', N'', N'同意', 100, NULL, 0, CAST(N'2021-07-19T13:23:59.1933713' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL)
GO
INSERT [dbo].[OA_UserFormStep] ([Id], [UserFormId], [RoleIds], [RoleNames], [Remarks], [Status], [StepName], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1418089937722413056', N'e7ad4db9-0f57-46fa-a397-7d8cc3229081', N'', N'', N'通过', 100, NULL, 0, CAST(N'2021-07-22T14:06:02.6477908' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL)
GO
INSERT [dbo].[OA_UserFormStep] ([Id], [UserFormId], [RoleIds], [RoleNames], [Remarks], [Status], [StepName], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1418217003612639232', N'e7ad4db9-0f57-46fa-a397-7d8cc3229081', N'', N'', N'aa', 100, NULL, 0, CAST(N'2021-07-22T22:30:57.5168903' AS DateTime2), NULL, N'Admin', N'Admin', NULL, NULL, NULL)
GO
INSERT [dbo].[Quartz_Task] ([Id], [TaskName], [GroupName], [Interval], [ApiUrl], [AuthKey], [AuthValue], [Describe], [RequestType], [LastRunTime], [Status], [ForbidOperate], [ForbidEdit], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1371083607283601408', N'SaveMessageJob', N'SystemJob', N'0/10 * * * * ?', N'SaveMessageJob', NULL, NULL, NULL, N'System', NULL, 0, 0, 1, 0, CAST(N'2021-03-14T20:59:40.1354432' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Quartz_Task] ([Id], [TaskName], [GroupName], [Interval], [ApiUrl], [AuthKey], [AuthValue], [Describe], [RequestType], [LastRunTime], [Status], [ForbidOperate], [ForbidEdit], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1371083607489122304', N'PushMessageJob', N'SystemJob', N'0/10 * * * * ?', N'PushMessageJob', NULL, NULL, NULL, N'System', NULL, 0, 0, 1, 0, CAST(N'2021-03-14T20:59:40.1841399' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Quartz_Task] ([Id], [TaskName], [GroupName], [Interval], [ApiUrl], [AuthKey], [AuthValue], [Describe], [RequestType], [LastRunTime], [Status], [ForbidOperate], [ForbidEdit], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1371083607518482432', N'GetLog', N'Test', N'0/10 * * * * ?', N'http://localhost:5000/Test/GetLogList', N'Authorization', N'Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VySWQiOiJBZG1pbiIsImV4cCI6MTYxMzQ1NTI0MX0.XbnD6R0Ozgp1xoI6BUrRjYaHwRYYAJ7OgU6gRO1sdbA', NULL, N'System', CAST(N'2021-07-26T22:11:52.0000000' AS DateTime2), 1, 0, 0, 0, CAST(N'2021-03-14T20:59:40.1918199' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Quartz_Task] ([Id], [TaskName], [GroupName], [Interval], [ApiUrl], [AuthKey], [AuthValue], [Describe], [RequestType], [LastRunTime], [Status], [ForbidOperate], [ForbidEdit], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1421455378759028736', N'ResetDataJob', N'SystemJob', N'0/10 * * * * ?', N'ResetDataJob', NULL, NULL, NULL, N'System', NULL, 0, 0, 1, 0, CAST(N'2021-07-31T20:59:06.3173940' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Quartz_Task] ([Id], [TaskName], [GroupName], [Interval], [ApiUrl], [AuthKey], [AuthValue], [Describe], [RequestType], [LastRunTime], [Status], [ForbidOperate], [ForbidEdit], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1421455379056824320', N'SaveMessageJob', N'SystemJob', N'0/10 * * * * ?', N'SaveMessageJob', NULL, NULL, NULL, N'System', NULL, 0, 0, 1, 0, CAST(N'2021-07-31T20:59:06.3886604' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Quartz_Task] ([Id], [TaskName], [GroupName], [Interval], [ApiUrl], [AuthKey], [AuthValue], [Describe], [RequestType], [LastRunTime], [Status], [ForbidOperate], [ForbidEdit], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1421455379195236352', N'PushMessageJob', N'SystemJob', N'0/10 * * * * ?', N'PushMessageJob', NULL, NULL, NULL, N'System', NULL, 0, 0, 1, 0, CAST(N'2021-07-31T20:59:06.4219365' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Quartz_Task] ([Id], [TaskName], [GroupName], [Interval], [ApiUrl], [AuthKey], [AuthValue], [Describe], [RequestType], [LastRunTime], [Status], [ForbidOperate], [ForbidEdit], [Deleted], [CreateTime], [ModifyTime], [CreatorId], [CreatorName], [ModifyId], [ModifyName], [TenantId]) VALUES (N'1421455379325259776', N'GetLog', N'Test', N'0/10 * * * * ?', N'http://localhost:5000/Test/GetLogList', N'Authorization', N'Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VySWQiOiJBZG1pbiIsImV4cCI6MTYxMzQ1NTI0MX0.XbnD6R0Ozgp1xoI6BUrRjYaHwRYYAJ7OgU6gRO1sdbA', NULL, N'System', NULL, 1, 0, 0, 0, CAST(N'2021-07-31T20:59:06.4525868' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [wfc].[Event] ON 
GO
INSERT [wfc].[Event] ([PersistenceId], [EventData], [EventId], [EventKey], [EventName], [EventTime], [IsProcessed]) VALUES (1, N'{"$type":"Coldairarrow.Util.MyEvent, Coldairarrow.Util","EventName":"MyEvent","EventKey":"86938f57-5ea4-4af9-8ea7-022815f24ac8node9","UserId":"Admin","UserName":"Admin","Status":2,"Remarks":"123123"}', N'68bb6f8e-0a69-4dcc-9b2e-f4bebdd15ea0', N'86938f57-5ea4-4af9-8ea7-022815f24ac8node9', N'MyEvent', CAST(N'2021-04-12T09:29:03.9919006' AS DateTime2), 1)
GO
INSERT [wfc].[Event] ([PersistenceId], [EventData], [EventId], [EventKey], [EventName], [EventTime], [IsProcessed]) VALUES (2, N'{"$type":"Coldairarrow.Util.MyEvent, Coldairarrow.Util","EventName":"MyEvent","EventKey":"86938f57-5ea4-4af9-8ea7-022815f24ac8node2","UserId":"Admin","UserName":"Admin","Status":2,"Remarks":"fgfn "}', N'7a008d5e-96c2-4689-b5df-ee6a0e132e8c', N'86938f57-5ea4-4af9-8ea7-022815f24ac8node2', N'MyEvent', CAST(N'2021-05-20T05:31:35.0332733' AS DateTime2), 1)
GO
INSERT [wfc].[Event] ([PersistenceId], [EventData], [EventId], [EventKey], [EventName], [EventTime], [IsProcessed]) VALUES (3, N'{"$type":"Coldairarrow.Util.MyEvent, Coldairarrow.Util","EventName":"MyEvent","EventKey":"5b32ca8d-ee12-4773-b348-54af04410863node9","UserId":"Admin","UserName":"Admin","Status":100,"Remarks":"13123"}', N'f115bd14-5c21-4c64-9f9b-97fa483d4214', N'5b32ca8d-ee12-4773-b348-54af04410863node9', N'MyEvent', CAST(N'2021-07-05T02:28:27.2457261' AS DateTime2), 1)
GO
INSERT [wfc].[Event] ([PersistenceId], [EventData], [EventId], [EventKey], [EventName], [EventTime], [IsProcessed]) VALUES (4, N'{"$type":"Coldairarrow.Util.MyEvent, Coldairarrow.Util","EventName":"MyEvent","EventKey":"86938f57-5ea4-4af9-8ea7-022815f24ac8node2","UserId":"Admin","UserName":"Admin","Status":100,"Remarks":"n"}', N'9b521bf6-0966-4a27-b5e5-3683e8b6502a', N'86938f57-5ea4-4af9-8ea7-022815f24ac8node2', N'MyEvent', CAST(N'2021-07-08T07:13:59.9271013' AS DateTime2), 1)
GO
INSERT [wfc].[Event] ([PersistenceId], [EventData], [EventId], [EventKey], [EventName], [EventTime], [IsProcessed]) VALUES (5, N'{"$type":"Coldairarrow.Util.MyEvent, Coldairarrow.Util","EventName":"MyEvent","EventKey":"86938f57-5ea4-4af9-8ea7-022815f24ac8node9","UserId":"Admin","UserName":"Admin","Status":100,"Remarks":"  "}', N'c0468de5-b223-4e21-865c-73e5ccf2c3e4', N'86938f57-5ea4-4af9-8ea7-022815f24ac8node9', N'MyEvent', CAST(N'2021-07-08T07:14:17.4439440' AS DateTime2), 1)
GO
INSERT [wfc].[Event] ([PersistenceId], [EventData], [EventId], [EventKey], [EventName], [EventTime], [IsProcessed]) VALUES (6, N'{"$type":"Coldairarrow.Util.MyEvent, Coldairarrow.Util","EventName":"MyEvent","EventKey":"86938f57-5ea4-4af9-8ea7-022815f24ac8node137","UserId":"Admin","UserName":"Admin","Status":100,"Remarks":"nn"}', N'67bb7de6-f14a-48e0-93f1-9961deb5ca0f', N'86938f57-5ea4-4af9-8ea7-022815f24ac8node137', N'MyEvent', CAST(N'2021-07-08T09:00:15.7834596' AS DateTime2), 1)
GO
INSERT [wfc].[Event] ([PersistenceId], [EventData], [EventId], [EventKey], [EventName], [EventTime], [IsProcessed]) VALUES (7, N'{"$type":"Coldairarrow.Util.MyEvent, Coldairarrow.Util","EventName":"MyEvent","EventKey":"86938f57-5ea4-4af9-8ea7-022815f24ac8node144","UserId":"Admin","UserName":"Admin","Status":4,"Remarks":"nn"}', N'38655c5a-e1db-4d13-83a4-6cf87e3a1f33', N'86938f57-5ea4-4af9-8ea7-022815f24ac8node144', N'MyEvent', CAST(N'2021-07-10T01:32:33.5199013' AS DateTime2), 1)
GO
INSERT [wfc].[Event] ([PersistenceId], [EventData], [EventId], [EventKey], [EventName], [EventTime], [IsProcessed]) VALUES (8, N'{"$type":"Coldairarrow.Util.MyEvent, Coldairarrow.Util","EventName":"MyEvent","EventKey":"5b32ca8d-ee12-4773-b348-54af04410863node137","UserId":"Admin","UserName":"Admin","Status":100,"Remarks":"饿起额前完成v从vv"}', N'fddad373-7f0f-4ac9-b17e-342f3ea07599', N'5b32ca8d-ee12-4773-b348-54af04410863node137', N'MyEvent', CAST(N'2021-07-12T01:14:26.5002792' AS DateTime2), 1)
GO
INSERT [wfc].[Event] ([PersistenceId], [EventData], [EventId], [EventKey], [EventName], [EventTime], [IsProcessed]) VALUES (9, N'{"$type":"Coldairarrow.Util.MyEvent, Coldairarrow.Util","EventName":"MyEvent","EventKey":"5b32ca8d-ee12-4773-b348-54af04410863node144","UserId":"Admin","UserName":"Admin","Status":100,"Remarks":"而"}', N'6cab5349-6331-4bd7-8e64-1badebcd8088', N'5b32ca8d-ee12-4773-b348-54af04410863node144', N'MyEvent', CAST(N'2021-07-12T01:14:34.2683128' AS DateTime2), 1)
GO
INSERT [wfc].[Event] ([PersistenceId], [EventData], [EventId], [EventKey], [EventName], [EventTime], [IsProcessed]) VALUES (10, N'{"$type":"Coldairarrow.Util.MyEvent, Coldairarrow.Util","EventName":"MyEvent","EventKey":"e7ad4db9-0f57-46fa-a397-7d8cc3229081node9","UserId":"Admin","UserName":"Admin","Status":100,"Remarks":"1"}', N'a29af104-66ec-4f46-9bd2-b7c49ae08b03', N'e7ad4db9-0f57-46fa-a397-7d8cc3229081node9', N'MyEvent', CAST(N'2021-07-14T01:37:02.7028124' AS DateTime2), 1)
GO
INSERT [wfc].[Event] ([PersistenceId], [EventData], [EventId], [EventKey], [EventName], [EventTime], [IsProcessed]) VALUES (11, N'{"$type":"Coldairarrow.Util.MyEvent, Coldairarrow.Util","EventName":"MyEvent","EventKey":"ea776dda-c4a4-4dc3-9a81-31ac4ef4f639node9","UserId":"Admin","UserName":"Admin","Status":4,"Remarks":"1"}', N'e6fd3b8b-568e-4621-b896-d4afcd77976d', N'ea776dda-c4a4-4dc3-9a81-31ac4ef4f639node9', N'MyEvent', CAST(N'2021-07-19T03:05:49.4575424' AS DateTime2), 1)
GO
INSERT [wfc].[Event] ([PersistenceId], [EventData], [EventId], [EventKey], [EventName], [EventTime], [IsProcessed]) VALUES (12, N'{"$type":"Coldairarrow.Util.MyEvent, Coldairarrow.Util","EventName":"MyEvent","EventKey":"fc3c5f3e-26c7-4603-8c19-b40a6ef103e5node9","UserId":"Admin","UserName":"Admin","Status":100,"Remarks":"同意"}', N'177093f7-e8a9-45e4-b44a-005fbc089737', N'fc3c5f3e-26c7-4603-8c19-b40a6ef103e5node9', N'MyEvent', CAST(N'2021-07-19T05:23:59.1680239' AS DateTime2), 1)
GO
INSERT [wfc].[Event] ([PersistenceId], [EventData], [EventId], [EventKey], [EventName], [EventTime], [IsProcessed]) VALUES (13, N'{"$type":"Coldairarrow.Util.MyEvent, Coldairarrow.Util","EventName":"MyEvent","EventKey":"e7ad4db9-0f57-46fa-a397-7d8cc3229081node137","UserId":"Admin","UserName":"Admin","Status":100,"Remarks":"通过"}', N'7488cc19-0258-4f90-980e-e69570502bbd', N'e7ad4db9-0f57-46fa-a397-7d8cc3229081node137', N'MyEvent', CAST(N'2021-07-22T06:06:02.6310805' AS DateTime2), 1)
GO
INSERT [wfc].[Event] ([PersistenceId], [EventData], [EventId], [EventKey], [EventName], [EventTime], [IsProcessed]) VALUES (14, N'{"$type":"Coldairarrow.Util.MyEvent, Coldairarrow.Util","EventName":"MyEvent","EventKey":"e7ad4db9-0f57-46fa-a397-7d8cc3229081node144","UserId":"Admin","UserName":"Admin","Status":100,"Remarks":"aa"}', N'da8369b5-b35c-4150-925f-702e41fc39d2', N'e7ad4db9-0f57-46fa-a397-7d8cc3229081node144', N'MyEvent', CAST(N'2021-07-22T14:30:57.4998078' AS DateTime2), 1)
GO
SET IDENTITY_INSERT [wfc].[Event] OFF
GO
SET IDENTITY_INSERT [wfc].[ExecutionPointer] ON 
GO
INSERT [wfc].[ExecutionPointer] ([PersistenceId], [Active], [RetryCount], [EndTime], [EventData], [EventKey], [EventName], [EventPublished], [Id], [PersistenceData], [SleepUntil], [StartTime], [StepId], [StepName], [WorkflowId], [Children], [ContextItem], [PredecessorId], [Outcome], [Scope], [Status]) VALUES (1, 0, 0, CAST(N'2021-03-19T03:39:05.6779487' AS DateTime2), N'null', NULL, NULL, 0, N'bbfdf875-3144-4f3d-bc2f-c78e6e234eeb', N'null', NULL, CAST(N'2021-03-19T03:39:05.6247716' AS DateTime2), 0, NULL, 1, N'', N'null', NULL, N'null', N'', 3)
GO
INSERT [wfc].[ExecutionPointer] ([PersistenceId], [Active], [RetryCount], [EndTime], [EventData], [EventKey], [EventName], [EventPublished], [Id], [PersistenceData], [SleepUntil], [StartTime], [StepId], [StepName], [WorkflowId], [Children], [ContextItem], [PredecessorId], [Outcome], [Scope], [Status]) VALUES (2, 0, 0, CAST(N'2021-07-05T02:28:28.3757348' AS DateTime2), N'{"$type":"Coldairarrow.Util.MyEvent, Coldairarrow.Util","EventName":"MyEvent","EventKey":"5b32ca8d-ee12-4773-b348-54af04410863node9","UserId":"Admin","UserName":"Admin","Status":100,"Remarks":"13123"}', N'5b32ca8d-ee12-4773-b348-54af04410863node9', N'MyEvent', 0, N'80ac8961-8ffe-4118-86f8-533335532b59', N'null', NULL, CAST(N'2021-03-19T03:39:05.7195990' AS DateTime2), 1, NULL, 1, N'', N'null', N'bbfdf875-3144-4f3d-bc2f-c78e6e234eeb', N'null', N'', 3)
GO
INSERT [wfc].[ExecutionPointer] ([PersistenceId], [Active], [RetryCount], [EndTime], [EventData], [EventKey], [EventName], [EventPublished], [Id], [PersistenceData], [SleepUntil], [StartTime], [StepId], [StepName], [WorkflowId], [Children], [ContextItem], [PredecessorId], [Outcome], [Scope], [Status]) VALUES (3, 0, 0, CAST(N'2021-03-20T03:16:22.7210513' AS DateTime2), N'null', NULL, NULL, 0, N'962a5c8b-068a-4622-931f-59cf30be7a10', N'null', NULL, CAST(N'2021-03-20T03:16:22.7193888' AS DateTime2), 0, NULL, 2, N'', N'null', NULL, N'null', N'', 3)
GO
INSERT [wfc].[ExecutionPointer] ([PersistenceId], [Active], [RetryCount], [EndTime], [EventData], [EventKey], [EventName], [EventPublished], [Id], [PersistenceData], [SleepUntil], [StartTime], [StepId], [StepName], [WorkflowId], [Children], [ContextItem], [PredecessorId], [Outcome], [Scope], [Status]) VALUES (4, 0, 0, CAST(N'2021-04-12T09:29:05.6326204' AS DateTime2), N'{"$type":"Coldairarrow.Util.MyEvent, Coldairarrow.Util","EventName":"MyEvent","EventKey":"86938f57-5ea4-4af9-8ea7-022815f24ac8node9","UserId":"Admin","UserName":"Admin","Status":2,"Remarks":"123123"}', N'86938f57-5ea4-4af9-8ea7-022815f24ac8node9', N'MyEvent', 0, N'32de4b29-2053-4bf4-aa9a-ad81c487f0c3', N'null', NULL, CAST(N'2021-03-20T03:16:22.7277572' AS DateTime2), 1, NULL, 2, N'', N'null', N'962a5c8b-068a-4622-931f-59cf30be7a10', N'null', N'', 3)
GO
INSERT [wfc].[ExecutionPointer] ([PersistenceId], [Active], [RetryCount], [EndTime], [EventData], [EventKey], [EventName], [EventPublished], [Id], [PersistenceData], [SleepUntil], [StartTime], [StepId], [StepName], [WorkflowId], [Children], [ContextItem], [PredecessorId], [Outcome], [Scope], [Status]) VALUES (5, 0, 0, CAST(N'2021-07-08T07:13:59.9740558' AS DateTime2), N'{"$type":"Coldairarrow.Util.MyEvent, Coldairarrow.Util","EventName":"MyEvent","EventKey":"86938f57-5ea4-4af9-8ea7-022815f24ac8node2","UserId":"Admin","UserName":"Admin","Status":100,"Remarks":"n"}', N'86938f57-5ea4-4af9-8ea7-022815f24ac8node2', N'MyEvent', 0, N'f3a1bea9-158a-442f-b088-af20bfac6c2e', N'null', NULL, CAST(N'2021-04-12T09:29:05.6500623' AS DateTime2), 0, NULL, 2, N'', N'null', N'32de4b29-2053-4bf4-aa9a-ad81c487f0c3', N'null', N'', 3)
GO
INSERT [wfc].[ExecutionPointer] ([PersistenceId], [Active], [RetryCount], [EndTime], [EventData], [EventKey], [EventName], [EventPublished], [Id], [PersistenceData], [SleepUntil], [StartTime], [StepId], [StepName], [WorkflowId], [Children], [ContextItem], [PredecessorId], [Outcome], [Scope], [Status]) VALUES (6, 0, 0, CAST(N'2021-07-12T01:14:26.5307345' AS DateTime2), N'{"$type":"Coldairarrow.Util.MyEvent, Coldairarrow.Util","EventName":"MyEvent","EventKey":"5b32ca8d-ee12-4773-b348-54af04410863node137","UserId":"Admin","UserName":"Admin","Status":100,"Remarks":"饿起额前完成v从vv"}', N'5b32ca8d-ee12-4773-b348-54af04410863node137', N'MyEvent', 0, N'1cf6b77c-8a96-4631-80cd-077650e94f13', N'null', NULL, CAST(N'2021-07-05T02:28:28.4179280' AS DateTime2), 2, NULL, 1, N'', N'null', N'80ac8961-8ffe-4118-86f8-533335532b59', N'null', N'', 3)
GO
INSERT [wfc].[ExecutionPointer] ([PersistenceId], [Active], [RetryCount], [EndTime], [EventData], [EventKey], [EventName], [EventPublished], [Id], [PersistenceData], [SleepUntil], [StartTime], [StepId], [StepName], [WorkflowId], [Children], [ContextItem], [PredecessorId], [Outcome], [Scope], [Status]) VALUES (7, 0, 0, CAST(N'2021-07-08T07:14:17.4735704' AS DateTime2), N'{"$type":"Coldairarrow.Util.MyEvent, Coldairarrow.Util","EventName":"MyEvent","EventKey":"86938f57-5ea4-4af9-8ea7-022815f24ac8node9","UserId":"Admin","UserName":"Admin","Status":100,"Remarks":"  "}', N'86938f57-5ea4-4af9-8ea7-022815f24ac8node9', N'MyEvent', 0, N'53ebb114-443b-4a14-9446-66912c788f2e', N'null', NULL, CAST(N'2021-07-08T07:13:59.9884182' AS DateTime2), 1, NULL, 2, N'', N'null', N'f3a1bea9-158a-442f-b088-af20bfac6c2e', N'null', N'', 3)
GO
INSERT [wfc].[ExecutionPointer] ([PersistenceId], [Active], [RetryCount], [EndTime], [EventData], [EventKey], [EventName], [EventPublished], [Id], [PersistenceData], [SleepUntil], [StartTime], [StepId], [StepName], [WorkflowId], [Children], [ContextItem], [PredecessorId], [Outcome], [Scope], [Status]) VALUES (8, 0, 0, CAST(N'2021-07-08T09:00:16.8297697' AS DateTime2), N'{"$type":"Coldairarrow.Util.MyEvent, Coldairarrow.Util","EventName":"MyEvent","EventKey":"86938f57-5ea4-4af9-8ea7-022815f24ac8node137","UserId":"Admin","UserName":"Admin","Status":100,"Remarks":"nn"}', N'86938f57-5ea4-4af9-8ea7-022815f24ac8node137', N'MyEvent', 0, N'065b04f7-efce-4298-97dd-a0989a6a21fb', N'null', NULL, CAST(N'2021-07-08T07:14:17.4825818' AS DateTime2), 2, NULL, 2, N'', N'null', N'53ebb114-443b-4a14-9446-66912c788f2e', N'null', N'', 3)
GO
INSERT [wfc].[ExecutionPointer] ([PersistenceId], [Active], [RetryCount], [EndTime], [EventData], [EventKey], [EventName], [EventPublished], [Id], [PersistenceData], [SleepUntil], [StartTime], [StepId], [StepName], [WorkflowId], [Children], [ContextItem], [PredecessorId], [Outcome], [Scope], [Status]) VALUES (9, 0, 0, CAST(N'2021-07-10T01:32:34.5460866' AS DateTime2), N'{"$type":"Coldairarrow.Util.MyEvent, Coldairarrow.Util","EventName":"MyEvent","EventKey":"86938f57-5ea4-4af9-8ea7-022815f24ac8node144","UserId":"Admin","UserName":"Admin","Status":4,"Remarks":"nn"}', N'86938f57-5ea4-4af9-8ea7-022815f24ac8node144', N'MyEvent', 0, N'0881ece7-69a1-46fe-881b-e2f530fd0615', N'null', NULL, CAST(N'2021-07-08T09:00:16.8383996' AS DateTime2), 3, NULL, 2, N'', N'null', N'065b04f7-efce-4298-97dd-a0989a6a21fb', N'null', N'', 3)
GO
INSERT [wfc].[ExecutionPointer] ([PersistenceId], [Active], [RetryCount], [EndTime], [EventData], [EventKey], [EventName], [EventPublished], [Id], [PersistenceData], [SleepUntil], [StartTime], [StepId], [StepName], [WorkflowId], [Children], [ContextItem], [PredecessorId], [Outcome], [Scope], [Status]) VALUES (10, 0, 0, CAST(N'2021-07-12T01:14:26.5425168' AS DateTime2), N'null', NULL, NULL, 0, N'5600df00-71dc-43b2-b3d5-0498d25cd82c', N'null', NULL, CAST(N'2021-07-12T01:14:26.5404359' AS DateTime2), 3, NULL, 1, N'', N'null', N'1cf6b77c-8a96-4631-80cd-077650e94f13', N'null', N'', 3)
GO
INSERT [wfc].[ExecutionPointer] ([PersistenceId], [Active], [RetryCount], [EndTime], [EventData], [EventKey], [EventName], [EventPublished], [Id], [PersistenceData], [SleepUntil], [StartTime], [StepId], [StepName], [WorkflowId], [Children], [ContextItem], [PredecessorId], [Outcome], [Scope], [Status]) VALUES (11, 0, 0, CAST(N'2021-07-12T01:14:34.3035025' AS DateTime2), N'{"$type":"Coldairarrow.Util.MyEvent, Coldairarrow.Util","EventName":"MyEvent","EventKey":"5b32ca8d-ee12-4773-b348-54af04410863node144","UserId":"Admin","UserName":"Admin","Status":100,"Remarks":"而"}', N'5b32ca8d-ee12-4773-b348-54af04410863node144', N'MyEvent', 0, N'a9b30d2a-8526-45a6-907f-8e41be4cd354', N'null', NULL, CAST(N'2021-07-12T01:14:26.5544902' AS DateTime2), 5, NULL, 1, N'', N'null', N'5600df00-71dc-43b2-b3d5-0498d25cd82c', N'null', N'', 3)
GO
INSERT [wfc].[ExecutionPointer] ([PersistenceId], [Active], [RetryCount], [EndTime], [EventData], [EventKey], [EventName], [EventPublished], [Id], [PersistenceData], [SleepUntil], [StartTime], [StepId], [StepName], [WorkflowId], [Children], [ContextItem], [PredecessorId], [Outcome], [Scope], [Status]) VALUES (12, 0, 0, CAST(N'2021-07-12T01:14:34.3218278' AS DateTime2), N'null', NULL, NULL, 0, N'987af0fc-1a78-468b-bab2-9347071dc7f7', N'null', NULL, CAST(N'2021-07-12T01:14:34.3160708' AS DateTime2), 6, NULL, 1, N'', N'null', N'a9b30d2a-8526-45a6-907f-8e41be4cd354', N'null', N'', 3)
GO
INSERT [wfc].[ExecutionPointer] ([PersistenceId], [Active], [RetryCount], [EndTime], [EventData], [EventKey], [EventName], [EventPublished], [Id], [PersistenceData], [SleepUntil], [StartTime], [StepId], [StepName], [WorkflowId], [Children], [ContextItem], [PredecessorId], [Outcome], [Scope], [Status]) VALUES (13, 0, 0, CAST(N'2021-07-12T06:57:10.6473477' AS DateTime2), N'null', NULL, NULL, 0, N'e14b96ff-b150-40e5-b319-0a6b71aec3e9', N'null', NULL, CAST(N'2021-07-12T06:57:10.6458955' AS DateTime2), 0, NULL, 3, N'', N'null', NULL, N'null', N'', 3)
GO
INSERT [wfc].[ExecutionPointer] ([PersistenceId], [Active], [RetryCount], [EndTime], [EventData], [EventKey], [EventName], [EventPublished], [Id], [PersistenceData], [SleepUntil], [StartTime], [StepId], [StepName], [WorkflowId], [Children], [ContextItem], [PredecessorId], [Outcome], [Scope], [Status]) VALUES (14, 0, 0, CAST(N'2021-07-14T01:37:02.7353405' AS DateTime2), N'{"$type":"Coldairarrow.Util.MyEvent, Coldairarrow.Util","EventName":"MyEvent","EventKey":"e7ad4db9-0f57-46fa-a397-7d8cc3229081node9","UserId":"Admin","UserName":"Admin","Status":100,"Remarks":"1"}', N'e7ad4db9-0f57-46fa-a397-7d8cc3229081node9', N'MyEvent', 0, N'a4034537-b775-4872-b3d9-eb70b71b8a14', N'null', NULL, CAST(N'2021-07-12T06:57:10.6558232' AS DateTime2), 1, NULL, 3, N'', N'null', N'e14b96ff-b150-40e5-b319-0a6b71aec3e9', N'null', N'', 3)
GO
INSERT [wfc].[ExecutionPointer] ([PersistenceId], [Active], [RetryCount], [EndTime], [EventData], [EventKey], [EventName], [EventPublished], [Id], [PersistenceData], [SleepUntil], [StartTime], [StepId], [StepName], [WorkflowId], [Children], [ContextItem], [PredecessorId], [Outcome], [Scope], [Status]) VALUES (15, 0, 0, CAST(N'2021-07-14T01:16:02.8179196' AS DateTime2), N'null', NULL, NULL, 0, N'937ce27c-154c-4819-aa97-5ea56f175709', N'null', NULL, CAST(N'2021-07-14T01:16:02.8164666' AS DateTime2), 0, NULL, 4, N'', N'null', NULL, N'null', N'', 3)
GO
INSERT [wfc].[ExecutionPointer] ([PersistenceId], [Active], [RetryCount], [EndTime], [EventData], [EventKey], [EventName], [EventPublished], [Id], [PersistenceData], [SleepUntil], [StartTime], [StepId], [StepName], [WorkflowId], [Children], [ContextItem], [PredecessorId], [Outcome], [Scope], [Status]) VALUES (16, 0, 0, CAST(N'2021-07-19T05:24:00.2011964' AS DateTime2), N'{"$type":"Coldairarrow.Util.MyEvent, Coldairarrow.Util","EventName":"MyEvent","EventKey":"fc3c5f3e-26c7-4603-8c19-b40a6ef103e5node9","UserId":"Admin","UserName":"Admin","Status":100,"Remarks":"同意"}', N'fc3c5f3e-26c7-4603-8c19-b40a6ef103e5node9', N'MyEvent', 0, N'eebcb9cd-a941-4460-892c-8cb9c926260d', N'null', NULL, CAST(N'2021-07-14T01:16:02.8247400' AS DateTime2), 1, NULL, 4, N'', N'null', N'937ce27c-154c-4819-aa97-5ea56f175709', N'null', N'', 3)
GO
INSERT [wfc].[ExecutionPointer] ([PersistenceId], [Active], [RetryCount], [EndTime], [EventData], [EventKey], [EventName], [EventPublished], [Id], [PersistenceData], [SleepUntil], [StartTime], [StepId], [StepName], [WorkflowId], [Children], [ContextItem], [PredecessorId], [Outcome], [Scope], [Status]) VALUES (17, 0, 0, CAST(N'2021-07-22T06:06:02.6639877' AS DateTime2), N'{"$type":"Coldairarrow.Util.MyEvent, Coldairarrow.Util","EventName":"MyEvent","EventKey":"e7ad4db9-0f57-46fa-a397-7d8cc3229081node137","UserId":"Admin","UserName":"Admin","Status":100,"Remarks":"通过"}', N'e7ad4db9-0f57-46fa-a397-7d8cc3229081node137', N'MyEvent', 0, N'443346c2-14a0-408e-8951-623bb92ed84e', N'null', NULL, CAST(N'2021-07-14T01:37:02.7428226' AS DateTime2), 2, NULL, 3, N'', N'null', N'a4034537-b775-4872-b3d9-eb70b71b8a14', N'null', N'', 3)
GO
INSERT [wfc].[ExecutionPointer] ([PersistenceId], [Active], [RetryCount], [EndTime], [EventData], [EventKey], [EventName], [EventPublished], [Id], [PersistenceData], [SleepUntil], [StartTime], [StepId], [StepName], [WorkflowId], [Children], [ContextItem], [PredecessorId], [Outcome], [Scope], [Status]) VALUES (18, 0, 0, CAST(N'2021-07-14T14:02:58.3375372' AS DateTime2), N'null', NULL, NULL, 0, N'845cefe1-aef3-4f4c-a48e-534a3c10f159', N'null', NULL, CAST(N'2021-07-14T14:02:58.3362317' AS DateTime2), 0, NULL, 5, N'', N'null', NULL, N'null', N'', 3)
GO
INSERT [wfc].[ExecutionPointer] ([PersistenceId], [Active], [RetryCount], [EndTime], [EventData], [EventKey], [EventName], [EventPublished], [Id], [PersistenceData], [SleepUntil], [StartTime], [StepId], [StepName], [WorkflowId], [Children], [ContextItem], [PredecessorId], [Outcome], [Scope], [Status]) VALUES (19, 0, 0, CAST(N'2021-07-19T03:05:49.4883883' AS DateTime2), N'{"$type":"Coldairarrow.Util.MyEvent, Coldairarrow.Util","EventName":"MyEvent","EventKey":"ea776dda-c4a4-4dc3-9a81-31ac4ef4f639node9","UserId":"Admin","UserName":"Admin","Status":4,"Remarks":"1"}', N'ea776dda-c4a4-4dc3-9a81-31ac4ef4f639node9', N'MyEvent', 0, N'521ee7af-769e-47a4-b0ee-e3b6cc9a3f00', N'null', NULL, CAST(N'2021-07-14T14:02:58.3941300' AS DateTime2), 1, NULL, 5, N'', N'null', N'845cefe1-aef3-4f4c-a48e-534a3c10f159', N'null', N'', 3)
GO
INSERT [wfc].[ExecutionPointer] ([PersistenceId], [Active], [RetryCount], [EndTime], [EventData], [EventKey], [EventName], [EventPublished], [Id], [PersistenceData], [SleepUntil], [StartTime], [StepId], [StepName], [WorkflowId], [Children], [ContextItem], [PredecessorId], [Outcome], [Scope], [Status]) VALUES (20, 0, 0, CAST(N'2021-07-22T14:30:57.5366120' AS DateTime2), N'{"$type":"Coldairarrow.Util.MyEvent, Coldairarrow.Util","EventName":"MyEvent","EventKey":"e7ad4db9-0f57-46fa-a397-7d8cc3229081node144","UserId":"Admin","UserName":"Admin","Status":100,"Remarks":"aa"}', N'e7ad4db9-0f57-46fa-a397-7d8cc3229081node144', N'MyEvent', 0, N'89b9fffe-5c29-4d48-9b97-a28240e16dfa', N'null', NULL, CAST(N'2021-07-22T06:06:02.6712501' AS DateTime2), 3, NULL, 3, N'', N'null', N'443346c2-14a0-408e-8951-623bb92ed84e', N'null', N'', 3)
GO
SET IDENTITY_INSERT [wfc].[ExecutionPointer] OFF
GO
SET IDENTITY_INSERT [wfc].[ExtensionAttribute] ON 
GO
INSERT [wfc].[ExtensionAttribute] ([PersistenceId], [AttributeKey], [AttributeValue], [ExecutionPointerId]) VALUES (1, N'ActionUser', N'"Admin"', 4)
GO
INSERT [wfc].[ExtensionAttribute] ([PersistenceId], [AttributeKey], [AttributeValue], [ExecutionPointerId]) VALUES (2, N'ActionUser', N'"Admin"', 2)
GO
INSERT [wfc].[ExtensionAttribute] ([PersistenceId], [AttributeKey], [AttributeValue], [ExecutionPointerId]) VALUES (3, N'ActionUser', N'"Admin"', 5)
GO
INSERT [wfc].[ExtensionAttribute] ([PersistenceId], [AttributeKey], [AttributeValue], [ExecutionPointerId]) VALUES (4, N'ActionUser', N'"Admin"', 7)
GO
INSERT [wfc].[ExtensionAttribute] ([PersistenceId], [AttributeKey], [AttributeValue], [ExecutionPointerId]) VALUES (5, N'ActionUser', N'"Admin"', 8)
GO
INSERT [wfc].[ExtensionAttribute] ([PersistenceId], [AttributeKey], [AttributeValue], [ExecutionPointerId]) VALUES (6, N'ActionUser', N'"Admin"', 9)
GO
INSERT [wfc].[ExtensionAttribute] ([PersistenceId], [AttributeKey], [AttributeValue], [ExecutionPointerId]) VALUES (7, N'ActionUser', N'"Admin"', 6)
GO
INSERT [wfc].[ExtensionAttribute] ([PersistenceId], [AttributeKey], [AttributeValue], [ExecutionPointerId]) VALUES (8, N'ActionUser', N'"Admin"', 11)
GO
INSERT [wfc].[ExtensionAttribute] ([PersistenceId], [AttributeKey], [AttributeValue], [ExecutionPointerId]) VALUES (9, N'ActionUser', N'"Admin"', 14)
GO
INSERT [wfc].[ExtensionAttribute] ([PersistenceId], [AttributeKey], [AttributeValue], [ExecutionPointerId]) VALUES (10, N'ActionUser', N'"Admin"', 19)
GO
INSERT [wfc].[ExtensionAttribute] ([PersistenceId], [AttributeKey], [AttributeValue], [ExecutionPointerId]) VALUES (11, N'ActionUser', N'"Admin"', 16)
GO
INSERT [wfc].[ExtensionAttribute] ([PersistenceId], [AttributeKey], [AttributeValue], [ExecutionPointerId]) VALUES (12, N'ActionUser', N'"Admin"', 17)
GO
INSERT [wfc].[ExtensionAttribute] ([PersistenceId], [AttributeKey], [AttributeValue], [ExecutionPointerId]) VALUES (13, N'ActionUser', N'"Admin"', 20)
GO
SET IDENTITY_INSERT [wfc].[ExtensionAttribute] OFF
GO
SET IDENTITY_INSERT [wfc].[Workflow] ON 
GO
INSERT [wfc].[Workflow] ([PersistenceId], [CompleteTime], [CreateTime], [Data], [Description], [InstanceId], [NextExecution], [Status], [Version], [WorkflowDefinitionId], [Reference]) VALUES (1, CAST(N'2021-07-12T01:14:34.3218572' AS DateTime2), CAST(N'2021-03-19T03:39:03.2425161' AS DateTime2), N'{"$type":"Coldairarrow.Util.OAData, Coldairarrow.Util","Id":"1274623664695808000","Version":0,"DataType":"Coldairarrow.Util.OAData, Coldairarrow.Util","FirstStart":false,"Steps":{"$type":"System.Collections.Generic.List`1[[Coldairarrow.Util.OAStep, Coldairarrow.Util]], System.Private.CoreLib","$values":[{"$type":"Coldairarrow.Util.OAStep, Coldairarrow.Util","Id":"node2","Label":"开始","StepType":"AIStudio.Service.WorkflowCore.OAStartStep, AIStudio.Service","PreStepId":null,"NextStepId":"node9","Status":100,"ActRules":{"$type":"Coldairarrow.Util.ActRule, Coldairarrow.Util","UserIds":{"$type":"System.Collections.Generic.List`1[[System.String, System.Private.CoreLib]], System.Private.CoreLib","$values":["Admin"]},"UserNames":{"$type":"System.Collections.Generic.List`1[[System.String, System.Private.CoreLib]], System.Private.CoreLib","$values":["Admin"]},"RoleIds":null,"RoleNames":null,"ActType":null},"SelectNextStep":{"$type":"System.Collections.Generic.Dictionary`2[[System.String, System.Private.CoreLib],[System.String, System.Private.CoreLib]], System.Private.CoreLib"}},{"$type":"Coldairarrow.Util.OAStep, Coldairarrow.Util","Id":"node9","Label":"主管审批","StepType":"AIStudio.Service.WorkflowCore.OAMiddleStep, AIStudio.Service","PreStepId":{"$type":"System.Collections.Generic.List`1[[System.String, System.Private.CoreLib]], System.Private.CoreLib","$values":["node2"]},"NextStepId":"node137","Status":100,"ActRules":{"$type":"Coldairarrow.Util.ActRule, Coldairarrow.Util","UserIds":{"$type":"System.Collections.Generic.List`1[[System.String, System.Private.CoreLib]], System.Private.CoreLib","$values":["Admin"]},"UserNames":{"$type":"System.Collections.Generic.List`1[[System.String, System.Private.CoreLib]], System.Private.CoreLib","$values":["Admin"]},"RoleIds":null,"RoleNames":null,"ActType":null},"SelectNextStep":{"$type":"System.Collections.Generic.Dictionary`2[[System.String, System.Private.CoreLib],[System.String, System.Private.CoreLib]], System.Private.CoreLib"}},{"$type":"Coldairarrow.Util.OAStep, Coldairarrow.Util","Id":"node137","Label":"人力审批","StepType":"AIStudio.Service.WorkflowCore.OAMiddleStep, AIStudio.Service","PreStepId":{"$type":"System.Collections.Generic.List`1[[System.String, System.Private.CoreLib]], System.Private.CoreLib","$values":["node9"]},"NextStepId":"node467","Status":100,"ActRules":{"$type":"Coldairarrow.Util.ActRule, Coldairarrow.Util","UserIds":{"$type":"System.Collections.Generic.List`1[[System.String, System.Private.CoreLib]], System.Private.CoreLib","$values":["Admin"]},"UserNames":{"$type":"System.Collections.Generic.List`1[[System.String, System.Private.CoreLib]], System.Private.CoreLib","$values":["Admin"]},"RoleIds":null,"RoleNames":null,"ActType":null},"SelectNextStep":{"$type":"System.Collections.Generic.Dictionary`2[[System.String, System.Private.CoreLib],[System.String, System.Private.CoreLib]], System.Private.CoreLib"}},{"$type":"Coldairarrow.Util.OAStep, Coldairarrow.Util","Id":"node467","Label":"条件","StepType":"AIStudio.Service.WorkflowCore.OADecideStep, AIStudio.Service","PreStepId":null,"NextStepId":null,"Status":100,"ActRules":{"$type":"Coldairarrow.Util.ActRule, Coldairarrow.Util","UserIds":null,"UserNames":null,"RoleIds":null,"RoleNames":null,"ActType":null},"SelectNextStep":{"$type":"System.Collections.Generic.Dictionary`2[[System.String, System.Private.CoreLib],[System.String, System.Private.CoreLib]], System.Private.CoreLib","node144":"data.Flag<=3","node479":"data.Flag>3"}},{"$type":"Coldairarrow.Util.OAStep, Coldairarrow.Util","Id":"node479","Label":"分管领导","StepType":"AIStudio.Service.WorkflowCore.OAMiddleStep, AIStudio.Service","PreStepId":{"$type":"System.Collections.Generic.List`1[[System.String, System.Private.CoreLib]], System.Private.CoreLib","$values":["node137"]},"NextStepId":"node144","Status":0,"ActRules":{"$type":"Coldairarrow.Util.ActRule, Coldairarrow.Util","UserIds":{"$type":"System.Collections.Generic.List`1[[System.String, System.Private.CoreLib]], System.Private.CoreLib","$values":["Admin"]},"UserNames":{"$type":"System.Collections.Generic.List`1[[System.String, System.Private.CoreLib]], System.Private.CoreLib","$values":["Admin"]},"RoleIds":null,"RoleNames":null,"ActType":null},"SelectNextStep":{"$type":"System.Collections.Generic.Dictionary`2[[System.String, System.Private.CoreLib],[System.String, System.Private.CoreLib]], System.Private.CoreLib"}},{"$type":"Coldairarrow.Util.OAStep, Coldairarrow.Util","Id":"node144","Label":"人力归档","StepType":"AIStudio.Service.WorkflowCore.OAMiddleStep, AIStudio.Service","PreStepId":{"$type":"System.Collections.Generic.List`1[[System.String, System.Private.CoreLib]], System.Private.CoreLib","$values":["node137","node479"]},"NextStepId":"node61","Status":100,"ActRules":{"$type":"Coldairarrow.Util.ActRule, Coldairarrow.Util","UserIds":{"$type":"System.Collections.Generic.List`1[[System.String, System.Private.CoreLib]], System.Private.CoreLib","$values":["Admin"]},"UserNames":{"$type":"System.Collections.Generic.List`1[[System.String, System.Private.CoreLib]], System.Private.CoreLib","$values":["Admin"]},"RoleIds":null,"RoleNames":null,"ActType":null},"SelectNextStep":{"$type":"System.Collections.Generic.Dictionary`2[[System.String, System.Private.CoreLib],[System.String, System.Private.CoreLib]], System.Private.CoreLib"}},{"$type":"Coldairarrow.Util.OAStep, Coldairarrow.Util","Id":"node61","Label":"结束","StepType":"AIStudio.Service.WorkflowCore.OAEndStep, AIStudio.Service","PreStepId":{"$type":"System.Collections.Generic.List`1[[System.String, System.Private.CoreLib]], System.Private.CoreLib","$values":["node144"]},"NextStepId":null,"Status":100,"ActRules":{"$type":"Coldairarrow.Util.ActRule, Coldairarrow.Util","UserIds":null,"UserNames":null,"RoleIds":null,"RoleNames":null,"ActType":null},"SelectNextStep":{"$type":"System.Collections.Generic.Dictionary`2[[System.String, System.Private.CoreLib],[System.String, System.Private.CoreLib]], System.Private.CoreLib"}}]},"CurrentStepIds":{"$type":"System.Collections.Generic.List`1[[Coldairarrow.Util.CurrentStepId, Coldairarrow.Util]], System.Private.CoreLib","$values":[]},"MyEvent":null,"Flag":0.0,"nodes":{"$type":"Coldairarrow.Util.nodes[], Coldairarrow.Util","$values":[{"$type":"Coldairarrow.Util.nodes, Coldairarrow.Util","id":"node2","name":"开始节点","backImage":null,"color":"LightGreen","image":"/assets/Shape.486da24a.svg","label":"开始","offsetX":85,"offsetY":26,"shape":"customNode","size":{"$type":"System.Int32[], System.Private.CoreLib","$values":[170,34]},"stateImage":"/assets/start.e502ed95.svg","type":"node","x":221.55001831054688,"y":84.0,"inPoints":{"$type":"System.Double[][], System.Private.CoreLib","$values":[{"$type":"System.Double[], System.Private.CoreLib","$values":[0.0,0.5]}]},"outPoints":{"$type":"System.Double[][], System.Private.CoreLib","$values":[{"$type":"System.Double[], System.Private.CoreLib","$values":[1.0,0.5]}]},"isDoingStart":false,"isDoingEnd":false,"UserIds":null,"RoleIds":null,"ActType":null},{"$type":"Coldairarrow.Util.nodes, Coldairarrow.Util","id":"node9","name":"中间节点","backImage":null,"color":"LightGreen","image":"/assets/Shape.486da24a.svg","label":"主管审批","offsetX":76,"offsetY":21,"shape":"customNode","size":{"$type":"System.Int32[], System.Private.CoreLib","$values":[170,34]},"stateImage":"/assets/ok.463ab0e4.svg","type":"node","x":220.55001831054688,"y":161.0,"inPoints":{"$type":"System.Double[][], System.Private.CoreLib","$values":[{"$type":"System.Double[], System.Private.CoreLib","$values":[0.0,0.5]}]},"outPoints":{"$type":"System.Double[][], System.Private.CoreLib","$values":[{"$type":"System.Double[], System.Private.CoreLib","$values":[1.0,0.5]}]},"isDoingStart":false,"isDoingEnd":false,"UserIds":{"$type":"System.Collections.Generic.List`1[[System.String, System.Private.CoreLib]], System.Private.CoreLib","$values":["Admin"]},"RoleIds":null,"ActType":null},{"$type":"Coldairarrow.Util.nodes, Coldairarrow.Util","id":"node61","name":"结束节点","backImage":null,"color":"LightGreen","image":"/assets/Shape.486da24a.svg","label":"结束","offsetX":81,"offsetY":25,"shape":"customNode","size":{"$type":"System.Int32[], System.Private.CoreLib","$values":[170,34]},"stateImage":"/assets/end.dfe4a5ab.svg","type":"node","x":213.55001831054688,"y":550.0,"inPoints":{"$type":"System.Double[][], System.Private.CoreLib","$values":[{"$type":"System.Double[], System.Private.CoreLib","$values":[0.0,0.5]}]},"outPoints":{"$type":"System.Double[][], System.Private.CoreLib","$values":[{"$type":"System.Double[], System.Private.CoreLib","$values":[1.0,0.5]}]},"isDoingStart":false,"isDoingEnd":false,"UserIds":null,"RoleIds":null,"ActType":null},{"$type":"Coldairarrow.Util.nodes, Coldairarrow.Util","id":"node137","name":"中间节点","backImage":null,"color":"LightGreen","image":"/assets/Shape.486da24a.svg","label":"人力审批","offsetX":116,"offsetY":20,"shape":"customNode","size":{"$type":"System.Int32[], System.Private.CoreLib","$values":[170,34]},"stateImage":"/assets/ok.463ab0e4.svg","type":"node","x":221.55001831054688,"y":243.0,"inPoints":{"$type":"System.Double[][], System.Private.CoreLib","$values":[{"$type":"System.Double[], System.Private.CoreLib","$values":[0.0,0.5]}]},"outPoints":{"$type":"System.Double[][], System.Private.CoreLib","$values":[{"$type":"System.Double[], System.Private.CoreLib","$values":[1.0,0.5]}]},"isDoingStart":false,"isDoingEnd":false,"UserIds":{"$type":"System.Collections.Generic.List`1[[System.String, System.Private.CoreLib]], System.Private.CoreLib","$values":["Admin"]},"RoleIds":null,"ActType":null},{"$type":"Coldairarrow.Util.nodes, Coldairarrow.Util","id":"node144","name":"中间节点","backImage":null,"color":"LightGreen","image":"/assets/Shape.486da24a.svg","label":"人力归档","offsetX":102,"offsetY":15,"shape":"customNode","size":{"$type":"System.Int32[], System.Private.CoreLib","$values":[170,34]},"stateImage":"/assets/ok.463ab0e4.svg","type":"node","x":214.55001831054688,"y":464.0,"inPoints":{"$type":"System.Double[][], System.Private.CoreLib","$values":[{"$type":"System.Double[], System.Private.CoreLib","$values":[0.0,0.5]}]},"outPoints":{"$type":"System.Double[][], System.Private.CoreLib","$values":[{"$type":"System.Double[], System.Private.CoreLib","$values":[1.0,0.5]}]},"isDoingStart":false,"isDoingEnd":false,"UserIds":{"$type":"System.Collections.Generic.List`1[[System.String, System.Private.CoreLib]], System.Private.CoreLib","$values":["Admin"]},"RoleIds":null,"ActType":null},{"$type":"Coldairarrow.Util.nodes, Coldairarrow.Util","id":"node467","name":"条件节点","backImage":null,"color":"LightGreen","image":"/assets/Shape.486da24a.svg","label":"条件","offsetX":84,"offsetY":22,"shape":"customNode","size":{"$type":"System.Int32[], System.Private.CoreLib","$values":[170,34]},"stateImage":"/assets/wenhao.71b31d27.svg","type":"node","x":221.55001831054688,"y":329.0,"inPoints":{"$type":"System.Double[][], System.Private.CoreLib","$values":[{"$type":"System.Double[], System.Private.CoreLib","$values":[0.0,0.5]}]},"outPoints":{"$type":"System.Double[][], System.Private.CoreLib","$values":[{"$type":"System.Double[], System.Private.CoreLib","$values":[1.0,0.4]},{"$type":"System.Double[], System.Private.CoreLib","$values":[1.0,0.6]}]},"isDoingStart":false,"isDoingEnd":false,"UserIds":null,"RoleIds":null,"ActType":null},{"$type":"Coldairarrow.Util.nodes, Coldairarrow.Util","id":"node479","name":"中间节点","backImage":null,"color":"#1890ff","image":"/assets/Shape.486da24a.svg","label":"分管领导","offsetX":104,"offsetY":24,"shape":"customNode","size":{"$type":"System.Int32[], System.Private.CoreLib","$values":[170,34]},"stateImage":"/assets/jiahao.ecf71c51.svg","type":"node","x":408.0752708357994,"y":396.07070707070704,"inPoints":{"$type":"System.Double[][], System.Private.CoreLib","$values":[{"$type":"System.Double[], System.Private.CoreLib","$values":[0.0,0.5]}]},"outPoints":{"$type":"System.Double[][], System.Private.CoreLib","$values":[{"$type":"System.Double[], System.Private.CoreLib","$values":[1.0,0.5]}]},"isDoingStart":false,"isDoingEnd":false,"UserIds":{"$type":"System.Collections.Generic.List`1[[System.String, System.Private.CoreLib]], System.Private.CoreLib","$values":["Admin"]},"RoleIds":null,"ActType":null}]},"edges":{"$type":"Coldairarrow.Util.edges[], Coldairarrow.Util","$values":[{"$type":"Coldairarrow.Util.edges, Coldairarrow.Util","id":"edge56","end":{"$type":"Coldairarrow.Util.point, Coldairarrow.Util","x":0.0,"y":-17.0},"endPoint":{"$type":"Coldairarrow.Util.point, Coldairarrow.Util","x":220.77729103781962,"y":143.5},"start":{"$type":"Coldairarrow.Util.point, Coldairarrow.Util","x":0.0,"y":17.0},"startPoint":{"$type":"Coldairarrow.Util.point, Coldairarrow.Util","x":221.32274558327413,"y":101.5},"shape":"customEdge","source":"node2","sourceId":"node2","target":"node9","targetId":"node9","type":"edge","label":null,"textColor":null},{"$type":"Coldairarrow.Util.edges, Coldairarrow.Util","id":"edge180","end":{"$type":"Coldairarrow.Util.point, Coldairarrow.Util","x":0.0,"y":-17.0},"endPoint":{"$type":"Coldairarrow.Util.point, Coldairarrow.Util","x":221.33660367640056,"y":225.5},"start":{"$type":"Coldairarrow.Util.point, Coldairarrow.Util","x":0.0,"y":17.0},"startPoint":{"$type":"Coldairarrow.Util.point, Coldairarrow.Util","x":220.7634329446932,"y":178.5},"shape":"customEdge","source":"node9","sourceId":"node9","target":"node137","targetId":"node137","type":"edge","label":null,"textColor":null},{"$type":"Coldairarrow.Util.edges, Coldairarrow.Util","id":"edge261","end":{"$type":"Coldairarrow.Util.point, Coldairarrow.Util","x":0.0,"y":-17.0},"endPoint":{"$type":"Coldairarrow.Util.point, Coldairarrow.Util","x":213.7535066826399,"y":532.5},"start":{"$type":"Coldairarrow.Util.point, Coldairarrow.Util","x":0.0,"y":17.0},"startPoint":{"$type":"Coldairarrow.Util.point, Coldairarrow.Util","x":214.34652993845384,"y":481.5},"shape":"customEdge","source":"node144","sourceId":"node144","target":"node61","targetId":"node61","type":"edge","label":null,"textColor":null},{"$type":"Coldairarrow.Util.edges, Coldairarrow.Util","id":"edge539","end":{"$type":"Coldairarrow.Util.point, Coldairarrow.Util","x":0.0,"y":-17.0},"endPoint":{"$type":"Coldairarrow.Util.point, Coldairarrow.Util","x":215.45742571795427,"y":446.5},"start":{"$type":"Coldairarrow.Util.point, Coldairarrow.Util","x":-17.0,"y":17.0},"startPoint":{"$type":"Coldairarrow.Util.point, Coldairarrow.Util","x":220.64261090313948,"y":346.5},"shape":"customEdge","source":"node467","sourceId":"node467","target":"node144","targetId":"node144","type":"edge","label":"<=3","textColor":"#3AB70D"},{"$type":"Coldairarrow.Util.edges, Coldairarrow.Util","id":"edge622","end":{"$type":"Coldairarrow.Util.point, Coldairarrow.Util","x":0.0,"y":-17.0},"endPoint":{"$type":"Coldairarrow.Util.point, Coldairarrow.Util","x":359.4073491490524,"y":378.57070707070704},"start":{"$type":"Coldairarrow.Util.point, Coldairarrow.Util","x":17.0,"y":17.0},"startPoint":{"$type":"Coldairarrow.Util.point, Coldairarrow.Util","x":270.2179399972939,"y":346.5},"shape":"customEdge","source":"node467","sourceId":"node467","target":"node479","targetId":"node479","type":"edge","label":">3","textColor":"#D61F1F"},{"$type":"Coldairarrow.Util.edges, Coldairarrow.Util","id":"edge735","end":{"$type":"Coldairarrow.Util.point, Coldairarrow.Util","x":0.0,"y":-17.0},"endPoint":{"$type":"Coldairarrow.Util.point, Coldairarrow.Util","x":264.4061521395431,"y":446.5},"start":{"$type":"Coldairarrow.Util.point, Coldairarrow.Util","x":0.0,"y":17.0},"startPoint":{"$type":"Coldairarrow.Util.point, Coldairarrow.Util","x":358.2191370068032,"y":413.57070707070704},"shape":"customEdge","source":"node479","sourceId":"node479","target":"node144","targetId":"node144","type":"edge","label":null,"textColor":null},{"$type":"Coldairarrow.Util.edges, Coldairarrow.Util","id":"edge770","end":{"$type":"Coldairarrow.Util.point, Coldairarrow.Util","x":0.0,"y":-17.0},"endPoint":{"$type":"Coldairarrow.Util.point, Coldairarrow.Util","x":221.55001831054688,"y":311.5},"start":{"$type":"Coldairarrow.Util.point, Coldairarrow.Util","x":0.0,"y":17.0},"startPoint":{"$type":"Coldairarrow.Util.point, Coldairarrow.Util","x":221.55001831054688,"y":260.5},"shape":"customEdge","source":"node137","sourceId":"node137","target":"node467","targetId":"node467","type":"edge","label":null,"textColor":null}]},"groups":{"$type":"Coldairarrow.Util.groups[], Coldairarrow.Util","$values":[]}}', NULL, N'5b32ca8d-ee12-4773-b348-54af04410863', NULL, 2, 0, N'1274623664695808000', NULL)
GO
INSERT [wfc].[Workflow] ([PersistenceId], [CompleteTime], [CreateTime], [Data], [Description], [InstanceId], [NextExecution], [Status], [Version], [WorkflowDefinitionId], [Reference]) VALUES (2, CAST(N'2021-07-10T01:32:34.5461215' AS DateTime2), CAST(N'2021-03-20T03:16:20.6947161' AS DateTime2), N'{"$type":"Coldairarrow.Util.OAData, Coldairarrow.Util","Id":"1274618511506804736","Version":0,"DataType":"Coldairarrow.Util.OAData, Coldairarrow.Util","FirstStart":false,"Steps":{"$type":"System.Collections.Generic.List`1[[Coldairarrow.Util.OAStep, Coldairarrow.Util]], System.Private.CoreLib","$values":[{"$type":"Coldairarrow.Util.OAStep, Coldairarrow.Util","Id":"node2","Label":"开始","StepType":"AIStudio.Service.WorkflowCore.OAStartStep, AIStudio.Service","PreStepId":null,"NextStepId":"node9","Status":100,"ActRules":{"$type":"Coldairarrow.Util.ActRule, Coldairarrow.Util","UserIds":{"$type":"System.Collections.Generic.List`1[[System.String, System.Private.CoreLib]], System.Private.CoreLib","$values":["Admin"]},"UserNames":{"$type":"System.Collections.Generic.List`1[[System.String, System.Private.CoreLib]], System.Private.CoreLib","$values":["Admin"]},"RoleIds":null,"RoleNames":null,"ActType":null},"SelectNextStep":{"$type":"System.Collections.Generic.Dictionary`2[[System.String, System.Private.CoreLib],[System.String, System.Private.CoreLib]], System.Private.CoreLib"}},{"$type":"Coldairarrow.Util.OAStep, Coldairarrow.Util","Id":"node9","Label":"主管审批","StepType":"AIStudio.Service.WorkflowCore.OAMiddleStep, AIStudio.Service","PreStepId":{"$type":"System.Collections.Generic.List`1[[System.String, System.Private.CoreLib]], System.Private.CoreLib","$values":["node2"]},"NextStepId":"node137","Status":100,"ActRules":{"$type":"Coldairarrow.Util.ActRule, Coldairarrow.Util","UserIds":{"$type":"System.Collections.Generic.List`1[[System.String, System.Private.CoreLib]], System.Private.CoreLib","$values":["Admin"]},"UserNames":{"$type":"System.Collections.Generic.List`1[[System.String, System.Private.CoreLib]], System.Private.CoreLib","$values":["Admin"]},"RoleIds":null,"RoleNames":null,"ActType":null},"SelectNextStep":{"$type":"System.Collections.Generic.Dictionary`2[[System.String, System.Private.CoreLib],[System.String, System.Private.CoreLib]], System.Private.CoreLib"}},{"$type":"Coldairarrow.Util.OAStep, Coldairarrow.Util","Id":"node137","Label":"人力审批","StepType":"AIStudio.Service.WorkflowCore.OAMiddleStep, AIStudio.Service","PreStepId":{"$type":"System.Collections.Generic.List`1[[System.String, System.Private.CoreLib]], System.Private.CoreLib","$values":["node9"]},"NextStepId":"node144","Status":100,"ActRules":{"$type":"Coldairarrow.Util.ActRule, Coldairarrow.Util","UserIds":{"$type":"System.Collections.Generic.List`1[[System.String, System.Private.CoreLib]], System.Private.CoreLib","$values":["Admin"]},"UserNames":{"$type":"System.Collections.Generic.List`1[[System.String, System.Private.CoreLib]], System.Private.CoreLib","$values":["Admin"]},"RoleIds":null,"RoleNames":null,"ActType":null},"SelectNextStep":{"$type":"System.Collections.Generic.Dictionary`2[[System.String, System.Private.CoreLib],[System.String, System.Private.CoreLib]], System.Private.CoreLib"}},{"$type":"Coldairarrow.Util.OAStep, Coldairarrow.Util","Id":"node144","Label":"人力归档","StepType":"AIStudio.Service.WorkflowCore.OAMiddleStep, AIStudio.Service","PreStepId":{"$type":"System.Collections.Generic.List`1[[System.String, System.Private.CoreLib]], System.Private.CoreLib","$values":["node137"]},"NextStepId":"node61","Status":4,"ActRules":{"$type":"Coldairarrow.Util.ActRule, Coldairarrow.Util","UserIds":{"$type":"System.Collections.Generic.List`1[[System.String, System.Private.CoreLib]], System.Private.CoreLib","$values":["Admin"]},"UserNames":{"$type":"System.Collections.Generic.List`1[[System.String, System.Private.CoreLib]], System.Private.CoreLib","$values":["Admin"]},"RoleIds":null,"RoleNames":null,"ActType":null},"SelectNextStep":{"$type":"System.Collections.Generic.Dictionary`2[[System.String, System.Private.CoreLib],[System.String, System.Private.CoreLib]], System.Private.CoreLib"}},{"$type":"Coldairarrow.Util.OAStep, Coldairarrow.Util","Id":"node61","Label":"结束","StepType":"AIStudio.Service.WorkflowCore.OAEndStep, AIStudio.Service","PreStepId":{"$type":"System.Collections.Generic.List`1[[System.String, System.Private.CoreLib]], System.Private.CoreLib","$values":["node144"]},"NextStepId":null,"Status":0,"ActRules":{"$type":"Coldairarrow.Util.ActRule, Coldairarrow.Util","UserIds":null,"UserNames":null,"RoleIds":null,"RoleNames":null,"ActType":null},"SelectNextStep":{"$type":"System.Collections.Generic.Dictionary`2[[System.String, System.Private.CoreLib],[System.String, System.Private.CoreLib]], System.Private.CoreLib"}}]},"CurrentStepIds":{"$type":"System.Collections.Generic.List`1[[Coldairarrow.Util.CurrentStepId, Coldairarrow.Util]], System.Private.CoreLib","$values":[]},"MyEvent":null,"Flag":1.0,"nodes":{"$type":"Coldairarrow.Util.nodes[], Coldairarrow.Util","$values":[{"$type":"Coldairarrow.Util.nodes, Coldairarrow.Util","id":"node2","name":"开始节点","backImage":null,"color":"LightGreen","image":"/assets/Shape.486da24a.svg","label":"开始","offsetX":85,"offsetY":26,"shape":"customNode","size":{"$type":"System.Int32[], System.Private.CoreLib","$values":[170,34]},"stateImage":"/assets/ok.463ab0e4.svg","type":"node","x":221.55001831054688,"y":84.0,"inPoints":{"$type":"System.Double[][], System.Private.CoreLib","$values":[{"$type":"System.Double[], System.Private.CoreLib","$values":[0.0,0.5]}]},"outPoints":{"$type":"System.Double[][], System.Private.CoreLib","$values":[{"$type":"System.Double[], System.Private.CoreLib","$values":[1.0,0.5]}]},"isDoingStart":false,"isDoingEnd":false,"UserIds":null,"RoleIds":null,"ActType":null},{"$type":"Coldairarrow.Util.nodes, Coldairarrow.Util","id":"node9","name":"中间节点","backImage":null,"color":"LightGreen","image":"/assets/Shape.486da24a.svg","label":"主管审批","offsetX":76,"offsetY":21,"shape":"customNode","size":{"$type":"System.Int32[], System.Private.CoreLib","$values":[170,34]},"stateImage":"/assets/ok.463ab0e4.svg","type":"node","x":220.55001831054688,"y":161.0,"inPoints":{"$type":"System.Double[][], System.Private.CoreLib","$values":[{"$type":"System.Double[], System.Private.CoreLib","$values":[0.0,0.5]}]},"outPoints":{"$type":"System.Double[][], System.Private.CoreLib","$values":[{"$type":"System.Double[], System.Private.CoreLib","$values":[1.0,0.5]}]},"isDoingStart":false,"isDoingEnd":false,"UserIds":{"$type":"System.Collections.Generic.List`1[[System.String, System.Private.CoreLib]], System.Private.CoreLib","$values":["Admin"]},"RoleIds":null,"ActType":null},{"$type":"Coldairarrow.Util.nodes, Coldairarrow.Util","id":"node61","name":"结束节点","backImage":null,"color":"#1890ff","image":"/assets/Shape.486da24a.svg","label":"结束","offsetX":81,"offsetY":25,"shape":"customNode","size":{"$type":"System.Int32[], System.Private.CoreLib","$values":[170,34]},"stateImage":"/assets/end.dfe4a5ab.svg","type":"node","x":218.55001831054688,"y":408.0,"inPoints":{"$type":"System.Double[][], System.Private.CoreLib","$values":[{"$type":"System.Double[], System.Private.CoreLib","$values":[0.0,0.5]}]},"outPoints":{"$type":"System.Double[][], System.Private.CoreLib","$values":[{"$type":"System.Double[], System.Private.CoreLib","$values":[1.0,0.5]}]},"isDoingStart":false,"isDoingEnd":false,"UserIds":null,"RoleIds":null,"ActType":null},{"$type":"Coldairarrow.Util.nodes, Coldairarrow.Util","id":"node137","name":"中间节点","backImage":null,"color":"LightGreen","image":"/assets/Shape.486da24a.svg","label":"人力审批","offsetX":116,"offsetY":20,"shape":"customNode","size":{"$type":"System.Int32[], System.Private.CoreLib","$values":[170,34]},"stateImage":"/assets/ok.463ab0e4.svg","type":"node","x":221.55001831054688,"y":243.0,"inPoints":{"$type":"System.Double[][], System.Private.CoreLib","$values":[{"$type":"System.Double[], System.Private.CoreLib","$values":[0.0,0.5]}]},"outPoints":{"$type":"System.Double[][], System.Private.CoreLib","$values":[{"$type":"System.Double[], System.Private.CoreLib","$values":[1.0,0.5]}]},"isDoingStart":false,"isDoingEnd":false,"UserIds":{"$type":"System.Collections.Generic.List`1[[System.String, System.Private.CoreLib]], System.Private.CoreLib","$values":["Admin"]},"RoleIds":null,"ActType":null},{"$type":"Coldairarrow.Util.nodes, Coldairarrow.Util","id":"node144","name":"中间节点","backImage":null,"color":"Red","image":"/assets/Shape.486da24a.svg","label":"人力归档","offsetX":102,"offsetY":15,"shape":"customNode","size":{"$type":"System.Int32[], System.Private.CoreLib","$values":[170,34]},"stateImage":"/assets/no.0ca40fee.svg","type":"node","x":220.55001831054688,"y":323.0,"inPoints":{"$type":"System.Double[][], System.Private.CoreLib","$values":[{"$type":"System.Double[], System.Private.CoreLib","$values":[0.0,0.5]}]},"outPoints":{"$type":"System.Double[][], System.Private.CoreLib","$values":[{"$type":"System.Double[], System.Private.CoreLib","$values":[1.0,0.5]}]},"isDoingStart":false,"isDoingEnd":false,"UserIds":{"$type":"System.Collections.Generic.List`1[[System.String, System.Private.CoreLib]], System.Private.CoreLib","$values":["Admin"]},"RoleIds":null,"ActType":null}]},"edges":{"$type":"Coldairarrow.Util.edges[], Coldairarrow.Util","$values":[{"$type":"Coldairarrow.Util.edges, Coldairarrow.Util","id":"edge56","end":{"$type":"Coldairarrow.Util.point, Coldairarrow.Util","x":0.0,"y":-17.0},"endPoint":{"$type":"Coldairarrow.Util.point, Coldairarrow.Util","x":220.77729103781962,"y":143.5},"start":{"$type":"Coldairarrow.Util.point, Coldairarrow.Util","x":0.0,"y":17.0},"startPoint":{"$type":"Coldairarrow.Util.point, Coldairarrow.Util","x":221.32274558327413,"y":101.5},"shape":"customEdge","source":"node2","sourceId":"node2","target":"node9","targetId":"node9","type":"edge","label":null,"textColor":null},{"$type":"Coldairarrow.Util.edges, Coldairarrow.Util","id":"edge180","end":{"$type":"Coldairarrow.Util.point, Coldairarrow.Util","x":0.0,"y":-17.0},"endPoint":{"$type":"Coldairarrow.Util.point, Coldairarrow.Util","x":221.33660367640056,"y":225.5},"start":{"$type":"Coldairarrow.Util.point, Coldairarrow.Util","x":0.0,"y":17.0},"startPoint":{"$type":"Coldairarrow.Util.point, Coldairarrow.Util","x":220.7634329446932,"y":178.5},"shape":"customEdge","source":"node9","sourceId":"node9","target":"node137","targetId":"node137","type":"edge","label":null,"textColor":null},{"$type":"Coldairarrow.Util.edges, Coldairarrow.Util","id":"edge219","end":{"$type":"Coldairarrow.Util.point, Coldairarrow.Util","x":0.0,"y":-17.0},"endPoint":{"$type":"Coldairarrow.Util.point, Coldairarrow.Util","x":220.76876831054688,"y":305.5},"start":{"$type":"Coldairarrow.Util.point, Coldairarrow.Util","x":0.0,"y":17.0},"startPoint":{"$type":"Coldairarrow.Util.point, Coldairarrow.Util","x":221.33126831054688,"y":260.5},"shape":"customEdge","source":"node137","sourceId":"node137","target":"node144","targetId":"node144","type":"edge","label":null,"textColor":null},{"$type":"Coldairarrow.Util.edges, Coldairarrow.Util","id":"edge261","end":{"$type":"Coldairarrow.Util.point, Coldairarrow.Util","x":0.0,"y":-17.0},"endPoint":{"$type":"Coldairarrow.Util.point, Coldairarrow.Util","x":218.96178301642922,"y":390.5},"start":{"$type":"Coldairarrow.Util.point, Coldairarrow.Util","x":0.0,"y":17.0},"startPoint":{"$type":"Coldairarrow.Util.point, Coldairarrow.Util","x":220.13825360466453,"y":340.5},"shape":"customEdge","source":"node144","sourceId":"node144","target":"node61","targetId":"node61","type":"edge","label":null,"textColor":null}]},"groups":{"$type":"Coldairarrow.Util.groups[], Coldairarrow.Util","$values":[]}}', NULL, N'86938f57-5ea4-4af9-8ea7-022815f24ac8', NULL, 2, 0, N'1274618511506804736', NULL)
GO
INSERT [wfc].[Workflow] ([PersistenceId], [CompleteTime], [CreateTime], [Data], [Description], [InstanceId], [NextExecution], [Status], [Version], [WorkflowDefinitionId], [Reference]) VALUES (3, CAST(N'2021-07-22T14:30:57.5366344' AS DateTime2), CAST(N'2021-07-12T06:57:08.6079674' AS DateTime2), N'{"$type":"Coldairarrow.Util.OAData, Coldairarrow.Util","Id":"1274618511506804736","Version":0,"DataType":"Coldairarrow.Util.OAData, Coldairarrow.Util","FirstStart":false,"Steps":{"$type":"System.Collections.Generic.List`1[[Coldairarrow.Util.OAStep, Coldairarrow.Util]], System.Private.CoreLib","$values":[{"$type":"Coldairarrow.Util.OAStep, Coldairarrow.Util","Id":"node2","Label":"开始","StepType":"AIStudio.Service.WorkflowCore.OAStartStep, AIStudio.Service","PreStepId":null,"NextStepId":"node9","Status":100,"ActRules":{"$type":"Coldairarrow.Util.ActRule, Coldairarrow.Util","UserIds":{"$type":"System.Collections.Generic.List`1[[System.String, System.Private.CoreLib]], System.Private.CoreLib","$values":["Admin"]},"UserNames":{"$type":"System.Collections.Generic.List`1[[System.String, System.Private.CoreLib]], System.Private.CoreLib","$values":["Admin"]},"RoleIds":null,"RoleNames":null,"ActType":null},"SelectNextStep":{"$type":"System.Collections.Generic.Dictionary`2[[System.String, System.Private.CoreLib],[System.String, System.Private.CoreLib]], System.Private.CoreLib"}},{"$type":"Coldairarrow.Util.OAStep, Coldairarrow.Util","Id":"node9","Label":"主管审批","StepType":"AIStudio.Service.WorkflowCore.OAMiddleStep, AIStudio.Service","PreStepId":{"$type":"System.Collections.Generic.List`1[[System.String, System.Private.CoreLib]], System.Private.CoreLib","$values":["node2"]},"NextStepId":"node137","Status":100,"ActRules":{"$type":"Coldairarrow.Util.ActRule, Coldairarrow.Util","UserIds":{"$type":"System.Collections.Generic.List`1[[System.String, System.Private.CoreLib]], System.Private.CoreLib","$values":["Admin"]},"UserNames":{"$type":"System.Collections.Generic.List`1[[System.String, System.Private.CoreLib]], System.Private.CoreLib","$values":["Admin"]},"RoleIds":null,"RoleNames":null,"ActType":null},"SelectNextStep":{"$type":"System.Collections.Generic.Dictionary`2[[System.String, System.Private.CoreLib],[System.String, System.Private.CoreLib]], System.Private.CoreLib"}},{"$type":"Coldairarrow.Util.OAStep, Coldairarrow.Util","Id":"node137","Label":"人力审批","StepType":"AIStudio.Service.WorkflowCore.OAMiddleStep, AIStudio.Service","PreStepId":{"$type":"System.Collections.Generic.List`1[[System.String, System.Private.CoreLib]], System.Private.CoreLib","$values":["node9"]},"NextStepId":"node144","Status":100,"ActRules":{"$type":"Coldairarrow.Util.ActRule, Coldairarrow.Util","UserIds":{"$type":"System.Collections.Generic.List`1[[System.String, System.Private.CoreLib]], System.Private.CoreLib","$values":["Admin"]},"UserNames":{"$type":"System.Collections.Generic.List`1[[System.String, System.Private.CoreLib]], System.Private.CoreLib","$values":["Admin"]},"RoleIds":null,"RoleNames":null,"ActType":null},"SelectNextStep":{"$type":"System.Collections.Generic.Dictionary`2[[System.String, System.Private.CoreLib],[System.String, System.Private.CoreLib]], System.Private.CoreLib"}},{"$type":"Coldairarrow.Util.OAStep, Coldairarrow.Util","Id":"node144","Label":"人力归档","StepType":"AIStudio.Service.WorkflowCore.OAMiddleStep, AIStudio.Service","PreStepId":{"$type":"System.Collections.Generic.List`1[[System.String, System.Private.CoreLib]], System.Private.CoreLib","$values":["node137"]},"NextStepId":"node61","Status":100,"ActRules":{"$type":"Coldairarrow.Util.ActRule, Coldairarrow.Util","UserIds":{"$type":"System.Collections.Generic.List`1[[System.String, System.Private.CoreLib]], System.Private.CoreLib","$values":["Admin"]},"UserNames":{"$type":"System.Collections.Generic.List`1[[System.String, System.Private.CoreLib]], System.Private.CoreLib","$values":["Admin"]},"RoleIds":null,"RoleNames":null,"ActType":null},"SelectNextStep":{"$type":"System.Collections.Generic.Dictionary`2[[System.String, System.Private.CoreLib],[System.String, System.Private.CoreLib]], System.Private.CoreLib"}},{"$type":"Coldairarrow.Util.OAStep, Coldairarrow.Util","Id":"node61","Label":"结束","StepType":"AIStudio.Service.WorkflowCore.OAEndStep, AIStudio.Service","PreStepId":{"$type":"System.Collections.Generic.List`1[[System.String, System.Private.CoreLib]], System.Private.CoreLib","$values":["node144"]},"NextStepId":null,"Status":0,"ActRules":{"$type":"Coldairarrow.Util.ActRule, Coldairarrow.Util","UserIds":null,"UserNames":null,"RoleIds":null,"RoleNames":null,"ActType":null},"SelectNextStep":{"$type":"System.Collections.Generic.Dictionary`2[[System.String, System.Private.CoreLib],[System.String, System.Private.CoreLib]], System.Private.CoreLib"}}]},"CurrentStepIds":{"$type":"System.Collections.Generic.List`1[[Coldairarrow.Util.CurrentStepId, Coldairarrow.Util]], System.Private.CoreLib","$values":[]},"MyEvent":null,"Flag":4.0,"nodes":{"$type":"Coldairarrow.Util.nodes[], Coldairarrow.Util","$values":[{"$type":"Coldairarrow.Util.nodes, Coldairarrow.Util","id":"node2","name":"开始节点","backImage":null,"color":"LightGreen","image":"/assets/Shape.486da24a.svg","label":"开始","offsetX":85,"offsetY":26,"shape":"customNode","size":{"$type":"System.Int32[], System.Private.CoreLib","$values":[170,34]},"stateImage":"/assets/start.e502ed95.svg","type":"node","x":221.55001831054688,"y":84.0,"inPoints":{"$type":"System.Double[][], System.Private.CoreLib","$values":[{"$type":"System.Double[], System.Private.CoreLib","$values":[0.0,0.5]}]},"outPoints":{"$type":"System.Double[][], System.Private.CoreLib","$values":[{"$type":"System.Double[], System.Private.CoreLib","$values":[1.0,0.5]}]},"isDoingStart":false,"isDoingEnd":false,"UserIds":null,"RoleIds":null,"ActType":null},{"$type":"Coldairarrow.Util.nodes, Coldairarrow.Util","id":"node9","name":"中间节点","backImage":null,"color":"LightGreen","image":"/assets/Shape.486da24a.svg","label":"主管审批","offsetX":76,"offsetY":21,"shape":"customNode","size":{"$type":"System.Int32[], System.Private.CoreLib","$values":[170,34]},"stateImage":"/assets/ok.463ab0e4.svg","type":"node","x":220.55001831054688,"y":161.0,"inPoints":{"$type":"System.Double[][], System.Private.CoreLib","$values":[{"$type":"System.Double[], System.Private.CoreLib","$values":[0.0,0.5]}]},"outPoints":{"$type":"System.Double[][], System.Private.CoreLib","$values":[{"$type":"System.Double[], System.Private.CoreLib","$values":[1.0,0.5]}]},"isDoingStart":false,"isDoingEnd":false,"UserIds":{"$type":"System.Collections.Generic.List`1[[System.String, System.Private.CoreLib]], System.Private.CoreLib","$values":["Admin"]},"RoleIds":null,"ActType":null},{"$type":"Coldairarrow.Util.nodes, Coldairarrow.Util","id":"node61","name":"结束节点","backImage":null,"color":"#1890ff","image":"/assets/Shape.486da24a.svg","label":"结束","offsetX":81,"offsetY":25,"shape":"customNode","size":{"$type":"System.Int32[], System.Private.CoreLib","$values":[170,34]},"stateImage":"/assets/end.dfe4a5ab.svg","type":"node","x":218.55001831054688,"y":408.0,"inPoints":{"$type":"System.Double[][], System.Private.CoreLib","$values":[{"$type":"System.Double[], System.Private.CoreLib","$values":[0.0,0.5]}]},"outPoints":{"$type":"System.Double[][], System.Private.CoreLib","$values":[{"$type":"System.Double[], System.Private.CoreLib","$values":[1.0,0.5]}]},"isDoingStart":false,"isDoingEnd":false,"UserIds":null,"RoleIds":null,"ActType":null},{"$type":"Coldairarrow.Util.nodes, Coldairarrow.Util","id":"node137","name":"中间节点","backImage":null,"color":"LightGreen","image":"/assets/Shape.486da24a.svg","label":"人力审批","offsetX":116,"offsetY":20,"shape":"customNode","size":{"$type":"System.Int32[], System.Private.CoreLib","$values":[170,34]},"stateImage":"/assets/ok.463ab0e4.svg","type":"node","x":221.55001831054688,"y":243.0,"inPoints":{"$type":"System.Double[][], System.Private.CoreLib","$values":[{"$type":"System.Double[], System.Private.CoreLib","$values":[0.0,0.5]}]},"outPoints":{"$type":"System.Double[][], System.Private.CoreLib","$values":[{"$type":"System.Double[], System.Private.CoreLib","$values":[1.0,0.5]}]},"isDoingStart":false,"isDoingEnd":false,"UserIds":{"$type":"System.Collections.Generic.List`1[[System.String, System.Private.CoreLib]], System.Private.CoreLib","$values":["Admin"]},"RoleIds":null,"ActType":null},{"$type":"Coldairarrow.Util.nodes, Coldairarrow.Util","id":"node144","name":"中间节点","backImage":null,"color":"LightGreen","image":"/assets/Shape.486da24a.svg","label":"人力归档","offsetX":102,"offsetY":15,"shape":"customNode","size":{"$type":"System.Int32[], System.Private.CoreLib","$values":[170,34]},"stateImage":"/assets/ok.463ab0e4.svg","type":"node","x":220.55001831054688,"y":323.0,"inPoints":{"$type":"System.Double[][], System.Private.CoreLib","$values":[{"$type":"System.Double[], System.Private.CoreLib","$values":[0.0,0.5]}]},"outPoints":{"$type":"System.Double[][], System.Private.CoreLib","$values":[{"$type":"System.Double[], System.Private.CoreLib","$values":[1.0,0.5]}]},"isDoingStart":false,"isDoingEnd":false,"UserIds":{"$type":"System.Collections.Generic.List`1[[System.String, System.Private.CoreLib]], System.Private.CoreLib","$values":["Admin"]},"RoleIds":null,"ActType":null}]},"edges":{"$type":"Coldairarrow.Util.edges[], Coldairarrow.Util","$values":[{"$type":"Coldairarrow.Util.edges, Coldairarrow.Util","id":"edge56","end":{"$type":"Coldairarrow.Util.point, Coldairarrow.Util","x":0.0,"y":-17.0},"endPoint":{"$type":"Coldairarrow.Util.point, Coldairarrow.Util","x":220.77729103781962,"y":143.5},"start":{"$type":"Coldairarrow.Util.point, Coldairarrow.Util","x":0.0,"y":17.0},"startPoint":{"$type":"Coldairarrow.Util.point, Coldairarrow.Util","x":221.32274558327413,"y":101.5},"shape":"customEdge","source":"node2","sourceId":"node2","target":"node9","targetId":"node9","type":"edge","label":null,"textColor":null},{"$type":"Coldairarrow.Util.edges, Coldairarrow.Util","id":"edge180","end":{"$type":"Coldairarrow.Util.point, Coldairarrow.Util","x":0.0,"y":-17.0},"endPoint":{"$type":"Coldairarrow.Util.point, Coldairarrow.Util","x":221.33660367640056,"y":225.5},"start":{"$type":"Coldairarrow.Util.point, Coldairarrow.Util","x":0.0,"y":17.0},"startPoint":{"$type":"Coldairarrow.Util.point, Coldairarrow.Util","x":220.7634329446932,"y":178.5},"shape":"customEdge","source":"node9","sourceId":"node9","target":"node137","targetId":"node137","type":"edge","label":null,"textColor":null},{"$type":"Coldairarrow.Util.edges, Coldairarrow.Util","id":"edge219","end":{"$type":"Coldairarrow.Util.point, Coldairarrow.Util","x":0.0,"y":-17.0},"endPoint":{"$type":"Coldairarrow.Util.point, Coldairarrow.Util","x":220.76876831054688,"y":305.5},"start":{"$type":"Coldairarrow.Util.point, Coldairarrow.Util","x":0.0,"y":17.0},"startPoint":{"$type":"Coldairarrow.Util.point, Coldairarrow.Util","x":221.33126831054688,"y":260.5},"shape":"customEdge","source":"node137","sourceId":"node137","target":"node144","targetId":"node144","type":"edge","label":null,"textColor":null},{"$type":"Coldairarrow.Util.edges, Coldairarrow.Util","id":"edge261","end":{"$type":"Coldairarrow.Util.point, Coldairarrow.Util","x":0.0,"y":-17.0},"endPoint":{"$type":"Coldairarrow.Util.point, Coldairarrow.Util","x":218.96178301642922,"y":390.5},"start":{"$type":"Coldairarrow.Util.point, Coldairarrow.Util","x":0.0,"y":17.0},"startPoint":{"$type":"Coldairarrow.Util.point, Coldairarrow.Util","x":220.13825360466453,"y":340.5},"shape":"customEdge","source":"node144","sourceId":"node144","target":"node61","targetId":"node61","type":"edge","label":null,"textColor":null}]},"groups":{"$type":"Coldairarrow.Util.groups[], Coldairarrow.Util","$values":[]}}', NULL, N'e7ad4db9-0f57-46fa-a397-7d8cc3229081', NULL, 2, 0, N'1274618511506804736', NULL)
GO
INSERT [wfc].[Workflow] ([PersistenceId], [CompleteTime], [CreateTime], [Data], [Description], [InstanceId], [NextExecution], [Status], [Version], [WorkflowDefinitionId], [Reference]) VALUES (4, CAST(N'2021-07-19T05:24:00.2012233' AS DateTime2), CAST(N'2021-07-14T01:16:01.7840807' AS DateTime2), N'{"$type":"Coldairarrow.Util.OAData, Coldairarrow.Util","Id":"1274618511506804736","Version":0,"DataType":"Coldairarrow.Util.OAData, Coldairarrow.Util","FirstStart":false,"Steps":{"$type":"System.Collections.Generic.List`1[[Coldairarrow.Util.OAStep, Coldairarrow.Util]], System.Private.CoreLib","$values":[{"$type":"Coldairarrow.Util.OAStep, Coldairarrow.Util","Id":"node2","Label":"开始","StepType":"AIStudio.Service.WorkflowCore.OAStartStep, AIStudio.Service","PreStepId":null,"NextStepId":"node9","Status":100,"ActRules":{"$type":"Coldairarrow.Util.ActRule, Coldairarrow.Util","UserIds":{"$type":"System.Collections.Generic.List`1[[System.String, System.Private.CoreLib]], System.Private.CoreLib","$values":["Admin"]},"UserNames":{"$type":"System.Collections.Generic.List`1[[System.String, System.Private.CoreLib]], System.Private.CoreLib","$values":["Admin"]},"RoleIds":null,"RoleNames":null,"ActType":null},"SelectNextStep":{"$type":"System.Collections.Generic.Dictionary`2[[System.String, System.Private.CoreLib],[System.String, System.Private.CoreLib]], System.Private.CoreLib"}},{"$type":"Coldairarrow.Util.OAStep, Coldairarrow.Util","Id":"node9","Label":"主管审批","StepType":"AIStudio.Service.WorkflowCore.OAMiddleStep, AIStudio.Service","PreStepId":{"$type":"System.Collections.Generic.List`1[[System.String, System.Private.CoreLib]], System.Private.CoreLib","$values":["node2"]},"NextStepId":"node137","Status":100,"ActRules":{"$type":"Coldairarrow.Util.ActRule, Coldairarrow.Util","UserIds":{"$type":"System.Collections.Generic.List`1[[System.String, System.Private.CoreLib]], System.Private.CoreLib","$values":["Admin"]},"UserNames":{"$type":"System.Collections.Generic.List`1[[System.String, System.Private.CoreLib]], System.Private.CoreLib","$values":["Admin"]},"RoleIds":null,"RoleNames":null,"ActType":null},"SelectNextStep":{"$type":"System.Collections.Generic.Dictionary`2[[System.String, System.Private.CoreLib],[System.String, System.Private.CoreLib]], System.Private.CoreLib"}},{"$type":"Coldairarrow.Util.OAStep, Coldairarrow.Util","Id":"node137","Label":"人力审批","StepType":"AIStudio.Service.WorkflowCore.OAMiddleStep, AIStudio.Service","PreStepId":{"$type":"System.Collections.Generic.List`1[[System.String, System.Private.CoreLib]], System.Private.CoreLib","$values":["node9"]},"NextStepId":"node144","Status":0,"ActRules":{"$type":"Coldairarrow.Util.ActRule, Coldairarrow.Util","UserIds":{"$type":"System.Collections.Generic.List`1[[System.String, System.Private.CoreLib]], System.Private.CoreLib","$values":["Admin"]},"UserNames":{"$type":"System.Collections.Generic.List`1[[System.String, System.Private.CoreLib]], System.Private.CoreLib","$values":["Admin"]},"RoleIds":null,"RoleNames":null,"ActType":null},"SelectNextStep":{"$type":"System.Collections.Generic.Dictionary`2[[System.String, System.Private.CoreLib],[System.String, System.Private.CoreLib]], System.Private.CoreLib"}},{"$type":"Coldairarrow.Util.OAStep, Coldairarrow.Util","Id":"node144","Label":"人力归档","StepType":"AIStudio.Service.WorkflowCore.OAMiddleStep, AIStudio.Service","PreStepId":{"$type":"System.Collections.Generic.List`1[[System.String, System.Private.CoreLib]], System.Private.CoreLib","$values":["node137"]},"NextStepId":"node61","Status":0,"ActRules":{"$type":"Coldairarrow.Util.ActRule, Coldairarrow.Util","UserIds":{"$type":"System.Collections.Generic.List`1[[System.String, System.Private.CoreLib]], System.Private.CoreLib","$values":["Admin"]},"UserNames":{"$type":"System.Collections.Generic.List`1[[System.String, System.Private.CoreLib]], System.Private.CoreLib","$values":["Admin"]},"RoleIds":null,"RoleNames":null,"ActType":null},"SelectNextStep":{"$type":"System.Collections.Generic.Dictionary`2[[System.String, System.Private.CoreLib],[System.String, System.Private.CoreLib]], System.Private.CoreLib"}},{"$type":"Coldairarrow.Util.OAStep, Coldairarrow.Util","Id":"node61","Label":"结束","StepType":"AIStudio.Service.WorkflowCore.OAEndStep, AIStudio.Service","PreStepId":{"$type":"System.Collections.Generic.List`1[[System.String, System.Private.CoreLib]], System.Private.CoreLib","$values":["node144"]},"NextStepId":null,"Status":0,"ActRules":{"$type":"Coldairarrow.Util.ActRule, Coldairarrow.Util","UserIds":null,"UserNames":null,"RoleIds":null,"RoleNames":null,"ActType":null},"SelectNextStep":{"$type":"System.Collections.Generic.Dictionary`2[[System.String, System.Private.CoreLib],[System.String, System.Private.CoreLib]], System.Private.CoreLib"}}]},"CurrentStepIds":{"$type":"System.Collections.Generic.List`1[[Coldairarrow.Util.CurrentStepId, Coldairarrow.Util]], System.Private.CoreLib","$values":[]},"MyEvent":null,"Flag":1.0,"nodes":{"$type":"Coldairarrow.Util.nodes[], Coldairarrow.Util","$values":[{"$type":"Coldairarrow.Util.nodes, Coldairarrow.Util","id":"node2","name":"开始节点","backImage":null,"color":"LightGreen","image":"/assets/Shape.486da24a.svg","label":"开始","offsetX":85,"offsetY":26,"shape":"customNode","size":{"$type":"System.Int32[], System.Private.CoreLib","$values":[170,34]},"stateImage":"/assets/start.e502ed95.svg","type":"node","x":221.55001831054688,"y":84.0,"inPoints":{"$type":"System.Double[][], System.Private.CoreLib","$values":[{"$type":"System.Double[], System.Private.CoreLib","$values":[0.0,0.5]}]},"outPoints":{"$type":"System.Double[][], System.Private.CoreLib","$values":[{"$type":"System.Double[], System.Private.CoreLib","$values":[1.0,0.5]}]},"isDoingStart":false,"isDoingEnd":false,"UserIds":null,"RoleIds":null,"ActType":null},{"$type":"Coldairarrow.Util.nodes, Coldairarrow.Util","id":"node9","name":"中间节点","backImage":null,"color":"LightGreen","image":"/assets/Shape.486da24a.svg","label":"主管审批","offsetX":76,"offsetY":21,"shape":"customNode","size":{"$type":"System.Int32[], System.Private.CoreLib","$values":[170,34]},"stateImage":"/assets/ok.463ab0e4.svg","type":"node","x":220.55001831054688,"y":161.0,"inPoints":{"$type":"System.Double[][], System.Private.CoreLib","$values":[{"$type":"System.Double[], System.Private.CoreLib","$values":[0.0,0.5]}]},"outPoints":{"$type":"System.Double[][], System.Private.CoreLib","$values":[{"$type":"System.Double[], System.Private.CoreLib","$values":[1.0,0.5]}]},"isDoingStart":false,"isDoingEnd":false,"UserIds":{"$type":"System.Collections.Generic.List`1[[System.String, System.Private.CoreLib]], System.Private.CoreLib","$values":["Admin"]},"RoleIds":null,"ActType":null},{"$type":"Coldairarrow.Util.nodes, Coldairarrow.Util","id":"node61","name":"结束节点","backImage":null,"color":"#1890ff","image":"/assets/Shape.486da24a.svg","label":"结束","offsetX":81,"offsetY":25,"shape":"customNode","size":{"$type":"System.Int32[], System.Private.CoreLib","$values":[170,34]},"stateImage":"/assets/end.dfe4a5ab.svg","type":"node","x":218.55001831054688,"y":408.0,"inPoints":{"$type":"System.Double[][], System.Private.CoreLib","$values":[{"$type":"System.Double[], System.Private.CoreLib","$values":[0.0,0.5]}]},"outPoints":{"$type":"System.Double[][], System.Private.CoreLib","$values":[{"$type":"System.Double[], System.Private.CoreLib","$values":[1.0,0.5]}]},"isDoingStart":false,"isDoingEnd":false,"UserIds":null,"RoleIds":null,"ActType":null},{"$type":"Coldairarrow.Util.nodes, Coldairarrow.Util","id":"node137","name":"中间节点","backImage":null,"color":"#1890ff","image":"/assets/Shape.486da24a.svg","label":"人力审批","offsetX":116,"offsetY":20,"shape":"customNode","size":{"$type":"System.Int32[], System.Private.CoreLib","$values":[170,34]},"stateImage":"/assets/jiahao.ecf71c51.svg","type":"node","x":221.55001831054688,"y":243.0,"inPoints":{"$type":"System.Double[][], System.Private.CoreLib","$values":[{"$type":"System.Double[], System.Private.CoreLib","$values":[0.0,0.5]}]},"outPoints":{"$type":"System.Double[][], System.Private.CoreLib","$values":[{"$type":"System.Double[], System.Private.CoreLib","$values":[1.0,0.5]}]},"isDoingStart":false,"isDoingEnd":false,"UserIds":{"$type":"System.Collections.Generic.List`1[[System.String, System.Private.CoreLib]], System.Private.CoreLib","$values":["Admin"]},"RoleIds":null,"ActType":null},{"$type":"Coldairarrow.Util.nodes, Coldairarrow.Util","id":"node144","name":"中间节点","backImage":null,"color":"#1890ff","image":"/assets/Shape.486da24a.svg","label":"人力归档","offsetX":102,"offsetY":15,"shape":"customNode","size":{"$type":"System.Int32[], System.Private.CoreLib","$values":[170,34]},"stateImage":"/assets/jiahao.ecf71c51.svg","type":"node","x":220.55001831054688,"y":323.0,"inPoints":{"$type":"System.Double[][], System.Private.CoreLib","$values":[{"$type":"System.Double[], System.Private.CoreLib","$values":[0.0,0.5]}]},"outPoints":{"$type":"System.Double[][], System.Private.CoreLib","$values":[{"$type":"System.Double[], System.Private.CoreLib","$values":[1.0,0.5]}]},"isDoingStart":false,"isDoingEnd":false,"UserIds":{"$type":"System.Collections.Generic.List`1[[System.String, System.Private.CoreLib]], System.Private.CoreLib","$values":["Admin"]},"RoleIds":null,"ActType":null}]},"edges":{"$type":"Coldairarrow.Util.edges[], Coldairarrow.Util","$values":[{"$type":"Coldairarrow.Util.edges, Coldairarrow.Util","id":"edge56","end":{"$type":"Coldairarrow.Util.point, Coldairarrow.Util","x":0.0,"y":-17.0},"endPoint":{"$type":"Coldairarrow.Util.point, Coldairarrow.Util","x":220.77729103781962,"y":143.5},"start":{"$type":"Coldairarrow.Util.point, Coldairarrow.Util","x":0.0,"y":17.0},"startPoint":{"$type":"Coldairarrow.Util.point, Coldairarrow.Util","x":221.32274558327413,"y":101.5},"shape":"customEdge","source":"node2","sourceId":"node2","target":"node9","targetId":"node9","type":"edge","label":null,"textColor":null},{"$type":"Coldairarrow.Util.edges, Coldairarrow.Util","id":"edge180","end":{"$type":"Coldairarrow.Util.point, Coldairarrow.Util","x":0.0,"y":-17.0},"endPoint":{"$type":"Coldairarrow.Util.point, Coldairarrow.Util","x":221.33660367640056,"y":225.5},"start":{"$type":"Coldairarrow.Util.point, Coldairarrow.Util","x":0.0,"y":17.0},"startPoint":{"$type":"Coldairarrow.Util.point, Coldairarrow.Util","x":220.7634329446932,"y":178.5},"shape":"customEdge","source":"node9","sourceId":"node9","target":"node137","targetId":"node137","type":"edge","label":null,"textColor":null},{"$type":"Coldairarrow.Util.edges, Coldairarrow.Util","id":"edge219","end":{"$type":"Coldairarrow.Util.point, Coldairarrow.Util","x":0.0,"y":-17.0},"endPoint":{"$type":"Coldairarrow.Util.point, Coldairarrow.Util","x":220.76876831054688,"y":305.5},"start":{"$type":"Coldairarrow.Util.point, Coldairarrow.Util","x":0.0,"y":17.0},"startPoint":{"$type":"Coldairarrow.Util.point, Coldairarrow.Util","x":221.33126831054688,"y":260.5},"shape":"customEdge","source":"node137","sourceId":"node137","target":"node144","targetId":"node144","type":"edge","label":null,"textColor":null},{"$type":"Coldairarrow.Util.edges, Coldairarrow.Util","id":"edge261","end":{"$type":"Coldairarrow.Util.point, Coldairarrow.Util","x":0.0,"y":-17.0},"endPoint":{"$type":"Coldairarrow.Util.point, Coldairarrow.Util","x":218.96178301642922,"y":390.5},"start":{"$type":"Coldairarrow.Util.point, Coldairarrow.Util","x":0.0,"y":17.0},"startPoint":{"$type":"Coldairarrow.Util.point, Coldairarrow.Util","x":220.13825360466453,"y":340.5},"shape":"customEdge","source":"node144","sourceId":"node144","target":"node61","targetId":"node61","type":"edge","label":null,"textColor":null}]},"groups":{"$type":"Coldairarrow.Util.groups[], Coldairarrow.Util","$values":[]}}', NULL, N'fc3c5f3e-26c7-4603-8c19-b40a6ef103e5', NULL, 2, 0, N'1274618511506804736', NULL)
GO
INSERT [wfc].[Workflow] ([PersistenceId], [CompleteTime], [CreateTime], [Data], [Description], [InstanceId], [NextExecution], [Status], [Version], [WorkflowDefinitionId], [Reference]) VALUES (5, CAST(N'2021-07-19T03:05:49.4884096' AS DateTime2), CAST(N'2021-07-14T14:02:56.3000927' AS DateTime2), N'{"$type":"Coldairarrow.Util.OAData, Coldairarrow.Util","Id":"1274618511506804736","Version":0,"DataType":"Coldairarrow.Util.OAData, Coldairarrow.Util","FirstStart":false,"Steps":{"$type":"System.Collections.Generic.List`1[[Coldairarrow.Util.OAStep, Coldairarrow.Util]], System.Private.CoreLib","$values":[{"$type":"Coldairarrow.Util.OAStep, Coldairarrow.Util","Id":"node2","Label":"开始","StepType":"AIStudio.Service.WorkflowCore.OAStartStep, AIStudio.Service","PreStepId":null,"NextStepId":"node9","Status":100,"ActRules":{"$type":"Coldairarrow.Util.ActRule, Coldairarrow.Util","UserIds":{"$type":"System.Collections.Generic.List`1[[System.String, System.Private.CoreLib]], System.Private.CoreLib","$values":["Admin"]},"UserNames":{"$type":"System.Collections.Generic.List`1[[System.String, System.Private.CoreLib]], System.Private.CoreLib","$values":["Admin"]},"RoleIds":null,"RoleNames":null,"ActType":null},"SelectNextStep":{"$type":"System.Collections.Generic.Dictionary`2[[System.String, System.Private.CoreLib],[System.String, System.Private.CoreLib]], System.Private.CoreLib"}},{"$type":"Coldairarrow.Util.OAStep, Coldairarrow.Util","Id":"node9","Label":"主管审批","StepType":"AIStudio.Service.WorkflowCore.OAMiddleStep, AIStudio.Service","PreStepId":{"$type":"System.Collections.Generic.List`1[[System.String, System.Private.CoreLib]], System.Private.CoreLib","$values":["node2"]},"NextStepId":"node137","Status":4,"ActRules":{"$type":"Coldairarrow.Util.ActRule, Coldairarrow.Util","UserIds":{"$type":"System.Collections.Generic.List`1[[System.String, System.Private.CoreLib]], System.Private.CoreLib","$values":["Admin"]},"UserNames":{"$type":"System.Collections.Generic.List`1[[System.String, System.Private.CoreLib]], System.Private.CoreLib","$values":["Admin"]},"RoleIds":null,"RoleNames":null,"ActType":null},"SelectNextStep":{"$type":"System.Collections.Generic.Dictionary`2[[System.String, System.Private.CoreLib],[System.String, System.Private.CoreLib]], System.Private.CoreLib"}},{"$type":"Coldairarrow.Util.OAStep, Coldairarrow.Util","Id":"node137","Label":"人力审批","StepType":"AIStudio.Service.WorkflowCore.OAMiddleStep, AIStudio.Service","PreStepId":{"$type":"System.Collections.Generic.List`1[[System.String, System.Private.CoreLib]], System.Private.CoreLib","$values":["node9"]},"NextStepId":"node144","Status":0,"ActRules":{"$type":"Coldairarrow.Util.ActRule, Coldairarrow.Util","UserIds":{"$type":"System.Collections.Generic.List`1[[System.String, System.Private.CoreLib]], System.Private.CoreLib","$values":["Admin"]},"UserNames":{"$type":"System.Collections.Generic.List`1[[System.String, System.Private.CoreLib]], System.Private.CoreLib","$values":["Admin"]},"RoleIds":null,"RoleNames":null,"ActType":null},"SelectNextStep":{"$type":"System.Collections.Generic.Dictionary`2[[System.String, System.Private.CoreLib],[System.String, System.Private.CoreLib]], System.Private.CoreLib"}},{"$type":"Coldairarrow.Util.OAStep, Coldairarrow.Util","Id":"node144","Label":"人力归档","StepType":"AIStudio.Service.WorkflowCore.OAMiddleStep, AIStudio.Service","PreStepId":{"$type":"System.Collections.Generic.List`1[[System.String, System.Private.CoreLib]], System.Private.CoreLib","$values":["node137"]},"NextStepId":"node61","Status":0,"ActRules":{"$type":"Coldairarrow.Util.ActRule, Coldairarrow.Util","UserIds":{"$type":"System.Collections.Generic.List`1[[System.String, System.Private.CoreLib]], System.Private.CoreLib","$values":["Admin"]},"UserNames":{"$type":"System.Collections.Generic.List`1[[System.String, System.Private.CoreLib]], System.Private.CoreLib","$values":["Admin"]},"RoleIds":null,"RoleNames":null,"ActType":null},"SelectNextStep":{"$type":"System.Collections.Generic.Dictionary`2[[System.String, System.Private.CoreLib],[System.String, System.Private.CoreLib]], System.Private.CoreLib"}},{"$type":"Coldairarrow.Util.OAStep, Coldairarrow.Util","Id":"node61","Label":"结束","StepType":"AIStudio.Service.WorkflowCore.OAEndStep, AIStudio.Service","PreStepId":{"$type":"System.Collections.Generic.List`1[[System.String, System.Private.CoreLib]], System.Private.CoreLib","$values":["node144"]},"NextStepId":null,"Status":0,"ActRules":{"$type":"Coldairarrow.Util.ActRule, Coldairarrow.Util","UserIds":null,"UserNames":null,"RoleIds":null,"RoleNames":null,"ActType":null},"SelectNextStep":{"$type":"System.Collections.Generic.Dictionary`2[[System.String, System.Private.CoreLib],[System.String, System.Private.CoreLib]], System.Private.CoreLib"}}]},"CurrentStepIds":{"$type":"System.Collections.Generic.List`1[[Coldairarrow.Util.CurrentStepId, Coldairarrow.Util]], System.Private.CoreLib","$values":[]},"MyEvent":null,"Flag":4.0,"nodes":{"$type":"Coldairarrow.Util.nodes[], Coldairarrow.Util","$values":[{"$type":"Coldairarrow.Util.nodes, Coldairarrow.Util","id":"node2","name":"开始节点","backImage":null,"color":"LightGreen","image":"/assets/Shape.486da24a.svg","label":"开始","offsetX":85,"offsetY":26,"shape":"customNode","size":{"$type":"System.Int32[], System.Private.CoreLib","$values":[170,34]},"stateImage":"/assets/start.e502ed95.svg","type":"node","x":221.55001831054688,"y":84.0,"inPoints":{"$type":"System.Double[][], System.Private.CoreLib","$values":[{"$type":"System.Double[], System.Private.CoreLib","$values":[0.0,0.5]}]},"outPoints":{"$type":"System.Double[][], System.Private.CoreLib","$values":[{"$type":"System.Double[], System.Private.CoreLib","$values":[1.0,0.5]}]},"isDoingStart":false,"isDoingEnd":false,"UserIds":null,"RoleIds":null,"ActType":null},{"$type":"Coldairarrow.Util.nodes, Coldairarrow.Util","id":"node9","name":"中间节点","backImage":null,"color":"Red","image":"/assets/Shape.486da24a.svg","label":"主管审批","offsetX":76,"offsetY":21,"shape":"customNode","size":{"$type":"System.Int32[], System.Private.CoreLib","$values":[170,34]},"stateImage":"/assets/no.0ca40fee.svg","type":"node","x":220.55001831054688,"y":161.0,"inPoints":{"$type":"System.Double[][], System.Private.CoreLib","$values":[{"$type":"System.Double[], System.Private.CoreLib","$values":[0.0,0.5]}]},"outPoints":{"$type":"System.Double[][], System.Private.CoreLib","$values":[{"$type":"System.Double[], System.Private.CoreLib","$values":[1.0,0.5]}]},"isDoingStart":false,"isDoingEnd":false,"UserIds":{"$type":"System.Collections.Generic.List`1[[System.String, System.Private.CoreLib]], System.Private.CoreLib","$values":["Admin"]},"RoleIds":null,"ActType":null},{"$type":"Coldairarrow.Util.nodes, Coldairarrow.Util","id":"node61","name":"结束节点","backImage":null,"color":"#1890ff","image":"/assets/Shape.486da24a.svg","label":"结束","offsetX":81,"offsetY":25,"shape":"customNode","size":{"$type":"System.Int32[], System.Private.CoreLib","$values":[170,34]},"stateImage":"/assets/end.dfe4a5ab.svg","type":"node","x":218.55001831054688,"y":408.0,"inPoints":{"$type":"System.Double[][], System.Private.CoreLib","$values":[{"$type":"System.Double[], System.Private.CoreLib","$values":[0.0,0.5]}]},"outPoints":{"$type":"System.Double[][], System.Private.CoreLib","$values":[{"$type":"System.Double[], System.Private.CoreLib","$values":[1.0,0.5]}]},"isDoingStart":false,"isDoingEnd":false,"UserIds":null,"RoleIds":null,"ActType":null},{"$type":"Coldairarrow.Util.nodes, Coldairarrow.Util","id":"node137","name":"中间节点","backImage":null,"color":"#1890ff","image":"/assets/Shape.486da24a.svg","label":"人力审批","offsetX":116,"offsetY":20,"shape":"customNode","size":{"$type":"System.Int32[], System.Private.CoreLib","$values":[170,34]},"stateImage":"/assets/jiahao.ecf71c51.svg","type":"node","x":221.55001831054688,"y":243.0,"inPoints":{"$type":"System.Double[][], System.Private.CoreLib","$values":[{"$type":"System.Double[], System.Private.CoreLib","$values":[0.0,0.5]}]},"outPoints":{"$type":"System.Double[][], System.Private.CoreLib","$values":[{"$type":"System.Double[], System.Private.CoreLib","$values":[1.0,0.5]}]},"isDoingStart":false,"isDoingEnd":false,"UserIds":{"$type":"System.Collections.Generic.List`1[[System.String, System.Private.CoreLib]], System.Private.CoreLib","$values":["Admin"]},"RoleIds":null,"ActType":null},{"$type":"Coldairarrow.Util.nodes, Coldairarrow.Util","id":"node144","name":"中间节点","backImage":null,"color":"#1890ff","image":"/assets/Shape.486da24a.svg","label":"人力归档","offsetX":102,"offsetY":15,"shape":"customNode","size":{"$type":"System.Int32[], System.Private.CoreLib","$values":[170,34]},"stateImage":"/assets/jiahao.ecf71c51.svg","type":"node","x":220.55001831054688,"y":323.0,"inPoints":{"$type":"System.Double[][], System.Private.CoreLib","$values":[{"$type":"System.Double[], System.Private.CoreLib","$values":[0.0,0.5]}]},"outPoints":{"$type":"System.Double[][], System.Private.CoreLib","$values":[{"$type":"System.Double[], System.Private.CoreLib","$values":[1.0,0.5]}]},"isDoingStart":false,"isDoingEnd":false,"UserIds":{"$type":"System.Collections.Generic.List`1[[System.String, System.Private.CoreLib]], System.Private.CoreLib","$values":["Admin"]},"RoleIds":null,"ActType":null}]},"edges":{"$type":"Coldairarrow.Util.edges[], Coldairarrow.Util","$values":[{"$type":"Coldairarrow.Util.edges, Coldairarrow.Util","id":"edge56","end":{"$type":"Coldairarrow.Util.point, Coldairarrow.Util","x":0.0,"y":-17.0},"endPoint":{"$type":"Coldairarrow.Util.point, Coldairarrow.Util","x":220.77729103781962,"y":143.5},"start":{"$type":"Coldairarrow.Util.point, Coldairarrow.Util","x":0.0,"y":17.0},"startPoint":{"$type":"Coldairarrow.Util.point, Coldairarrow.Util","x":221.32274558327413,"y":101.5},"shape":"customEdge","source":"node2","sourceId":"node2","target":"node9","targetId":"node9","type":"edge","label":null,"textColor":null},{"$type":"Coldairarrow.Util.edges, Coldairarrow.Util","id":"edge180","end":{"$type":"Coldairarrow.Util.point, Coldairarrow.Util","x":0.0,"y":-17.0},"endPoint":{"$type":"Coldairarrow.Util.point, Coldairarrow.Util","x":221.33660367640056,"y":225.5},"start":{"$type":"Coldairarrow.Util.point, Coldairarrow.Util","x":0.0,"y":17.0},"startPoint":{"$type":"Coldairarrow.Util.point, Coldairarrow.Util","x":220.7634329446932,"y":178.5},"shape":"customEdge","source":"node9","sourceId":"node9","target":"node137","targetId":"node137","type":"edge","label":null,"textColor":null},{"$type":"Coldairarrow.Util.edges, Coldairarrow.Util","id":"edge219","end":{"$type":"Coldairarrow.Util.point, Coldairarrow.Util","x":0.0,"y":-17.0},"endPoint":{"$type":"Coldairarrow.Util.point, Coldairarrow.Util","x":220.76876831054688,"y":305.5},"start":{"$type":"Coldairarrow.Util.point, Coldairarrow.Util","x":0.0,"y":17.0},"startPoint":{"$type":"Coldairarrow.Util.point, Coldairarrow.Util","x":221.33126831054688,"y":260.5},"shape":"customEdge","source":"node137","sourceId":"node137","target":"node144","targetId":"node144","type":"edge","label":null,"textColor":null},{"$type":"Coldairarrow.Util.edges, Coldairarrow.Util","id":"edge261","end":{"$type":"Coldairarrow.Util.point, Coldairarrow.Util","x":0.0,"y":-17.0},"endPoint":{"$type":"Coldairarrow.Util.point, Coldairarrow.Util","x":218.96178301642922,"y":390.5},"start":{"$type":"Coldairarrow.Util.point, Coldairarrow.Util","x":0.0,"y":17.0},"startPoint":{"$type":"Coldairarrow.Util.point, Coldairarrow.Util","x":220.13825360466453,"y":340.5},"shape":"customEdge","source":"node144","sourceId":"node144","target":"node61","targetId":"node61","type":"edge","label":null,"textColor":null}]},"groups":{"$type":"Coldairarrow.Util.groups[], Coldairarrow.Util","$values":[]}}', NULL, N'ea776dda-c4a4-4dc3-9a81-31ac4ef4f639', NULL, 2, 0, N'1274618511506804736', NULL)
GO
SET IDENTITY_INSERT [wfc].[Workflow] OFF
GO
/****** Object:  Index [IX_Event_EventId]    Script Date: 2021/7/31 21:17:42 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Event_EventId] ON [wfc].[Event]
(
	[EventId] ASC
)
WHERE ([EventId] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Event_EventName_EventKey]    Script Date: 2021/7/31 21:17:42 ******/
CREATE NONCLUSTERED INDEX [IX_Event_EventName_EventKey] ON [wfc].[Event]
(
	[EventName] ASC,
	[EventKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Event_EventTime]    Script Date: 2021/7/31 21:17:42 ******/
CREATE NONCLUSTERED INDEX [IX_Event_EventTime] ON [wfc].[Event]
(
	[EventTime] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Event_IsProcessed]    Script Date: 2021/7/31 21:17:42 ******/
CREATE NONCLUSTERED INDEX [IX_Event_IsProcessed] ON [wfc].[Event]
(
	[IsProcessed] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ExecutionPointer_WorkflowId]    Script Date: 2021/7/31 21:17:42 ******/
CREATE NONCLUSTERED INDEX [IX_ExecutionPointer_WorkflowId] ON [wfc].[ExecutionPointer]
(
	[WorkflowId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ExtensionAttribute_ExecutionPointerId]    Script Date: 2021/7/31 21:17:42 ******/
CREATE NONCLUSTERED INDEX [IX_ExtensionAttribute_ExecutionPointerId] ON [wfc].[ExtensionAttribute]
(
	[ExecutionPointerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Subscription_EventKey]    Script Date: 2021/7/31 21:17:42 ******/
CREATE NONCLUSTERED INDEX [IX_Subscription_EventKey] ON [wfc].[Subscription]
(
	[EventKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Subscription_EventName]    Script Date: 2021/7/31 21:17:42 ******/
CREATE NONCLUSTERED INDEX [IX_Subscription_EventName] ON [wfc].[Subscription]
(
	[EventName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Subscription_SubscriptionId]    Script Date: 2021/7/31 21:17:42 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Subscription_SubscriptionId] ON [wfc].[Subscription]
(
	[SubscriptionId] ASC
)
WHERE ([SubscriptionId] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Workflow_InstanceId]    Script Date: 2021/7/31 21:17:42 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Workflow_InstanceId] ON [wfc].[Workflow]
(
	[InstanceId] ASC
)
WHERE ([InstanceId] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Workflow_NextExecution]    Script Date: 2021/7/31 21:17:42 ******/
CREATE NONCLUSTERED INDEX [IX_Workflow_NextExecution] ON [wfc].[Workflow]
(
	[NextExecution] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_Datasource', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_Datasource', @level2type=N'COLUMN',@level2name=N'Code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_Datasource', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'数据库主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_Datasource', @level2type=N'COLUMN',@level2name=N'DbLinkId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'sql语句' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_Datasource', @level2type=N'COLUMN',@level2name=N'Sql'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_Datasource', @level2type=N'COLUMN',@level2name=N'Description'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_Datasource', @level2type=N'COLUMN',@level2name=N'CreatorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_Datasource', @level2type=N'COLUMN',@level2name=N'CreatorName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_Datasource', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改人ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_Datasource', @level2type=N'COLUMN',@level2name=N'ModifyId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_Datasource', @level2type=N'COLUMN',@level2name=N'ModifyName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_Datasource', @level2type=N'COLUMN',@level2name=N'ModifyTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'租户Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_Datasource', @level2type=N'COLUMN',@level2name=N'TenantId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'否已删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_Datasource', @level2type=N'COLUMN',@level2name=N'Deleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'数据源表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Base_Datasource'
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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自然主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_UserMessage_202104', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态 =0草稿中，=1已发送，=2废弃撤回，=3发送失败' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_UserMessage_202104', @level2type=N'COLUMN',@level2name=N'Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'否已删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_UserMessage_202104', @level2type=N'COLUMN',@level2name=N'Deleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_UserMessage_202104', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_UserMessage_202104', @level2type=N'COLUMN',@level2name=N'ModifyTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_UserMessage_202104', @level2type=N'COLUMN',@level2name=N'CreatorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_UserMessage_202104', @level2type=N'COLUMN',@level2name=N'CreatorName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改人Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_UserMessage_202104', @level2type=N'COLUMN',@level2name=N'ModifyId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_UserMessage_202104', @level2type=N'COLUMN',@level2name=N'ModifyName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'租户Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_UserMessage_202104', @level2type=N'COLUMN',@level2name=N'TenantId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自然主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_UserMessage_202105', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态 =0草稿中，=1已发送，=2废弃撤回，=3发送失败' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_UserMessage_202105', @level2type=N'COLUMN',@level2name=N'Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'否已删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_UserMessage_202105', @level2type=N'COLUMN',@level2name=N'Deleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_UserMessage_202105', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_UserMessage_202105', @level2type=N'COLUMN',@level2name=N'ModifyTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_UserMessage_202105', @level2type=N'COLUMN',@level2name=N'CreatorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_UserMessage_202105', @level2type=N'COLUMN',@level2name=N'CreatorName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改人Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_UserMessage_202105', @level2type=N'COLUMN',@level2name=N'ModifyId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_UserMessage_202105', @level2type=N'COLUMN',@level2name=N'ModifyName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'租户Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_UserMessage_202105', @level2type=N'COLUMN',@level2name=N'TenantId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自然主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_UserMessage_202106', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态 =0草稿中，=1已发送，=2废弃撤回，=3发送失败' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_UserMessage_202106', @level2type=N'COLUMN',@level2name=N'Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'否已删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_UserMessage_202106', @level2type=N'COLUMN',@level2name=N'Deleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_UserMessage_202106', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_UserMessage_202106', @level2type=N'COLUMN',@level2name=N'ModifyTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_UserMessage_202106', @level2type=N'COLUMN',@level2name=N'CreatorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_UserMessage_202106', @level2type=N'COLUMN',@level2name=N'CreatorName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改人Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_UserMessage_202106', @level2type=N'COLUMN',@level2name=N'ModifyId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_UserMessage_202106', @level2type=N'COLUMN',@level2name=N'ModifyName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'租户Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_UserMessage_202106', @level2type=N'COLUMN',@level2name=N'TenantId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自然主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_UserMessage_202107', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态 =0草稿中，=1已发送，=2废弃撤回，=3发送失败' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_UserMessage_202107', @level2type=N'COLUMN',@level2name=N'Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'否已删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_UserMessage_202107', @level2type=N'COLUMN',@level2name=N'Deleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_UserMessage_202107', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_UserMessage_202107', @level2type=N'COLUMN',@level2name=N'ModifyTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_UserMessage_202107', @level2type=N'COLUMN',@level2name=N'CreatorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_UserMessage_202107', @level2type=N'COLUMN',@level2name=N'CreatorName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改人Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_UserMessage_202107', @level2type=N'COLUMN',@level2name=N'ModifyId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_UserMessage_202107', @level2type=N'COLUMN',@level2name=N'ModifyName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'租户Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_UserMessage_202107', @level2type=N'COLUMN',@level2name=N'TenantId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自然主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_UserMessage_202108', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态 =0草稿中，=1已发送，=2废弃撤回，=3发送失败' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_UserMessage_202108', @level2type=N'COLUMN',@level2name=N'Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'否已删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_UserMessage_202108', @level2type=N'COLUMN',@level2name=N'Deleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_UserMessage_202108', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_UserMessage_202108', @level2type=N'COLUMN',@level2name=N'ModifyTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_UserMessage_202108', @level2type=N'COLUMN',@level2name=N'CreatorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_UserMessage_202108', @level2type=N'COLUMN',@level2name=N'CreatorName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改人Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_UserMessage_202108', @level2type=N'COLUMN',@level2name=N'ModifyId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_UserMessage_202108', @level2type=N'COLUMN',@level2name=N'ModifyName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'租户Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'D_UserMessage_202108', @level2type=N'COLUMN',@level2name=N'TenantId'
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
USE [master]
GO
ALTER DATABASE [Colder.Admin.AntdVue] SET  READ_WRITE 
GO
