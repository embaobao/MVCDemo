using System.Web.Mvc;
using Newtonsoft.Json;

namespace WebMVCDemoApplication.Controllers
{
    public class LoginController : Controller
    {
        public class User
        {
            public string Name { get; set; }
        }
        // GET: Login
        public ActionResult Index()
        {
            //弱类型 Key 字典类型   ViewData  ViewBag 数据共享 键值若相同 则会覆盖
            ViewData["1"] = "哈哈";

            User _user = new User { Name = "embaobao" };
            //ViewData.Model = _user; 
            TempData["Pw"] = "123456"; 
            //dynamic 类型 程序运行动态解析
            ViewBag.Message = "登录页面";
            //展现数据到视图  把_user 传过去 等同于 ViewData.Model=_user
            return View(_user);
        }
        // GET: Access
        public ActionResult Access(string name, string pw)
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
        public JsonResult Login() {
            return Json(new User { Name = "OK" });
                //JsonConvert.SerializeObject(new User { Name = "OK" });
        }

    }
}