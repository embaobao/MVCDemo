# .NETMVC 基础入门学习笔记 
## Welcome to ASP.NET MVC 记录代码笔记 
>- 作者：  吃火星的宝宝|朱盟
>- GitHub: embaobao  
>- Wechat: 吃火星的宝宝  
>- 笔记链接:
>>1. [ASP.NET MVC笔记](https://github.com/embaobao/MVCDemo/blob/master/note.md "点击查看" ) 
>>2. [Markdown 语法笔记](https://github.com/embaobao/MVCDemo/blob/master/MarkDownNote.md "点击查看" ) 
>2019-3.2 17:00  
>*为啥要学习mvc了?*  
>*AJAX技术越来越重要厉害了导致前后端分离趋势*
>*而状态控制的WebForm来刷新页面给用户的体验过差*  
>*但是窗体形式并没有完全被取缔 相反依赖控件* 
>*他的开发速度在小型的项目上肯定会很快的*  
>*MVC 测试驱动 在代码组织逻辑组织上更好与webform*  
>*在和前端交互的控制上完全的实现分离*
>*而他在数据请求上也实现了路由来完成抽象请求*  
>*在三层MVC的组织上结合有更好的项目开发实力*  
> 优点:
>- 任务分离
>- HTML 控制力加强
>- 基于测试驱动
>>注: 
>>- MVC 是什么?  
>> 在 ASP.NET MVC应用程序为 Model-View-Controller 缩写 即为三个主要组件分别为:  
>>   - 模型(Model)         **:业务逻辑 数据控制 包含在Models 文件夹**
>>   - 视图(View)          **:UI 逻辑 包含在Views 文件夹**
>>   - 控制器(Controller)  **: 输入逻辑 包含在Controllers 文件夹**
>>- MVC适合场景: ASP.NET MVC WEB 应用基于测试驱动开发的编程模型,不是为了简化代码开发量,他把重点放在了业务实现的分层控制和代码测试. MVC框架特别适合上百人组成的团队实现大型的WEB应用项目的开发
___

##  1. MVC 项目的结构


>*为什么了解结构？  
MVC应用程序默认遵循一些约定，像：视图文件默认的目录为\Views\[ControllerName]\[ActionName].cshtml
约定胜于配置约定可以简化沟通*  
>*当我们了解MVC 文件夹的结构，尝试去摸清楚之间的约定。那么就意味着我们可以根据经验（约定）编写应用程序而不需要进行配置。别人也可以更容易理解程序，你的程序也更容易被其他人员浏览、阅读和调试、维护。*




文件夹\文件名称|作用|说明  
|---|:--:|---:|
|App_Data|文件夹用于存储应用程序数据|SQL 数据库或者其他数据|
|App_Start| 文件夹用于存放应用程序初始化类库| BundleConfig.cs 用来将js和css进行压缩（多个文件可以打包成一个文件）绑定，并且可以区分调试和非调试(debug为true时为调试模式)，在调试时不进行压缩，以原始方式显示出来，以方便查找问题。 FilterConfig.cs 过滤器配置  RouteConfig.cs 路由配置  WebApiConfig.cs WebApi配置 AuthConfig.cs：配置安全设置，包括网站的OAuth登录，可以让用户用外部提供方的证书（比如Facebook, Twitter, Microsoft,或Google）登陆，然后将源自那些提供方的一些功能集成进你的web应用|
|Areas|独立于项目的区域|开发复杂项目中独立出的部分项目|
|Conten|文件夹用于存放静态文件|样式表（CSS 文件）、图标和图像 自动添加一个标准的样式表文件到项目中：即 content 文件夹中的 Site.css 文件 还有bosstrap 等样式文件 视VS版本而定|
|Controllers|文件夹包含负责处理用户输入和响应的控制器类 | HomeController（用于 Home 页面和 About 页面）和一个AccountController 或者是ValuesController,所有控制器文件的名称以 "Controller"|
|fonts|字体文件|初始有默认字体文件多种格式|
|Models|文件夹包含表示应用程序模型的类|模型控制并操作应用程序的数据|
|Scripts|文件夹存储应用程序的 JavaScript 文件|默认存放标准的 MVC、Ajax、jQuery、boostrap 的js 文件|
|Views|文件夹用于存储与应用程序的显示相关的 HTML 文件（用户界面）|默认包含 Home文件夹对应 HomeController 包含idex.cshtml 主页面、share文件夹中 包含_Layout.cshtml 模板加载页、_ViewStart.cshtml 页面初始化加载母版页||
|favicon.ico|应用标题栏icon|微软默认图标|
|Global.asax|全局配置文件|Web应用是声明周期的事件响应MVC 设置Route对象|
|packages.config|Nuget引用包配置文件|引用包的信息和配置|
|Web.config| 网站配置文件|包含网站的配置信息|
|Properties|程序配置信息(dll文件)程序集|通过Attribute来设置程序集(dll文件)的常规信息或作为配置信息文件供程序内部使用|
|引用|引用的库文件（dll）|用于查看引用类库|

___
>注：MVC 项目版本不一样会有所区别  
当了解这些文件夹或者结构是 会慢慢的掌握MVC 吧？
___
## 2. 项目的开始