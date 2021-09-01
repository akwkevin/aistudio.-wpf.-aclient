# AClient

写在前面，下载请选择net5的分支

#### 介绍
Wpf客户端，AIStudio.Wpf.AClient

![输入图片说明](https://images.gitee.com/uploads/images/2021/0316/221638_6edc08d9_4799126.png "809298-20210314215728859-1650551509.png")


#### 软件架构
本框架使用Prism做MVVM，优点咱就不说了，主要了容器注入，消息和DI，比自己写省很多事。网上有很多标准的MVVM的使用方法，但是没有形成一个系统级的框架。本框架从登录到具体业务的使用，还有自动升级都搭建完成，没有大神写的那么好，只是起个抛砖引玉的作用。
后端使用ASP.net core，采用的是Colder.Admin.AntdVue的框架，强烈推荐大家去看，我在其基础上增加了一些功能.
本项目使用的控件库Util.Controls也是开源的， **完全兼容MahApps.Metro** ，可以与MahApps.Metro同时使用，大家可在我的码云上下载。

其它技术特点：AOP,MAP

网页客户端浏览地址http://121.36.12.76:5001/
（账号密码：Admin，Admin）
接口浏览地址http://121.36.12.76:5000/swagger/index.html

#### 快速预览
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

#### 登录界面

快速预览方式可直接在登录界面进行切换。
![输入图片说明](https://images.gitee.com/uploads/images/2021/0829/155127_88a0408b_4799126.png "屏幕截图.png")

####  **框架截图** 

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

####  **快速代码生成** ：

1.在数据库添加新表。

2.选择代码生成菜单，选中查询回来的新表，区域为你所加界面的工程，比如默认值Base_Manage，将把页面加到AIStudio.Wpf.Base_Manage工程下。

3.点击生成即可，重新启动客户端即可快速预览（前提是服务端也用代码生成器生成(在web端的代码生成器)了相应的控制器与接口）

![输入图片说明](https://images.gitee.com/uploads/images/2021/0829/172904_ed6373e9_4799126.png "屏幕截图.png")

#### 技术交流
个人QQ:80267720
QQ技术交流群:51286643（进群提供服务端的开源代码地址）
个人博客:https://www.cnblogs.com/akwkevin/


#### 更多
界面截图请到博客介绍：https://www.cnblogs.com/akwkevin/p/14534441.html

