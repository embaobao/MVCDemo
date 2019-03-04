using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMVCDemoApplication.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {

            ViewBag.Message = "登录页面";
            //展现数据到视图
            return View();
        }
        // GET: Access
        public ActionResult Access(string name,string pw)
        {
            ViewBag.Name = Server.HtmlEncode(name);
            ViewBag.PW = Server.HtmlEncode(pw);
            return View("Showlogin");
        }
        // GET: Fail
        public string Fail()
        {
            return "登录失败 请返回重新登录";
        }

    }
}