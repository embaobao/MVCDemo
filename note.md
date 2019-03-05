# .NETMVC 基础入门学习笔记 
## Welcome to ASP.NET MVC 记录代码笔记 
>- 作者：  吃火星的宝宝|朱盟
>- GitHub: embaobao  
>- Wechat: 吃火星的宝宝
>- Emil:1132067567@qq.com
>- 163Email:chihuoxingdebaobao@163.com
>- 2019-3.2 17:00    
>- 笔记链接:
>>1. [ASP.NET MVC笔记](https://github.com/embaobao/MVCDemo/blob/master/note.md "点击查看" ) 
>>2. [Markdown 语法笔记](https://github.com/embaobao/MVCDemo/blob/master/MarkDownNote.md "点击查看" ) 
>>
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
##  1. MVC项目模板介绍
###  1.1 MVC 项目的结构


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
### 1.2 MVC 项目的执行阶段
1.接受对应用程序的第一个请求 Global.asax文件执行Application_Start() 方法；
```        
            // 注册 ASP.NET MVC 应用程序中的所有区域。
            AreaRegistration.RegisterAllAreas();  

            //全局配置文件 为 ASP.NET 应用程序提供全局 System.Web.Http.HttpConfiguration  
            //把App_Start 文件夹中WebApiConfig类中Register配置到全局
            GlobalConfiguration.Configure(WebApiConfig.Register);  

            //过滤器配置 把全局筛选器集合放到应用中App_Start 文件夹中 FilterConfig类中RegisterRoutes方法操作配置过滤器
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);  

            //把全局路由表 放在App_Start 文件夹中 RouteConfig类中的RegisterRoutes方法操作配置路由
            RouteConfig.RegisterRoutes(RouteTable.Routes);  

            //把全局bundle collection 放在App_Start 文件夹中  BundleConfig类中的 RegisterBundles方法操作配置全局bundle
            BundleConfig.RegisterBundles(BundleTable.Bundles);
```
2. 执行路由
3. 创建MVC请求处理程序
4. 创建控制器
5. 执行控制器
6. 调用操作
7. 执行结果
>>具体详情再更新 还没摸清楚
___
### 1.3 Controller 与View 的配合关系
> 为啥子没说Model了？歧视？ 可不是哦！！！  
>  在模板中还没有涉及到数据模板，在后面我会学到的！
> 所以先了解控制器和视图之间的配合，来显示数据！

我们不难发现 每个控制器的名字 （去掉Controller）实际上在Views目录下 有文件夹名字所对应  
而控制器的操作方法对应视图目录下的控制器名字目录下会有 方法名.cshtml 文件作为对应

如：

|控制器|对应视图|
|----|:--:|
|HomeController | Views/Home  |
| HomeController. Index()|Views/Home/index.cshtml|
|1. 控制器名字 |对应视图文件夹名字|
|2. 控制器的操作方法|对应视图文件名字 **.cshtml|
>>注：所以我有必要简单了解下路由对吧？
___
### 1.4 ASP.NET MVC模板路由的说明
>#### 1.4.1 *路由是啥？*
>是映射到处理程序上的URL模式。   
>*URL又是啥？* 
>简短说：URL是一个网络地址  表示网络上资源的位置  
>URL是统一资源定位符，对可以从互联网上得到的资源的位置和访问方法的一种简洁的表示，
>是互联网上标准资源的地址  
>详情：[URL百度百科](https://baike.baidu.com/item/url/110640?fr=aladdin"点下到URL的百科")          
>>而路由就是： 该映射到网络资源上的URL  我偏不 ！！！ 我让他映射到咱们的程序上（MVC 上的控制器） 返回点啥。

在MVC 中
#### 1.4.2 App_Start文件夹中 RouteConfig类
```
        public static void RegisterRoutes(RouteCollection routes)
        {

            // 设定忽略给定可用路由列表和约束列表的指定 URL 路由。
            //参数  url:要忽略的路由的 URL 模式。  
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
           
            routes.MapRoute(  // 设定映射指定的 URL 路由并设置默认路由值和约束。
                name: "Default", // name: 要映射的路由的名称。
                url: "{controller}/{action}/{id}",// url:路由的 URL 模式。
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional } 
                //defaults: 一个包含默认路由值的对象。
            );
        }
```
___
#### 1.4.3 URL 路由模式的说明
##### 1.4.3.1 MVC和WEB程序 URL 的映射区别
程序|区别
----|:--:
ASP.NET WEB | WEB 应用程序中 的URL 通常映射到一个页面文件或者一个资源文件|
ASP.NET MVC|URL 通常映射到Controller 类 不直接映射到页码或处理文件等|

>所以URL 要映射到什么地方，  
那么ASP.NET MVC框架就要知道怎么分析我们的URL去映射到你想映射的地方  
所以我们就得定义URL模式  
来告诉程序该怎样解析映射格式，  
你给我这样解析我的URL 别给哦映射到其他地方，搞错了...  
对吧？  
>>举个例子：  
比如路由就是  
我们寄快递  
快递公司给我提供一个快递单子（就是URL模板）   
让我们把收件人和地址填在快递单子的那些地方（路由模板的占位符）  
我们填的地址和收件人（就是形成URL 的参数）  
然后快递员就按照单子上的地址去送（解析路由）
  
>在MVC路由中就是这样 所以我们得设计URL模式  （就是提供快递单子样板）  
>不然请求的啥我都不知道是啥(先写的地址还是收件人我傻傻分不清楚)
##### 1.4.3.2 URL 模式
 定义占位符:
-  要求用大括号包起来 *ps:```{controller}/{action}或者 {controller}-{action}/{id}   就是用一个文本值分开```
-  这是错误的： ```{controller}{action}```他也是很傻的不知道你两个参数的界限* 


 URL路由定义实例:

路由定义|匹配的URL实例|说明
----|---:|---:|
`{`controller`}`/`{`action`}`/`{`id`}` |/Home/index/1 |控制器名/操作方法名/ 值参数|
`{`table`}`/Details.aspx|/Info/Details.aspx|表名称/页面名.aspx|
blog/`{`action`}`/`{`entry`}`|/bolg/edit/2|控制器名/操作方法名/ 值参数|

默认URL模式说明

路由定义|匹配的URL实例|说明
----|---:|---:|
`{`controller`}`/`{`action`}`/`{`id`}` |http://192.168.1.1/Home/index/1 |`{`controller`}` 默认为控制器占位符/`{`action`}`操作方法占位符/ 值参数|

___
## 2.控制器 （必须用Controller结尾命名的类） 
>> 操作方法:就是在控制器类中定义的方法 （后面 操作方法省略为->方法）  

>控制器的作用： 
> - 查找要调用的方法，验证调用权限  
> - 获取调用方法的参数值  
> - 处理执行方法的错误  
> - 提供默认视图引擎   

___
### 2.1 开始创建一个控制器及对应视图   

#### 2.1.1 第一种方式

1. 右击Controllers文件夹 ↓
2. 添加↓
3. 控制器...↓
4. MVC 5控制器 - 空↓
5. LoginController↓
6. 添加↓

如图
 文件夹下多出了  LoginController.cs    
![添加控制器完成](https://github.com/embaobao/MVCDemo/blob/master/01.png?raw=true"添加控制器完成")

默认的代码如下：
```
public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
    }
```

给他改下试试  
先不管这是啥东西昂
```
public ActionResult Index()
        {

            ViewBag.Message = "登录页面";
            return View();
        }

```
选中 ```Index()```方法  
右击  
添加视图
如图：  
![给操作添加视图0](640.png"给操作添加视图0")
默认视图的命名  
![给操作添加视图1](641.png"给操作添加视图1")
 此时观察文件夹时 视图文件夹出现 和控制器中名称对应  
 文件夹下的视图文件出现 和操作方法名对应  
![给操作添加视图2](642.png"给操作添加视图2")

修改视图代码：   显示在控制器中赋的值 ViewBag.Message0  
此处  用的是视图引擎  Razor 他的语法是放在 ‘ @’ 后  
与ASP.NET WEB 中的 <% 代码内容%> 的格式相似
```
@{
    ViewBag.Title = "Index";
}

<h2>Index</h2>
<p> @ViewBag.Message </p>
```

我们可以试调了吗？  
还不行！  
我们试调会默认进入首页  而不会进入 Login 控制器的映射    
所以我们修改默认路由  

前面提到的 在App_Start文件夹中的RouteConfig.cs 类管理路由配置吧？

我们修改他
```
 defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional } 
                //defaults: 一个包含默认路由值的对象。
```
改成  
```
defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional } 
                //defaults: 一个包含默认路由值的对象。
```

效果如下:  
![修改路由后效果图](643.png"修改路由后效果图")
>解释
>  
>- LoginController 继承于 Controller 表示他是控制器  — *LoginController : Controller**  
>- 控制器通过识别URL 来判断执行的方法   
>- ViewBag 可以理解为动态的字典 可以为他添加任何属性 不需要修改他的定义  
>- 通过视图我们可以访问到ViewBag 的属性值  


#### 2.1.2 第二种方法实现

我们也可以先建立视图 在控制器相对应的视图文件夹下  
 - 右击View/Login文件夹  
 - 添加  
 - 视图  
 - 命名视图 Showlogin  
如图  
![建立视图](i2.png"建立视图")
![建立视图](i1.png"建立视图")
如图：  
建立视图成功  
![建立视图](i0.png"建立视图")  
在Login控制器中新建操作方法 Access
代码如下：
```
 // GET: Login
        public ActionResult Access()
        {
            return View("Showlogin");
        }
```
>解释: View();
>如果不传入参数默认返回与方法名相同的视图  
>传入参数 代表指定返回 参数名字的视图  （暂时）   
>在这里我们指定他返回Showlogin 视图  
>稍后我们再详细学习 返回的 ActionResult 中 View 类型； 

修改Showlogin.cshtml 视图代码  
```

@{
    ViewBag.Title = "Showlogin";
}

<h2>登录成功</h2>
<br/>
欢迎您登录系统

```
运行》  
在输入栏中添加调用Access方法的格式：
> http://localhost:端口号/Login/Access  
> 注：在URL上不区分大小写 即： http://localhost:端口号/login/access   也是一样  


成功后如图：  

![调用结果](i3.png"调用结果") 
#### 2.1.3 返回字符串的操作方法

我们也可以 返回一句话而不是视图的操作方法
代码如下：  
```
 // GET: Fail
        public string Fail()
        {
            return "登录失败 请返回重新登录";
        }
```
调用结果如下:   
![返回字符串的操作方法调用结果](i4.png"返回字符串的操作方法调用结果")

 #### 2.1.4 接受参数的操作方法

修改方法 Access 代码如下：  
```
   // GET: Access
        public ActionResult Access(string name,string pw)
        {
            ViewBag.Name = Server.HtmlEncode(name);
            ViewBag.PW = Server.HtmlEncode(pw);
            return View("Showlogin");
        }
```
控制器会分析URL 中的参数  
试调运行  
输入URL:  
>http://localhost:3812/Login/Access?name=embaobao&pw=123456
>


>ps:  
>关于控制器的详细内容我们晚点再学习 相继更新

参数便会传入操作方法中Access ：

通过给 ViewBag 传值 在视图调用  
视图代码如下： 

```
@{
    ViewBag.Title = "Showlogin";
}
<br />
@ViewBag.Name  ,欢迎您登录系统!
<br />
您的密码为：@ViewBag.PW 
```


效果图如下： 
  
![ 接受参数的操作方法](i5.png"接受参数的操作方法")


### 2.2 
待更新...
___

## 3 视图 （控制器的‘对象’-两者呼应）  
>MVC 有两种视图引擎 ：
>- Razor   （MVC 3.0 后添加 ）
>- ASPX （C#） 
>
### 3.1 Razor 视图引擎  

引擎优点：  
- HTML5和C# 语言混合编程的项目模板
- 语法简单  ‘@’表示C# 代码块或者内联块开始 ps:像 JQ中的$ 相似
- Razor 视图增加了对视图页的新的操作
- 页面兼容使用MVC中的模块和类库
- VS 智能提示的支持
- 单元测试友好 可直接编辑测试视图模块



















