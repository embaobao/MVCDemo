using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace WebMVCDemoApplication
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        /// <summary>
        /// 程序开始  全局文件 应用入口
        /// </summary>
        protected void Application_Start()
        {

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

        }
    }
}
