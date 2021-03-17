# AClient

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


其中ServerIP就是后台接口地址，http://121.36.12.76:5000可直接使用。

账号密码：Admin，Admin。
如果不连服务器，只看DemoPage，账号密码LocalUser，LocalUser。

注1：引用的控件包（比较乱，没有整理，后期再公开），需要添加在nuget包管理器中添加源 http://121.36.12.76:8020/v3/index.json。

![输入图片说明](https://images.gitee.com/uploads/images/2021/0316/221422_67f12595_4799126.png "809298-20210316220213368-2073205544.png")

注2：如果不想引用控件包，可以去仓库https://gitee.com/akwkevin/aistudio.-wpf.-min-aclient
下载裁剪版本，下载后可直接运行，但是没有集成oa和消息。


个人QQ:80267720
QQ技术交流群:51286643