using AIStudio.Core;
using AIStudio.Wpf.DataBusiness.Base_Manage;
using AIStudio.Wpf.Entity.Models;
using Coldairarrow.Util;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.IO;

namespace AIStudio.Wpf.DataBusiness
{
    //astudio edit
    public class SeedData
    {
        public static void EnsureSeedData()
        {
            var roleBusiness = ContainerLocator.Current.Resolve<IBase_RoleBusiness>();
            var admin = roleBusiness.FirstOrDefaultAsync(p => p.RoleName == RoleTypes.部门管理员.ToString()).Result;
            if (admin == null)
            {
                admin = new Base_Role
                {
                    Id = IdHelper.GetId(),
                    RoleName = RoleTypes.部门管理员.ToString(),
                    CreateTime = DateTime.Now,
                };
                var result = roleBusiness.InsertAsync(admin).Result;
            }

            var superadmin = roleBusiness.FirstOrDefaultAsync(p => p.RoleName == RoleTypes.超级管理员.ToString()).Result;
            if (superadmin == null)
            {
                superadmin = new Base_Role
                {
                    Id = IdHelper.GetId(),
                    RoleName = RoleTypes.超级管理员.ToString(),
                    CreateTime = DateTime.Now,
                };
                var result = roleBusiness.InsertAsync(superadmin).Result;
            }

            var userBusiness = ContainerLocator.Current.Resolve<IBase_UserBusiness>();

            var adminUser = userBusiness.FirstOrDefaultAsync(p => p.UserName == "Admin").Result;
            if (adminUser == null)
            {
                adminUser = new Base_User
                {
                    Id = "Admin",
                    UserName = "Admin",
                    Password = "Admin".ToMD5String(),
                    CreateTime = DateTime.Now,
                };
                var result = userBusiness.InsertAsync(adminUser).Result;
                userBusiness.SetUserRoleAsync(adminUser.Id, new List<string> { superadmin.Id }).Wait();

                Console.WriteLine("admin created");
            }
            else
            {
                Console.WriteLine("admin already exists");
            }

            //alice ,123456,
            var alice = userBusiness.FirstOrDefaultAsync(p => p.UserName == "alice").Result;
            if (alice == null)
            {
                alice = new Base_User
                {
                    Id = IdHelper.GetId(),
                    UserName = "alice",
                    Password = "123456".ToMD5String(),
                    CreateTime = DateTime.Now,
                };
                var result = userBusiness.InsertAsync(alice).Result;

                userBusiness.SetUserRoleAsync(alice.Id, new List<string> { admin.Id }).Wait();

                Console.WriteLine("alice created");
            }
            else
            {
                Console.WriteLine("alice already exists");
            }

            //bob ,123456,
            var bob = userBusiness.FirstOrDefaultAsync(p => p.UserName == "bob").Result;
            if (bob == null)
            {
                bob = new Base_User
                {
                    Id = IdHelper.GetId(),
                    UserName = "bob",
                    Password = "123456".ToMD5String(),
                    CreateTime = DateTime.Now,
                };
                var result = userBusiness.InsertAsync(bob).Result;

                Console.WriteLine("bob created");
            }
            else
            {
                Console.WriteLine("bob already exists");
            }

            var actionBusiness = ContainerLocator.Current.Resolve<IBase_ActionBusiness>();
            var actionBusinesscount = actionBusiness.GetIQueryable().CountAsync().Result;
            if (actionBusinesscount == 0)
            {
                List<Base_Action> actions = new List<Base_Action>()
                    {
                         new Base_Action(){ Id="1178957405992521728",Deleted = false, ParentId=null,                  Type = (int)ActionType.菜单, Name="系统管理", Url=null,                               Value=null,                    NeedAction=true,    Icon="setting",        Sort=1, CreateTime=DateTime.Now},
                         new Base_Action(){ Id="1178957553778823168",Deleted = false, ParentId="1178957405992521728", Type = (int)ActionType.页面, Name="权限管理", Url="/Base_Manage/Base_Action/List",    Value=null,                    NeedAction=true,    Icon="lock",           Sort=1, CreateTime=DateTime.Now},
                         new Base_Action(){ Id="1179018395304071168",Deleted = false, ParentId="1178957405992521728", Type = (int)ActionType.页面, Name="密钥管理", Url="/Base_Manage/Base_AppSecret/List", Value=null,                    NeedAction=true,    Icon="key",            Sort=1, CreateTime=DateTime.Now},
                         new Base_Action(){ Id="1182652266117599232",Deleted = false, ParentId="1178957405992521728", Type = (int)ActionType.页面, Name="用户管理", Url="/Base_Manage/Base_User/List",      Value=null,                    NeedAction=true,    Icon="user-add",       Sort=1, CreateTime=DateTime.Now},
                         new Base_Action(){ Id="1182652367447789568",Deleted = false, ParentId="1178957405992521728", Type = (int)ActionType.页面, Name="角色管理", Url="/Base_Manage/Base_Role/List",      Value=null,                    NeedAction=true,    Icon="safety",         Sort=1, CreateTime=DateTime.Now},
                         new Base_Action(){ Id="1182652433302556672",Deleted = false, ParentId="1178957405992521728", Type = (int)ActionType.页面, Name="部门管理", Url="/Base_Manage/Base_Department/List",Value=null,                    NeedAction=true,    Icon="usergroup-add",  Sort=1, CreateTime=DateTime.Now},
                         new Base_Action(){ Id="1182652599069839360",Deleted = false, ParentId="1178957405992521728", Type = (int)ActionType.页面, Name="操作日志", Url="/Base_Manage/Base_UserLog/List",   Value=null,                    NeedAction=true,    Icon="fire",    Sort=1, CreateTime=DateTime.Now},
                         new Base_Action(){ Id="1182652599069839160",Deleted = false, ParentId="1178957405992521728", Type = (int)ActionType.页面, Name="常用数据配置", Url="/Base_Manage/Base_Datasource/List",   Value=null,             NeedAction=true,    Icon="file-search",    Sort=1, CreateTime=DateTime.Now},
                         new Base_Action(){ Id="1182652599069839361",Deleted = false, ParentId="1178957405992521728", Type = (int)ActionType.页面, Name="任务管理", Url="/Quartz_Manage/Quartz_Task/List",  Value=null,                    NeedAction=true,    Icon="calendar",       Sort=1, CreateTime=DateTime.Now},
                         new Base_Action(){ Id="1188800845714558976",Deleted = false, ParentId="1182652266117599232", Type = (int)ActionType.权限, Name="增",       Url=null,                               Value="Base_User.Add",         NeedAction=true,    Icon=null,             Sort=1, CreateTime=DateTime.Now},
                         new Base_Action(){ Id="1188800845714558977",Deleted = false, ParentId="1182652266117599232", Type = (int)ActionType.权限, Name="改",       Url=null,                               Value="Base_User.Edit",        NeedAction=true,    Icon=null,             Sort=1, CreateTime=DateTime.Now},
                         new Base_Action(){ Id="1188800845714558978",Deleted = false, ParentId="1182652266117599232", Type = (int)ActionType.权限, Name="删",       Url=null,                               Value="Base_User.Delete",      NeedAction=true,    Icon=null,             Sort=1, CreateTime=DateTime.Now},
                         new Base_Action(){ Id="1188801057778569216",Deleted = false, ParentId="1182652367447789568", Type = (int)ActionType.权限, Name="增",       Url=null,                               Value="Base_Role.Add",         NeedAction=true,    Icon=null,             Sort=1, CreateTime=DateTime.Now},
                         new Base_Action(){ Id="1188801057778569217",Deleted = false, ParentId="1182652367447789568", Type = (int)ActionType.权限, Name="改",       Url=null,                               Value="Base_Role.Edit",        NeedAction=true,    Icon=null,             Sort=1, CreateTime=DateTime.Now},
                         new Base_Action(){ Id="1188801057778569218",Deleted = false, ParentId="1182652367447789568", Type = (int)ActionType.权限, Name="删",       Url=null,                               Value="Base_Role.Delete",      NeedAction=true,    Icon=null,             Sort=1, CreateTime=DateTime.Now},
                         new Base_Action(){ Id="1188801109783744512",Deleted = false, ParentId="1182652433302556672", Type = (int)ActionType.权限, Name="增",       Url=null,                               Value="Base_Department.Add",   NeedAction=true,    Icon=null,             Sort=1, CreateTime=DateTime.Now},
                         new Base_Action(){ Id="1188801109783744513",Deleted = false, ParentId="1182652433302556672", Type = (int)ActionType.权限, Name="改",       Url=null,                               Value="Base_Department.Edit",  NeedAction=true,    Icon=null,             Sort=1, CreateTime=DateTime.Now},
                         new Base_Action(){ Id="1188801109783744514",Deleted = false, ParentId="1182652433302556672", Type = (int)ActionType.权限, Name="删",       Url=null,                               Value="Base_Department.Delete",NeedAction=true,    Icon=null,             Sort=1, CreateTime=DateTime.Now},
                         new Base_Action(){ Id="1188801273885888512",Deleted = false, ParentId="1179018395304071168", Type = (int)ActionType.权限, Name="增",       Url=null,                               Value="Base_AppSecret.Add",    NeedAction=true,    Icon=null,             Sort=1, CreateTime=DateTime.Now},
                         new Base_Action(){ Id="1188801273885888513",Deleted = false, ParentId="1179018395304071168", Type = (int)ActionType.权限, Name="改",       Url=null,                               Value="Base_AppSecret.Edit",   NeedAction=true,    Icon=null,             Sort=1, CreateTime=DateTime.Now},
                         new Base_Action(){ Id="1188801273885888514",Deleted = false, ParentId="1179018395304071168", Type = (int)ActionType.权限, Name="删",       Url=null,                               Value="Base_AppSecret.Delete", NeedAction=true,    Icon=null,             Sort=1, CreateTime=DateTime.Now},
                         new Base_Action(){ Id="1188801341661646848",Deleted = false, ParentId="1178957553778823168", Type = (int)ActionType.权限, Name="增",       Url=null,                               Value="Base_Action.Add",       NeedAction=true,    Icon=null,             Sort=1, CreateTime=DateTime.Now},
                         new Base_Action(){ Id="1188801341661646849",Deleted = false, ParentId="1178957553778823168", Type = (int)ActionType.权限, Name="改",       Url=null,                               Value="Base_Action.Edit",      NeedAction=true,    Icon=null,             Sort=1, CreateTime=DateTime.Now},
                         new Base_Action(){ Id="1188801341661646850",Deleted = false, ParentId="1178957553778823168", Type = (int)ActionType.权限, Name="删",       Url=null,                               Value="Base_Action.Delete",    NeedAction=true,    Icon=null,             Sort=1, CreateTime=DateTime.Now},
                         new Base_Action(){ Id="1182652599069839161",Deleted = false, ParentId="1182652599069839160", Type = (int)ActionType.权限, Name="增",       Url=null,                               Value="Base_Datasource.Add",       NeedAction=true,    Icon=null,             Sort=1, CreateTime=DateTime.Now},
                         new Base_Action(){ Id="1182652599069839162",Deleted = false, ParentId="1182652599069839160", Type = (int)ActionType.权限, Name="改",       Url=null,                               Value="Base_Datasource.Edit",      NeedAction=true,    Icon=null,             Sort=1, CreateTime=DateTime.Now},
                         new Base_Action(){ Id="1182652599069839163",Deleted = false, ParentId="1182652599069839160", Type = (int)ActionType.权限, Name="删",       Url=null,                               Value="Base_Datasource.Delete",    NeedAction=true,    Icon=null,             Sort=1, CreateTime=DateTime.Now},
                         new Base_Action(){ Id="1193158266167758848",Deleted = false, ParentId=null,                  Type = (int)ActionType.菜单, Name="首页",     Url=null,                               Value=null,                    NeedAction=true,    Icon="home",           Sort=1, CreateTime=DateTime.Now},
                         new Base_Action(){ Id="1193158630615027712",Deleted = false, ParentId="1193158266167758848", Type = (int)ActionType.页面, Name="框架介绍", Url="/Home/Introduce",                  Value=null,                    NeedAction=false,   Icon=null,             Sort=1, CreateTime=DateTime.Now},
                         new Base_Action(){ Id="1193158780011941888",Deleted = false, ParentId="1193158266167758848", Type = (int)ActionType.页面, Name="运营统计", Url="/Home/Statis",                     Value=null,                    NeedAction=false,   Icon=null,             Sort=1, CreateTime=DateTime.Now},
                         new Base_Action(){ Id="1193158266167758849",Deleted = false, ParentId=null,                  Type = (int)ActionType.菜单, Name="消息中心", Url=null,                               Value=null,                    NeedAction=true,    Icon="notification",   Sort=1, CreateTime=DateTime.Now},
                         new Base_Action(){ Id="1193158266167758867",Deleted = false, ParentId="1193158266167758849", Type = (int)ActionType.页面, Name="站内消息", Url="/D_Manage/D_UserMessage/List",     Value=null,                    NeedAction=false,   Icon="message",        Sort=1, CreateTime=DateTime.Now},
                         new Base_Action(){ Id="1193158266167758868",Deleted = false, ParentId="1193158266167758849", Type = (int)ActionType.页面, Name="站内信",   Url="/D_Manage/D_UserMail/Index",       Value=null,                    NeedAction=false,   Icon="mail",          Sort=1, CreateTime=DateTime.Now},
                         new Base_Action(){ Id="1193158266167758869",Deleted = false, ParentId="1193158266167758849", Type = (int)ActionType.页面, Name="通告",     Url="/D_Manage/D_Notice/List",          Value=null,                    NeedAction=false,   Icon="sound",           Sort=1, CreateTime=DateTime.Now},   
                         new Base_Action(){ Id="1193158266167758850",Deleted = false, ParentId=null,                  Type = (int)ActionType.菜单, Name="流程中心", Url=null,                               Value=null,                    NeedAction=true,    Icon="clock-circle",   Sort=1, CreateTime=DateTime.Now},
                         new Base_Action(){ Id="1193158266167758851",Deleted = false, ParentId="1193158266167758850", Type = (int)ActionType.页面, Name="流程管理", Url="/OA_Manage/OA_DefForm/List",       Value=null,                    NeedAction=true,    Icon="interaction",    Sort=1, CreateTime=DateTime.Now},
                         new Base_Action(){ Id="1193158266167758852",Deleted = false, ParentId="1193158266167758851", Type = (int)ActionType.权限, Name="增",       Url=null,                               Value="OA_DefForm.Add",        NeedAction=true,    Icon=null,             Sort=1, CreateTime=DateTime.Now},
                         new Base_Action(){ Id="1193158266167758853",Deleted = false, ParentId="1193158266167758851", Type = (int)ActionType.权限, Name="改",       Url=null,                               Value="OA_DefForm.Edit",       NeedAction=true,    Icon=null,             Sort=1, CreateTime=DateTime.Now},
                         new Base_Action(){ Id="1193158266167758854",Deleted = false, ParentId="1193158266167758851", Type = (int)ActionType.权限, Name="删",       Url=null,                               Value="OA_DefForm.Delete",     NeedAction=true,    Icon=null,             Sort=1, CreateTime=DateTime.Now},
                         new Base_Action(){ Id="1193158266167758855",Deleted = false, ParentId="1193158266167758850", Type = (int)ActionType.页面, Name="发起流程", Url="/OA_Manage/OA_DefForm/TreeList",   Value=null,                    NeedAction=true,    Icon="file-add",       Sort=1, CreateTime=DateTime.Now},
                         new Base_Action(){ Id="1193158266167758856",Deleted = false, ParentId="1193158266167758850", Type = (int)ActionType.页面, Name="我的流程", Url="/OA_Manage/OA_UserForm/List",      Value=null,                    NeedAction=true,    Icon="file-done",      Sort=1, CreateTime=DateTime.Now},
                         new Base_Action(){ Id="1193158266167758860",Deleted = false, ParentId="1193158266167758856", Type = (int)ActionType.权限, Name="增",       Url=null,                               Value="OA_UserForm.Add",       NeedAction=true,    Icon=null,             Sort=1, CreateTime=DateTime.Now},
                         new Base_Action(){ Id="1193158266167758861",Deleted = false, ParentId="1193158266167758856", Type = (int)ActionType.权限, Name="改",       Url=null,                               Value="OA_UserForm.Edit",      NeedAction=true,    Icon=null,             Sort=1, CreateTime=DateTime.Now},
                         new Base_Action(){ Id="1193158266167758862",Deleted = false, ParentId="1193158266167758856", Type = (int)ActionType.权限, Name="删",       Url=null,                               Value="OA_UserForm.Delete",    NeedAction=true,    Icon=null,             Sort=1, CreateTime=DateTime.Now},
                         new Base_Action(){ Id="1193158266167758863",Deleted = false, ParentId="1193158266167758850", Type = (int)ActionType.页面, Name="表单管理", Url="/OA_Manage/OA_DefType/List",       Value=null,                    NeedAction=true,    Icon="form",           Sort=1, CreateTime=DateTime.Now},
                         new Base_Action(){ Id="1193158266167758864",Deleted = false, ParentId="1193158266167758863", Type = (int)ActionType.权限, Name="增",       Url=null,                               Value="OA_DefType.Add",        NeedAction=true,    Icon=null,             Sort=1, CreateTime=DateTime.Now},
                         new Base_Action(){ Id="1193158266167758865",Deleted = false, ParentId="1193158266167758863", Type = (int)ActionType.权限, Name="改",       Url=null,                               Value="OA_DefType.Edit",       NeedAction=true,    Icon=null,             Sort=1, CreateTime=DateTime.Now},
                         new Base_Action(){ Id="1193158266167758866",Deleted = false, ParentId="1193158266167758863", Type = (int)ActionType.权限, Name="删",       Url=null,                               Value="OA_DefType.Delete",     NeedAction=true,    Icon=null,             Sort=1, CreateTime=DateTime.Now},
                         new Base_Action(){ Id="1193158266167758967",Deleted = false, ParentId=null,                  Type = (int)ActionType.菜单, Name="个人页",   Url=null,                               Value=null,                    NeedAction=true,    Icon="user",           Sort=1, CreateTime=DateTime.Now},
                         new Base_Action(){ Id="1193158266167758968",Deleted = false, ParentId="1193158266167758967", Type = (int)ActionType.页面, Name="个人中心", Url="/account/center/Index",            Value=null,                    NeedAction=false,   Icon="user",           Sort=1, CreateTime=DateTime.Now},
                         new Base_Action(){ Id="1193158266167758969",Deleted = false, ParentId="1193158266167758967", Type = (int)ActionType.页面, Name="个人设置", Url="/account/settings/Index",          Value=null,                    NeedAction=false,   Icon="user",           Sort=1, CreateTime=DateTime.Now}, };

                var result = actionBusiness.InsertAsync(actions).Result;
                Console.WriteLine("action created");
            }
            else
            {
                Console.WriteLine("action already exists");
            }

            var appSecretBussiness = ContainerLocator.Current.Resolve<IBase_AppSecretBusiness>();
            var appSecretcount = appSecretBussiness.GetIQueryable().CountAsync().Result;
            if (appSecretcount == 0)
            {
                List<Base_AppSecret> actions = new List<Base_AppSecret>()
                {
                    new Base_AppSecret(){  Id="1172497995938271232", AppId="PcAdmin", AppSecret="wtMaiTRPTT3hrf5e", AppName="后台AppId", CreateTime=DateTime.Now},
                    new Base_AppSecret(){  Id="1173937877642383360", AppId="AppAdmin", AppSecret="IVh9LLSVFcoQPQ5K", AppName="APP密钥", CreateTime=DateTime.Now}
                };
            }          
        }
    }
}