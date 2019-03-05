using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebMVCDemoApplication
{
   /// <summary>
   /// 应用路由配置类
   /// </summary>
   public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {

            // 设定忽略给定可用路由列表和约束列表的指定 URL 路由。
            //参数  url:要忽略的路由的 URL 模式。  
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
           
            routes.MapRoute(  // 设定映射指定的 URL 路由并设置默认路由值和约束。
                name: "Default", // name: 要映射的路由的名称。
                url: "{controller}/{action}/{id}",// url:路由的 URL 模式。
                defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional }
                //defaults: 一个包含默认路由值的对象。
            );
        }
    }
}
