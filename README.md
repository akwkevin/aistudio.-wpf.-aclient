# AClient

写在前面，下载请选择net5的分支

#### 介绍
Wpf客户端，AIStudio.Wpf.AClient

![输入图片说明](https://images.gitee.com/uploads/images/2021/0316/221638_6edc08d9_4799126.png "809298-20210314215728859-1650551509.png")


#### 软件架构
本框架使用Prism做MVVM，优点咱就不说了，主要了容器注入，消息和DI，比自己写省很多事。网上有很多标准的MVVM的使用方法，但是没有形成一个系统级的框架。本框架从登录到具体业务的使用，还有自动升级都搭建完成，没有大神写的那么好，只是起个抛砖引玉的作用。
后端使用ASP.net core，采用的是Colder.Admin.AntdVue的框架，强烈推荐大家去看，我在其基础上增加了一些功能，
网页客户端浏览地址http://121.36.12.76:5001/
（账号密码：Admin，Admin）
接口浏览地址http://121.36.12.76:5000/

Wpf客户端下载可以直接运行，默认配置文件 AIStudio.Wpf.Client.exe.Config

```
<appSettings>
    <add key="Title" value="AIStudio" />
    <add key="Language" value="中文" />
    <add key="FontSize" value="16" />
    <add key="FontFamily" value="宋体" />
    <add key="Accent" value="BlueGray" />
    <add key="Theme" value="BaseGray11" />
    <add key="NavigationLocation" value="Left" />
    <add key="NavigationAccent" value="Dark" />
    <add key="TitleAccent" value="Normal" />
    <add key="ToolBarLocation" value="Top" />
    <add key="Version" value="1.0.20201115-rc3" />
    <add key="ServerIP" value="http://121.36.12.76:5000" />
    <add key="UpdateAddress" value="http://121.36.12.76:5000/update" />
  </appSettings>
```


 **快速预览方式1：** 其中ServerIP就是后台接口地址，http://121.36.12.76:5000可直接使用。

账号密码：Admin，Admin。

 **快速预览方式2** ：不需要服务器，客户端直接使用SQLite本地数据，客户端独立运行。账号密码Admin, Admin
```
<add key="ServerIP" value=""/> 
<add key="UpdateAddress" value="http://121.36.12.76:5000/Update/AutoUpdater.xml"/>
<add key="ConString" value="Data Source=Admin.db"/>
<add key="DatabaseType" value="SQLite"/>
<add key="DeleteMode" value="Logic"/>
```
注释掉ServerIP，那么是使用efcore获取数据，改变ConString和DatabaseType即可。另外，默认数据库删除模式为软删除。

 **快速预览方式3** ：启动ServiceMonitor，点击启动服务，待本地服务启动后，可运行客户端进行连接。
```
<add key="ServerIP" value="http://localhost:5000" />
```
![输入图片说明](https://images.gitee.com/uploads/images/2021/0822/170817_84186e95_4799126.png "屏幕截图.png")

 **框架截图** 

![输入图片说明](https://images.gitee.com/uploads/images/2021/0822/170248_4a489e89_4799126.png "屏幕截图.png")

 **系统扩展** ：如果需要扩展自己的页面，只需要按照这个工程的目录进行扩展即可。

![输入图片说明](https://images.gitee.com/uploads/images/2021/0822/171241_88a20e42_4799126.png "屏幕截图.png")
 ```
protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
 {
    var homePageModule = typeof(HomePageModule);
    moduleCatalog.AddModule(new ModuleInfo()
    {
        ModuleName = homePageModule.Name,
        ModuleType = homePageModule.AssemblyQualifiedName,
        InitializationMode = InitializationMode.WhenAvailable
    });

    var base_ManageModule = typeof(Base_ManageModule);
    moduleCatalog.AddModule(new ModuleInfo()
    {
        ModuleName = base_ManageModule.Name,
        ModuleType = base_ManageModule.AssemblyQualifiedName,
        InitializationMode = InitializationMode.WhenAvailable
    });

    //在这里添加你新增的
}
```

个人QQ:80267720
QQ技术交流群:51286643（进群提供服务端的开源代码地址）
个人博客:https://www.cnblogs.com/akwkevin/




<section id="nice" data-tool="mdnice编辑器" data-website="https://www.mdnice.com" style="font-size: 16px; color: black; padding: 0 10px; line-height: 1.6; word-spacing: 0px; letter-spacing: 0px; word-break: break-word; word-wrap: break-word; text-align: left; font-family: Optima-Regular, Optima, PingFangSC-light, PingFangTC-light, 'PingFang SC', Cambria, Cochin, Georgia, Times, 'Times New Roman', serif;"><h2 data-tool="mdnice编辑器" style="margin-top: 30px; margin-bottom: 15px; padding: 0px; font-weight: bold; color: black; font-size: 22px;"><span class="prefix" style="display: none;"></span><span class="content">登录界面</span><span class="suffix"></span></h2>
<figure data-tool="mdnice编辑器" style="margin: 0; margin-top: 10px; margin-bottom: 10px; display: flex; flex-direction: column; justify-content: center; align-items: center;"><img src="https://files.mdnice.com/user/17967/2d38db2c-3736-479f-822f-45828e846d15.gif" alt style="display: block; margin: 0 auto; max-width: 100%;"></figure>
<h2 data-tool="mdnice编辑器" style="margin-top: 30px; margin-bottom: 15px; padding: 0px; font-weight: bold; color: black; font-size: 22px;"><span class="prefix" style="display: none;"></span><span class="content">主题设置</span><span class="suffix"></span></h2>
<figure data-tool="mdnice编辑器" style="margin: 0; margin-top: 10px; margin-bottom: 10px; display: flex; flex-direction: column; justify-content: center; align-items: center;"><img src="https://files.mdnice.com/user/17967/c309e5b4-9851-4d64-b0fe-5a2b61f3a1ce.gif" alt style="display: block; margin: 0 auto; max-width: 100%;"></figure>
<h2 data-tool="mdnice编辑器" style="margin-top: 30px; margin-bottom: 15px; padding: 0px; font-weight: bold; color: black; font-size: 22px;"><span class="prefix" style="display: none;"></span><span class="content">用户管理</span><span class="suffix"></span></h2>
<figure data-tool="mdnice编辑器" style="margin: 0; margin-top: 10px; margin-bottom: 10px; display: flex; flex-direction: column; justify-content: center; align-items: center;"><img src="https://files.mdnice.com/user/17967/bd3dab1e-b958-4ee7-a5dc-c4095f91b6d0.png" alt style="display: block; margin: 0 auto; max-width: 100%;"></figure>
<h2 data-tool="mdnice编辑器" style="margin-top: 30px; margin-bottom: 15px; padding: 0px; font-weight: bold; color: black; font-size: 22px;"><span class="prefix" style="display: none;"></span><span class="content">角色管理</span><span class="suffix"></span></h2>
<figure data-tool="mdnice编辑器" style="margin: 0; margin-top: 10px; margin-bottom: 10px; display: flex; flex-direction: column; justify-content: center; align-items: center;"><img src="https://files.mdnice.com/user/17967/9d2c827b-ab65-4ba9-bc97-c4f3197cb4c5.png" alt style="display: block; margin: 0 auto; max-width: 100%;"></figure>
<h2 data-tool="mdnice编辑器" style="margin-top: 30px; margin-bottom: 15px; padding: 0px; font-weight: bold; color: black; font-size: 22px;"><span class="prefix" style="display: none;"></span><span class="content">部门管理</span><span class="suffix"></span></h2>
<figure data-tool="mdnice编辑器" style="margin: 0; margin-top: 10px; margin-bottom: 10px; display: flex; flex-direction: column; justify-content: center; align-items: center;"><img src="https://files.mdnice.com/user/17967/9198d6f8-9aa7-41f9-9026-592f7e7d142e.png" alt style="display: block; margin: 0 auto; max-width: 100%;"></figure>
<h2 data-tool="mdnice编辑器" style="margin-top: 30px; margin-bottom: 15px; padding: 0px; font-weight: bold; color: black; font-size: 22px;"><span class="prefix" style="display: none;"></span><span class="content">操作日志</span><span class="suffix"></span></h2>
<figure data-tool="mdnice编辑器" style="margin: 0; margin-top: 10px; margin-bottom: 10px; display: flex; flex-direction: column; justify-content: center; align-items: center;"><img src="https://files.mdnice.com/user/17967/c863a2a2-4f23-4073-ac36-5c315ef53951.png" alt style="display: block; margin: 0 auto; max-width: 100%;"></figure>
<h2 data-tool="mdnice编辑器" style="margin-top: 30px; margin-bottom: 15px; padding: 0px; font-weight: bold; color: black; font-size: 22px;"><span class="prefix" style="display: none;"></span><span class="content">任务管理</span><span class="suffix"></span></h2>
<figure data-tool="mdnice编辑器" style="margin: 0; margin-top: 10px; margin-bottom: 10px; display: flex; flex-direction: column; justify-content: center; align-items: center;"><img src="https://files.mdnice.com/user/17967/ff3e8bc0-cd6e-4e51-8f16-d7c0995f110c.png" alt style="display: block; margin: 0 auto; max-width: 100%;"></figure>
<h2 data-tool="mdnice编辑器" style="margin-top: 30px; margin-bottom: 15px; padding: 0px; font-weight: bold; color: black; font-size: 22px;"><span class="prefix" style="display: none;"></span><span class="content">权限管理</span><span class="suffix"></span></h2>
<figure data-tool="mdnice编辑器" style="margin: 0; margin-top: 10px; margin-bottom: 10px; display: flex; flex-direction: column; justify-content: center; align-items: center;"><img src="https://files.mdnice.com/user/17967/40c54418-0046-4893-a492-2b424128b413.png" alt style="display: block; margin: 0 auto; max-width: 100%;"></figure>
<h2 data-tool="mdnice编辑器" style="margin-top: 30px; margin-bottom: 15px; padding: 0px; font-weight: bold; color: black; font-size: 22px;"><span class="prefix" style="display: none;"></span><span class="content">我的控制台</span><span class="suffix"></span></h2>
<figure data-tool="mdnice编辑器" style="margin: 0; margin-top: 10px; margin-bottom: 10px; display: flex; flex-direction: column; justify-content: center; align-items: center;"><img src="https://files.mdnice.com/user/17967/13f3c3e5-e2cb-43bc-a0c8-087e10beeeed.png" alt style="display: block; margin: 0 auto; max-width: 100%;"></figure>
<h2 data-tool="mdnice编辑器" style="margin-top: 30px; margin-bottom: 15px; padding: 0px; font-weight: bold; color: black; font-size: 22px;"><span class="prefix" style="display: none;"></span><span class="content">3D展台</span><span class="suffix"></span></h2>
<figure data-tool="mdnice编辑器" style="margin: 0; margin-top: 10px; margin-bottom: 10px; display: flex; flex-direction: column; justify-content: center; align-items: center;"><img src="https://files.mdnice.com/user/17967/98558310-7810-4486-8d54-3fc13cc3e746.png" alt style="display: block; margin: 0 auto; max-width: 100%;"></figure>
<h2 data-tool="mdnice编辑器" style="margin-top: 30px; margin-bottom: 15px; padding: 0px; font-weight: bold; color: black; font-size: 22px;"><span class="prefix" style="display: none;"></span><span class="content">站内消息</span><span class="suffix"></span></h2>
<figure data-tool="mdnice编辑器" style="margin: 0; margin-top: 10px; margin-bottom: 10px; display: flex; flex-direction: column; justify-content: center; align-items: center;"><img src="https://files.mdnice.com/user/17967/7e926bae-7a22-4edf-b163-03d72b95193a.png" alt style="display: block; margin: 0 auto; max-width: 100%;"></figure>
<h2 data-tool="mdnice编辑器" style="margin-top: 30px; margin-bottom: 15px; padding: 0px; font-weight: bold; color: black; font-size: 22px;"><span class="prefix" style="display: none;"></span><span class="content">站内信</span><span class="suffix"></span></h2>
<figure data-tool="mdnice编辑器" style="margin: 0; margin-top: 10px; margin-bottom: 10px; display: flex; flex-direction: column; justify-content: center; align-items: center;"><img src="https://files.mdnice.com/user/17967/3992a7ac-a823-45dc-9d46-87e39b1c2c29.png" alt style="display: block; margin: 0 auto; max-width: 100%;"></figure>
<h2 data-tool="mdnice编辑器" style="margin-top: 30px; margin-bottom: 15px; padding: 0px; font-weight: bold; color: black; font-size: 22px;"><span class="prefix" style="display: none;"></span><span class="content">通告</span><span class="suffix"></span></h2>
<figure data-tool="mdnice编辑器" style="margin: 0; margin-top: 10px; margin-bottom: 10px; display: flex; flex-direction: column; justify-content: center; align-items: center;"><img src="https://files.mdnice.com/user/17967/09bde92b-06bd-42ff-a81d-6f6912b74fb0.png" alt style="display: block; margin: 0 auto; max-width: 100%;"></figure>
<h2 data-tool="mdnice编辑器" style="margin-top: 30px; margin-bottom: 15px; padding: 0px; font-weight: bold; color: black; font-size: 22px;"><span class="prefix" style="display: none;"></span><span class="content">发起流程</span><span class="suffix"></span></h2>
<figure data-tool="mdnice编辑器" style="margin: 0; margin-top: 10px; margin-bottom: 10px; display: flex; flex-direction: column; justify-content: center; align-items: center;"><img src="https://files.mdnice.com/user/17967/d6d6b0bc-97ff-4a23-8d2c-12bbba411f57.png" alt style="display: block; margin: 0 auto; max-width: 100%;"></figure>
<h2 data-tool="mdnice编辑器" style="margin-top: 30px; margin-bottom: 15px; padding: 0px; font-weight: bold; color: black; font-size: 22px;"><span class="prefix" style="display: none;"></span><span class="content">表单管理</span><span class="suffix"></span></h2>
<figure data-tool="mdnice编辑器" style="margin: 0; margin-top: 10px; margin-bottom: 10px; display: flex; flex-direction: column; justify-content: center; align-items: center;"><img src="https://files.mdnice.com/user/17967/446930ef-d909-4c82-aeba-1e62c2cb8c34.png" alt style="display: block; margin: 0 auto; max-width: 100%;"></figure>
<h2 data-tool="mdnice编辑器" style="margin-top: 30px; margin-bottom: 15px; padding: 0px; font-weight: bold; color: black; font-size: 22px;"><span class="prefix" style="display: none;"></span><span class="content">流程管理</span><span class="suffix"></span></h2>
<figure data-tool="mdnice编辑器" style="margin: 0; margin-top: 10px; margin-bottom: 10px; display: flex; flex-direction: column; justify-content: center; align-items: center;"><img src="https://files.mdnice.com/user/17967/68d3b8e8-6aac-4bfc-b81a-ff1c936c02b4.png" alt style="display: block; margin: 0 auto; max-width: 100%;"></figure>
<h2 data-tool="mdnice编辑器" style="margin-top: 30px; margin-bottom: 15px; padding: 0px; font-weight: bold; color: black; font-size: 22px;"><span class="prefix" style="display: none;"></span><span class="content">我的流程</span><span class="suffix"></span></h2>
<figure data-tool="mdnice编辑器" style="margin: 0; margin-top: 10px; margin-bottom: 10px; display: flex; flex-direction: column; justify-content: center; align-items: center;"><img src="https://files.mdnice.com/user/17967/704cbdfe-c10f-4873-9923-a30e08b71664.png" alt style="display: block; margin: 0 auto; max-width: 100%;"></figure>
<h2 data-tool="mdnice编辑器" style="margin-top: 30px; margin-bottom: 15px; padding: 0px; font-weight: bold; color: black; font-size: 22px;"><span class="prefix" style="display: none;"></span><span class="content">代码生成</span><span class="suffix"></span></h2>
<figure data-tool="mdnice编辑器" style="margin: 0; margin-top: 10px; margin-bottom: 10px; display: flex; flex-direction: column; justify-content: center; align-items: center;"><img src="https://files.mdnice.com/user/17967/ff4de71d-020d-4e70-8c7a-6589bbbf7049.png" alt style="display: block; margin: 0 auto; max-width: 100%;"></figure>
<h2 data-tool="mdnice编辑器" style="margin-top: 30px; margin-bottom: 15px; padding: 0px; font-weight: bold; color: black; font-size: 22px;"><span class="prefix" style="display: none;"></span><span class="content">多窗口，多屏模式</span><span class="suffix"></span></h2>
<figure data-tool="mdnice编辑器" style="margin: 0; margin-top: 10px; margin-bottom: 10px; display: flex; flex-direction: column; justify-content: center; align-items: center;"><img src="https://files.mdnice.com/user/17967/b710141f-ccef-4723-be1e-82d3e3bb02aa.png" alt style="display: block; margin: 0 auto; max-width: 100%;"></figure>
</section>